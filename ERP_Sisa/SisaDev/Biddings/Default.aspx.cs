using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Biddings
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLoginProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                using (var DataControl = new SisaEntitie())
                {
                    //var Usuario = DataControl.sp_Login(UserName.Text.Trim(), Password.Text.Trim()).FirstOrDefault();
                    var Usuario = DataControl.tblProveedores.FirstOrDefault(u => u.Usuario == UserName.Text && u.Contrasena == Password.Text.Trim());
                    if (Usuario != null)
                    {
                        if (Usuario.Activo == 0)
                        {
                            FailureText.Text = "Usuario inactivo, contácta administrador.";
                            ErrorMessage.Visible = true;
                        }
                        else
                        {
                            HttpContext.Current.Session["UsuarioProveedorLogueado"] = Usuario;
                            Response.Redirect("Biddings.aspx", false);
                        }
                    }
                    else
                    {
                        FailureText.Text = "Usuario o clave incorrectas.";
                        ErrorMessage.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                FailureText.Text = "Error al conectar con servidor servidor.\n" + ex.Message + ".\nContácta el administrador de sistema.";
                ErrorMessage.Visible = true;
            }
        }
    }
}