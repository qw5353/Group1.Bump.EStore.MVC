using Bump.EStore.Infrastructure.Criteria;
using Bump.EStore.Infrastructure.Data.EFModels;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Bump.EStore.Infrastructure.Repositories.DapperRepositories
{
    public class MemberTagDapperRepository
    {
        private readonly string _connStr;
        public MemberTagDapperRepository()
        {
            _connStr = System.Configuration.ConfigurationManager.ConnectionStrings["AppDbContext"].ConnectionString;
        }

        public List<MemberTagEntity> TotalSearch()
        {

            string sql = $@"
select mt.Id, mt.[Name] as TagName,mt.[Description],mc.[Name] as ConditionName, mc.Operator, mc.[value],
mc.[unit] 
from MemberTags mt
left join [MemberTagCondition] mc on mt.Id = mc.MemberTagId
";

            using (var connection = new SqlConnection(_connStr))
            {
                IEnumerable<MemberTagEntity> tags = connection.Query<MemberTagEntity>(sql);

                return tags
                    .GroupBy(m => m.Id)
                    .Select(g =>
                    {
                        var tag = g.First();
                        tag.ConditionName = string.Join("\n", g.Select(m => m.ConditionName));
                        tag.Operator = string.Join("\n", g.Select(m => m.Operator));
                        //tag.Value = int.Parse(string.Join("|", g.Select(m => m.Value)));
                        tag.Unit = string.Join("\n", g.Select(m => m.Unit));
                        return tag;
                    })
                    .ToList();
            }
        }

        public List<MemberTagEntity> CreateMemberTags(IEnumerable<MemberTagEntity> entities)
        {
            string sql = @"
Insert into MemberTags 
([Name],[Description])
values
(@Name, @Description)";

			using (SqlConnection connection = new SqlConnection(_connStr))
			{
				connection.Open();

				foreach (MemberTagEntity entity in entities)
				{
					connection.Execute(sql, new { Name =  entity.TagName, Description =  entity.Description });
				}

				// 如果需要，可以從資料庫中重新查詢已插入的資料
				List<MemberTagEntity> insertedEntities = connection.Query<MemberTagEntity>("SELECT * FROM MemberTags").ToList();

				return insertedEntities;
			}
		}

        public int CreatedMemberTagId()
        {
            string selectSql = @"
       SELECT top 1(id) FROM MemberTags
        order by Id desc;
    ";

            using (var connection = new SqlConnection(_connStr))
            {
                connection.Open();

                decimal createdTagId = connection.QuerySingleOrDefault<decimal>(selectSql);

                return (int)createdTagId;
            }
        }

        public List<MemberTagEntity> CreateMemberTagsCondition(IEnumerable<MemberTagEntity> entities,int id)
        {
            //DECLARE @MemberTagId INT;
            //SET @MemberTagId = SCOPE_IDENTITY();
            string sql = @"
-- 在相同的 MemberTagId 下插入到 MemberTagCondition 表
INSERT INTO MemberTagCondition ([MemberTagId], [Name], [Operator], [Value], [Unit])
VALUES (@MemberTagId, @Name, @Operator, @Value, @Unit);
";


			using (SqlConnection connection = new SqlConnection(_connStr))
			{
				connection.Open();

				foreach (MemberTagEntity entity in entities)
				{
					connection.Execute(sql, new
                    {  
                        MemberTagId = id, 
                        Name = entity.ConditionName,
                        Operator = entity.Operator,
                        Value = entity.Value,
                        Unit = entity.Unit
                    });
                }

				// 如果需要，可以從資料庫中重新查詢已插入的資料
				List <MemberTagEntity> insertedEntities = connection.Query<MemberTagEntity>("SELECT * FROM MemberTagCondition").ToList();

				return insertedEntities;
			}

        }

        public List<MemberTagEntity> EditMemberTag(MemberTagEntity entity, int id)
        {
            string sql = @"
UPDATE MemberTags
SET [Name]=@Name,
    [Description] = @Description
WHERE Id= @Id;";

            IEnumerable<MemberTagEntity> categories = new SqlConnection(_connStr)
                                                        .Query<MemberTagEntity>(sql,
                                                        new { Name = entity.TagName, Id = id });

            return categories.ToList();
        }

        public List<MemberTagEntity> EditMemberTagCondition(MemberTagEntity entity)
        {
            string sql = @"
UPDATE MemberTagCondition
SET [Name]=@Name,
    [Operator]=@Operator,
    [Value]=@Value,
    [Unit]=@Unit
WHERE MemberTagId= @Id;";

            IEnumerable<MemberTagEntity> categories = new SqlConnection(_connStr)
                                                        .Query<MemberTagEntity>(sql,
                                                        new 
                                                        {
                                                            Id = entity.MemberTagId,
                                                            Name = entity.ConditionName,
                                                            Operator = entity.Operator,
                                                            Value = entity.Value,
                                                            Unit = entity.Unit
                                                        });

            return categories.ToList();
        }

        public List<MemberTagEntity> DeleteMemberTag(int id)
        {
            string sql = @"
DELETE FROM MemberTags
WHERE Id= @Id;";

            IEnumerable<MemberTagEntity> membertag = new SqlConnection(_connStr)
                                                        .Query<MemberTagEntity>(sql,
                                                        new { Id = id });

            return membertag.ToList();
        }
    }
    public class MemberTagEntity
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public string Description { get; set; }
        public int MemberTagId { get; set; }
        public string ConditionName { get; set; }
        public string Operator { get; set; }
        public int Value { get; set; }
        public string Unit { get; set; }
        
    }

}
