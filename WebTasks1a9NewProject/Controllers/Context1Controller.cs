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
    public class Context1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Context1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Context1
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Exec1.ToListAsync());
        }

        // GET: Context1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exec1 = await _context.Exec1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exec1 == null)
            {
                return NotFound();
            }

            return View(exec1);
        }

        // GET: Context1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Context1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ReceberNumero,Resposta")] Exec1 exec1)
        {
            ModelState.Clear();

            int x = exec1.ReceberNumero;

            if (x % 2 == 0)
            {
                exec1.Resposta = "Seu número é *** PAR ***";
            }
            else
            {
                exec1.Resposta = "Seu número é *** IMPAR ***";
            }
            if (ModelState.IsValid)
            {
                _context.Add(exec1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exec1);
        }

        // GET: Context1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exec1 = await _context.Exec1.FindAsync(id);
            if (exec1 == null)
            {
                return NotFound();
            }
            return View(exec1);
        }

        // POST: Context1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReceberNumero,Resposta")] Exec1 exec1)
        {
            if (id != exec1.Id)
            {
                return NotFound();
            }

            ModelState.Clear();

            int x = exec1.ReceberNumero;

            if (x % 2 == 0)
            {
                exec1.Resposta = "Seu número é *** PAR ***";
            }
            else
            {
                exec1.Resposta = "Seu número é *** IMPAR ***";
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exec1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Exec1Exists(exec1.Id))
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
            return View(exec1);
        }

        // GET: Context1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exec1 = await _context.Exec1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exec1 == null)
            {
                return NotFound();
            }

            return View(exec1);
        }

        // POST: Context1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exec1 = await _context.Exec1.FindAsync(id);
            _context.Exec1.Remove(exec1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Exec1Exists(int id)
        {
            return _context.Exec1.Any(e => e.Id == id);
        }
    }
}
