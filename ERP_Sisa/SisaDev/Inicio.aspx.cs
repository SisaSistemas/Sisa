using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using SisaDev.Models;
namespace SisaDev
{
    public partial class Inicio : System.Web.UI.Page
    {
        static tblUsuarios usuario;
        static tblRolesUsuarios rolesUsuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            if (usuario != null)
            {
                rolesUsuario = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string ObtenerFoto(int a)
        {
            return usuario.Foto;
        }


        [WebMethod]
        public static string ObtenerBoletin(string pid)
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                var CC = DataControl.tblBoletin.Select(s => s);
                retorno = JsonConvert.SerializeObject(CC);
            }
            return retorno;
        }
    }
}