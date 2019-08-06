using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Entregas
{
    public class ClientesBL
    {
        public BindingList<Clientes> ListaClientes { get; set; }
        
        public ClientesBL()
        {
            ListaClientes = new BindingList<Clientes>();

            var cliente1 = new Clientes();
            cliente1.Id = 001;
            cliente1.Nombre = "Bella";
            cliente1.Direccion = "Res. Mackay, San Pedro Sula, Cortes";
            cliente1.Telefono = 99473245;
            cliente1.Correo = "bellahadid@gmail.com";

            ListaClientes.Add(cliente1);

            var cliente2 = new Clientes();
            cliente2.Id = 002;
            cliente2.Nombre = "Sara S";
            cliente2.Direccion = "Res. Merendon, San Pedro Sula, Cortes";
            cliente2.Telefono = 99463240;
            cliente2.Correo = "sarasampaio@gmail.com";

            ListaClientes.Add(cliente2);

            var cliente3 = new Clientes();
            cliente3.Id = 003;
            cliente3.Nombre = "Jasmin";
            cliente3.Direccion = "Res. Veranda, San Pedro Sula, Cortes";
            cliente3.Telefono = 88763241;
            cliente3.Correo = "jasmin@gmail.com";

            ListaClientes.Add(cliente3);
            
        }
        public BindingList<Clientes> ObtenerClientes()
        {
            return ListaClientes;
        }
    }
      public class Clientes
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public double Telefono { get; set; }
        public string Correo { get; set; }
    }
       
}
