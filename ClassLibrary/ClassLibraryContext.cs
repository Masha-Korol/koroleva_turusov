//using System.Data.Entity;
using TasksSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Data
{
 
    public class ClassLibraryContext : DbContext
    {
        public ClassLibraryContext() : base() { }

        public ClassLibraryContext(DbContextOptions<ClassLibraryContext> dbContextOptions): base(dbContextOptions)
        {

        }

        /*public ClassLibraryContext(DbContextOptions<ClassLibraryContext> options)
        : base(options) { }*/

        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDb>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<ProjectDb>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<ProjectUsers>()
                .HasKey(x => new { x.ProjectId, x.UserId });
            modelBuilder.Entity<ProjectUsers>()
                .HasOne(x => x.User)
                .WithMany(m => m.Projects)
                .HasForeignKey(x => x.UserId);
            modelBuilder.Entity<ProjectUsers>()
                .HasOne(x => x.Project)
                .WithMany(m => m.Users)
                .HasForeignKey(x => x.ProjectId);
        }

        public DbSet<TaskDb> Task { get; set; }
        public DbSet<UserDb> User { get; set; }
        public DbSet<ProjectDb> Project { get; set; }
        public DbSet<CommentDb> Comments { get; set; }
    }
}
