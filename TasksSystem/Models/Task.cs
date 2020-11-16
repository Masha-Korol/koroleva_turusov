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

        [Required]
        public virtual int StatusId
        {
            get
            {
                return (int)this.Status;
            }
            set
            {
                Status = (Statuses)value;
            }
        }
        [EnumDataType(typeof(Statuses))]
        public Statuses Status { get; set; }

        public string Text { get; set; }

        //_________________________________________________

        public Project Project { get; set; }

        public List<Comment> Comments {get; set;}
        public User User { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Task task &&
                   Id == task.Id &&
                   Title == task.Title;
        }
    }
}
