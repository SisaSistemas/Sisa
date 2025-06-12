using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Administracion
{
    public partial class Boletines : System.Web.UI.Page
    {
        public static tblUsuarios usuario;
        public static tblRolesUsuarios rolesUsuarios;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            if (usuario != null)
            {
                rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        [WebMethod]
        public static string ObtenerBoletin(string pid)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var CC = DataControl.tblBoletin.Select(s => s);
                    retorno = JsonConvert.SerializeObject(CC);
                }
            }
            else
            {
                retorno = "No tienes permiso,";
            }


            return retorno;
        }

        [WebMethod]
        public static string CargarDocumentos(string idBoletin, string Opcion)
        {
            string retorno = string.Empty;
            if (Opcion == "PDF")
            {
                try
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        var File = (from a in DataControl.tblBoletin
                                    where a.idBoletin.ToString() == idBoletin
                                    select new { a.idBoletin, a.PDF } );
                        retorno = JsonConvert.SerializeObject(File);
                    }
                }
                catch (Exception e)
                {
                    retorno = e.ToString();
                }
            }
            else
            {
                try
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        var File = (from a in DataControl.tblBoletin
                                    where a.idBoletin.ToString() == idBoletin
                                    select new { a.idBoletin, a.Imagen });
                        retorno = JsonConvert.SerializeObject(File);
                    }
                }
                catch (Exception e)
                {
                    retorno = e.ToString();
                }
            }
            
            return retorno;
        }

        [WebMethod]
        public static string GuardarDocumentos(string TipoDoc, string idBoletin, string FileName, string File)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                try
                {

                    using (var DataControl = new SisaEntitie())
                    {
                        int id = int.Parse(idBoletin);

                        var Proy = DataControl.tblBoletin.FirstOrDefault(p => p.idBoletin == id);
                        if (Proy != null)
                        {
                            if (TipoDoc.Trim() == "IMAGEN")
                            {
                                Proy.Imagen = File;
                                Proy.NombreImagen = FileName;
                            }
                            else if (TipoDoc.Trim() == "PDF")
                            {
                                Proy.PDF = File;
                                Proy.NombrePDF = FileName;
                                if (!string.IsNullOrEmpty(File) && !string.IsNullOrEmpty(FileName))
                                {
                                    string[] completo64 = File.Split(',');
                                    string a = AppDomain.CurrentDomain.BaseDirectory + "docsboletines\\" + FileName;
                                    using (FileStream Writer = new System.IO.FileStream(a, FileMode.Create, FileAccess.Write))
                                    {
                                        Writer.Write(Convert.FromBase64String(completo64[1]), 0, Convert.FromBase64String(completo64[1]).Length);
                                    }
                                }
                            }
                            //Proy.Usuario = usuario.NombreCompleto;
                            DataControl.SaveChanges();
                            retorno = "Archivo guardado";
                        }
                        else
                        {
                            retorno = "Ocurrio un error al obtener información de proyecto, recarga la página e intenta de nuevo.";
                        }

                    }
                }
                catch (Exception e)
                {
                    retorno = e.ToString();
                }
            }
            else
            {
                retorno = "No tienes permiso de edición.";
            }
            return retorno;
        }

        [WebMethod]
        public static string NuevoBoletin(string texto)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                try
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        tblBoletin add = new tblBoletin
                        {
                            Texto = texto,
                            Usuario = usuario.NombreCompleto,
                            Fecha = DateTime.Now,
                            Imagen = "",
                            NombreImagen = "",
                            PDF = "",
                            NombrePDF = ""

                        };
                        DataControl.tblBoletin.Add(add);
                        DataControl.SaveChanges();
                        
                        retorno = "Boletin creado, favor de agregar archivos.";
                    }
                }
                catch (Exception e)
                {
                    retorno = e.ToString();
                }
            }
            else
            {
                retorno = "No tienes permiso.";
            }            

            return retorno;
        }

        [WebMethod]
        public static string EliminarBoletin(string pid)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var BolExiste = DataControl.tblBoletin.FirstOrDefault(s => s.idBoletin.ToString() == pid);
                    if (BolExiste != null)
                    {
                        DataControl.tblBoletin.Remove(BolExiste);
                        if (DataControl.SaveChanges() > 0)
                        {
                            retorno = "Informacion eliminada.";
                        }
                        else
                        {
                            retorno = "Ocurrio un problema al eliminar información.";
                        }
                    }
                    else
                    {
                        retorno = "Ocurrio un problema al obtener información seleccionada.";
                    }
                }
            }
            else
            {
                retorno = "No tienes permiso de eliminar información.";
            }

            return retorno;
        }

        [WebMethod]
        public static string EliminarImagenBoletin(string idBoletin)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var BolExiste = DataControl.tblBoletin.FirstOrDefault(s => s.idBoletin.ToString() == idBoletin);
                    if (BolExiste != null)
                    {
                        BolExiste.NombreImagen = "";
                        BolExiste.Imagen = "";
                        if (DataControl.SaveChanges() > 0)
                        {
                            retorno = "Informacion eliminada.";
                        }
                        else
                        {
                            retorno = "Ocurrio un problema al eliminar información.";
                        }
                    }
                    else
                    {
                        retorno = "Ocurrio un problema al obtener información seleccionada.";
                    }
                }
            }
            else
            {
                retorno = "No tienes permiso de eliminar información.";
            }

            return retorno;
        }

        [WebMethod]
        public static string EliminarDocumentoBoletin(string idBoletin)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var BolExiste = DataControl.tblBoletin.FirstOrDefault(s => s.idBoletin.ToString() == idBoletin);
                    if (BolExiste != null)
                    {
                        BolExiste.NombrePDF = "";
                        BolExiste.PDF = "";
                        if (DataControl.SaveChanges() > 0)
                        {
                            retorno = "Informacion eliminada.";
                        }
                        else
                        {
                            retorno = "Ocurrio un problema al eliminar información.";
                        }
                    }
                    else
                    {
                        retorno = "Ocurrio un problema al obtener información seleccionada.";
                    }
                }
            }
            else
            {
                retorno = "No tienes permiso de eliminar información.";
            }

            return retorno;
        }
    }


}