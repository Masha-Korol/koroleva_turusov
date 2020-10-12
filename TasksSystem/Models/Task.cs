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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime DeadlineDate { get; set; }

        //public Status status { get; set; }

        public string UserName { get; set; }

        public int NumberOfDays { get; set; }

        public string Text { get; set; }

        public User User { get; set; }

        public Project Project { get; set; }

        public Task(string Title, DateTime CreationDate, DateTime DeadlineDate, string UserName, int NumberOfDays, string Text)
        {
            this.Title = Title;
            this.CreationDate = CreationDate;
            this.DeadlineDate = DeadlineDate;
            this.UserName = UserName;
            this.NumberOfDays = NumberOfDays;
            this.Text = Text;
        }


    }
}
