using System;
using System.Collections.Generic;
using System.IO;
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
    public class Context9Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Context9Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Context9
        public async Task<IActionResult> Index()
        {
            return View(await _context.Exec9.ToListAsync());
        }

        // GET: Context9/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exec9 = await _context.Exec9
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exec9 == null)
            {
                return NotFound();
            }

            return View(exec9);
        }

        // GET: Context9/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Context9/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeUser,IdadeUser,PesoUser,AlturaUser,SaidaUser,AvisoUser,ConteudoUser")] Exec9 exec9)
        {
            //Declaralçao de variáveis 
            var nome = exec9.NomeUser;
            var idade = exec9.IdadeUser;
            float peso = float.Parse(exec9.PesoUser);
            float altura = float.Parse(exec9.AlturaUser);

            //Lógica do IMC
            float imc = peso / (altura * altura);

            if (imc <= 18.5)
            {
                exec9.SaidaUser = "Você esta abaixo do peso!";
            }
            else if ((imc <= 24.9) && (imc >= 18.5))
            {
                exec9.SaidaUser = "Parabéns seu peso esta normal!";
            }
            else if ((imc <= 29.9) && (imc >= 25))
            {
                exec9.SaidaUser = "Você esta acima do peso!";
            }
            else if ((imc <= 34.9) && (imc >= 30))
            {
                exec9.SaidaUser = "Você esta com obesidade nível I !";
            }
            else if ((imc <= 39.9) && (imc >= 35))
            {
                exec9.SaidaUser = "Você esta com obesidade nível II !";
            }
            else
            {
                exec9.SaidaUser = "Você esta com obesidade nível III !";
            }

            //Lógica de criação de documento de texto
            StreamWriter Gravar = new StreamWriter("Exercicio9.txt");

            Gravar.WriteLine($"Nome: {nome}");
            Gravar.WriteLine($"Idade: {idade}");
            Gravar.WriteLine($"Peso: {peso}");
            Gravar.WriteLine($"Altura: {altura}");
            Gravar.WriteLine($"IMC: {imc}");

            Gravar.Close();

            //Aviso que foi criado o documento de texto
            exec9.AvisoUser = "Documento Criado!";

            //Leitor do conteúdo que esta dentro do arquivo de texto
            string Leitura = System.IO.File.ReadAllText("..\\WebTasks1a9NewProject\\Exercicio9.txt");

            exec9.ConteudoUser = Leitura;

            if (ModelState.IsValid)
            {
                _context.Add(exec9);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exec9);
        }

        // GET: Context9/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exec9 = await _context.Exec9.FindAsync(id);
            if (exec9 == null)
            {
                return NotFound();
            }
            return View(exec9);
        }

        // POST: Context9/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeUser,IdadeUser,PesoUser,AlturaUser,SaidaUser,AvisoUser,ConteudoUser")] Exec9 exec9)
        {
            if (id != exec9.Id)
            {
                return NotFound();
            }

            //Declaralçao de variáveis 
            var nome = exec9.NomeUser;
            var idade = exec9.IdadeUser;
            float peso = float.Parse(exec9.PesoUser);
            float altura = float.Parse(exec9.AlturaUser);

            //Lógica do IMC
            float imc = peso / (altura * altura);

            if (imc <= 18.5)
            {
                exec9.SaidaUser = "Você esta abaixo do peso!";
            }
            else if ((imc <= 24.9) && (imc >= 18.5))
            {
                exec9.SaidaUser = "Parabéns seu peso esta normal!";
            }
            else if ((imc <= 29.9) && (imc >= 25))
            {
                exec9.SaidaUser = "Você esta acima do peso!";
            }
            else if ((imc <= 34.9) && (imc >= 30))
            {
                exec9.SaidaUser = "Você esta com obesidade nível I !";
            }
            else if ((imc <= 39.9) && (imc >= 35))
            {
                exec9.SaidaUser = "Você esta com obesidade nível II !";
            }
            else
            {
                exec9.SaidaUser = "Você esta com obesidade nível III !";
            }

            //Lógica de criação de documento de texto
            StreamWriter Gravar = new StreamWriter("Exercicio9.txt");

            Gravar.WriteLine($"Nome: {nome}");
            Gravar.WriteLine($"Idade: {idade}");
            Gravar.WriteLine($"Peso: {peso}");
            Gravar.WriteLine($"Altura: {altura}");
            Gravar.WriteLine($"IMC: {imc}");

            Gravar.Close();

            //Aviso que foi criado o documento de texto
            exec9.AvisoUser = "Documento Criado!";

            //Leitor do conteúdo que esta dentro do arquivo de texto
            string Leitura = System.IO.File.ReadAllText("..\\WbEx1a9\\Exercicio9.txt");

            exec9.ConteudoUser = Leitura;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exec9);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Exec9Exists(exec9.Id))
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
            return View(exec9);
        }

        // GET: Context9/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exec9 = await _context.Exec9
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exec9 == null)
            {
                return NotFound();
            }

            return View(exec9);
        }

        // POST: Context9/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exec9 = await _context.Exec9.FindAsync(id);
            _context.Exec9.Remove(exec9);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Exec9Exists(int id)
        {
            return _context.Exec9.Any(e => e.Id == id);
        }
    }
}
