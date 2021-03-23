using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTasks1a9NewProject.Models
{
    public class Exec3
    {
        public int Id { get; set; }

        [Display(Name = "Digite o primeiro número:")]
        public float Num1 { get; set; }

        [Display(Name = "Digite o segundo número:")]
        public float Num2 { get; set; }

        public string Operador { get; set; }

        public float Resultado { get; set; }
    }
}
