using System;
using System.Collections.Generic;
using System.Linq;
using TasksSystem.Models;
using TasksSystem.Repos;

namespace TasksSystem.Services
{
    public class TaskService
    {
        private readonly TaskRepository _taskRepository;
        public TaskService(TaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public List<Task> GetAllTasks()
        {
            return _taskRepository.GetAllTasks();
        }

        public Task GetTaskById(int? id)
        {
            return _taskRepository.GetTaskById(id);
        }

        public bool TaskExists(int? id)
        {
            return _taskRepository.TaskExists(id);
        }

        public void Remove(Task task)
        {
            _taskRepository.Remove(task);
        }

        public void Create(Task task, string User)
        {
            _taskRepository.CreateTask(task, User);
        }
        
        public void Update(Task task)
        {
            _taskRepository.Update(task);
        }
    }
}
