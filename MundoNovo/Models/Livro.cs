using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MundoNovo.Models
{
    [Table("Livros")]
    public class Livro
    {

        [Key]
        public int id { get; set; }

        [Display(Name = "Titulo")]
        public string titulo { get; set; }

        [Display(Name = "Autor")]
        public string autor { get; set; }

        [Display(Name = "Data")]
        public DateTime ano { get; set; }

        [Display(Name = "Categoria")]
        public Categoria categoria { get; set; }

        [Display(Name = "Descrição")]
        public string descricao { get; set; }
    }
}