using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Cliente
{
    public partial class ProyectoTareas : System.Web.UI.Page
    {
        public static tblClienteContacto usuario;
        public static string idProyecto = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = HttpContext.Current.Session["UsuarioClienteLogueado"] as tblClienteContacto;
            if (usuario != null)
            {                
                idProyecto = Request.QueryString["id"];
                idProyectoTarea.Value = idProyecto;
                using (var DataControl = new SisaEntitie())
                {
                    //var proy = DataControl.tblProyectos.FirstOrDefault(p => p.IdProyecto.ToString() == idProyecto);
                    var proy = (from p in DataControl.tblProyectos
                                join c in DataControl.tblClienteContacto on p.IdCliente equals c.idContacto.ToString()
                                join u in DataControl.tblEmpresas on c.idEmpresa equals u.idEmpresa
                                join x in DataControl.tblUsuarios on p.IdLider equals x.IdUsuario.ToString()
                                where p.IdProyecto.ToString() == idProyecto
                                select new { 
                                    p.IdProyecto, 
                                    p.FolioProyecto, 
                                    p.NombreProyecto, 
                                    p.Descripcion, 
                                    u.RazonSocial, 
                                    FechaIY = p.FechaInicio.Value.Year, 
                                    FechaIM = p.FechaInicio.Value.Month, 
                                    FechaID = p.FechaInicio.Value.Day, 
                                    FechaTY = p.FechaFin.Value.Year, 
                                    FechaTM = p.FechaFin.Value.Month, 
                                    FechaTD = p.FechaFin.Value.Day, 
                                    c.NombreContacto, 
                                    x.NombreCompleto 
                                }
                            );
                    var proyecto = proy.FirstOrDefault(s => s.IdProyecto.ToString() == idProyecto);
                    lblProyectoTarea.InnerText = proyecto.FolioProyecto + " " + proyecto.NombreProyecto;
                    lblFolio.InnerText = "Descripción: " + proyecto.Descripcion;
                    int a = proyecto.FechaIM;
                    lblFechas.InnerText = "Fechas: " + proyecto.FechaIY + "-" + (proyecto.FechaIM.ToString().Length == 1 ? "0" + proyecto.FechaIM.ToString() : proyecto.FechaIM.ToString()) + "-" + (proyecto.FechaID.ToString().Length == 1 ? "0" + proyecto.FechaID.ToString() : proyecto.FechaID.ToString()) + " al " + proyecto.FechaTY + "-" + (proyecto.FechaTM.ToString().Length == 1 ? "0" + proyecto.FechaTM.ToString() : proyecto.FechaTM.ToString()) + "-" + (proyecto.FechaTD.ToString().Length == 1 ? "0" + proyecto.FechaTD.ToString() : proyecto.FechaTD.ToString());
                    lblEmpresa.InnerText = "Empresa: " + proyecto.RazonSocial;
                    lblContacto.InnerText = "Contácto: " + proyecto.NombreContacto;
                    lbllider.InnerText = "Lider proyecto: " + proyecto.NombreCompleto;

                    var nombreArchivo = DataControl.sp_SelectDailyReport(idProyecto).FirstOrDefault();

                    if (nombreArchivo == null)
                    {

                    }
                    else
                    {
                        MyIframe.Attributes["src"] = @"..\Proyecto\visorDocto.aspx?Docto=" + nombreArchivo.Archivo + "&Proyecto=" + proyecto.FolioProyecto;
                    }
                    

                    //lblFolio.InnerText = proy.NombreProyecto;
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }


        [WebMethod]
        public static string CargarGrafica(string IdProyecto)
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                var Filtrado = DataControl.sp_GraficaTasks(IdProyecto);
                //Filtrado = Filtrado.Where(a => a.);
                retorno = JsonConvert.SerializeObject(Filtrado);
                //var Filtrado = (from tt in DataControl.tblProyectoTasks
                //                join u in DataControl.tblUsuarios on tt.IdUsuario equals u.IdUsuario
                //                where tt.IdProyecto.ToString() == idProyecto && tt.Estatus < 6
                //                select new { u.NombreCompleto, tt.Task.Count };


            }
            return retorno;

        }

        [WebMethod]
        public static string CargarDetalleGrafica(string Nombre, string IdProyecto)
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                var Filtrado = DataControl.sp_GraficaTasksDetalle(IdProyecto, Nombre);
                retorno = JsonConvert.SerializeObject(Filtrado);
            }
            return retorno;

        }

        [WebMethod]
        public static string CargaTareas()
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                //var Filtrado = (from tt in DataControl.tblProyectoTasks
                //                join u in DataControl.tblUsuarios on tt.IdUsuario equals u.IdUsuario
                //                where tt.IdProyecto.ToString() == idProyecto && tt.Estatus < 6
                //                select new { 
                //                    tt.IdTask, 
                //                    tt.Task, 
                //                    u.NombreCompleto, 
                //                    tt.FechaInicio, 
                //                    tt.FechaFin, 
                //                    Dias = SqlFunctions.DateDiff("DAY", tt.FechaInicio, tt.FechaFin), 
                //                    DiasTranscurridos = SqlFunctions.DateDiff("DAY", tt.FechaInicio, DateTime.Now), 
                //                    tt.Estatus, 
                //                    tt.Comentarios, 
                //                    tt.Porcentaje 
                //                }
                //    );
                var Filtrado = DataControl.sp_CargaTareas(idProyecto);
                retorno = JsonConvert.SerializeObject(Filtrado.OrderBy(a => a.Task));
            }
            return retorno;

        }

        [WebMethod]
        public static string ObtenerImagenTarea(string pid)
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                var Filtrado = DataControl.tblDocProyectos.FirstOrDefault(a => a.IdProyecto.ToString() == pid);
                //var Filtrado = DataControl.tblProyectoTaskImagen.FirstOrDefault(a => a.IdTask.ToString() == pid);
                if (Filtrado != null)
                {
                    retorno = JsonConvert.SerializeObject(Filtrado);
                }
                else
                {
                    retorno = "";
                }

            }
            return retorno;

        }

        [WebMethod]
        public static string CargarComentariosTareas(string pid)
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                var Filtrado = (from a in DataControl.tblProyectoTasksComentarios
                                join b in DataControl.tblUsuarios on a.IdUsuario equals b.IdUsuario
                                where a.IdTask.ToString() == pid
                                select new { a.IdTaskComentario, a.Comentario, b.NombreCompleto, a.Fecha });
                if (Filtrado != null)
                {
                    retorno = JsonConvert.SerializeObject(Filtrado);
                }
                else
                {
                    retorno = "";
                }

            }
            return retorno;

        }

        [WebMethod]
        public static string CargarDocumentos(string IdDocumento, string IdProyecto, string FileName, string File, string IdTask, string Opcion)
        {
            string retorno = string.Empty;
            try
            {
                int a = Convert.ToInt32(Opcion);
                using (var DataControl = new SisaEntitie())
                {
                    var Filtrado = DataControl.sp_InsertDeleteDocumentosProyecto(IdDocumento, IdProyecto, FileName, File, IdTask, a);
                    retorno = JsonConvert.SerializeObject(Filtrado);
                }


            }
            catch (Exception e)
            {
                retorno = e.ToString();
            }
            return retorno;
        }

        [WebMethod]
        public static string VerPdf(string id)
        {
            string retorno = string.Empty;
            try
            {
                using (var DataControl = new SisaEntitie())
                {
                    var docu = DataControl.tblDocProyectos.FirstOrDefault(a => a.IdDocumento.ToString() == id);
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
                    else
                    {
                        var docs = DataControl.tblProyectoTaskImagen.FirstOrDefault(a => a.IdTaskImagen.ToString() == id);
                        if (docs != null)
                        {
                            if (!string.IsNullOrEmpty(docs.FileName) && !string.IsNullOrEmpty(docs.Imagen))
                            {
                                string[] archivoCompleto = docs.Imagen.Split(',');
                                string a = AppDomain.CurrentDomain.BaseDirectory + "Cliente\\docs\\" + docs.FileName;
                                using (FileStream Writer = new FileStream(a, FileMode.Create, FileAccess.Write))
                                {
                                    Writer.Write(Convert.FromBase64String(archivoCompleto[1]), 0, Convert.FromBase64String(archivoCompleto[1]).Length);
                                }
                            }
                            retorno = JsonConvert.SerializeObject(docs);
                        }
                        else
                        {
                            retorno = "No se encontro archivo.";
                        }
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
        public static string ObtenerCarrusel(string IdDocumento, string IdProyecto, string FileName, string File, string IdTask, string Opcion)
        {
            //string retorno = string.Empty;
            //using (var DataControl = new SisaEntitie())
            //{
            //    var CC = DataControl.tblBoletin.Select(s => s);
            //    retorno = JsonConvert.SerializeObject(CC);
            //}
            //return retorno;

            string retorno = string.Empty;
            try
            {
                int a = Convert.ToInt32(Opcion);
                using (var DataControl = new SisaEntitie())
                {
                    var Filtrado = DataControl.sp_InsertDeleteDocumentosProyecto(IdDocumento, IdProyecto, FileName, File, IdTask, a);
                    retorno = JsonConvert.SerializeObject(Filtrado);
                }


            }
            catch (Exception e)
            {
                retorno = e.ToString();
            }
            return retorno;
        }
    }
}