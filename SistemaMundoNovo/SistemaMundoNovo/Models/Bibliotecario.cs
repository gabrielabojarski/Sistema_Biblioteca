using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaMundoNovo.Models
{
    [Table("Bibliotecarios")]
    public class Bibliotecario
    {
        [Key]
        public int BibliotecarioID { get; set; }

        [Required]
        [Display(Name ="Nome")]
        public string Nome { get; set; }

        [Display(Name = "Matricula")]
        [Range(1,2000)]
        public long Matricula { get; set; }

    }
}