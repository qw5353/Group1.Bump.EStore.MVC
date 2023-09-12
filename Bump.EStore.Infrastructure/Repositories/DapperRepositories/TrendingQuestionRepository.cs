using Bump.EStore.Infrastructure.Criteria;
using Bump.EStore.Infrastructure.Data.EFModels;
using Bump.EStore.Infrastructure.Repositories.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Infrastructure.Repositories.DapperRepositories
{
	public class TrendingQuestionRepository : ITrendingQuestionRepository
	{
		public int Count(TrendingQuestionCriteria criteria)
		{
			#region Prepare Where
			var parameters = new DynamicParameters();

			var whereConditions = new List<string>();
			var whereStatement = string.Empty;

			if (!string.IsNullOrEmpty(criteria.Title))
			{
				whereConditions.Add($" [Title] LIKE @Title");
				parameters.Add("Title", $"%{criteria.Title}%");
			}

			if (criteria.TypeId.HasValue)
			{
				whereConditions.Add($" [QuestionTypeId] LIKE @TypeId");
				parameters.Add("TypeId", criteria.TypeId);
			}

			if (whereConditions.Any())
			{
				whereStatement = $"\nWHERE {string.Join("\nAND", whereConditions)}\n";
			}
			#endregion


			using (var conn = SqlConnectionFactory.Create())
			{
				string sql = $@"SELECT COUNT(*) FROM TrendingQuestions{whereStatement};";
				int count = conn.ExecuteScalar<int>(sql, parameters);
				return count;
			}
		}

		public int Delete(int id)
		{
			using (var conn = SqlConnectionFactory.Create())
			{
				string sql = @"DELETE FROM TrendingQuestions WHERE Id = @Id;";
				int affectedRows = conn.Execute(sql, new { Id = id });
				return affectedRows;
			}
		}

		public IEnumerable<TrendingQuestion> Search(int pageNumber, int rowsPerPage, TrendingQuestionCriteria criteria)
		{
			#region Prepare Where
			var parameters = new DynamicParameters(new
			{
				OffsetRows = (pageNumber - 1) * rowsPerPage,
				FetchRows = rowsPerPage
			});

			var whereConditions = new List<string>();
			var whereStatement = string.Empty;

			if (!string.IsNullOrEmpty(criteria.Title))
			{
				whereConditions.Add($" [Title] LIKE @Title");
				parameters.Add("Title", $"%{criteria.Title}%"); 
			}

			if (criteria.TypeId.HasValue)
			{
				whereConditions.Add($" [QuestionTypeId] LIKE @TypeId");
				parameters.Add("TypeId", criteria.TypeId);
			}

			if (whereConditions.Any())
			{
				whereStatement = $"\nWHERE {string.Join("\nAND", whereConditions)}\n";
			}
			#endregion

			#region SQL Statement
			string sql = $@"
SELECT
	t.[Id], t.[QuestionTypeId], t.[Title], t.[Description], ts.[Name], ts.[Id]
FROM
	TrendingQuestions t
INNER JOIN
	TrendingQuestionTypes ts ON t.QuestionTypeId = ts.Id{whereStatement}
ORDER BY t.[Id]
OFFSET @OffsetRows ROWS
FETCH NEXT @FetchRows ROWS ONLY;";
			#endregion

			using (var conn = SqlConnectionFactory.Create())
			{

				return conn.Query<TrendingQuestion, TrendingQuestionType, TrendingQuestion>(sql, (question, questionType) =>
				{
					question.TrendingQuestionType = questionType;
					return question;
				},
					splitOn: "Name",
					param: parameters
				);
			}
		}

		public IEnumerable<TrendingQuestionType> GetQuestionTypes()
		{
			string sql = @"SELECT [Id],[Name] FROM [dbo].[TrendingQuestionTypes]";

			using (var conn = SqlConnectionFactory.Create())
			{
				return conn.Query<TrendingQuestionType>(sql);
			}
		}

		public int Create(TrendingQuestion entity)
		{
			string sql = @"
INSERT INTO [dbo].[TrendingQuestions]
    ([QuestionTypeId]
    ,[Title]
    ,[Description])
VALUES
    (@QuestionTypeId, @Title, @Description)";


			using (var conn = SqlConnectionFactory.Create())
			{
				return conn.Execute(sql, entity);
			}
		}

		public TrendingQuestion GetById(int id)
		{
			string sql = @"
SELECT [Id], [QuestionTypeId], [Title], [Description]
FROM [Bump].[dbo].[TrendingQuestions]
WHERE Id = @Id;";

			using (var conn = SqlConnectionFactory.Create())
			{
				return conn.QueryFirstOrDefault<TrendingQuestion>(sql, new { Id = id });
			}
		}

		public int Update(TrendingQuestion trendingQuestion)
		{
			string sql = @"
UPDATE [dbo].[TrendingQuestions]
SET [QuestionTypeId] = @QuestionTypeId
    ,[Title] = @Title
    ,[Description] = @Description
WHERE [Id] = @Id;";

			using (var conn = SqlConnectionFactory.Create())
			{
				return conn.Execute(sql, trendingQuestion);
			}
		}
	}
}
