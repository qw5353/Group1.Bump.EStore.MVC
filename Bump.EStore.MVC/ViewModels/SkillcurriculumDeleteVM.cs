using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Bump.EStore.MVC.ViewModels
{
	public class SkillcurriculumDeleteVM
	{
		[Display(Name = "編號")]
		public int Id { get; set; }

		[Display(Name = "課表名字")]
		public string Name { get; set; }
		[Display(Name = "場館")]
		public string Field { get; set; }
		[Display(Name = "課堂開始時間")]
		[DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
		public DateTime StartTime { get; set; }
		[Display(Name = "課堂結束時間")]
		[DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]

		public DateTime EndTime { get; set; }
		[Display(Name = "開課週數")]
		public byte Week { get; set; }
		[Display(Name = "開課開始日期")]
		[Column(TypeName = "date")]
		[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]

		public DateTime StartDate { get; set; }
		
		[Display(Name = "上課教練")]
		public string Coach { get; set; }

	}
}