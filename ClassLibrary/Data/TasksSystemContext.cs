using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Text;
using System.Linq;
using TasksSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Data
{
    class TasksSystemContext : DbContext
    {
        public TasksSystemContext(DbContextOptions<TasksSystemContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
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
        }

        public DbSet<Task> Task { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
