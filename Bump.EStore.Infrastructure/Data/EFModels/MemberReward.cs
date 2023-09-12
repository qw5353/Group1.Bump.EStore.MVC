namespace Bump.EStore.Infrastructure.Data.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MemberReward
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MemberReward()
        {
            MemberRewardRecords = new HashSet<MemberRewardRecord>();
            MemberLevels = new HashSet<MemberLevel>();
            MemberTags = new HashSet<MemberTag>();
            ProductTags = new HashSet<ProductTag>();
            ThirdCategories = new HashSet<ThirdCategory>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public int MemberRewardTypeId { get; set; }

        public int TargetTypeId { get; set; }

        public int? PromotionProductTypeId { get; set; }

        public int PriceThreshold { get; set; }

        public int CouponTypeId { get; set; }

        public int? Amount { get; set; }

        public int? FreebieId { get; set; }

        public bool ExtraSalesUsage { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual CouponType CouponType { get; set; }

        public virtual Freebie Freebie { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberRewardRecord> MemberRewardRecords { get; set; }

        public virtual MemberRewardType MemberRewardType { get; set; }

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
