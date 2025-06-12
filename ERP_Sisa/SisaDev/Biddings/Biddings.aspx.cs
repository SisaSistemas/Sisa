using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Biddings
{
    public partial class Biddings : System.Web.UI.Page
    {
        public static tblProveedores usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = HttpContext.Current.Session["UsuarioProveedorLogueado"] as tblProveedores;

            if (usuario != null)
            {
                
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        [WebMethod]
        public static string ObtieneSolicitudes()
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                var cotizaciones = (from a in DataControl.tblBiddingsEnc
                                    join d in DataControl.tblBiddingsDet
                                    on a.IdBiddings equals d.IdBiddingsEnc
                                    where d.IdProveedor == usuario.IdProveedor
                                    orderby a.FolioBiddings ascending
                                    select a);
                retorno = JsonConvert.SerializeObject(cotizaciones);
            }
            return retorno;
        }

        [WebMethod]
        public static string ObtieneBiddingsDet(string IdBiddings)
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                Guid id = Guid.Parse(IdBiddings);
                //var _solicitudes = DataControl.tblBiddingsDet.Where(s => s.IdBiddingsEnc == id);
                //retorno = JsonConvert.SerializeObject(_solicitudes);

                var _solicitudes = (from s in DataControl.tblBiddingsDet
                                    join p in DataControl.tblProveedores
                                    on s.IdProveedor equals p.IdProveedor
                                    where s.IdBiddingsEnc == id && s.IdProveedor == usuario.IdProveedor
                                    select new
                                    {
                                        Proveedor = p.NombreComercial,
                                        FolioCotizacion = s.FolioCotizacionProveedor,
                                        Concepto = s.Concepto,
                                        CostoCotizacion = s.CostoCotizacion,
                                        FechaEntrega = s.FechaEntrega,
                                        Estatus = s.Estatus,
                                        IdBiddingDet = s.IdBiddingsDet
                                    }).ToList();

                retorno = JsonConvert.SerializeObject(_solicitudes);
                //List<tblCotizaciones> cotizaciones = (from a in DataControl.tblCotizaciones
                //                    where id.Equals(a.idRequisicion)
                //                    select a).ToList();
                //retorno = JsonConvert.SerializeObject(cotizaciones);
            }
            return retorno;
        }

        [WebMethod]
        public static string CargarPDF(string IdBiddingDet, string Opcion)
        {
            string retorno = string.Empty;
            try
            {
                //int a = Convert.ToInt32(Opcion);
                Guid idBiddingDet = Guid.Parse(IdBiddingDet);
                using (var DataControl = new SisaEntitie())
                {
                    var pdf = (from a in DataControl.tblBiddingsArchivos
                               where a.IdBiddingsDet == idBiddingDet
                               select a);
                    retorno = JsonConvert.SerializeObject(pdf);
                }


            }
            catch (Exception e)
            {
                retorno = e.ToString();
            }
            return retorno;
        }

        [WebMethod]
        public static string GuardarCotizacion(string pIdBiddingDet, string pFolio, string pConcepto, string pCostoCotizacion)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioProveedorLogueado"] as tblProveedores;
            Guid id = Guid.Parse(pIdBiddingDet);

            using (var DataControl = new SisaEntitie())
            {
                var Proveedor = DataControl.tblBiddingsDet.Where(b => b.IdBiddingsDet == id).FirstOrDefault();

                if (Proveedor != null)
                {
                    Proveedor.FolioCotizacionProveedor = pFolio;
                    Proveedor.Concepto = pConcepto;
                    Proveedor.CostoCotizacion = Convert.ToDecimal(pCostoCotizacion);
                    Proveedor.FechaEntrega = DateTime.Now;
                    Proveedor.Estatus = 1;
                   
                    if (DataControl.SaveChanges() > 0)
                    {
                        retorno = "Cotizacion actualizada.";
                    }
                    else
                    {
                        retorno = "No se realizaron cambios.";
                    }
                }
                else
                {
                    retorno = "No se obtuvo información de Proveedor seleccionado.";
                }
            }

            return retorno;
        }

        [WebMethod]
        public static string GuardarDocumentos(string IdBiddingDet, string FileName, string fileSize, string filetype, string fileExtension, string Archivo)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioProveedorLogueado"] as tblProveedores;
            //rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            try
            {

                using (var DataControl = new SisaEntitie())
                {
                    //int a = Convert.ToInt32(Opcion);
                    Guid id = Guid.Parse(IdBiddingDet);
                    tblBiddingsArchivos add = new tblBiddingsArchivos
                    {
                        IdArchivoBiddings = Guid.NewGuid(),
                        IdBiddingsDet = id,
                        File = Archivo,
                        FileName = FileName,
                        FileExtension = fileExtension,
                        FileSize = fileSize,
                        FileContentType = filetype,
                        Fecha = DateTime.Now

                    };
                    DataControl.tblBiddingsArchivos.Add(add);
                    DataControl.SaveChanges();
                    retorno = "Archivo guardado";
                }
            }
            catch (Exception e)
            {
                retorno = e.ToString();
            }

            return retorno;
        }
    }
}