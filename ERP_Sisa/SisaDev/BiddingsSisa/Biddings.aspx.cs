using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.BiddingsSisa
{
    public partial class Biddings : System.Web.UI.Page
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
        public static string ObtieneSolicitudes()
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                var cotizaciones = (from a in DataControl.tblBiddingsEnc
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
                                    where s.IdBiddingsEnc == id
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
        public static string CreaCotizacion(string IdBiddingDet, string Comentario, string Opt)
        {
            string retorno = string.Empty;
            try
            {
                //int a = Convert.ToInt32(Opcion);
                Guid idBiddingDet = Guid.Parse(IdBiddingDet);

                using (var DataControl = new SisaEntitie())
                {
                    var existeBidding = DataControl.tblBiddingsDet.Where(p => p.IdBiddingsDet.Equals(idBiddingDet)).FirstOrDefault();
                    existeBidding.Estatus = 2;

                    if (DataControl.SaveChanges() > 0)
                    {
                        var existeBiddingEnc = (from be in DataControl.tblBiddingsEnc
                                                join bd in DataControl.tblBiddingsDet
                                                on be.IdBiddings equals bd.IdBiddingsEnc
                                                where bd.IdBiddingsDet == idBiddingDet
                                                select be).FirstOrDefault();

                        if (existeBiddingEnc != null)
                        {
                            existeBiddingEnc.Estatus = 1;
                            

                            if (DataControl.SaveChanges() > 0)
                            {
                                //Guid idSolicitud = Guid.Parse(_idSolicitud);

                                tblBiddingComentario add = new tblBiddingComentario
                                {
                                    IdBiddingComentario = Guid.NewGuid(),
                                    IdBidding = existeBiddingEnc.IdBiddings,
                                    Comentario = Comentario,
                                    IdUsuarioAlta = usuario.IdUsuario,
                                    FechaComentario = DateTime.Now
                                };

                                DataControl.tblBiddingComentario.Add(add);
                                DataControl.SaveChanges();

                            }
                        }
                    }
                    

                    retorno = "Bidding guardado correctamente!!!";
                }


            }
            catch (Exception e)
            {
                retorno = e.ToString();
            }
            return retorno;
        }

        [WebMethod]
        public static string CargarComentarios(string IdBidding, string Opcion)
        {
            string retorno = string.Empty;
            Guid id = Guid.Parse(IdBidding);

            using (var DataControl = new SisaEntitie())
            {
                var comentarios = (from a in DataControl.tblBiddingComentario
                                   join b in DataControl.tblUsuarios
                                   on a.IdUsuarioAlta equals b.IdUsuario
                                   where a.IdBidding == id
                                   orderby a.FechaComentario ascending
                                    select new
                                    {
                                        a.IdBiddingComentario,
                                        a.Comentario,
                                        FechaComentario = a.FechaComentario.ToString(),
                                        b.NombreCompleto
                                    });
                retorno = JsonConvert.SerializeObject(comentarios);
            }
            return retorno;
        }

        [WebMethod]
        public static string CargarParticipantes(string IdSolicitudCotizacion, string Opcion)
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                var areas = (from a in DataControl.tblProveedores
                             where a.Activo == 1
                             orderby a.Contacto ascending
                             select a);
                retorno = JsonConvert.SerializeObject(areas);
            }
            return retorno;
        }

        [WebMethod]
        public static string GuardarParticipante(string IdBidding, string IdProveedor, string Opt)
        {
            string retorno = string.Empty;

            Guid idBidding = Guid.Parse(IdBidding);
            Guid idProveedor = Guid.Parse(IdProveedor);

            using (var DataControl = new SisaEntitie())
            {
                tblBiddingsDet add = new tblBiddingsDet
                {
                    IdBiddingsDet = Guid.NewGuid(),
                    IdBiddingsEnc = idBidding,
                    IdProveedor = idProveedor,
                    FolioCotizacionProveedor = "",
                    Concepto = "",
                    CostoCotizacion = 0,
                    FechaEntrega = DateTime.Now,
                    Estatus = 0
                };

                DataControl.tblBiddingsDet.Add(add);

                if (DataControl.SaveChanges() > 0)
                {
                    retorno = "Participante Agregado Correctamente!.";
                }
                else
                {
                    retorno = "Participante No Agregado, Favor de revisar informacion!.";
                }
                
            }
            return retorno;
        }
    }
}