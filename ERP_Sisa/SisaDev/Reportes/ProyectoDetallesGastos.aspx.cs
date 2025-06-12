using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Reportes
{
    public partial class ProyectoDetallesGastos : System.Web.UI.Page
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
                    using (var DataControl = new SisaEntitie())
                    {
                        var a = DataControl.sp_ReporteProyectosGastos();
                    }

                    ReportViewer1.LocalReport.DisplayName = "Reporte_DetalleGastos";
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