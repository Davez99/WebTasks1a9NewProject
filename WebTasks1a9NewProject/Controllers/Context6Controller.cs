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
    public class Context6Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Context6Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Context6
        public async Task<IActionResult> Index()
        {
            return View(await _context.Exec6.ToListAsync());
        }

        // GET: Context6/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exec6 = await _context.Exec6
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exec6 == null)
            {
                return NotFound();
            }

            return View(exec6);
        }

        // GET: Context6/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Context6/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EntradaTexto,SaidaTexto")] Exec6 exec6)
        {
            ModelState.Clear();
            /* Criado uma variavel "texto" para a propriedade "EntradaTexto" que vem da Model Ex06
             * Na sequência feito um Array char com tamanho 200 e identificando ele como "letra"
             * Atribuindo para "letra" o "texto" no formato array
             * Feito o primeiro loop com "for" para ler e fragmentar a palavra em caracteres
             * Dentro do for feito mais um loop com while para que fosse identificado entre os caracteres o "a"
             * Com a substituição do "a" para "&" retornando para o "letra"
             * Finalizando com a transformação da "letra" que é um array para uma nova string, possibilitando levar as informações na tela através de um tipo.
             */

            var texto = exec6.EntradaTexto;

            char[] letra = new char[200];
            letra = texto.ToCharArray();


            for (int i = 0; i < letra.Length; i++)
            {
                while (letra[i] == 'a')
                {
                    letra[i] = '&';
                }
            }

            String letraModificada = new string(letra);

            exec6.SaidaTexto = letraModificada;

            if (ModelState.IsValid)
            {
                _context.Add(exec6);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exec6);
        }

        // GET: Context6/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exec6 = await _context.Exec6.FindAsync(id);
            if (exec6 == null)
            {
                return NotFound();
            }
            return View(exec6);
        }

        // POST: Context6/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EntradaTexto,SaidaTexto")] Exec6 exec6)
        {
            if (id != exec6.Id)
            {
                return NotFound();
            }

            ModelState.Clear();
            /* Criado uma variavel "texto" para a propriedade "EntradaTexto" que vem da Model Ex06
             * Na sequência feito um Array char com tamanho 200 e identificando ele como "letra"
             * Atribuindo para "letra" o "texto" no formato array
             * Feito o primeiro loop com "for" para ler e fragmentar a palavra em caracteres
             * Dentro do for feito mais um loop com while para que fosse identificado entre os caracteres o "a"
             * Com a substituição do "a" para "&" retornando para o "letra"
             * Finalizando com a transformação da "letra" que é um array para uma nova string, possibilitando levar as informações na tela através de um tipo.
             */

            var texto = exec6.EntradaTexto;

            char[] letra = new char[200];
            letra = texto.ToCharArray();


            for (int i = 0; i < letra.Length; i++)
            {
                while (letra[i] == 'a')
                {
                    letra[i] = '&';
                }
            }

            String letraModificada = new string(letra);

            exec6.SaidaTexto = letraModificada;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exec6);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Exec6Exists(exec6.Id))
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
            return View(exec6);
        }

        // GET: Context6/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exec6 = await _context.Exec6
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exec6 == null)
            {
                return NotFound();
            }

            return View(exec6);
        }

        // POST: Context6/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exec6 = await _context.Exec6.FindAsync(id);
            _context.Exec6.Remove(exec6);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Exec6Exists(int id)
        {
            return _context.Exec6.Any(e => e.Id == id);
        }


    }
}
