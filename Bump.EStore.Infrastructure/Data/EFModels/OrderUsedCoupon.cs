namespace Bump.EStore.Infrastructure.Data.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderUsedCoupon
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int CouponId { get; set; }

        public virtual Coupon Coupon { get; set; }

        public virtual Order Order { get; set; }
    }
}
