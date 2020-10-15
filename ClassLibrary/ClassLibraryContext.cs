//using System.Data.Entity;
using TasksSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace ClassLibrary.Data
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    class ClassLibraryContext : DbContext
    {
        public ClassLibraryContext() : base("conn") { }

        /*public ClassLibraryContext(DbContextOptions<ClassLibraryContext> options)
        : base(options) { }*/

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Project>()
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
        }*/

        public System.Data.Entity.DbSet<Task> Task { get; set; }
        public System.Data.Entity.DbSet<User> User { get; set; }
        public System.Data.Entity.DbSet<Project> Project { get; set; }
        public System.Data.Entity.DbSet<Comment> Comments { get; set; }
    }
}
