using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Proyecto
{
    public partial class ProyectoTareas : System.Web.UI.Page
    {
        public static tblUsuarios usuario;
        public static tblRolesUsuarios rolesUsuarios;
        public static string idProyecto = string.Empty;
        public static string folioProyecto = string.Empty;
        public static double TotalProyectado = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            if (usuario != null)
            {
                rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
                idProyecto = Request.QueryString["id"];
                idProyectoTarea.Value = idProyecto;
                using(var DataControl = new SisaEntitie())
                {
                    var proy = (from p in DataControl.tblProyectos
                                    join c in DataControl.tblClienteContacto on p.IdCliente equals c.idContacto.ToString()
                                    join u in DataControl.tblEmpresas on c.idEmpresa equals u.idEmpresa
                                    join x in DataControl.tblUsuarios on p.IdLider equals x.IdUsuario.ToString()
                                where p.IdProyecto.ToString() == idProyecto
                                    select new 
                                    { 
                                        p.IdProyecto, 
                                        p.FolioProyecto, 
                                        p.NombreProyecto, 
                                        p.Descripcion, 
                                        u.RazonSocial, 
                                        FechaIY = p.FechaInicio.Value.Year , 
                                        FechaIM = p.FechaInicio.Value.Month , 
                                        FechaID = p.FechaInicio.Value.Day, 
                                        FechaTY = p.FechaFin.Value.Year ,
                                        FechaTM = p.FechaFin.Value.Month ,
                                        FechaTD = p.FechaFin.Value.Day, 
                                        c.NombreContacto, 
                                        x.NombreCompleto,
                                        totalProyectado = p.CostoMaterialProyectado + p.CostoMEProyectado + p.CostoMOProyectado
                                    }
                                        );
                    var proyecto = proy.FirstOrDefault(s => s.IdProyecto.ToString() == idProyecto);
                    //var proy = (from p in DataControl.tblProyectos
                    //            join c in DataControl.tblClienteContacto on p.IdCliente equals c.idContacto
                    //            join e in DataControl.tblEmpresas on c.idEmpresa equals e.idEmpresa
                    //            where p.IdProyecto.ToString() == idProyecto
                    //            select new { p.FolioProyecto });
                        //DataControl.tblProyectos.FirstOrDefault(p => p.IdProyecto.ToString() == idProyecto);
                    lblProyectoTarea.InnerText = proyecto.FolioProyecto + " " + proyecto.NombreProyecto;
                    lblFolio.InnerText = "Descripción: " + proyecto.Descripcion;
                    int a = proyecto.FechaIM;
                    lblFechas.InnerText = "Fechas: " +  proyecto.FechaIY + "-" + (proyecto.FechaIM.ToString().Length == 1 ? "0" + proyecto.FechaIM.ToString() : proyecto.FechaIM.ToString()) + "-" + (proyecto.FechaID.ToString().Length == 1 ? "0" + proyecto.FechaID.ToString() : proyecto.FechaID.ToString()) + " al " + proyecto.FechaTY + "-" + (proyecto.FechaTM.ToString().Length == 1 ? "0" + proyecto.FechaTM.ToString() : proyecto.FechaTM.ToString()) + "-" + (proyecto.FechaTD.ToString().Length == 1 ? "0" + proyecto.FechaTD.ToString() : proyecto.FechaTD.ToString());
                    lblEmpresa.InnerText = "Empresa: " + proyecto.RazonSocial;
                    lblContacto.InnerText = "Contácto: " + proyecto.NombreContacto;
                    lbllider.InnerText = "Lider proyecto: " + proyecto.NombreCompleto;


                    folioProyecto = proyecto.FolioProyecto;
                    TotalProyectado = (double)proyecto.totalProyectado;

                    lblProyectado.InnerText = "Proyectado: $ " + ((double)proyecto.totalProyectado).ToString("N", CultureInfo.GetCultureInfo("en-US"));
                    var resultado = DataControl.sp_GraficaPastelDetalle(idProyecto, "TotalGastos", new Decimal?(Decimal.Parse(TotalProyectado.ToString())));
                    //lblGastado.InnerText = "Gastado: $ " + resultado.ToList().Sum(r => r.Total).ToString("0.00").Replace(',', '.');
                    lblGastado.InnerText = "Gastado: $ " + resultado.ToList().Sum(r => r.Total).ToString("N", CultureInfo.GetCultureInfo("en-US"));
                    //string fileName = "Daily_Reports.pdf";

                    var nombreArchivo = DataControl.sp_SelectDailyReport(idProyecto).FirstOrDefault();

                    if (nombreArchivo == null)
                    {

                    }
                    else
                    {
                        MyIframe.Attributes["src"] = @".\visorDocto.aspx?Docto=" + nombreArchivo.Archivo + "&Proyecto=" + proyecto.FolioProyecto;
                    }

                        
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        [WebMethod]
        public static string CargarCombos(string Opcion)
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                int op = Convert.ToInt32(Opcion);

                retorno = JsonConvert.SerializeObject(DataControl.sp_CargaCombos(op));
            }
            return retorno;

        }

        [WebMethod]
        public static string EliminarProyectosTarea(string pid)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ProyectosEditar == true || rolesUsuarios.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var CExiste = DataControl.tblProyectoTasks.FirstOrDefault(s => s.IdTask.ToString() == pid);
                    if (CExiste != null)
                    {
                        CExiste.Estatus = 6;
                        if (DataControl.SaveChanges() > 0)
                        {
                            retorno = "Tarea eliminado.";
                        }
                        else
                        {
                            retorno = "Ocurrio un problema al eliminar tarea.";
                        }
                    }

                }
            }
            else
            {
                retorno = "No tienes permiso de eliminar tarea.";
            }

            return retorno;
        }

        [WebMethod]
        public static string CargarGrafica(string Nombre, string IdProyecto)
        {
            string str = string.Empty;
            try
            {
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                {
                    str = JsonConvert.SerializeObject((object)sisaEntitie.sp_GraficaPastelDetalle(IdProyecto, Nombre, new Decimal?(Decimal.Parse(TotalProyectado.ToString()))));
                    
                }
            }
            catch (Exception ex)
            {
                str = ex.ToString();
            }
            return str;
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
        public static string CargarDetalle(string Punto, string IdProyecto)
        {
            string str = string.Empty;
            try
            {
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                    str = !(Punto == "Mano de Obra") ? (!(Punto == "Viaticos") ? (!(Punto == "Caja Chica") ? JsonConvert.SerializeObject((object)sisaEntitie.sp_CargarDetalleGrafica(Punto, IdProyecto).Distinct<sp_CargarDetalleGrafica_Result>()) : JsonConvert.SerializeObject((object)sisaEntitie.sp_CargarDetalleGraficaCajaChica(Punto, IdProyecto))) : JsonConvert.SerializeObject((object)sisaEntitie.sp_CargarDetalleGraficaViaticos(Punto, IdProyecto))) : JsonConvert.SerializeObject((object)sisaEntitie.sp_CargarDetalleGraficaMO(Punto, IdProyecto));
            }
            catch (Exception ex)
            {
                str = ex.ToString();
            }
            return str;

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
                //                    tt.Porcentaje, 
                //                    tt.FechaAlta
                //                }
                //    ) ;
                var Filtrado = DataControl.sp_CargaTareas(idProyecto);
                retorno = JsonConvert.SerializeObject(Filtrado.OrderBy(a=> a.Task));
            }
            return retorno;

        }
       
        [WebMethod]
        public static string GuardarTarea(string pid, string Tarea, string Inicio, string Fin, string Comentario, string idUsuarioAsignado)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ProyectosEditar || rolesUsuarios.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {
                    Guid id = Guid.Parse(pid);
                    Guid idu = Guid.Parse(idUsuarioAsignado);

                    tblProyectoTasks add = new tblProyectoTasks
                    {
                        IdTask = Guid.NewGuid(),
                        IdProyecto = id,
                        Task = Tarea,
                        FechaAlta = DateTime.Now,
                        Comentarios = Comentario,
                        IdUsuario = idu,
                        IdUsuarioAlta = usuario.IdUsuario,
                        IdUsuarioModificacion = usuario.IdUsuario,
                        FechaModificacion = DateTime.Now,
                        FechaFin = DateTime.Parse(Fin),
                        FechaInicio = DateTime.Parse(Inicio),
                        Estatus = 0,
                        Porcentaje = 0
                    };
                    DataControl.tblProyectoTasks.Add(add);
                    DataControl.SaveChanges();
                    if(Comentario != "")
                    {
                        tblProyectoTasksComentarios adc = new tblProyectoTasksComentarios
                        {
                            IdTask = add.IdTask,
                            Comentario = Comentario,
                            IdTaskComentario = Guid.NewGuid(),
                            Fecha = DateTime.Now,
                            IdUsuario = usuario.IdUsuario
                        };
                        DataControl.tblProyectoTasksComentarios.Add(adc);
                        DataControl.SaveChanges();
                    }                    
                    retorno = "Tarea agregada";
                }
            }
            else
            {
                retorno = "No tienes permiso de agregar tareas.";
            }
            
            return retorno;
        }

        [WebMethod]
        public static string ActualizarAvance(string pid, string Porcentaje)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ProyectosEditar == true || rolesUsuarios.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var CExiste = DataControl.tblProyectoTasks.FirstOrDefault(s => s.IdTask.ToString() == pid);
                    if (CExiste != null)
                    {
                        if(Porcentaje.Trim() == "100")
                        {
                            CExiste.Estatus = 2;
                        }
                        else
                        {
                            CExiste.Estatus = 1;
                        }
                        
                        CExiste.Porcentaje = decimal.Parse(Porcentaje);
                        if (DataControl.SaveChanges() > 0)
                        {
                            retorno = "Tarea actualizada.";
                        }
                        else
                        {
                            retorno = "Ocurrio un problema al actualizar avance tarea.";
                        }
                    }
                    else
                    {
                        retorno = "No se encontro información de la tarea seleccionada, intenta de nuevo actualizando página.";
                    }

                }
            }
            else
            {
                retorno = "No tienes permiso de agregar avance tarea.";
            }

            return retorno;
        }

        [WebMethod]
        public static string GuardarDocumentos(string IdDocumento, string IdProyecto, string FileName, string File, string Opcion)
        {
            string retorno = string.Empty;
            try
            {
                
                using (var DataControl = new SisaEntitie())
                {
                    int a = Convert.ToInt32(Opcion);
                    Guid p = Guid.Parse(IdProyecto);
                    tblDocProyectos add = new tblDocProyectos
                    {
                        IdDocumento = Guid.NewGuid(),
                        IdProyecto = p,
                        FileName = FileName,
                        File = File,
                        Fecha = DateTime.Now

                    };
                    DataControl.tblDocProyectos.Add(add);
                    DataControl.SaveChanges();
                    retorno = "Archivo guardado";
                }
            }
            catch (Exception e)
            {
                retorno =  e.ToString();
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
                retorno= e.ToString();
            }
            return retorno;
        }

        [WebMethod]
        public static string GuardarImagenTarea(string idTask, string IdProyecto, string FileName, string FileSize, string FileType, string File, string Opcion)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            try
            {
                //int a = Convert.ToInt32(Opcion);
                //Guid b = Guid.Parse(idTask);
                //Guid c = Guid.Parse(IdProyecto);
                //using (var DataControl = new SisaEntitie())
                //{
                //    tblProyectoTaskImagen add = new tblProyectoTaskImagen
                //    {
                //        IdTaskImagen = Guid.NewGuid(),
                //        IdTask = b,
                //        IdUsuario = usuario.IdUsuario,
                //        Imagen = File,
                //        FileName = FileName,
                //        Descripcion = FileName,
                //        FileExtension = "",
                //        FileContentType = FileType,
                //        FileSize = FileSize,
                //        Fecha = DateTime.Now

                //    };
                //    DataControl.tblProyectoTaskImagen.Add(add);
                //    DataControl.SaveChanges();
                //    retorno = "Archivo guardado";
                //}

                using (var DataControl = new SisaEntitie())
                {
                    int a = Convert.ToInt32(Opcion);
                    Guid p = Guid.Parse(IdProyecto);
                    Guid t = Guid.Parse(idTask);
                    tblDocProyectos add = new tblDocProyectos
                    {
                        IdDocumento = Guid.NewGuid(),
                        IdProyecto = p,
                        FileName = FileName,
                        File = File,
                        Fecha = DateTime.Now,
                        IdTask = t

                    };
                    DataControl.tblDocProyectos.Add(add);
                    DataControl.SaveChanges();
                    retorno = "Archivo guardado";
                }

                //if (!Directory.Exists(@"\\Win-s20lmo4rao9\d\Proyectos\" + folioProyecto))
                //{
                //    Directory.CreateDirectory(@"\\Win-s20lmo4rao9\d\Proyectos\" + folioProyecto);
                //}

                //if (System.IO.File.Exists(@"\\Win-s20lmo4rao9\d\Proyectos\" + folioProyecto + @"\" + FileName))
                //{
                //    System.IO.File.Delete(@"\\Win-s20lmo4rao9\d\Proyectos\" + folioProyecto + @"\" + FileName);
                //}

                if (!Directory.Exists(@"C:\SisaFiles\Proyectos\" + folioProyecto))
                {
                    Directory.CreateDirectory(@"C:\SisaFiles\Proyectos\" + folioProyecto);
                }

                if (System.IO.File.Exists(@"C:\SisaFiles\Proyectos\" + folioProyecto + @"\" + FileName))
                {
                    System.IO.File.Delete(@"C:\SisaFiles\Proyectos\" + folioProyecto + @"\" + FileName);
                }

                string[] completo64 = File.Split(',');
                //var originalString = ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(completo64[1]));
                //string archivo = @"\\Win-s20lmo4rao9\d\Proyectos\" + folioProyecto + @"\" + FileName;//AppDomain.CurrentDomain.BaseDirectory + "Ventas\\docs\\" + p.Nombre;
                string archivo = @"C:\SisaFiles\Proyectos\" + folioProyecto + @"\" + FileName;//AppDomain.CurrentDomain.BaseDirectory + "Ventas\\docs\\" + p.Nombre;
                using (FileStream Writer = new System.IO.FileStream(archivo, FileMode.Create, FileAccess.Write))
                {
                    Writer.Write(Convert.FromBase64String(completo64[1]), 0, Convert.FromBase64String(completo64[1]).Length);
                }
            }
            catch (Exception e)
            {
                retorno = e.ToString();
            }
            
            return retorno;
        }

        [WebMethod]
        public static string ObtenerImagenTarea(string pid)
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                var Filtrado = DataControl.tblProyectoTaskImagen.Where(a => a.IdTask.ToString() == pid);
                if(Filtrado != null)
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
                    retorno = JsonConvert.SerializeObject(Filtrado.OrderByDescending(a=>a.Fecha));
                }
                else
                {
                    retorno = "";
                }

            }
            return retorno;

        }

        [WebMethod]
        public static string GuardarComentariosTarea(string pid, string Comentario)
        {
            string retorno = string.Empty;
            try
            {
                using (var DataControl = new SisaEntitie())
                {
                    tblProyectoTasksComentarios adc = new tblProyectoTasksComentarios
                    {
                        IdTask = Guid.Parse(pid),
                        Comentario = Comentario,
                        IdTaskComentario = Guid.NewGuid(),
                        Fecha = DateTime.Now,
                        IdUsuario = usuario.IdUsuario
                    };
                    DataControl.tblProyectoTasksComentarios.Add(adc);
                    DataControl.SaveChanges();
                    retorno = "Tarea agregada.";
                }
            }
            catch(Exception ex)
            {
                retorno = "";
            }
            
            return retorno;
        }

        [WebMethod]
        public static string ObtenerFechas(string pid)
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                var proyects = (from p in DataControl.tblProyectoTasks
                                where p.IdTask.ToString() == pid

                                select new { p.FechaInicio, p.FechaFin }
                                );
                retorno = JsonConvert.SerializeObject(proyects);
            }
            return retorno;
        }

        [WebMethod]
        public static string GuardarFechas(string pid, string Razon, string Inicio, string Fin)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ProyectosEditar == true || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var Existe = DataControl.tblProyectoTasks.FirstOrDefault(a => a.IdTask.ToString() == pid);
                    if (Existe != null)
                    {
                        Existe.FechaInicio = DateTime.Parse(Inicio);
                        Existe.FechaFin = DateTime.Parse(Fin);
                        DataControl.SaveChanges();
                        tblProyectoTasksComentarios adc = new tblProyectoTasksComentarios
                        {
                            IdTask = Guid.Parse(pid),
                            Comentario = "CAMBIO DE FECHAS, RAZON: " + Razon,
                            IdTaskComentario = Guid.NewGuid(),
                            Fecha = DateTime.Now,
                            IdUsuario = usuario.IdUsuario
                        };
                        DataControl.tblProyectoTasksComentarios.Add(adc);
                        DataControl.SaveChanges();
                        retorno = "Fechas actualizadas.";
                    }
                    else
                    {
                        retorno = "Ocurrio un problema al obtener información, recarga página.";
                    }
                }
            }
            else
            {
                retorno = "No tienes permiso de editar proyectos.";
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
                    var docu = DataControl.tblDocProyectos.FirstOrDefault(a=> a.IdDocumento.ToString() == id);
                    if(docu != null)
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
                    else
                    {
                        var docs = DataControl.tblProyectoTaskImagen.FirstOrDefault(a => a.IdTaskImagen.ToString() == id);
                        if (docs != null)
                        {
                            if (!string.IsNullOrEmpty(docs.FileName) && !string.IsNullOrEmpty(docs.Imagen))
                            {
                                string[] archivoCompleto = docs.Imagen.Split(',');
                                string a = AppDomain.CurrentDomain.BaseDirectory + "Proyecto\\docs\\" + docs.FileName;
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
        public static string EliminarDocumento(string IdDocumento, string IdProyecto)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ProyectosEditar == true || rolesUsuarios.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {

                    tblDocProyectos entity = DataControl.tblDocProyectos.FirstOrDefault<tblDocProyectos>((v => v.IdDocumento.ToString() == IdDocumento));
                    if (entity != null)
                    {
                        DataControl.tblDocProyectos.Remove(entity);
                        DataControl.SaveChanges();
                        retorno = "Documento eliminado.";
                    }
                    else
                    {
                        retorno = "Error";
                    }
                        
                

                }
            }
            else
            {
                retorno = "No tienes permiso de eliminar documento.";
            }

            return retorno;
        }

        [WebMethod]
        public static string GuardarDailyReport(string idTask, string IdProyecto, string FileName, string FileSize, string FileType, string file, string Opcion)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            string nombreArchivo = "";
            try
            {
                if (FileName.Count() > 100)
                {
                    nombreArchivo = FileName.Substring(0, 100);
                }
                else
                {
                    nombreArchivo = FileName;
                }
                int a = Convert.ToInt32(Opcion);
                Guid b = Guid.Parse(idTask);
                Guid c = Guid.Parse(IdProyecto);
                using (var DataControl = new SisaEntitie())
                {
                    tblProyectoTaskImagen add = new tblProyectoTaskImagen
                    {
                        IdTaskImagen = Guid.NewGuid(),
                        IdTask = b,
                        IdUsuario = usuario.IdUsuario,
                        Imagen = file,
                        FileName = FileName,
                        Descripcion = nombreArchivo,
                        FileExtension = "",
                        FileContentType = FileType,
                        FileSize = FileSize,
                        Fecha = DateTime.Now

                    };
                    DataControl.tblProyectoTaskImagen.Add(add);
                    DataControl.SaveChanges();
                    retorno = "Archivo guardado";
                }

                //using (var DataControl = new SisaEntitie())
                //{
                //    int a = Convert.ToInt32(Opcion);
                //    Guid p = Guid.Parse(IdProyecto);
                //    tblDocProyectos add = new tblDocProyectos
                //    {
                //        IdDocumento = Guid.NewGuid(),
                //        IdProyecto = p,
                //        FileName = FileName,
                //        File = file,
                //        Fecha = DateTime.Now

                //    };
                //    DataControl.tblDocProyectos.Add(add);
                //    DataControl.SaveChanges();
                //    retorno = "Archivo guardado";
                //}

                if (!Directory.Exists(@"C:\SisaFiles\Proyectos\" + folioProyecto))
                {
                    Directory.CreateDirectory(@"C:\SisaFiles\Proyectos\" + folioProyecto);
                }

                if (File.Exists(@"C:\SisaFiles\Proyectos\" + folioProyecto + @"\" + FileName))
                {
                    File.Delete(@"C:\SisaFiles\Proyectos\" + folioProyecto + @"\" + FileName);
                }

                string[] completo64 = file.Split(',');
                //var originalString = ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(completo64[1]));
                string archivo = @"C:\SisaFiles\Proyectos\" + folioProyecto + @"\" + FileName;//AppDomain.CurrentDomain.BaseDirectory + "Ventas\\docs\\" + p.Nombre;
                using (FileStream Writer = new System.IO.FileStream(archivo, FileMode.Create, FileAccess.Write))
                {
                    Writer.Write(Convert.FromBase64String(completo64[1]), 0, Convert.FromBase64String(completo64[1]).Length);
                }
                //File.WriteAllBytes(a + p.Nombre, Convert.FromBase64String(p.Archivo));
            }
            catch (Exception e)
            {
                retorno = e.ToString();
            }

            return retorno;
        }
    }
}