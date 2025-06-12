using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace SisaDev.Administracion
{
    public partial class Sucursales : System.Web.UI.Page
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
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string ObtenerSucursales(string pid)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuario = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (pid.Trim() == "2")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var Sucursales = DataControl.tblSucursales.Where(s => s.Estatus == true);
                    return JsonConvert.SerializeObject(Sucursales);
                }
            }
            if (rolesUsuario.Sucursales == true || rolesUsuario.Tipo == "ROOT")
            {
                if (pid.Trim() == "1")
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        var Sucursales = DataControl.tblSucursales.Where(s => s.Estatus == true);
                        retorno = JsonConvert.SerializeObject(Sucursales);
                    }
                }
                else
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        var Sucursales = DataControl.tblSucursales.FirstOrDefault(s => s.idSucursa.ToString() == pid);

                        retorno = JsonConvert.SerializeObject(Sucursales);
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
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string GuardarSucursal(string pCiudad, string pTelefono, string pDireccion, string pGerente, string pColonia, string pCP)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuario = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuario.SucursalesAgregar == true || rolesUsuario.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {
                    tblSucursales add = new tblSucursales
                    {
                        idSucursa = Guid.NewGuid(),
                        CiudadSucursal = pCiudad,
                        TelefonoSucursal = pTelefono,
                        DireccionSucursal = pDireccion,
                        ColoniaSucursal = pColonia,
                        CPSucursal = pCP,
                        Estatus = true,
                        Gerente = pGerente,
                        TIMESTAMP = DateTime.Now
                        
                    };
                    DataControl.tblSucursales.Add(add);
                    if (DataControl.SaveChanges() > 0)
                    {
                        retorno = "Sucursal creada.";
                    }
                    else
                    {
                        retorno = "Ocurrio un problema al guardar sucursal.";
                    }
                }
            }
            else
            {
                retorno = "No tienes permiso de crear sucursal.";
            }
            
            return retorno;
        }

        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string EliminarSucursal(string pidSucursal)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuario = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuario.SucursalesEliminar == true || rolesUsuario.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var SucExiste = DataControl.tblSucursales.FirstOrDefault(s => s.idSucursa.ToString() == pidSucursal);
                    if (SucExiste != null)
                    {
                        SucExiste.Estatus = false;
                        if (DataControl.SaveChanges() > 0)
                        {
                            retorno = "Sucursal eliminada.";
                        }
                        else
                        {
                            retorno = "Ocurrio un problema al eliminar sucursal.";
                        }
                    }
                    else
                    {
                        retorno = "Ocurrio un problema al obtener información de sucursal seleccionada.";
                    }
                }
            }
            else
            {
                retorno = "No tienes permiso de dar de baja sucursales.";
            }
           
            return retorno;
        }

        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string EditarSucursal(string pid, string pCiudad, string pDireccion, string pTelefono, string pGerente, string pColonia, string pCP)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuario = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuario.SucursalesEditar == true || rolesUsuario.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var Sucursales = DataControl.tblSucursales.FirstOrDefault(s => s.idSucursa.ToString() == pid.Trim());
                    if (Sucursales != null)
                    {
                        Sucursales.DireccionSucursal = pDireccion;
                        Sucursales.TelefonoSucursal = pTelefono;
                        Sucursales.Gerente = pGerente;
                        Sucursales.ColoniaSucursal = pColonia;
                        Sucursales.CPSucursal = pCP;

                        if (DataControl.SaveChanges() > 0)
                        {
                            retorno = "Sucursal actualizada.";
                        }
                        else
                        {
                            retorno = "No se detectaron cambios.";
                        }
                    }
                    else
                    {
                        retorno = "No se obtuvo información de sucursal seleccionada.";
                    }
                }
            }
            else
            {
                retorno = "No tienes permiso de edición.";
            }
                     
            
            return retorno;
        }
    }    
}