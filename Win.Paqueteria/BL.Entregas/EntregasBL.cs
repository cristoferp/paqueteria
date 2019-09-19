using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Entregas
{
    public class EntregasBL
    {
        public BindingList<Entregas> ListaEntregas { get; set; }

        public EntregasBL()
        {
            ListaEntregas = new BindingList<Entregas>();

            var entrega1 = new Entregas();
            entrega1.Nombre = "Selena Maria Lopez Turcios";
            entrega1.Direccion = "Barrio El Benque, La Ceiba";
            entrega1.Id = 222;
            entrega1.Precio = 1000;
            entrega1.Codigo = 1902;
            entrega1.Activo = true;

            ListaEntregas.Add(entrega1);

            var entrega2 = new Entregas();
            entrega2.Nombre = "Ana Maria Castro";
            entrega2.Direccion = "Res. Campisa, S.P.S, Cortes";
            entrega2.Id = 111;
            entrega2.Precio = 500;
            entrega2.Codigo = 1002;
            entrega2.Activo = true;

            ListaEntregas.Add(entrega2);

            var entrega3 = new Entregas();
            entrega3.Nombre = "Gigi Romero Martinez";
            entrega3.Direccion = "Barrio Las Palmas, S.P.S, Cortes";
            entrega3.Id = 333;
            entrega3.Precio = 1000;
            entrega3.Codigo = 11023;
            entrega3.Activo = true;

            ListaEntregas.Add(entrega3);

        }
        public BindingList<Entregas> ObtenerEntregas()
        {
            return ListaEntregas;
        }
    }
    public class Entregas
    {
        public string Nombre { get; set; }
        public int Id { get; set; }
        public string Direccion { get; set; }
        public double Precio { get; set; }
        public int Codigo { get; set; }
        public bool Activo { get; set; }

    }
}
