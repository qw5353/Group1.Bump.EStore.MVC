using Bump.EStore.Infrastructure.Data.EFModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bump.EStore.MVC.ViewModels.Coupons
{
	public class CouponSendMemberIndexVM
	{
		public int Id { get; set; }

		public int MemberId { get; set; }

		public int CouponId { get; set; }

		public DateTime? SendingTime { get; set; }

		public bool Usage { get; set; }
	}

	public static class CouponSendMemberIndexVMExts
	{
		public static CouponSendMemberIndexVM ToVM(this CouponSendＭembers entity)
		{
			return new CouponSendMemberIndexVM
			{
				Id = entity.Id,
				MemberId = entity.MemberId,
				CouponId = entity.CouponId,
				Usage = entity.Usage,
				SendingTime = entity.SendingTime
			};
		}
	}
}