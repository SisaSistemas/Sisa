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

namespace SisaDev.Ventas
{
    public partial class frmSolicitudesCotizaciones : System.Web.UI.Page
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
        public static string ObtieneSolicitudesCotizaciones()
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                var cotizaciones = (from a in DataControl.tblSolicitudCotizacion_CCM
                                    orderby a.Folio ascending
                                    select a);
                retorno = JsonConvert.SerializeObject(cotizaciones);
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
                            string a = AppDomain.CurrentDomain.BaseDirectory + "Proyecto\\docs\\" + docu.FileName;
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
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
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

        [WebMethod]
        public static string GuardarFecha(string IdSolicitudCotizacion, string Fecha)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            //if (rolesUsuarios.OCEliminar == true || rolesUsuarios.Tipo == "ROOT")
            //{
            using (var DataControl = new SisaEntitie())
            {

                tblSolicitudCotizacion_CCM entity = DataControl.tblSolicitudCotizacion_CCM.FirstOrDefault<tblSolicitudCotizacion_CCM>((v => v.idSolicitudCotizacion.ToString() == IdSolicitudCotizacion));
                if (entity != null)
                {
                    entity.FechaEntrega = DateTime.Parse(Fecha);
                    entity.IdUsuarioPM = usuario.IdUsuario;
                    entity.FechaActualizaEntrega = DateTime.Now;
                    DataControl.SaveChanges();
                    retorno = "Fecha Actualizada.";
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

        [WebMethod]
        public static string GuardarTipoCotizacion(string IdSolicitudCotizacion, string Tipo)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            //if (rolesUsuarios.OCEliminar == true || rolesUsuarios.Tipo == "ROOT")
            //{
            using (var DataControl = new SisaEntitie())
            {
                Guid id = Guid.Parse(IdSolicitudCotizacion);

                tblSolicitudCotizacion_CCM entity = DataControl.tblSolicitudCotizacion_CCM.FirstOrDefault<tblSolicitudCotizacion_CCM>((v => v.idSolicitudCotizacion == id));
                if (entity != null)
                {
                    entity.TipoCotizacion = Tipo;
                    entity.Estatus = 1;
                    DataControl.SaveChanges();
                    retorno = "Tipo Actualizada.";
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