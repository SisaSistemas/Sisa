using SisaDev.Models;
using SisaDev.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev
{
    public partial class RecuperarClave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            using (var DataControl = new SisaEntitie())
            {
                var Usuario = DataControl.tblUsuarios.FirstOrDefault(u => u.Usuario == txtUsuario.Text.Trim());
                if(Usuario != null) 
                {
                    string code = Proceso.GeneraCodigoRecuperacion();
                    tblRecuperaciones r = new tblRecuperaciones
                    {
                        fecha = DateTime.Now,
                        Usuario = txtUsuario.Text.Trim(),
                        Estatus = true,
                        Codigo = code,
                        idUsuario = Usuario.IdUsuario,
                        Correo = Usuario.Correo
                    };
                    DataControl.tblRecuperaciones.Add(r);
                    DataControl.SaveChanges();

                   

                    if (Proceso.EnviarCorreo(Usuario.Correo, code) == true)
                    {
                        CorrectText.Text = "Código enviado.";
                        CorrectMessage.Visible = true;
                    }
                    else
                    {
                        //var UsuarioRecupera = DataControl.tblRecuperaciones.FirstOrDefault(u => u.idUsuario == Usuario.IdUsuario);
                        //UsuarioRecupera.Estatus = false;
                        //DataControl.SaveChanges();
                        FailureText.Text = "Problema al enviar correo, intenta de nuevo.";
                        ErrorMessage.Visible = true;
                    }
                }
                else
                {
                    FailureText.Text = "Usuario inexistente.";
                    ErrorMessage.Visible = true;
                }
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string GuardarClaveNueva(string pCodigo, string pClaveNueva)
        {
            string retorno = "Se ha actualizado información.";
            using (var DataControl = new SisaEntitie())
            {
                var BuscaID = DataControl.tblRecuperaciones.FirstOrDefault(r => r.Codigo == pCodigo.Trim() && r.Estatus == true);
                if(BuscaID != null)
                {
                    var Usuario = DataControl.tblUsuarios.FirstOrDefault(r => r.IdUsuario == BuscaID.idUsuario);
                    Usuario.Contrasena = pClaveNueva.Trim();
                    BuscaID.Estatus = false;
                    DataControl.SaveChanges();
                }
                else
                {
                    retorno = "Código inexistente o ya caduco.";
                }
            }
            return retorno;
        }
    }
}