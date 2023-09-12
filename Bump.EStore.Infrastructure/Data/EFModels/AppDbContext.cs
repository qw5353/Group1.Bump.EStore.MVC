using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Bump.EStore.Infrastructure.Data.EFModels
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=AppDbContext")
        {
        }

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<ActivityCoupon> ActivityCoupons { get; set; }
        public virtual DbSet<ActivityDetail> ActivityDetails { get; set; }
        public virtual DbSet<ActivityDiscount> ActivityDiscounts { get; set; }
        public virtual DbSet<BanDate> BanDates { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<CartDetail> CartDetails { get; set; }
        public virtual DbSet<CartHistory> CartHistories { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Coach> Coaches { get; set; }
        public virtual DbSet<ContactU> ContactUs { get; set; }
        public virtual DbSet<Coupon> Coupons { get; set; }
        public virtual DbSet<CouponSendＭembers> CouponSendＭembers { get; set; }
        public virtual DbSet<CouponType> CouponTypes { get; set; }
        public virtual DbSet<Dealer> Dealers { get; set; }
        public virtual DbSet<DiscountType> DiscountTypes { get; set; }
        public virtual DbSet<DM> DMs { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<ExperienceCoursePlan> ExperienceCoursePlans { get; set; }
        public virtual DbSet<ExperienceEnrollment> ExperienceEnrollments { get; set; }
        public virtual DbSet<Field> Fields { get; set; }
        public virtual DbSet<FirstCategory> FirstCategories { get; set; }
        public virtual DbSet<Freebie> Freebies { get; set; }
        public virtual DbSet<MemberLevelDetail> MemberLevelDetails { get; set; }
        public virtual DbSet<MemberLevelDetails_Histories> MemberLevelDetails_Histories { get; set; }
        public virtual DbSet<MemberLevel> MemberLevels { get; set; }
        public virtual DbSet<MemberPoint> MemberPoints { get; set; }
        public virtual DbSet<MemberRewardRecord> MemberRewardRecords { get; set; }
        public virtual DbSet<MemberReward> MemberRewards { get; set; }
        public virtual DbSet<MemberRewardType> MemberRewardTypes { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Members_Histories> Members_Histories { get; set; }
        public virtual DbSet<MemberTagCondition> MemberTagConditions { get; set; }
        public virtual DbSet<MemberTag> MemberTags { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrderReturnDetail> OrderReturnDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
        public virtual DbSet<OrderUsedCoupon> OrderUsedCoupons { get; set; }
        public virtual DbSet<PointStatus> PointStatuses { get; set; }
        public virtual DbSet<ProductComment> ProductComments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductStyle> ProductStyles { get; set; }
        public virtual DbSet<ProductTagCategory> ProductTagCategories { get; set; }
        public virtual DbSet<ProductTag> ProductTags { get; set; }
        public virtual DbSet<PromotionProductType> PromotionProductTypes { get; set; }
        public virtual DbSet<SecondCategory> SecondCategories { get; set; }
        public virtual DbSet<SkillCours> SkillCourses { get; set; }
        public virtual DbSet<Skillcurriculum> Skillcurriculums { get; set; }
        public virtual DbSet<SkillEnrollment> SkillEnrollments { get; set; }
        public virtual DbSet<TargetType> TargetTypes { get; set; }
        public virtual DbSet<ThirdCategory> ThirdCategories { get; set; }
        public virtual DbSet<TrendingQuestion> TrendingQuestions { get; set; }
        public virtual DbSet<TrendingQuestionType> TrendingQuestionTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>()
                .Property(e => e.Thumbnail)
                .IsFixedLength();

            modelBuilder.Entity<Activity>()
                .HasMany(e => e.ActivityDetails)
                .WithRequired(e => e.Activity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ActivityDetail>()
                .HasMany(e => e.ActivityCoupons)
                .WithRequired(e => e.ActivityDetail)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ActivityDetail>()
                .HasMany(e => e.ActivityDiscounts)
                .WithRequired(e => e.ActivityDetail)
                .HasForeignKey(e => e.AcitivityDetailId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ActivityDiscount>()
                .HasMany(e => e.MemberLevels)
                .WithMany(e => e.ActivityDiscounts)
                .Map(m => m.ToTable("MemberLevelOfActivityDiscounts").MapLeftKey("ActivityDiscountId").MapRightKey("MemberLevelId"));

            modelBuilder.Entity<ActivityDiscount>()
                .HasMany(e => e.MemberTags)
                .WithMany(e => e.ActivityDiscounts)
                .Map(m => m.ToTable("MemberTagOfActivityDiscounts").MapLeftKey("ActivityDiscountId").MapRightKey("MemberTagId"));

            modelBuilder.Entity<ActivityDiscount>()
                .HasMany(e => e.ProductTags)
                .WithMany(e => e.ActivityDiscounts)
                .Map(m => m.ToTable("ProductTagOfActivityDiscounts").MapLeftKey("ActivityDiscountId").MapRightKey("ProductTagId"));

            modelBuilder.Entity<ActivityDiscount>()
                .HasMany(e => e.ThirdCategories)
                .WithMany(e => e.ActivityDiscounts)
                .Map(m => m.ToTable("ThirdCategoryOfActivityDiscounts").MapLeftKey("ActivityDiscountId").MapRightKey("ThirdCategoryId"));

            modelBuilder.Entity<Brand>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Brand)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CartDetail>()
                .HasMany(e => e.CartHistories)
                .WithRequired(e => e.CartDetail)
                .HasForeignKey(e => e.CartDetailsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cart>()
                .HasMany(e => e.CartDetails)
                .WithRequired(e => e.Cart)
                .HasForeignKey(e => e.CartsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Coach>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Coach>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Coach>()
                .HasMany(e => e.ExperienceEnrollments)
                .WithRequired(e => e.Coach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Coach>()
                .HasMany(e => e.Skillcurriculums)
                .WithRequired(e => e.Coach)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContactU>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<ContactU>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<ContactU>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Coupon>()
                .HasMany(e => e.ActivityCoupons)
                .WithRequired(e => e.Coupon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Coupon>()
                .HasMany(e => e.ActivityDiscounts)
                .WithOptional(e => e.Coupon)
                .HasForeignKey(e => e.GiftCouponId);

            modelBuilder.Entity<Coupon>()
                .HasMany(e => e.CouponSendＭembers)
                .WithRequired(e => e.Coupon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Coupon>()
                .HasMany(e => e.OrderUsedCoupons)
                .WithRequired(e => e.Coupon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Coupon>()
                .HasMany(e => e.MemberLevels)
                .WithMany(e => e.Coupons)
                .Map(m => m.ToTable("MemberLevelOfCoupons").MapLeftKey("CouponId").MapRightKey("MemberLevelId"));

            modelBuilder.Entity<Coupon>()
                .HasMany(e => e.MemberTags)
                .WithMany(e => e.Coupons)
                .Map(m => m.ToTable("MemberTagOfCoupons").MapLeftKey("CouponId").MapRightKey("MemberTagId"));

            modelBuilder.Entity<Coupon>()
                .HasMany(e => e.ProductTags)
                .WithMany(e => e.Coupons)
                .Map(m => m.ToTable("ProductTagOfCoupons").MapLeftKey("CouponId").MapRightKey("ProductTagId"));

            modelBuilder.Entity<Coupon>()
                .HasMany(e => e.ThirdCategories)
                .WithMany(e => e.Coupons)
                .Map(m => m.ToTable("ThirdCategoryOfCoupons").MapLeftKey("CouponId").MapRightKey("ThirdCategoryId"));

            modelBuilder.Entity<CouponType>()
                .HasMany(e => e.Coupons)
                .WithRequired(e => e.CouponType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CouponType>()
                .HasMany(e => e.MemberRewards)
                .WithRequired(e => e.CouponType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Dealer>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Dealer>()
                .HasMany(e => e.Products)
                .WithMany(e => e.Dealers)
                .Map(m => m.ToTable("ProductsOfDealers").MapLeftKey("DealerId").MapRightKey("ProductId"));

            modelBuilder.Entity<DiscountType>()
                .HasMany(e => e.ActivityDiscounts)
                .WithRequired(e => e.DiscountType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DM>()
                .Property(e => e.DMFile)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Account)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Role)
                .IsUnicode(false);

            modelBuilder.Entity<ExperienceCoursePlan>()
                .HasMany(e => e.ExperienceEnrollments)
                .WithRequired(e => e.ExperienceCoursePlan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Field>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Field>()
                .HasMany(e => e.ExperienceEnrollments)
                .WithRequired(e => e.Field)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Field>()
                .HasMany(e => e.Skillcurriculums)
                .WithRequired(e => e.Field)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FirstCategory>()
                .HasMany(e => e.SecondCategories)
                .WithRequired(e => e.FirstCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Freebie>()
                .Property(e => e.Brand)
                .IsFixedLength();

            modelBuilder.Entity<Freebie>()
                .Property(e => e.Thumbnail)
                .IsUnicode(false);

            modelBuilder.Entity<MemberLevelDetails_Histories>()
                .HasOptional(e => e.MemberLevelDetails_Histories1)
                .WithRequired(e => e.MemberLevelDetails_Histories2);

            modelBuilder.Entity<MemberLevel>()
                .HasMany(e => e.MemberLevelDetails)
                .WithRequired(e => e.MemberLevel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberLevel>()
                .HasMany(e => e.MemberLevelDetails_Histories)
                .WithRequired(e => e.MemberLevel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberLevel>()
                .HasMany(e => e.Members)
                .WithRequired(e => e.MemberLevel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberLevel>()
                .HasMany(e => e.MemberRewards)
                .WithMany(e => e.MemberLevels)
                .Map(m => m.ToTable("MemberLevelOfMemberRewards").MapLeftKey("MemberLevelId").MapRightKey("MemberRewardId"));

            modelBuilder.Entity<MemberReward>()
                .HasMany(e => e.MemberRewardRecords)
                .WithRequired(e => e.MemberReward)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MemberReward>()
                .HasMany(e => e.MemberTags)
                .WithMany(e => e.MemberRewards)
                .Map(m => m.ToTable("MemberTagOfMemberRewards").MapLeftKey("MemberRewardId").MapRightKey("MemberTagId"));

            modelBuilder.Entity<MemberReward>()
                .HasMany(e => e.ProductTags)
                .WithMany(e => e.MemberRewards)
                .Map(m => m.ToTable("ProductTagOfMemberRewards").MapLeftKey("MemberRewardId").MapRightKey("ProductTagId"));

            modelBuilder.Entity<MemberReward>()
                .HasMany(e => e.ThirdCategories)
                .WithMany(e => e.MemberRewards)
                .Map(m => m.ToTable("ThirdCategoryOfMemberRewards").MapLeftKey("MemberRewardId").MapRightKey("ThirdCategoryId"));

            modelBuilder.Entity<MemberRewardType>()
                .HasMany(e => e.MemberRewards)
                .WithRequired(e => e.MemberRewardType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.Account)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Carts)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.CouponSendＭembers)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.ExperienceEnrollments)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.MemberLevelDetails)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.MemberPoints)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.MemberRewardRecords)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Members_Histories)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.SkillEnrollments)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.MemberTags)
                .WithMany(e => e.Members)
                .Map(m => m.ToTable("MembersOfMemberTags").MapLeftKey("MemberId").MapRightKey("MemberTagId"));

            modelBuilder.Entity<Members_Histories>()
                .Property(e => e.Account)
                .IsUnicode(false);

            modelBuilder.Entity<Members_Histories>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Members_Histories>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Members_Histories>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<MemberTagCondition>()
                .Property(e => e.Operator)
                .IsUnicode(false);

            modelBuilder.Entity<MemberTagCondition>()
                .Property(e => e.Value)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Order>()
                .Property(e => e.Snapshot)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.RecipientPhone)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.MemberPoints)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderReturnDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderUsedCoupons)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.ProductComments)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderStatus>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.OrderStatus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PointStatus>()
                .HasMany(e => e.MemberPoints)
                .WithRequired(e => e.PointStatus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductComment>()
                .Property(e => e.Thumbnail)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Thumbnail)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.CartDetails)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.ProductsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductComments)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductStyles)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductTagCategory>()
                .HasMany(e => e.ProductTags)
                .WithRequired(e => e.ProductTagCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductTag>()
                .HasMany(e => e.Products)
                .WithMany(e => e.ProductTags)
                .Map(m => m.ToTable("TagOfProducts").MapLeftKey("ProductTagId").MapRightKey("ProductId"));

            modelBuilder.Entity<PromotionProductType>()
                .HasMany(e => e.ActivityDiscounts)
                .WithRequired(e => e.PromotionProductType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PromotionProductType>()
                .HasMany(e => e.Coupons)
                .WithRequired(e => e.PromotionProductType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SecondCategory>()
                .HasMany(e => e.ThirdCategories)
                .WithRequired(e => e.SecondCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SkillCours>()
                .HasMany(e => e.Skillcurriculums)
                .WithRequired(e => e.SkillCours)
                .HasForeignKey(e => e.SkillCoursesId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Skillcurriculum>()
                .HasMany(e => e.SkillEnrollments)
                .WithRequired(e => e.Skillcurriculum)
                .HasForeignKey(e => e.SkillcurriculumsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TargetType>()
                .HasMany(e => e.ActivityDiscounts)
                .WithRequired(e => e.TargetType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TargetType>()
                .HasMany(e => e.Coupons)
                .WithRequired(e => e.TargetType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TargetType>()
                .HasMany(e => e.MemberRewards)
                .WithRequired(e => e.TargetType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThirdCategory>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.ThirdCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TrendingQuestion>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<TrendingQuestion>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<TrendingQuestionType>()
                .HasMany(e => e.TrendingQuestions)
                .WithRequired(e => e.TrendingQuestionType)
                .HasForeignKey(e => e.QuestionTypeId)
                .WillCascadeOnDelete(false);
        }
    }
}
