using Bump.EStore.Infrastructure.Criteria;
using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bump.EStore.Infrastructure.Repositories.DapperRepositories
{
	public class OrderRepository
	{
		private readonly string _connStr;
		public OrderRepository()
		{
			_connStr = System.Configuration.ConfigurationManager.ConnectionStrings["AppDbContext"].ConnectionString;
		}

		public List<OrdersVM> TotalSearch(OrderCriteria criteria)
		{
			var parameters = new DynamicParameters();

			var whereConditions = new List<string>();
			var whereStatement = string.Empty;

			if (!string.IsNullOrEmpty(criteria.MemberName))
			{
				whereConditions.Add($" m.Name LIKE @MemberName");
				parameters.Add("MemberName", $"%{criteria.MemberName}%");
			}

			if (criteria.MemberId.HasValue)
			{
				whereConditions.Add($" m.Id LIKE @MemberId");
				parameters.Add("MemberId", $"%{criteria.MemberId}%");
			}

			if (!string.IsNullOrEmpty(criteria.MemberEmail))
			{
				whereConditions.Add($" m.Email LIKE @MemberEmail");
				parameters.Add("MemberEmail", $"%{criteria.MemberEmail}%");
			}

			if (!string.IsNullOrEmpty(criteria.MemberPhone))
			{
				whereConditions.Add($" m.PhoneNumber LIKE @MemberPhone");
				parameters.Add("MemberPhone", $"%{criteria.MemberPhone}%");
			}

			if (!string.IsNullOrEmpty(criteria.RecipientName))
			{
				whereConditions.Add($" o.RecipientName LIKE @RecipientName");
				parameters.Add("RecipientName", $"%{criteria.RecipientName}%");
			}

			if (!string.IsNullOrEmpty(criteria.RecipientPhone))
			{
				whereConditions.Add($" o.RecipientPhone LIKE @RecipientPhone");
				parameters.Add("RecipientPhone", $"%{criteria.RecipientPhone}%");
			}

			if (!string.IsNullOrEmpty(criteria.RecipientAddress))
			{
				whereConditions.Add($" o.RecipientAddress LIKE @RecipientAddress");
				parameters.Add("RecipientAddress", $"%{criteria.RecipientAddress}%");
			}

			if (!string.IsNullOrEmpty(criteria.ProductName))
			{
				whereConditions.Add($" o.[Id]  IN \r\n(SELECT OrderId \r\nFROM OrderDetails \r\nWHERE ProductName like @ProductName)");
				parameters.Add("ProductName", $"%{criteria.ProductName}%");
			}

			if (!string.IsNullOrEmpty(criteria.ProductCode))
			{
				whereConditions.Add($" o.[Id] IN \r\n(SELECT OrderId \r\nFROM OrderDetails \r\nINNER JOIN Products ON Products.Id = OrderDetails.ProductId \r\nWHERE Code like @ProductCode)");
				parameters.Add("ProductCode", $"%{criteria.ProductCode}%");
			}

			if (criteria.OrderId.HasValue)
			{
				whereConditions.Add($" o.Id LIKE @OrderId");
				parameters.Add("OrderId", $"%{criteria.OrderId}%");
			}

			if (!string.IsNullOrEmpty(criteria.CreateTime))
			{
				whereConditions.Add($" o.CreateAt LIKE @CreateTime");
				parameters.Add("CreateTime", $"%{criteria.CreateTime}%");
			}

			if (criteria.OrderStatus.HasValue)
			{
				whereConditions.Add($" o.OrderStatusId LIKE @OrderStatus");
				parameters.Add("OrderStatus", $"%{criteria.OrderStatus}%");
			}

			if (criteria.MinPrice.HasValue)
			{
				whereConditions.Add($" o.TotalProductsPrice >= @MinPrice");
				parameters.Add("MinPrice", $"{criteria.MinPrice}");
			}

			if (criteria.MaxPrice.HasValue)
			{
				whereConditions.Add($" o.TotalProductsPrice <= @MaxPrice");
				parameters.Add("MaxPrice", $"{criteria.MaxPrice}");
			}

			if (whereConditions.Any())
			{
				whereStatement = $"\nWHERE {string.Join("\nAND", whereConditions)}\n";
			}


			string sql = $@"
SELECT o.[Id] as OrderId, m.[Name] as MemberName, o.TotalProductsPrice, o.CreateAt , s.[Name] as OrderStatusName, 
d.ProductName, d.Quantity, d.UnitPrice
FROM Orders as o
INNER JOIN OrderDetails as d on d.OrderId = o.Id
INNER JOIN Members as m on m.Id = o.MemberId
INNER JOIN OrderStatuses as s on s.Id = o.OrderStatusId
INNER JOIN Products as p on p.id = d.ProductId {whereStatement}
ORDER BY o.Id DESC;";
			IEnumerable<OrdersVM> orders = new SqlConnection(_connStr).Query<OrdersVM, OrderDetailVM, OrdersVM>(
				sql,
				(order, orderDetail) =>
				{ 
					if (order.Details is null)
					{
						order.Details = new List<OrderDetailVM>();
					}
					order.Details.Add(orderDetail);
					return order;
				},
				splitOn: "ProductName" ,
				param: parameters
			);

			var result = orders
				.GroupBy(o => o.OrderId)
				.Select(g =>
				{
					var groupedOrder = g.First();
					groupedOrder.Details = g.Select(o => o.Details.Single()).ToList();
					return groupedOrder;
				})
				.ToList();

			return result;
		}

		public List<SearchOrdersVM> TotalDetailSearch(int id)
		{
			string sql = @"
SELECT o.Id as OrderId, m.Name as MemberName, o.MemberId, o.RecipientName, o.RecipientPhone,
o.RecipientAddress,o.CreateAt, o.[Snapshot], o.DeliverPrice,o.DiscountPrice,
o.UsedPoint,o.Note,o.TotalProductsPrice, o.OrderStatusId, r.CreatedAt as  ReturnCreateAt,
r.Quantity as ReturnQuantity,r.Subtotal as  ReturnSubtotal, r.ProductName as ReturnProductName
FROM Orders as o
INNER JOIN Members as m on m.Id = o.MemberId
INNER JOIN OrderStatuses as s on s.Id = o.OrderStatusId
LEFT JOIN OrderReturnDetails as r on r.OrderId = o.Id
WHERE o.Id = @Id;";
			IEnumerable<SearchOrdersVM> orders = new SqlConnection(_connStr).Query<SearchOrdersVM, ReturnOrderVM, SearchOrdersVM>(
				sql, 
				(order, returnOrder) =>
				{
					if (order.Returns is null)
					{
						order.Returns = new List<ReturnOrderVM>();
					}
					order.Returns.Add(returnOrder);
					return order;
				},
				new { Id = id },
				splitOn: "ReturnQuantity"

			);

			var result = orders
				.GroupBy(o => o.OrderId)
				.Select(g =>
				{
					var groupedOrder = g.First();
					groupedOrder.Returns = g.Select(o => o.Returns.Single()).ToList();
					return groupedOrder;
				})
				.ToList();

			return result;
		}

		public List<ChartVM> MonthOfChart(int year, int month)
		{
			string sql = @"
SELECT 
    DATEPART(DAY, CreateAt) AS DayOfMonth,
    SUM(TotalProductsPrice) AS TotalAmount
FROM 
    Orders
WHERE 
    YEAR(CreateAt) = @Year
    AND MONTH(CreateAt) = @Month
GROUP BY 
    DATEPART(DAY, CreateAt)
ORDER BY 
    DATEPART(DAY, CreateAt);";

			IEnumerable<ChartVM> categories = new SqlConnection(_connStr)
														.Query<ChartVM>(sql,
														new { Year = year, Month = month });

			return categories.ToList();
		}

	}

	public class ChartVM
	{
        public int DayOfMonth { get; set; }

        public int TotalAmount { get; set; }
    }

	public class OrdersVM
	{
		[Display(Name = "訂單編號")]
		public int OrderId { get; set; }


		[Display(Name = "會員名稱")]
		public string MemberName { get; set; }

		[Display(Name = "產品資訊")]
		public List<OrderDetailVM> Details { get; set; }


		[Display(Name = "總金額")]
		public int TotalProductsPrice { get; set; }


		[Display(Name = "訂單成立時間")]
		public DateTime CreateAt { get; set; }


		[Display(Name = "訂單狀態")]
		public string OrderStatusName { get; set; }

	}

	public class OrderDetailVM
	{
		
		public int OrderId { get; set; }


		[Display(Name = "產品名稱")]
		public string ProductName { get; set; }

		[Display(Name = "數量")]
		public int Quantity { get; set; }

		[Display(Name = "單價")]
		public int UnitPrice { get; set; }
	}
		


	public class SearchOrdersVM
	{
		[Display(Name = "訂單編號")]
		public int OrderId { get; set; }

		[Display(Name = "收件人名稱")]
		public string RecipientName { get; set; }

		[Display(Name = "收件人電話")]
		public string RecipientPhone { get; set; }

		[Display(Name = "收件人地址")]
		public string RecipientAddress { get; set; }

		[Display(Name = "訂購進度")]
		public int OrderStatusId { get; set; }

		[Display(Name = "訂單成立時間")]
		[JsonIgnore]
		public DateTime CreateAt { get; set; }

		[Display(Name = "退貨成立時間")]
		[JsonIgnore]
		public DateTime? ReturnCreateAt { get; set; }
		public string CreateAtString => CreateAt.ToString();

		public string ReturnCreateAtString => ReturnCreateAt.ToString();


		[Display(Name = "備註")]
		public string Note { get; set; }

		[Display(Name = "總金額")]
		public int TotalProductsPrice { get; set; }

		[Display(Name = "運費")]
		public int DeliverPrice { get; set; }

		[Display(Name = "折價券")]
		public int DiscountPrice { get; set; }

		[Display(Name = "紅利點數")]
		public int UsedPoint { get; set; }
		
		[Display(Name = "會員名稱")]
		public string MemberName { get; set; }

		[Display(Name = "會員編號")]
		public int MemberId { get; set; }

		[Display(Name = "訂單截圖")]
		public string Snapshot { get; set; }

		[Display(Name = "退貨資訊")]
		public List<ReturnOrderVM> Returns { get; set; }

	}

	public class ReturnOrderVM
	{
		[Display(Name = "退貨數量")]
		public int? ReturnQuantity { get; set; }

		[Display(Name = "退貨小計")]
		public int? ReturnSubtotal { get; set; }

		[Display(Name = "退貨產品名稱")]
		public string ReturnProductName { get; set; }
	}
	
}
