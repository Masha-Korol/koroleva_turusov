using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TasksSystem.Models;

namespace TasksSystem.Data
{
    public class TasksSystemContext : DbContext
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

        public DbSet<Models.Task> Task { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Project> Project { get; set; }
    }
}
