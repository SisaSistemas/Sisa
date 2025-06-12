using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Cliente
{
    public partial class ReporteSolicitudCotizacion : System.Web.UI.Page
    {
        public static tblClienteContacto usuario;
        public static tblRolesContactos rolesContactos;

        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = HttpContext.Current.Session["UsuarioClienteLogueado"] as tblClienteContacto;
            if (usuario != null)
            {
                txtFolioSolicitud.Text = Request.QueryString["Folio"].ToString();
                txtIdSolicitudCotizacion.Text = Request.QueryString["IdSolicitudCotizacion"].ToString();
                ReportViewer1.LocalReport.DisplayName = txtFolioSolicitud.Text;

            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}