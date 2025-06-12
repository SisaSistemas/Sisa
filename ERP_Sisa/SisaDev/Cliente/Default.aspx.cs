using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Cliente
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLoginCliente_Click(object sender, EventArgs e)
        {
            try
            {
                using (var DataControl = new SisaEntitie())
                {
                    //var Usuario = DataControl.sp_Login(UserName.Text.Trim(), Password.Text.Trim()).FirstOrDefault();
                    var Usuario = DataControl.tblClienteContacto.FirstOrDefault(u => u.Usuario == UserName.Text && u.Clave == Password.Text.Trim());
                    if (Usuario != null)
                    {
                        if (Usuario.Estatus == false)
                        {
                            FailureText.Text = "Usuario inactivo, contácta administrador.";
                            ErrorMessage.Visible = true;
                        }
                        else
                        {
                            var RolesUsuarios = DataControl.tblRolesContactos.FirstOrDefault(r => r.IdContacto == Usuario.idContacto);
                            HttpContext.Current.Session["RolesUsuarioClienteLogueado"] = RolesUsuarios;
                            HttpContext.Current.Session["UsuarioClienteLogueado"] = Usuario;
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
            catch (Exception ex)
            {
                FailureText.Text = "Error al conectar con servidor servidor.\n" + ex.Message + ".\nContácta el administrador de sistema.";
                ErrorMessage.Visible = true;
            }
        }
    }
}