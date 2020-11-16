using AutoMapper;
using ClassLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using TasksSystem.Models;
using TasksSystem.Repos;

namespace TasksSystem.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepo;
        private readonly TaskRepository _taskRepo;
        public UserService(ClassLibraryContext context, UserRepository userRepo, TaskRepository taskRepo)
        {
            _userRepo = userRepo;
            _taskRepo = taskRepo;
        }

        public void RemoveUser(User user)
        {
            DeleteAllUsersTasks(user);
            _userRepo.RemoveUser(user);
        }
        
        public void CreateUser(User user)
        {
            _userRepo.CreateUser(user);
        }

        public bool UserExists(int id)
        {
            return _userRepo.UserExistsAsync(id);
        }

        public List<User> GetAllUsers()
        {
            return _userRepo.GetAllUsers();
        }

        public User GetUserById(int? id)
        {
            return _userRepo.GetUserById(id);
        }

        public void Edit(User user)
        {
            _userRepo.UpdateEntity(user);
        }

        public List<Task> GetUsersTasks(User user) {
            //return _taskRepo.GetUsersTasks(user);
            List<Task> usersTasks = new List<Task>();
            var tasks = _taskRepo.GetAllTasks();
            foreach (Task task in tasks)
            {
                if(task.Id == user.Id)
                {
                    usersTasks.Add(task);
                }
            }
            return usersTasks;
        }

        public void DeleteAllUsersTasks(User user)
        {
            List<Task> tasks = GetUsersTasks(user);
            foreach(Task task in tasks)
            {
                _taskRepo.Remove(task);
            }
        }
    }
}
