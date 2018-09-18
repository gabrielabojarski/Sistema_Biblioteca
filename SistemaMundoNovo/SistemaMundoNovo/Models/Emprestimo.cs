using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaMundoNovo.Models
{
    [Table("Emprestimos")]
    public class Emprestimo
    {
        [Key]
        public int id { get; set; }

        public Livro livro { get; set; }
        public Bibliotecario bibliotecario { get; set; }

        [DataType(DataType.Currency)]
        public double valor { get; set; }
        public string dataPrazo { get; set; }
        public string dataDevolucao { get; set; }
        public int status { get; set; }
        public string cep { get; set; }
        public string endereco { get; set; }
        public string nome { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }

    }
}