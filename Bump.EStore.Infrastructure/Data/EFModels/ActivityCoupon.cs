namespace Bump.EStore.Infrastructure.Data.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ActivityCoupon
    {
        public int Id { get; set; }

        public int ActivityDetailId { get; set; }

        public int CouponId { get; set; }

        public virtual ActivityDetail ActivityDetail { get; set; }

        public virtual Coupon Coupon { get; set; }
    }
}
