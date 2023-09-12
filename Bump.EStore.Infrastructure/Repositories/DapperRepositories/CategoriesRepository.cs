using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bump.EStore.Infrastructure.Repositories.DapperRepositories
{
	public class CategoriesRepository
	{
		private readonly string _connStr;
		public CategoriesRepository()
		{
			_connStr = System.Configuration.ConfigurationManager.ConnectionStrings["AppDbContext"].ConnectionString;
		}

		public List<CategoriesVM> Search()
		{
			string sql = @"
SELECT f.Name as FirstCategoryName , s.Name as SecondCategoryName , T.Name as ThirdCategoryName
FROM FirstCategories as f
INNER JOIN SecondCategories as s ON s.FirstCategoryId = f.Id
Inner JOIN ThirdCategories as T ON T.SecondCategoryId = S.Id";
			IEnumerable<CategoriesVM> categories = new SqlConnection(_connStr).Query<CategoriesVM>(sql);

			return categories.ToList();
		}

		public List<CategoriesVM> CreateFirstCategories(string firstCategoriyName)
		{
			string sql = @"
INSERT INTO FirstCategories
([Name])
VALUES
(@Name)";

			IEnumerable<CategoriesVM> categories = new SqlConnection(_connStr)
														.Query<CategoriesVM>(sql,new {Name = firstCategoriyName});

			return categories.ToList();
		}

		public List<CategoriesVM> CreateSecondCategories(string secondCategoriyName, int id)
		{
			string sql = @"
INSERT INTO SecondCategories
([Name],FirstCategoryId)
VALUES
(@Name,@Id)";

			IEnumerable<CategoriesVM> categories = new SqlConnection(_connStr)
														.Query<CategoriesVM>(sql, 
														new { Name = secondCategoriyName ,Id = id});

			return categories.ToList();
		}

		public List<CategoriesVM> CreateThirdCategories(string thirdCategoriyName, int id)
		{
			string sql = @"
INSERT INTO ThirdCategories
([Name],SecondCategoryId)
VALUES
(@Name,@Id)";

			IEnumerable<CategoriesVM> categories = new SqlConnection(_connStr)
														.Query<CategoriesVM>(sql,
														new { Name = thirdCategoriyName, Id = id });

			return categories.ToList();
		}

		public List<CategoriesVM> FindFirstCategoryName ()
		{
			string sql = @"
SELECT [Name] as FirstCategoryName ,Id as FirstCategoryId
FROM FirstCategories";

			IEnumerable<CategoriesVM> categories = new SqlConnection(_connStr)
														.Query<CategoriesVM>(sql);

			return categories.ToList();
		}

		public List<CategoriesVM> FindSecondCategoryName()
		{
			string sql = @"
SELECT [Name] as SecondCategoryName ,Id as SecondCategoryId ,FirstCategoryId
FROM SecondCategories";

			IEnumerable<CategoriesVM> categories = new SqlConnection(_connStr)
														.Query<CategoriesVM>(sql);

			return categories.ToList();
		}

		public List<CategoriesVM> FindThirdCategoryName()
		{
			string sql = @"
SELECT [Name] as ThirdCategoryName ,Id as ThirdCategoryId ,SecondCategoryId
FROM ThirdCategories";

			IEnumerable<CategoriesVM> categories = new SqlConnection(_connStr)
														.Query<CategoriesVM>(sql);

			return categories.ToList();
		}

		public List<CategoriesVM> EditFirstCategories(string firstCategoriyName, int id)
		{
			string sql = @"
UPDATE FirstCategories
SET [Name]=@Name 
WHERE Id= @Id;";

			IEnumerable<CategoriesVM> categories = new SqlConnection(_connStr)
														.Query<CategoriesVM>(sql, 
														new { Name = firstCategoriyName, Id = id });

			return categories.ToList();
		}

		public List<CategoriesVM> EditSecondCategories(string secondCategoriyName, int id)
		{
			string sql = @"
UPDATE SecondCategories
SET [Name]=@Name 
WHERE Id= @Id;";

			IEnumerable<CategoriesVM> categories = new SqlConnection(_connStr)
														.Query<CategoriesVM>(sql,
														new { Name = secondCategoriyName, Id = id });

			return categories.ToList();
		}

		public List<CategoriesVM> EditThirdCategories(string thirdCategoriyName, int id)
		{
			string sql = @"
UPDATE ThirdCategories
SET [Name]=@Name 
WHERE Id= @Id;";

			IEnumerable<CategoriesVM> categories = new SqlConnection(_connStr)
														.Query<CategoriesVM>(sql,
														new { Name = thirdCategoriyName, Id = id });

			return categories.ToList();
		}

		public List<CategoriesVM> DeleteFirstCategories(int id)
		{
			string sql = @"
DELETE FROM FirstCategories
WHERE Id= @Id;";

			IEnumerable<CategoriesVM> categories = new SqlConnection(_connStr)
														.Query<CategoriesVM>(sql,
														new { Id = id });

			return categories.ToList();
		}

		public List<CategoriesVM> DeleteSecondCategories(int id)
		{
			string sql = @"
DELETE FROM SecondCategories
WHERE Id= @Id;";

			IEnumerable<CategoriesVM> categories = new SqlConnection(_connStr)
														.Query<CategoriesVM>(sql,
														new { Id = id });

			return categories.ToList();
		}

		public List<CategoriesVM> DeleteThirdCategories(int id)
		{
			string sql = @"
DELETE FROM ThirdCategories
WHERE Id= @Id;";

			IEnumerable<CategoriesVM> categories = new SqlConnection(_connStr)
														.Query<CategoriesVM>(sql,
														new { Id = id });

			return categories.ToList();
		}

	}
	public class CategoriesVM
	{
		[Display(Name = "第一分類")]
		public string FirstCategoryName { get; set; }

		public int FirstCategoryId { get; set; }

		[Display(Name = "第二分類")]
		public string SecondCategoryName { get; set; }

		public int SecondCategoryId { get; set; }

		[Display(Name = "第三分類")]
		public string ThirdCategoryName { get; set; }

		public int ThirdCategoryId { get; set; }
	}

	

}
