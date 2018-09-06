using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MundoNovo.Models
{
    [Table("Categorias")]
    public class Categoria
    {

        [Key]
        public int id { get; set; }

        [Display(Name = "Nome Categoria")]
        public string nome { get; set; }

    }
}