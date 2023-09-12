namespace Bump.EStore.Infrastructure.Data.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductComment
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        [Required]
        [StringLength(50)]
        public string Thumbnail { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        public byte Rating { get; set; }

        public bool Blocked { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreateAt { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
