namespace propertyfinder.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PropertyFinder : DbContext
    {
        public PropertyFinder()
            : base("name=PropertyFinder")
        {
        }

        public virtual DbSet<tComment> tComments { get; set; }
        public virtual DbSet<tNotification> tNotifications { get; set; }
        public virtual DbSet<tPersonInfo> tPersonInfoes { get; set; }
        public virtual DbSet<tPost> tPosts { get; set; }
        public virtual DbSet<tPostImage> tPostImages { get; set; }
        public virtual DbSet<tPropertyType> tPropertyTypes { get; set; }
        public virtual DbSet<tServiceEntity> tServiceEntities { get; set; }
        public virtual DbSet<tUser> tUsers { get; set; }
        public virtual DbSet<tUserValidationId> tUserValidationIds { get; set; }
        public virtual DbSet<vUserAcctStatu> vUserAcctStatus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tComment>()
                .Property(e => e.PostId)
                .IsUnicode(false);

            modelBuilder.Entity<tComment>()
                .Property(e => e.CommentId)
                .IsUnicode(false);

            modelBuilder.Entity<tComment>()
                .Property(e => e.PersonId)
                .IsUnicode(false);

            modelBuilder.Entity<tNotification>()
                .Property(e => e.notificationId)
                .IsUnicode(false);

            modelBuilder.Entity<tNotification>()
                .Property(e => e.SenderId)
                .IsUnicode(false);

            modelBuilder.Entity<tNotification>()
                .Property(e => e.RecipientId)
                .IsUnicode(false);

            modelBuilder.Entity<tNotification>()
                .Property(e => e.Message)
                .IsUnicode(false);

            modelBuilder.Entity<tPersonInfo>()
                .Property(e => e.PersonId)
                .IsUnicode(false);

            modelBuilder.Entity<tPersonInfo>()
                .Property(e => e.UserId)
                .IsUnicode(false);

            modelBuilder.Entity<tPersonInfo>()
                .Property(e => e.Firstname)
                .IsUnicode(false);

            modelBuilder.Entity<tPersonInfo>()
                .Property(e => e.Middlename)
                .IsUnicode(false);

            modelBuilder.Entity<tPersonInfo>()
                .Property(e => e.Lastname)
                .IsUnicode(false);

            modelBuilder.Entity<tPersonInfo>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<tPersonInfo>()
                .Property(e => e.ContactNo)
                .IsUnicode(false);

            modelBuilder.Entity<tPost>()
                .Property(e => e.PostId)
                .IsUnicode(false);

            modelBuilder.Entity<tPost>()
                .Property(e => e.PropertyTypeId)
                .IsUnicode(false);

            modelBuilder.Entity<tPost>()
                .Property(e => e.PersonId)
                .IsUnicode(false);

            modelBuilder.Entity<tPost>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<tPost>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<tPost>()
                .Property(e => e.ImgId)
                .IsUnicode(false);

            modelBuilder.Entity<tPostImage>()
                .Property(e => e.ImgId)
                .IsUnicode(false);

            modelBuilder.Entity<tPostImage>()
                .Property(e => e.PostId)
                .IsUnicode(false);

            modelBuilder.Entity<tPostImage>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tPostImage>()
                .Property(e => e.UpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tPropertyType>()
                .Property(e => e.PropertyTypeId)
                .IsUnicode(false);

            modelBuilder.Entity<tPropertyType>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<tPropertyType>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tPropertyType>()
                .Property(e => e.UpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tPropertyType>()
                .Property(e => e.Status)
                .IsFixedLength();

            modelBuilder.Entity<tServiceEntity>()
                .Property(e => e.ServiceEntityId)
                .IsUnicode(false);

            modelBuilder.Entity<tServiceEntity>()
                .Property(e => e.PropertyTypeId)
                .IsUnicode(false);

            modelBuilder.Entity<tServiceEntity>()
                .Property(e => e.ServiceEntityName)
                .IsUnicode(false);

            modelBuilder.Entity<tServiceEntity>()
                .Property(e => e.ServiceEntityAddress)
                .IsUnicode(false);

            modelBuilder.Entity<tUser>()
                .Property(e => e.UserId)
                .IsUnicode(false);

            modelBuilder.Entity<tUser>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<tUser>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<tUserValidationId>()
                .Property(e => e.ValidationId)
                .IsUnicode(false);

            modelBuilder.Entity<tUserValidationId>()
                .Property(e => e.PersonId)
                .IsUnicode(false);

            modelBuilder.Entity<tUserValidationId>()
                .Property(e => e.ImageDescription)
                .IsUnicode(false);

            modelBuilder.Entity<tUserValidationId>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<tUserValidationId>()
                .Property(e => e.UpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<vUserAcctStatu>()
                .Property(e => e.UserId)
                .IsUnicode(false);

            modelBuilder.Entity<vUserAcctStatu>()
                .Property(e => e.PersonId)
                .IsUnicode(false);

            modelBuilder.Entity<vUserAcctStatu>()
                .Property(e => e.Lastname)
                .IsUnicode(false);

            modelBuilder.Entity<vUserAcctStatu>()
                .Property(e => e.Firstname)
                .IsUnicode(false);

            modelBuilder.Entity<vUserAcctStatu>()
                .Property(e => e.Middlename)
                .IsUnicode(false);

            modelBuilder.Entity<vUserAcctStatu>()
                .Property(e => e.Address)
                .IsUnicode(false);
        }
    }
}
