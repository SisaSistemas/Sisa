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
    public partial class Facturas : System.Web.UI.Page
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
                    
                else if (Opcion == "10")
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
                    str = JsonConvert.SerializeObject((object)((IQueryable<tblFacturasEmitidas>)sisaEntitie.tblFacturasEmitidas).OrderBy<tblFacturasEmitidas, string>((Expression<Func<tblFacturasEmitidas, string>>)(d => d.NombreReceptor)).Select(d => new
                    {
                        Id = d.NombreReceptor,
                        Nombre = d.NombreReceptor
                    }).Distinct());
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
            if (!(rolesUsuarios.Tipo == "ROOT") && !(rolesUsuarios.Tipo == "GERENCIAL") && !(rolesUsuarios.Tipo == "ADMINISTRACION") && !rolesUsuarios.ControlFacturas)
            {
                facturasEmitidas = rolesUsuarios.FacturasEmitidas;
                bool flag = true;
                if (!(facturasEmitidas.GetValueOrDefault() == flag & facturasEmitidas.HasValue))
                {
                    str = "Error, no tienes permiso";
                    goto label_13;
                }
            }
            using (SisaEntitie sisaEntitie = new SisaEntitie())
            {
                if (pid == "1" && rolesUsuarios.ControlFacturas)
                {
                    Convert.ToInt32("-1");
                    str = JsonConvert.SerializeObject((object)((IEnumerable<sp_CargarFacturasRecibidas_Result>)sisaEntitie.sp_CargarFacturasRecibidas("-1")).OrderByDescending<sp_CargarFacturasRecibidas_Result, string>((Func<sp_CargarFacturasRecibidas_Result, string>)(a => a.FechaFactura)));
                }
                else
                {
                    if (pid == "2")
                    {
                        facturasEmitidas = Facturas.rolesUsuarios.FacturasEmitidas;
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

        //[WebMethod]
        //public static string CargarBusquedaRecibidas(string pid, string FechaBuscar, string ProveedorBuscar, string FacturaBuscar, string ProyectoRecibidaBuscar, string MonedaRecibidaBuscar, string EstatusRecibidas, string OC, string FechaAnioBuscar)
        //{
        //    using (var DataControl = new SisaEntitie())
        //    {
        //        int est = Convert.ToInt32("-1");
        //        if (FechaBuscar == "null")
        //        {
        //            FechaBuscar = "-1";
        //        }

        //        if (ProveedorBuscar == "null")
        //        {
        //            ProveedorBuscar = "-1";
        //        }

        //        if (FacturaBuscar == "null")
        //        {
        //            FacturaBuscar = "-1";
        //        }

        //        if (ProyectoRecibidaBuscar == "null")
        //        {
        //            ProyectoRecibidaBuscar = "-1";
        //        }

        //        if (MonedaRecibidaBuscar == "null")
        //        {
        //            MonedaRecibidaBuscar = "-1";
        //        }

        //        if (EstatusRecibidas == "null")
        //        {
        //            EstatusRecibidas = "-1";
        //        }

        //        if (FechaAnioBuscar == "null")
        //        {
        //            FechaAnioBuscar = "-1";
        //        }

        //        if (OC == "null")
        //        {
        //            OC = "-1";
        //        }
        //        SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
        //        connection.Open();
        //        SqlCommand command = new SqlCommand("sp_CargarFacturas", connection);
        //        command.CommandType = System.Data.CommandType.StoredProcedure;
        //        command.Parameters.AddWithValue("@Mes", FechaBuscar);
        //        command.Parameters.AddWithValue("@IdProveedor", ProveedorBuscar);
        //        command.Parameters.AddWithValue("@NoFactura", FacturaBuscar);
        //        command.Parameters.AddWithValue("@Proyecto", ProyectoRecibidaBuscar);
        //        command.Parameters.AddWithValue("@Moneda", MonedaRecibidaBuscar);
        //        command.Parameters.AddWithValue("@Estatus", EstatusRecibidas);
        //        command.Parameters.AddWithValue("@Anio", FechaAnioBuscar);
        //        command.Parameters.AddWithValue("@OC", OC);


        //        DataTable dt = new DataTable();

        //        dt.Load(command.ExecuteReader());

        //        return JsonConvert.SerializeObject(dt);

        //    }
        //}

        //[WebMethod]
        //public static string CargarResumenRecibidas(string mes, string idProveedor, string noFactura, string proyecto, string moneda, string estatus, string oc, string anio)
        //{
        //    string retorno = string.Empty;
            
        //    try
        //    {
        //        if (mes == "null")
        //        {
        //            mes = "-1";
        //        }

        //        if (idProveedor == "null")
        //        {
        //            idProveedor = "-1";
        //        }

        //        if (noFactura == "null")
        //        {
        //            noFactura = "-1";
        //        }

        //        if (proyecto == "null")
        //        {
        //            proyecto = "-1";
        //        }

        //        if (moneda == "null")
        //        {
        //            moneda = "-1";
        //        }

        //        if (estatus == "null")
        //        {
        //            estatus = "-1";
        //        }

        //        if (anio == "null")
        //        {
        //            anio = "-1";
        //        }

        //        if (oc == "null")
        //        {
        //            oc = "-1";
        //        }
        //        SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
        //        connection.Open();
        //        SqlCommand command = new SqlCommand("sp_ResumenTotales", connection);
        //        command.CommandType = System.Data.CommandType.StoredProcedure;
        //        command.Parameters.AddWithValue("@Mes", mes);
        //        command.Parameters.AddWithValue("@IdProveedor", idProveedor);
        //        command.Parameters.AddWithValue("@NoFactura", noFactura);
        //        command.Parameters.AddWithValue("@Proyecto", proyecto);
        //        command.Parameters.AddWithValue("@Moneda", moneda);
        //        command.Parameters.AddWithValue("@Estatus", estatus);
        //        command.Parameters.AddWithValue("@Anio", anio);
        //        command.Parameters.AddWithValue("@OC", oc);


        //        DataTable dt = new DataTable();

        //        dt.Load(command.ExecuteReader());

        //        retorno = JsonConvert.SerializeObject(dt);
        //        //using (var DataControl = new SisaEntitie())
        //        //{

        //        //    retorno = JsonConvert.SerializeObject(DataControl.sp_ResumenTotalesRecibidas(Opcion));
        //        //}
        //    }
        //    catch (Exception e)
        //    {
        //        retorno = e.Message;
        //    }
        //    return retorno;
        //}

        //[WebMethod]
        //public static string CargarFacturasRecibida(string pid)
        //{
        //    string str = string.Empty;
        //    usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
        //    rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
        //    if (rolesUsuarios.ControlFacturas || rolesUsuarios.Tipo == "ROOT")
        //    {
        //        using (SisaEntitie sisaEntitie = new SisaEntitie())
        //        {
        //            Convert.ToInt32("-1");
        //            str = JsonConvert.SerializeObject((object)((IQueryable<tblControlFacturas>)sisaEntitie.tblControlFacturas).FirstOrDefault<tblControlFacturas>((Expression<Func<tblControlFacturas, bool>>)(a => a.IdControlFacturas.ToString() == pid)));
        //        }
        //    }
        //    else
        //        str = "Error";
        //    return str;
        //}

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

        //[WebMethod]
        //public static string GuardarArchivos(string IdControlFacturas, string NombreArchivo, string Documento)
        //{
        //    string retorno = string.Empty;
        //    usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
        //    rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
        //    try
        //    {
        //        if(rolesUsuarios.ControlFacturas == true || rolesUsuarios.Tipo == "ROOT")
        //        {
        //            using (var DataControl = new SisaEntitie())
        //            {
        //                var Sube = DataControl.sp_SubeArchivosFacturas(IdControlFacturas, NombreArchivo, Documento);
        //                retorno = "Factura actualizada.";
        //            }
        //        }
        //        else
        //        {
        //            retorno = "No tienes permiso.";
        //        }
                
        //    }
        //    catch (Exception e)
        //    {
        //        retorno = e.ToString();
        //    }
        //    return retorno;
        //}
        
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
                    if(Data != null)
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
                                        select new { p.NombreArchivo, ArchivoFactura = p.ArchivoPDF, IdControlFacturas=p.IdFacturasEmitidas });
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
                if(rolesUsuarios.ControlFacturas == true || rolesUsuarios.Tipo == "ROOT")
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
        
        //[WebMethod]
        //public static string GuardarFacturaFR(string IdControlFactura, string IdProveedor, string OrdenCompra, string IdProyecto, string FechaFactura, string NoFactura, string Moneda, string SubTotal, string Descuento, string Iva, string Total, string Estatus, string FormaPago, string Viaticos, string Categoria, string Anticipo, string NotaCredito, string Proyecto, string nombrearchivo, string dataarchivo)
        //{
        //    string str = string.Empty;
        //    usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
        //    rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
        //    try
        //    {
        //        if (rolesUsuarios.ControlFacturas || rolesUsuarios.Tipo == "ROOT")
        //        {
        //            using (SisaEntitie sisaEntitie1 = new SisaEntitie())
        //            {
        //                Guid guid;
        //                if (IdProyecto == "B2C9AA16-C340-47A1-8744-5CA73C388F92")
        //                {
        //                    SisaEntitie sisaEntitie2 = sisaEntitie1;
        //                    string idControlFacturas = IdControlFactura;
        //                    DateTime? fechaFactura = new DateTime?(DateTime.Parse(FechaFactura));
        //                    string idProveedor = IdProveedor;
        //                    string noFactura = NoFactura;
        //                    string ordenCompra = OrdenCompra;
        //                    string moneda = Moneda;
        //                    Decimal? subTotal = new Decimal?(Decimal.Parse(SubTotal));
        //                    Decimal? descuento = new Decimal?(Decimal.Parse(Descuento));
        //                    Decimal? iVA = new Decimal?(Decimal.Parse(Iva));
        //                    Decimal? total = new Decimal?(Decimal.Parse(Total));
        //                    int? estatus = new int?(int.Parse(Estatus));
        //                    string formaPago = FormaPago;
        //                    int? vaticos = new int?(int.Parse(Viaticos));
        //                    guid = usuario.IdUsuario;
        //                    string idUsuario = guid.ToString();
        //                    string categoria = Categoria;
        //                    Decimal? anticipo = new Decimal?(Decimal.Parse(Anticipo));
        //                    Decimal? notaCredito = new Decimal?(Decimal.Parse(NotaCredito));
        //                    string proyecto = Proyecto;
        //                    string nombreArchivo = nombrearchivo;
        //                    string archivoFactura = dataarchivo;
        //                    sisaEntitie2.JT_InsertUpdateControlFacturas(idControlFacturas, fechaFactura, idProveedor, noFactura, ordenCompra, "N/A", moneda, subTotal, descuento, iVA, total, estatus, formaPago, vaticos, idUsuario, categoria, anticipo, notaCredito, proyecto, nombreArchivo, archivoFactura);
        //                    sisaEntitie1.SaveChanges();
        //                }
        //                else
        //                {
        //                    var IdControlFacturas = sisaEntitie1.JT_InsertUpdateControlFacturas(IdControlFactura, new DateTime?(DateTime.Parse(FechaFactura)), IdProveedor, NoFactura, OrdenCompra, IdProyecto, Moneda, new Decimal?(Decimal.Parse(SubTotal)), new Decimal?(Decimal.Parse(Descuento)), new Decimal?(Decimal.Parse(Iva)), new Decimal?(Decimal.Parse(Total)), new int?(int.Parse(Estatus)), FormaPago, new int?(int.Parse(Viaticos)), Facturas.usuario.IdUsuario.ToString(), Categoria, new Decimal?(Decimal.Parse(Anticipo)), new Decimal?(Decimal.Parse(NotaCredito)), Proyecto, nombrearchivo, dataarchivo);
        //                    sisaEntitie1.SaveChanges();
        //                }
        //                if (IdControlFactura == "0")
        //                {
        //                    //IdControlFactura
        //                    //var IdControlFacturass;
        //                    IQueryable<tblControlFacturas> source = ((IQueryable<tblControlFacturas>)sisaEntitie1.tblControlFacturas).Where<tblControlFacturas>((Expression<Func<tblControlFacturas, bool>>)(a => a.IdProveedor.ToString() == IdProveedor && a.NoFactura == NoFactura && a.IdProyecto == IdProyecto && a.Total.ToString() == Total && a.Categoria == Categoria));
        //                    //Expression<Func<tblControlFacturas, Guid>> selector = a => a.IdControlFacturas == IdControlFacturass;
        //                    //Expression<Func<tblControlFacturas, Guid>> selector = a => new
        //                    //{
        //                    //    IdControlFacturas = a.IdControlFacturas
        //                    //};

        //                    var selector = source.ToList();

        //                    foreach (var data in selector)
        //                    {
        //                        guid = data.IdControlFacturas;
        //                        IdControlFactura = guid.ToString();
        //                    }
        //                    //IdControlFactura = source.FirstOrDefault(a => a.IdControlFacturas.ToString() != IdControlFactura);


        //                }
        //            }
        //            using (SisaEntitie sisaEntitie = new SisaEntitie())
        //            {
        //                Decimal num1 = Decimal.Parse(Total);
        //                if (Moneda == "USD")
        //                {
        //                    Decimal num2 = 20.5M;
        //                    num1 *= num2;
        //                }
        //                tblEficienciasDesglose eficienciasDesglose1 = ((IQueryable<tblEficienciasDesglose>)sisaEntitie.tblEficienciasDesglose).FirstOrDefault<tblEficienciasDesglose>((Expression<Func<tblEficienciasDesglose, bool>>)(e => e.idDocumento == IdControlFactura));
        //                if (eficienciasDesglose1 != null)
        //                {
        //                    eficienciasDesglose1.idProyecto = IdProyecto;
        //                    eficienciasDesglose1.idDocumento = IdControlFactura;
        //                    eficienciasDesglose1.Categoria = Categoria.ToUpper();
        //                    eficienciasDesglose1.Total = new Decimal?(num1);
        //                    eficienciasDesglose1.TipoDoc = "FAC";
        //                    eficienciasDesglose1.Folio = NoFactura;
        //                    sisaEntitie.SaveChanges();
        //                }
        //                else
        //                {
        //                    tblEficienciasDesglose eficienciasDesglose2 = new tblEficienciasDesglose()
        //                    {
        //                        idProyecto = IdProyecto,
        //                        idDocumento = IdControlFactura,
        //                        Categoria = Categoria.ToUpper(),
        //                        Total = new Decimal?(num1),
        //                        TipoDoc = "FAC",
        //                        Folio = NoFactura,
        //                        FechaDoc = new DateTime?(DateTime.Now),
        //                        idUsuarioUltimo = Facturas.usuario.IdUsuario.ToString()
        //                    };
        //                    sisaEntitie.tblEficienciasDesglose.Add(eficienciasDesglose2);
        //                    sisaEntitie.SaveChanges();
        //                }
        //                str = "Factura agregada.";
        //            }
        //        }
        //        else
        //            str = "No tienes permiso.";
        //    }
        //    catch (Exception ex)
        //    {
        //        str = ex.Message;
        //    }
        //    return str;
        //    //string retorno = string.Empty;
        //    //usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
        //    //rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
        //    //try
        //    //{
        //    //    if (rolesUsuarios.ControlFacturas == true || rolesUsuarios.Tipo == "ROOT")
        //    //    {
        //    //        using (var DataControl = new SisaEntitie())
        //    //        {
        //    //            if(IdProyecto == "B2C9AA16-C340-47A1-8744-5CA73C388F92")
        //    //            {
        //    //                var ins = DataControl.JT_InsertUpdateControlFacturas(IdControlFactura, DateTime.Parse(FechaFactura), IdProveedor, NoFactura, OrdenCompra, "N/A", Moneda, decimal.Parse(SubTotal), decimal.Parse(Descuento), decimal.Parse(Iva), decimal.Parse(Total), int.Parse(Estatus), FormaPago, int.Parse(Viaticos), usuario.IdUsuario.ToString(), Categoria, decimal.Parse(Anticipo), decimal.Parse(NotaCredito), Proyecto, nombrearchivo, dataarchivo);
        //    //                DataControl.SaveChanges();


        //    //            }
        //    //            else
        //    //            {
        //    //                var ins = DataControl.JT_InsertUpdateControlFacturas(IdControlFactura, DateTime.Parse(FechaFactura), IdProveedor, NoFactura, OrdenCompra, IdProyecto, Moneda, decimal.Parse(SubTotal), decimal.Parse(Descuento), decimal.Parse(Iva), decimal.Parse(Total), int.Parse(Estatus), FormaPago, int.Parse(Viaticos), usuario.IdUsuario.ToString(), Categoria, decimal.Parse(Anticipo), decimal.Parse(NotaCredito), Proyecto, nombrearchivo, dataarchivo);
        //    //                DataControl.SaveChanges();


        //    //            }

        //    //        }
        //    //        using(var DataControl = new SisaEntitie())
        //    //        {
        //    //            if (OrdenCompra == "-1" || OrdenCompra == "N/A" || OrdenCompra == "PENDIENTE")
        //    //            {

        //    //            }
        //    //            else
        //    //            {
        //    //                decimal total = decimal.Parse(Total);
        //    //                var Eficiencia = DataControl.tblEficiencias.FirstOrDefault(e => e.idProyecto.ToString() == IdProyecto);
        //    //                if (Eficiencia != null)
        //    //                {
        //    //                    if (Categoria == "MATERIAL")
        //    //                    {
        //    //                        Eficiencia.Material = total + Eficiencia.Material;
        //    //                    }
        //    //                    else if (Categoria == "EQUIPO")
        //    //                    {
        //    //                        Eficiencia.Equipo = total + Eficiencia.Equipo;
        //    //                    }
        //    //                    else if (Categoria == "MANOOBRA")
        //    //                    {
        //    //                        Eficiencia.ManoObra = total + Eficiencia.ManoObra;
        //    //                    }
        //    //                    DataControl.SaveChanges();
        //    //                }
        //    //                else
        //    //                {
        //    //                    tblEficiencias ad = new tblEficiencias
        //    //                    {
        //    //                        idProyecto = Guid.Parse(IdProyecto),
        //    //                        ManoObra = Categoria == "MANOOBRA" ? total : 0,
        //    //                        Equipo = Categoria == "EQUIPO" ? total : 0,
        //    //                        Material = Categoria == "MATERIAL" ? total : 0
        //    //                    };
        //    //                    DataControl.tblEficiencias.Add(ad);
        //    //                    DataControl.SaveChanges();
        //    //                }
        //    //            }

        //    //            retorno = "Factura agregada.";
        //    //        }

        //    //    }
        //    //    else
        //    //    {
        //    //        retorno = "No tienes permiso.";
        //    //    }

        //    //}
        //    //catch (Exception e)
        //    //{
        //    //    retorno = e.Message;
        //    //}
        //    //return retorno;
        //}

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

            XNamespace xnamespace1 = (XNamespace)"http://www.sat.gob.mx/cfd/3";
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

            try
            {
                using (SisaEntitie sisaEntitie = new SisaEntitie())
                    sisaEntitie.sp_InsertFacturasEmitidas(folioFactura, new DateTime?(DateTime.Parse(s1)), rfcReceptor, nombreReceptor, new Decimal?(Decimal.Parse(s2)), new Decimal?(Decimal.Parse(s3)), new Decimal?(Decimal.Parse(s4)), new Decimal?(Decimal.Parse(s5)), moneda, new Decimal?(Decimal.Parse(s6)), Facturas.usuario.IdUsuario.ToString());
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

        //[WebMethod]
        //public static string GuardarRecibidaXML(string NombreArchivo, string Archivo)
        //{
        //    string retorno = string.Empty;
        //    string archivoBase64 = "";
        //    usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
        //    rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
        //    archivoBase64 = Archivo;

        //    string[] completo64 = archivoBase64.Split(',');
        //    var originalString = ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(completo64[1]));
        //    string a = AppDomain.CurrentDomain.BaseDirectory + "\\FacturasXML\\";
        //    //File.WriteAllBytes(@"\\win-s20lmo4rao9\FacturasXML\" + NombreArchivo, Convert.FromBase64String(completo64[1]));
        //    File.WriteAllBytes(a + NombreArchivo, Convert.FromBase64String(completo64[1]));

        //    //XmlDocument doc = new XmlDocument();
        //    //doc.Load(@"\\win-s20lmo4rao9\FacturasXML\" + NombreArchivo);
        //    //XmlNodeReader nodereader = new XmlNodeReader(doc);
        //    //while (nodereader.Read())
        //    //{
        //    //    // Read the XmlDocument as a stream of XML.
        //    //}

        //    // sustituir por la ruta de tu xml
        //    //string rutaXML = @"\\win-s20lmo4rao9\FacturasXML\" + NombreArchivo;

        //    string rutaXML = a + NombreArchivo;

        //    //variables del esquema
        //    XNamespace cfdi = @"http://www.sat.gob.mx/cfd/3";
        //    XNamespace tfd = @"http://www.sat.gob.mx/TimbreFiscalDigital";

        //    //cargamos el xml
        //    var xdoc = XDocument.Load(rutaXML);

        //    var _comprobante = xdoc.Element(cfdi + "Comprobante");
        //    var _receptor = xdoc.Element(cfdi + "Comprobante").Element(cfdi + "Receptor");
        //    var _impuestos = xdoc.Element(cfdi + "Comprobante").Element(cfdi + "Impuestos");
        //    var _emisor = xdoc.Element(cfdi + "Comprobante").Element(cfdi + "Emisor");
        //    var RFCEmisor = (string)_emisor.Attribute("Rfc");
        //    var folioFactura = (string)_comprobante.Attribute("Folio");
        //    var fecha = (string)_comprobante.Attribute("Fecha");

        //    var rfcReceptor = (string)_receptor.Attribute("Rfc");
        //    var nombreReceptor = (string)_receptor.Attribute("Nombre");

        //    var subTotal = (string)_comprobante.Attribute("SubTotal");
        //    var iva = "";
        //    var retencion = "";

        //    if (_impuestos == null)
        //    {
        //        iva = "0.00";
        //        retencion = "0.00";
        //    }
        //    else
        //    {
        //        iva = (string)_impuestos.Attribute("TotalImpuestosTrasladados");
        //        retencion = (string)_impuestos.Attribute("TotalImpuestosRetenidos");
        //    }

        //    var total = (string)_comprobante.Attribute("Total");
        //    var moneda = (string)_comprobante.Attribute("Moneda");
        //    var tipoCambio = (string)_comprobante.Attribute("TipoCambio");

        //    if (File.Exists(rutaXML))
        //    {
        //        File.Delete(rutaXML);
        //    }
        //    if (retencion == null)
        //    {
        //        retencion = "0.00";
        //    }
        //    try
        //    {
        //        using (var DataControl = new SisaEntitie())
        //        {
        //            var RFCProveedor = DataControl.tblProveedores.FirstOrDefault(p => p.RFC.Trim() == RFCEmisor);
        //            if(RFCProveedor != null)
        //            {
        //                var ins = DataControl.JT_InsertUpdateControlFacturas("0", DateTime.Parse(fecha), RFCProveedor.IdProveedor.ToString(), folioFactura, "N/A", "B2C9AA16-C340-47A1-8744-5CA73C388F92", moneda, decimal.Parse(subTotal), 0, decimal.Parse(iva), decimal.Parse(total), 0, "", 0, usuario.IdUsuario.ToString(), "", 0, 0, "N/A", "","");
        //                DataControl.SaveChanges();
        //            }
        //            else
        //            {
        //                var ins = DataControl.JT_InsertUpdateControlFacturas("0", DateTime.Parse(fecha), "81d71cb6-fcc3-451f-ae2a-1094dcf38e5d", folioFactura, "N/A", "B2C9AA16-C340-47A1-8744-5CA73C388F92", moneda, decimal.Parse(subTotal), 0, decimal.Parse(iva), decimal.Parse(total), 0, "", 0, usuario.IdUsuario.ToString(), "", 0, 0, "N/A","","");
        //                DataControl.SaveChanges();
        //            }
                    

        //        }
        //        //using (var DataControl = new SisaEntitie())
        //        //{
        //        //    var inser = DataControl.sp_InsertFacturasEmitidas(folioFactura, DateTime.Parse(fecha), rfcReceptor, nombreReceptor, decimal.Parse(subTotal), decimal.Parse(iva), decimal.Parse(retencion), decimal.Parse(total), moneda, decimal.Parse(tipoCambio), usuario.IdUsuario.ToString());
        //        //}
        //        retorno = "Factura recibida, agregada.";
        //    }
        //    catch (Exception e)
        //    {
        //        retorno = e.ToString();
        //    }

        //    ////Navegamos hasta el elemento que contiene el UUID
        //    //var elt = xdoc.Element(cfdi + "Comprobante")
        //    //              .Element(cfdi + "Complemento")
        //    //              .Element(tfd + "TimbreFiscalDigital");

        //    ////listo obtenemos el UUID
        //    //var uuid = (string)elt.Attribute("UUID");

        //    //return "";
        //    return retorno;
        //}

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
                            Retencion = A.Retencion,
                            Enviada = A.Enviada,
                            CorreoEnviado = A.CorreoEnviado
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
        public static string EditarFactura(string IdFacturasEmitidas, string IdProyecto, string NoCotizacion, string NoOrdenCompra, string ProgramacionPago, string PorPagar, string FechaPago, string Estatus, string Retencion, string EstatusEnviado, string CorreoEnviado)
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
                            Decimal num = string.IsNullOrEmpty(Retencion) ? 0M : Decimal.Parse(Retencion);
                            facturasEmitidas.NoCotizacion = NoCotizacion;
                            facturasEmitidas.OrdenCompraRecibida = NoOrdenCompra;
                            facturasEmitidas.IdProyecto = IdProyecto;
                            if (ProgramacionPago != "")
                                facturasEmitidas.ProgramacionPago = new DateTime?(DateTime.Parse(ProgramacionPago));
                            if (FechaPago != "")
                                facturasEmitidas.FechaPago = new DateTime?(DateTime.Parse(FechaPago));
                            facturasEmitidas.PorPagar = new Decimal?(Decimal.Parse(PorPagar));
                            facturasEmitidas.Estatus = int.Parse(Estatus);
                            facturasEmitidas.FechaModificacion = new DateTime?(DateTime.Now);
                            facturasEmitidas.IdUsuarioModificacion = new Guid?(Facturas.usuario.IdUsuario);
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
        public static string AgregarFacturaEmitida(string folioFactura, string fecha, string rfcReceptor, string nombreReceptor, string subTotal, string iva, string retencion, string total, string moneda, string tipoCambio, string IdProyecto, string NoCotizacion, string NoOrdenCompra, string ProgramacionPago, string PorPagar, string FechaPago, string Estatus)
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
                            Retencion = retencion.Length > 0 ? decimal.Parse(retencion) : 0,
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
        public static string CambiarEstatusFR(string array, string FormaPago)
        {
            string retorno = string.Empty;
            usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
            rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
            if (rolesUsuarios.ControlFacturas == true || rolesUsuarios.Tipo == "ROOT")
            {
                try
                {
                    string[] a = array.Split('|');                    
                    using (var DataControl = new SisaEntitie())
                    {
                        foreach (var arr in a)
                        {
                            var Existe = DataControl.tblControlFacturas.FirstOrDefault(s => s.IdControlFacturas.ToString() == arr);
                            if(Existe != null)
                            {
                                Existe.Estatus = 1;
                                Existe.FormaPago = FormaPago;
                                DataControl.SaveChanges();
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
    }
}