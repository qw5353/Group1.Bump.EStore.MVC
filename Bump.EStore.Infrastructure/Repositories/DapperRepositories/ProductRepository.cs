using Bump.EStore.Infrastructure.Criteria;
using Bump.EStore.Infrastructure.Data.EFModels;
using Bump.EStore.Infrastructure.Repositories.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace Bump.EStore.Infrastructure.Repositories.DapperRepositories
{
	public class ProductRepository : IProductsRepository
	{

		public IEnumerable<Product> Search(int pageNumber, int rowsPerPage, ProductCriteria criteria)
		{
		
			var parameters = new DynamicParameters(new
			{
				OffsetRows = (pageNumber - 1) * rowsPerPage,
				FetchRows = rowsPerPage
			});
		    (string whereConditions, DynamicParameters parametersResult) whereStatement = GetProductFilterWhereStatment(criteria, parameters);

			string sql = @"SELECT
P.Id,P.Name,P.Code,P.Price,P.Thumbnail,P.CreateAt,
P.UpdateTime,P.ShelfStatus,B.Name
FROM Products P
JOIN Brands B on B.Id = P.BrandId 
JOIN ThirdCategories T on T.Id =  P.ThirdCategoryId
JOIN SecondCategories S on S.Id = T.SecondCategoryId
JOIN FirstCategories F on F.Id = S.FirstCategoryId
WHERE 1 = 1 " + "\n"+
whereStatement.whereConditions +
@"ORDER BY P.Id
OFFSET @OffsetRows ROWS
FETCH NEXT @FetchRows ROWS ONLY; " ;

			using (var conn = SqlConnectionFactory.Create())
			{	
					return conn.Query<Product, Brand, Product>(sql, (product, brand) =>
					{
						product.Brand = brand;
						return product;
					},
					splitOn: "Name",
					param: whereStatement.parametersResult);
				
			}
		}

		private (string, DynamicParameters) GetProductFilterWhereStatment(ProductCriteria criteria,DynamicParameters parameters)
		{
			string whereConditions = "";
			if (!string.IsNullOrEmpty(criteria.Name))
			{
				whereConditions = whereConditions + $" AND P.Name like @Name \n";
				parameters.Add("Name", $"%{criteria.Name}%");
			}
			if (!string.IsNullOrEmpty(criteria.Code))
			{
				whereConditions = whereConditions + $" AND P.Code like @Code \n";
				parameters.Add("Code", $"%{criteria.Code}%");
			}
			if (criteria.BrandId.HasValue)
			{
				whereConditions = whereConditions + $" AND P.BrandId = {criteria.BrandId} \n";
			}
			if (criteria.MinPrice.HasValue)
			{
				whereConditions = whereConditions + $" AND P.Price >= {criteria.MinPrice} \n";
			}
			if (criteria.MaxPrice.HasValue)
			{
				whereConditions = whereConditions + $" AND P.Price <= {criteria.MaxPrice} \n";
			}

			if (criteria.FirstCategoryId.HasValue)
			{
				whereConditions = whereConditions + $" AND F.Id = {criteria.FirstCategoryId} \n";
			}

			if (criteria.SecondCategoryId.HasValue)
			{
				whereConditions = whereConditions + $" AND S.Id = {criteria.SecondCategoryId} \n";
			}

			if (criteria.ThirdCategoryId.HasValue)
			{
				whereConditions = whereConditions + $" AND P.ThirdCategoryId = {criteria.ThirdCategoryId} \n";
			}

			return (whereConditions,parameters);
		}

		public int Count(ProductCriteria criteria)
		{
			var parameters = new DynamicParameters();
			(string whereConditions, DynamicParameters parametersResult) whereStatement = GetProductFilterWhereStatment(criteria,parameters);

			using (var conn = SqlConnectionFactory.Create())
			{
				string sql = $@"SELECT COUNT(*)
FROM Products P
JOIN Brands B on B.Id = P.BrandId 
JOIN ThirdCategories T on T.Id =  P.ThirdCategoryId
JOIN SecondCategories S on S.Id = T.SecondCategoryId
JOIN FirstCategories F on F.Id = S.FirstCategoryId
Where 1 = 1 " +"\n"+
whereStatement.whereConditions + ";";

				int count = conn.ExecuteScalar<int>(sql, whereStatement.parametersResult);
				return count;
			}
		}
		public bool Create(Product product)
		{
			string sql = @"INSERT INTO Products(
ThirdCategoryId,BrandId,Name,Code,Price,ShortDescription,Description,Thumbnail,CreateAt,UpdateTime,ShelfStatus)
Values
(@ThirdCategoryId,@BrandId,@Name,@Code,@Price,
@ShortDescription,@Description,@Thumbnail,getDate(),getDate(),
@ShelfStatus);";
			using (var conn = SqlConnectionFactory.Create())
			{
				int rowsAffected = conn.Execute(sql, product); 

				return rowsAffected > 0;
			}

		}

		public bool UpdateShelfStatus(int id, string shelfStatus)
		{
			var parameters = new DynamicParameters();
			parameters.Add("@ShelfStatus", shelfStatus);
			parameters.Add("@Id", id);
			string sql = @"UPDATE Products
SET ShelfStatus = @ShelfStatus,
    UpdateTime  = getDate()
WHERE Id = @Id ";
			using (var conn = SqlConnectionFactory.Create())
			{
				int rowsAffected = conn.Execute(sql, parameters);

				bool isUpdated = rowsAffected > 0;

				return isUpdated;
			}
		}

		public Product GetProductEdits(int? id)
		{
			string sql = @"SELECT
P.Id,P.ThirdCategoryId,P.Thumbnail,P.[Name],P.ShortDescription,
P.[Description],P.BrandId,P.Price,PS.Style
FROM Products P
JOIN ProductStyles PS on PS.ProductId = P.Id
WHERE P.Id = @ProductId;
";
			using (var conn = SqlConnectionFactory.Create())
			{
				IEnumerable<Product> products = conn.Query<Product, ProductStyle, Product>(sql, (product,productStyle) =>
				{
					product.ProductStyles = new List<ProductStyle>()
					{
						productStyle
					};

					return product;
				},
					splitOn: "Style",
					param: new
					{
						@ProductId = id
					}
				);

				var productsDistinct = products
					.GroupBy(p => p.Id)
					.Select(g =>
					{
						var product = g.First();
						product.ProductStyles = g.Select(ps => ps.ProductStyles.Single()).ToList();
						return product;
					})
					.FirstOrDefault();

				return productsDistinct;
			}
		}

		public bool Edit(Product product)
		{
			string imageCheck = string.IsNullOrWhiteSpace(product.Thumbnail) ? "" : "\n Thumbnail = @Thumbnail,\n";
			string sql = @"UPDATE Products
SET ThirdCategoryId = @ThirdCategoryId,
    BrandId = @BrandId,
	[Name] = @Name,
	Price = @Price,
	ShortDescription = @ShortDescription,
	[Description] = @Description," + imageCheck +
	@"UpdateTime = getDate()
WHERE Id = @Id;";

			using (var conn = SqlConnectionFactory.Create())
			{
				int rowsAffected = conn.Execute(sql, product);
				bool isUpdated = rowsAffected > 0;

				return isUpdated;
			}
		}

		public int Delete(int? id)
		{
			if (id == null) return 0;

			string sql = @"
DELETE FROM Products
WHERE id = @id ;";
			try
			{
				using (var conn = SqlConnectionFactory.Create())
				{
					var parameters = new { id = id };
					int result = conn.Execute(sql, parameters);

					return result;
				}
			}
			catch
			{
				return 0;
			}
		}
	}
}
