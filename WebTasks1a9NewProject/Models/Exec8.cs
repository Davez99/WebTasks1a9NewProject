using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTasks1a9NewProject.Models
{
    public class Exec8
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string ReceberNome { get; set; }

        [Display(Name = "E-mail")]
        public string ReceberEmail { get; set; }

        [Display(Name = "RG ou CPF")]
        public string ReceberRG { get; set; }

        [Display(Name = "Documento")]
        public string ResponderAoUser { get; set; }

        [Display(Name = "Conteúdo no documento")]
        public string MostrarAoUser { get; set; }
    }
}
