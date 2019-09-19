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
    public class FacturasBL
    {
        Contexto _contexto;

        public BindingList<Facturas> ListaFacturas { get; set; }

        public FacturasBL()
        {
            _contexto = new Contexto();
        }

        public BindingList<Facturas> ObtenerFacturas()    
    {
            _contexto.Facturas.Include("FacturaDetalle").Load();
            ListaFacturas = _contexto.Facturas.Local.ToBindingList();

            return ListaFacturas;
     
    }
    public void AgregarFactura()
    {
            var nuevaFactura = new Facturas();
            _contexto.Facturas.Add(nuevaFactura);
   
    }
        public void AgregarFacturaDetalle(Facturas factura)
        {
            if (factura != null)
            {
                var nuevoDetalle = new FacturaDetalle();
                factura.FacturaDetalle.Add(nuevoDetalle);
            }
        }
        public void RemoverFacturaDetalle(Facturas factura, FacturaDetalle facturaDetalle)
        {
            if (factura != null && facturaDetalle != null)
            {
                factura.FacturaDetalle.Remove(facturaDetalle);
            }
        }

    public void CancelarCambios()
    {
        foreach (var item in _contexto.ChangeTracker.Entries())
        {
            item.State = EntityState.Unchanged;
            item.Reload();
        }
    }
        public Resultado GuardarFacturas(Facturas facturas)
        {
            var resultado = Validar(facturas);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }

            CalcularExistencia(facturas);

            
        _contexto.SaveChanges();
        resultado.Exitoso = true;
        return resultado;
    }

        private void CalcularExistencia(Facturas facturas)
        {
            foreach (var detalle in facturas.FacturaDetalle)
            {
                var ingresos = _contexto.ingresos.Find(detalle.ProductoId);
                if (ingresos != null)

                {
                    if (facturas.Activo == true)
                    {
                         ingresos.Existencia = ingresos.Existencia - detalle.Cantidad;
                
                      }   
                    else
                    {
                        ingresos.Existencia = ingresos.Existencia + detalle.Cantidad;
                    }
               }
            }
        }

        private Resultado Validar(Facturas factura)
    {
        var resultado = new Resultado();
        resultado.Exitoso = true;

            if (factura == null)
            {
                resultado.Mensaje = "Agregue una factura para poder salvar";
                resultado.Exitoso = false;

                return resultado;
            }
        
            if (factura.Id != 0 && factura.Activo == true)
            {
                resultado.Mensaje = "La factura esta anulada ya fue emitida y no se pueden realizar cambios en ella";
                resultado.Exitoso = false;

                }

            if (factura.Activo == false)
            {
                resultado.Mensaje = "La factura esta anulada y no se pueden realizar cambios en ella";
                resultado.Exitoso = false;

                }
        
            if (factura.ClienteId == 0)
            {
                resultado.Mensaje = "Seleccione un cliente";
                resultado.Exitoso = false;
                
            }

            if (factura.FacturaDetalle.Count == 0)
            {
                resultado.Mensaje = "Agregue productos a la factura";
                resultado.Exitoso = false;
                
            }

            foreach (var detalle in factura.FacturaDetalle)
            {
                if (detalle.ProductoId == 0)
                { 
                resultado.Mensaje = "Seleccione productos validos";
                resultado.Exitoso = false;

               }
                
            }


            return resultado;
         }

        public void CalcularFactura(Facturas factura)
        {
            if (factura != null)
            {
                double subtotal = 0;


                foreach (var detalle in factura.FacturaDetalle)
                    {
                    var ingresos = _contexto.ingresos.Find(detalle.ProductoId);
                    if (ingresos != null)

                    {
                        detalle.Precio = ingresos.Precio;
                        detalle.Total = detalle.Cantidad * ingresos.Precio;

                        subtotal += detalle.Total;
                                                   
                      }

                    }

                factura.Subtotal = subtotal;
                factura.Impuesto = subtotal * 0.15;
                factura.Total = subtotal + factura.Impuesto;
               }
        }
        public bool AnularFactura(int id)
        {
            foreach (var factura in ListaFacturas)
            {
                if (factura.Id == id)
                {
                    factura.Activo = false;

                    CalcularExistencia(factura);

                    _contexto.SaveChanges();
                    return true;
                }
            }
            return false;
        }

    }
public class Facturas
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }
    public BindingList<FacturaDetalle> FacturaDetalle { get; set; }
    public double Subtotal { get; set; }
    public double Impuesto { get; set; }
    public double Total { get; set; }
    public bool Activo { get; set; }
       

        public Facturas()
    {
        Fecha = DateTime.Now;
        FacturaDetalle = new BindingList<FacturaDetalle>();
        Activo = true;
    }

  }
   public class FacturaDetalle
{
    public int Id { get; set; }
    public int ProductoId { get; set; }
    public Ingreso Ingreso { get; set; }
    public int Cantidad { get; set; }
    public double Precio { get; set; }
    public double Total { get; set; }
    

        public FacturaDetalle()
    {
        Cantidad = 1;
        
    }
        
  }
 
}

