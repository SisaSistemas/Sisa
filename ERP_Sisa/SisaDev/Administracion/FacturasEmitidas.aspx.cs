using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Xml.Linq;

namespace SisaDev.Administracion
{
    public partial class FacturasEmitidas : System.Web.UI.Page
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
        public static string CargarCombos(string Opcion)
        {

            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                int int32 = Convert.ToInt32(Opcion);
                return JsonConvert.SerializeObject((object)sisaEntitie.sp_CargaCombos(new int?(int32)));
            }

        }

        [WebMethod]
        public static string CargarEmitidasBuscar(string Opcion)
        {
            string str = string.Empty;
            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                int int32 = Convert.ToInt32(Opcion);
                if (Opcion == "7")
                {
                    //str = JsonConvert.SerializeObject((object)sisaEntitie.sp_CargaCombosFacturasEmitidas(new int?(int32)));

                    str = JsonConvert.SerializeObject((object)((IQueryable<tblMonedas>)sisaEntitie.tblMonedas).OrderBy<tblMonedas, string>((Expression<Func<tblMonedas, string>>)(d => d.Moneda)).Select(d => new
                    {
                        Id = d.Abreviatura,
                        Nombre = d.Moneda
                    }).Distinct());
                }

                else if (Opcion == "26")
                    str = JsonConvert.SerializeObject((object)((IQueryable<tblProyectos>)sisaEntitie.tblProyectos).Where<tblProyectos>((Expression<Func<tblProyectos, bool>>)(d => d.Activo == (int?)1)).Select(d => new
                    {
                        Id = d.IdProyecto,
                        Nombre = d.FolioProyecto + "-" + d.NombreProyecto
                    }).OrderBy(a => a.Nombre));
                else if (Opcion == "12")
                    str = JsonConvert.SerializeObject((object)((IQueryable<DateDimension>)sisaEntitie.DateDimension).Where<DateDimension>((Expression<Func<DateDimension, bool>>)(d => d.Year <= DateTime.Now.Year)).Select(d => new
                    {
                        Id = d.Year,
                        Nombre = d.Year
                    }).Distinct());
                else if (Opcion == "13")
                {
                    str = JsonConvert.SerializeObject((object)((IQueryable<tblFacturasEmitidas>)sisaEntitie.tblFacturasEmitidas).OrderBy<tblFacturasEmitidas, string>((Expression<Func<tblFacturasEmitidas, string>>)(d => d.NombreReceptor)).Select(d => new
                    {
                        Id = d.NombreReceptor,
                        Nombre = d.NombreReceptor
                    }).Distinct());
                }
                    
            }
            return str;
        }

        //[WebMethod]
        //public static string CargarRecibidasBuscar(string Opcion)
        // {

        //     using (SisaEntitie sisaEntitie = new SisaEntitie())
        //     {
        //         int int32 = Convert.ToInt32(Opcion);
        //         return JsonConvert.SerializeObject((object)sisaEntitie.sp_CargarCombosFacturasRecibidas(new int?(int32)));
        //     }
        // }        

        [WebMethod]
        public static string CargarOC(string pid)
        {
            string empty = string.Empty;
            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                Guid id = Guid.Parse(pid);
                return JsonConvert.SerializeObject((object)((IQueryable<tblOrdenCompra>)sisaEntitie.tblOrdenCompra).Where<tblOrdenCompra>((Expression<Func<tblOrdenCompra, bool>>)(a => a.IdProveedor == id)).Select(a => new
                {
                    Folio = a.Folio.ToUpper(),
                    TipoOC = a.TipoOC.ToUpper()
                }).Union(((IQueryable<tblOrdenCompraInsumos>)sisaEntitie.tblOrdenCompraInsumos).Where<tblOrdenCompraInsumos>((Expression<Func<tblOrdenCompraInsumos, bool>>)(b => b.IdProveedor == id)).Select(b => new
                {
                    Folio = b.Folio.ToUpper(),
                    TipoOC = "MATERIAL"
                })));
            }

        }

        [WebMethod]
        public static string CargarFacturas(string pid)
        {
            string str = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            bool? facturasEmitidas;
            if (!(rolesUsuarios.Tipo == "ROOT") && !(rolesUsuarios.Tipo == "GERENCIAL") && !(rolesUsuarios.Tipo == "ADMINISTRACION") && !rolesUsuarios.FacEmitidas)
            {
                facturasEmitidas = rolesUsuarios.FacEmitidas;
                bool flag = true;
                if (!(facturasEmitidas.GetValueOrDefault() == flag & facturasEmitidas.HasValue))
                {
                    str = "Error, no tienes permiso";
                    goto label_13;
                }
            }
            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                if (pid == "2")
                {
                    facturasEmitidas = rolesUsuarios.FacEmitidas;
                    bool flag = true;
                    if (facturasEmitidas.GetValueOrDefault() == flag & facturasEmitidas.HasValue)
                    {
                        Convert.ToInt32("-1");
                        str = JsonConvert.SerializeObject((object)((IEnumerable<sp_CargarFacturasEmitidas_Result>)sisaEntitie.sp_CargarFacturasEmitidas("-1")).OrderByDescending<sp_CargarFacturasEmitidas_Result, DateTime>((Func<sp_CargarFacturasEmitidas_Result, DateTime>)(a => a.FechaFactura)));
                        goto label_13;
                    }
                }
                str = "No tienes permiso de acceso.";
                
            }
        label_13:
            return str;
        }

        [WebMethod]
        public static string CargarBusquedaEmitidas(string pid, string AnioBuscar, string ClienteBuscar, string ProyectoEmitidaBuscar, string MonedaEmitidaBuscar, string EstatusEmitidas, string Enviada)
        {
            string empty = string.Empty;
            if (AnioBuscar == "null")
            {
                AnioBuscar = "-1";
            }

            if (ClienteBuscar == "null")
            {
                ClienteBuscar = "-1";
            }

            if (ProyectoEmitidaBuscar == "null")
            {
                ProyectoEmitidaBuscar = "-1";
            }

            if (MonedaEmitidaBuscar == "null")
            {
                MonedaEmitidaBuscar = "-1";
            }

            if (EstatusEmitidas == "null")
            {
                EstatusEmitidas = "-1";
            }

            if (Enviada == "null")
            {
                Enviada = "-1";
            }

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("JT_LoadFacturasEmitidas", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Anio", (object)AnioBuscar);
            sqlCommand.Parameters.AddWithValue("@Cliente", (object)ClienteBuscar);
            sqlCommand.Parameters.AddWithValue("@IdProyecto", (object)ProyectoEmitidaBuscar);
            sqlCommand.Parameters.AddWithValue("@Moneda", (object)MonedaEmitidaBuscar);
            sqlCommand.Parameters.AddWithValue("@Estatus", (object)EstatusEmitidas);
            sqlCommand.Parameters.AddWithValue("@Enviada", (object)Enviada);
            DataTable dataTable = new DataTable();
            dataTable.Load((IDataReader)sqlCommand.ExecuteReader());
            return JsonConvert.SerializeObject((object)dataTable);
        }


        [WebMethod]
        public static string CargarFacturasEmitidas(string anio, string cliente, string proyecto, string moneda, string estatus)
        {
            string retorno = string.Empty;

            try
            {
                using (var DataControl = new SisaEntitie())
                {
                    if (anio == "null")
                    {
                        anio = "-1";
                    }

                    if (cliente == "null")
                    {
                        cliente = "-1";
                    }

                    if (proyecto == "null")
                    {
                        proyecto = "-1";
                    }

                    if (moneda == "null")
                    {
                        moneda = "-1";
                    }

                    if (estatus == "null")
                    {
                        estatus = "-1";
                    }
                    int e = Convert.ToInt32(estatus);
                    SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
                    connection.Open();
                    SqlCommand command = new SqlCommand("sp_ResumenTotalesFacturasEmitidas", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Anio", anio);
                    command.Parameters.AddWithValue("@Cliente", cliente);
                    command.Parameters.AddWithValue("@IdProyecto", proyecto);
                    command.Parameters.AddWithValue("@Moneda", moneda);
                    command.Parameters.AddWithValue("@Estatus", estatus);


                    DataTable dt = new DataTable();

                    dt.Load(command.ExecuteReader());

                    return JsonConvert.SerializeObject(dt);
                    //retorno = JsonConvert.SerializeObject(DataControl.sp_ResumenTotalesFacturasEmitidas(anio,cliente,proyecto,moneda,e));
                }
            }
            catch (Exception e)
            {
                retorno = e.Message;
            }
            return retorno;
        }

        [WebMethod]
        public static string GuardarArchivosEmitida(string pid, string NombreArchivo, string Documento)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            try
            {
                using (var DataControl = new SisaEntitie())
                {
                    //var Sube = DataControl.sp_SubeArchivosFacturas(pid, NombreArchivo, Documento);
                    var Data = DataControl.tblFacturasEmitidas.FirstOrDefault(s => s.IdFacturasEmitidas.ToString() == pid);
                    if (Data != null)
                    {
                        Data.NombreArchivo = NombreArchivo;
                        Data.ArchivoPDF = Documento;
                        DataControl.SaveChanges();
                        retorno = "Factura actualizada.";
                    }
                    else
                    {
                        retorno = "";
                    }
                }

            }
            catch (Exception e)
            {
                retorno = e.ToString();
            }
            return retorno;
        }

        [WebMethod]
        public static string CargarDocumentos(string IdControlFacturas, string Opcion)
        {
            string retorno = string.Empty;
            try
            {
                using (var DataControl = new SisaEntitie())
                {
                    if (Opcion == "FR")
                    {
                        var proyects = (from p in DataControl.tblControlFacturas
                                        where p.IdControlFacturas.ToString() == IdControlFacturas
                                        select new { p.NombreArchivo, p.ArchivoFactura, p.IdControlFacturas });
                        retorno = JsonConvert.SerializeObject(proyects);
                    }
                    else if (Opcion == "FE")
                    {
                        var proyects = (from p in DataControl.tblFacturasEmitidas
                                        where p.IdFacturasEmitidas.ToString() == IdControlFacturas
                                        select new { p.NombreArchivo, ArchivoFactura = p.ArchivoPDF, IdControlFacturas = p.IdFacturasEmitidas });
                        retorno = JsonConvert.SerializeObject(proyects);
                    }
                }
            }
            catch (Exception e)
            {
                retorno = e.ToString();
            }
            return retorno;
        }

        [WebMethod]
        public static string EliminarDocumento(string pid, string Opcion)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            try
            {
                if (rolesUsuarios.ControlFacturas == true || rolesUsuarios.Tipo == "ROOT")
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        if (Opcion == "FR")
                        {
                            var proyects = DataControl.tblControlFacturas.FirstOrDefault(p => p.IdControlFacturas.ToString() == pid);
                            if (proyects != null)
                            {
                                proyects.NombreArchivo = "";
                                proyects.ArchivoFactura = "";
                                DataControl.SaveChanges();
                                retorno = "Documento eliminado.";
                            }
                            else
                            {
                                retorno = "No se encontro información de documento, intenta de nuevo recargando página";
                            }
                        }
                        else if (Opcion == "FE")
                        {
                            var proyects = DataControl.tblFacturasEmitidas.FirstOrDefault(p => p.IdFacturasEmitidas.ToString() == pid);
                            if (proyects != null)
                            {
                                proyects.NombreArchivo = "";
                                proyects.ArchivoPDF = "";
                                DataControl.SaveChanges();
                                retorno = "Documento eliminado.";
                            }
                            else
                            {
                                retorno = "No se encontro información de documento, intenta de nuevo recargando página";
                            }
                        }
                    }
                }
                else
                {
                    retorno = "No tienes permisos.";
                }
            }
            catch (Exception e)
            {
                retorno = e.ToString();
            }
            return retorno;
        }

        [WebMethod]
        public static string GuardarXml(string NombreArchivo, string Archivo)
        {
            string empty = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;

            string[] strArray = Archivo.Split(',');

            Encoding.ASCII.GetString(Convert.FromBase64String(strArray[1]));

            string str1 = AppDomain.CurrentDomain.BaseDirectory + "\\FacturasXML\\";

            File.WriteAllBytes(str1 + NombreArchivo, Convert.FromBase64String(strArray[1]));

            string str2 = str1 + NombreArchivo;

            XNamespace xnamespace1 = (XNamespace)"http://www.sat.gob.mx/cfd/4";
            XNamespace xnamespace2 = (XNamespace)"http://www.sat.gob.mx/TimbreFiscalDigital";

            XDocument xdocument = XDocument.Load(str2);
            XElement xelement1 = xdocument.Element(xnamespace1 + "Comprobante");
            XElement xelement2 = xdocument.Element(xnamespace1 + "Comprobante").Element(xnamespace1 + "Receptor");
            XElement xelement3 = xdocument.Element(xnamespace1 + "Comprobante").Element(xnamespace1 + "Impuestos");

            string folioFactura = (string)xelement1.Attribute((XName)"Folio");
            string s1 = (string)xelement1.Attribute((XName)"Fecha");
            string rfcReceptor = (string)xelement2.Attribute((XName)"Rfc");
            string nombreReceptor = (string)xelement2.Attribute((XName)"Nombre");
            string s2 = (string)xelement1.Attribute((XName)"SubTotal");
            string s3;
            string s4;

            if (xelement3 == null)
            {
                s3 = "0.00";
                s4 = "0.00";
            }
            else
            {
                s3 = (string)xelement3.Attribute((XName)"TotalImpuestosTrasladados");
                s4 = (string)xelement3.Attribute((XName)"TotalImpuestosRetenidos");
            }

            string s5 = (string)xelement1.Attribute((XName)"Total");
            string moneda = (string)xelement1.Attribute((XName)"Moneda");
            string s6 = (string)xelement1.Attribute((XName)"TipoCambio");

            if (File.Exists(str2))
            {
                File.Delete(str2);
            }

            if (s4 == null)
            {
                s4 = "0.00";
            }

            if (s6 == null)
            {
                s6 = "1.00";
            }

            try
            {
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                    sisaEntitie.sp_InsertFacturasEmitidas(folioFactura, new DateTime?(DateTime.Parse(s1)), rfcReceptor, nombreReceptor, new Decimal?(Decimal.Parse(s2)), new Decimal?(Decimal.Parse(s3)), new Decimal?(Decimal.Parse(s4)), new Decimal?(Decimal.Parse(s5)), moneda, new Decimal?(Decimal.Parse(s6)), usuario.IdUsuario.ToString());
                return "Factura emitida, agregada.";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            //string retorno = string.Empty;
            //usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            //rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            //string archivoBase64 = "";

            //archivoBase64 = Archivo;

            //string[] completo64 = archivoBase64.Split(',');
            //var originalString = ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(completo64[1]));
            //string a = AppDomain.CurrentDomain.BaseDirectory + "\\FacturasXML\\";
            ////File.WriteAllBytes(@"\\win-s20lmo4rao9\FacturasXML\" + NombreArchivo, Convert.FromBase64String(completo64[1]));
            //File.WriteAllBytes(a + NombreArchivo, Convert.FromBase64String(completo64[1]));

            ////XmlDocument doc = new XmlDocument();
            ////doc.Load(@"\\win-s20lmo4rao9\FacturasXML\" + NombreArchivo);
            ////XmlNodeReader nodereader = new XmlNodeReader(doc);
            ////while (nodereader.Read())
            ////{
            ////    // Read the XmlDocument as a stream of XML.
            ////}

            //// sustituir por la ruta de tu xml
            ////string rutaXML = @"\\win-s20lmo4rao9\FacturasXML\" + NombreArchivo;

            //string rutaXML = a  + NombreArchivo;

            ////variables del esquema
            //XNamespace cfdi = @"http://www.sat.gob.mx/cfd/3";
            //XNamespace tfd = @"http://www.sat.gob.mx/TimbreFiscalDigital";

            ////cargamos el xml
            //var xdoc = XDocument.Load(rutaXML);

            //var _comprobante = xdoc.Element(cfdi + "Comprobante");
            //var _receptor = xdoc.Element(cfdi + "Comprobante").Element(cfdi + "Receptor");
            //var _impuestos = xdoc.Element(cfdi + "Comprobante").Element(cfdi + "Impuestos");


            //var folioFactura = (string)_comprobante.Attribute("Folio");
            //var fecha = (string)_comprobante.Attribute("Fecha");

            //var rfcReceptor = (string)_receptor.Attribute("Rfc");
            //var nombreReceptor = (string)_receptor.Attribute("Nombre");

            //var subTotal = (string)_comprobante.Attribute("SubTotal");
            //var iva = "";
            //var retencion = "";

            //if (_impuestos == null)
            //{
            //    iva = "0.00";
            //    retencion = "0.00";
            //}
            //else
            //{
            //    iva = (string)_impuestos.Attribute("TotalImpuestosTrasladados");
            //    retencion = (string)_impuestos.Attribute("TotalImpuestosRetenidos");
            //}

            //var total = (string)_comprobante.Attribute("Total");
            //var moneda = (string)_comprobante.Attribute("Moneda");
            //var tipoCambio = (string)_comprobante.Attribute("TipoCambio");

            //if (File.Exists(rutaXML))
            //{
            //    File.Delete(rutaXML);
            //}
            //if(retencion == null)
            //{
            //    retencion = "0.00";
            //}
            //try
            //{
            //    using (var DataControl = new SisaEntitie())
            //    {
            //        var inser = DataControl.sp_InsertFacturasEmitidas(folioFactura, DateTime.Parse(fecha), rfcReceptor, nombreReceptor, decimal.Parse(subTotal), decimal.Parse(iva), decimal.Parse(retencion), decimal.Parse(total), moneda, decimal.Parse(tipoCambio), usuario.IdUsuario.ToString());
            //    }
            //    retorno = "Factura emitida, agregada.";
            //}
            //catch (Exception e)
            //{
            //    retorno =  e.ToString();
            //}

            //////Navegamos hasta el elemento que contiene el UUID
            ////var elt = xdoc.Element(cfdi + "Comprobante")
            ////              .Element(cfdi + "Complemento")
            ////              .Element(tfd + "TimbreFiscalDigital");

            //////listo obtenemos el UUID
            ////var uuid = (string)elt.Attribute("UUID");

            ////return "";
            //return retorno;
        }

        [WebMethod]
        public static string CargarFacturaEmitida(string pid)
        {
            string str = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            try
            {
                if (rolesUsuarios.ControlFacturas || rolesUsuarios.Tipo == "ROOT")
                {
                    using (SisaEntitie sisaEntitie = new SisaEntitie())
                        str = JsonConvert.SerializeObject((object)((IQueryable<tblFacturasEmitidas>)sisaEntitie.tblFacturasEmitidas).Where<tblFacturasEmitidas>((Expression<Func<tblFacturasEmitidas, bool>>)(A => A.IdFacturasEmitidas.ToString() == pid)).Select(A => new
                        {
                            FolioFactura = A.FolioFactura,
                            FechaFactura = A.FechaFactura,
                            RfcReceptor = A.RfcReceptor,
                            NombreReceptor = A.NombreReceptor,
                            IdProyecto = A.IdProyecto,
                            NoCotizacion = A.NoCotizacion,
                            OrdenCompraRecibida = A.OrdenCompraRecibida,
                            Estatus = A.Estatus,
                            Moneda = A.Moneda,
                            SubTotal = A.SubTotal,
                            Iva = A.Iva,
                            Total = A.Total,
                            PorPagar = A.PorPagar,
                            TipoCambio = A.TipoCambio,
                            FechaPago = A.FechaPago,
                            ProgramacionPago = A.ProgramacionPago,
                            Enviada = A.Enviada,
                            CorreoEnviado = A.CorreoEnviado,
                            FechaPA = A.FechaPA
                        }));
                }
                else
                    str = "No tienes permiso.";
            }
            catch (Exception ex)
            {
                str = ex.ToString();
            }
            return str;
        }

        [WebMethod]
        public static string EditarFactura(string IdFacturasEmitidas, string IdProyecto, string NoCotizacion, string NoOrdenCompra, string ProgramacionPago, string PorPagar, string FechaPago, string Estatus, string FechaPA, string EstatusEnviado, string CorreoEnviado)
        {
            string str = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            try
            {
                if (rolesUsuarios.ControlFacturas || rolesUsuarios.Tipo == "ROOT")
                {
                    using (SisaEntitie sisaEntitie = new SisaEntitie())
                    {
                        tblFacturasEmitidas facturasEmitidas = ((IQueryable<tblFacturasEmitidas>)sisaEntitie.tblFacturasEmitidas).FirstOrDefault<tblFacturasEmitidas>((Expression<Func<tblFacturasEmitidas, bool>>)(a => a.IdFacturasEmitidas.ToString() == IdFacturasEmitidas));
                        if (facturasEmitidas != null)
                        {
                            Decimal num = 0;//string.IsNullOrEmpty(Retencion) ? 0M : Decimal.Parse(Retencion);
                            facturasEmitidas.NoCotizacion = NoCotizacion;
                            facturasEmitidas.OrdenCompraRecibida = NoOrdenCompra;
                            facturasEmitidas.IdProyecto = IdProyecto;
                            if (ProgramacionPago != "")
                                facturasEmitidas.ProgramacionPago = new DateTime?(DateTime.Parse(ProgramacionPago));
                            if (FechaPago != "")
                                facturasEmitidas.FechaPago = new DateTime?(DateTime.Parse(FechaPago));
                            if (FechaPA != "")
                            {
                                facturasEmitidas.FechaPA = new DateTime?(DateTime.Parse(FechaPA));
                            }
                            facturasEmitidas.PorPagar = new Decimal?(Decimal.Parse(PorPagar));
                            facturasEmitidas.Estatus = int.Parse(Estatus);
                            facturasEmitidas.FechaModificacion = new DateTime?(DateTime.Now);
                            facturasEmitidas.IdUsuarioModificacion = new Guid?(usuario.IdUsuario);
                            facturasEmitidas.Retencion = new Decimal?(num);
                            facturasEmitidas.Enviada = int.Parse(EstatusEnviado);
                            facturasEmitidas.CorreoEnviado = CorreoEnviado;
                            sisaEntitie.SaveChanges();
                            str = "Factura actualizada.";
                        }
                        else
                            str = "Ocurrio un error, recarga página e intenta de nuevo.";
                    }
                }
                else
                    str = "No tienes permiso.";
            }
            catch (Exception ex)
            {
                str = ex.ToString();
            }
            return str;
        }

        [WebMethod]
        public static string AgregarFacturaEmitida(string folioFactura, string fecha, string rfcReceptor, string nombreReceptor, string subTotal, string iva, string FechaPA, string total, string moneda, string tipoCambio, string IdProyecto, string NoCotizacion, string NoOrdenCompra, string ProgramacionPago, string PorPagar, string FechaPago, string Estatus)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            try
            {
                if (rolesUsuarios.ControlFacturas == true || rolesUsuarios.Tipo == "ROOT")
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        tblFacturasEmitidas add = new tblFacturasEmitidas
                        {
                            IdFacturasEmitidas = Guid.NewGuid(),
                            FolioFactura = folioFactura,
                            FechaAlta = DateTime.Now,
                            FechaFactura = DateTime.Parse(fecha),
                            FechaModificacion = DateTime.Now,
                            IdUsuario = usuario.IdUsuario,
                            IdUsuarioModificacion = usuario.IdUsuario,
                            Estatus = int.Parse(Estatus),
                            IdProyecto = IdProyecto,
                            RfcReceptor = rfcReceptor,
                            NombreReceptor = nombreReceptor,
                            NoCotizacion = NoCotizacion,
                            OrdenCompraRecibida = NoOrdenCompra,
                            SubTotal = decimal.Parse(subTotal),
                            Iva = decimal.Parse(iva),
                            Total = decimal.Parse(total),
                            Moneda = moneda,
                            PorPagar = PorPagar.Length > 0 ? decimal.Parse(PorPagar) : 0,
                            TipoCambio = decimal.Parse(tipoCambio),
                            Retencion = 0
                        };
                        DataControl.tblFacturasEmitidas.Add(add);
                        DataControl.SaveChanges();
                        if (FechaPago.Length > 0)
                        {
                            add.FechaPago = DateTime.Parse(FechaPago);
                            DataControl.SaveChanges();
                        }
                        if (ProgramacionPago.Length > 0)
                        {
                            add.ProgramacionPago = DateTime.Parse(ProgramacionPago);
                            DataControl.SaveChanges();
                        }
                        if (FechaPA.Length > 0)
                        {
                            add.FechaPA = DateTime.Parse(FechaPA);
                            DataControl.SaveChanges();
                        }

                        retorno = "Factura guardada.";
                    }
                }
                else
                {
                    retorno = "No tienes permiso.";
                }
            }
            catch (Exception e)
            {
                retorno = e.ToString();
            }
            return retorno;
        }

        [WebMethod]
        public static string EliminarFacturas(string pid, string Opcion)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ControlFacturas == true || rolesUsuarios.Tipo == "ROOT")
            {
                try
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        if (Opcion == "FR")
                        {
                            var facturas = DataControl.tblControlFacturas.FirstOrDefault(p => p.IdControlFacturas.ToString() == pid);
                            if (facturas != null)
                            {
                                DataControl.tblControlFacturas.Remove(facturas);
                                DataControl.SaveChanges();
                                retorno = "Documento eliminado.";
                            }
                            else
                            {
                                retorno = "No se encontro información de documento, intenta de nuevo recargando página";
                            }
                        }
                        else if (Opcion == "FE")
                        {
                            var facturas = DataControl.tblFacturasEmitidas.FirstOrDefault(p => p.IdFacturasEmitidas.ToString() == pid);
                            if (facturas != null)
                            {
                                DataControl.tblFacturasEmitidas.Remove(facturas);
                                DataControl.SaveChanges();
                                retorno = "Documento eliminado.";
                            }
                            else
                            {
                                retorno = "No se encontro información de documento, intenta de nuevo recargando página";
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    retorno = e.ToString();
                }
            }
            else
            {
                retorno = "No tienes permiso de eliminar factura.";
            }

            return retorno;
        }

        [WebMethod]
        public static string BuscarProyecto(string pid)
        {
            string retorno = string.Empty;
            using (var DataControl = new SisaEntitie())
            {
                var oc = (from a in DataControl.tblOrdenCompra
                          where a.Folio == pid
                          select new { a.IdProyecto, a.Folio });
                retorno = JsonConvert.SerializeObject(oc);
            }
            return retorno;

        }

        [WebMethod]
        public static string AgregaOrdenParaPagoMultiple(string IdFacturasEmitidas, string Folio, string NombreProyecto, string Total)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;

            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                var idFacturaEmitida = sisaEntitie.tblFacturaEmitidaPagoMultiple.Where(p => p.IdFacturaEmitida.ToString().Equals(IdFacturasEmitidas) && p.IdUsuario.ToString().Equals(usuario.IdUsuario.ToString())).ToList().Count;
                if (idFacturaEmitida <= 0)
                {
                    //generamos el objeto nuevo con la info necesaria para insertarlo en la tabla
                    var nuevoPago = new tblFacturaEmitidaPagoMultiple()
                    {
                        IdFacturaPagoMultiple = Guid.NewGuid(),
                        IdFacturaEmitida = Guid.Parse(IdFacturasEmitidas),
                        Folio = Folio,
                        IdUsuario = usuario.IdUsuario,
                        NombreProyecto = NombreProyecto,
                        Total = decimal.Parse(Total),
                        FechaAlta = DateTime.Now
                    };
                    //agregamos el objeto creado a la tabla del modelo
                    sisaEntitie.tblFacturaEmitidaPagoMultiple.Add(nuevoPago);
                    //con esete codigo se guarda en la base de datos
                    sisaEntitie.SaveChanges();
                    retorno = "pago agregado a la lista";
                }
            }
            return retorno;
        }

        [WebMethod]
        public static string EliminaOrdenParaPagoMultiple(string IdFacturasEmitidas, string Folio, string NombreProyecto, string Total)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;

            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                //verificamos que la orden existe en la tabla 
                var pago = sisaEntitie.tblFacturaEmitidaPagoMultiple.Where(p => p.IdFacturaEmitida.ToString().Equals(IdFacturasEmitidas) && p.IdUsuario.ToString().Equals(usuario.IdUsuario.ToString())).FirstOrDefault();
                if (pago != null)
                {
                    //el pago existe
                    sisaEntitie.tblFacturaEmitidaPagoMultiple.Remove(pago);
                    //guardamos los cambios en la base de datos
                    sisaEntitie.SaveChanges();
                    retorno = "Pago eliminado";
                }
            }
            return retorno;
        }

        [WebMethod]
        public static string CuantosParaPagoMultiple(string id)
        {
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                return JsonConvert.SerializeObject((object)sisaEntitie.tblFacturaEmitidaPagoMultiple.Where(p => p.IdUsuario.ToString().Equals(usuario.IdUsuario.ToString())).ToList().Count.ToString());
            }
        }

        [WebMethod]
        public static string obtienePagosMultiplesPendientes(string id)
        {
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            string retorno = string.Empty;
            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                retorno = JsonConvert.SerializeObject((object)sisaEntitie.tblFacturaEmitidaPagoMultiple.Where(p => p.IdUsuario.ToString().Equals(usuario.IdUsuario.ToString())).ToList());
            }
            return retorno;
        }

        [WebMethod]
        public static string guardaPagosMultiples(string _fecha, string _estatus)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                var ordenes = sisaEntitie.tblFacturaEmitidaPagoMultiple.Where(p => p.IdUsuario.ToString().Equals(usuario.IdUsuario.ToString())).ToList();
                foreach (var orden in ordenes)
                {
                    //sisaEntitie.spInsertPagosFacturasOrdenes(orden.IdOrdenCompra.ToString(), _fecha, Convert.ToDecimal(orden.Total), _Banco, usuario.IdUsuario.ToString(), "");
                    tblFacturasEmitidas facturasEmitidas = ((IQueryable<tblFacturasEmitidas>)sisaEntitie.tblFacturasEmitidas).FirstOrDefault<tblFacturasEmitidas>((Expression<Func<tblFacturasEmitidas, bool>>)(a => a.IdFacturasEmitidas == orden.IdFacturaEmitida));
                    if (facturasEmitidas != null)
                    {
                        if (_fecha != "")
                            facturasEmitidas.FechaPago = new DateTime?(DateTime.Parse(_fecha));
                       
                        facturasEmitidas.PorPagar = new Decimal?(Decimal.Parse("0.00"));
                        facturasEmitidas.Estatus = int.Parse(_estatus);
                        facturasEmitidas.FechaModificacion = new DateTime?(DateTime.Now);
                        facturasEmitidas.IdUsuarioModificacion = new Guid?(usuario.IdUsuario);
                        sisaEntitie.SaveChanges();
                        retorno = "Factura actualizada.";
                    }


                    sisaEntitie.tblFacturaEmitidaPagoMultiple.Remove(orden);
                }
                sisaEntitie.SaveChanges();
                //verificamos que no haya pagoa pendientes en la tabla para el usuario en curso
                if (sisaEntitie.tblFacturaEmitidaPagoMultiple.Where(p => p.IdUsuario.ToString().Equals(usuario.IdUsuario.ToString())).ToList().Count > 0)
                {
                    retorno = "Ocurrio un error al intentar guardar los pagos!!!";
                }
                else
                {
                    retorno = "Facturas pagadas.";
                }
            }
            return retorno;
        }
    }
}