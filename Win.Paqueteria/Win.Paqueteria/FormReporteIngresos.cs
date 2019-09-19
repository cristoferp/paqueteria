using BL.Entregas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.Paqueteria
{
    public partial class FormReporteIngresos : Form
    {
        public FormReporteIngresos()
        {
            InitializeComponent();

            var _ingresosBL = new IngresosBL();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = _ingresosBL.ObtenerIngresos();


            var reporte = new ReporteIngresos();
            reporte.SetDataSource(bindingSource);


            crystalReportViewer1.ReportSource = reporte;
            crystalReportViewer1.RefreshReport();
        }
    }
}
