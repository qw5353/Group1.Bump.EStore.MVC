namespace Bump.EStore.Infrastructure.Data.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            MemberPoints = new HashSet<MemberPoint>();
            OrderDetails = new HashSet<OrderDetail>();
            OrderReturnDetails = new HashSet<OrderReturnDetail>();
            OrderUsedCoupons = new HashSet<OrderUsedCoupon>();
            ProductComments = new HashSet<ProductComment>();
        }

        public int Id { get; set; }

        public int MemberId { get; set; }

        [StringLength(2550)]
        public string Snapshot { get; set; }

        [Required]
        [StringLength(100)]
        public string RecipientName { get; set; }

        [Required]
        [StringLength(16)]
        public string RecipientPhone { get; set; }

        [Required]
        [StringLength(200)]
        public string RecipientAddress { get; set; }

        public int OrderStatusId { get; set; }

        public DateTime CreateAt { get; set; }

        [StringLength(300)]
        public string Note { get; set; }

        public int TotalProductsPrice { get; set; }

        public int DeliverPrice { get; set; }

        public int DiscountPrice { get; set; }

        public int UsedPoint { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberPoint> MemberPoints { get; set; }

        public virtual Member Member { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderReturnDetail> OrderReturnDetails { get; set; }

        public virtual OrderStatus OrderStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderUsedCoupon> OrderUsedCoupons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductComment> ProductComments { get; set; }
    }
}
