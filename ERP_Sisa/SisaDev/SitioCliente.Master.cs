using SisaDev.Control;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev
{
    public partial class SitioCliente : System.Web.UI.MasterPage
    {
        public static tblClienteContacto usuario;
        public static tblRolesContactos rolesContactos;

        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = HttpContext.Current.Session["UsuarioClienteLogueado"] as tblClienteContacto;
            rolesContactos = HttpContext.Current.Session["RolesUsuarioClienteLogueado"] as tblRolesContactos;
            //byte[] imagen = Encoding.ASCII.GetBytes(usuario.Foto);
            //string PROFILE_PIC = Convert.ToBase64String(imagen);
            //fotoPerfil.ImageUrl = String.Format("data:image/jpg;base64,{0}", PROFILE_PIC);
            Proceso.contactoGlobal = usuario;
            Proceso.rolesContactosGlobal = rolesContactos;
        }
    }
}