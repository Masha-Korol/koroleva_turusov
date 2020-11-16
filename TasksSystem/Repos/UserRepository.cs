using AutoMapper;
using ClassLibrary.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TasksSystem.Models;

namespace TasksSystem.Repos
{
    public class UserRepository
    {
        private readonly ClassLibraryContext _context;
        private readonly TaskRepository _taskRepository;
        private readonly IMapper _mapper;
        public UserRepository(ClassLibraryContext context, TaskRepository taskRepository, IMapper mapper)
        {
            _context = context;
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public User GetUserByName(string Name)
        {
            var user = _context.User.AsNoTracking().FirstOrDefault(c => c.Name.Equals(Name));
            user.Projects = null;
            return _mapper.Map<UserDb, User>(user);
        }

        public void UpdateEntity(User user)
        {
            _context.User.Update(_mapper.Map<User, UserDb>(user));
            _context.SaveChanges();
        }

        public void RemoveUser(User user)
        {
            _context.User.Remove(_mapper.Map<User, UserDb>(user));
            _context.SaveChanges();
        }

        public void CreateUser(User user)
        {
            _context.User.Add(_mapper.Map<User, UserDb>(user));
            _context.SaveChanges();
        }

        public bool UserExistsAsync(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }

        public List<User> GetAllUsers()
        {
            return _mapper.Map<List<UserDb>, List<User>>(_context.User.AsNoTracking().ToList());
        }

        public User GetUserById(int? id)
        {
            var user = _context.User.AsNoTracking().FirstOrDefault(p => p.Id == id);
            user.Projects = null;
            return _mapper.Map<UserDb, User>(user);
        }

        public List<Task> GetUsersTasks(User user)
        {
            return _taskRepository.GetUsersTasks(user);
        }
    }
}
