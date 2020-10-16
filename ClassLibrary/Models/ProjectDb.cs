using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TasksSystem.Models
{
    public class ProjectDb
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public List<TaskDb> Tasks { get; set; }

        public List<ProjectUsers> Users { get; set; }

        //public Status status { get; set; }
    }
}
