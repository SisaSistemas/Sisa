using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace SisaDev.Administracion
{
    public partial class ProyectoDetallesAdmin : System.Web.UI.Page
    {
        public static tblUsuarios usuario;
        public static tblRolesUsuarios rolesUsuarios;
        public static string idProyecto = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            if (usuario != null)
            {
                rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
                idProyecto = this.Request.QueryString["id"];
                idProyectoDetalle.Value = idProyecto;
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                {
                    tblProyectos tblProyectos = sisaEntitie.tblProyectos.FirstOrDefault<tblProyectos>((Expression<Func<tblProyectos, bool>>)(p => p.IdProyecto.ToString() == ProyectoDetallesAdmin.idProyecto));
                    lblProyectoTarea.InnerText = tblProyectos.FolioProyecto + " " + tblProyectos.NombreProyecto + " Descripción: " + tblProyectos.Descripcion;
                    this.lblFolio.InnerText = tblProyectos.NombreProyecto;
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
                
        }

        [WebMethod]
        public static string CargarDatos(string IdProyecto, string Opcion)
        {
            string empty = string.Empty;
            try
            {
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                    return JsonConvert.SerializeObject((object)sisaEntitie.sp_CargarDetalleProyecto(IdProyecto, new int?(Convert.ToInt32(Opcion))));
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        [WebMethod]
        public static string CargarComentarios(string IdProyecto, string Opcion)
        {
            string empty = string.Empty;
            try
            {
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                    return JsonConvert.SerializeObject((object)sisaEntitie.sp_CargarDetalleProyecto(IdProyecto, new int?(Convert.ToInt32(Opcion))));
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        [WebMethod]
        public static string CargarGrafica(string IdProyecto)
        {
            string empty = string.Empty;
            try
            {
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                    return JsonConvert.SerializeObject((object)sisaEntitie.sp_GraficaUtilidad(IdProyecto));
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        [WebMethod]
        public static string CargarGraficaPastel(string IdProyecto)
        {
            
            try
            {
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                    return JsonConvert.SerializeObject((object)sisaEntitie.sp_GraficaPastelUtilidad(IdProyecto));
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }

        [WebMethod]
        public static string CargarDetalleGrafica(string Nombre, string IdProyecto, string Gastado)
        {
            
            try
            {
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                    return JsonConvert.SerializeObject((object)sisaEntitie.sp_GraficaPastelDetalle(IdProyecto, Nombre, new Decimal?(Decimal.Parse(Gastado))));
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }

        [WebMethod]
        public static string CargarDetalle(string Punto, string IdProyecto)
        {
            string str = string.Empty;
            try
            {
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                    str = !(Punto == "Mano de Obra") ? (!(Punto == "Viaticos") ? (!(Punto == "Caja Chica") ? JsonConvert.SerializeObject((object)sisaEntitie.sp_CargarDetalleGrafica(Punto, IdProyecto).Distinct<sp_CargarDetalleGrafica_Result>()) : JsonConvert.SerializeObject((object)sisaEntitie.sp_CargarDetalleGraficaCajaChica(Punto, IdProyecto))) : JsonConvert.SerializeObject((object)sisaEntitie.sp_CargarDetalleGraficaViaticos(Punto, IdProyecto))) : JsonConvert.SerializeObject((object)sisaEntitie.sp_CargarDetalleGraficaMO(Punto, IdProyecto));
            }
            catch (Exception ex)
            {
                str = ex.ToString();
            }
            return str;

        }

        [WebMethod]
        public static string CargarGraficaPastelEficiencia(string IdProyecto)
        {
            string str = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.Administracion || rolesUsuarios.Tipo == "ROOT")
            {
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                    str = JsonConvert.SerializeObject((object)sisaEntitie.CargarEficiencias(IdProyecto));
            }
            else
                str = "No tienes permiso de actualizar proyecto.";
            return str;
        }

        [WebMethod]
        public static string Proyecciones(string IdProyecto)
        {
            string str = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.Administracion || rolesUsuarios.Tipo == "ROOT")
            {
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                    str = JsonConvert.SerializeObject((object)sisaEntitie.sp_CargarProyecciones(IdProyecto));
            }
            else
                str = "No tienes permiso de actualizar proyecto.";
            return str;
        }

        [WebMethod]
        public static string GuardarProyecciones(string pid, string str10, string strFecha10, string str20, string strFecha20, string str30, string strFecha30, string str40, string strFecha40, string str50, string strFecha50, string str60, string strFecha60, string str70, string strFecha70, string str80, string strFecha80, string str90, string strFecha90, string str100, string strFecha100)
        {
            string empty = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            using (SisaEntitie sisaEntitie = new SisaEntitie())
                return JsonConvert.SerializeObject((object)sisaEntitie.sp_InsertProyeccionFinanciera(pid, Convert.ToDecimal(str10), strFecha10, Convert.ToDecimal(str20), strFecha20, Convert.ToDecimal(str30), strFecha30, Convert.ToDecimal(str40), strFecha40, Convert.ToDecimal(str50), strFecha50, Convert.ToDecimal(str60), strFecha60, Convert.ToDecimal(str70), strFecha70, Convert.ToDecimal(str80), strFecha80, Convert.ToDecimal(str90), strFecha90, Convert.ToDecimal(str100), strFecha100, usuario.IdUsuario.ToString()));
        }

        [WebMethod]
        public static string cargarProyeccionFinanciera(string IdProyecto)
        {
            string empty = string.Empty;
            try
            {
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                    return JsonConvert.SerializeObject((object)sisaEntitie.sp_CargarProyeccionesFinancieras(IdProyecto));
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}