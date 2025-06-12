using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Administracion
{
    public partial class UsuariosContactos : System.Web.UI.Page
    {
        public static tblUsuarios usuario;
        public static tblRolesUsuarios rolesUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            if (usuario != null)
            {
                rolesUsuario = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        [WebMethod]
        public static string ObtenerUsuarios(string pid)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuario = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuario.Usuarios == true || rolesUsuario.Tipo == "ROOT")
            {
                if (pid.Trim() == "1")
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        //var Usuario = (from cl in DataControl.tblUsuarios
                        //               join rl in DataControl.tblRolesUsuarios on cl.IdUsuario equals rl.idUsuarios
                        //               join suc in DataControl.tblSucursales on cl.idSucursal equals suc.idSucursa
                        //               where cl.Activo == 1
                        //               select new { cl.IdUsuario, cl.NombreCompleto, cl.Usuario, cl.Telefono, cl.Correo, rl.Tipo, suc.CiudadSucursal }).OrderBy(a => a.NombreCompleto);
                        var usuarioContacto = (from uc in DataControl.tblClienteContacto
                                               join ru in DataControl.tblRolesContactos
                                               on uc.idContacto equals ru.IdContacto
                                               where uc.Estatus == true && uc.Usuario != ""
                                               select new { uc.idContacto, uc.NombreContacto, uc.Usuario, uc.Correo }).OrderBy(a => a.NombreContacto);
                        //var Contacto = DataControl.tblClienteContacto.Select(s => s);
                        retorno = JsonConvert.SerializeObject(usuarioContacto);
                    }
                }
                else
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        var usuarioContacto = (from uc in DataControl.tblClienteContacto
                                               join ru in DataControl.tblRolesContactos
                                               on uc.idContacto equals ru.IdContacto
                                               where uc.idContacto.ToString() == pid
                                               select new
                                               {
                                                   uc.idContacto,
                                                   uc.idEmpresa,
                                                   uc.Estatus,
                                                   uc.Correo,
                                                   uc.Usuario,
                                                   uc.Clave,
                                                   ru.Tipo,
                                                   Cotizaciones = ru.Cotizaciones,
                                                   CotizacionesAgregar = ru.CotizacionesAgregar,
                                                   CotizacionesEditar = ru.CotizacionesEditar,
                                                   CotizacionesEliminar = ru.CotizacionesEliminar,
                                                   Proyectos = ru.Proyectos,
                                                   Paquetes = ru.Paquetes,
                                                   PaquetesAgregar = ru.PaquetesAgregar,
                                                   PaquetesEditar = ru.PaquetesEditar,
                                                   PaquetesEliminar = ru.PaquetesEliminar,
                                                   ActivaSitio = ru.ActivaSitio
                                               });
                        retorno = JsonConvert.SerializeObject(usuarioContacto);

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
        public static string ObtenerEmpresas(string pid)
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                var Empresas = (from cl in DataControl.tblEmpresas
                               where cl.Estatus == true
                               select new
                               {
                                   cl.idEmpresa,
                                   cl.RazonSocial

                               });
                retorno = JsonConvert.SerializeObject(Empresas);
            }


            return retorno;
        }

        [WebMethod]
        public static string ObtenerContactos(string IdEmpresa)
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                var Contactos = (from cl in DataControl.tblClienteContacto
                                where cl.Estatus == true && cl.idEmpresa.ToString() == IdEmpresa
                                select new
                                {
                                    cl.idContacto,
                                    cl.idEmpresa,
                                    cl.NombreContacto,
                                    cl.Correo,
                                    cl.Usuario,
                                    cl.Clave
                                });
                retorno = JsonConvert.SerializeObject(Contactos);
            }


            return retorno;
        }

        [WebMethod]
        public static string GuardarUsuarios(string pIdContacto, string pCorreo, string pUsuario, string pClaveUsuario, string pTipo
            , int pchkCotiVer, int pchkCotiAdd, int pchkCotiEdit, int pchkCotiDel, int pchkProyectosVer, int pchkPaquetesVer
            , int pchkPaquetesAdd, int pchkPaquetesEdit, int pchkPaquetesDel)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuario = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuario.UsuariosAgregar == true || rolesUsuario.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var existeContacto = DataControl.tblRolesContactos.FirstOrDefault(e => e.IdContacto.ToString() == pIdContacto);
                    if (existeContacto != null)
                    {
                        existeContacto.Tipo = pTipo;
                        existeContacto.Cotizaciones = pchkCotiVer;
                        existeContacto.CotizacionesAgregar = pchkCotiAdd;
                        existeContacto.CotizacionesEditar = pchkCotiEdit;
                        existeContacto.CotizacionesEliminar = pchkCotiDel;
                        existeContacto.Proyectos = pchkProyectosVer;
                        existeContacto.Paquetes = pchkPaquetesVer;
                        existeContacto.PaquetesAgregar = pchkPaquetesAdd;
                        existeContacto.PaquetesEditar = pchkPaquetesEdit;
                        existeContacto.PaquetesEliminar = pchkPaquetesDel;
                        existeContacto.ActivaSitio = 1;
                        existeContacto.IdUsuarioModifica = usuario.IdUsuario;
                        existeContacto.FechaModifica = DateTime.Now;

                        if (DataControl.SaveChanges() > 0)
                        {
                            var Contacto = DataControl.tblClienteContacto.FirstOrDefault(u => u.idContacto.ToString() == pIdContacto);
                            if (Contacto != null)
                            {
                                Contacto.Correo = pCorreo;
                                Contacto.Usuario = pUsuario;
                                Contacto.Clave = pClaveUsuario;

                                DataControl.SaveChanges();
                                retorno = "Contacto Modificado.";
                            }
                        }
                    }
                    else
                    {
                        tblRolesContactos rol = new tblRolesContactos
                        {
                            IdRolContacto = Guid.NewGuid(),
                            IdContacto = Guid.Parse(pIdContacto),
                            Tipo = pTipo,
                            Cotizaciones = pchkCotiVer,
                            CotizacionesAgregar = pchkCotiAdd,
                            CotizacionesEditar = pchkCotiEdit,
                            CotizacionesEliminar = pchkCotiDel,
                            Proyectos = pchkProyectosVer,
                            Paquetes = pchkPaquetesVer,
                            PaquetesAgregar = pchkPaquetesAdd,
                            PaquetesEditar = pchkPaquetesEdit,
                            PaquetesEliminar = pchkPaquetesDel,
                            ActivaSitio = 1,
                            IdUsuarioAlta = usuario.IdUsuario,
                            FechaAlta = DateTime.Now,
                            IdUsuarioModifica = usuario.IdUsuario,
                            FechaModifica = DateTime.Now
                        };
                        DataControl.tblRolesContactos.Add(rol);

                        if (DataControl.SaveChanges() > 0)
                        {
                            var Contacto = DataControl.tblClienteContacto.FirstOrDefault(u => u.idContacto.ToString() == pIdContacto);
                            if (Contacto != null)
                            {
                                Contacto.Correo = pCorreo;
                                Contacto.Usuario = pUsuario;
                                Contacto.Clave = pClaveUsuario;

                                DataControl.SaveChanges();
                                retorno = "Contacto creado.";
                            }

                        }
                        else
                        {
                            retorno = "Error al agregar los roles de usuario, contácta el administrador del sistema.";
                        }
                    }
                    
                }
            }
            else
            {
                retorno = "No tienes permiso para agregar usuarios.";
            }

            return retorno;
        }
    }
}