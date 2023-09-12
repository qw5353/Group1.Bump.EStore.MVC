using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Bump.EStore.MVC.ViewModels
{
	public class SkillcurriculumCreateVM
	{
		[Display(Name = "編號")]
		[Required]
		public int Id { get; set; }

		[Display(Name = "課表名字")]
		
		public string Name { get; set; }
		[Display(Name = "場館")]
		[Required]
		public int FieldId { get; set; }


		[Display(Name = "課堂開始時間")]
		[Required]
		[DataType(DataType.Time)]
		[DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
		public DateTime StartTime { get; set; }
		


		[Display(Name = "課堂結束時間")]
		[Required]
		[DataType(DataType.Time)]
		[DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
		public DateTime EndTime { get; set; }

		

		[Display(Name = "開課週數")]
		[Required]
		public byte Week { get; set; }
		[Display(Name = "開課開始日期")]
		[Required]
		[Column(TypeName = "date")]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime StartDate { get; set; }
		[Display(Name = "課程類別")]
		[Required]
		public int SkillCoursesId { get; set; }
		[Display(Name = "上課教練")]
		[Required]
		public int CoachId { get; set; }
		[Display(Name = "是否滿人")]
		public bool Status { get; set; }
	}
}