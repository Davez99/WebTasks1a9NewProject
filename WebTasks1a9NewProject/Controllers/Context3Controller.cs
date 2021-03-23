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
    public class Context3Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Context3Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Context3
        public async Task<IActionResult> Index()
        {
            return View(await _context.Exec3.ToListAsync());
        }

        // GET: Context3/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exec3 = await _context.Exec3
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exec3 == null)
            {
                return NotFound();
            }

            return View(exec3);
        }

        // GET: Context3/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Context3/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Num1,Num2,Operador,Resultado")] Exec3 exec3)
        {
            ModelState.Clear();

            switch (exec3.Operador)
            {
                case "+":
                    exec3.Resultado = exec3.Num1 + exec3.Num2;
                    break;
                case "-":
                    exec3.Resultado = exec3.Num1 - exec3.Num2;
                    break;
                case "*":
                    exec3.Resultado = exec3.Num1 * exec3.Num2;
                    break;
                case "/":
                    exec3.Resultado = exec3.Num1 / exec3.Num2;
                    break;
                default:
                    break;
            }

            if (ModelState.IsValid)
            {
                _context.Add(exec3);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exec3);
        }

        // GET: Context3/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exec3 = await _context.Exec3.FindAsync(id);
            if (exec3 == null)
            {
                return NotFound();
            }
            return View(exec3);
        }

        // POST: Context3/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Num1,Num2,Operador,Resultado")] Exec3 exec3)
        {
            if (id != exec3.Id)
            {
                return NotFound();
            }

            ModelState.Clear();

            switch (exec3.Operador)
            {
                case "+":
                    exec3.Resultado = exec3.Num1 + exec3.Num2;
                    break;
                case "-":
                    exec3.Resultado = exec3.Num1 - exec3.Num2;
                    break;
                case "*":
                    exec3.Resultado = exec3.Num1 * exec3.Num2;
                    break;
                case "/":
                    exec3.Resultado = exec3.Num1 / exec3.Num2;
                    break;
                default:
                    break;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exec3);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Exec3Exists(exec3.Id))
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
            return View(exec3);
        }

        // GET: Context3/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exec3 = await _context.Exec3
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exec3 == null)
            {
                return NotFound();
            }

            return View(exec3);
        }

        // POST: Context3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exec3 = await _context.Exec3.FindAsync(id);
            _context.Exec3.Remove(exec3);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Exec3Exists(int id)
        {
            return _context.Exec3.Any(e => e.Id == id);
        }

    }
}
