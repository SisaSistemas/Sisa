using Newtonsoft.Json;
using SisaDev.Control;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Ventas
{
    public partial class Cotizaciones : System.Web.UI.Page
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
        public static string ObtenerCotizaciones(string pid)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.Administracion == true || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "ADMINISTRACION" || rolesUsuarios.Cotizaciones == true)
            {
                if (pid.Trim() == "1")
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        if (rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ROOT")
                        {
                            //var Cotiza = (from c in DataControl.tblCotizaciones
                            //              join em in DataControl.tblEmpresas on c.IdEmpresa equals em.idEmpresa
                            //              join cn in DataControl.tblClienteContacto on c.idContacto equals cn.idContacto
                            //              join r in DataControl.tblRFQ on c.idRequisicion equals r.IdRfq
                            //              select new { c.IdCotizaciones, c.NoCotizaciones, FechaCotizaciones = c.FechaCotizaciones.Day + "/" + c.FechaCotizaciones.Month + "/" + c.FechaCotizaciones.Year, r.Folio, FechaRequisicion = r.FechaAlta.Day + "/" + r.FechaAlta.Month + "/" + r.FechaAlta.Year, em.RazonSocial, cn.NombreContacto, cn.Telefono, c.Concepto, c.CostoCotizaciones, c.Estatus }
                            //              ).Concat(from c in DataControl.tblCotizaciones
                            //                       join em in DataControl.tblEmpresas on c.IdEmpresa equals em.idEmpresa
                            //                       join cn in DataControl.tblClienteContacto on c.idContacto equals cn.idContacto
                            //                       select new { c.IdCotizaciones, c.NoCotizaciones, FechaCotizaciones = c.FechaCotizaciones.Day + "/" + c.FechaCotizaciones.Month + "/" + c.FechaCotizaciones.Year, Folio = "", FechaRequisicion = "", em.RazonSocial, cn.NombreContacto, cn.Telefono, c.Concepto, c.CostoCotizaciones, c.Estatus });
                            var Cotiza = DataControl.sp_CargarCotizaciones().OrderByDescending(a=> a.FechaCotizaciones);
                            retorno = JsonConvert.SerializeObject(Cotiza);

                        }
                        else
                        {
                            //var Cotiza = (from c in DataControl.tblCotizaciones
                            //              join em in DataControl.tblEmpresas on c.IdEmpresa equals em.idEmpresa
                            //              join cn in DataControl.tblClienteContacto on c.idContacto equals cn.idContacto
                            //              join r in DataControl.tblRFQ on c.idRequisicion equals r.IdRfq
                            //              where c.IdUsuarioCreo == usuario.IdUsuario
                            //              select new { c.IdCotizaciones, c.NoCotizaciones, FechaCotizaciones = c.FechaCotizaciones.Day + "/" + c.FechaCotizaciones.Month + "/" + c.FechaCotizaciones.Year, r.Folio, FechaRequisicion = r.FechaAlta.Day + "/" + r.FechaAlta.Month + "/" + r.FechaAlta.Year, em.RazonSocial, cn.NombreContacto, cn.Telefono, c.Concepto, c.CostoCotizaciones, c.Estatus }
                            //              ).Concat(from c in DataControl.tblCotizaciones
                            //                       join em in DataControl.tblEmpresas on c.IdEmpresa equals em.idEmpresa
                            //                       join cn in DataControl.tblClienteContacto on c.idContacto equals cn.idContacto
                            //                       where c.IdUsuarioCreo == usuario.IdUsuario
                            //                       select new { c.IdCotizaciones, c.NoCotizaciones, FechaCotizaciones = c.FechaCotizaciones.Day + "/" + c.FechaCotizaciones.Month + "/" + c.FechaCotizaciones.Year, Folio = "", FechaRequisicion = "", em.RazonSocial, cn.NombreContacto, cn.Telefono, c.Concepto, c.CostoCotizaciones, c.Estatus }
                            //              );
                            if (usuario.Usuario == "cgarcia01" || usuario.Usuario == "dtopete")
                            {
                                var Cotiza = DataControl.sp_CargarCotizaciones().Where(c => c.IdUsuarioCreo == usuario.IdUsuario || c.IdUsuarioEnvia == usuario.IdUsuario).OrderByDescending(a => a.FechaCotizaciones);
                                retorno = JsonConvert.SerializeObject(Cotiza.Distinct());
                            }
                            else
                            {
                                var Cotiza = DataControl.sp_CargarCotizaciones().OrderByDescending(a => a.FechaCotizaciones); //.Where(c => c.IdUsuarioCreo == usuario.IdUsuario || c.IdUsuarioEnvia == usuario.IdUsuario)
                                retorno = JsonConvert.SerializeObject(Cotiza.Distinct());
                            }
                            
                        }
                    }
                }
                else
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        //var Cotiza = (from c in DataControl.tblCotizaciones
                        //              join em in DataControl.tblEmpresas on c.IdEmpresa equals em.idEmpresa
                        //              join cn in DataControl.tblClienteContacto on c.idContacto equals cn.idContacto
                        //              join r in DataControl.tblRFQ on c.idRequisicion equals r.IdRfq
                        //              where c.IdUsuarioCreo == usuario.IdUsuario && c.IdCotizaciones.ToString() == pid
                        //              select new { c.IdCotizaciones, c.NoCotizaciones, FechaCotizaciones = c.FechaCotizaciones.Day + "/" + c.FechaCotizaciones.Month + "/" + c.FechaCotizaciones.Year, r.Folio, FechaRequisicion = r.FechaAlta.Day + "/" + r.FechaAlta.Month + "/" + r.FechaAlta.Year, em.RazonSocial, cn.NombreContacto, cn.Telefono, c.Concepto, c.CostoCotizaciones, c.Estatus });
                        var Cotiza = DataControl.sp_CargarCotizaciones().Where(c => c.IdCotizaciones.ToString() == pid);
                        retorno = JsonConvert.SerializeObject(Cotiza);

                    }
                }
            }
            else
            {
                retorno = "";
            }

            return retorno;
        }

        [WebMethod]
        public static string EliminarCotizaciones(string pid)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.CotizacionesEliminar == true || rolesUsuarios.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var CExiste = DataControl.tblCotizaciones.FirstOrDefault(s => s.IdCotizaciones.ToString() == pid);
                    if (CExiste != null)
                    {
                        CExiste.Estatus = 0;
                        if (DataControl.SaveChanges() > 0)
                        {
                            retorno = "Cotización eliminado.";
                        }
                        else
                        {
                            retorno = "Ocurrio un problema al eliminar cotización.";
                        }
                    }

                }
            }
            else
            {
                retorno = "No tienes permiso de eliminar cotización.";
            }

            return retorno;
        }

        [WebMethod]
        public static string CancelarCotizacion(string pid)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.CotizacionesEliminar == true || rolesUsuarios.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var Existe = DataControl.tblCotizaciones.FirstOrDefault(s => s.IdCotizaciones.ToString() == pid);
                    if (Existe != null)
                    {
                        Existe.Estatus = 2;
                        if (DataControl.SaveChanges() > 0)
                        {
                            retorno = "Cotización cancelado.";
                        }
                        else
                        {
                            retorno = "Ocurrio un problema al cancelar Cotización.";
                        }
                    }

                }
            }
            else
            {
                retorno = "No tienes permiso de cancelar Cotización.";
            }

            return retorno;
        }

        [WebMethod]
        public static string CargarComentarios(string pid)
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                var Filtrado = DataControl.sp_CargarComentariosCotizacion(pid).OrderByDescending(a=>a.Fecha);
                retorno = JsonConvert.SerializeObject(Filtrado);
            }
            return retorno;
        }

        [WebMethod]
        public static string GuardarComentarios(string pid, string Comentario)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            using (var DataControl = new SisaEntitie())
            {
                var Filtrado = DataControl.sp_InsertaComentarioCotizacion(pid, Comentario, usuario.IdUsuario.ToString());
                retorno = JsonConvert.SerializeObject(Filtrado);
            }
            return retorno;
        }

        [WebMethod]
        protected void btnEnviar_Click(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string GuardarArchivo(string IdCotizacion, string NombreArchivo, string Documento)
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                var Existe = DataControl.tblCotizaciones.FirstOrDefault(c => c.IdCotizaciones.ToString() == IdCotizacion);
                if (Existe != null)
                {
                    if (NombreArchivo.Contains(".pdf"))
                    {
                        Existe.NombreArchivoPdf = NombreArchivo;
                        Existe.DocumentoPdf = Documento;
                        DataControl.SaveChanges();
                    }
                    else if (NombreArchivo.Contains(".xls") || NombreArchivo.Contains(".xlsx"))
                    {
                        Existe.NombreArchivoXls = NombreArchivo;
                        Existe.DocumentoXls = Documento;
                        DataControl.SaveChanges();
                    }
                    
                }
                else
                {
                    retorno = "Error, no se encontro cotización seleccionada, intenta de nuevo.";
                }
            }
            return retorno;
        }

        [WebMethod]
        public static string ConvertirCotizacion(string pid, string Concepto, string dtInicial, string dtFinal, string idLider, string Nombre, string MOC, string MC
            , string MEC, string MOP, string MP, string MEP, string CorreoLider, string Coordinador/*, string IdSucursal*/, string IdFolioPO, string FolioPO, string EsCCM)
        {
            string str = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;

            if (rolesUsuarios.CotizacionesEditar || rolesUsuarios.Tipo == "ROOT")
            {
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                {
                    tblCotizaciones tblCotizaciones = ((IQueryable<tblCotizaciones>)sisaEntitie.tblCotizaciones).FirstOrDefault<tblCotizaciones>((Expression<Func<tblCotizaciones, bool>>)(s => s.IdCotizaciones.ToString() == pid));
                    if (tblCotizaciones != null)
                    {
                        if (!string.IsNullOrEmpty(tblCotizaciones.DocumentoPdf) || !string.IsNullOrEmpty(tblCotizaciones.DocumentoXls))
                        {
                            string FolioProyecto = tblCotizaciones.NoCotizaciones.Replace("COT", "SIS");
                            if (((IQueryable<tblProyectos>)sisaEntitie.tblProyectos).FirstOrDefault<tblProyectos>((Expression<Func<tblProyectos, bool>>)(p => p.FolioProyecto == FolioProyecto)) == null)
                            {
                                tblCotizaciones.Estatus = 3;
                                var idProy = Guid.NewGuid();
                                var totalCotizado = (decimal.Parse(MOC) + decimal.Parse(MC) + decimal.Parse(MEC)) * decimal.Parse("1.16");

                                tblModuloPO tblModuloPO = (sisaEntitie.tblModuloPO.FirstOrDefault(s => s.IdModuloPO.ToString() == IdFolioPO));

                                string IdSucursal = tblModuloPO.IdSucursal.ToString();

                                if (IdSucursal == "56A03C71-BF9B-48E1-ABE0-D32A95B5FBDB")
                                {
                                    tblProyectos tblProyectos = new tblProyectos()
                                    {
                                        IdProyecto = idProy,
                                        EstatusDesc = "PENDIENTE",
                                        Estatus = "0",
                                        Activo = new int?(1),
                                        FolioProyecto = FolioProyecto,
                                        NombreProyecto = Nombre,
                                        Descripcion = Concepto,
                                        IdLider = idLider,
                                        IdCliente = tblCotizaciones.idContacto.ToString(),
                                        IdCotizacion = tblCotizaciones.IdCotizaciones.ToString(),
                                        IdUsuarioAlta = new Guid?(Cotizaciones.usuario.IdUsuario),
                                        IdUsuarioModificacion = new Guid?(Cotizaciones.usuario.IdUsuario),
                                        FechaAlta = new DateTime?(DateTime.Now),
                                        FechaModificacion = new DateTime?(DateTime.Now),
                                        FechaFin = new DateTime?(DateTime.Parse(dtFinal)),
                                        FechaInicio = new DateTime?(DateTime.Parse(dtInicial)),
                                        CostoCotizacion = new decimal?(totalCotizado),//tblCotizaciones.CostoCotizaciones,
                                        CostoMOCotizado = new double?(double.Parse(MOC)),
                                        CostoMaterialCotizado = new double?(double.Parse(MC)),
                                        CostoMECotizado = new double?(double.Parse(MEC)),
                                        CostoMOProyectado = new double?(double.Parse(MOP)),
                                        CostoMaterialProyectado = new double?(double.Parse(MP)),
                                        CostoMEProyectado = new double?(double.Parse(MEP)),
                                        LinkSharepoint = string.Empty,
                                        IdSucursal = Guid.Parse(IdSucursal),
                                        FolioPO = FolioPO,
                                        EsCCM = EsCCM == "true" ? 1 : 0,
                                        IdModuloPO = Guid.Parse(IdFolioPO)
                                    };
                                    sisaEntitie.tblProyectos.Add(tblProyectos);
                                }
                                else
                                {
                                    tblProyectos tblProyectos = new tblProyectos()
                                    {
                                        IdProyecto = idProy,
                                        EstatusDesc = "PENDIENTE",
                                        Estatus = "0",
                                        Activo = new int?(1),
                                        FolioProyecto = FolioProyecto,
                                        NombreProyecto = Nombre,
                                        Descripcion = Concepto,
                                        IdLider = idLider,
                                        IdCliente = tblCotizaciones.idContacto.ToString(),
                                        IdCotizacion = tblCotizaciones.IdCotizaciones.ToString(),
                                        IdUsuarioAlta = new Guid?(Cotizaciones.usuario.IdUsuario),
                                        IdUsuarioModificacion = new Guid?(Cotizaciones.usuario.IdUsuario),
                                        FechaAlta = new DateTime?(DateTime.Now),
                                        FechaModificacion = new DateTime?(DateTime.Now),
                                        FechaFin = new DateTime?(DateTime.Parse(dtFinal)),
                                        FechaInicio = new DateTime?(DateTime.Parse(dtInicial)),
                                        CostoCotizacion = new decimal?(totalCotizado),//tblCotizaciones.CostoCotizaciones,
                                        CostoMOCotizado = new double?(double.Parse(MOC) * 1.16),
                                        CostoMaterialCotizado = new double?(double.Parse(MC) * 1.16),
                                        CostoMECotizado = new double?(double.Parse(MEC) * 1.16),
                                        CostoMOProyectado = new double?(double.Parse(MOP) * 1.16),
                                        CostoMaterialProyectado = new double?(double.Parse(MP) * 1.16),
                                        CostoMEProyectado = new double?(double.Parse(MEP) * 1.16),
                                        LinkSharepoint = string.Empty,
                                        IdSucursal = Guid.Parse(IdSucursal),
                                        FolioPO = FolioPO,
                                        EsCCM = EsCCM == "true" ? 1 : 0,
                                        IdModuloPO = Guid.Parse(IdFolioPO)
                                    };
                                    sisaEntitie.tblProyectos.Add(tblProyectos);
                                }
                                
                                if (sisaEntitie.SaveChanges() > 0)
                                {
                                    tblEficiencias tblEficiencias = new tblEficiencias()
                                    {
                                        idProyecto = idProy,
                                        ManoObra = new Decimal?(0M),
                                        Equipo = new Decimal?(0M),
                                        Material = new Decimal?(0M)
                                    };
                                    sisaEntitie.tblEficiencias.Add(tblEficiencias);
                                    //sisaEntitie.SaveChanges();

                                    if (sisaEntitie.SaveChanges() > 0)
                                    {
                                        tblProyectoTasks tblProyectoTasks = new tblProyectoTasks()
                                        {
                                            IdTask = Guid.NewGuid(),
                                            IdProyecto = idProy,
                                            Task = "01-MEETING MINUTES",
                                            IdUsuario = usuario.IdUsuario,
                                            FechaInicio = DateTime.Now,
                                            FechaFin = DateTime.Now,
                                            Comentarios = "",
                                            Estatus = 0,
                                            IdUsuarioAlta = usuario.IdUsuario,
                                            FechaAlta = DateTime.Now,
                                            IdUsuarioModificacion = usuario.IdUsuario,
                                            FechaModificacion = DateTime.Now,
                                            Porcentaje = 0

                                        };
                                        sisaEntitie.tblProyectoTasks.Add(tblProyectoTasks);
                                        sisaEntitie.SaveChanges();

                                        tblProyectoTasks = new tblProyectoTasks()
                                        {
                                            IdTask = Guid.NewGuid(),
                                            IdProyecto = idProy,
                                            Task = "02-TIMMING",
                                            IdUsuario = usuario.IdUsuario,
                                            FechaInicio = DateTime.Now,
                                            FechaFin = DateTime.Now,
                                            Comentarios = "",
                                            Estatus = 0,
                                            IdUsuarioAlta = usuario.IdUsuario,
                                            FechaAlta = DateTime.Now,
                                            IdUsuarioModificacion = usuario.IdUsuario,
                                            FechaModificacion = DateTime.Now,
                                            Porcentaje = 0

                                        };
                                        sisaEntitie.tblProyectoTasks.Add(tblProyectoTasks);
                                        sisaEntitie.SaveChanges();

                                        tblProyectoTasks = new tblProyectoTasks()
                                        {
                                            IdTask = Guid.NewGuid(),
                                            IdProyecto = idProy,
                                            Task = "03-DAILY REPORTS",
                                            IdUsuario = usuario.IdUsuario,
                                            FechaInicio = DateTime.Now,
                                            FechaFin = DateTime.Now,
                                            Comentarios = "",
                                            Estatus = 0,
                                            IdUsuarioAlta = usuario.IdUsuario,
                                            FechaAlta = DateTime.Now,
                                            IdUsuarioModificacion = usuario.IdUsuario,
                                            FechaModificacion = DateTime.Now,
                                            Porcentaje = 0

                                        };
                                        sisaEntitie.tblProyectoTasks.Add(tblProyectoTasks);
                                        sisaEntitie.SaveChanges();

                                        tblProyectoTasks = new tblProyectoTasks()
                                        {
                                            IdTask = Guid.NewGuid(),
                                            IdProyecto = idProy,
                                            Task = "04-EVIDENCIA FOTOGRAFICA",
                                            IdUsuario = usuario.IdUsuario,
                                            FechaInicio = DateTime.Now,
                                            FechaFin = DateTime.Now,
                                            Comentarios = "",
                                            Estatus = 0,
                                            IdUsuarioAlta = usuario.IdUsuario,
                                            FechaAlta = DateTime.Now,
                                            IdUsuarioModificacion = usuario.IdUsuario,
                                            FechaModificacion = DateTime.Now,
                                            Porcentaje = 0

                                        };
                                        sisaEntitie.tblProyectoTasks.Add(tblProyectoTasks);
                                        sisaEntitie.SaveChanges();

                                        tblProyectoTasks = new tblProyectoTasks()
                                        {
                                            IdTask = Guid.NewGuid(),
                                            IdProyecto = idProy,
                                            Task = "05-CONTROL Y PROGRAMACION",
                                            IdUsuario = usuario.IdUsuario,
                                            FechaInicio = DateTime.Now,
                                            FechaFin = DateTime.Now,
                                            Comentarios = "",
                                            Estatus = 0,
                                            IdUsuarioAlta = usuario.IdUsuario,
                                            FechaAlta = DateTime.Now,
                                            IdUsuarioModificacion = usuario.IdUsuario,
                                            FechaModificacion = DateTime.Now,
                                            Porcentaje = 0

                                        };
                                        sisaEntitie.tblProyectoTasks.Add(tblProyectoTasks);
                                        sisaEntitie.SaveChanges();

                                        tblProyectoTasks = new tblProyectoTasks()
                                        {
                                            IdTask = Guid.NewGuid(),
                                            IdProyecto = idProy,
                                            Task = "06-DISEÑO",
                                            IdUsuario = usuario.IdUsuario,
                                            FechaInicio = DateTime.Now,
                                            FechaFin = DateTime.Now,
                                            Comentarios = "",
                                            Estatus = 0,
                                            IdUsuarioAlta = usuario.IdUsuario,
                                            FechaAlta = DateTime.Now,
                                            IdUsuarioModificacion = usuario.IdUsuario,
                                            FechaModificacion = DateTime.Now,
                                            Porcentaje = 0

                                        };
                                        sisaEntitie.tblProyectoTasks.Add(tblProyectoTasks);
                                        sisaEntitie.SaveChanges();

                                        tblProyectoTasks = new tblProyectoTasks()
                                        {
                                            IdTask = Guid.NewGuid(),
                                            IdProyecto = idProy,
                                            Task = "07-SOW",
                                            IdUsuario = usuario.IdUsuario,
                                            FechaInicio = DateTime.Now,
                                            FechaFin = DateTime.Now,
                                            Comentarios = "",
                                            Estatus = 0,
                                            IdUsuarioAlta = usuario.IdUsuario,
                                            FechaAlta = DateTime.Now,
                                            IdUsuarioModificacion = usuario.IdUsuario,
                                            FechaModificacion = DateTime.Now,
                                            Porcentaje = 0

                                        };
                                        sisaEntitie.tblProyectoTasks.Add(tblProyectoTasks);
                                        sisaEntitie.SaveChanges();

                                        tblProyectoTasks = new tblProyectoTasks()
                                        {
                                            IdTask = Guid.NewGuid(),
                                            IdProyecto = idProy,
                                            Task = "08-SEGURIDAD",
                                            IdUsuario = usuario.IdUsuario,
                                            FechaInicio = DateTime.Now,
                                            FechaFin = DateTime.Now,
                                            Comentarios = "",
                                            Estatus = 0,
                                            IdUsuarioAlta = usuario.IdUsuario,
                                            FechaAlta = DateTime.Now,
                                            IdUsuarioModificacion = usuario.IdUsuario,
                                            FechaModificacion = DateTime.Now,
                                            Porcentaje = 0

                                        };
                                        sisaEntitie.tblProyectoTasks.Add(tblProyectoTasks);
                                        sisaEntitie.SaveChanges();

                                        tblProyectoTasks = new tblProyectoTasks()
                                        {
                                            IdTask = Guid.NewGuid(),
                                            IdProyecto = idProy,
                                            Task = "09-EVALUACION Y CIERRE",
                                            IdUsuario = usuario.IdUsuario,
                                            FechaInicio = DateTime.Now,
                                            FechaFin = DateTime.Now,
                                            Comentarios = "",
                                            Estatus = 0,
                                            IdUsuarioAlta = usuario.IdUsuario,
                                            FechaAlta = DateTime.Now,
                                            IdUsuarioModificacion = usuario.IdUsuario,
                                            FechaModificacion = DateTime.Now,
                                            Porcentaje = 0

                                        };
                                        sisaEntitie.tblProyectoTasks.Add(tblProyectoTasks);
                                        sisaEntitie.SaveChanges();
                                    }
                                    Proceso.EnviarCorreoProyecto(CorreoLider, "Se creo un nuevo proyecto con folio <b>" + FolioProyecto + "</b> con el nombre de <b>" + Nombre + "</b> con el coordinador <b>" + Coordinador + "</b>.", usuario.Correo, "Proyecto - " + FolioProyecto + " - " + Nombre);

                                    str = "Cotización convertida.";
                                }
                                else
                                    str = "Ocurrio un problema al convertir Cotización.";
                            }
                            else
                                str = "Cotización ya ha sido convertida a proyecto con anterioridad con folio:" + FolioProyecto;
                        }
                        else
                            str = "Es necesario subir archivo de excel y pdf, para convertir cotización a proyecto.";
                    }
                    else
                        str = "No se encontro información de cotización seleccioanda.";
                }
            }
            else
                str = "No tienes permiso de convertir Cotización.";
            return str;
            //string retorno = string.Empty;
            //usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            //rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            //if (rolesUsuarios.CotizacionesEditar == true || rolesUsuarios.Tipo == "ROOT")
            //{
            //    using (var DataControl = new SisaEntitie())
            //    {

            //        var Existe = DataControl.tblCotizaciones.FirstOrDefault(s => s.IdCotizaciones.ToString() == pid);
            //        if (Existe != null)
            //        {    
            //            if((!string.IsNullOrEmpty(Existe.DocumentoPdf) || !string.IsNullOrEmpty(Existe.DocumentoXls)))
            //            {
            //                string FolioProyecto = Existe.NoCotizaciones.Replace("COT", "SIS");
            //                var ProyectoExiste = DataControl.tblProyectos.FirstOrDefault(p => p.FolioProyecto == FolioProyecto);
            //                if (ProyectoExiste == null)
            //                {
            //                    Existe.Estatus = 3;

            //                    tblProyectos add = new tblProyectos
            //                    {
            //                        IdProyecto = Guid.NewGuid(),
            //                        EstatusDesc = "PENDIENTE",
            //                        Estatus = "0",
            //                        Activo = 1,
            //                        FolioProyecto = FolioProyecto,
            //                        NombreProyecto = Nombre,
            //                        Descripcion = Concepto,
            //                        IdLider = idLider,
            //                        IdCliente = Existe.idContacto.ToString(),
            //                        IdCotizacion = Existe.IdCotizaciones.ToString(),
            //                        IdUsuarioAlta = usuario.IdUsuario,
            //                        IdUsuarioModificacion = usuario.IdUsuario,
            //                        FechaAlta = DateTime.Now,
            //                        FechaModificacion = DateTime.Now,
            //                        FechaFin = DateTime.Parse(dtFinal),
            //                        FechaInicio = DateTime.Parse(dtInicial),
            //                        CostoCotizacion = Existe.CostoCotizaciones,
            //                        CostoMOCotizado = double.Parse(MOC),
            //                        CostoMaterialCotizado = double.Parse(MC),
            //                        CostoMECotizado = double.Parse(MEC),
            //                        CostoMOProyectado = double.Parse(MOP),
            //                        CostoMaterialProyectado = double.Parse(MP),
            //                        CostoMEProyectado = double.Parse(MEP)
            //                    };
            //                    DataControl.tblProyectos.Add(add);
            //                    if (DataControl.SaveChanges() > 0)
            //                    {
            //                        tblEficiencias ad = new tblEficiencias
            //                        {
            //                            idProyecto = add.IdProyecto,
            //                            ManoObra = 0,
            //                            Equipo = 0,
            //                            Material = 0
            //                        };
            //                        DataControl.tblEficiencias.Add(ad);
            //                        DataControl.SaveChanges();
            //                        retorno = "Cotización convertida.";
            //                    }
            //                    else
            //                    {
            //                        retorno = "Ocurrio un problema al convertir Cotización.";
            //                    }
            //                }
            //                else
            //                {
            //                    retorno = "Cotización ya ha sido convertida a proyecto con anterioridad con folio:" + FolioProyecto;
            //                }
            //            }
            //            else
            //            {
            //                retorno = "Es necesario subir archivo de excel y pdf, para convertir cotización a proyecto.";
            //            }


            //        }
            //        else
            //        {
            //            retorno = "No se encontro información de cotización seleccioanda.";
            //        }

            //    }
            //}
            //else
            //{
            //    retorno = "No tienes permiso de convertir Cotización.";
            //}

            //return retorno;
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
        public static string CargarMontosCotizacion(string pid)
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                Guid op = Guid.Parse(pid);
                var cot = (from a in DataControl.tblCotizaciones
                           where a.IdCotizaciones == op
                           select new { a.CostoMOCotizado, a.CostoMECotizado, a.CostoMaterialCotizado });
                retorno = JsonConvert.SerializeObject(cot);
            }
            return retorno;

        }

        [WebMethod]
        public static string CargarDocumentos(string id, string Opcion)
        {
            string retorno = string.Empty;
            try
            {              
                using (var DataControl = new SisaEntitie())
                {
                    var proyects = from p in DataControl.tblCotizaciones
                                    where p.IdCotizaciones.ToString() == id
                                    select new { Nombre = (p.NombreArchivoPdf != null ? p.NombreArchivoPdf : ""), Archivo = (p.DocumentoPdf != null ? p.DocumentoPdf : ""), p.IdCotizaciones };

                    foreach(var p in proyects)
                    {
                        
                        if(!string.IsNullOrEmpty(p.Nombre) && !string.IsNullOrEmpty(p.Archivo))
                        {
                            string[] completo64 = p.Archivo.Split(',');
                            //var originalString = ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(completo64[1]));
                            string a = AppDomain.CurrentDomain.BaseDirectory + "Ventas\\docs\\" + p.Nombre;
                            using (FileStream Writer = new System.IO.FileStream(a, FileMode.Create, FileAccess.Write))
                            {
                                Writer.Write(Convert.FromBase64String(completo64[1]), 0, Convert.FromBase64String(completo64[1]).Length);
                            }
                            //File.WriteAllBytes(a + p.Nombre, Convert.FromBase64String(p.Archivo));
                        }
                        
                    }                  

                    retorno = JsonConvert.SerializeObject(proyects);

                }
            }
            catch (Exception e)
            {
                retorno = e.ToString();
            }
            return retorno;
        }

        [WebMethod]
        public static string CargarDocumentosExcel(string id, string Opcion)
        {
            string retorno = string.Empty;
            try
            {
                using (var DataControl = new SisaEntitie())
                {
                    var proyects = from p in DataControl.tblCotizaciones
                                   where p.IdCotizaciones.ToString() == id
                                   select new { Nombre = (p.NombreArchivoXls != null ? p.NombreArchivoXls : ""), Archivo = (p.DocumentoXls != null ? p.DocumentoXls : ""), p.IdCotizaciones };

                    foreach (var p in proyects)
                    {

                        if (!string.IsNullOrEmpty(p.Nombre) && !string.IsNullOrEmpty(p.Archivo))
                        {
                            string[] completo64 = p.Archivo.Split(',');
                            //var originalString = ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(completo64[1]));
                            string a = AppDomain.CurrentDomain.BaseDirectory + "Ventas\\docs\\" + p.Nombre;
                            using (FileStream Writer = new System.IO.FileStream(a, FileMode.Create, FileAccess.Write))
                            {
                                Writer.Write(Convert.FromBase64String(completo64[1]), 0, Convert.FromBase64String(completo64[1]).Length);
                            }
                            //File.WriteAllBytes(a + p.Nombre, Convert.FromBase64String(p.Archivo));
                        }

                    }

                    retorno = JsonConvert.SerializeObject(proyects);

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