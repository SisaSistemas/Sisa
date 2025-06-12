using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Clientes
{
    public partial class Empresas : System.Web.UI.Page
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
        public static string ObtenerEmpresas(string pid)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (pid.Trim() == "2")
            {
                //using (var DataControl = new SisaEntitie())
                //{

                //    var Empresas = DataControl.tblEmpresas.Where(s => s.Estatus == true && s.idSucursalRegistro == usuario.idSucursal).OrderBy(a => a.RazonSocial);
                //    return JsonConvert.SerializeObject(Empresas);
                //}
                //string retorno = string.Empty;
                using (var DataControl = new SisaEntitie())
                {
                    if (rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "ADMINISTRACION" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "COMPRAS")
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
            }
            if (rolesUsuarios.ClienteEmpresa == true || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "ADMINISTRACION" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "COMPRAS")
            {
                if (pid.Trim() == "1")
                {
                    //using (var DataControl = new SisaEntitie())
                    //{
                    //    var Empresas = DataControl.tblEmpresas.Where(s => s.idSucursalRegistro == usuario.idSucursal).OrderBy(a=> a.RazonSocial);
                    //    retorno = JsonConvert.SerializeObject(Empresas);
                    //}
                    //string retorno = string.Empty;
                    using (var DataControl = new SisaEntitie())
                    {
                        if (rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "ADMINISTRACION" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "COMPRAS")
                        {
                            var Empresas = DataControl.tblEmpresas.Where(s => s.Estatus == true);
                            retorno = JsonConvert.SerializeObject(Empresas);
                        }
                        else
                        {
                            var Empresas = DataControl.tblEmpresas.Where(s => s.Estatus == true);
                            retorno = JsonConvert.SerializeObject(Empresas);
                        }

                    }

                    return retorno;
                }
                else
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        var Empresas = DataControl.tblEmpresas.FirstOrDefault(s => s.idEmpresa.ToString() == pid);
                        retorno = JsonConvert.SerializeObject(Empresas);
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
        public static string GuardarEmpresa(string pRZ, string pDireccion, string pTelefono, string pRFC, string pCorreo, string pCP, string pCiudad, string pCliente)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ClienteEmpresaAgregar == true || rolesUsuarios.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {
                    tblEmpresas add = new tblEmpresas
                    {
                        idEmpresa = Guid.NewGuid(),
                        RazonSocial = pRZ,
                        DireccionFiscal = pDireccion,
                        Telefono = pTelefono,
                        TIMESTAMP = DateTime.Now,
                        RFC = pRFC,
                        Correo = pCorreo,
                        CP = Convert.ToInt32(pCP),
                        Ciudad = pCiudad,
                        Estatus = true,
                        idSucursalRegistro = usuario.idSucursal,
                        Cliente = pCliente
                    };
                    DataControl.tblEmpresas.Add(add);
                    if (DataControl.SaveChanges() > 0)
                    {
                        retorno = "Empresa creada.";
                    }
                    else
                    {
                        retorno = "Ocurrio un problema al guardar empresa.";
                    }
                }
            }
            else
            {
                retorno = "No tienes permiso de agregar empresas.";
            }
            
            return retorno;
        }

        [WebMethod]
        public static string EliminarEmpresa(string pidEmpresa)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ClienteEmpresaEliminar == true || rolesUsuarios.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var EmpExiste = DataControl.tblEmpresas.FirstOrDefault(s => s.idEmpresa.ToString() == pidEmpresa);
                    if (EmpExiste != null)
                    {
                        EmpExiste.Estatus = false;
                        if (DataControl.SaveChanges() > 0)
                        {
                            retorno = "Empresa eliminada.";
                        }
                        else
                        {
                            retorno = "Ocurrio un problema al eliminar empresa, ya esta inactiva.";
                        }
                    }
                    else
                    {
                        retorno = "Ocurrio un problema al obtener información de empresa seleccionada.";
                    }
                }
            }
            else
            {
                retorno = "No tienes permiso de eliminar empresas.";
            }
            
            return retorno;
        }

        [WebMethod]
        public static string EditarEmpresa(string pid, string pRZ, string pDireccion, string pTelefono, string pRFC, string pCorreo, string pCP, string pCiudad, string pCliente)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ClienteEmpresaEditar == true || rolesUsuarios.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var Empresas = DataControl.tblEmpresas.FirstOrDefault(s => s.idEmpresa.ToString() == pid.Trim());
                    if (Empresas != null)
                    {
                        Empresas.RazonSocial = pRZ;
                        Empresas.DireccionFiscal = pDireccion;
                        Empresas.Telefono = pTelefono;
                        Empresas.RFC = pRFC;
                        Empresas.Correo = pCorreo;
                        Empresas.CP = Convert.ToInt32(pCP);
                        Empresas.Ciudad = pCiudad;
                        Empresas.Cliente = pCliente;
                        if (DataControl.SaveChanges() > 0)
                        {
                            retorno = "Emrpesa actualizada.";
                        }
                        else
                        {
                            retorno = "No se realizaron cambios.";
                        }
                    }
                    else
                    {
                        retorno = "No se obtuvo información de empresa seleccionada.";
                    }
                }
            }
            else
            {
                retorno = "NO tienes permiso de edición de empresas.";
            }
            

            return retorno;
        }

        [WebMethod]
        public static string ActivarEmpresa(string pidEmpresa)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ClienteEmpresaEditar == true || rolesUsuarios.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var EmpExiste = DataControl.tblEmpresas.FirstOrDefault(s => s.idEmpresa.ToString() == pidEmpresa);
                    if (EmpExiste != null)
                    {
                        EmpExiste.Estatus = true;
                        if (DataControl.SaveChanges() > 0)
                        {
                            retorno = "Empresa activada.";
                        }
                        else
                        {
                            retorno = "Ocurrio un problema al activar empresa, ya esta activa.";
                        }
                    }
                    else
                    {
                        retorno = "Ocurrio un problema al obtener información de empresa seleccionada.";
                    }
                }
            }
            else
            {
                retorno = "No tienes permiso de editar empresas.";
            }

            return retorno;
        }
    }
}