namespace Bump.EStore.Infrastructure.Data.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderReturnDetail
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public int UnitPrice { get; set; }

        public int Subtotal { get; set; }

        public bool RefundStatus { get; set; }

        [Required]
        [StringLength(300)]
        public string ProductName { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual Order Order { get; set; }
    }
}
