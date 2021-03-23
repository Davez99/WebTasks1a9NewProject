using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTasks1a9NewProject.Models
{
    public class Exec4
    {
        public int Id { get; set; }

        //propriedade para entrada da idade do user
        [Display(Name = "Digite sua idade")]
        public int IdadeEntrada { get; set; }

        // propriedade de saida da permissão de entrada
        [Display(Name = "Digite sua idade")]
        public string IdadeSaida { get; set; }
    }
}
