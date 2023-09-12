namespace Bump.EStore.Infrastructure.Data.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SkillEnrollment
    {
        public int Id { get; set; }

        public int SkillcurriculumsId { get; set; }

        public int MemberId { get; set; }

        public int PaymentId { get; set; }

        public DateTime CreatedAt { get; set; }

        public int NumberOfPeople { get; set; }

        public virtual Member Member { get; set; }

        public virtual Skillcurriculum Skillcurriculum { get; set; }
    }
}
