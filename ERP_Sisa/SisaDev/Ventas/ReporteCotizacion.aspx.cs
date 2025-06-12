using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Ventas
{
    public partial class ReporteCotizacion : System.Web.UI.Page
    {
        public static tblUsuarios usuario;
        public static tblRolesUsuarios rolesUsuarios;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            if (usuario != null)
            {
                txtIdCotizacion.Text = Request.QueryString["IdCotizacion"].ToString();
                string codigo = string.Empty;
                using (var DataControl = new SisaEntitie())
                {
                    var Cotizacion=DataControl.tblCotizaciones.FirstOrDefault(s => s.IdCotizaciones.ToString() == txtIdCotizacion.Text);                    
                    ReportViewer1.LocalReport.DisplayName = Cotizacion.NoCotizaciones;
                }
                
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }

        }
    }
}