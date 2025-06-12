using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Account
{
    public partial class Perfil : System.Web.UI.Page
    {
        public static tblUsuarios usuario;
        public static string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            if (usuario != null)
            {
                id= usuario.IdUsuario.ToString();
                txtId.Value = usuario.IdUsuario.ToString();
                txtNombre.Value = usuario.NombreCompleto;
                txtTelefono.Value = usuario.Telefono;
                txtUsuario.Value = usuario.Usuario;
                txtCorreo.Value = usuario.Correo;
                
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string GuardarClaveNueva(string pClaveActual, string pClaveNueva)
        {
            string retorno = "";
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            
            if (usuario.Contrasena.Trim() == pClaveActual.Trim())
            {
                using (var DataControl = new SisaEntitie())
                {
                    var BuscaID = DataControl.tblUsuarios.FirstOrDefault(r => r.IdUsuario.ToString().Trim() == id.Trim());
                    if (BuscaID != null)
                    {
                        BuscaID.Contrasena = pClaveNueva.Trim();
                        if(DataControl.SaveChanges() > 0)
                        {
                            HttpContext.Current.Session["UsuarioLogueado"] = BuscaID;
                            retorno = "Se ha actualizado información.";
                        }
                        else
                        {
                            retorno = "Se perdio comunicación con el servidor.";
                        }
                    }
                    else
                    {
                        retorno = "Ocurrio un problema al actualizar información.";
                    }
                }

            }
            else
            {
                retorno = "Clave actual erronéa.";
            }           
            
            return retorno;
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string GuardarDatosGenerales(string pFoto, string pTelefono, string pCorreo)
        {
            string retorno = "";
            try
            {
                
                using (var DataControl = new SisaEntitie())
                {
                    var BuscaID = DataControl.tblUsuarios.FirstOrDefault(r => r.IdUsuario.ToString().Trim() == id.Trim());
                    if (BuscaID != null)
                    {
                        if(pFoto != "")
                        {
                            BuscaID.Foto = pFoto;
                            
                        }                        
                        BuscaID.Telefono = pTelefono;
                        BuscaID.Correo = pCorreo;
                        int Cambios = DataControl.SaveChanges();
                        if (Cambios > 0)
                        {
                            HttpContext.Current.Session["UsuarioLogueado"] = BuscaID;
                            Sitio.usuario = BuscaID;
                            retorno = "Datos guardados.";
                        }
                        else
                        {
                            retorno = "No se hicieron cambios.";
                            
                        }
                    }
                    else
                    {
                        retorno = "Problema al guardar información, recarga la página.";
                    
                    }
                       
                }
            }
            catch(Exception ex)
            {
                retorno = "Problema de comunicación con servidor, intenta de nuevo.";
               
            }
            return retorno;
        }
    }
}