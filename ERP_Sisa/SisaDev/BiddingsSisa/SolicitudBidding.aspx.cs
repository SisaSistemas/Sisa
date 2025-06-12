using Newtonsoft.Json;
using SisaDev.Clases;
using SisaDev.Control;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.BiddingsSisa
{
    public partial class SolicitudBidding : System.Web.UI.Page
    {
        public static tblUsuarios usuario;
        public static tblRolesUsuarios rolesUsuarios;

        static List<Guid> _proveedores = new List<Guid>();
        static List<clsProveedores> queryProveedores = new List<clsProveedores>();
        static List<clsProveedores> proveedoresRFQ = new List<clsProveedores>();

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
        public static string ObtieneAreas()
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                var areas = (from a in DataControl.tblArea
                             where a.Activo == true
                             orderby a.Nombre ascending
                             select a);
                retorno = JsonConvert.SerializeObject(areas);
            }
            return retorno;
        }

        [WebMethod]
        public static string GuardaSolicitud(string _planta, string _idArea, string _resumen, string _fechaLimite, string _idSolicitud)
        {
            string retorno = string.Empty;
            tblBiddingsFolio _folio;

            using (var DataControl = new SisaEntitie())
            {
                var _folioEnTabla = (from f in DataControl.tblBiddingsFolio
                                     where (f.Dia.Year == DateTime.Now.Year &&
                                            f.Dia.Month == DateTime.Now.Month &&
                                            f.Dia.Day == DateTime.Now.Day)
                                     orderby f.Consecutivo descending
                                     select f).FirstOrDefault();
                if (_folioEnTabla == null)
                {
                    _folio = new tblBiddingsFolio
                    {
                        IdFolioBiddings = Guid.NewGuid(),
                        Dia = DateTime.Now,
                        Consecutivo = 1
                    };
                }
                else
                {
                    _folio = new tblBiddingsFolio
                    {
                        IdFolioBiddings = Guid.NewGuid(),
                        Dia = DateTime.Now,
                        Consecutivo = _folioEnTabla.Consecutivo + 1
                    };
                }
                DataControl.tblBiddingsFolio.Add(_folio);
                DataControl.SaveChanges();

                Guid idSolicitud = Guid.Parse(_idSolicitud);

                tblBiddingsEnc add = new tblBiddingsEnc
                {
                    IdBiddings = Guid.NewGuid(),
                    FolioBiddings = "SB" + _folio.Dia.Day.ToString("00") + _folio.Dia.Month.ToString("00") + _folio.Dia.ToString("yy") + "-" + _folio.Consecutivo.ToString("000"),
                    Concepto = _resumen,
                    Planta = _planta,
                    IdArea = Guid.Parse(_idArea),
                    FechaLimite = Convert.ToDateTime(_fechaLimite),
                    FechaAlta = DateTime.Now,
                    IdUsuarioAlta = usuario.IdUsuario,
                    FechaModificacion = DateTime.Now,
                    IdUsuarioModificacion = usuario.IdUsuario,
                    Estatus = 0,
                    IdSolicitudCotizacion = idSolicitud
                };

                DataControl.tblBiddingsEnc.Add(add);
                if (DataControl.SaveChanges() > 0)
                {
                    foreach (var _c in _proveedores)
                    {
                        DataControl.tblBiddingsDet.Add(new tblBiddingsDet
                        {
                            IdBiddingsDet = Guid.NewGuid(),
                            IdBiddingsEnc = add.IdBiddings,
                            IdProveedor = _c,
                            FolioCotizacionProveedor = "",
                            Concepto = "",
                            CostoCotizacion = 0,
                            FechaEntrega = DateTime.Now,
                            Estatus = 0
                        });
                    }

                    if (DataControl.SaveChanges() > 0)
                    {
                        tblSolicitudCotizacion_CCM entity = DataControl.tblSolicitudCotizacion_CCM.FirstOrDefault<tblSolicitudCotizacion_CCM>((v => v.idSolicitudCotizacion == idSolicitud));
                        if (entity != null)
                        {
                            entity.TipoCotizacion = "Bidding";
                            entity.FolioTipo = add.FolioBiddings;
                            DataControl.SaveChanges();
                            //retorno = "Tipo Actualizada.";
                        }
                        else
                        {
                            //retorno = "Error";
                        }
                    }
                    

                    retorno = "IdSolicitud." + add.IdBiddings.ToString();

                    var _correoPM = (from u in DataControl.tblUsuarios
                                     where (u.PlantaCCM == _planta && u.AreaCCM == _idArea)
                                     select u.Correo).FirstOrDefault();

                    var _correosGerentesCCM = (from c in DataControl.tblUsuarios
                                               where (c.PlantaCCM == _planta && c.PuestoCCM == "GERENCIA")
                                               select c.Correo).ToList();

                    Proceso.EnviarCorreoCCM("lgalvez@sistemasautomatizados.net",
                        $"Se generó la solicitud de Bidding #{add.FolioBiddings} para la planta: {_planta}, con el concepto de: {add.Concepto}",
                        "no_reply@sistemasautomatizados.net", $"Solicitud de Bidding #{add.FolioBiddings}", _planta, _correoPM, _correosGerentesCCM);
                }
                else
                {
                    retorno = "Ocurrio un problema al guardar la Solicitud de cotizacion.";
                }




            }



            return retorno;
        }

        [WebMethod]
        public static string ObtieneProveedores()
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                queryProveedores = (from c in DataControl.tblProveedores
                                    select new clsProveedores
                                    {
                                        IdProveedor = c.IdProveedor,
                                        RFC = c.RFC,
                                        NombreComercial = c.NombreComercial,
                                        Contacto = c.Contacto,
                                        Estilo = "btn btn-success AgregarCotizacion"
                                    }
                            ).ToList();//List<clsProveedores>(DataControl.tblProveedores).Where(p => p.Activo == 1).OrderByDescending(p => p.Proveedor).ToList();


                queryProveedores.ForEach(x => { if (!_proveedores.Contains(x.IdProveedor)) { x.Estilo = "btn btn-success AgregarProveedor"; } else { x.Estilo = "btn btn-warning EliminarProveedor"; } });


                retorno = JsonConvert.SerializeObject(queryProveedores);
            }
            return retorno;
        }

        [WebMethod]
        public static string AgregarProveedor(string IdProveedor)
        {
            string retorno = string.Empty;

            bool _exists = _proveedores.Contains(Guid.Parse(IdProveedor));
            if (!_exists)
            {
                _proveedores.Add(Guid.Parse(IdProveedor));
                retorno = "Proveedor agregado correctamente!!!";
            }
            else
            {
                retorno = "El proveedor ya existe!!!";
            }

            return retorno;
        }

        [WebMethod]
        public static string CargaProveedoresPermitidos()
        {
            string retorno = string.Empty;

            using (var DataControl = new SisaEntitie())
            {
                //if (idPaquete != "0" && bandera)
                //{
                //    bandera = false;
                //    _cotizaciones = DataControl.tblPaqueteDet_CCM.Where(c => c.IdPaqueteEnc.Equals(_idPaquete)).Select(c => c.IdCotizaciones).ToList();
                //}
                var proveedores = (from c in DataControl.tblProveedores
                                    where _proveedores.Contains(c.IdProveedor)
                                    select new clsProveedores
                                    {
                                        IdProveedor = c.IdProveedor,
                                        RFC = c.RFC,
                                        NombreComercial = c.NombreComercial,
                                        Contacto = c.Contacto,
                                        Estilo = ""
                                    }).ToList();

                //List<Guid> provs = proveedores.Select(a => a.IdProveedor).ToList();

                retorno = JsonConvert.SerializeObject(proveedores);
            }

            return retorno;
        }

        [WebMethod]
        public static string EliminarProveedor(string IdProveedor)
        {
            string retorno = string.Empty;

            bool _exists = _proveedores.Contains(Guid.Parse(IdProveedor));
            if (_exists)
            {
                _proveedores.Remove(Guid.Parse(IdProveedor));
                retorno = "Proveedor Eliminado correctamente!!!";
            }
            else
            {
                retorno = "El Proveedor No existe!!!";
            }

            return retorno;
        }
    }
}