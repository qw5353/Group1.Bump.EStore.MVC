namespace Bump.EStore.Infrastructure.Data.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BanDate
    {
        public int Id { get; set; }

        public DateTime BanStartDateTime { get; set; }

        public int FieldId { get; set; }

        public DateTime BanEndDateTime { get; set; }

        public virtual Field Field { get; set; }
    }
}
