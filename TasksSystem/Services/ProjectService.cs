using AutoMapper;
using ClassLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksSystem.Models;
using TasksSystem.Repos;

namespace TasksSystem.Services
{
    public class ProjectService

    {
        private readonly ProjectRepository _projectRepo;
        private readonly ProjectUsersRepository _projectUsersRepository;
        private readonly UserRepository _userRepository;

        public ProjectService(ProjectRepository projectRepository,
                              ProjectUsersRepository projectUsersRepository, 
                              UserRepository userRepository)
        {
            _projectRepo = projectRepository;
            _projectUsersRepository = projectUsersRepository;
            _userRepository = userRepository;
        }

        public void RemoveProject(Project project)
        {
            _projectRepo.RemoveProject(project);
        }

        public bool ProjectExists(int id)
        {
            return _projectRepo.ProjectExists(id);
        }

        public List<User> GetProjectsUsers(int? id)
        {
            List<User> users = new List<User>();
            var projects = _projectUsersRepository.GetAll();
            foreach (ProjectUsers projectUsers in projects)
            {
                if (projectUsers.ProjectId == id)
                {
                    users.Add(_userRepository.GetUserById(projectUsers.UserId));
                }
            }
            return users;
        }  

        public void CreateProject(Project project, string[] users)
        {
            _projectRepo.CreateProject(project, users);
        }

        public List<Project> GetAllProjects()
        {
            return _projectRepo.GetAllProjects();
        }

        public Project GetProjectById(int? id)
        {
            return _projectRepo.GetProjectById(id);
        }

        public void Edit(Project project, string User1, string User2, string User3)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProjectDb, Project>()
                    .ForMember("Name", opt => opt.MapFrom(src => src.Name)));
            var mapper = new Mapper(config);
            /*UserDb user1 = _userRepo.GetUserByName(User1);
            UserDb user2 = _userRepo.GetUserByName(User2);
            UserDb user3 = _userRepo.GetUserByName(User3);
            List<UserDb> users = new List<UserDb>();
            users.Add(user1);
            users.Add(user2);
            users.Add(user3);
            project.Users = users;*/
            //надо вытащить проджект юзеров и их всех изменить
            _projectRepo.UpdateEntity(project);
        }
    }
}
