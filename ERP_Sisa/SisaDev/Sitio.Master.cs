using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SisaDev.Control;
using SisaDev.Models;

namespace SisaDev
{
    public partial class Sitio : System.Web.UI.MasterPage
    {
        public static tblUsuarios usuario;
        public static tblRolesUsuarios rolesUsuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuario = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            //byte[] imagen = Encoding.ASCII.GetBytes(usuario.Foto);
            //string PROFILE_PIC = Convert.ToBase64String(imagen);
            //fotoPerfil.ImageUrl = String.Format("data:image/jpg;base64,{0}", PROFILE_PIC);
            Proceso.usuarioGlobal = usuario;
            Proceso.rolesUsuariosGlobal = rolesUsuario;
        }
        
    }
}