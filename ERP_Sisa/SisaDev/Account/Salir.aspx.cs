using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Account
{
    public partial class Salir : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.Session["UsuarioLogueado"] = null;
            HttpContext.Current.Session["RolesUsuarioLogueado"] = null;
            Response.Redirect("~/Default.aspx");
            
        }
    }
}