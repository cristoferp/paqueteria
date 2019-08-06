using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Entregas
{
    public class IngresosBL
    {
        public BindingList<Ingreso> ListaIngresos { get; set; }

        public IngresosBL()
        {
            ListaIngresos = new BindingList<Ingreso>();

            var ingreso1 = new Ingreso();
            ingreso1.id = 1;
            ingreso1.Nombre = "Juan";
            ingreso1.Descripcion = "Zapatos";
            ingreso1.Precio = 2000;
            ingreso1.Codigo = 123;
            ingreso1.Activo = true;

            ListaIngresos.Add(ingreso1);

            var ingreso2 = new Ingreso();
            ingreso2.id = 2;
            ingreso2.Nombre = "Salma";
            ingreso2.Descripcion = "Telefonos";
            ingreso2.Precio = 3000;
            ingreso2.Codigo = 222;
            ingreso2.Activo = true;

            ListaIngresos.Add(ingreso2);

            var ingreso3 = new Ingreso();
            ingreso3.id = 3;
            ingreso3.Nombre = "Selena";
            ingreso3.Descripcion = "Ropa Marca Kalvin";
            ingreso3.Precio = 4000;
            ingreso3.Codigo = 333;
            ingreso3.Activo = true;

            ListaIngresos.Add(ingreso3);

        }
        public BindingList<Ingreso> ObtenerIngresos()
        {
            return ListaIngresos;
        }
        public Resultado GuardarIngreso(Ingreso ingreso)
        {
            var resultado = Validar(ingreso);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }

            if (ingreso.id == 0)
            {
                ingreso.id = ListaIngresos.Max(item => item.id) + 1;
            }
            resultado.Exitoso = true;
            return resultado;
        }
        public void AgregarIngreso()
        {
            var nuevoIngreso = new Ingreso();
            ListaIngresos.Add(nuevoIngreso);
        }

        public bool EliminarIngreso(int id)
        {
            foreach (var ingreso in ListaIngresos)
            {
                if (ingreso.id == id)
                {
                    ListaIngresos.Remove(ingreso);
                    return true;
                }
            }

            return false;
        }
        private Resultado Validar(Ingreso ingreso)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if (string.IsNullOrEmpty(ingreso.Descripcion) == true)
            {
                resultado.Mensaje = "Ingrese una descripcion";
                resultado.Exitoso = false;
            }
            if (ingreso.Codigo < 0)
            {
                resultado.Mensaje = "La existencia debe ser mayor que cero";
                resultado.Exitoso = false;
            }
            if (ingreso.Precio < 0)
            {
                resultado.Mensaje = "El precio debe ser mayor que cero";
                resultado.Exitoso = false;
            }



            return resultado;
        }      
    public class Ingreso
        {
            public int id { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }
            public double Precio { get; set; }
            public int Codigo { get; set; }
            public bool Activo { get; set; }
            
        }
        public class Resultado
        {
            public bool Exitoso { get; set; }
            public string Mensaje { get; set; }
        }
    }
}

