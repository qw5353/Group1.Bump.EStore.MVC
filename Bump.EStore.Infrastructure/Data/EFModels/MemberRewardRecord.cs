namespace Bump.EStore.Infrastructure.Data.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MemberRewardRecord
    {
        public int Id { get; set; }

        public int MemberRewardId { get; set; }

        public int MemberId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime? SendingTime { get; set; }

        public bool Usage { get; set; }

        public virtual MemberReward MemberReward { get; set; }

        public virtual Member Member { get; set; }
    }
}
