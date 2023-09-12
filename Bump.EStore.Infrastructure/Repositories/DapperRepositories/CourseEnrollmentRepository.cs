using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Infrastructure.Repositories.DapperRepositories
{
    public class CourseEnrollmentRepository
    {
        public IEnumerable<SkillEnrollmentVM> GetAllSkills(int fieldId)
        {
            using (var conn = SqlConnectionFactory.Create())
            {
                string sql = @"
 SELECT se.[Id] AS EnrollmentId
      ,[MemberId]
      ,se.[CreatedAt]
      ,[NumberOfPeople]
	  ,skccs.[Name] as CourseName
	  ,CAST(StartTime as time(0)) AS StartTime
	  ,CAST(EndTime as time(0)) AS EndTime
	  ,skccs.[Week] AS Weeks
	  ,c.[Name] AS CoachName
	  ,f.[Name] AS FieldName
	  ,StartDate
	  ,Price * NumberOfPeople AS TotalPrice
	  ,m.[Name] AS MemberName
      ,m.[Account]
      ,f.[Id] AS FieldId
  FROM [Bump].[dbo].[SkillEnrollments] se
  INNER JOIN Skillcurriculums skccs
  ON SkillcurriculumsId = skccs.Id
  INNER JOIN SkillCourses sc
  ON skccs.SkillCoursesId = sc.Id
  INNER JOIN Coaches c
  ON c.Id = skccs.CoachId
  INNER JOIN Fields f
  ON f.Id = skccs.FieldId
  INNER JOIN Members m
  ON se.MemberId = m.Id
  WHERE f.[Id] = @FieldId";

                return conn.Query<SkillEnrollmentEntity>(sql, new { @FieldId = fieldId}).Select(e => e.ToVMs()).SelectMany(e => e).ToList();
            }
        }

        public IEnumerable<ExperienceEnrollmentVM> GetAllExperience(int fieldId)
        {
            string sql = @"
SELECT ee.[Id]
      ,m.[Name] AS MemberName
	  ,Account
      ,[PaymentId]
      ,ee.[CreatedAt]
      ,[NumberOfPeople]
      ,f.[Name] AS FieldName
      ,c.[Name] AS CoachName
      ,[StartTime]
      ,[EndTime]
	  ,ecp.[Name] AS PlanName
	  ,ecp.Price * NumberOfPeople AS TotalPrice
      ,f.[Id] AS FieldId
  FROM [Bump].[dbo].[ExperienceEnrollments] ee
  INNER JOIN ExperienceCoursePlans ecp
  ON ecp.Id = ee.ExperienceCoursePlanId
  INNER JOIN Coaches c
  ON ee.CoachId = c.Id
  INNER JOIN Fields f
  ON ee.FieldId = f.Id
  INNER JOIN Members m
  ON m.Id = ee.MemberId
  WHERE f.Id = @FieldId;";

            using (var conn = SqlConnectionFactory.Create())
            {
                return conn.Query<ExperienceEnrollmentVM>(sql, new {@FieldId = fieldId}).ToList();
            }
        }

        public IEnumerable<EnrollmentFieldVM> GetFields()
        {
            string sql = @"SELECT [Id],[Name] FROM Fields;";

            using (var conn = SqlConnectionFactory.Create())
            {
                return conn.Query<EnrollmentFieldVM>(sql);
            }
        }
    }

    public class EnrollmentFieldVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ExperienceEnrollmentVM
    {
        public int Id { get; set; }
        public string MemberName { get; set; }
        public string Account { get; set; }
        public int NumberOfPeople { get; set; }
        public int FieldId { get; set; }
        public string FieldName { get; set; }
        public string CoachName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string PlanName { get; set; }
        public int TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class SkillEnrollmentEntity
    {
        public int EnrollmentId { get; set; }
        public int MemberId { get; set; }
        public int FieldId { get; set; }
        public string FieldName { get; set; }
        public string CourseName { get; set; }
        public string CoachName { get; set; }
        public string MemberName { get; set; }
        public int NumberOfPeople { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int Weeks { get; set; }
        public int TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Account { get; set; }
    }

    public class SkillEnrollmentVM
    {
        public int EnrollmentId { get; set; }
        public int MemberId { get; set; }
        public int FieldId { get; set; }
        public string FieldName { get; set; }
        public string CourseName { get; set; }
        public string CoachName { get; set; }
        public string MemberName { get; set; }
        public int NumberOfPeople { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Account { get; set; }
    }

    public static class SkillEnrollmentVMExts
    {
        public static IEnumerable<SkillEnrollmentVM> ToVMs(this SkillEnrollmentEntity entity)
        {
            return Enumerable.Range(0, entity.Weeks).Select(weeks =>
            {
                return new SkillEnrollmentVM
                {
                    EnrollmentId = entity.EnrollmentId,
                    MemberId = entity.MemberId,
                    FieldName = entity.FieldName,
                    FieldId = entity.FieldId,
                    CourseName = entity.CourseName,
                    CoachName = entity.CoachName,
                    MemberName = entity.MemberName,
                    NumberOfPeople = entity.NumberOfPeople,
                    StartTime = entity.StartDate.Add(entity.StartTime).AddDays(7 * weeks),
                    EndTime = entity.StartDate.Add(entity.EndTime).AddDays(7 * weeks),
                    TotalPrice = entity.TotalPrice,
                    CreatedAt = entity.CreatedAt,
                    Account = entity.Account,
                };
            });
        }
    }
}
