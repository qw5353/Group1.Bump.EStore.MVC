namespace Bump.EStore.Infrastructure.Data.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MemberLevelDetail
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public int MemberLevelId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public virtual MemberLevel MemberLevel { get; set; }

        public virtual Member Member { get; set; }
    }
}
