namespace Bump.EStore.Infrastructure.Data.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Skillcurriculum
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Skillcurriculum()
        {
            SkillEnrollments = new HashSet<SkillEnrollment>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int FieldId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public byte Week { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        public int SkillCoursesId { get; set; }

        public int CoachId { get; set; }

        public bool Status { get; set; }

        public virtual Coach Coach { get; set; }

        public virtual Field Field { get; set; }

        public virtual SkillCours SkillCours { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SkillEnrollment> SkillEnrollments { get; set; }
    }
}
