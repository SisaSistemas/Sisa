using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Reportes
{

    public partial class frmRptViaticos : System.Web.UI.Page
    {

        static tblUsuarios usuario;
        static tblRolesUsuarios rolesUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            if (usuario != null)
            {
                txtIdViaticos.Text = Request.QueryString["IdViaticos"].ToString();
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}