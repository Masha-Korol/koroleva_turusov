using AutoMapper;
using ClassLibrary.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TasksSystem.Models;

namespace TasksSystem.Repos
{
    public class TaskRepository
    {
        private readonly ClassLibraryContext _context;
        private readonly IMapper _mapper;

        public TaskRepository(ClassLibraryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreateTask(Task task, string User)
        {
            var user = _context.User.AsNoTracking().FirstOrDefault(c => c.Name.Equals(User));
            //task.User = _mapper.Map<UserDb, User>(user);
            var taskDb = _mapper.Map<Task, TaskDb>(task);
            //taskDb.User = user;
            _context.Task.Add(taskDb);
            _context.UpdateRange();
            _context.SaveChanges();
        }

        public void Update(Task task)
        {
            _context.Task.Update(_mapper.Map<Task, TaskDb>(task));
            _context.SaveChanges();
        }

        public List<Task> GetAllTasks()
        {
            return _mapper.Map<List<TaskDb>, List<Task>>(_context.Task.AsNoTracking().ToList());
        }

        public List<Task> GetUsersTasks(User user)
        {
            List<TaskDb> tasks = new List<TaskDb>();
            IQueryable<TaskDb> usersTasks = _context.Task.AsNoTracking().Where(t => t.User.Equals(_mapper.Map<User, UserDb>(user)));
            foreach(TaskDb task in usersTasks)
            {
                tasks.Add(task);
            }
            return _mapper.Map<List<TaskDb>, List<Task>>(tasks);
        }

        public Task GetTaskById(int? id)
        {
            return _mapper.Map<TaskDb, Task>(_context.Task.AsNoTracking().FirstOrDefault(m => m.Id == id));
        }

        public void Remove(Task task)
        {
            _context.Task.Remove(_mapper.Map<Task, TaskDb>(task));
            _context.SaveChanges();
        }

        public bool TaskExists(int? id)
        {
            return _context.Task.Any(e => e.Id == id);
        }
    }
}
