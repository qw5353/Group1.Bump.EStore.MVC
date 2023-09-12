namespace Bump.EStore.Infrastructure.Data.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Coupon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Coupon()
        {
            ActivityCoupons = new HashSet<ActivityCoupon>();
            ActivityDiscounts = new HashSet<ActivityDiscount>();
            CouponSendＭembers = new HashSet<CouponSendＭembers>();
            OrderUsedCoupons = new HashSet<OrderUsedCoupon>();
            MemberLevels = new HashSet<MemberLevel>();
            MemberTags = new HashSet<MemberTag>();
            ProductTags = new HashSet<ProductTag>();
            ThirdCategories = new HashSet<ThirdCategory>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        public DateTime? PrevTime { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        [StringLength(20)]
        public string RepeatRule { get; set; }

        public byte? RepeatNum { get; set; }

        public int TargetTypeId { get; set; }

        public int PromotionProductTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        public int PriceThreshold { get; set; }

        public int CouponTypeId { get; set; }

        public int? DiscountQty { get; set; }

        public decimal? Amount { get; set; }

        public int? FreebieId { get; set; }

        public int? Quantity { get; set; }

        public bool ExtraSalesUsage { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime LastModified { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActivityCoupon> ActivityCoupons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActivityDiscount> ActivityDiscounts { get; set; }

        public virtual CouponType CouponType { get; set; }

        public virtual Freebie Freebie { get; set; }

        public virtual PromotionProductType PromotionProductType { get; set; }

        public virtual TargetType TargetType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CouponSendＭembers> CouponSendＭembers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderUsedCoupon> OrderUsedCoupons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberLevel> MemberLevels { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberTag> MemberTags { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductTag> ProductTags { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThirdCategory> ThirdCategories { get; set; }
    }
}
