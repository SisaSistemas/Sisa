using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev
{
    public partial class SitioProveedores : System.Web.UI.MasterPage
    {
        public static tblProveedores usuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = HttpContext.Current.Session["UsuarioProveedorLogueado"] as tblProveedores;
        }
    }
}