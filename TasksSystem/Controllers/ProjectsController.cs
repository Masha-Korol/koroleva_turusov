using AutoMapper;
using ClassLibrary.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksSystem.Models;
using TasksSystem.Services;

namespace TasksSystem.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ProjectService _projectService;
        private readonly UserService _userService;
        private readonly ProjectUsersService _projectUsersService;

        public ProjectsController(ProjectService projectService, UserService userService, ProjectUsersService projectUsersService)
            {
            _projectService = projectService;
            _userService = userService;
            _projectUsersService = projectUsersService;
            }

            // GET: Projects
            public async Task<IActionResult> Index()
            {
                return View(_projectService.GetAllProjects());
            }

            // GET: Projects/Create
            public IActionResult Create()
            {
            List<User> users = _userService.GetAllUsers();
            ViewBag.Users = users;
            return View();
            }

            // POST: Projects/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([FromForm] Project project, string User1, string User2, string User3)
        public async Task<IActionResult> Create([FromForm] Project project, string[] users)
        {
            if (users.Length >= 4 || users.Length == 0)
            {
                return Create();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    _projectService.CreateProject(project, users);
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
        }

            // GET: Projects/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

            var project = _projectService.GetProjectById(id);
                if (project == null)
                {
                    return NotFound();
                }
                return View(project);
            }

            // POST: Projects/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [FromForm] Project project, string User1, string User2, string User3)
            {
                if (id != project.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                _projectService.Edit(project, User1, User2, User3);   
                    return RedirectToAction(nameof(Index));
                }
                return View(project);
            }

            // GET: Projects/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

            var project = _projectService.GetProjectById(id);    
            if (project == null)
                {
                    return NotFound();
                }

            List<User> users = _projectService.GetProjectsUsers(id);
            ViewBag.Users = users;
            return View(project);
         }

            // GET: Projects/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

            var project = _projectService.GetProjectById(id);    
            if (project == null)
                {
                    return NotFound();
                }

                return View(project);
            }

            // POST: Projects/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
            var project = _projectService.GetProjectById(id);
            _projectService.RemoveProject(project);
                return RedirectToAction(nameof(Index));
            }

            private bool PojectExists(int id)
            {
            return _projectService.ProjectExists(id);
            }
        }
}
