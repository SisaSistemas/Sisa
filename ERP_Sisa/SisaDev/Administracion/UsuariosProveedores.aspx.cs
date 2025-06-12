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
    public partial class UsuariosProveedores : System.Web.UI.Page
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
                        var usuarioProveedor = (from up in DataControl.tblProveedores
                                               join rp in DataControl.tblRolesProveedores
                                               on up.IdProveedor equals rp.IdProveedor
                                               where up.Activo == 1 && (up.Usuario != "" || up.Usuario != null)
                                               select new { up.IdProveedor, up.Proveedor, up.Email, up.Telefono1, up.Usuario }).OrderBy(a => a.Proveedor);
                        //var Contacto = DataControl.tblClienteContacto.Select(s => s);
                        retorno = JsonConvert.SerializeObject(usuarioProveedor);
                    }
                }
                else
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        var usuarioContacto = (from up in DataControl.tblProveedores
                                               join rp in DataControl.tblRolesProveedores
                                               on up.IdProveedor equals rp.IdProveedor
                                               where up.IdProveedor.ToString() == pid
                                               select new
                                               {
                                                   up.IdProveedor,
                                                   up.Email,
                                                   up.Telefono1,
                                                   up.Usuario,
                                                   up.Contrasena,
                                                   Biddings = rp.Biddings,
                                                   BiddingsAgregar = rp.BiddingsAgregar,
                                                   BiddingsEditar = rp.BiddingsEditar,
                                                   BiddingsEliminar = rp.BiddingsEliminar,
                                                   ActivaSitio = rp.ActivaSitio
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
        public static string ObtenerProveedores(string pid)
        {
            string retorno = string.Empty;

            if (pid == "1")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var Proveedores = (from cl in DataControl.tblProveedores
                                       where cl.Activo == 1 && (cl.Usuario == "" || cl.Usuario == null)
                                       select new
                                       {
                                           cl.IdProveedor,
                                           cl.Proveedor,
                                           cl.Email

                                       });
                    retorno = JsonConvert.SerializeObject(Proveedores);
                }
            }
            else
            {
                using (var DataControl = new SisaEntitie())
                {
                    var Proveedores = (from cl in DataControl.tblProveedores
                                       where cl.Activo == 1
                                       select new
                                       {
                                           cl.IdProveedor,
                                           cl.Proveedor,
                                           cl.Email

                                       });
                    retorno = JsonConvert.SerializeObject(Proveedores);
                }
            }
            


            return retorno;
        }

        [WebMethod]
        public static string GuardarUsuarios(string pIdProveedor, string pCorreo, string pUsuario, string pClaveUsuario
            , bool chkBidVer, bool chkBidAdd, bool chkBidEdit, bool chkBidDel)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuario = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuario.UsuariosAgregar == true || rolesUsuario.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var existeContacto = DataControl.tblRolesProveedores.FirstOrDefault(e => e.IdProveedor.ToString() == pIdProveedor);
                    if (existeContacto != null)
                    {
                        existeContacto.Biddings = chkBidVer;
                        existeContacto.BiddingsAgregar = chkBidAdd;
                        existeContacto.BiddingsEditar = chkBidEdit;
                        existeContacto.BiddingsEliminar = chkBidDel;
                        existeContacto.ActivaSitio = true;
                        existeContacto.IdUsuarioModifica = usuario.IdUsuario;
                        existeContacto.FechaModifica = DateTime.Now;

                        if (DataControl.SaveChanges() > 0)
                        {
                            var Contacto = DataControl.tblProveedores.FirstOrDefault(u => u.IdProveedor.ToString() == pIdProveedor);
                            if (Contacto != null)
                            {
                                Contacto.Email = pCorreo;
                                Contacto.Usuario = pUsuario;
                                Contacto.Contrasena = pClaveUsuario;

                                DataControl.SaveChanges();
                                retorno = "Proveedor Modificado.";
                            }
                        }
                    }
                    else
                    {
                        tblRolesProveedores rol = new tblRolesProveedores
                        {
                            IdRolProveedor = Guid.NewGuid(),
                            IdProveedor = Guid.Parse(pIdProveedor),
                            Biddings = chkBidVer,
                            BiddingsAgregar = chkBidAdd,
                            BiddingsEditar = chkBidEdit,
                            BiddingsEliminar = chkBidDel,
                            ActivaSitio = true,
                            IdUsuarioAlta = usuario.IdUsuario,
                            FechaAlta = DateTime.Now,
                            IdUsuarioModifica = usuario.IdUsuario,
                            FechaModifica = DateTime.Now
                        };
                        DataControl.tblRolesProveedores.Add(rol);

                        if (DataControl.SaveChanges() > 0)
                        {
                            var Contacto = DataControl.tblProveedores.FirstOrDefault(u => u.IdProveedor.ToString() == pIdProveedor);
                            if (Contacto != null)
                            {
                                Contacto.Email = pCorreo;
                                Contacto.Usuario = pUsuario;
                                Contacto.Contrasena = pClaveUsuario;

                                DataControl.SaveChanges();
                                retorno = "Proveedor Creado.";
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