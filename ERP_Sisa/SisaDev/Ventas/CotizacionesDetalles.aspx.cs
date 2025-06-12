using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Ventas
{
    public partial class CotizacionesDetalles : System.Web.UI.Page
    {
        public static tblUsuarios usuario;
        public static tblRolesUsuarios rolesUsuarios;
        public static string idCotizaciones = string.Empty;
        public static string idSolicitudCotizacion = string.Empty;
        public static string idBidding = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            if (usuario != null)
            {
                rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
                idCotizaciones = Request.QueryString["idCotizacion"];
                idSolicitudCotizacion = Request.QueryString["idSolicitud"];
                idBidding = Request.QueryString["idBidding"];
                idCotiza.Value = idCotizaciones;
                idSolicitud.Value = idSolicitudCotizacion;
                idBiddingInput.Value = idBidding;

                if (idSolicitudCotizacion != "0")
                {
                    if (idSolicitudCotizacion != "null")
                    {
                        using (var DataControl = new SisaEntitie())
                        {
                            Guid id = Guid.Parse(idSolicitudCotizacion);
                            var contacto = DataControl.tblSolicitudCotizacion_CCM.Where(d => d.idSolicitudCotizacion == id).Select(d => d.Requisitor).FirstOrDefault();
                            idContacto.Value = contacto.ToString();
                            var contactoEmpresa = DataControl.tblClienteContacto.Where(d => d.idContacto == contacto).Select(d => d.idEmpresa).FirstOrDefault();
                            idEmpresa.Value = contactoEmpresa.ToString();
                            //var Contactos = DataControl.tblClienteContacto.Where(d => d.idEmpresa == id && d.Estatus == true);
                            //retorno = JsonConvert.SerializeObject(Contactos);
                        }
                    }
                    
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        [WebMethod]
        public static string BuscarContactos(string pid)
        {

            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                Guid id = Guid.Parse(pid);
                var Contactos = DataControl.tblClienteContacto.Where(d => d.idEmpresa == id && d.Estatus == true);
                retorno = JsonConvert.SerializeObject(Contactos);
            }
            return retorno;

        }

        [WebMethod]
        public static string CargarCombos(string Opcion)
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                int op = Convert.ToInt32(Opcion);
                
                retorno = JsonConvert.SerializeObject(DataControl.sp_CargaCombos(op));
            }
            return retorno;

        }

        static Guid idCotizacionNueva;
        [WebMethod]
        public static string CrearCotizacion(string idContacto, string idEmpresa, string RFQ, string txtDescripcionCotizaCompleta, string CostoCotizacion
            , string MO, string CM, string CE, string pIva, string pSaving, string CreadoPor, string VendidoPor, string Sucursal)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;

            CostoCotizacion = CostoCotizacion.Replace(",", "");
            MO = MO.Replace(",", "");
            CM = CM.Replace(",", "");
            CE = CE.Replace(",", "");
            pIva = pIva.Replace(",", "");
            pSaving = pSaving.Replace(",", "");

            try
            {
                using (var DataControl = new SisaEntitie())
                {
                    if (rolesUsuarios.CotizacionesAgregar == true || rolesUsuarios.Tipo == "ROOT")
                    {
                        if (!string.IsNullOrEmpty(RFQ))
                        {
                            var parametro = new ObjectParameter("Folio", typeof(string));
                            DataControl.sp_ObtieneFolioCotizacion(parametro).ToString();
                            //var Rfq = DataControl.tblRFQ.FirstOrDefault(r => r.Folio == RFQ);
                            var idSolicitud = DataControl.tblSolicitudCotizacion_CCM.FirstOrDefault(d => d.Folio == RFQ);
                            if (idSolicitud != null)
                            {
                                idSolicitud.Estatus = 2;
                                DataControl.SaveChanges();

                                //parametro.Value.ToString()
                                tblCotizaciones add = new tblCotizaciones
                                {
                                    IdCotizaciones = Guid.NewGuid(),
                                    idContacto = Guid.Parse(idContacto),
                                    IdEmpresa = Guid.Parse(idEmpresa),
                                    idRequisicion = idSolicitud.idSolicitudCotizacion,
                                    NoCotizaciones = parametro.Value.ToString(),
                                    FolioModificacion = "00",
                                    Concepto = txtDescripcionCotizaCompleta,
                                    CostoCotizaciones = decimal.Parse(CostoCotizacion),
                                    IdUsuarioCreo = Guid.Parse(CreadoPor),//usuario.IdUsuario,
                                    IdUsuarioEnvia = usuario.IdUsuario,
                                    TIMESTAMP = DateTime.Now,
                                    FechaCotizaciones = DateTime.Now,
                                    Estatus = 1,
                                    CostoMOCotizado = double.Parse(MO),
                                    CostoMaterialCotizado = double.Parse(CM),
                                    CostoMECotizado = double.Parse(CE),
                                    SavingPorcentaje = decimal.Parse(pSaving),
                                    IvaPorcentaje = decimal.Parse(pIva),
                                    VendidoPor = Guid.Parse(VendidoPor),
                                    Sucursal = Guid.Parse(Sucursal)
                                };
                                DataControl.tblCotizaciones.Add(add);
                                DataControl.SaveChanges();
                                idCotizacionNueva = add.IdCotizaciones;

                                retorno = "Cotizacion creada." + idCotizacionNueva.ToString();

                            }
                            else
                            {
                                retorno = "No se encontro RFQ, verifica el folio.";

                            }
                        }
                        else
                        {
                            var parametro = new ObjectParameter("Folio", typeof(string));
                            DataControl.sp_ObtieneFolioCotizacion(parametro).ToString();
                            tblCotizaciones add = new tblCotizaciones
                            {
                                IdCotizaciones = Guid.NewGuid(),
                                idContacto = Guid.Parse(idContacto),
                                IdEmpresa = Guid.Parse(idEmpresa),
                                idRequisicion = null,
                                NoCotizaciones = parametro.Value.ToString(),
                                FolioModificacion = "00",
                                Concepto = txtDescripcionCotizaCompleta,
                                CostoCotizaciones = decimal.Parse(CostoCotizacion),
                                IdUsuarioCreo = Guid.Parse(CreadoPor),//usuario.IdUsuario,
                                IdUsuarioEnvia = usuario.IdUsuario,
                                TIMESTAMP = DateTime.Now,
                                FechaCotizaciones = DateTime.Now,
                                Estatus = 1,
                                CostoMOCotizado = double.Parse(MO),
                                CostoMaterialCotizado = double.Parse(CM),
                                CostoMECotizado = double.Parse(CE),
                                SavingPorcentaje = decimal.Parse(pSaving),
                                IvaPorcentaje = decimal.Parse(pIva),
                                VendidoPor = Guid.Parse(VendidoPor),
                                Sucursal = Guid.Parse(Sucursal)
                            };
                            DataControl.tblCotizaciones.Add(add);
                            DataControl.SaveChanges();
                            idCotizacionNueva = add.IdCotizaciones;

                            retorno = "Cotizacion creada." + idCotizacionNueva.ToString();
                        }
                    }
                    else
                    {
                        retorno = "No tienes permiso.";
                    }

                }
            }
            catch(Exception ex)
            {
                retorno = ex.Message;
            }
            
            return retorno;

        }

        [WebMethod]
        public static string CrearCotizacionItem(string item, string Descripcion, string Cantidad, string Unidad, string Precio, string Importe)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.CotizacionesAgregar == true || rolesUsuarios.Tipo == "ROOT")
            {    using (var DataControl = new SisaEntitie())
                {
                    tblCotizacionesDet add = new tblCotizacionesDet
                    {
                        idCotDetalle = Guid.NewGuid(),
                        idCotizacion = idCotizacionNueva,
                        TimeStamp = DateTime.Now,
                        Descripcion = Descripcion,
                        Cantidad = decimal.Parse(Cantidad),
                        Unidad = Unidad,
                        Precio = decimal.Parse(Precio),
                        Importe = decimal.Parse(Importe),
                        idUsuarioAlta = usuario.IdUsuario,
                        Estatus = 1

                    };
                    DataControl.tblCotizacionesDet.Add(add);
                    DataControl.SaveChanges();
                    retorno = "Cotizacion creada.";
                }
            }
            else
            {
                retorno = "No tienes permiso.";
            }
            return retorno;

        }

        [WebMethod]
        public static string CrearCotizacionModifica(string idContacto, string idEmpresa, string RFQ, string txtDescripcionCotizaCompleta, string CostoCotizacion
            , string idCotiza, string MO, string CM, string CE, string pIva, string pSaving, string CreadoPor, string VendidoPor, string Sucursal)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            try
            {
                using (var DataControl = new SisaEntitie())
                {
                    if (rolesUsuarios.CotizacionesAgregar == true || rolesUsuarios.Tipo == "ROOT")
                    {
                        if (!string.IsNullOrEmpty(RFQ))
                        {
                            //var parametro = new ObjectParameter("Folio", typeof(string));
                            //DataControl.sp_ObtieneFolioCotizacion(parametro).ToString();
                            Guid id = Guid.Parse(idCotiza);
                            var folioCotizacion = DataControl.tblCotizaciones.FirstOrDefault(a => a.IdCotizaciones == id);

                            var cont = (from o in DataControl.tblCotizaciones
                                        where o.NoCotizaciones == folioCotizacion.NoCotizaciones
                                        select o).Count();

                            var idSolicitud = DataControl.tblSolicitudCotizacion_CCM.FirstOrDefault(d => d.Folio == RFQ);
                            if (idSolicitud != null)
                            {
                                //parametro.Value.ToString()
                                tblCotizaciones add = new tblCotizaciones
                                {
                                    IdCotizaciones = Guid.NewGuid(),
                                    idContacto = Guid.Parse(idContacto),
                                    IdEmpresa = Guid.Parse(idEmpresa),
                                    idRequisicion = idSolicitud.idSolicitudCotizacion,
                                    NoCotizaciones = folioCotizacion.NoCotizaciones.ToString(),
                                    FolioModificacion = cont.ToString("00"),
                                    Concepto = txtDescripcionCotizaCompleta,
                                    CostoCotizaciones = decimal.Parse(CostoCotizacion),
                                    IdUsuarioCreo = Guid.Parse(CreadoPor),//usuario.IdUsuario,
                                    IdUsuarioEnvia = usuario.IdUsuario,
                                    TIMESTAMP = DateTime.Now,
                                    FechaCotizaciones = DateTime.Now,
                                    Estatus = 1,
                                    CostoMOCotizado = double.Parse(MO),
                                    CostoMaterialCotizado = double.Parse(CM),
                                    CostoMECotizado = double.Parse(CE),
                                    SavingPorcentaje = decimal.Parse(pSaving),
                                    IvaPorcentaje = decimal.Parse(pIva),
                                    VendidoPor = Guid.Parse(VendidoPor),
                                    Sucursal = Guid.Parse(Sucursal)
                                };
                                DataControl.tblCotizaciones.Add(add);
                                DataControl.SaveChanges();
                                idCotizacionNueva = add.IdCotizaciones;

                                retorno = "Cotizacion Modificada." + idCotizacionNueva.ToString();

                            }
                            else
                            {
                                retorno = "No se encontro RFQ, verifica el folio.";

                            }
                        }
                        else
                        {
                            //var parametro = new ObjectParameter("Folio", typeof(string));
                            //DataControl.sp_ObtieneFolioCotizacion(parametro).ToString();
                            Guid id = Guid.Parse(idCotiza);
                            var folioCotizacion = DataControl.tblCotizaciones.FirstOrDefault(a => a.IdCotizaciones == id);

                            var cont = (from o in DataControl.tblCotizaciones
                                        where o.NoCotizaciones == folioCotizacion.NoCotizaciones
                                        select o).Count();

                            tblCotizaciones add = new tblCotizaciones
                            {
                                IdCotizaciones = Guid.NewGuid(),
                                idContacto = Guid.Parse(idContacto),
                                IdEmpresa = Guid.Parse(idEmpresa),
                                idRequisicion = null,
                                NoCotizaciones = folioCotizacion.NoCotizaciones.ToString(),
                                FolioModificacion = cont.ToString("00"),
                                Concepto = txtDescripcionCotizaCompleta,
                                CostoCotizaciones = decimal.Parse(CostoCotizacion),
                                IdUsuarioCreo = Guid.Parse(CreadoPor),//usuario.IdUsuario,
                                IdUsuarioEnvia = usuario.IdUsuario,
                                TIMESTAMP = DateTime.Now,
                                FechaCotizaciones = DateTime.Now,
                                Estatus = 1,
                                CostoMOCotizado = double.Parse(MO),
                                CostoMaterialCotizado = double.Parse(CM),
                                CostoMECotizado = double.Parse(CE),
                                SavingPorcentaje = decimal.Parse(pSaving),
                                IvaPorcentaje = decimal.Parse(pIva),
                                VendidoPor = Guid.Parse(VendidoPor),
                                Sucursal = Guid.Parse(Sucursal)
                            };
                            DataControl.tblCotizaciones.Add(add);
                            DataControl.SaveChanges();
                            idCotizacionNueva = add.IdCotizaciones;

                            retorno = "Cotizacion Modificada." + idCotizacionNueva.ToString();
                        }
                    }
                    else
                    {
                        retorno = "No tienes permiso.";
                    }

                }
            }
            catch (Exception ex)
            {
                retorno = ex.Message;
            }

            return retorno;

        }

        [WebMethod]
        public static string CargarDatosEncabezado(string idCotiza)
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                Guid id = Guid.Parse(idCotiza);
                var OCD = DataControl.tblCotizaciones.Where(d => d.IdCotizaciones == id);
                retorno = JsonConvert.SerializeObject(OCD);
            }
            return retorno;

        }

        [WebMethod]
        public static string CargarDatosSolicitud(string idSolicitud)
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                Guid id = Guid.Parse(idSolicitud);
                var OCD = DataControl.tblSolicitudCotizacion_CCM.Where(d => d.idSolicitudCotizacion == id);
                retorno = JsonConvert.SerializeObject(OCD);
            }
            return retorno;

        }

        [WebMethod]
        public static string CargarDatosDetalle(string IdCotiza)
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                Guid id = Guid.Parse(IdCotiza);
                var OCD = DataControl.tblCotizacionesDet.Where(d => d.idCotizacion == id);
                retorno = JsonConvert.SerializeObject(OCD);
            }
            return retorno;

        }

        [WebMethod]
        public static string CargarNotas(string IdCotiza)
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                Guid id = Guid.Parse(IdCotiza);
                var OCD = DataControl.tblNotaAclaratoria.Where(d => d.IdCotizacion == id);
                retorno = JsonConvert.SerializeObject(OCD);
            }
            return retorno;

        }

        [WebMethod]
        public static string CargarFolioRFQ(string pid)
        {
            string retorno = string.Empty;
            if(string.IsNullOrEmpty(pid) || pid == "null")
            {
                //tblRFQ a = new tblRFQ
                //{
                //    Folio = "",

                //};
                retorno = "SIN RFQ";
            }
            else
            {
                using (var DataControl = new SisaEntitie())
                {
                    Guid id = Guid.Parse(pid);
                    var OCD = DataControl.tblSolicitudCotizacion_CCM.Where(d => d.idSolicitudCotizacion == id);
                    retorno = JsonConvert.SerializeObject(OCD);
                }
            }
            return retorno;

        }

        [WebMethod]
        public static string ActualizarCotizacion(string idContacto, string idEmpresa, string RFQ, string txtDescripcionCotizaCompleta
            , string CostoCotizacion, string idCotiza, string MO, string CM, string CE, string pIva, string pSaving, string CreadoPor, string VendidoPor, string Sucursal)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.CotizacionesEditar == true || rolesUsuarios.Tipo == "ROOT")
            {
                using (var DataControl = new SisaEntitie())
                {
                    if (!string.IsNullOrEmpty(RFQ))
                    {
                        var Rfq = DataControl.tblSolicitudCotizacion_CCM.FirstOrDefault(r => r.Folio == RFQ);
                        if (Rfq != null)
                        {
                            idCotizacionNueva = Guid.Parse(idCotiza);
                            var CotExiste = DataControl.tblCotizaciones.FirstOrDefault(c => c.IdCotizaciones == idCotizacionNueva);
                            if (CotExiste != null)
                            {
                                CotExiste.IdEmpresa = Guid.Parse(idEmpresa);
                                CotExiste.idContacto = Guid.Parse(idContacto);
                                CotExiste.idRequisicion = Rfq.idSolicitudCotizacion;
                                CotExiste.Concepto = txtDescripcionCotizaCompleta;
                                CotExiste.CostoCotizaciones = decimal.Parse(CostoCotizacion);
                                CotExiste.CostoMOCotizado = double.Parse(MO);
                                CotExiste.CostoMaterialCotizado = double.Parse(CM);
                                CotExiste.CostoMECotizado = double.Parse(CE);
                                CotExiste.SavingPorcentaje = decimal.Parse(pSaving);
                                CotExiste.IvaPorcentaje = decimal.Parse(pIva);
                                CotExiste.IdUsuarioCreo = Guid.Parse(CreadoPor);
                                CotExiste.VendidoPor = Guid.Parse(VendidoPor);
                                CotExiste.Sucursal = Guid.Parse(Sucursal);
                                DataControl.SaveChanges();
                                retorno = "Cotizacion actualizada.";
                                var Delete = DataControl.tblCotizacionesDet.Where(d => d.idCotizacion == idCotizacionNueva);
                                if (Delete != null)
                                {
                                    foreach (var d in Delete)
                                    {
                                        DataControl.tblCotizacionesDet.Remove(d);
                                    }
                                    DataControl.SaveChanges();
                                }
                                var DeleteNota = DataControl.tblNotaAclaratoria.Where(d => d.IdCotizacion == idCotizacionNueva);
                                if (DeleteNota != null)
                                {
                                    foreach (var d in DeleteNota)
                                    {
                                        DataControl.tblNotaAclaratoria.Remove(d);
                                    }
                                    DataControl.SaveChanges();
                                }
                            }
                            else
                            {
                                retorno = "No se encontro información de cotización, intenta de nuevo refrescando página.";
                            }


                        }
                        else
                        {

                            retorno = "No se encontro RFQ, verifica el folio.";
                        }
                    }
                    else
                    {
                        idCotizacionNueva = Guid.Parse(idCotiza);
                        var CotExiste = DataControl.tblCotizaciones.FirstOrDefault(c => c.IdCotizaciones == idCotizacionNueva);
                        if (CotExiste != null)
                        {
                            CotExiste.IdEmpresa = Guid.Parse(idEmpresa);
                            CotExiste.idContacto = Guid.Parse(idContacto);
                            CotExiste.Concepto = txtDescripcionCotizaCompleta;
                            CotExiste.CostoCotizaciones = decimal.Parse(CostoCotizacion);
                            CotExiste.CostoMOCotizado = double.Parse(MO);
                            CotExiste.CostoMaterialCotizado = double.Parse(CM);
                            CotExiste.CostoMECotizado = double.Parse(CE);
                            CotExiste.SavingPorcentaje = decimal.Parse(pSaving);
                            CotExiste.IvaPorcentaje = decimal.Parse(pIva);
                            CotExiste.IdUsuarioCreo = Guid.Parse(CreadoPor);
                            CotExiste.VendidoPor = Guid.Parse(VendidoPor);
                            CotExiste.Sucursal = Guid.Parse(Sucursal);
                            DataControl.SaveChanges();
                            retorno = "Cotizacion actualizada.";
                            var Delete = DataControl.tblCotizacionesDet.Where(d => d.idCotizacion == idCotizacionNueva);
                            if (Delete != null)
                            {
                                foreach (var d in Delete)
                                {
                                    DataControl.tblCotizacionesDet.Remove(d);
                                }
                                DataControl.SaveChanges();
                            }
                            var DeleteNota = DataControl.tblNotaAclaratoria.Where(d => d.IdCotizacion == idCotizacionNueva);
                            if (DeleteNota != null)
                            {
                                foreach (var d in DeleteNota)
                                {
                                    DataControl.tblNotaAclaratoria.Remove(d);
                                }
                                DataControl.SaveChanges();
                            }
                        }
                        else
                        {
                            retorno = "No se encontro información de cotización, intenta de nuevo refrescando página.";
                        }
                    }


                }
            }
            else
            {
                retorno = "No tienes permiso.";
            }
            return retorno;

        }

        [WebMethod]
        public static string ObtenerEmpresas(string pid)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            using (var DataControl = new SisaEntitie())
            {
                
                if (rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "ADMINISTRACION" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "COMPRAS")
                {
                    var Empresas = DataControl.tblEmpresas.Where(s => s.Estatus == true);
                    retorno = JsonConvert.SerializeObject(Empresas);
                }
                else
                {
                    var Empresas = DataControl.tblEmpresas.Where(s => s.Estatus == true);
                    retorno = JsonConvert.SerializeObject(Empresas);
                }
                
            }

            return retorno;
        }

        [WebMethod]
        public static string ObtenerSucursales(string pid)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            using (var DataControl = new SisaEntitie())
            {

                if (rolesUsuarios.Tipo == "ROOT" || rolesUsuarios.Tipo == "ADMINISTRACION" || rolesUsuarios.Tipo == "GERENCIAL" || rolesUsuarios.Tipo == "COMPRAS")
                {
                    var Empresas = DataControl.tblSucursales.Where(s => s.Estatus == true);
                    retorno = JsonConvert.SerializeObject(Empresas);
                }
                else
                {
                    var Empresas = DataControl.tblSucursales.Where(s => s.Estatus == true);
                    retorno = JsonConvert.SerializeObject(Empresas);
                }

            }

            return retorno;
        }

        [WebMethod]
        public static string CrearNotasAclaratorias(string Nota)
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                var a = DataControl.sp_InsertaNotaAclaratoria(idCotizacionNueva.ToString(), Nota);
                
                DataControl.SaveChanges();
                retorno = "Nota creada.";

            }
            return retorno;

        }
    }
}