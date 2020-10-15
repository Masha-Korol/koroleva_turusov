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

        public List<Project> Projects { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
