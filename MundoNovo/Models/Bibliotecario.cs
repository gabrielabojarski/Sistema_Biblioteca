using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MundoNovo.Models
{
    [Table("Bibliotecarios")]
    public class Bibliotecario
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "Login")]
        public string login { get; set; }

        public string guid { get; set; }
        
        [Display(Name = "Senha")]
        public string senha { get; set; }

        [Display(Name ="Nome")]
        public string nome { get; set; }

        [Display(Name = "Matricula")]
        [Range(1,500)]
        public long matricula { get; set; }

    }
}