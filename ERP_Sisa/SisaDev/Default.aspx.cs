using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SisaDev.Models;

namespace SisaDev
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                using (var DataControl = new SisaEntitie())
                {
                    var Usuario1 = DataControl.sp_Login(UserName.Text.Trim(), Password.Text.Trim()).FirstOrDefault();
                    
                    
                    var Usuario = DataControl.tblUsuarios.FirstOrDefault(u => u.Usuario == UserName.Text && u.Contrasena == Password.Text.Trim());
                    if (Usuario != null)
                    {
                        if(Usuario.Activo == 0)
                        {
                            FailureText.Text = "Usuario inactivo, contácta administrador.";
                            ErrorMessage.Visible = true;
                        }
                        else
                        {
                            var RolesUsuarios = DataControl.tblRolesUsuarios.FirstOrDefault(r => r.idUsuarios == Usuario.IdUsuario);
                            HttpContext.Current.Session["RolesUsuarioLogueado"] = RolesUsuarios;
                            HttpContext.Current.Session["UsuarioLogueado"] = Usuario;
                            HttpContext.Current.Session.Timeout = 360;
                            Response.Redirect("Inicio.aspx", false);
                        }                        
                    }
                    else
                    {
                        FailureText.Text = "Usuario o clave incorrectas.";
                        ErrorMessage.Visible = true;
                    }
                }
            }
            catch(Exception ex)
            {
                FailureText.Text = "Error al conectar con servidor servidor.\n" + ex.Message + ".\nContácta el administrador de sistema.";
                ErrorMessage.Visible = true;
            }
            
        }
    }
}