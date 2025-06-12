using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Proyectos
{
    public partial class Administracion : System.Web.UI.Page
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
        public static string CargarTotal(string Opcion)
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                int op = Convert.ToInt32(Opcion);

                retorno = JsonConvert.SerializeObject(DataControl.sp_TotalSinOrden(op));
            }
            return retorno;

        }

        [WebMethod]
        public static string ObtenerProyectos(string pid)
        {//b.Procedure = "dbo.sp_LoadProyectosAdmin";
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.Administracion == true || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                if (pid.Trim() == "1")
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        if(rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL")
                        {
                            var proyects = DataControl.sp_Administracion();

                            retorno = JsonConvert.SerializeObject(proyects);
                        }
                        else
                        {
                            //var proyects = DataControl.sp_Administracion().Where(a=> a.idSucursal == usuario.idSucursal);
                            var proyects = DataControl.sp_Administracion().Where(a => a.idSucursal == usuario.idSucursal);

                            if (usuario.Usuario == "scaraveo" || usuario.Usuario == "cgarcia")
                            {
                                proyects = DataControl.sp_Administracion().Where(a => a.Cliente == "FORD IRAPUATO" || a.idSucursal == usuario.idSucursal);
                            }
                            //else
                            //{
                            //    proyects = DataControl.sp_Administracion().Where(a => a.idSucursal == usuario.idSucursal);
                            //}

                            //var proyects = DataControl.sp_Administracion().Where(a => a.Cliente == "FORD IRAPUATO" || a.idSucursal == usuario.idSucursal);

                            retorno = JsonConvert.SerializeObject(proyects);
                        }
                    }
                }
                else
                {
                    using (var DataControl = new SisaEntitie())
                    {

                        var proyects = DataControl.sp_Administracion().Where(a => a.IdProyecto.ToString() == pid).OrderBy(a => a.ID);
                        retorno = JsonConvert.SerializeObject(proyects);

                    }
                }
            }
            else
            {
                retorno = "No tienes permiso.";
            }
            
            return retorno;
        }

        [WebMethod]
        public static string CargarDocumentos(string IdProyecto, string Opcion)
        {
            string str = string.Empty;
            try
            {
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                {
                    if (Opcion == "OC")
                        str = JsonConvert.SerializeObject((object)((IQueryable<tblProyectos>)sisaEntitie.tblProyectos).Where<tblProyectos>((Expression<Func<tblProyectos, bool>>)(p => p.IdProyecto.ToString() == IdProyecto)).Select(p => new
                        {
                            NombreOC = p.NombreOC != default(string) ? p.NombreOC : "",
                            ArchivoOC = p.ArchivoOC != default(string) ? p.ArchivoOC : "",
                            IdProyecto = p.IdProyecto
                        }));
                    else if (Opcion == "CL")
                        str = JsonConvert.SerializeObject((object)((IQueryable<tblProyectos>)sisaEntitie.tblProyectos).Where<tblProyectos>((Expression<Func<tblProyectos, bool>>)(p => p.IdProyecto.ToString() == IdProyecto)).Select(p => new
                        {
                            NombreCL = p.NombreCL != default(string) ? p.NombreCL : "",
                            ArchivoCL = p.ArchivoCL != default(string) ? p.ArchivoCL : "",
                            IdProyecto = p.IdProyecto
                        }));
                }
            }
            catch (Exception ex)
            {
                str = ex.ToString();
            }
            return str;
            //string retorno = string.Empty;
            //try
            //{
            //    using (var DataControl = new SisaEntitie())
            //    {
            //        if(Opcion == "OC")
            //        {
            //            var proyects = (from p in DataControl.tblProyectos
            //                            where p.IdProyecto.ToString() == IdProyecto
            //                            select new { NombreOC = (p.NombreOC != null ? p.NombreOC : ""), ArchivoOC=(p.ArchivoOC != null ? p.ArchivoOC : ""), p.IdProyecto });
            //            retorno = JsonConvert.SerializeObject(proyects);
            //        }
            //        else if (Opcion == "CL")
            //        {
            //            var proyects = (from p in DataControl.tblProyectos
            //                            where p.IdProyecto.ToString() == IdProyecto
            //                            select new { NombreCL = (p.NombreCL != null ? p.NombreCL : ""), ArchivoCL = (p.ArchivoCL != null ? p.ArchivoCL : ""), p.IdProyecto });
            //            retorno = JsonConvert.SerializeObject(proyects);
            //        }                   

            //    }                
            //}
            //catch (Exception e)
            //{
            //    retorno = e.ToString();
            //}
            //return retorno;
        }

        [WebMethod]
        public static string EliminarDocumento(string IdProyecto, string Opcion)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ProyectosEditar == true || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION") { 
                try
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        if (Opcion == "OC")
                        {
                            var proyects = DataControl.tblProyectos.FirstOrDefault(p => p.IdProyecto.ToString() == IdProyecto);
                            if (proyects != null)
                            {
                                proyects.ArchivoOC = "";
                                proyects.NombreOC = "";
                                DataControl.SaveChanges();
                                retorno = "Documento eliminado.";
                            }
                            else
                            {
                                retorno = "No se encontro información de documento, intenta de nuevo recargando página";
                            }
                        }
                        else if (Opcion == "CL")
                        {
                            var proyects = DataControl.tblProyectos.FirstOrDefault(p=> p.IdProyecto.ToString() == IdProyecto);
                            if(proyects != null)
                            {
                                proyects.ArchivoCL = "";
                                proyects.NombreCL = "";
                                DataControl.SaveChanges();
                                retorno = "Documento eliminado.";
                            }
                            else
                            {
                                retorno = "No se encontro información de documento, intenta de nuevo recargando página";
                            }


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
        public static string GuardarDocumentos(string TipoDoc, string IdProyecto, string FileName, string File)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ProyectosEditar == true || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                try
                {

                    using (var DataControl = new SisaEntitie())
                    {
                        Guid id = Guid.Parse(IdProyecto);

                        var Proy = DataControl.tblProyectos.FirstOrDefault(p => p.IdProyecto == id);
                        if (Proy != null)
                        {
                            if (TipoDoc.Trim() == "1")
                            {
                                Proy.ArchivoOC = File;
                                Proy.NombreOC = FileName;
                            }
                            else if (TipoDoc.Trim() == "2")
                            {
                                Proy.ArchivoCL = File;
                                Proy.NombreCL = FileName;
                            }

                            Proy.IdUsuarioModificacion = usuario.IdUsuario;
                            Proy.FechaModificacion = DateTime.Now;
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
        public static string CambiarEstatus(string pid, string Estatus)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ProyectosEditar == true || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var CExiste = DataControl.tblProyectos.FirstOrDefault(s => s.IdProyecto.ToString() == pid);
                    if (CExiste != null)
                    {
                        CExiste.Estatus = Estatus;
                        CExiste.IdUsuarioEstatus = usuario.IdUsuario;
                        CExiste.FechaEstatus = DateTime.Now;
                        if (DataControl.SaveChanges() > 0)
                        {
                            retorno = "Proyecto actualizado.";
                        }
                        else
                        {
                            retorno = "Ocurrio un problema al actualizar proyecto.";
                        }
                    }

                }
            }
            else
            {
                retorno = "No tienes permiso de actualizar proyecto.";
            }

            return retorno;
        }

        [WebMethod]
        public static string FinalizarProyecto(string pid)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ProyectosEditar == true || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var CExiste = DataControl.tblProyectos.FirstOrDefault(s => s.IdProyecto.ToString() == pid);
                    if (CExiste != null)
                    {
                        CExiste.Estatus = "3";
                        CExiste.IdUsuarioFinaliza = usuario.IdUsuario;

                        if (DataControl.SaveChanges() > 0)
                        {
                            retorno = "Proyecto Cierre Operativo.";
                        }
                        else
                        {
                            retorno = "Ocurrio un problema al finalizar proyecto.";
                        }
                    }

                }
            }
            else
            {
                retorno = "No tienes permiso de finalizar proyecto.";
            }

            return retorno;
        }

        [WebMethod]
        public static string TerminarProyecto(string pid)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ProyectosEditar == true || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var CExiste = DataControl.tblProyectos.FirstOrDefault(s => s.IdProyecto.ToString() == pid);
                    if (CExiste != null)
                    {
                        CExiste.Estatus = "5";
                        CExiste.IdUsuarioFinaliza = usuario.IdUsuario;

                        if (DataControl.SaveChanges() > 0)
                        {
                            retorno = "Proyecto Finalizado.";
                        }
                        else
                        {
                            retorno = "Ocurrio un problema al finalizar proyecto.";
                        }
                    }

                }
            }
            else
            {
                retorno = "No tienes permiso de finalizar proyecto.";
            }

            return retorno;
        }

        [WebMethod]
        public static string CargarGastos(string pid)
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                var aa = (from a in DataControl.tblProyectos
                         where a.IdProyecto.ToString() == pid
                         select new { a.CostoMOProyectado, a.CostoMaterialProyectado, a.CostoMEProyectado, a.CostoMOCotizado, a.CostoMaterialCotizado, a.CostoMECotizado });
                retorno = JsonConvert.SerializeObject(aa);
            }

            return retorno;
        }

        [WebMethod]
        public static string CambiarGastos(string pid, string MO, string M, string ME, string MOC, string MC, string MEC)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ProyectosEditar == true || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var CExiste = DataControl.tblProyectos.FirstOrDefault(s => s.IdProyecto.ToString() == pid);
                    if (CExiste != null)
                    {
                        if (CExiste.IdSucursal.ToString() == "56A03C71-BF9B-48E1-ABE0-D32A95B5FBDB")
                        {
                            CExiste.CostoMaterialProyectado = double.Parse(M);
                            CExiste.CostoMEProyectado = double.Parse(ME);
                            CExiste.CostoMOProyectado = double.Parse(MO);
                            CExiste.CostoMOCotizado = double.Parse(MOC);
                            CExiste.CostoMaterialCotizado = double.Parse(MC);
                            CExiste.CostoMECotizado = double.Parse(MEC);
                            if (DataControl.SaveChanges() > 0)
                            {
                                retorno = "Proyecto actualizado.";
                            }
                            else
                            {
                                retorno = "Ocurrio un problema al actualizar proyecto, o no se detecto cambios.";
                            }
                        }
                        else
                        {
                            CExiste.CostoMaterialProyectado = (double.Parse(M) * 1.16);
                            CExiste.CostoMEProyectado = (double.Parse(ME) * 1.16);
                            CExiste.CostoMOProyectado = (double.Parse(MO) * 1.16);
                            CExiste.CostoMOCotizado = (double.Parse(MOC) * 1.16);
                            CExiste.CostoMaterialCotizado = (double.Parse(MC) * 1.16);
                            CExiste.CostoMECotizado = (double.Parse(MEC) * 1.16);
                            if (DataControl.SaveChanges() > 0)
                            {
                                retorno = "Proyecto actualizado.";
                            }
                            else
                            {
                                retorno = "Ocurrio un problema al actualizar proyecto, o no se detecto cambios.";
                            }
                        }
                        
                    }

                }
            }
            else
            {
                retorno = "No tienes permiso de editar proyecto.";
            }

            return retorno;
        }

        [WebMethod]
        public static string CambiarMonto(string pid, string Monto)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ProyectosEditar == true || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var CExiste = DataControl.tblProyectos.FirstOrDefault(s => s.IdProyecto.ToString() == pid);
                    if (CExiste != null)
                    {
                        if (CExiste.IdSucursal.ToString() == "56A03C71-BF9B-48E1-ABE0-D32A95B5FBDB")
                        {
                            double iva = double.Parse("0");
                            double tota = double.Parse(Monto) + iva;
                            CExiste.CostoCotizacion = decimal.Parse(tota.ToString());
                            if (DataControl.SaveChanges() > 0)
                            {
                                retorno = "Proyecto actualizado.";
                            }
                            else
                            {
                                retorno = "Ocurrio un problema al actualizar proyecto, no se encontraron cambios, el monto es igual al registrado actualmente.";
                            }
                        }
                        else
                        {
                            double iva = double.Parse(Monto) * (.16);
                            double tota = double.Parse(Monto) + iva;
                            CExiste.CostoCotizacion = decimal.Parse(tota.ToString());
                            if (DataControl.SaveChanges() > 0)
                            {
                                retorno = "Proyecto actualizado.";
                            }
                            else
                            {
                                retorno = "Ocurrio un problema al actualizar proyecto, no se encontraron cambios, el monto es igual al registrado actualmente.";
                            }
                        }
                        
                    }

                }
            }
            else
            {
                retorno = "No tienes permiso de actualizar proyecto.";
            }

            return retorno;
        }
        [WebMethod]
        public static string CambiarLider(string pid, string idLider, string nombreProyecto, string folioPO, string idSucursal, string idFolioPO)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ProyectosEditar == true || rolesUsuarios.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var CExiste = DataControl.tblProyectos.FirstOrDefault(s => s.IdProyecto.ToString() == pid);
                    if (CExiste != null)
                    {
                        CExiste.IdLider = idLider;
                        CExiste.NombreProyecto = nombreProyecto;
                        CExiste.FolioPO = folioPO;
                        CExiste.IdSucursal = Guid.Parse(idSucursal);
                        CExiste.IdModuloPO = Guid.Parse(idFolioPO);
                        if (DataControl.SaveChanges() > 0)
                        {
                            retorno = "Proyecto actualizado.";
                        }
                        else
                        {
                            retorno = "Ocurrio un problema al actualizar proyecto.";
                        }
                    }

                }
            }
            else
            {
                retorno = "No tienes permiso de actualizar proyecto.";
            }

            return retorno;
        }

        [WebMethod]
        public static string ActualizarAvance(string pid, string Avance)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ProyectosEditar == true || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var CExiste = DataControl.tblProyectos.FirstOrDefault(s => s.IdProyecto.ToString() == pid);
                    if (CExiste != null)
                    {
                        
                        CExiste.Avance = int.Parse(Avance.ToString());
                        CExiste.IdUsuarioAvance = usuario.IdUsuario;

                        if (DataControl.SaveChanges() > 0)
                        {
                            retorno = "Proyecto actualizado.";
                        }
                        else
                        {
                            retorno = "Ocurrio un problema al actualizar proyecto, no se encontraron cambios, el monto es igual al registrado actualmente.";
                        }
                    }

                }
            }
            else
            {
                retorno = "No tienes permiso de actualizar proyecto.";
            }

            return retorno;
        }

        [WebMethod]
        public static string CargarComentarios(string pid)
        {
            string empty = string.Empty;
            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                return JsonConvert.SerializeObject((object)sisaEntitie.tblComentariosProyecto.Join((IEnumerable<tblUsuarios>)sisaEntitie.tblUsuarios, (Expression<Func<tblComentariosProyecto, Guid>>)(p => p.IdUsuario), (Expression<Func<tblUsuarios, Guid>>)(u => u.IdUsuario), (p, u) => new
                {
                    p = p,
                    u = u
                }).Where(data => data.p.IdProyecto.ToString() == pid).OrderByDescending(data => data.p.FechaComentario).Select(data => new
                {
                    IdProyecto = data.p.IdProyecto,
                    Comentario = data.p.Comentario,
                    NombreCompleto = data.u.NombreCompleto,
                    Fecha = data.p.FechaComentario
                }).OrderByDescending(a => a.Fecha));
            }

        }

        [WebMethod]
        public static string GuardarComentarios(string pid, string Comentario)
        {
            string empty = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            using (SisaEntitie sisaEntitie = new SisaEntitie())
                return JsonConvert.SerializeObject((object)sisaEntitie.sp_InsertaComentarioProyecto(pid, Comentario, usuario.IdUsuario.ToString()));
        }

        [WebMethod]
        public static string cargaCombosFiltrosBuscar(string Opcion)
        {
            string str = string.Empty;
            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                int op = Convert.ToInt32(Opcion);
                str = JsonConvert.SerializeObject(sisaEntitie.sp_CargaCombos(op));
                //if (Opcion == "10")
                //    str = JsonConvert.SerializeObject((object)((IQueryable<tblProyectos>)sisaEntitie.tblProyectos).Where<tblProyectos>((Expression<Func<tblProyectos, bool>>)(d => d.Activo == (int?)1)).Select(d => new
                //    {
                //        Id = d.idContacto,
                //        Nombre = d.NombreContacto
                //    }).OrderBy(a => a.Nombre));
                //else if (Opcion == "22")
                //{
                //    str = JsonConvert.SerializeObject((object)((IQueryable<tblProyectos>)sisaEntitie.tblProyectos).Where<tblProyectos>((Expression<Func<tblProyectos, bool>>)(d => d.Activo == (int?)1)).Select(d => new
                //    {
                //        Id = d.IdProyecto,
                //        Nombre = d.FolioProyecto + "-" + d.NombreProyecto
                //    }).OrderBy(a => a.Nombre));
                //}
                //else if (Opcion == "23")
                //{
                //    str = JsonConvert.SerializeObject((object)((IQueryable<tblProyectos>)sisaEntitie.tblProyectos).Where<tblProyectos>((Expression<Func<tblProyectos, bool>>)(d => d.Activo == (int?)1)).Select(d => new
                //    {
                //        Id = d.IdProyecto,
                //        Nombre = d.FolioProyecto + "-" + d.NombreProyecto
                //    }).OrderBy(a => a.Nombre));
                //}
            }
            return str;
        }

        [WebMethod]
        public static string CargaBusqueda(string pid, string _proyecto, string _contacto, string _empresa, string _lider, string _sucursal, string _fechaInicio, string _fechaFin, string _estatus, string _oc, string _cl)
        {
            if (_proyecto == "null")
            {
                _proyecto = "-1";
            }
            if (_contacto == "null")
            {
                _contacto = "-1";
            }
            if (_empresa == "null")
            {
                _empresa = "-1";
            }
            if (_lider == "null")
            {
                _lider = "-1";
            }
            if (_sucursal == "null")
            {
                _sucursal = "-1";
            }
            if (_fechaInicio == "null")
            {
                _fechaInicio = "-1";
            }
            if (_fechaFin == "null")
            {
                _fechaFin = "-1";
            }
            if (_estatus == "null")
            {
                _estatus = "-1";
            }
            if (_oc == "null")
            {
                _oc = "-1";
            }
            if (_cl == "null")
            {
                _cl = "-1";
            }

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand("JT_LoadProyectos", conn);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Proyecto", (object)_proyecto);
            sqlCommand.Parameters.AddWithValue("@Contacto", (object)_contacto);
            sqlCommand.Parameters.AddWithValue("@Empresa", (object)_empresa);
            sqlCommand.Parameters.AddWithValue("@Lider", (object)_lider);
            sqlCommand.Parameters.AddWithValue("@Sucursal", (object)_sucursal);
            sqlCommand.Parameters.AddWithValue("@FechaInicio", (object)_fechaInicio);
            sqlCommand.Parameters.AddWithValue("@FechaFin", (object)_fechaFin);
            sqlCommand.Parameters.AddWithValue("@Estatus", (object)_estatus);
            sqlCommand.Parameters.AddWithValue("@OC", (object)_oc);
            sqlCommand.Parameters.AddWithValue("@CL", (object)_cl);
            DataTable dataTable = new DataTable();
            dataTable.Load((IDataReader)sqlCommand.ExecuteReader());
            return JsonConvert.SerializeObject((object)dataTable);
        }
    }
}