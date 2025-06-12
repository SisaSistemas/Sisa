using Microsoft.Reporting.WebForms;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Compras
{
    public partial class ReporteRFQ : System.Web.UI.Page
    {
        public static tblUsuarios usuario;
        public static tblRolesUsuarios rolesUsuarios;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            if (usuario != null)
            {
                //txtNombreRFQ.Text = Request.QueryString["Nombre"].ToString();
                txtIdRFQ.Text = Request.QueryString["IdRFQ"].ToString();
                ReportViewer1.LocalReport.DisplayName = txtNombreRFQ.Text;

                //ReportParameter[] param = new ReportParameter[1]; 
                //param[0] = new ReportParameter("IdRfq", txtIdRFQ.Text, false); 
                //ReportViewer1.LocalReport.SetParameters(param);
                //ReportViewer1.LocalReport.Refresh();
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}