using AutoMapper;
using ClassLibrary.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksSystem.Models;

namespace TasksSystem.Repos
{
    public class ProjectRepository
    {
        private readonly ClassLibraryContext _context;
        private readonly IMapper _mapper;
        public ProjectRepository(ClassLibraryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void UpdateEntity(Project project)
        {
            project.Users = null;
            _context.Project.Update(_mapper.Map<Project, ProjectDb>(project));
            _context.SaveChanges();
        }

        public void RemoveProject(Project project)
        {
            project.Users = null;
            _context.Project.Remove(_mapper.Map<Project, ProjectDb>(project));
            _context.SaveChanges();
        }

        public bool ProjectExists(int id)
        {
            return _context.Project.Any(e => e.Id == id);
        }

        public void CreateProject(Project project, string[] users)
        {
            if (project.Users == null)
            {
                project.Users = new List<ProjectUsers>();
            }

            ProjectUsersDb projectUsersDb1 = new ProjectUsersDb();
            ProjectUsersDb projectUsersDb2 = new ProjectUsersDb();
            ProjectUsersDb projectUsersDb3 = new ProjectUsersDb();

            ProjectDb projectDb = _mapper.Map<Project, ProjectDb>(project);

            var userDb1 = _context.User.AsNoTracking().FirstOrDefault(c => c.Name.Equals(users[0]));
            projectUsersDb1.UserId = userDb1.Id;
            projectUsersDb1.ProjectId = _mapper.Map<Project, ProjectDb>(project).Id;
            ProjectUsers projectUsers1 = _mapper.Map<ProjectUsersDb, ProjectUsers>(projectUsersDb1);
            project.Users.Add(projectUsers1);

            if (users.Length > 1) 
            {
                var userDb2 = _context.User.AsNoTracking().FirstOrDefault(c => c.Name.Equals(users[1]));
                projectUsersDb2.UserId = userDb2.Id;
                projectUsersDb2.ProjectId = _mapper.Map<Project, ProjectDb>(project).Id;
                ProjectUsers projectUsers2 = _mapper.Map<ProjectUsersDb, ProjectUsers>(projectUsersDb2);
                project.Users.Add(projectUsers2);
                projectDb.Users.Add(projectUsersDb2);
            }
            if (users.Length > 2) 
            {
                var userDb3 = _context.User.AsNoTracking().FirstOrDefault(c => c.Name.Equals(users[2]));
                projectUsersDb3.UserId = userDb3.Id;
                projectUsersDb3.ProjectId = _mapper.Map<Project, ProjectDb>(project).Id;
                ProjectUsers projectUsers3 = _mapper.Map<ProjectUsersDb, ProjectUsers>(projectUsersDb3);
                project.Users.Add(projectUsers3);
                projectDb.Users.Add(projectUsersDb3);
            }
            projectDb.Users.Add(projectUsersDb1);
            
            
            _context.Project.Add(projectDb);
            _context.UpdateRange();
            _context.SaveChanges();
        }

        public List<Project> GetAllProjects()
        {
            return _mapper.Map<List<ProjectDb>, List<Project>>(_context.Project.AsNoTracking().ToList());
        }

        public Project GetProjectById(int? id)
        {
            return _mapper.Map<ProjectDb, Project>(_context.Project.AsNoTracking().FirstOrDefault(p => p.Id == id));
        }
    }
}
