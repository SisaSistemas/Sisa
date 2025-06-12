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

namespace SisaDev.Cliente
{
    public partial class frmSolicitudesCotizaciones : System.Web.UI.Page
    {
        public static tblClienteContacto usuario;
        public static tblRolesContactos rolesContactos;

        protected void Page_Load(object sender, EventArgs e)
        {

            usuario = HttpContext.Current.Session["UsuarioClienteLogueado"] as tblClienteContacto;
            if (usuario != null)
            {
                rolesContactos = HttpContext.Current.Session["RolesUsuarioClienteLogueado"] as tblRolesContactos;
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        [WebMethod]
        public static string ObtieneSolicitudesCotizaciones()
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioClienteLogueado"] as tblClienteContacto;
            rolesContactos = HttpContext.Current.Session["RolesUsuarioClienteLogueado"] as tblRolesContactos;

            if (rolesContactos.Tipo == "COMPRAS")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var cotizaciones = (from a in DataControl.tblSolicitudCotizacion_CCM
                                        orderby a.Folio ascending
                                        select a);
                    retorno = JsonConvert.SerializeObject(cotizaciones);
                }
            }
            else
            {
                using (var DataControl = new SisaEntitie())
                {
                    var cotizaciones = (from a in DataControl.tblSolicitudCotizacion_CCM
                                        where a.Requisitor == usuario.idContacto
                                        orderby a.Folio ascending
                                        select a);
                    retorno = JsonConvert.SerializeObject(cotizaciones);
                }
            }
            
            
            return retorno;
        }

        [WebMethod]
        public static string ObtieneCotizaciones(string idSolicitud)
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                Guid id = Guid.Parse(idSolicitud);
                var cotizaciones = DataControl.tblCotizaciones.Where(s => s.idRequisicion == id);
                retorno = JsonConvert.SerializeObject(cotizaciones);
                //List<tblCotizaciones> cotizaciones = (from a in DataControl.tblCotizaciones
                //                    where id.Equals(a.idRequisicion)
                //                    select a).ToList();
                //retorno = JsonConvert.SerializeObject(cotizaciones);
            }
            return retorno;
        }

        [WebMethod]
        public static string GuardarDocumentos(string IdSolicitudCotizacion, string FileName, string fileSize, string filetype, string fileExtension, string Archivo)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioClienteLogueado"] as tblClienteContacto;
            //rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            try
            {

                using (var DataControl = new SisaEntitie())
                {
                    //int a = Convert.ToInt32(Opcion);
                    Guid idSolicitud = Guid.Parse(IdSolicitudCotizacion);
                    tblArchivosIngenieria_CCM add = new tblArchivosIngenieria_CCM
                    {
                        idArchivosIngenieria_CCM = Guid.NewGuid(),
                        idSolicitudCotizacion = idSolicitud,
                        File = Archivo,
                        FileName = FileName,
                        FileExtension = fileExtension,
                        FileSize = fileSize,
                        FileContentType = filetype,
                        Fecha = DateTime.Now

                    };
                    DataControl.tblArchivosIngenieria_CCM.Add(add);
                    DataControl.SaveChanges();
                    retorno = "Archivo guardado";
                }
            }
            catch (Exception e)
            {
                retorno = e.ToString();
            }

            return retorno;
        }

        [WebMethod]
        public static string CargarDocumentos(string IdSolicitudCotizacion, string Opcion)
        {
            string retorno = string.Empty;
            try
            {
                //int a = Convert.ToInt32(Opcion);
                Guid idSolicitud = Guid.Parse(IdSolicitudCotizacion);
                using (var DataControl = new SisaEntitie())
                {
                    var cotizaciones = (from a in DataControl.tblArchivosIngenieria_CCM
                                        where a.idSolicitudCotizacion == idSolicitud
                                        orderby a.Fecha ascending
                                        select a);
                    retorno = JsonConvert.SerializeObject(cotizaciones);
                }


            }
            catch (Exception e)
            {
                retorno = e.ToString();
            }
            return retorno;
        }

        [WebMethod]
        public static string VerPdf(string IdSolicitudCotizacion)
        {
            string retorno = string.Empty;
            try
            {
                using (var DataControl = new SisaEntitie())
                {
                    var docu = DataControl.tblArchivosIngenieria_CCM.FirstOrDefault(a => a.idArchivosIngenieria_CCM.ToString() == IdSolicitudCotizacion);
                    if (docu != null)
                    {
                        if (!string.IsNullOrEmpty(docu.FileName) && !string.IsNullOrEmpty(docu.File))
                        {
                            string[] completo64 = docu.File.Split(',');
                            //var originalString = ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(completo64[1]));
                            string a = AppDomain.CurrentDomain.BaseDirectory + "Cliente\\docs\\" + docu.FileName;
                            using (FileStream Writer = new System.IO.FileStream(a, FileMode.Create, FileAccess.Write))
                            {
                                Writer.Write(Convert.FromBase64String(completo64[1]), 0, Convert.FromBase64String(completo64[1]).Length);
                            }
                            //File.WriteAllBytes(a + p.Nombre, Convert.FromBase64String(p.Archivo));
                        }
                        retorno = JsonConvert.SerializeObject(docu);
                    }
                }
            }
            catch (Exception e)
            {
                retorno = e.ToString();
            }
            retorno = retorno.Replace("FileName", "NombreArchivo");
            return retorno;
        }

        [WebMethod]
        public static string EliminarDocumento(string IdDocumento)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioClienteLogueado"] as tblClienteContacto;
            //if (rolesUsuarios.OCEliminar == true || rolesUsuarios.Tipo == "ROOT")
            //{
                using (var DataControl = new SisaEntitie())
                {

                    tblArchivosIngenieria_CCM entity = DataControl.tblArchivosIngenieria_CCM.FirstOrDefault<tblArchivosIngenieria_CCM>((v => v.idArchivosIngenieria_CCM.ToString() == IdDocumento));
                    if (entity != null)
                    {
                        DataControl.tblArchivosIngenieria_CCM.Remove(entity);
                        DataControl.SaveChanges();
                        retorno = "Documento eliminado.";
                    }
                    else
                    {
                        retorno = "Error";
                    }



                }
            //}
            //else
            //{
            //    retorno = "No tienes permiso de eliminar documento.";
            //}

            return retorno;
        }
    }
}