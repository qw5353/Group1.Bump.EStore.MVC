namespace Bump.EStore.Infrastructure.Data.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MemberTagCondition")]
    public partial class MemberTagCondition
    {
        public int Id { get; set; }

        public int MemberTagId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        public string Operator { get; set; }

        public decimal Value { get; set; }

        [Required]
        [StringLength(50)]
        public string Unit { get; set; }

        public virtual MemberTag MemberTag { get; set; }
    }
}
