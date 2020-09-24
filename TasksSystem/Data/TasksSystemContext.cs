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

        public DbSet<Task> Task { get; set; }
    }
}
