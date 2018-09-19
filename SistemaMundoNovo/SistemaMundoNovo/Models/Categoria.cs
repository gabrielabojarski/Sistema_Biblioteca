using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaMundoNovo.Models
{
    [Table("Categorias")]
    public class Categoria
    {

        [Key]
        public int CategoriaId { get; set; }

        [Display(Name = "Nome Categoria")]
        public string Nome { get; set; }

    }
}