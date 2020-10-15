using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TasksSystem.Models
{
    public class Task
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime DeadlineDate { get; set; }

        //public Status status { get; set; }

        public string Text { get; set; }

        //_________________________________________________

        public Project Project { get; set; }

        public List<Comment> Comments {get; set;}
    }
}
