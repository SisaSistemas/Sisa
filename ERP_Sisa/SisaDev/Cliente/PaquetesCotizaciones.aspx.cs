using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Cliente
{
    public partial class PaquetesCotizaciones : System.Web.UI.Page
    {
        public static tblClienteContacto usuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = HttpContext.Current.Session["UsuarioClienteLogueado"] as tblClienteContacto;
            if (usuario != null)
            {

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
                                    select new { 
                                        a.IdPaqueteEnc, a.Folio, b.NombreContacto, a.FechaCreado, a.Descuento
                                    });
                retorno = JsonConvert.SerializeObject(cotizaciones);
            }
            return retorno;
        }
    }
}