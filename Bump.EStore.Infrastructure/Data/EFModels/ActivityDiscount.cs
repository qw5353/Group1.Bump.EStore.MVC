namespace Bump.EStore.Infrastructure.Data.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ActivityDiscount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ActivityDiscount()
        {
            MemberLevels = new HashSet<MemberLevel>();
            MemberTags = new HashSet<MemberTag>();
            ProductTags = new HashSet<ProductTag>();
            ThirdCategories = new HashSet<ThirdCategory>();
        }

        public int Id { get; set; }

        public int AcitivityDetailId { get; set; }

        public int TargetTypeId { get; set; }

        public int PromotionProductTypeId { get; set; }

        public int PriceThreshold { get; set; }

        public int DiscountTypeId { get; set; }

        public int? DiscountQty { get; set; }

        public decimal? Amount { get; set; }

        public int? FreebieId { get; set; }

        public int? GiftCouponId { get; set; }

        public bool ExtraSalesUsage { get; set; }

        public virtual ActivityDetail ActivityDetail { get; set; }

        public virtual Coupon Coupon { get; set; }

        public virtual DiscountType DiscountType { get; set; }

        public virtual Freebie Freebie { get; set; }

        public virtual PromotionProductType PromotionProductType { get; set; }

        public virtual TargetType TargetType { get; set; }

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
