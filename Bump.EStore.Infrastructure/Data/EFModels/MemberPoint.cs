namespace Bump.EStore.Infrastructure.Data.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MemberPoint
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public int OrderId { get; set; }

        public int PointStatusId { get; set; }

        public int GainPoints { get; set; }

        public virtual Member Member { get; set; }

        public virtual Order Order { get; set; }

        public virtual PointStatus PointStatus { get; set; }
    }
}
