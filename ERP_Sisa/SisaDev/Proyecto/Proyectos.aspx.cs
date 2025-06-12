using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;

namespace SisaDev.Proyectos
{
    public partial class Proyectos : System.Web.UI.Page
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
        public static string ObtenerProyectos(string pid)
        {
            string str = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.Proyectos || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "ADMINISTRACION" || rolesUsuarios.Tipo == "GERENCIAL")
            {
                if (pid.Trim() == "1")
                {
                    if (rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "ADMINISTRACION" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "COMPRAS")
                    {

                        if (usuario.idSucursal.ToString().ToUpper() == "E9D0B53B-D8B7-493A-B26D-FAF66D906157")
                        {
                            using (var DataControl = new SisaEntitie())
                            {
                                var proyects = DataControl.sp_Administracion();

                                str = JsonConvert.SerializeObject(proyects);
                            }
                            
                            //using (SisaEntitie sisaEntitie = new SisaEntitie())
                            //    str = JsonConvert.SerializeObject((object)sisaEntitie.tblProyectos.Join((IEnumerable<tblClienteContacto>)sisaEntitie.tblClienteContacto, (Expression<Func<tblProyectos, string>>)(p => p.IdCliente), (Expression<Func<tblClienteContacto, string>>)(c => c.idContacto.ToString()), (p, c) => new
                            //    {
                            //        p = p,
                            //        c = c
                            //    }).Join((IEnumerable<tblEmpresas>)sisaEntitie.tblEmpresas, data => data.c.idEmpresa, (Expression<Func<tblEmpresas, Guid>>)(e => e.idEmpresa), (data, e) => new
                            //    {
                            //        data = data,
                            //        e = e
                            //    }).Join((IEnumerable<tblUsuarios>)sisaEntitie.tblUsuarios, data => data.data.p.IdLider, (Expression<Func<tblUsuarios, string>>)(u => u.IdUsuario.ToString()), (data, u) => new
                            //    {
                            //        data1 = data,
                            //        u = u
                            //    }).Where(data => data.data1.data.p.Activo == (int?)1 && data.data1.data.p.Estatus != "6").OrderBy(data => data.data1.data.p.Estatus).ThenByDescending(data => data.data1.data.p.FechaAlta).Select(data => new
                            //    {
                            //        IdProyecto = data.data1.data.p.IdProyecto,
                            //        FolioProyecto = data.data1.data.p.FolioProyecto,
                            //        NombreProyecto = data.data1.data.p.NombreProyecto,
                            //        NombreContacto = data.data1.data.c.NombreContacto,
                            //        RazonSocial = data.data1.e.Cliente,
                            //        Lider = data.u.NombreCompleto,
                            //        FechaI = data.data1.data.p.FechaInicio,
                            //        FechaT = data.data1.data.p.FechaFin,
                            //        Estatus = data.data1.data.p.Estatus,
                            //        Activo = data.data1.data.p.Activo,
                            //        FechaAlta = data.data1.data.p.FechaAlta,
                            //        LinkSharepoint = data.data1.data.p.LinkSharepoint
                            //    }));
                        }
                        else
                        {
                            using (var DataControl = new SisaEntitie())
                            {
                                var proyects = DataControl.sp_Administracion().Where(a => a.idSucursal == usuario.idSucursal);

                                str = JsonConvert.SerializeObject(proyects);
                            }
                            //using (SisaEntitie sisaEntitie = new SisaEntitie())
                            //    str = JsonConvert.SerializeObject((object)sisaEntitie.tblProyectos.Join((IEnumerable<tblClienteContacto>)sisaEntitie.tblClienteContacto, (Expression<Func<tblProyectos, string>>)(p => p.IdCliente), (Expression<Func<tblClienteContacto, string>>)(c => c.idContacto.ToString()), (p, c) => new
                            //    {
                            //        p = p,
                            //        c = c
                            //    }).Join((IEnumerable<tblEmpresas>)sisaEntitie.tblEmpresas, data => data.c.idEmpresa, (Expression<Func<tblEmpresas, Guid>>)(e => e.idEmpresa), (data, e) => new
                            //    {
                            //        data = data,
                            //        e = e
                            //    }).Join((IEnumerable<tblUsuarios>)sisaEntitie.tblUsuarios, data => data.data.p.IdLider, (Expression<Func<tblUsuarios, string>>)(u => u.IdUsuario.ToString()), (data, u) => new
                            //    {
                            //        data1 = data,
                            //        u = u
                            //    }).Where(data => data.data1.data.p.Activo == (int?)1 && data.data1.data.p.Estatus != "6" && data.data1.e.idSucursalRegistro == usuario.idSucursal).OrderBy(data => data.data1.data.p.Estatus).ThenByDescending(data => data.data1.data.p.FechaAlta).Select(data => new
                            //    {
                            //        IdProyecto = data.data1.data.p.IdProyecto,
                            //        FolioProyecto = data.data1.data.p.FolioProyecto,
                            //        NombreProyecto = data.data1.data.p.NombreProyecto,
                            //        NombreContacto = data.data1.data.c.NombreContacto,
                            //        RazonSocial = data.data1.e.Cliente,
                            //        Lider = data.u.NombreCompleto,
                            //        FechaI = data.data1.data.p.FechaInicio,
                            //        FechaT = data.data1.data.p.FechaFin,
                            //        Estatus = data.data1.data.p.Estatus,
                            //        Activo = data.data1.data.p.Activo,
                            //        FechaAlta = data.data1.data.p.FechaAlta,
                            //        LinkSharepoint = data.data1.data.p.LinkSharepoint
                            //    }));
                        }

                        
                    }
                    else
                    {
                        //using (SisaEntitie sisaEntitie = new SisaEntitie())
                        //    str = JsonConvert.SerializeObject((object)sisaEntitie.tblProyectos.Join((IEnumerable<tblClienteContacto>)sisaEntitie.tblClienteContacto, (Expression<Func<tblProyectos, string>>)(p => p.IdCliente), (Expression<Func<tblClienteContacto, string>>)(c => c.idContacto.ToString()), (p, c) => new
                        //    {
                        //        p = p,
                        //        c = c
                        //    }).Join((IEnumerable<tblEmpresas>)sisaEntitie.tblEmpresas, data => data.c.idEmpresa, (Expression<Func<tblEmpresas, Guid>>)(e => e.idEmpresa), (data, e) => new
                        //    {
                        //        data0 = data,
                        //        e = e
                        //    }).Join((IEnumerable<tblUsuarios>)sisaEntitie.tblUsuarios, data => data.data0.p.IdLider, (Expression<Func<tblUsuarios, string>>)(u => u.IdUsuario.ToString()), (data, u) => new
                        //    {
                        //        data1 = data,
                        //        u = u
                        //    }).Where(data => data.data1.data0.p.Activo == (int?)1 && data.data1.data0.p.Estatus != "6" && (data.data1.data0.p.IdLider.ToString() == usuario.IdUsuario.ToString() || data.data1.data0.p.IdUsuarioAlta.ToString() == usuario.IdUsuario.ToString())).OrderBy(data => data.data1.data0.p.Estatus).ThenByDescending(data => data.data1.data0.p.FechaAlta).Select(data => new
                        //    {
                        //        IdProyecto = data.data1.data0.p.IdProyecto,
                        //        FolioProyecto = data.data1.data0.p.FolioProyecto,
                        //        NombreProyecto = data.data1.data0.p.NombreProyecto,
                        //        NombreContacto = data.data1.data0.c.NombreContacto,
                        //        RazonSocial = data.data1.e.Cliente,
                        //        Lider = data.u.NombreCompleto,
                        //        FechaI = data.data1.data0.p.FechaInicio,
                        //        FechaT = data.data1.data0.p.FechaFin,
                        //        Estatus = data.data1.data0.p.Estatus,
                        //        Activo = data.data1.data0.p.Activo,
                        //        FechaAlta = data.data1.data0.p.FechaAlta
                        //    }));

                        using (var DataControl = new SisaEntitie())
                        {
                            var proyects = DataControl.sp_Administracion().Where(a => a.IdUsuario == usuario.IdUsuario);

                            str = JsonConvert.SerializeObject(proyects);
                        }

                        //using (SisaEntitie sisaEntitie = new SisaEntitie())
                        //    str = JsonConvert.SerializeObject((object)sisaEntitie.tblProyectos.Join((IEnumerable<tblClienteContacto>)sisaEntitie.tblClienteContacto, (Expression<Func<tblProyectos, string>>)(p => p.IdCliente), (Expression<Func<tblClienteContacto, string>>)(c => c.idContacto.ToString()), (p, c) => new
                        //    {
                        //        p = p,
                        //        c = c
                        //    }).Join((IEnumerable<tblEmpresas>)sisaEntitie.tblEmpresas, data => data.c.idEmpresa, (Expression<Func<tblEmpresas, Guid>>)(e => e.idEmpresa), (data, e) => new
                        //    {
                        //        data0 = data,
                        //        e = e
                        //    }).Join((IEnumerable<tblUsuarios>)sisaEntitie.tblUsuarios, data => data.data0.p.IdLider, (Expression<Func<tblUsuarios, string>>)(u => u.IdUsuario.ToString()), (data, u) => new
                        //    {
                        //        data1 = data,
                        //        u = u
                        //    }).Where(data => data.data1.data0.p.Activo == (int?)1 && data.data1.data0.p.Estatus != "6" && (data.data1.e.idSucursalRegistro == usuario.idSucursal )).OrderBy(data => data.data1.data0.p.Estatus).ThenByDescending(data => data.data1.data0.p.FechaAlta).Select(data => new
                        //    {
                        //        IdProyecto = data.data1.data0.p.IdProyecto,
                        //        FolioProyecto = data.data1.data0.p.FolioProyecto,
                        //        NombreProyecto = data.data1.data0.p.NombreProyecto,
                        //        NombreContacto = data.data1.data0.c.NombreContacto,
                        //        RazonSocial = data.data1.e.Cliente,
                        //        Lider = data.u.NombreCompleto,
                        //        FechaI = data.data1.data0.p.FechaInicio,
                        //        FechaT = data.data1.data0.p.FechaFin,
                        //        Estatus = data.data1.data0.p.Estatus,
                        //        Activo = data.data1.data0.p.Activo,
                        //        FechaAlta = data.data1.data0.p.FechaAlta,
                        //        LinkSharepoint = data.data1.data0.p.LinkSharepoint
                        //    }));
                    }
                }
                else
                {
                    using (SisaEntitie sisaEntitie = new SisaEntitie())
                    {
                        str = JsonConvert.SerializeObject((object)sisaEntitie.tblProyectos.Join((IEnumerable<tblClienteContacto>)sisaEntitie.tblClienteContacto, (Expression<Func<tblProyectos, string>>)(p => p.IdCliente), (Expression<Func<tblClienteContacto, string>>)(c => c.idContacto.ToString()), (p, c) => new
                        {
                            p = p,
                            c = c
                        }).Join((IEnumerable<tblEmpresas>)sisaEntitie.tblEmpresas, data => data.c.idEmpresa, (Expression<Func<tblEmpresas, Guid>>)(e => e.idEmpresa), (data, e) => new
                        {
                            data0 = data,
                            e = e
                        }).Join((IEnumerable<tblUsuarios>)sisaEntitie.tblUsuarios, data => data.data0.p.IdLider, (Expression<Func<tblUsuarios, string>>)(u => u.IdUsuario.ToString()), (data, u) => new
                        {
                            data1 = data,
                            u = u
                        }).Where(data => data.data1.data0.p.IdProyecto.ToString() == pid && data.data1.data0.p.Activo == (int?)1 && data.data1.data0.p.Estatus != "6").OrderByDescending(data => data.data1.data0.p.FechaAlta).Select(data => new
                        {
                            IdProyecto = data.data1.data0.p.IdProyecto,
                            FolioProyecto = data.data1.data0.p.FolioProyecto,
                            NombreProyecto = data.data1.data0.p.NombreProyecto,
                            NombreContacto = data.data1.data0.c.NombreContacto,
                            RazonSocial = data.data1.e.Cliente,
                            Lider = data.u.NombreCompleto,
                            FechaI = data.data1.data0.p.FechaInicio,
                            FechaT = data.data1.data0.p.FechaFin,
                            Estatus = data.data1.data0.p.Estatus,
                            Activo = data.data1.data0.p.Activo,
                            FechaAlta = data.data1.data0.p.FechaAlta,
                            LinkSharepoint = data.data1.data0.p.LinkSharepoint
                        }));
                    }
                        
                }
            }
            else
            {
                str = "No tienes permiso.";
            }
                    
                
            return str;
        }

        [WebMethod]
        public static string EliminarProyectos(string pid)
        {
            string str = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ProyectosEliminar || rolesUsuarios.Tipo == "ROOT")
            {
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                {
                    tblProyectos tblProyectos = sisaEntitie.tblProyectos.FirstOrDefault<tblProyectos>((Expression<Func<tblProyectos, bool>>)(s => s.IdProyecto.ToString() == pid));
                    if (tblProyectos != null)
                    {
                        tblProyectos.Activo = new int?(0);
                        str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al eliminar proyecto." : "Proyecto eliminado.";
                    }
                }
            }
            else
                str = "No tienes permiso de eliminar proyecto.";
            return str;
        }

        [WebMethod]
        public static string CancelarProyectos(string pid)
        {
            string str = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ProyectosEliminar || rolesUsuarios.Tipo == "ROOT")
            {
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                {
                    tblProyectos tblProyectos = sisaEntitie.tblProyectos.FirstOrDefault<tblProyectos>((Expression<Func<tblProyectos, bool>>)(s => s.IdProyecto.ToString() == pid));
                    if (tblProyectos != null)
                    {
                        tblProyectos.Estatus = "4";
                        str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al cancelar Proyecto." : "Proyecto cancelado.";
                    }
                }
            }
            else
                str = "No tienes permiso de cancelar Proyecto.";
            return str;
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
        public static string ObtenerFechas(string pid)
        {
            string empty = string.Empty;
            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                return JsonConvert.SerializeObject((object)sisaEntitie.tblProyectos.Where<tblProyectos>((Expression<Func<tblProyectos, bool>>)(p => p.IdProyecto.ToString() == pid)).Select(p => new
                {
                    FechaInicio = p.FechaInicio,
                    FechaFin = p.FechaFin
                }));
            }
                
        }

        [WebMethod]
        public static string GuardarFechas(string pid, string Razon, string Inicio, string Fin)
        {
            string str = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ProyectosEditar || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL")
            {
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                {
                    tblProyectos tblProyectos = sisaEntitie.tblProyectos.FirstOrDefault<tblProyectos>((Expression<Func<tblProyectos, bool>>)(a => a.IdProyecto.ToString() == pid));
                    if (tblProyectos != null)
                    {
                        tblProyectos.FechaInicio = new DateTime?(DateTime.Parse(Inicio));
                        tblProyectos.FechaFin = new DateTime?(DateTime.Parse(Fin));
                        tblProyectos.UserProject1 = Razon;
                        sisaEntitie.SaveChanges();
                        str = "Fechas actualizadas.";
                    }
                    else
                        str = "Ocurrio un problema al obtener información, recarga página.";
                }
            }
            else
                str = "No tienes permiso de editar proyectos.";
            return str;
        }

        [WebMethod]
        public static string ActualizaLink(string IdProyecto, string Link)
        {
            string str = string.Empty;

            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;

            if (rolesUsuarios.ProyectosEditar || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL")
            {
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                {
                    tblProyectos tblProyectos = sisaEntitie.tblProyectos.FirstOrDefault<tblProyectos>((Expression<Func<tblProyectos, bool>>)(a => a.IdProyecto.ToString() == IdProyecto));
                    if (tblProyectos != null)
                    {
                        tblProyectos.LinkSharepoint = Link;
                        sisaEntitie.SaveChanges();
                        str = "Link Actualizado.";
                    }
                    else
                        str = "Error";
                }
            }
            else
                str = "No tienes permiso de editar proyectos.";
            return str;
        }

        [WebMethod]
        public static string ActualizarAvance(string pid, string Avance)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.Proyectos == true || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
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

    }
}