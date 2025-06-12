using Newtonsoft.Json;
using SisaDev.Control;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Compras
{
    public partial class Proveedores : System.Web.UI.Page
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
        public static string ObtenerProveedores(string pid)
        {
            string retorno = string.Empty;
            if (pid.Trim() == "2")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var proveedor = (from p in DataControl.tblProveedores
                                     where  p.Activo == 1 //p.idSucursal == usuario.idSucursal
                                     select new { p.IdProveedor, p.NombreComercial, p.Proveedor, p.Contacto, p.Email, p.Telefono1, p.Telefono2, p.Domicilio, p.DiasCredito, p.RFC, p.Usuario, p.Contrasena });

                    retorno = JsonConvert.SerializeObject(proveedor);
                }
            }
            if (Proceso.rolesUsuariosGlobal.Proveedores == true || Proceso.rolesUsuariosGlobal.Tipo == "ROOT")
            {
                if (pid.Trim() == "1")
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        var proveedor = (from p in DataControl.tblProveedores
                                         where  p.Activo == 1 //p.idSucursal == Proceso.usuarioGlobal.idSucursal
                                         select new { p.IdProveedor, p.NombreComercial, p.Proveedor, p.Contacto, p.Email, p.Telefono1, p.Telefono2, p.Domicilio, p.DiasCredito, p.RFC, p.Usuario, p.Contrasena });

                        retorno = JsonConvert.SerializeObject(proveedor);
                    }
                }
                else
                {
                    using (var DataControl = new SisaEntitie())
                    {

                        var proveedore = (from p in DataControl.tblProveedores
                                          where p.IdProveedor.ToString() == pid //&& p.idSucursal == usuario.idSucursal //&& p.Activo == 1
                                          select new { p.IdProveedor, p.NombreComercial, p.Proveedor, p.Contacto, p.Email, p.Telefono1, p.Telefono2, p.Domicilio, p.DiasCredito, p.RFC, p.Usuario, p.Contrasena });

                        retorno = JsonConvert.SerializeObject(proveedore);

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
        public static string GuardarProveedores(string pNombre, string pComercial, string pTelefono, string pCorreo, string pContacto
            , string pDireccion, string pCredito, string pRFC, string pUsuario, string pClave, string pTipoEmpresa)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ProveedoresAgregar == true || rolesUsuarios.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {
                    tblProveedores add = new tblProveedores
                    {
                        IdProveedor = Guid.NewGuid(),
                        Proveedor = pNombre,
                        NombreComercial = pComercial,
                        Telefono1 = pTelefono,
                        Email = pCorreo,
                        Contacto = pContacto,
                        Domicilio = pDireccion,
                        DiasCredito = pCredito.Length == 0 ? 0 : Convert.ToInt32(pCredito),
                        FechaAlta = DateTime.Now,
                        Activo = 1,
                        IdUsuarioAlta = usuario.IdUsuario,
                        IdUsuarioModifica = usuario.IdUsuario,
                        FechaModificacion = DateTime.Now,
                        idSucursal = usuario.idSucursal,
                        RFC = pRFC,
                        Usuario = pUsuario,
                        Contrasena = pClave,
                        PerfilEmpresa = pTipoEmpresa
                    };
                    DataControl.tblProveedores.Add(add);
                    if (DataControl.SaveChanges() > 0)
                    {
                        retorno = "Proveedor creado.";
                    }
                    else
                    {
                        retorno = "Ocurrio un problema al guardar proveedor.";
                    }
                }
            }
            else
            {
                retorno = "No tienes permiso de agregar proveedores.";
            }
            return retorno;
        }

        [WebMethod]
        public static string EliminarProveedores(string pidProveedores)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ProveedoresEliminar == true || rolesUsuarios.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var ProvExiste = DataControl.tblProveedores.FirstOrDefault(s => s.IdProveedor.ToString() == pidProveedores);
                    if (ProvExiste != null)
                    {
                        ProvExiste.Activo = 0;
                        if (DataControl.SaveChanges() > 0)
                        {
                            retorno = "Proveedor eliminado.";
                        }
                        else
                        {
                            retorno = "Ocurrio un problema al eliminar Proveedor.";
                        }
                    }
                    else
                    {
                        retorno = "Ocurrio un problema al obtener información de Proveedor seleccionada.";
                    }
                }
            }
            else
            {
                retorno = "No tienes permiso de eliminar Proveedor.";
            }

            return retorno;
        }
        [WebMethod]
        public static string EditarProveedores(string pid, string pNombre, string pComercial, string pTelefono, string pCorreo, string pContacto
            , string pDireccion, string pCredito, string pRFC, string pUsuario, string pClave, string pTipoEmpresa)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ProveedoresEditar == true || rolesUsuarios.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var Proveedor = DataControl.tblProveedores.FirstOrDefault(s => s.IdProveedor.ToString() == pid.Trim());
                    if (Proveedor != null)
                    {
                        Proveedor.Proveedor = pNombre;
                        Proveedor.Telefono1 = pTelefono;
                        Proveedor.Email = pCorreo;
                        Proveedor.NombreComercial = pComercial;
                        Proveedor.Contacto = pContacto;
                        Proveedor.Domicilio = pDireccion;
                        Proveedor.DiasCredito = Convert.ToInt32(pCredito == "" ? "0" : pCredito);
                        Proveedor.RFC = pRFC;
                        Proveedor.Usuario = pUsuario;
                        Proveedor.Contrasena = pClave;
                        Proveedor.PerfilEmpresa = pTipoEmpresa;
                        if (DataControl.SaveChanges() > 0)
                        {
                            retorno = "Proveedor actualizado.";
                        }
                        else
                        {
                            retorno = "No se realizaron cambios.";
                        }
                    }
                    else
                    {
                        retorno = "No se obtuvo información de Proveedor seleccionado.";
                    }
                }
            }
            else
            {
                retorno = "NO tienes permiso de edición de Proveedor.";
            }
            return retorno;
        }

    }
}