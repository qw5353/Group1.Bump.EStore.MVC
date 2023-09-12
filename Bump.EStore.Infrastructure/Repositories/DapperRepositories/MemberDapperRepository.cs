using Bump.EStore.Infrastructure.Criteria;
using Bump.EStore.Infrastructure.Data.EFModels;
using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bump.EStore.Infrastructure.Repositories.DapperRepositories
{
	public class MemberDapperRepository
	{
		private readonly string _connStr;
		public MemberDapperRepository()
		{
			_connStr = System.Configuration.ConfigurationManager.ConnectionStrings["AppDbContext"].ConnectionString;
		}

		public List<MemberIndexEntity> TotalSearch(MemberCriteria criteria)
		{

			#region where

			var whereConditions = new List<string>();
			var whereStatement = string.Empty;

			if (criteria.MemberLevel.HasValue)
			{
				whereConditions.Add($" ml.Id = {criteria.MemberLevel}");
			}

			if (criteria.MemberTag.HasValue)
			{
				whereConditions.Add($" mt.Id = {criteria.MemberTag}");
			}
			if (whereConditions.Any())
			{
				whereStatement = $"\nWHERE {string.Join("\nAND", whereConditions)}\n";
			}

			#endregion


			string sql = $@"
select m.Account,m.[Name] as MemberName,m.Nickname,m.Email,m.Birthday,
ml.[Name] as MemberLevel,mt.[Name], m.[Thumbnail], m.Gender, m.PhoneNumber,
m.DMSubscribe, m.LastModified, mt.Name AS MemberTag, m.IsConfirm, m.Points,
m.Id
from Members m 
left join MemberLevels ml on m.MemberLevelId = ml.Id
left join MembersOfMemberTags mo on m.Id = mo.MemberId
left join MemberTags mt on mo.MemberTagId = mt.Id {whereStatement};
";

			using (var connection = new SqlConnection(_connStr))
			{
				IEnumerable<MemberIndexEntity> members = connection.Query<MemberIndexEntity>(sql);

				return members
					.GroupBy(m => m.Id)
					.Select(g =>
					{
						var member = g.First();
						member.MemberTag = string.Join("|", g.Select(m => m.MemberTag));
						return member;
					})
					.ToList();
			}
		}
	}

	
}

public class MemberIndexEntity
	{
		public int Id { get; set; }
		public string Account { get; set; }

		public string MemberName { get; set; }
		public string Nickname { get; set; }
		public int Points { get; set; }

		public string MemberLevel { get; set; }
		public string Thumbnail { get; set; }

		public string Email { get; set; }

		public string Gender { get; set; }

		public DateTime Birthday { get; set; }

		public string PhoneNumber { get; set; }

		public bool DMSubscribe { get; set; }

		public DateTime LastModified { get; set; }
		public string MemberTag { get; set; }

		public bool IsConfirm { get; set; }
	}

