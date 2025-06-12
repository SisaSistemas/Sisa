using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Cliente
{
    public partial class Inicio : System.Web.UI.Page
    {
        public static tblClienteContacto usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = HttpContext.Current.Session["UsuarioClienteLogueado"] as tblClienteContacto;
            if (usuario != null)
            {

            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}