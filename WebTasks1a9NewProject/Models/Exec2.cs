using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTasks1a9NewProject.Models
{
    public class Exec2
    {
        //Propriedade Id para identificação no BD
        public int Id { get; set; }

        //propriedade tipo string - pergunta para o usuário
        [Display(Name = "Digite o seu nome:")]
        public string Pergunta { get; set; }

        //Propriedade resposta ao usuário
        [Display(Name = "Resposta:")]
        public string RespostaEx2 { get; set; }
    }
}
