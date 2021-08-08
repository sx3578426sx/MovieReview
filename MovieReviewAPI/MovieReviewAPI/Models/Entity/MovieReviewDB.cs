namespace MovieReviewAPI.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MovieReviewDB : DbContext
    {
        public MovieReviewDB()
            : base("name=MovieReviewDB")
        {
        }

        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<MovieComments> MovieComments { get; set; }
        public virtual DbSet<MovieImageFile> MovieImageFile { get; set; }
        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Members>()
                .HasMany(e => e.Roles)
                .WithMany(e => e.Members)
                .Map(m => m.ToTable("RoleMembers").MapLeftKey("Account").MapRightKey("RoleId"));

            modelBuilder.Entity<Movies>()
                .HasMany(e => e.MovieComments)
                .WithRequired(e => e.Movies)
                .HasForeignKey(e => e.MovieId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Movies>()
                .HasOptional(e => e.MovieImageFile)
                .WithRequired(e => e.Movies);
        }
    }
}
