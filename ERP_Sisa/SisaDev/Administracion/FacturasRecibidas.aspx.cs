using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace SisaDev.Administracion
{
    public partial class FacturasRecibidas : System.Web.UI.Page
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
        public static string CargarFacturas(string pid)
        {
            string str = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            bool? facturasEmitidas;
            if (!(rolesUsuarios.Tipo == "ROOT") && !(rolesUsuarios.Tipo == "GERENCIAL") && !(rolesUsuarios.Tipo == "ADMINISTRACION") && !rolesUsuarios.FacRecibidas)
            {
                facturasEmitidas = rolesUsuarios.FacRecibidas;
                bool flag = true;
                if (!(facturasEmitidas.GetValueOrDefault() == flag & facturasEmitidas.HasValue))
                {
                    str = "Error, no tienes permiso";
                    goto label_13;
                }
            }
            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                if (pid == "1" && rolesUsuarios.FacRecibidas)
                {
                    Convert.ToInt32("-1");
                    str = JsonConvert.SerializeObject((object)sisaEntitie.sp_CargarFacturasRecibidas("-1").OrderByDescending(a => a.FechaFactura));
                    //str = JsonConvert.SerializeObject((object)((IEnumerable<sp_CargarFacturasRecibidas_Result>)sisaEntitie.sp_CargarFacturasRecibidas("-1")).OrderByDescending<sp_CargarFacturasRecibidas_Result, string>((Func<sp_CargarFacturasRecibidas_Result, string>)(a => a.FechaFactura)));
                }
                else
                {
                    
                    str = "No tienes permiso de acceso.";
                }
            }
        label_13:
            return str;
        }

        [WebMethod]
        public static string CargarResumenRecibidas(string mes, string idProveedor, string noFactura, string proyecto, string moneda, string estatus, string oc, string anio)
        {
            string retorno = string.Empty;

            try
            {
                if (mes == "null")
                {
                    mes = "-1";
                }

                if (idProveedor == "null")
                {
                    idProveedor = "-1";
                }

                if (noFactura == "null")
                {
                    noFactura = "-1";
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

                if (anio == "null")
                {
                    anio = "-1";
                }

                if (oc == "null")
                {
                    oc = "-1";
                }
                SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("sp_ResumenTotales", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Mes", mes);
                command.Parameters.AddWithValue("@IdProveedor", idProveedor);
                command.Parameters.AddWithValue("@NoFactura", noFactura);
                command.Parameters.AddWithValue("@Proyecto", proyecto);
                command.Parameters.AddWithValue("@Moneda", moneda);
                command.Parameters.AddWithValue("@Estatus", estatus);
                command.Parameters.AddWithValue("@Anio", anio);
                command.Parameters.AddWithValue("@OC", oc);


                DataTable dt = new DataTable();

                dt.Load(command.ExecuteReader());

                retorno = JsonConvert.SerializeObject(dt);
                //using (var DataControl = new SisaEntitie())
                //{

                //    retorno = JsonConvert.SerializeObject(DataControl.sp_ResumenTotalesRecibidas(Opcion));
                //}
            }
            catch (Exception e)
            {
                retorno = e.Message;
            }
            return retorno;
        }

        [WebMethod]
        public static string CargarRecibidasBuscar(string Opcion)
        {

            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                int int32 = Convert.ToInt32(Opcion);
                return JsonConvert.SerializeObject((object)sisaEntitie.sp_CargarCombosFacturasRecibidas(new int?(int32)));
            }
        }

        [WebMethod]
        public static string CambiarEstatusFR(string array, string FormaPago)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.FacRecibidas == true || rolesUsuarios.Tipo == "ROOT")
            {
                try
                {
                    string[] a = array.Split('|');
                    using (var DataControl = new SisaEntitie())
                    {
                        foreach (var arr in a)
                        {
                            var Existe = DataControl.tblControlFacturas.FirstOrDefault(s => s.IdControlFacturas.ToString() == arr);
                            if (Existe != null)
                            {
                                Existe.Estatus = 1;
                                Existe.FormaPago = Existe.FormaPago + " - " + FormaPago;
                                DataControl.SaveChanges();

                                SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
                                connection.Open();
                                SqlCommand command = new SqlCommand("sp_DeleteFactGlobal", connection);
                                command.CommandType = System.Data.CommandType.StoredProcedure;
                                command.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario.ToString());

                                command.ExecuteNonQuery();
                                connection.Close();
                            }
                            retorno = "Informacion actualizada.";
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
                retorno = "No tienes permiso de modificar factura.";
            }

            return retorno;
        }

        [WebMethod]
        public static string CargarBusquedaRecibidas(string pid, string FechaBuscar, string ProveedorBuscar, string FacturaBuscar, string ProyectoRecibidaBuscar, string MonedaRecibidaBuscar, string EstatusRecibidas, string OC, string FechaAnioBuscar, string FolioOC)
        {
            using (var DataControl = new SisaEntitie())
            {
                int est = Convert.ToInt32("-1");
                if (FechaBuscar == "null")
                {
                    FechaBuscar = "-1";
                }

                if (ProveedorBuscar == "null")
                {
                    ProveedorBuscar = "-1";
                }

                if (FacturaBuscar == "null")
                {
                    FacturaBuscar = "-1";
                }

                if (ProyectoRecibidaBuscar == "null")
                {
                    ProyectoRecibidaBuscar = "-1";
                }

                if (MonedaRecibidaBuscar == "null")
                {
                    MonedaRecibidaBuscar = "-1";
                }

                if (EstatusRecibidas == "null")
                {
                    EstatusRecibidas = "-1";
                }

                if (FechaAnioBuscar == "null")
                {
                    FechaAnioBuscar = "-1";
                }

                if (OC == "null")
                {
                    OC = "-1";
                }

                if (FolioOC == "null")
                {
                    FolioOC = "-1";
                }
                SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("sp_CargarFacturas", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Mes", FechaBuscar);
                command.Parameters.AddWithValue("@IdProveedor", ProveedorBuscar);
                command.Parameters.AddWithValue("@NoFactura", FacturaBuscar);
                command.Parameters.AddWithValue("@Proyecto", ProyectoRecibidaBuscar);
                command.Parameters.AddWithValue("@Moneda", MonedaRecibidaBuscar);
                command.Parameters.AddWithValue("@Estatus", EstatusRecibidas);
                command.Parameters.AddWithValue("@Anio", FechaAnioBuscar);
                command.Parameters.AddWithValue("@OC", OC);
                command.Parameters.AddWithValue("@FolioOC", FolioOC);


                DataTable dt = new DataTable();

                dt.Load(command.ExecuteReader());

                return JsonConvert.SerializeObject(dt);

            }
        }

        [WebMethod]
        public static string EliminarDocumento(string pid, string Opcion)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            try
            {
                if (rolesUsuarios.FacRecibidas == true || rolesUsuarios.Tipo == "ROOT")
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
        public static string CargarCombos(string Opcion)
        {

            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                int int32 = Convert.ToInt32(Opcion);
                return JsonConvert.SerializeObject((object)sisaEntitie.sp_CargaCombos(new int?(int32)));
            }

        }

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
        public static string GuardarFacturaFR(string IdControlFactura, string IdProveedor, string OrdenCompra, string IdProyecto, string FechaFactura, string NoFactura, string Moneda, string SubTotal, string Descuento, string Iva, string Total, string Estatus, string FormaPago, string Viaticos, string Categoria, string Anticipo, string NotaCredito, string Proyecto, string nombrearchivo, string dataarchivo)
        {
            string str = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            try
            {
                if (rolesUsuarios.FacRecibidas || rolesUsuarios.Tipo == "ROOT")
                {
                    using (SisaEntitie sisaEntitie1 = new SisaEntitie())
                    {
                        Guid guid;
                        if (IdProyecto == "B2C9AA16-C340-47A1-8744-5CA73C388F92")
                        {
                            SisaEntitie sisaEntitie2 = sisaEntitie1;
                            string idControlFacturas = IdControlFactura;
                            DateTime? fechaFactura = new DateTime?(DateTime.Parse(FechaFactura));
                            string idProveedor = IdProveedor;
                            string noFactura = NoFactura;
                            string ordenCompra = OrdenCompra;
                            string moneda = Moneda;
                            Decimal? subTotal = new Decimal?(Decimal.Parse(SubTotal));
                            Decimal? descuento = new Decimal?(Decimal.Parse(Descuento));
                            Decimal? iVA = new Decimal?(Decimal.Parse(Iva));
                            Decimal? total = new Decimal?(Decimal.Parse(Total));
                            int? estatus = new int?(int.Parse(Estatus));
                            string formaPago = FormaPago;
                            int? vaticos = new int?(int.Parse(Viaticos));
                            guid = usuario.IdUsuario;
                            string idUsuario = guid.ToString();
                            string categoria = Categoria;
                            Decimal? anticipo = new Decimal?(Decimal.Parse(Anticipo));
                            Decimal? notaCredito = new Decimal?(Decimal.Parse(NotaCredito));
                            string proyecto = Proyecto;
                            string nombreArchivo = nombrearchivo;
                            string archivoFactura = dataarchivo;
                            sisaEntitie2.JT_InsertUpdateControlFacturas(idControlFacturas, fechaFactura, idProveedor, noFactura, ordenCompra, "N/A", moneda, subTotal, descuento, iVA, total, estatus, formaPago, vaticos, idUsuario, categoria, anticipo, notaCredito, proyecto, nombreArchivo, archivoFactura);
                            sisaEntitie1.SaveChanges();
                        }
                        else
                        {
                            var IdControlFacturas = sisaEntitie1.JT_InsertUpdateControlFacturas(IdControlFactura, new DateTime?(DateTime.Parse(FechaFactura)), IdProveedor, NoFactura, OrdenCompra, IdProyecto, Moneda, new Decimal?(Decimal.Parse(SubTotal)), new Decimal?(Decimal.Parse(Descuento)), new Decimal?(Decimal.Parse(Iva)), new Decimal?(Decimal.Parse(Total)), new int?(int.Parse(Estatus)), FormaPago, new int?(int.Parse(Viaticos)), usuario.IdUsuario.ToString(), Categoria, new Decimal?(Decimal.Parse(Anticipo)), new Decimal?(Decimal.Parse(NotaCredito)), Proyecto, nombrearchivo, dataarchivo);
                            sisaEntitie1.SaveChanges();
                        }
                        if (IdControlFactura == "0")
                        {
                            IQueryable<tblControlFacturas> source = ((IQueryable<tblControlFacturas>)sisaEntitie1.tblControlFacturas).Where<tblControlFacturas>((Expression<Func<tblControlFacturas, bool>>)(a => a.IdProveedor.ToString() == IdProveedor && a.NoFactura == NoFactura && a.IdProyecto == IdProyecto && a.Total.ToString() == Total && a.Categoria == Categoria));
                            var selector = source.ToList();

                            foreach (var data in selector)
                            {
                                guid = data.IdControlFacturas;
                                IdControlFactura = guid.ToString();
                            }
                        }
                    }
                    using (SisaEntitie sisaEntitie = new SisaEntitie())
                    {
                        Decimal num1 = Decimal.Parse(Total);
                        if (Moneda == "USD")
                        {
                            Decimal num2 = 20.5M;
                            num1 *= num2;
                        }
                        tblEficienciasDesglose eficienciasDesglose1 = ((IQueryable<tblEficienciasDesglose>)sisaEntitie.tblEficienciasDesglose).FirstOrDefault<tblEficienciasDesglose>((Expression<Func<tblEficienciasDesglose, bool>>)(e => e.idDocumento == IdControlFactura));
                        if (eficienciasDesglose1 != null)
                        {
                            eficienciasDesglose1.idProyecto = IdProyecto;
                            eficienciasDesglose1.idDocumento = IdControlFactura;
                            eficienciasDesglose1.Categoria = Categoria.ToUpper();
                            eficienciasDesglose1.Total = new Decimal?(num1);
                            eficienciasDesglose1.TipoDoc = "FAC";
                            eficienciasDesglose1.Folio = NoFactura;
                            sisaEntitie.SaveChanges();
                        }
                        else
                        {
                            tblEficienciasDesglose eficienciasDesglose2 = new tblEficienciasDesglose()
                            {
                                idProyecto = IdProyecto,
                                idDocumento = IdControlFactura,
                                Categoria = Categoria.ToUpper(),
                                Total = new Decimal?(num1),
                                TipoDoc = "FAC",
                                Folio = NoFactura,
                                FechaDoc = new DateTime?(DateTime.Now),
                                idUsuarioUltimo = usuario.IdUsuario.ToString()
                            };
                            sisaEntitie.tblEficienciasDesglose.Add(eficienciasDesglose2);
                            sisaEntitie.SaveChanges();
                        }
                        str = "Factura agregada.";
                    }
                }
                else
                    str = "No tienes permiso.";
            }
            catch (Exception ex)
            {
                str = ex.Message;
            }
            return str;
        }

        [WebMethod]
        public static string GuardarRecibidaXML(string NombreArchivo, string Archivo)
        {
            string retorno = string.Empty;
            string archivoBase64 = "";
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            archivoBase64 = Archivo;

            string[] completo64 = archivoBase64.Split(',');
            var originalString = ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(completo64[1]));
            string a = AppDomain.CurrentDomain.BaseDirectory + "\\FacturasXML\\";
            //File.WriteAllBytes(@"\\win-s20lmo4rao9\FacturasXML\" + NombreArchivo, Convert.FromBase64String(completo64[1]));
            File.WriteAllBytes(a + NombreArchivo, Convert.FromBase64String(completo64[1]));

            //XmlDocument doc = new XmlDocument();
            //doc.Load(@"\\win-s20lmo4rao9\FacturasXML\" + NombreArchivo);
            //XmlNodeReader nodereader = new XmlNodeReader(doc);
            //while (nodereader.Read())
            //{
            //    // Read the XmlDocument as a stream of XML.
            //}

            // sustituir por la ruta de tu xml
            //string rutaXML = @"\\win-s20lmo4rao9\FacturasXML\" + NombreArchivo;

            string rutaXML = a + NombreArchivo;

            //variables del esquema
            XNamespace cfdi = @"http://www.sat.gob.mx/cfd/3";
            XNamespace tfd = @"http://www.sat.gob.mx/TimbreFiscalDigital";

            //cargamos el xml
            var xdoc = XDocument.Load(rutaXML);

            var _comprobante = xdoc.Element(cfdi + "Comprobante");
            var _receptor = xdoc.Element(cfdi + "Comprobante").Element(cfdi + "Receptor");
            var _impuestos = xdoc.Element(cfdi + "Comprobante").Element(cfdi + "Impuestos");
            var _emisor = xdoc.Element(cfdi + "Comprobante").Element(cfdi + "Emisor");
            var RFCEmisor = (string)_emisor.Attribute("Rfc");
            var folioFactura = (string)_comprobante.Attribute("Folio");
            var fecha = (string)_comprobante.Attribute("Fecha");

            var rfcReceptor = (string)_receptor.Attribute("Rfc");
            var nombreReceptor = (string)_receptor.Attribute("Nombre");

            var subTotal = (string)_comprobante.Attribute("SubTotal");
            var iva = "";
            var retencion = "";

            if (_impuestos == null)
            {
                iva = "0.00";
                retencion = "0.00";
            }
            else
            {
                iva = (string)_impuestos.Attribute("TotalImpuestosTrasladados");
                retencion = (string)_impuestos.Attribute("TotalImpuestosRetenidos");
            }

            var total = (string)_comprobante.Attribute("Total");
            var moneda = (string)_comprobante.Attribute("Moneda");
            var tipoCambio = (string)_comprobante.Attribute("TipoCambio");

            if (File.Exists(rutaXML))
            {
                File.Delete(rutaXML);
            }
            if (retencion == null)
            {
                retencion = "0.00";
            }
            try
            {
                using (var DataControl = new SisaEntitie())
                {
                    var RFCProveedor = DataControl.tblProveedores.FirstOrDefault(p => p.RFC.Trim() == RFCEmisor);
                    if (RFCProveedor != null)
                    {
                        var ins = DataControl.JT_InsertUpdateControlFacturas("0", DateTime.Parse(fecha), RFCProveedor.IdProveedor.ToString(), folioFactura, "N/A", "B2C9AA16-C340-47A1-8744-5CA73C388F92", moneda, decimal.Parse(subTotal), 0, decimal.Parse(iva), decimal.Parse(total), 0, "", 0, usuario.IdUsuario.ToString(), "", 0, 0, "N/A", "", "");
                        DataControl.SaveChanges();
                    }
                    else
                    {
                        var ins = DataControl.JT_InsertUpdateControlFacturas("0", DateTime.Parse(fecha), "81d71cb6-fcc3-451f-ae2a-1094dcf38e5d", folioFactura, "N/A", "B2C9AA16-C340-47A1-8744-5CA73C388F92", moneda, decimal.Parse(subTotal), 0, decimal.Parse(iva), decimal.Parse(total), 0, "", 0, usuario.IdUsuario.ToString(), "", 0, 0, "N/A", "", "");
                        DataControl.SaveChanges();
                    }


                }
                retorno = "Factura recibida, agregada.";
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
            if (rolesUsuarios.FacRecibidas == true || rolesUsuarios.Tipo == "ROOT")
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
        public static string CargarFacturasRecibida(string pid)
        {
            string str = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.FacRecibidas || rolesUsuarios.Tipo == "ROOT")
            {
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                {
                    Convert.ToInt32("-1");
                    str = JsonConvert.SerializeObject((object)((IQueryable<tblControlFacturas>)sisaEntitie.tblControlFacturas).FirstOrDefault<tblControlFacturas>((Expression<Func<tblControlFacturas, bool>>)(a => a.IdControlFacturas.ToString() == pid)));
                }
            }
            else
                str = "Error";
            return str;
        }

        [WebMethod]
        public static string GuardarArchivos(string IdControlFacturas, string NombreArchivo, string Documento)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            try
            {
                if (rolesUsuarios.FacRecibidas == true || rolesUsuarios.Tipo == "ROOT")
                {
                    using (var DataControl = new SisaEntitie())
                    {
                        var Sube = DataControl.sp_SubeArchivosFacturas(IdControlFacturas, NombreArchivo, Documento);
                        retorno = "Factura actualizada.";
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
                }
            }
            catch (Exception e)
            {
                retorno = e.ToString();
            }
            return retorno;
        }

        [WebMethod]
        public static string ModificacionGlobal(string IdControlFacturas, string Monto, string Opcion)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.FacRecibidas == true || rolesUsuarios.Tipo == "ROOT")
            {
                try
                {
                    //string[] a = array.Split('|');
                    using (var DataControl = new SisaEntitie())
                    {
                        if (Opcion == "1")
                        {
                            var Existe = DataControl.tblFacturasModiGlobal.FirstOrDefault(s => s.IdFactura.ToString() == IdControlFacturas);
                            if (Existe != null)
                            {
                                DataControl.tblFacturasModiGlobal.Remove(Existe);
                                DataControl.SaveChanges();
                                retorno = "Informacion actualizada.";
                            }
                        }
                        else
                        {
                            tblFacturasModiGlobal tblFacturasModiGlobal = new tblFacturasModiGlobal
                            {
                                IdGlobal = Guid.NewGuid(),
                                IdFactura = Guid.Parse(IdControlFacturas),
                                Monto = Convert.ToDecimal(Monto),
                                IdUsuario = usuario.IdUsuario
                            };
                            DataControl.tblFacturasModiGlobal.Add(tblFacturasModiGlobal);
                            if (DataControl.SaveChanges() > 0)
                            {
                                retorno = "Informacion Guardada.";
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
                retorno = "No tienes permiso de modificar factura.";
            }

            return retorno;
        }

        [WebMethod]
        public static string ObtenerTotalGlobal(string Opcion)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.FacRecibidas == true || rolesUsuarios.Tipo == "ROOT")
            {
                try
                {
                    using (SisaEntitie sisaEntitie = new SisaEntitie())
                    {
                        //int int32 = Convert.ToInt32(Opcion);
                        return JsonConvert.SerializeObject((object)sisaEntitie.sp_SumGlobalfacturas(usuario.IdUsuario.ToString()));
                    }

                }
                catch (Exception e)
                {
                    retorno = e.ToString();
                }
            }
            else
            {
                retorno = "No tienes permiso de modificar factura.";
            }

            return retorno;
        }

        [WebMethod]
        public static string ObtenerFactGlobal(string Opcion)
        {

            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                int int32 = Convert.ToInt32(Opcion);
                return JsonConvert.SerializeObject((object)sisaEntitie.sp_ObtenerFactGlobal(new int?(int32), usuario.IdUsuario.ToString()));
            }
        }
    }
}