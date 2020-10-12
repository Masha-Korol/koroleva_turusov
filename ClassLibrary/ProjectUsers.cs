using System;
using System.Collections.Generic;
using System.Linq;

namespace TasksSystem.Models
{
    public class ProjectUsers
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
