using MundoNovo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MundoNovo.DAL
{
    public class CategoriaDAO
    {

        private static Context ctx = Singleton.Instance.Context;

        public static List<Categoria> ListarCategorias()
        {
            return ctx.Categorias.ToList();
        }

        public static Categoria BuscarCategoriaPorId(int? id)
        {
            return ctx.Categorias.Find(id);
        }

        public static void CadastrarCategoria(Categoria categoria)
        {
            ctx.Categorias.Add(categoria);
            ctx.SaveChanges();
        }

        public static bool EditarCategoria(Categoria categoria)
        {
            if (categoria != null)
            {
                //Puxa novamente o objeto selecionado do banco e altera
                Categoria c = BuscarCategoriaPorId(categoria.id);

                ctx.Entry(c).CurrentValues.SetValues(categoria);
                ctx.Entry(c).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void RemoverCategoria(Categoria categoria)
        {
            ctx.Categorias.Remove(categoria);
            ctx.SaveChanges();
        }
    }
}