using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Bump.EStore.MVC.ViewModels.Freebies
{
	public class FreebieEditImgVM
	{
		[Display(Name = "編號")]
		public int? Id { get; set; }


		[Display(Name = "贈品圖片")]
		public string Thumbnail { get; set; }
	}

	public static class FreebieEditImgVMExts
	{
		public static FreebieEditImgVM ToImgVM(this Freebie entity)
		{
			return new FreebieEditImgVM
			{
				Id = entity.Id,
				Thumbnail = entity.Thumbnail
			};
		}
	}
}