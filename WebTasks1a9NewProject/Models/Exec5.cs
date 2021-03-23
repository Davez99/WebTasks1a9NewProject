using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTasks1a9NewProject.Models
{
    public class Exec5
    {
        public int Id { get; set; }

        [Display(Name = "Escreva o seu nome para sair na tela:")]
        public string EntradaUser { get; set; }

        [Display(Name = "Resultado:")]
        public string SaidaUser { get; set; }
    }
}
