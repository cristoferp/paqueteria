using BL.Entregas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Entregas
{
    public class IngresosBL
    {
        Contexto _contexto;
        public BindingList<Ingreso> ListaIngresos { get; set; }

        public IngresosBL()
        {
             
            _contexto = new Contexto();
            ListaIngresos = new BindingList<Ingreso>();

        }
        public BindingList<Ingreso> ObtenerIngresos()
        {
            _contexto.ingresos.Load();
            ListaIngresos = _contexto.ingresos.Local.ToBindingList();

            return ListaIngresos;
        }

        public void CancelarCambios()
        {
            foreach (var item in _contexto.ChangeTracker.Entries())
            {
                item.State = EntityState.Unchanged;
                item.Reload();
            }
        }

        
        public Resultado GuardarIngreso(Ingreso ingreso)
        {
            var resultado = Validar(ingreso);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }

            _contexto.SaveChanges();

            resultado.Exitoso = true;
            return resultado;
        }
        public void AgregarIngreso()
        {
            var nuevoIngreso = new Ingreso();
            _contexto.ingresos.Add(nuevoIngreso);
            //ListaIngresos.Add(nuevoIngreso);
        }

        public bool EliminarIngreso(int id)
        {
            //foreach (var ingreso in ListaIngresos)
            foreach (var ingreso in ListaIngresos.ToList())
            {
                if (ingreso.id == id)
                {
                    ListaIngresos.Remove(ingreso);
                    _contexto.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        private Resultado Validar(Ingreso ingreso)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if (ingreso == null )
            {

                resultado.Mensaje = "Agregue un producto valido";
                resultado.Exitoso = false;

                return resultado;
            }


            if ( String.IsNullOrEmpty (ingreso.Descripcion) == true)
            {
                resultado.Mensaje = "Ingrese una descripcion";
                resultado.Exitoso = false;
            }

            if (ingreso.Codigo<0)
            {
                resultado.Mensaje = "El codigo debe ser mayor que cero";
                resultado.Exitoso = false;
                
                }

                if (ingreso.Existencia < 0)
                {
                    resultado.Mensaje = "La existencia debe ser mayor que cero";
                    resultado.Exitoso = false;

                }
            if (ingreso.Precio < 0)
            {
                resultado.Mensaje = "El codigo debe ser mayor que cero";
                resultado.Exitoso = false;
            }
            
            if (ingreso.TipoId == 0)
            {
                resultado.Mensaje = "Seleccione un tipo";
                resultado.Exitoso = false;
            }

            if (ingreso.CategoriaId == 0)
            {
                resultado.Mensaje = "selecione una categoria";
                resultado.Exitoso = false; 
            }
            return resultado;
        
            
          }


    }            
    public class Ingreso
        {
            public int id { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public double Precio { get; set; }
            public int Codigo { get; set; }
            public int CategoriaId { get; set; }
            public Categoria Categoria { get; set; }
            public int TipoId { get; set; }
            public Tipo Tipo { get; set; }
            public byte[] Foto { get; set; }
            public bool Activo { get; set; }
            public int Existencia { get; set; }



        public Ingreso()
        {
            Activo = true;
        }

            
        }
        public class Resultado
        {
            public bool Exitoso { get; set; }
            public string Mensaje { get; set; }
        }
    }


