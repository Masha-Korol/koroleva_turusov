using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TasksSystem.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //__________________________________________

        public List<ProjectUsers> Projects { get; set; }

        public List<Comment> Comments { get; set; }
        public List<Task> Tasks { get; set; }



        public User()
        {
            Projects = new List<ProjectUsers>();
        }

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   Id == user.Id &&
                   Name == user.Name;
        }
    }
}
