namespace Bump.EStore.Infrastructure.Data.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SkillCourses")]
    public partial class SkillCours
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SkillCours()
        {
            Skillcurriculums = new HashSet<Skillcurriculum>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int Price { get; set; }

        [Required]
        [StringLength(2550)]
        public string Thumbnail { get; set; }

        [Required]
        public string Description { get; set; }

        public int PeopleMin { get; set; }

        public int PeopleMax { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Skillcurriculum> Skillcurriculums { get; set; }
    }
}
