using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Entregas
{
   public class DatosdeInicio : CreateDatabaseIfNotExists<Contexto>
    {
        protected override void Seed (Contexto contexto)
        {
            var usuarioadmin = new Usuario();
            usuarioadmin.Nombre = "admin";
            usuarioadmin.Contraseña = "123";

            contexto.Usuarios.Add(usuarioadmin);

            var categoria1 = new Categoria();
            categoria1.Descripcion = "Paquete Normal";
            contexto.Categorias.Add(categoria1);

            var categoria2 = new Categoria();
            categoria2.Descripcion = "Paquete Express";
            contexto.Categorias.Add(categoria2);


            var categoria3 = new Categoria();
            categoria3.Descripcion = "Paquete Vip";
            contexto.Categorias.Add(categoria3);

            var tipo1 = new Tipo();
            tipo1.Descripcion = "Ropa";
            contexto.Tipos.Add(tipo1);

            var tipo2 = new Tipo();
            tipo2.Descripcion = "Tecnologia";
            contexto.Tipos.Add(tipo2);

            var tipo3 = new Tipo();
            tipo3.Descripcion = "Electrodomestiscos";
            contexto.Tipos.Add(tipo3);

            base.Seed(contexto);
        }

    }
}
