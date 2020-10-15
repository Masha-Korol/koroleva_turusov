﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TasksSystem.Models
{
    public class Project
    {
        public int Id { get; set; }
        public List<Task> Tasks { get; set; }

        public List<User> Users { get; set; }

        //public Status status { get; set; }
    }
}
