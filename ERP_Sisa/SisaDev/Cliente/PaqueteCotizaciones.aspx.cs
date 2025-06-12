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

namespace SisaDev.Cliente
{
    public partial class PaqueteCotizaciones : System.Web.UI.Page
    {
        public static tblClienteContacto usuario;
        public static string idPaquete;
        public static Guid _idPaquete;
        public static bool bandera = false;

        static List<Guid> _cotizaciones = new List<Guid>();
        static List<clsPaquetesCotizaciones> queryHSAP = new List<clsPaquetesCotizaciones>();
        static List<clsPaquetesCotizaciones> queryIrapuato = new List<clsPaquetesCotizaciones>();
        static List<clsPaquetesCotizaciones> queryChihuahua = new List<clsPaquetesCotizaciones>();
        static List<clsPaquetesCotizaciones> queryCuautitlan = new List<clsPaquetesCotizaciones>();
        static List<clsPaquetesCotizaciones> paquete = new List<clsPaquetesCotizaciones>();

        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = HttpContext.Current.Session["UsuarioClienteLogueado"] as tblClienteContacto;
            if (usuario != null)
            {
                idPaquete = Request.QueryString["idPaquete"];
                if (idPaquete != "0")
                {
                    if (idPaquete != "null")
                    {
                        _idPaquete = Guid.Parse(idPaquete);
                       
                    }
                }
                bandera = true;
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        [WebMethod]
        public static string ObtieneCotizacionesHSAP()
        {
            string retorno = string.Empty;
            List<Guid> allowedEmpresas = new List<Guid>
            {
                Guid.Parse("E9A70DAC-356F-4AD0-988A-9CC3D8D88DB8")
                //Guid.Parse("11C3483C-8E3C-4956-A6AC-A6BD908D896A")//,
                //Guid.Parse("5ED3C790-8124-4CEA-8DE2-B44B122D0274"),
                //Guid.Parse("9DBA90B1-192D-4536-B79C-B86FDFF45CD3"),
                //Guid.Parse("62187385-52E3-4743-B358-D565B9001F43"),
                //Guid.Parse("9198CB84-22F8-40F3-AD93-D6B1D9EACCB2"),
                //Guid.Parse("9DB0E133-FEFA-497D-899A-FAD6526AB652"),
                //Guid.Parse("0227A2C1-D05B-49F1-9EA2-FF0C77667CC1")
            };

            using (var DataControl = new SisaEntitie())
            {
                var empresas = (from c in DataControl.tblEmpresas
                                where allowedEmpresas.Contains(c.idEmpresa)
                                select c).ToList();

                var cotizaciones = (from c in DataControl.tblCotizaciones
                                    where allowedEmpresas.Contains(c.IdEmpresa)
                                    select new
                                    {
                                        IdCotizaciones = c.IdCotizaciones,
                                        IdEmpresa = c.IdEmpresa,
                                        NoCotizaciones = c.NoCotizaciones,
                                        Concepto = c.Concepto,
                                        Estatus = c.Estatus,
                                        CostoCotizaciones = c.CostoCotizaciones,
                                        FechaCotizaciones = c.FechaCotizaciones
                                    }).ToList();

                queryHSAP = (from c in cotizaciones
                             join e in empresas
                             on c.IdEmpresa equals e.idEmpresa
                             select new clsPaquetesCotizaciones
                             {
                                 IdCotizaciones = c.IdCotizaciones,
                                 IdEmpresa = c.IdEmpresa,
                                 RazonSocial = e.RazonSocial,
                                 RFC = e.RFC,
                                 Cliente = e.Cliente,
                                 NoCotizaciones = c.NoCotizaciones,
                                 Concepto = c.Concepto,
                                 Estatus = c.Estatus,
                                 CostoCotizaciones = (decimal)(c.CostoCotizaciones == null ? 0 : c.CostoCotizaciones),
                                 FechaCotizaciones = c.FechaCotizaciones,
                                 Estilo = "btn btn-success AgregarCotizacion"
                             }
                            ).ToList();

                queryHSAP.ForEach(x => { if (!_cotizaciones.Contains(x.IdCotizaciones)) { x.Estilo = "btn btn-success AgregarCotizacion"; } else { x.Estilo = "btn btn-warning EliminarCotizacion"; } });

                retorno = JsonConvert.SerializeObject(queryHSAP);
            }

            return retorno;
        }

        [WebMethod]
        public static string ObtieneCotizacionesIrapuato()
        {
            string retorno = string.Empty;
            List<Guid> allowedEmpresas = new List<Guid>
            {
                //Guid.Parse("E9A70DAC-356F-4AD0-988A-9CC3D8D88DB8"),
                Guid.Parse("11C3483C-8E3C-4956-A6AC-A6BD908D896A"),
                //Guid.Parse("5ED3C790-8124-4CEA-8DE2-B44B122D0274"),
                //Guid.Parse("9DBA90B1-192D-4536-B79C-B86FDFF45CD3"),
                //Guid.Parse("62187385-52E3-4743-B358-D565B9001F43"),
                //Guid.Parse("9198CB84-22F8-40F3-AD93-D6B1D9EACCB2"),
                //Guid.Parse("9DB0E133-FEFA-497D-899A-FAD6526AB652"),
                Guid.Parse("0227A2C1-D05B-49F1-9EA2-FF0C77667CC1")
            };

            using (var DataControl = new SisaEntitie())
            {
                var empresas = (from c in DataControl.tblEmpresas
                                where allowedEmpresas.Contains(c.idEmpresa)
                                select c).ToList();

                var cotizaciones = (from c in DataControl.tblCotizaciones
                                    where allowedEmpresas.Contains(c.IdEmpresa)
                                    select new
                                    {
                                        IdCotizaciones = c.IdCotizaciones,
                                        IdEmpresa = c.IdEmpresa,
                                        NoCotizaciones = c.NoCotizaciones,
                                        Concepto = c.Concepto,
                                        Estatus = c.Estatus,
                                        CostoCotizaciones = c.CostoCotizaciones,
                                        FechaCotizaciones = c.FechaCotizaciones
                                    }).ToList();

                queryIrapuato = (from c in cotizaciones
                                 join e in empresas
                                 on c.IdEmpresa equals e.idEmpresa
                                 select new clsPaquetesCotizaciones
                                 {
                                     IdCotizaciones = c.IdCotizaciones,
                                     IdEmpresa = c.IdEmpresa,
                                     RazonSocial = e.RazonSocial,
                                     RFC = e.RFC,
                                     Cliente = e.Cliente,
                                     NoCotizaciones = c.NoCotizaciones,
                                     Concepto = c.Concepto,
                                     Estatus = c.Estatus,
                                     CostoCotizaciones = (decimal)(c.CostoCotizaciones == null ? 0 : c.CostoCotizaciones),
                                     FechaCotizaciones = c.FechaCotizaciones,
                                     Estilo = "btn btn-success AgregarCotizacion"
                                 }
                            ).ToList();

                queryIrapuato.ForEach(x => { if (!_cotizaciones.Contains(x.IdCotizaciones)) { x.Estilo = "btn btn-success AgregarCotizacion"; } else { x.Estilo = "btn btn-warning EliminarCotizacion"; } });

                retorno = JsonConvert.SerializeObject(queryIrapuato);
            }

            return retorno;
        }

        [WebMethod]
        public static string ObtieneCotizacionesChihuahua()
        {
            string retorno = string.Empty;
            List<Guid> allowedEmpresas = new List<Guid>
            {
                Guid.Parse("9DBA90B1-192D-4536-B79C-B86FDFF45CD3")
            };

            using (var DataControl = new SisaEntitie())
            {
                var empresas = (from c in DataControl.tblEmpresas
                                where allowedEmpresas.Contains(c.idEmpresa)
                                select c).ToList();

                var cotizaciones = (from c in DataControl.tblCotizaciones
                                    where allowedEmpresas.Contains(c.IdEmpresa)
                                    select new
                                    {
                                        IdCotizaciones = c.IdCotizaciones,
                                        IdEmpresa = c.IdEmpresa,
                                        NoCotizaciones = c.NoCotizaciones,
                                        Concepto = c.Concepto,
                                        Estatus = c.Estatus,
                                        CostoCotizaciones = c.CostoCotizaciones,
                                        FechaCotizaciones = c.FechaCotizaciones
                                    }).ToList();

                queryChihuahua = (from c in cotizaciones
                                  join e in empresas
                                  on c.IdEmpresa equals e.idEmpresa
                                  select new clsPaquetesCotizaciones
                                  {
                                      IdCotizaciones = c.IdCotizaciones,
                                      IdEmpresa = c.IdEmpresa,
                                      RazonSocial = e.RazonSocial,
                                      RFC = e.RFC,
                                      Cliente = e.Cliente,
                                      NoCotizaciones = c.NoCotizaciones,
                                      Concepto = c.Concepto,
                                      Estatus = c.Estatus,
                                      CostoCotizaciones = (decimal)(c.CostoCotizaciones == null ? 0 : c.CostoCotizaciones),
                                      FechaCotizaciones = c.FechaCotizaciones,
                                      Estilo = "btn btn-success AgregarCotizacion"
                                  }
                            ).ToList();
                queryChihuahua.ForEach(x => { if (!_cotizaciones.Contains(x.IdCotizaciones)) { x.Estilo = "btn btn-success AgregarCotizacion"; } else { x.Estilo = "btn btn-warning EliminarCotizacion"; } });
                retorno = JsonConvert.SerializeObject(queryChihuahua);
            }

            return retorno;
        }

        [WebMethod]
        public static string ObtieneCotizacionesCuautitlan()
        {
            string retorno = string.Empty;
            List<Guid> allowedEmpresas = new List<Guid>
            {
                Guid.Parse("9DB0E133-FEFA-497D-899A-FAD6526AB652")
            };

            using (var DataControl = new SisaEntitie())
            {
                var empresas = (from c in DataControl.tblEmpresas
                                where allowedEmpresas.Contains(c.idEmpresa)
                                select c).ToList();

                var cotizaciones = (from c in DataControl.tblCotizaciones
                                    where allowedEmpresas.Contains(c.IdEmpresa)
                                    select new
                                    {
                                        IdCotizaciones = c.IdCotizaciones,
                                        IdEmpresa = c.IdEmpresa,
                                        NoCotizaciones = c.NoCotizaciones,
                                        Concepto = c.Concepto,
                                        Estatus = c.Estatus,
                                        CostoCotizaciones = c.CostoCotizaciones,
                                        FechaCotizaciones = c.FechaCotizaciones
                                    }).ToList();

                queryCuautitlan = (from c in cotizaciones
                                   join e in empresas
                                   on c.IdEmpresa equals e.idEmpresa
                                   select new clsPaquetesCotizaciones
                                   {
                                       IdCotizaciones = c.IdCotizaciones,
                                       IdEmpresa = c.IdEmpresa,
                                       RazonSocial = e.RazonSocial,
                                       RFC = e.RFC,
                                       Cliente = e.Cliente,
                                       NoCotizaciones = c.NoCotizaciones,
                                       Concepto = c.Concepto,
                                       Estatus = c.Estatus,
                                       CostoCotizaciones = (decimal)(c.CostoCotizaciones == null ? 0 : c.CostoCotizaciones),
                                       FechaCotizaciones = c.FechaCotizaciones,
                                       Estilo = "btn btn-success AgregarCotizacion"
                                   }
                            ).ToList();

                queryCuautitlan.ForEach(x => { if (!_cotizaciones.Contains(x.IdCotizaciones)) { x.Estilo = "btn btn-success AgregarCotizacion"; } else { x.Estilo = "btn btn-warning EliminarCotizacion"; } });

                retorno = JsonConvert.SerializeObject(queryCuautitlan);
            }

            return retorno;
        }

        [WebMethod]
        public static string AgregarCotizacion(string IdCotizaciones)
        {
            string retorno = string.Empty;

            bool _exists = _cotizaciones.Contains(Guid.Parse(IdCotizaciones));
            if (!_exists)
            {
                _cotizaciones.Add(Guid.Parse(IdCotizaciones));
                retorno = "Cotizacion agregada correctamente!!!";
            }
            else
            {
                retorno = "La cotización ya existe!!!";
            }

            return retorno;
        }

        [WebMethod]
        public static string EliminarCotizacion(string IdCotizaciones)
        {
            string retorno = string.Empty;

            bool _exists = _cotizaciones.Contains(Guid.Parse(IdCotizaciones));
            if (_exists)
            {
                _cotizaciones.Remove(Guid.Parse(IdCotizaciones));
                retorno = "Cotizacion Eliminada correctamente!!!";
            }
            else
            {
                retorno = "La cotización No existe!!!";
            }

            return retorno;
        }

        [WebMethod]
        public static string CargaCotizacionesPaquete()
        {
            string retorno = string.Empty;

            using (var DataControl = new SisaEntitie())
            {
                if (idPaquete != "0"  && bandera)
                {
                    bandera = false;
                    _cotizaciones = DataControl.tblPaqueteDet_CCM.Where(c=>c.IdPaqueteEnc.Equals(_idPaquete)).Select(c => c.IdCotizaciones).ToList();
                }
                var cotizaciones = (from c in DataControl.tblCotizaciones
                                    where _cotizaciones.Contains(c.IdCotizaciones)
                                    select new
                                    {
                                        IdCotizaciones = c.IdCotizaciones,
                                        IdEmpresa = c.IdEmpresa,
                                        NoCotizaciones = c.NoCotizaciones,
                                        Concepto = c.Concepto,
                                        Estatus = c.Estatus,
                                        CostoCotizaciones = c.CostoCotizaciones,
                                        FechaCotizaciones = c.FechaCotizaciones
                                    }).ToList();

                List<Guid> cots = cotizaciones.Select(a => a.IdEmpresa).ToList();

                var empresas = (from c in DataControl.tblEmpresas
                                where cots.Contains(c.idEmpresa)
                                select c).ToList();

                paquete = (from c in cotizaciones
                           join e in empresas
                           on c.IdEmpresa equals e.idEmpresa
                           select new clsPaquetesCotizaciones
                           {
                               IdCotizaciones = c.IdCotizaciones,
                               IdEmpresa = c.IdEmpresa,
                               RazonSocial = e.RazonSocial,
                               RFC = e.RFC,
                               Cliente = e.Cliente,
                               NoCotizaciones = c.NoCotizaciones,
                               Concepto = c.Concepto,
                               Estatus = c.Estatus,
                               CostoCotizaciones = (decimal)(c.CostoCotizaciones == null ? 0 : c.CostoCotizaciones),
                               FechaCotizaciones = c.FechaCotizaciones,
                               Estilo = ""
                           }
                            ).ToList();

                retorno = JsonConvert.SerializeObject(paquete);
            }

            return retorno;
        }

        [WebMethod]
        public static string GuardaPaquete()
        {
            string retorno = string.Empty;
            tblFolioPaquete_CCM _folio;

            if (_cotizaciones.Count > 0)
            {
                using (var DataControl = new SisaEntitie())
                {
                    if (idPaquete == "0")
                    {
                        //es nuevo
                        var _folioEnTabla = (from f in DataControl.tblFolioPaquete_CCM
                                             where (f.Dia.Year == DateTime.Now.Year &&
                                                    f.Dia.Month == DateTime.Now.Month &&
                                                    f.Dia.Day == DateTime.Now.Day)
                                             orderby f.Consecutivo descending
                                             select f).FirstOrDefault();
                        if (_folioEnTabla == null)
                        {
                            _folio = new tblFolioPaquete_CCM
                            {
                                IdFolioPaquete = Guid.NewGuid(),
                                Dia = DateTime.Now,
                                Consecutivo = 1
                            };
                        }
                        else
                        {
                            _folio = new tblFolioPaquete_CCM
                            {
                                IdFolioPaquete = Guid.NewGuid(),
                                Dia = DateTime.Now,
                                Consecutivo = _folioEnTabla.Consecutivo + 1
                            };
                        }
                        DataControl.tblFolioPaquete_CCM.Add(_folio);
                        DataControl.SaveChanges();

                        tblPaqueteEnc_CCM encabezado = new tblPaqueteEnc_CCM
                        {
                            IdPaqueteEnc = Guid.NewGuid(),
                            Folio = "PAQ" + _folio.Dia.Day.ToString("00") + _folio.Dia.Month.ToString("00") + _folio.Dia.ToString("yy") + "-" + _folio.Consecutivo.ToString("000"),
                            IdCliente = usuario.idContacto,
                            FechaCreado = DateTime.Now
                        };
                        DataControl.tblPaqueteEnc_CCM.Add(encabezado);
                        DataControl.SaveChanges();

                        foreach (var _c in _cotizaciones)
                        {
                            DataControl.tblPaqueteDet_CCM.Add(new tblPaqueteDet_CCM
                            {
                                IdPaqueteDet = Guid.NewGuid(),
                                IdPaqueteEnc = encabezado.IdPaqueteEnc,
                                IdCotizaciones = _c
                            });
                        }
                        DataControl.SaveChanges();

                        retorno = "Paquete guardado correctamente!!!";
                        Proceso.EnviarCorreoProyecto("lgalvez@sistemasautomatizados.net",
                            $"Se guardó correctamente el paquete de cotizaciones #{encabezado.IdPaqueteEnc} !!!",
                            "no_reply@sistemasautomatizados.net", $"Paquete #{encabezado.IdPaqueteEnc} guardado correctamente");
                    }
                    else
                    {
                        //se modifica el existente
                        var encabezado = DataControl.tblPaqueteEnc_CCM.Where(p => p.IdPaqueteEnc.Equals(_idPaquete)).FirstOrDefault();
                        encabezado.IdClienteModifica = usuario.idContacto;
                        encabezado.FechaModifica = DateTime.Now;
                        DataControl.SaveChanges();

                        var detalle = DataControl.tblPaqueteDet_CCM.Where(p => p.IdPaqueteEnc.Equals(_idPaquete)).ToList();
                        DataControl.tblPaqueteDet_CCM.RemoveRange(detalle);
                        DataControl.SaveChanges();

                        foreach (var _c in _cotizaciones)
                        {
                            DataControl.tblPaqueteDet_CCM.Add(new tblPaqueteDet_CCM
                            {
                                IdPaqueteDet = Guid.NewGuid(),
                                IdPaqueteEnc = encabezado.IdPaqueteEnc,
                                IdCotizaciones = _c
                            });
                        }
                        DataControl.SaveChanges();
                        retorno = "Paquete guardado correctamente!!!";

                        Proceso.EnviarCorreoProyecto("lgalvez@sistemasautomatizados.net",
                            $"Se guardó correctamente el paquete de cotizaciones #{encabezado.IdPaqueteEnc} !!!",
                            "no_reply@sistemasautomatizados.net", $"Paquete #{encabezado.IdPaqueteEnc} guardado correctamente");
                    }

                }
            }
            else
            {
                retorno = "No existen cotizaciones para guardar!!!";
            }
            return retorno;
        }
    }
}