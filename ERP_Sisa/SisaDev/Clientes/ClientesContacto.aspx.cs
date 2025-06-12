using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Clientes
{
    public partial class ClientesContacto : System.Web.UI.Page
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
        public static string ObtenerContactos(string pid)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ClienteContacto == true || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                if (pid.Trim() == "1")
                {
                    if(rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "ADMINISTRACION")
                    {
                        using (var DataControl = new SisaEntitie())
                        {
                            var Contacto = (from cl in DataControl.tblClienteContacto
                                            join em in DataControl.tblEmpresas on cl.idEmpresa equals em.idEmpresa
                                            //where em.idSucursalRegistro == usuario.idSucursal
                                            select new { cl.idContacto, cl.NombreContacto, cl.Telefono, cl.Correo, em.Cliente, em.idEmpresa, cl.Usuario, cl.Clave, cl.Estatus });
                            //var Contacto = DataControl.tblClienteContacto.Select(s => s);
                            retorno = JsonConvert.SerializeObject(Contacto.OrderBy(a => a.NombreContacto));
                        }
                    }
                    else
                    {
                        using (var DataControl = new SisaEntitie())
                        {
                            var Contacto = (from cl in DataControl.tblClienteContacto
                                            join em in DataControl.tblEmpresas on cl.idEmpresa equals em.idEmpresa
                                            //where em.idSucursalRegistro == usuario.idSucursal
                                            select new { cl.idContacto, cl.NombreContacto, cl.Telefono, cl.Correo, em.Cliente, em.idEmpresa, cl.Usuario, cl.Clave, cl.Estatus });
                            //var Contacto = DataControl.tblClienteContacto.Select(s => s);
                            retorno = JsonConvert.SerializeObject(Contacto.OrderBy(a => a.NombreContacto));
                        }
                    }
                }
                else
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        var Contacto = (from cl in DataControl.tblClienteContacto
                                        join em in DataControl.tblEmpresas on cl.idEmpresa equals em.idEmpresa
                                        where cl.idContacto.ToString() == pid
                                        select new { cl.idContacto, cl.NombreContacto, cl.Telefono, cl.Correo, em.RazonSocial, em.idEmpresa, cl.Usuario, cl.Clave, cl.Estatus });
                        retorno = JsonConvert.SerializeObject(Contacto);
                    }
                }
            }
            else
            {
                retorno = "No tienes permiso de ver los contactos de clientes";
            }
            

            return retorno;
        }

        [WebMethod]
        public static string GuardarContacto(string pNombre, string pTelefono, string pCorreo, string pEmpresa, string pUsuario, string pClave)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ClienteContactoAgrear == true || rolesUsuarios.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {
                    tblClienteContacto add = new tblClienteContacto
                    {
                        idContacto = Guid.NewGuid(),
                        NombreContacto = pNombre,
                        Telefono = pTelefono,
                        Correo = pCorreo,
                        TIMESTAMP = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),                        
                        Estatus = true,
                        Usuario = pUsuario,
                        Clave = pClave,
                        idEmpresa = Guid.Parse(pEmpresa)
                    };
                    DataControl.tblClienteContacto.Add(add);
                    if (DataControl.SaveChanges() > 0)
                    {
                        retorno = "Contacto creado.";
                    }
                    else
                    {
                        retorno = "Ocurrio un problema al guardar contacto.";
                    }
                }
            }
            else
            {
                retorno = "No tienes permiso de agregar contactos.";
            }

            return retorno;
        }

        [WebMethod]
        public static string EliminarContacto(string pidContacto)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ClienteContactoEliminar == true || rolesUsuarios.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var ContExiste = DataControl.tblClienteContacto.FirstOrDefault(s => s.idContacto.ToString() == pidContacto);
                    if (ContExiste != null)
                    {
                        ContExiste.Estatus = false;
                        if (DataControl.SaveChanges() > 0)
                        {
                            retorno = "Contacto eliminado.";
                        }
                        else
                        {
                            retorno = "Ocurrio un problema al eliminar Contacto, ya esta inactivo.";
                        }
                    }
                    else
                    {
                        retorno = "Ocurrio un problema al obtener información de Contacto seleccionada.";
                    }
                }
            }
            else
            {
                retorno = "No tienes permiso de eliminar Contacto.";
            }

            return retorno;
        }

        [WebMethod]
        public static string ActivarContacto(string pidContacto)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ClienteContactoEditar == true || rolesUsuarios.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var ContExiste = DataControl.tblClienteContacto.FirstOrDefault(s => s.idContacto.ToString() == pidContacto);
                    if (ContExiste != null)
                    {
                        ContExiste.Estatus = true;
                        if (DataControl.SaveChanges() > 0)
                        {
                            retorno = "Contacto activada.";
                        }
                        else
                        {
                            retorno = "Ocurrio un problema al activar Contacto, ya esta activo.";
                        }
                    }
                    else
                    {
                        retorno = "Ocurrio un problema al obtener información de Contacto seleccionada.";
                    }
                }
            }
            else
            {
                retorno = "No tienes permiso de activar Contacto.";
            }

            return retorno;
        }

        [WebMethod]
        public static string EditarContacto(string pid, string pNombre, string pTelefono, string pCorreo, string pUsuario, string pClave, string idEmpresa)
        {
            string str = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ClienteContactoEditar || rolesUsuarios.Tipo == "ROOT")
            {
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                {
                    tblClienteContacto tblClienteContacto = ((IQueryable<tblClienteContacto>)sisaEntitie.tblClienteContacto).FirstOrDefault<tblClienteContacto>((Expression<Func<tblClienteContacto, bool>>)(s => s.idContacto.ToString() == pid.Trim()));
                    if (tblClienteContacto != null)
                    {
                        Guid guid = Guid.Parse(idEmpresa);
                        tblClienteContacto.NombreContacto = pNombre;
                        tblClienteContacto.Telefono = pTelefono;
                        tblClienteContacto.Correo = pCorreo;
                        tblClienteContacto.Usuario = pUsuario;
                        tblClienteContacto.Clave = pClave;
                        tblClienteContacto.idEmpresa = guid;
                        str = sisaEntitie.SaveChanges() <= 0 ? "No se realizaron cambios." : "Contacto actualizada.";
                    }
                    else
                        str = "No se obtuvo información de Contacto seleccionado.";
                }
            }
            else
                str = "NO tienes permiso de edición de Contacto.";
            return str;
        }

        [WebMethod]
        public static string ObtenerEmpresas(string pid)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            using (var DataControl = new SisaEntitie())
            {
                if (rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "ADMINISTRACION" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "COMPRAS" || rolesUsuarios.Tipo == "VENTAS")
                {
                    var Empresas = DataControl.tblEmpresas.Where(s => s.Estatus == true);
                    retorno = JsonConvert.SerializeObject(Empresas);
                }
                else
                {
                    var Empresas = DataControl.tblEmpresas.Where(s => s.Estatus == true && s.idSucursalRegistro == usuario.idSucursal);
                    retorno = JsonConvert.SerializeObject(Empresas);
                }

            }

            return retorno;
            //string retorno = string.Empty;
            //using (var DataControl = new SisaEntitie())
            //{
            //    var Empresas = DataControl.tblEmpresas.Where(s => s.Estatus == true && s.idSucursalRegistro == usuario.idSucursal);
            //    retorno =  JsonConvert.SerializeObject(Empresas);
            //}

            //return retorno;
        }
    }
}