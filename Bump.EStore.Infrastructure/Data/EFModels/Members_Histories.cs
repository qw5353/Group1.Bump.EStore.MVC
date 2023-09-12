namespace Bump.EStore.Infrastructure.Data.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Members_Histories
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        [Required]
        [StringLength(50)]
        public string Account { get; set; }

        [Required]
        [StringLength(64)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

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

        public DateTime ModifiedTime { get; set; }

        public virtual Member Member { get; set; }
    }
}
