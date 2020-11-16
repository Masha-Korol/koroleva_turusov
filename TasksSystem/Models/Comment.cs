using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TasksSystem.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public String text { get; set; }

        //_________________________________
        public User User { get; set; }

        public Task Task { get; set; }

        public Comment(string text)
        {
            this.text = text;
        }
    }
}
