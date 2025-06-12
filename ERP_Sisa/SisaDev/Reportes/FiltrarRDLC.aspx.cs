using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Reportes
{
    public partial class FiltrarRDLC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ReportParameter prueba = new ReportParameter("Cliente", txtFiltro.Text);
            this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { prueba });
            
        }
    }
}