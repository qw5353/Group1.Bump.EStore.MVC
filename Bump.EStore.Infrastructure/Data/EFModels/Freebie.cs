namespace Bump.EStore.Infrastructure.Data.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Freebie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Freebie()
        {
            ActivityDiscounts = new HashSet<ActivityDiscount>();
            Coupons = new HashSet<Coupon>();
            MemberRewards = new HashSet<MemberReward>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Brand { get; set; }

        public int Price { get; set; }

        [Required]
        [StringLength(500)]
        public string ShortDescription { get; set; }

        [Required]
        [StringLength(2048)]
        public string Thumbnail { get; set; }

        public int Inventory { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActivityDiscount> ActivityDiscounts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Coupon> Coupons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberReward> MemberRewards { get; set; }
    }
}
