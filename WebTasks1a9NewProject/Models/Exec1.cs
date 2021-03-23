using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTasks1a9NewProject.Models
{
    public class Exec1
    {
        public int Id { get; set; }

        // Interação com o usuário 
        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        [Display(Name = "Escreva um número")]
        public int ReceberNumero { get; set; }

        // Resposta para o Usuário 
        public string Resposta { get; set; }
    }
}
