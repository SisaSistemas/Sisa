using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Compras
{
    public partial class ReporteOrdenCompra : System.Web.UI.Page
    {
        public static tblUsuarios usuario;
        public static tblRolesUsuarios rolesUsuarios;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            if (usuario != null)
            {
                txtNombreOrden.Text = Request.QueryString["NombreOrden"].ToString();
                txtIdOrdenCompra.Text = Request.QueryString["IdOrdenCompra"].ToString();
                ReportViewer1.LocalReport.DisplayName = txtNombreOrden.Text;

            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
            
        }
    }
}