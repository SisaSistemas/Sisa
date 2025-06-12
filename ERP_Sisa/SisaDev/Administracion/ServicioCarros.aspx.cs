using Newtonsoft.Json;
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
    public partial class ServicioCarros : System.Web.UI.Page
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
        public static string ObtenerCarros(string pid)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ServiciosCarro == true || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                if (pid.Trim() == "1")
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        var Carro = (from cl in DataControl.tblVehiculos
                                     where cl.Activo > 0
                                        select new { cl.IdCarro, cl.Vehiculo, cl.Anio, cl.Comentarios, cl.FechaAlta });
                        //var Contacto = DataControl.tblClienteContacto.Select(s => s);
                        retorno = JsonConvert.SerializeObject(Carro);
                    }
                }
                else
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        var Carro = (from cl in DataControl.tblVehiculos
                                        where cl.IdCarro.ToString() == pid
                                        select new { cl.IdCarro, cl.Vehiculo, cl.Anio, cl.Comentarios, cl.FechaAlta });
                        //var Contacto = DataControl.tblClienteContacto.Select(s => s);
                        retorno = JsonConvert.SerializeObject(Carro);
                    }
                }
            }
            else
            {
                retorno = "No tienes permiso de ver los automoviles";
            }


            return retorno;
        }

        [WebMethod]
        public static string EliminarCarro(string pid)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var ContExiste = DataControl.tblVehiculos.FirstOrDefault(s => s.IdCarro.ToString() == pid);
                    if (ContExiste != null)
                    {
                        ContExiste.Activo = 0;
                        if (DataControl.SaveChanges() > 0)
                        {
                            retorno = "Carro eliminado.";
                        }
                        else
                        {
                            retorno = "Ocurrio un problema al eliminar carro.";
                        }
                    }
                    else
                    {
                        retorno = "Ocurrio un problema al obtener información de carro seleccionada.";
                    }
                }
            }
            else
            {
                retorno = "No tienes permiso de eliminar carro.";
            }

            return retorno;
        }

        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string GuardarCarro(string pCarro, string pAno, string cComentarios)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                using (var DataControl = new SisaEntitie())
                {
                    tblVehiculos add = new tblVehiculos
                    {
                        IdCarro = Guid.NewGuid(),
                        Anio = int.Parse(pAno),
                        Comentarios = cComentarios,
                        Vehiculo = pCarro,
                        Activo = 1,
                        IdUsuario = usuario.IdUsuario,
                        IdUsuarioModificacion = usuario.IdUsuario,
                        FechaAlta = DateTime.Now,
                        FechaModificacion = DateTime.Now
                        
                    };
                    DataControl.tblVehiculos.Add(add);
                    if (DataControl.SaveChanges() > 0)
                    {
                        retorno = "Carro creado.";
                    }
                    else
                    {
                        retorno = "Ocurrio un problema al guardar carro.";
                    }
                }
            }
            else
            {
                retorno = "No tienes permiso de agregar carro.";
            }

            return retorno;
        }

        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string EditarCarro(string pid, string cComentarios)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var Carro = DataControl.tblVehiculos.FirstOrDefault(s => s.IdCarro.ToString() == pid.Trim());
                    if (Carro != null)
                    {
                        Carro.Comentarios = cComentarios;
                        if (DataControl.SaveChanges() > 0)
                        {
                            retorno = "Carro actualizada.";
                        }
                        else
                        {
                            retorno = "No se realizaron cambios.";
                        }
                    }
                    else
                    {
                        retorno = "No se obtuvo información de carro seleccionado.";
                    }
                }
            }
            else
            {
                retorno = "NO tienes permiso de edición de carros.";
            }
            return retorno;
        }

        [WebMethod]
        public static string CargarServicios(string pid)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ServiciosCarro == true || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var Carro = (from cl in DataControl.tblVehiculoServicio
                                 where cl.IdCarro.ToString() == pid
                                 select new { cl.IdCarro, cl.IdServicioVehiculo, cl.KilometrajeActual, cl.KilometrajeProximo, FechaServicio = cl.FechaServicio.Day.ToString() + "/" + cl.FechaServicio.Month.ToString() + "/" + cl.FechaServicio.Year.ToString(), cl.Taller, cl.TipoServicio });
                    retorno = JsonConvert.SerializeObject(Carro);
                }
            }
            else
            {
                retorno = "No tienes permiso de ver los automoviles";
            }


            return retorno;
        }

        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string GuardarServicio(string pid, string pkmAc, string pKmpro, string pTaller, string pTipo, string pFecha)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                using (var DataControl = new SisaEntitie())
                {
                    tblVehiculoServicio add = new tblVehiculoServicio
                    {
                        IdServicioVehiculo = Guid.NewGuid(),
                        IdCarro = Guid.Parse(pid),
                        IdUsuario = usuario.IdUsuario,
                        IdUsuarioModificacion = usuario.IdUsuario,
                        FechaAlta = DateTime.Now,
                        FechaModificacion = DateTime.Now,
                        FechaServicio = DateTime.Parse(pFecha),
                        KilometrajeActual = int.Parse(pkmAc), 
                        KilometrajeProximo = int.Parse(pKmpro),
                        Taller = pTaller,
                        TipoServicio = pTipo
                    };
                    DataControl.tblVehiculoServicio.Add(add);
                    if (DataControl.SaveChanges() > 0)
                    {
                        retorno = "Servicio creado.";
                    }
                    else
                    {
                        retorno = "Ocurrio un problema al guardar servicio.";
                    }
                }
            }
            else
            {
                retorno = "No tienes permiso de agregar servicio.";
            }

            return retorno;
        }
    }
}