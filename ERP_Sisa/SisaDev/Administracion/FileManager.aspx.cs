using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaAdmin
{
    public partial class FileManager: System.Web.UI.Page
    {
        public static tblUsuarios usuario;
        public static tblRolesUsuarios rolesUsuarios;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            if (usuario != null)
            {
                rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
                if(rolesUsuarios.Tipo != "ROOT" || rolesUsuarios.Tipo != "ADMINISTRACION")
                {
                    a1.Visible = false;
                    a2.Visible = false;
                    a3.Visible = false;
                    a4.Visible = false;
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}