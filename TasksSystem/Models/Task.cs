using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TasksSystem.Models
{
    public class Task
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime DeadlineDate { get; set; }

        //public Status status { get; set; }

        public int UserId { get; set; }
        
        public int NumberOfDays { get; set; }

        public string Text { get; set; }
    }
}
