using SisaDev.Models;
using System;
using System.Web;

namespace SisaDev.Reportes
{
    public partial class AdeudoProveedores : System.Web.UI.Page
    {
        static tblUsuarios usuario;
        static tblRolesUsuarios rolesUsuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            if (usuario != null)
            {
                rolesUsuario = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
                if (rolesUsuario.Reportes == true || rolesUsuario.Tipo == "ROOT" || rolesUsuario.Tipo == "ADMINISTRACION" || rolesUsuario.Tipo == "GERENCIAL")
                {
                    ReportViewer1.LocalReport.DisplayName = "Reporte_ProveedoresPagar";
                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}