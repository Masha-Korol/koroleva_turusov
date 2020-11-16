using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TasksSystem.Models
{
    public class TaskDb
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        [DataType(DataType.Date)]
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
                Status = (StatusesDb)value;
            }
        }
        [EnumDataType(typeof(StatusesDb))]
        public StatusesDb Status { get; set; }

        public string Text { get; set; }

        //_________________________________________________

        public ProjectDb Project { get; set; }

        public List<CommentDb> Comments {get; set;}

        public UserDb User { get; set; }
    }
}
