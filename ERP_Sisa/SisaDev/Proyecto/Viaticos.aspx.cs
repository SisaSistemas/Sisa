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

namespace SisaDev.Proyectos
{
    public partial class Viaticos : System.Web.UI.Page
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
        public static string ObtenerViaticos(string pid)
        {
            string str = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;

            if (pid.Trim() == "2")
            {
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                {
                    str = JsonConvert.SerializeObject((object)sisaEntitie.sp_CargaListaViaticos());
                }
            }
            if (rolesUsuarios.Viaticos || rolesUsuarios.Administracion || rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                if (pid.Trim() == "1")
                {
                    if (rolesUsuarios.Tipo == "ROOT")
                    {
                        using (SisaEntitie sisaEntitie = new SisaEntitie())
                        {
                            str = JsonConvert.SerializeObject(sisaEntitie.sp_CargaListaViaticos());
                        }
                    }
                    else if (rolesUsuarios.Tipo == "ADMINISTRACION")
                    { 
                        if (usuario.Usuario == "cgarcia")
                        {
                            Guid sucursalIrapuato = Guid.Parse("AED5D6F1-86F9-4148-8A45-F97F4AD140A5");

                            using (SisaEntitie sisaEntitie = new SisaEntitie())
                            {
                                str = JsonConvert.SerializeObject(sisaEntitie.sp_CargaListaViaticos().Where(a => a.idSucursal == usuario.idSucursal || a.idSucursal == sucursalIrapuato));
                            }
                        }
                        else
                        {
                            using (SisaEntitie sisaEntitie = new SisaEntitie())
                            {
                                str = JsonConvert.SerializeObject(sisaEntitie.sp_CargaListaViaticos().Where(a => a.idSucursal == usuario.idSucursal));
                            }
                        }
                        
                    }
                    else
                    {
                        using (SisaEntitie sisaEntitie = new SisaEntitie())
                        {
                            str = JsonConvert.SerializeObject(sisaEntitie.sp_CargaListaViaticos().Where(A => A.IdUsuario == usuario.IdUsuario));
                        }
                    }
                    //using (SisaEntitie sisaEntitie = new SisaEntitie())
                    //{
                    //    str = rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "ADMINISTRACION" ? JsonConvert.SerializeObject((object)sisaEntitie.sp_CargaListaViaticos()) : JsonConvert.SerializeObject((object)sisaEntitie.sp_CargaListaViaticos().Where<sp_CargaListaViaticos_Result>((Func<sp_CargaListaViaticos_Result, bool>)(A => A.IdUsuario == usuario.IdUsuario)));
                    //}
                }
                else
                {
                    using (SisaEntitie sisaEntitie = new SisaEntitie())
                    {
                        str = JsonConvert.SerializeObject((object)sisaEntitie.sp_CargaListaViaticos().FirstOrDefault<sp_CargaListaViaticos_Result>((Func<sp_CargaListaViaticos_Result, bool>)(a => a.ID.ToString() == pid)));
                    }
                }
            }
            else
            {
                str = "No tienes permiso de lectura en los viaticos.";
            }
            return str;
            
        }


        [WebMethod]
        public static string CargarProyectos(string pid)
        {
            string str = string.Empty;
            if (pid.Trim() == "2")
            {
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                    str = JsonConvert.SerializeObject((object)sisaEntitie.tblProyectos.Where<tblProyectos>((Expression<Func<tblProyectos, bool>>)(a => a.Activo == (int?)1)).Select(a => new
                    {
                        IdProyecto = a.IdProyecto,
                        NombreProyecto = a.NombreProyecto,
                        FolioProyecto = a.FolioProyecto
                    }));
            }
            
            return str;
        }

        [WebMethod]
        public static string CargarUsuarios(string pid)
        {
            string str = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (pid.Trim() == "2")
            {
                using (var DataControl = new SisaEntitie())
                {
                    using (SisaEntitie sisaEntitie = new SisaEntitie())
                        str = JsonConvert.SerializeObject((object)sisaEntitie.tblUsuarios.Where<tblUsuarios>((Expression<Func<tblUsuarios, bool>>)(a => a.Activo == (int?)1)).Select(a => new
                        {
                            IdUsuario = a.IdUsuario,
                            NombreCompleto = a.NombreCompleto
                        }));
                }
            }

            return str;
        }

        [WebMethod]
        public static string GuardarViatico(string Usuario, string Proyecto, string Cantidad, string Concepto, string Comentarios, string FechaViatico)
        {
            string str = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                {
                    tblViaticos entity = new tblViaticos()
                    {
                        ID = Guid.NewGuid(),
                        IdProyecto = new Guid?(Guid.Parse(Proyecto)),
                        IdUsuario = Guid.Parse(Usuario),
                        CantEntregada = Decimal.Parse(Cantidad),
                        CantGastada = 0M,
                        Estatus = new int?(1),
                        FechaAlta = DateTime.Now,
                        FechaCaptura = new DateTime?(DateTime.Parse(FechaViatico)),
                        Concepto = Concepto,
                        Comentarios = Comentarios
                    };
                    sisaEntitie.tblViaticos.Add(entity);
                    str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al guardar viaticos." : "Viatico creado.";
                }
            }
            else
                str = "No tienes permiso de agregar viaticos.";
            return str;
        }

        [WebMethod]
        public static string EliminarViaticos(string pid)
        {
            string str = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "ADMINISTRACION")
            {
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                {
                    if (sisaEntitie.tblViaticosDet.FirstOrDefault<tblViaticosDet>((Expression<Func<tblViaticosDet, bool>>)(v => v.IdViaticos.ToString() == pid)) != null)
                    {
                        str = "Se encontraron gastos registrados dentro de viático seleccionado, favor de eliminar primero los gastos y despues el viático proporcionado.";
                    }
                    else
                    {
                        tblViaticos entity = sisaEntitie.tblViaticos.FirstOrDefault<tblViaticos>((Expression<Func<tblViaticos, bool>>)(v => v.ID.ToString() == pid));
                        if (entity != null)
                        {
                            sisaEntitie.tblViaticos.Remove(entity);
                            sisaEntitie.SaveChanges();
                            str = "Viatico eliminado.";
                        }
                        else
                            str = "Ocurrio un problema al buscar viático, recarga página e intenta de nuevo.";
                    }
                }
            }
            else
                str = "No tienes permiso de eliminar viático.";
            return str;
        }

        [WebMethod]
        public static string Cargar(string IdViatico)
        {
            string empty = string.Empty;
            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                return JsonConvert.SerializeObject((object)((IEnumerable<sp_LoadViaticos_Result>)sisaEntitie.sp_LoadViaticos(IdViatico)).OrderBy<sp_LoadViaticos_Result, DateTime?>((Func<sp_LoadViaticos_Result, DateTime?>)(s => s.FechaViaticos)));
            }

        }

        [WebMethod]
        public static string CargarCombos(string Opcion)
        {

            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                int int32 = Convert.ToInt32(Opcion);
                return JsonConvert.SerializeObject((object)sisaEntitie.sp_CargaCombos(new int?(int32)));
            }

        }

    }
}