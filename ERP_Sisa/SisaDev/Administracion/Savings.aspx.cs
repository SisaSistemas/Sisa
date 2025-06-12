using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using SisaDev.Models;

namespace SisaDev.Administracion
{
    public partial class Savings : System.Web.UI.Page
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
        public static string CargarSavings(string Planta, string Mes)
        {
            string str = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.Savings || rolesUsuarios.Tipo == "ROOT")
            {
                if (Planta == "FORD HSAP")
                {
                    using (SisaEntitie sisaEntitie = new SisaEntitie())
                        str = JsonConvert.SerializeObject((object)sisaEntitie.sp_SelectSavings().Where(s => s.IdEmpresa == Guid.Parse("E9A70DAC-356F-4AD0-988A-9CC3D8D88DB8") && s.NombreMes == Mes));
                }

                if (Planta == "FORD CSAP")
                {
                    using (SisaEntitie sisaEntitie = new SisaEntitie())
                        str = JsonConvert.SerializeObject((object)sisaEntitie.sp_SelectSavings().Where(s => s.IdEmpresa == Guid.Parse("9DB0E133-FEFA-497D-899A-FAD6526AB652") && s.NombreMes == Mes));
                }

            }
            else
                str = "No tienes permiso.";
            return str;
        }

        [WebMethod]
        public static string CargarGrafica(string Id)
        {

            try
            {
                
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                    return JsonConvert.SerializeObject((object)sisaEntitie.sp_GraficaSavings(Id));
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }

        [WebMethod]
        public static string AgregarMonto(string IdSavings, string Monto)
        {
            string str = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Savings)
            {
                try
                {
                    using (SisaEntitie sisaEntitie = new SisaEntitie())
                    {
                        tblSavings tblSavings = ((IQueryable<tblSavings>)sisaEntitie.tblSavings).FirstOrDefault<tblSavings>((Expression<Func<tblSavings, bool>>)(p => p.IdSavings.ToString() == IdSavings));
                        if (tblSavings != null)
                        {
                            tblSavings.Monto = Decimal.Parse(Monto);
                            sisaEntitie.SaveChanges();
                            str = "Cantidad actualizada.";
                        }
                        else
                            str = "No se encontro información de viatico, intenta de nuevo recargando página";
                    }
                }
                catch (Exception ex)
                {
                    str = ex.ToString();
                }
            }
            else
                str = "No tienes permiso de edición.";
            return str;
        }

        [WebMethod]
        public static string ActualizarTipoAhorro(string IdSavings, string TipoAhorro)
        {
            string str = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Savings)
            {
                try
                {
                    using (SisaEntitie sisaEntitie = new SisaEntitie())
                    {
                        tblSavings tblSavings = ((IQueryable<tblSavings>)sisaEntitie.tblSavings).FirstOrDefault<tblSavings>((Expression<Func<tblSavings, bool>>)(p => p.IdSavings.ToString() == IdSavings));
                        if (tblSavings != null)
                        {
                            tblSavings.TipoAhorro = TipoAhorro;
                            sisaEntitie.SaveChanges();
                            str = "Tipo Ahorro actualizada.";
                        }
                        else
                            str = "No se encontro información, intenta de nuevo recargando página";
                    }
                }
                catch (Exception ex)
                {
                    str = ex.ToString();
                }
            }
            else
                str = "No tienes permiso de edición.";
            return str;
        }
    }
}