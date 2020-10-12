using ClassLibrary.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
//using System.Data.Entity.Infrastructure;
using System.Reflection;
//using System.Data.Entity.Infrastructure;
using System.Text;

namespace ClassLibrary
{
    /*public class TemporaryDbContextFactory : IDbContextFactory<TasksSystemContext>
    {
        public TasksSystemContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<TasksSystemContext>();
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=efmigrations2017;Trusted_Connection=True;MultipleActiveResultSets=true",
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(TasksSystemContext).GetTypeInfo().Assembly.GetName().Name));
            return new TasksSystemContext(builder.Options);
        }
    }*/
}
