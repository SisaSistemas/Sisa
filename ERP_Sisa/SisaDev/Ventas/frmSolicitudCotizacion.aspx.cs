using Newtonsoft.Json;
using SisaDev.Control;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Ventas
{
    public partial class frmSolicitudCotizacion : System.Web.UI.Page
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
        public static string GuardaSolicitud(string _nombreRequisitor, string _cdsid, string _telefono, string _idArea, string _objetivo, string _resumen
                , string _fechaVisita, string _horaVisita, string _ubicacionTrabajo, string _otherText, string _planta)
        {
            string retorno = string.Empty;
            tblFolioSolicitudCotizacion_CCM _folio;

            using (var DataControl = new SisaEntitie())
            {
                var _folioEnTabla = (from f in DataControl.tblFolioSolicitudCotizacion_CCM
                                     where (f.Dia.Year == DateTime.Now.Year &&
                                            f.Dia.Month == DateTime.Now.Month &&
                                            f.Dia.Day == DateTime.Now.Day)
                                     orderby f.Consecutivo descending
                                     select f).FirstOrDefault();
                if (_folioEnTabla == null)
                {
                    _folio = new tblFolioSolicitudCotizacion_CCM
                    {
                        IdFolioSolicitudCotizacion = Guid.NewGuid(),
                        Dia = DateTime.Now,
                        Consecutivo = 1
                    };
                }
                else
                {
                    _folio = new tblFolioSolicitudCotizacion_CCM
                    {
                        IdFolioSolicitudCotizacion = Guid.NewGuid(),
                        Dia = DateTime.Now,
                        Consecutivo = _folioEnTabla.Consecutivo + 1
                    };
                }
                DataControl.tblFolioSolicitudCotizacion_CCM.Add(_folio);
                DataControl.SaveChanges();

                tblSolicitudCotizacion_CCM add = new tblSolicitudCotizacion_CCM
                {
                    idSolicitudCotizacion = Guid.NewGuid(),
                    Folio = "SC" + _folio.Dia.Day.ToString("00") + _folio.Dia.Month.ToString("00") + _folio.Dia.ToString("yy") + "-" + _folio.Consecutivo.ToString("000"),
                    Fecha = DateTime.Now,
                    Requisitor = usuario.IdUsuario,
                    NombreRequisitor = _nombreRequisitor,
                    CDSID = _cdsid,
                    Telefono = _telefono,
                    idArea = Guid.Parse(_idArea),
                    Objetivo = _objetivo,
                    Resumen = _resumen,
                    FechaVisita = Convert.ToDateTime(_fechaVisita),
                    HoraVisita = TimeSpan.Parse(_horaVisita),
                    FechaEntrega = null,
                    UbicacionTrabajo = _ubicacionTrabajo,
                    Estatus = 0,
                    Tipo = _otherText,
                    PlantaCCM = _planta
                };

                DataControl.tblSolicitudCotizacion_CCM.Add(add);
                if (DataControl.SaveChanges() > 0)
                {
                    string area = (from a in DataControl.tblArea
                                   where a.idArea.Equals(add.idArea)
                                   select a).First().Nombre;

                    retorno = "idSolicitudCotizacion." + add.idSolicitudCotizacion.ToString();

                    var _correoPM = (from u in DataControl.tblUsuarios
                                     where (u.PlantaCCM == _planta && u.AreaCCM == _idArea)
                                     select u.Correo).FirstOrDefault();

                    var _correosGerentesCCM = (from c in DataControl.tblUsuarios
                                               where (c.PlantaCCM == _planta && c.PuestoCCM == "GERENCIA")
                                               select c.Correo).ToList();

                    //Proceso.EnviarCorreoCCM("lgalvez@sistemasautomatizados.net",
                    //    $"Se generó la solicitud de cotización #{add.Folio} para el Área: {area}, Requisitor: {add.NombreRequisitor}",
                    //    "no_reply@sistemasautomatizados.net", $"Solicitud de cotizacion #{add.Folio}", _planta, _correoPM, _correosGerentesCCM);
                }
                else
                {
                    retorno = "Ocurrio un problema al guardar la Solicitud de cotizacion.";
                }




            }



            return retorno;
        }
    }
}