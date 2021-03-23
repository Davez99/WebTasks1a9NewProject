using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebTasks1a9NewProject.Data;
using WebTasks1a9NewProject.Models;

namespace WebTasks1a9NewProject.Controllers
{
    [Authorize]
    public class Context7Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Context7Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Context7
        public async Task<IActionResult> Index()
        {
            return View(await _context.Exec7.ToListAsync());
        }

        // GET: Context7/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exec7 = await _context.Exec7
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exec7 == null)
            {
                return NotFound();
            }

            return View(exec7);
        }

        // GET: Context7/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Context7/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SalarioUser,Reajuste")] Exec7 exec7)
        {
            ModelState.Clear();

            float x, y, z;

            x = exec7.SalarioUser;

            if (x >= 1700)
            {
                y = x + 200;
                exec7.Reajuste = $"Seu reajuste ficou em {y}";

            }
            else if (x <= 1699)
            {
                z = x + 300;
                exec7.Reajuste = $"Seu reajuste ficou em {z}";
            }

            if (ModelState.IsValid)
            {
                _context.Add(exec7);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exec7);
        }

        // GET: Context7/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exec7 = await _context.Exec7.FindAsync(id);
            if (exec7 == null)
            {
                return NotFound();
            }
            return View(exec7);
        }

        // POST: Context7/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SalarioUser,Reajuste")] Exec7 exec7)
        {
            if (id != exec7.Id)
            {
                return NotFound();
            }

            ModelState.Clear();

            float x, y, z;

            x = exec7.SalarioUser;

            if (x >= 1700)
            {
                y = x + 200;
                exec7.Reajuste = $"Seu reajuste ficou em {y}";

            }
            else if (x <= 1699)
            {
                z = x + 300;
                exec7.Reajuste = $"Seu reajuste ficou em {z}";
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exec7);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Exec7Exists(exec7.Id))
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
            return View(exec7);
        }

        // GET: Context7/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exec7 = await _context.Exec7
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exec7 == null)
            {
                return NotFound();
            }

            return View(exec7);
        }

        // POST: Context7/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exec7 = await _context.Exec7.FindAsync(id);
            _context.Exec7.Remove(exec7);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Exec7Exists(int id)
        {
            return _context.Exec7.Any(e => e.Id == id);
        }
    }
}
