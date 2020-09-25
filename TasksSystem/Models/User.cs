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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Task> Tasks { get; set; }

        public void AddTask(Task task)
        {
            //this.Tasks.AddLast(task);
            this.Tasks.AddRange(new List<Task>() { task });
        }

        public User(string Name, int id)
        {
            this.Name = Name;
            this.Id = id;
            this.Tasks = new List<Task>();
        }
    }
}
