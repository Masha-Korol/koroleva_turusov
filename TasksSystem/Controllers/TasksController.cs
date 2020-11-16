using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasksSystem.Models;
using TasksSystem.Repos;
using TasksSystem.Services;

namespace TasksSystem.Controllers
{
    public class TasksController : Controller
    {
        private readonly TaskService _taskService;
        private readonly UserRepository _userRepository;
        private readonly CommentService _commentService;

        public TasksController(TaskService taskService, UserRepository userRepository, CommentService commentService)
        {
            _taskService = taskService;
            _userRepository = userRepository;
            _commentService = commentService;
        }

        // POST: Tasks/CreateComment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateComment(string text)
        {
            if (ModelState.IsValid)
            {
                Comment comment = new Comment(text);
                _commentService.CreateComment(comment);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            return View(_taskService.GetAllTasks());
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Models.Task task, string User)
        {
            if (ModelState.IsValid)
            {
                var user = _userRepository.GetUserByName(User);
                _taskService.Create((Models.Task)task, User);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = _taskService.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // POST: Tasks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] Models.Task task)
        {
            if (id != task.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _taskService.Update(task);
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = _taskService.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            ViewBag.Comments = _commentService.GetAllComments();
            return View(task);
        }

        // GET: Tasks/DeleteComment/5
        public async Task<IActionResult> DeleteComment(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = _commentService.GetCommentById(id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // POST: Tasks/DeleteComment/5
        [HttpPost, ActionName("DeleteComment")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCommentConfirmed(int id)
        {
            var comment = _commentService.GetCommentById(id);
            _commentService.RemoveComment(comment);
            return RedirectToAction(nameof(Index));
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = _taskService.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var task = _taskService.GetTaskById(id);
            _taskService.Remove(task);
            return RedirectToAction(nameof(Index));
        }

        private bool TaskExists(int id)
        {
            return _taskService.TaskExists(id);
        }
    }
}
