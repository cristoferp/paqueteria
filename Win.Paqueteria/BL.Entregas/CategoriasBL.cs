using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Entregas
{
   public  class CategoriasBL
    {
        Contexto _contexto;
        public BindingList<Categoria> listaCategorias { get; set; }

        public CategoriasBL()
        {
            _contexto = new Contexto();
            listaCategorias = new BindingList<Categoria>();
           
        }

        public BindingList<Categoria> ObtenerCategorias()
        {
            _contexto.Categorias.Load();
            listaCategorias = _contexto.Categorias.Local.ToBindingList();

            return listaCategorias;
        }
    }


    public class Categoria
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
    }
}
