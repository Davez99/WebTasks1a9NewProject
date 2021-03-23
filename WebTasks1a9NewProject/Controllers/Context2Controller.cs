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
    public class Context2Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Context2Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Context2
        public async Task<IActionResult> Index()
        {
            return View(await _context.Exec2.ToListAsync());
        }

        // GET: Context2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exec2 = await _context.Exec2
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exec2 == null)
            {
                return NotFound();
            }

            return View(exec2);
        }

        // GET: Context2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Context2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Pergunta,RespostaEx2")] Exec2 exec2)
        {
            ModelState.Clear();

            var x = exec2.Pergunta;

            exec2.RespostaEx2 = $"Seu nome é: {x}";

            if (ModelState.IsValid)
            {
                _context.Add(exec2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exec2);
        }

        // GET: Context2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exec2 = await _context.Exec2.FindAsync(id);
            if (exec2 == null)
            {
                return NotFound();
            }
            return View(exec2);
        }

        // POST: Context2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Pergunta,RespostaEx2")] Exec2 exec2)
        {
            if (id != exec2.Id)
            {
                return NotFound();
            }

            ModelState.Clear();

            var x = exec2.Pergunta;

            exec2.RespostaEx2 = $"Seu nome é: {x}";

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exec2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Exec2Exists(exec2.Id))
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
            return View(exec2);
        }

        // GET: Context2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exec2 = await _context.Exec2
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exec2 == null)
            {
                return NotFound();
            }

            return View(exec2);
        }

        // POST: Context2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exec2 = await _context.Exec2.FindAsync(id);
            _context.Exec2.Remove(exec2);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Exec2Exists(int id)
        {
            return _context.Exec2.Any(e => e.Id == id);
        }
    }
}
