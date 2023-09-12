namespace Bump.EStore.Infrastructure.Data.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MemberLevel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MemberLevel()
        {
            MemberLevelDetails = new HashSet<MemberLevelDetail>();
            MemberLevelDetails_Histories = new HashSet<MemberLevelDetails_Histories>();
            Members = new HashSet<Member>();
            ActivityDiscounts = new HashSet<ActivityDiscount>();
            Coupons = new HashSet<Coupon>();
            MemberRewards = new HashSet<MemberReward>();
        }

        public int Id { get; set; }

        public int LevelOrder { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int UpgradePrice { get; set; }

        public int UpgradeOrderCount { get; set; }

        public int TimePeriod { get; set; }

        public decimal GainPointRate { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberLevelDetail> MemberLevelDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberLevelDetails_Histories> MemberLevelDetails_Histories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Member> Members { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActivityDiscount> ActivityDiscounts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Coupon> Coupons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberReward> MemberRewards { get; set; }
    }
}
