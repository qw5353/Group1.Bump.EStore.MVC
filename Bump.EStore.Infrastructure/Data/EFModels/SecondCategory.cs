namespace Bump.EStore.Infrastructure.Data.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SecondCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SecondCategory()
        {
            ThirdCategories = new HashSet<ThirdCategory>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Name { get; set; }

        public int FirstCategoryId { get; set; }

        public virtual FirstCategory FirstCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThirdCategory> ThirdCategories { get; set; }
    }
}
