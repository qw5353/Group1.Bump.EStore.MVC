namespace Bump.EStore.Infrastructure.Data.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DM
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string MailContent { get; set; }

        [Required]
        [StringLength(200)]
        public string DMFile { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? SendingTime { get; set; }
    }
}
