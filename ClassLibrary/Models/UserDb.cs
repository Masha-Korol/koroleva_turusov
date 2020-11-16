using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TasksSystem.Models
{
    public class UserDb
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        //__________________________________________

        public List<ProjectUsersDb> Projects { get; set; }

        public List<CommentDb> Comments { get; set; }
        public List<TaskDb> Tasks { get; set; }
    }
}
