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
    public class Context5Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Context5Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Context5
        public async Task<IActionResult> Index()
        {
            return View(await _context.Exec5.ToListAsync());
        }

        // GET: Context5/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exec5 = await _context.Exec5
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exec5 == null)
            {
                return NotFound();
            }

            return View(exec5);
        }

        // GET: Context5/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Context5/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EntradaUser,SaidaUser")] Exec5 exec5)
        {
            exec5.SaidaUser = RetornoNomeUser(exec5.EntradaUser);

            if (ModelState.IsValid)
            {
                _context.Add(exec5);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exec5);
        }

        // GET: Context5/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exec5 = await _context.Exec5.FindAsync(id);
            if (exec5 == null)
            {
                return NotFound();
            }
            return View(exec5);
        }

        // POST: Context5/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EntradaUser,SaidaUser")] Exec5 exec5)
        {
            exec5.SaidaUser = RetornoNomeUser(exec5.EntradaUser);

            if (id != exec5.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exec5);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Exec5Exists(exec5.Id))
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
            return View(exec5);
        }

        // GET: Context5/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exec5 = await _context.Exec5
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exec5 == null)
            {
                return NotFound();
            }

            return View(exec5);
        }

        // POST: Context5/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exec5 = await _context.Exec5.FindAsync(id);
            _context.Exec5.Remove(exec5);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Exec5Exists(int id)
        {
            return _context.Exec5.Any(e => e.Id == id);
        }

        private static string RetornoNomeUser(string nome)
        {
            nome = $"Olá meu nome é  {nome}";
            return nome;
        }
    }
}
