namespace Bump.EStore.Infrastructure.Data.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Member()
        {
            Carts = new HashSet<Cart>();
            CouponSendＭembers = new HashSet<CouponSendＭembers>();
            ExperienceEnrollments = new HashSet<ExperienceEnrollment>();
            MemberLevelDetails = new HashSet<MemberLevelDetail>();
            MemberPoints = new HashSet<MemberPoint>();
            MemberRewardRecords = new HashSet<MemberRewardRecord>();
            Members_Histories = new HashSet<Members_Histories>();
            Orders = new HashSet<Order>();
            SkillEnrollments = new HashSet<SkillEnrollment>();
            MemberTags = new HashSet<MemberTag>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Account { get; set; }

        [Required]
        [StringLength(64)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Nickname { get; set; }

        public int MemberLevelId { get; set; }

        public int Points { get; set; }

        [StringLength(2550)]
        public string Thumbnail { get; set; }

        [Required]
        [StringLength(320)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Gender { get; set; }

        public DateTime Birthday { get; set; }

        [Required]
        [StringLength(25)]
        public string PhoneNumber { get; set; }

        public bool DMSubscribe { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime LastModified { get; set; }

        public bool IsConfirm { get; set; }

        public bool IsBanned { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Carts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CouponSendＭembers> CouponSendＭembers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExperienceEnrollment> ExperienceEnrollments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberLevelDetail> MemberLevelDetails { get; set; }

        public virtual MemberLevel MemberLevel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberPoint> MemberPoints { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberRewardRecord> MemberRewardRecords { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Members_Histories> Members_Histories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SkillEnrollment> SkillEnrollments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberTag> MemberTags { get; set; }
    }
}
