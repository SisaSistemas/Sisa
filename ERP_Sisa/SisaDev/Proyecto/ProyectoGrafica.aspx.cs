using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Proyecto
{
    public partial class ProyectoGrafica : System.Web.UI.Page
    {
        public static tblUsuarios usuario;
        public static tblRolesUsuarios rolesUsuarios;
        public static string idProyecto = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            if (usuario != null)
            {
                rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
                idProyecto = this.Request.QueryString["id"];
                idProyectoDetalle.Value = idProyecto;
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                {
                    tblProyectos tblProyectos = sisaEntitie.tblProyectos.FirstOrDefault<tblProyectos>((Expression<Func<tblProyectos, bool>>)(p => p.IdProyecto.ToString() == idProyecto));
                    lblProyectoTarea.InnerText = tblProyectos.FolioProyecto + " " + tblProyectos.NombreProyecto + " Descripción: " + tblProyectos.Descripcion;
                    this.lblFolio.InnerText = tblProyectos.NombreProyecto;
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}