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
    public partial class PaquetesCotizaciones : System.Web.UI.Page
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
        public static string ObtienePaquetes()
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                var cotizaciones = (from a in DataControl.tblPaqueteEnc_CCM
                                    join b in DataControl.tblClienteContacto
                                    on a.IdCliente equals b.idContacto
                                    orderby a.Folio ascending
                                    select new
                                    {
                                        a.IdPaqueteEnc,
                                        a.Folio,
                                        b.NombreContacto,
                                        a.FechaCreado,
                                        a.Descuento
                                    });
                retorno = JsonConvert.SerializeObject(cotizaciones);
            }
            return retorno;
        }
    }
}