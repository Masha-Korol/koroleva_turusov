using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TasksSystem.Data;
using TasksSystem.Models;
using Task = TasksSystem.Models.Task;

namespace TasksSystem.Controllers
{
    public class TasksController : Controller
    {
        private readonly TasksSystemContext _context;

        public TasksController(TasksSystemContext context)
        {
            _context = context;
        }

        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Task.ToListAsync());
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var task = await _context.Task
                .FirstOrDefaultAsync(m => m.Id == Id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("id,Title,CreationDate,DeadlineDate,UserId,NumberOfDays,Text")] Task task, int Id)
        public async Task<IActionResult> Create(string Title,
                                                DateTime CreationDate,
                                                DateTime DeadlineDate,
                                                string UserName,
                                                int NumberOfDays,
                                                string Text, int id)
        {           
            if (ModelState.IsValid)
            {
                User user = _context.User.Find(id);
                Task task = new Task(Title, CreationDate, DeadlineDate, UserName, NumberOfDays, Text);
                task.User = user;
                _context.Add(task);
                user.Tasks.AddRange(new List<Task>() { task });
                //task.User.Tasks.Add(task);
                //_context.Entry(User).State = EntityState.Modified;
                //user.Tasks.Add(task);
                //user.addTask(task);
                _context.Update<User>(user);
                //_context.UpdateRange(user.Tasks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
            //return View(task);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Task.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, [Bind("id,Title,CreationDate,DeadlineDate,UserId,NumberOfDays,Text")] Task task)
        {
            if (Id != task.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(task);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskExists(task.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var task = await _context.Task
                .FirstOrDefaultAsync(m => m.Id == Id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            var task = await _context.Task.FindAsync(Id);
            _context.Task.Remove(task);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskExists(int Id)
        {
            return _context.Task.Any(e => e.Id == Id);
        }
    }
}
