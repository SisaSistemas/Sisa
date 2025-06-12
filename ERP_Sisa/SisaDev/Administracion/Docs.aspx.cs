using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Administracion
{
    public partial class Docs : System.Web.UI.Page
    {
        public static tblUsuarios usuario;
        public static tblRolesUsuarios rolesUsuarios;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            if (usuario != null)
            {
                rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
                if (rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "ADMINISTRACION")
                {
                    //a1.Visible = true;
                    a2.Visible = true;
                    //a3.Visible = true;
                    a4.Visible = true;
                    upload.Visible = true;
                    newfolder.Visible = true;
                    browse.Visible = true;
                    filepath.Visible = true;
                }
                else
                {
                    
                    //a1.Visible = false;
                    a2.Visible = false;
                    //a3.Visible = false;
                    a4.Visible = false;
                    upload.Visible = false;
                    newfolder.Visible = false;
                    browse.Visible = false;
                    filepath.Visible = false;
                    itemOptions.Visible = false;
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        [WebMethod]
        public string Permisos(string pid)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                //a1.Visible = true;
                a2.Visible = true;
                //a3.Visible = true;
                //a4.Visible = true;
                upload.Visible = true;
                newfolder.Visible = true;
                browse.Visible = true;
                filepath.Visible = true;
            }
            else
            {

                //a1.Visible = false;
                a2.Visible = false;
                //a3.Visible = false;
                //a4.Visible = false;
                upload.Visible = false;
                newfolder.Visible = false;
                browse.Visible = false;
                filepath.Visible = false;
            }
            retorno = "";
            return retorno;

        }
    }
}