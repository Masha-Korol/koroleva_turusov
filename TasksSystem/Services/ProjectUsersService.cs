using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksSystem.Models;
using TasksSystem.Repos;

namespace TasksSystem.Services
{
    public class ProjectUsersService
    {
        ProjectUsersRepository _projectUsersRepository;
        public ProjectUsersService(ProjectUsersRepository projectUsersRepository)
        {
            _projectUsersRepository = projectUsersRepository;
        }

        public List<ProjectUsers> GetAll()
        {
            return _projectUsersRepository.GetAll();
        }
    }
}
