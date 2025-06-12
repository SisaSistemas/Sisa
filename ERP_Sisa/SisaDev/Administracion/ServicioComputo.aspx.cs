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
    public partial class ServicioComputo : System.Web.UI.Page
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
        public static string CargarCombosComputo(string Opcion)
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
        public static string ObtenerServicios(string pid)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ServiciosComputo == true || rolesUsuarios.Tipo == "SISTEMAS" || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                using (var DataControl = new SisaEntitie())
                {
                    if(pid == "1")
                    {
                        var Carro = (from cl in DataControl.tblServiciosComputo
                                     select new { cl.IdComputo, cl.PC, cl.Tipo, cl.Comentarios, cl.FechaAlta, cl.FechaProximoMantenimiento, cl.Serie, cl.Activo, cl.Usuario });
                        //var Contacto = DataControl.tblClienteContacto.Select(s => s);
                        retorno = JsonConvert.SerializeObject(Carro);
                        //if (rolesUsuarios.Tipo == "SISTEMAS")
                        //{
                        //    var Carro = (from cl in DataControl.tblServiciosComputo
                        //                 select new { cl.IdComputo, cl.PC, cl.Tipo, cl.Comentarios, cl.FechaAlta , cl.FechaProximoMantenimiento, cl.Serie, cl.Activo, cl.Usuario });
                        //    //var Contacto = DataControl.tblClienteContacto.Select(s => s);
                        //    retorno = JsonConvert.SerializeObject(Carro);
                        //}
                        //else
                        //{
                        //    var Carro = (from cl in DataControl.tblServiciosComputo
                        //                 where cl.IdUsuario == usuario.IdUsuario
                        //                 select new { cl.IdComputo, cl.PC, cl.Tipo, cl.Comentarios, cl.FechaAlta, cl.FechaProximoMantenimiento, cl.Serie, cl.Activo, cl.Usuario });
                        //    //var Contacto = DataControl.tblClienteContacto.Select(s => s);
                        //    retorno = JsonConvert.SerializeObject(Carro);
                        //}
                    }
                    else
                    {
                        var Carro = (from cl in DataControl.tblServiciosComputo
                                     where cl.IdComputo.ToString() == pid
                                     select new { cl.IdComputo, cl.PC, cl.Tipo, cl.Comentarios, cl.FechaAlta , cl.FechaProximoMantenimiento, cl.Serie, cl.Activo, cl.Usuario, cl.IdUsuario });

                        retorno = JsonConvert.SerializeObject(Carro);
                    }
                    
                }
            }
            else
            {
                retorno = "No tienes permiso de ver los servicios de computo.";
            }


            return retorno;
        }

        [WebMethod]
        public static string EliminarServicio(string pid)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.Tipo == "SISTEMAS" || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var ContExiste = DataControl.tblServiciosComputo.FirstOrDefault(s => s.IdComputo.ToString() == pid);
                    if (ContExiste != null)
                    {
                        DataControl.tblServiciosComputo.Remove(ContExiste);
                        if (DataControl.SaveChanges() > 0)
                        {
                            retorno = "Servicio eliminado.";
                        }
                        else
                        {
                            retorno = "Ocurrio un problema al eliminar servicio de computo.";
                        }
                    }
                    else
                    {
                        retorno = "Ocurrio un problema al obtener información de servicio de computo seleccionada.";
                    }
                }
            }
            else
            {
                retorno = "No tienes permiso de eliminar servicio de computo.";
            }

            return retorno;
        }

        [WebMethod]
        public static string GuardarServicio(string PC, string Comentarios, string Tipo, string Serie, string FechaMto, string idUsuario, string NombreUsuario)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.Tipo == "SISTEMAS" || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                using (var DataControl = new SisaEntitie())
                {
                    tblServiciosComputo add = new tblServiciosComputo
                    {
                        IdComputo = Guid.NewGuid(),
                        IdUsuario = Guid.Parse(idUsuario), 
                        IdUsuarioModificacion = usuario.IdUsuario,
                        PC = PC,
                        Comentarios = Comentarios,
                        Tipo = Tipo,
                        Activo = true,
                        FechaAlta = DateTime.Now,
                        FechaModificacion = DateTime.Now,
                        Serie = Serie,
                        FechaProximoMantenimiento = (FechaMto.Length > 0 ? DateTime.Parse(FechaMto) : DateTime.Now ),
                        Usuario = NombreUsuario
                    };
                    DataControl.tblServiciosComputo.Add(add);
                    if (DataControl.SaveChanges() > 0)
                    {
                        retorno = "Computo creado.";
                    }
                    else
                    {
                        retorno = "Ocurrio un problema al guardar servicio de computo.";
                    }
                }
            }
            else
            {
                retorno = "No tienes permiso de agregar servicio de computo.";
            }

            return retorno;
        }

        [WebMethod]
        public static string EditarComputo(string pid, string txtComentariosCerrados, string PC, string Tipo, string Serie, string FechaMto)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.Tipo == "SISTEMAS" || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                using (var DataControl = new SisaEntitie())
                {
                    var ContExiste = DataControl.tblServiciosComputo.FirstOrDefault(s => s.IdComputo.ToString() == pid);
                    if (ContExiste != null)
                    {
                        ContExiste.PC = PC;
                        ContExiste.Tipo = Tipo;
                        ContExiste.Serie = Serie;
                        ContExiste.FechaProximoMantenimiento = (FechaMto.Length > 0 ? DateTime.Parse(FechaMto) : DateTime.Now);
                        
                        ContExiste.Activo = false;
                        ContExiste.Comentarios = ContExiste.Comentarios + "-" + txtComentariosCerrados;
                        if (DataControl.SaveChanges() > 0)
                        {
                            retorno = "Servicio terminado.";
                        }
                        else
                        {
                            retorno = "Ocurrio un problema al cerrar servicio de computo.";
                        }
                    }
                    else
                    {
                        retorno = "Ocurrio un problema al obtener información de servicio de computo seleccionada.";
                    }
                }
            }
            else
            {
                retorno = "No tienes permiso de cerrar servicio de computo.";
            }

            return retorno;
        }
    }
}