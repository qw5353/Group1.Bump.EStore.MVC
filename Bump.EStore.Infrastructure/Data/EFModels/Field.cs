namespace Bump.EStore.Infrastructure.Data.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Field
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Field()
        {
            BanDates = new HashSet<BanDate>();
            ExperienceEnrollments = new HashSet<ExperienceEnrollment>();
            Skillcurriculums = new HashSet<Skillcurriculum>();
        }

        public int Id { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(200)]
        public string BusinessHours { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        public bool Indoor { get; set; }

        [Required]
        [StringLength(300)]
        public string Thumbnail { get; set; }

        [Required]
        [StringLength(500)]
        public string ShortDescription { get; set; }

        [StringLength(2048)]
        public string Link { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public DateTime? BusinessWeekdayStartTime { get; set; }

        public DateTime? BusinessWeekdayEndTime { get; set; }

        public DateTime? BusinessWeekendStartTime { get; set; }

        public DateTime? BusinessWeekendEndTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BanDate> BanDates { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExperienceEnrollment> ExperienceEnrollments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Skillcurriculum> Skillcurriculums { get; set; }
    }
}
