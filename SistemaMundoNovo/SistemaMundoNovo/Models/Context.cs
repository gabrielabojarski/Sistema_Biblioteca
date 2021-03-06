﻿using System.Data.Entity;

namespace SistemaMundoNovo.Models
{
    public class Context : DbContext
    {
        public DbSet<Bibliotecario> Bibliotecarios { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Livro> Livros { get; set; }

    }
}