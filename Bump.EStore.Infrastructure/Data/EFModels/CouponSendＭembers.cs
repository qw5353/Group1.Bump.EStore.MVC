namespace Bump.EStore.Infrastructure.Data.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CouponSendＭembers
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public int CouponId { get; set; }

        public DateTime? SendingTime { get; set; }

        public bool Usage { get; set; }

        public virtual Coupon Coupon { get; set; }

        public virtual Member Member { get; set; }
    }
}
