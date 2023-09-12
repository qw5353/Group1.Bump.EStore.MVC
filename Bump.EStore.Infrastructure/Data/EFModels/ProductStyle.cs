namespace Bump.EStore.Infrastructure.Data.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductStyle
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        [Required]
        [StringLength(50)]
        public string Style { get; set; }

        public int Inventory { get; set; }

        public int MinimumStock { get; set; }

        public virtual Product Product { get; set; }
    }
}
