// Decompiled with JetBrains decompiler
// Type: SisaDev.Administracion.Facturas
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

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
  public class Facturas : Page
  {
    public static tblUsuarios usuario;
    public static tblRolesUsuarios rolesUsuarios;

    protected void Page_Load(object sender, EventArgs e)
    {
      Facturas.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (Facturas.usuario != null)
        Facturas.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      else
        this.Response.Redirect("~/Default.aspx");
    }

    [WebMethod]
    public static string CargarCombos(string Opcion)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
      {
        int int32 = Convert.ToInt32(Opcion);
        return JsonConvert.SerializeObject((object) sisaEntitie.sp_CargaCombos(new int?(int32)));
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
          str = JsonConvert.SerializeObject((object) sisaEntitie.sp_CargaCombosFacturasEmitidas(new int?(int32)));
        else if (Opcion == "10")
          str = JsonConvert.SerializeObject((object) ((IQueryable<tblProyectos>) sisaEntitie.tblProyectos).Where<tblProyectos>((Expression<Func<tblProyectos, bool>>) (d => d.Activo == (int?) 1)).Select(d => new
          {
            Id = d.IdProyecto,
            Nombre = d.FolioProyecto + "-" + d.NombreProyecto
          }).OrderBy(a => a.Nombre));
        else if (Opcion == "12")
          str = JsonConvert.SerializeObject((object) ((IQueryable<DateDimension>) sisaEntitie.DateDimension).Where<DateDimension>((Expression<Func<DateDimension, bool>>) (d => d.Year <= DateTime.Now.Year)).Select(d => new
          {
            Id = d.Year,
            Nombre = d.Year
          }).Distinct());
        else if (Opcion == "13")
          str = JsonConvert.SerializeObject((object) ((IQueryable<tblFacturasEmitidas>) sisaEntitie.tblFacturasEmitidas).OrderBy<tblFacturasEmitidas, string>((Expression<Func<tblFacturasEmitidas, string>>) (d => d.NombreReceptor)).Select(d => new
          {
            Id = d.NombreReceptor,
            Nombre = d.NombreReceptor
          }).Distinct());
      }
      return str;
    }

    [WebMethod]
    public static string CargarRecibidasBuscar(string Opcion)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
      {
        int int32 = Convert.ToInt32(Opcion);
        return JsonConvert.SerializeObject((object) sisaEntitie.sp_CargarCombosFacturasRecibidas(new int?(int32)));
      }
    }

    [WebMethod]
    public static string CargarOC(string pid)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
      {
        Guid id = Guid.Parse(pid);
        return JsonConvert.SerializeObject((object) ((IQueryable<tblOrdenCompra>) sisaEntitie.tblOrdenCompra).Where<tblOrdenCompra>((Expression<Func<tblOrdenCompra, bool>>) (a => a.IdProveedor == id)).Select(a => new
        {
          Folio = a.Folio,
          TipoOC = a.TipoOC
        }).Union(((IQueryable<tblOrdenCompraInsumos>) sisaEntitie.tblOrdenCompraInsumos).Where<tblOrdenCompraInsumos>((Expression<Func<tblOrdenCompraInsumos, bool>>) (b => b.IdProveedor == id)).Select(b => new
        {
          Folio = b.Folio,
          TipoOC = "MATERIAL"
        })));
      }
    }

    [WebMethod]
    public static string CargarFacturas(string pid)
    {
      string str = string.Empty;
      Facturas.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Facturas.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      bool? facturasEmitidas;
      if (!(Facturas.rolesUsuarios.Tipo == "ROOT") && !(Facturas.rolesUsuarios.Tipo == "GERENCIAL") && !(Facturas.rolesUsuarios.Tipo == "ADMINISTRACION") && !Facturas.rolesUsuarios.ControlFacturas)
      {
        facturasEmitidas = Facturas.rolesUsuarios.FacturasEmitidas;
        bool flag = true;
        if (!(facturasEmitidas.GetValueOrDefault() == flag & facturasEmitidas.HasValue))
        {
          str = "Error, no tienes permiso";
          goto label_13;
        }
      }
      using (SisaEntitie sisaEntitie = new SisaEntitie())
      {
        if (pid == "1" && Facturas.rolesUsuarios.ControlFacturas)
        {
          Convert.ToInt32("-1");
          str = JsonConvert.SerializeObject((object) ((IEnumerable<sp_CargarFacturasRecibidas_Result>) sisaEntitie.sp_CargarFacturasRecibidas("-1")).OrderByDescending<sp_CargarFacturasRecibidas_Result, string>((Func<sp_CargarFacturasRecibidas_Result, string>) (a => a.FechaFactura)));
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
              str = JsonConvert.SerializeObject((object) ((IEnumerable<sp_CargarFacturasEmitidas_Result>) sisaEntitie.sp_CargarFacturasEmitidas("-1")).OrderByDescending<sp_CargarFacturasEmitidas_Result, DateTime>((Func<sp_CargarFacturasEmitidas_Result, DateTime>) (a => a.FechaFactura)));
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
    public static string CargarBusquedaEmitidas(
      string pid,
      string AnioBuscar,
      string ClienteBuscar,
      string ProyectoEmitidaBuscar,
      string MonedaEmitidaBuscar,
      string EstatusEmitidas)
    {
      string empty = string.Empty;
      if (AnioBuscar == "null")
        AnioBuscar = "-1";
      if (ClienteBuscar == "null")
        ClienteBuscar = "-1";
      if (ProyectoEmitidaBuscar == "null")
        ProyectoEmitidaBuscar = "-1";
      if (MonedaEmitidaBuscar == "null")
        MonedaEmitidaBuscar = "-1";
      if (EstatusEmitidas == "null")
        EstatusEmitidas = "-1";
      SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
      connection.Open();
      SqlCommand sqlCommand = new SqlCommand("JT_LoadFacturasEmitidas", connection);
      sqlCommand.CommandType = CommandType.StoredProcedure;
      sqlCommand.Parameters.AddWithValue("@Anio", (object) AnioBuscar);
      sqlCommand.Parameters.AddWithValue("@Cliente", (object) ClienteBuscar);
      sqlCommand.Parameters.AddWithValue("@IdProyecto", (object) ProyectoEmitidaBuscar);
      sqlCommand.Parameters.AddWithValue("@Moneda", (object) MonedaEmitidaBuscar);
      sqlCommand.Parameters.AddWithValue("@Estatus", (object) EstatusEmitidas);
      DataTable dataTable = new DataTable();
      dataTable.Load((IDataReader) sqlCommand.ExecuteReader());
      return JsonConvert.SerializeObject((object) dataTable);
    }

    [WebMethod]
    public static string CargarBusquedaRecibidas(
      string pid,
      string FechaBuscar,
      string ProveedorBuscar,
      string FacturaBuscar,
      string ProyectoRecibidaBuscar,
      string MonedaRecibidaBuscar,
      string EstatusRecibidas,
      string MesPago,
      string OC)
    {
      using (new SisaEntitie())
      {
        Convert.ToInt32("-1");
        if (FechaBuscar == "null")
          FechaBuscar = "-1";
        if (ProveedorBuscar == "null")
          ProveedorBuscar = "-1";
        if (FacturaBuscar == "null")
          FacturaBuscar = "-1";
        if (ProyectoRecibidaBuscar == "null")
          ProyectoRecibidaBuscar = "-1";
        if (MonedaRecibidaBuscar == "null")
          MonedaRecibidaBuscar = "-1";
        if (EstatusRecibidas == "null")
          EstatusRecibidas = "-1";
        if (MesPago == "null")
          MesPago = "-1";
        if (OC == "null")
          OC = "-1";
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
        connection.Open();
        SqlCommand sqlCommand = new SqlCommand("sp_CargarFacturas", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@Mes", (object) FechaBuscar);
        sqlCommand.Parameters.AddWithValue("@IdProveedor", (object) ProveedorBuscar);
        sqlCommand.Parameters.AddWithValue("@NoFactura", (object) FacturaBuscar);
        sqlCommand.Parameters.AddWithValue("@Proyecto", (object) ProyectoRecibidaBuscar);
        sqlCommand.Parameters.AddWithValue("@Moneda", (object) MonedaRecibidaBuscar);
        sqlCommand.Parameters.AddWithValue("@Estatus", (object) EstatusRecibidas);
        sqlCommand.Parameters.AddWithValue("@OC", (object) OC);
        DataTable dataTable = new DataTable();
        dataTable.Load((IDataReader) sqlCommand.ExecuteReader());
        return JsonConvert.SerializeObject((object) dataTable);
      }
    }

    [WebMethod]
    public static string CargarResumenRecibidas(
      string mes,
      string idProveedor,
      string noFactura,
      string proyecto,
      string moneda,
      string estatus,
      string OC)
    {
      string empty = string.Empty;
      try
      {
        if (mes == "null")
          mes = "-1";
        if (idProveedor == "null")
          idProveedor = "-1";
        if (noFactura == "null")
          noFactura = "-1";
        if (proyecto == "null")
          proyecto = "-1";
        if (moneda == "null")
          moneda = "-1";
        if (estatus == "null")
          estatus = "-1";
        if (OC == "null")
          OC = "-1";
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
        connection.Open();
        SqlCommand sqlCommand = new SqlCommand("sp_ResumenTotales", connection);
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.Parameters.AddWithValue("@Mes", (object) mes);
        sqlCommand.Parameters.AddWithValue("@IdProveedor", (object) idProveedor);
        sqlCommand.Parameters.AddWithValue("@NoFactura", (object) noFactura);
        sqlCommand.Parameters.AddWithValue("@Proyecto", (object) proyecto);
        sqlCommand.Parameters.AddWithValue("@Moneda", (object) moneda);
        sqlCommand.Parameters.AddWithValue("@Estatus", (object) estatus);
        sqlCommand.Parameters.AddWithValue("@OC", (object) OC);
        DataTable dataTable = new DataTable();
        dataTable.Load((IDataReader) sqlCommand.ExecuteReader());
        return JsonConvert.SerializeObject((object) dataTable);
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }

    [WebMethod]
    public static string CargarFacturasRecibida(string pid)
    {
      string str = string.Empty;
      Facturas.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Facturas.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Facturas.rolesUsuarios.ControlFacturas || Facturas.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          Convert.ToInt32("-1");
          str = JsonConvert.SerializeObject((object) ((IQueryable<tblControlFacturas>) sisaEntitie.tblControlFacturas).FirstOrDefault<tblControlFacturas>((Expression<Func<tblControlFacturas, bool>>) (a => a.IdControlFacturas.ToString() == pid)));
        }
      }
      else
        str = "Error";
      return str;
    }

    [WebMethod]
    public static string CargarFacturasEmitidas(
      string anio,
      string cliente,
      string proyecto,
      string moneda,
      string estatus)
    {
      string empty = string.Empty;
      try
      {
        using (new SisaEntitie())
        {
          if (anio == "null")
            anio = "-1";
          if (cliente == "null")
            cliente = "-1";
          if (proyecto == "null")
            proyecto = "-1";
          if (moneda == "null")
            moneda = "-1";
          if (estatus == "null")
            estatus = "-1";
          Convert.ToInt32(estatus);
          SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
          connection.Open();
          SqlCommand sqlCommand = new SqlCommand("sp_ResumenTotalesFacturasEmitidas", connection);
          sqlCommand.CommandType = CommandType.StoredProcedure;
          sqlCommand.Parameters.AddWithValue("@Anio", (object) anio);
          sqlCommand.Parameters.AddWithValue("@Cliente", (object) cliente);
          sqlCommand.Parameters.AddWithValue("@IdProyecto", (object) proyecto);
          sqlCommand.Parameters.AddWithValue("@Moneda", (object) moneda);
          sqlCommand.Parameters.AddWithValue("@Estatus", (object) estatus);
          DataTable dataTable = new DataTable();
          dataTable.Load((IDataReader) sqlCommand.ExecuteReader());
          return JsonConvert.SerializeObject((object) dataTable);
        }
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }

    [WebMethod]
    public static string GuardarArchivos(
      string IdControlFacturas,
      string NombreArchivo,
      string Documento)
    {
      string str = string.Empty;
      Facturas.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Facturas.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      try
      {
        if (Facturas.rolesUsuarios.ControlFacturas || Facturas.rolesUsuarios.Tipo == "ROOT")
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
          {
            sisaEntitie.sp_SubeArchivosFacturas(IdControlFacturas, NombreArchivo, Documento);
            str = "Factura actualizada.";
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
    public static string GuardarArchivosEmitida(string pid, string NombreArchivo, string Documento)
    {
      string str = string.Empty;
      Facturas.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Facturas.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      try
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblFacturasEmitidas facturasEmitidas = ((IQueryable<tblFacturasEmitidas>) sisaEntitie.tblFacturasEmitidas).FirstOrDefault<tblFacturasEmitidas>((Expression<Func<tblFacturasEmitidas, bool>>) (s => s.IdFacturasEmitidas.ToString() == pid));
          if (facturasEmitidas != null)
          {
            facturasEmitidas.NombreArchivo = NombreArchivo;
            facturasEmitidas.ArchivoPDF = Documento;
            sisaEntitie.SaveChanges();
            str = "Factura actualizada.";
          }
          else
            str = "";
        }
      }
      catch (Exception ex)
      {
        str = ex.ToString();
      }
      return str;
    }

    [WebMethod]
    public static string CargarDocumentos(string IdControlFacturas, string Opcion)
    {
      string str = string.Empty;
      try
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          if (Opcion == "FR")
            str = JsonConvert.SerializeObject((object) ((IQueryable<tblControlFacturas>) sisaEntitie.tblControlFacturas).Where<tblControlFacturas>((Expression<Func<tblControlFacturas, bool>>) (p => p.IdControlFacturas.ToString() == IdControlFacturas)).Select(p => new
            {
              NombreArchivo = p.NombreArchivo,
              ArchivoFactura = p.ArchivoFactura,
              IdControlFacturas = p.IdControlFacturas
            }));
          else if (Opcion == "FE")
            str = JsonConvert.SerializeObject((object) ((IQueryable<tblFacturasEmitidas>) sisaEntitie.tblFacturasEmitidas).Where<tblFacturasEmitidas>((Expression<Func<tblFacturasEmitidas, bool>>) (p => p.IdFacturasEmitidas.ToString() == IdControlFacturas)).Select(p => new
            {
              NombreArchivo = p.NombreArchivo,
              ArchivoFactura = p.ArchivoPDF,
              IdControlFacturas = p.IdFacturasEmitidas
            }));
        }
      }
      catch (Exception ex)
      {
        str = ex.ToString();
      }
      return str;
    }

    [WebMethod]
    public static string EliminarDocumento(string pid, string Opcion)
    {
      string str = string.Empty;
      Facturas.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Facturas.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      try
      {
        if (Facturas.rolesUsuarios.ControlFacturas || Facturas.rolesUsuarios.Tipo == "ROOT")
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
          {
            if (Opcion == "FR")
            {
              tblControlFacturas tblControlFacturas = ((IQueryable<tblControlFacturas>) sisaEntitie.tblControlFacturas).FirstOrDefault<tblControlFacturas>((Expression<Func<tblControlFacturas, bool>>) (p => p.IdControlFacturas.ToString() == pid));
              if (tblControlFacturas != null)
              {
                tblControlFacturas.NombreArchivo = "";
                tblControlFacturas.ArchivoFactura = "";
                sisaEntitie.SaveChanges();
                str = "Documento eliminado.";
              }
              else
                str = "No se encontro información de documento, intenta de nuevo recargando página";
            }
            else if (Opcion == "FE")
            {
              tblFacturasEmitidas facturasEmitidas = ((IQueryable<tblFacturasEmitidas>) sisaEntitie.tblFacturasEmitidas).FirstOrDefault<tblFacturasEmitidas>((Expression<Func<tblFacturasEmitidas, bool>>) (p => p.IdFacturasEmitidas.ToString() == pid));
              if (facturasEmitidas != null)
              {
                facturasEmitidas.NombreArchivo = "";
                facturasEmitidas.ArchivoPDF = "";
                sisaEntitie.SaveChanges();
                str = "Documento eliminado.";
              }
              else
                str = "No se encontro información de documento, intenta de nuevo recargando página";
            }
          }
        }
        else
          str = "No tienes permisos.";
      }
      catch (Exception ex)
      {
        str = ex.ToString();
      }
      return str;
    }

    [WebMethod]
    public static string GuardarFacturaFR(
      string IdControlFactura,
      string IdProveedor,
      string OrdenCompra,
      string IdProyecto,
      string FechaFactura,
      string NoFactura,
      string Moneda,
      string SubTotal,
      string Descuento,
      string Iva,
      string Total,
      string Estatus,
      string FormaPago,
      string Viaticos,
      string Categoria,
      string Anticipo,
      string NotaCredito,
      string Proyecto,
      string nombrearchivo,
      string dataarchivo)
    {
      string str = string.Empty;
      Facturas.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Facturas.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      try
      {
        if (Facturas.rolesUsuarios.ControlFacturas || Facturas.rolesUsuarios.Tipo == "ROOT")
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
              guid = Facturas.usuario.IdUsuario;
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
              sisaEntitie1.JT_InsertUpdateControlFacturas(IdControlFactura, new DateTime?(DateTime.Parse(FechaFactura)), IdProveedor, NoFactura, OrdenCompra, IdProyecto, Moneda, new Decimal?(Decimal.Parse(SubTotal)), new Decimal?(Decimal.Parse(Descuento)), new Decimal?(Decimal.Parse(Iva)), new Decimal?(Decimal.Parse(Total)), new int?(int.Parse(Estatus)), FormaPago, new int?(int.Parse(Viaticos)), Facturas.usuario.IdUsuario.ToString(), Categoria, new Decimal?(Decimal.Parse(Anticipo)), new Decimal?(Decimal.Parse(NotaCredito)), Proyecto, nombrearchivo, dataarchivo);
              sisaEntitie1.SaveChanges();
            }
            if (IdControlFactura == "0")
            {
              IQueryable<tblControlFacturas> source = ((IQueryable<tblControlFacturas>) sisaEntitie1.tblControlFacturas).Where<tblControlFacturas>((Expression<Func<tblControlFacturas, bool>>) (a => a.IdProveedor.ToString() == IdProveedor && a.NoFactura == NoFactura && a.IdProyecto == IdProyecto && a.Total.ToString() == Total && a.Categoria == Categoria));
              Expression<Func<tblControlFacturas, \u003C\u003Ef__AnonymousType7<Guid>>> selector = a => new
              {
                IdControlFacturas = a.IdControlFacturas
              };
              foreach (var data in source.Select(selector))
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
            tblEficienciasDesglose eficienciasDesglose1 = ((IQueryable<tblEficienciasDesglose>) sisaEntitie.tblEficienciasDesglose).FirstOrDefault<tblEficienciasDesglose>((Expression<Func<tblEficienciasDesglose, bool>>) (e => e.idDocumento == IdControlFactura));
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
                idUsuarioUltimo = Facturas.usuario.IdUsuario.ToString()
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
    public static string GuardarXml(string NombreArchivo, string Archivo)
    {
      string empty = string.Empty;
      Facturas.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Facturas.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      string[] strArray = Archivo.Split(',');
      Encoding.ASCII.GetString(Convert.FromBase64String(strArray[1]));
      string str1 = AppDomain.CurrentDomain.BaseDirectory + "\\FacturasXML\\";
      File.WriteAllBytes(str1 + NombreArchivo, Convert.FromBase64String(strArray[1]));
      string str2 = str1 + NombreArchivo;
      XNamespace xnamespace1 = (XNamespace) "http://www.sat.gob.mx/cfd/3";
      XNamespace xnamespace2 = (XNamespace) "http://www.sat.gob.mx/TimbreFiscalDigital";
      XDocument xdocument = XDocument.Load(str2);
      XElement xelement1 = xdocument.Element(xnamespace1 + "Comprobante");
      XElement xelement2 = xdocument.Element(xnamespace1 + "Comprobante").Element(xnamespace1 + "Receptor");
      XElement xelement3 = xdocument.Element(xnamespace1 + "Comprobante").Element(xnamespace1 + "Impuestos");
      string folioFactura = (string) xelement1.Attribute((XName) "Folio");
      string s1 = (string) xelement1.Attribute((XName) "Fecha");
      string rfcReceptor = (string) xelement2.Attribute((XName) "Rfc");
      string nombreReceptor = (string) xelement2.Attribute((XName) "Nombre");
      string s2 = (string) xelement1.Attribute((XName) "SubTotal");
      string s3;
      string s4;
      if (xelement3 == null)
      {
        s3 = "0.00";
        s4 = "0.00";
      }
      else
      {
        s3 = (string) xelement3.Attribute((XName) "TotalImpuestosTrasladados");
        s4 = (string) xelement3.Attribute((XName) "TotalImpuestosRetenidos");
      }
      string s5 = (string) xelement1.Attribute((XName) "Total");
      string moneda = (string) xelement1.Attribute((XName) "Moneda");
      string s6 = (string) xelement1.Attribute((XName) "TipoCambio");
      if (File.Exists(str2))
        File.Delete(str2);
      if (s4 == null)
        s4 = "0.00";
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
    }

    [WebMethod]
    public static string GuardarRecibidaXML(string NombreArchivo, string Archivo)
    {
      string empty = string.Empty;
      Facturas.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Facturas.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      string[] strArray = Archivo.Split(',');
      Encoding.ASCII.GetString(Convert.FromBase64String(strArray[1]));
      string str1 = AppDomain.CurrentDomain.BaseDirectory + "\\FacturasXML\\";
      File.WriteAllBytes(str1 + NombreArchivo, Convert.FromBase64String(strArray[1]));
      string str2 = str1 + NombreArchivo;
      XNamespace xnamespace1 = (XNamespace) "http://www.sat.gob.mx/cfd/3";
      XNamespace xnamespace2 = (XNamespace) "http://www.sat.gob.mx/TimbreFiscalDigital";
      XDocument xdocument = XDocument.Load(str2);
      XElement xelement1 = xdocument.Element(xnamespace1 + "Comprobante");
      XElement xelement2 = xdocument.Element(xnamespace1 + "Comprobante").Element(xnamespace1 + "Receptor");
      XElement xelement3 = xdocument.Element(xnamespace1 + "Comprobante").Element(xnamespace1 + "Impuestos");
      string RFCEmisor = (string) xdocument.Element(xnamespace1 + "Comprobante").Element(xnamespace1 + "Emisor").Attribute((XName) "Rfc");
      string noFactura = (string) xelement1.Attribute((XName) "Folio");
      string s1 = (string) xelement1.Attribute((XName) "Fecha");
      string str3 = (string) xelement2.Attribute((XName) "Rfc");
      string str4 = (string) xelement2.Attribute((XName) "Nombre");
      string s2 = (string) xelement1.Attribute((XName) "SubTotal");
      string str5 = "";
      string s3;
      string str6;
      if (xelement3 == null)
      {
        s3 = "0.00";
        str6 = "0.00";
      }
      else
      {
        s3 = (string) xelement3.Attribute((XName) "TotalImpuestosTrasladados");
        str6 = (string) xelement3.Attribute((XName) "TotalImpuestosRetenidos");
      }
      string s4 = (string) xelement1.Attribute((XName) "Total");
      string moneda = (string) xelement1.Attribute((XName) "Moneda");
      string str7 = (string) xelement1.Attribute((XName) "TipoCambio");
      if (File.Exists(str2))
        File.Delete(str2);
      if (str6 == null)
        str5 = "0.00";
      try
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblProveedores tblProveedores = ((IQueryable<tblProveedores>) sisaEntitie.tblProveedores).FirstOrDefault<tblProveedores>((Expression<Func<tblProveedores, bool>>) (p => p.RFC.Trim() == RFCEmisor));
          if (tblProveedores != null)
          {
            sisaEntitie.JT_InsertUpdateControlFacturas("0", new DateTime?(DateTime.Parse(s1)), tblProveedores.IdProveedor.ToString(), noFactura, "N/A", "B2C9AA16-C340-47A1-8744-5CA73C388F92", moneda, new Decimal?(Decimal.Parse(s2)), new Decimal?(0M), new Decimal?(Decimal.Parse(s3)), new Decimal?(Decimal.Parse(s4)), new int?(0), "", new int?(0), Facturas.usuario.IdUsuario.ToString(), "", new Decimal?(0M), new Decimal?(0M), "N/A", "", "");
            sisaEntitie.SaveChanges();
          }
          else
          {
            sisaEntitie.JT_InsertUpdateControlFacturas("0", new DateTime?(DateTime.Parse(s1)), "81d71cb6-fcc3-451f-ae2a-1094dcf38e5d", noFactura, "N/A", "B2C9AA16-C340-47A1-8744-5CA73C388F92", moneda, new Decimal?(Decimal.Parse(s2)), new Decimal?(0M), new Decimal?(Decimal.Parse(s3)), new Decimal?(Decimal.Parse(s4)), new int?(0), "", new int?(0), Facturas.usuario.IdUsuario.ToString(), "", new Decimal?(0M), new Decimal?(0M), "N/A", "", "");
            sisaEntitie.SaveChanges();
          }
        }
        return "Factura recibida, agregada.";
      }
      catch (Exception ex)
      {
        return ex.ToString();
      }
    }

    [WebMethod]
    public static string CargarFacturaEmitida(string pid)
    {
      string str = string.Empty;
      Facturas.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Facturas.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      try
      {
        if (Facturas.rolesUsuarios.ControlFacturas || Facturas.rolesUsuarios.Tipo == "ROOT")
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
            str = JsonConvert.SerializeObject((object) ((IQueryable<tblFacturasEmitidas>) sisaEntitie.tblFacturasEmitidas).Where<tblFacturasEmitidas>((Expression<Func<tblFacturasEmitidas, bool>>) (A => A.IdFacturasEmitidas.ToString() == pid)).Select(A => new
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
              Retencion = A.Retencion
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
    public static string EditarFactura(
      string IdFacturasEmitidas,
      string IdProyecto,
      string NoCotizacion,
      string NoOrdenCompra,
      string ProgramacionPago,
      string PorPagar,
      string FechaPago,
      string Estatus,
      string Retencion)
    {
      string str = string.Empty;
      Facturas.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Facturas.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      try
      {
        if (Facturas.rolesUsuarios.ControlFacturas || Facturas.rolesUsuarios.Tipo == "ROOT")
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
          {
            tblFacturasEmitidas facturasEmitidas = ((IQueryable<tblFacturasEmitidas>) sisaEntitie.tblFacturasEmitidas).FirstOrDefault<tblFacturasEmitidas>((Expression<Func<tblFacturasEmitidas, bool>>) (a => a.IdFacturasEmitidas.ToString() == IdFacturasEmitidas));
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
    public static string AgregarFacturaEmitida(
      string folioFactura,
      string fecha,
      string rfcReceptor,
      string nombreReceptor,
      string subTotal,
      string iva,
      string retencion,
      string total,
      string moneda,
      string tipoCambio,
      string IdProyecto,
      string NoCotizacion,
      string NoOrdenCompra,
      string ProgramacionPago,
      string PorPagar,
      string FechaPago,
      string Estatus)
    {
      string str = string.Empty;
      Facturas.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Facturas.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      try
      {
        if (Facturas.rolesUsuarios.ControlFacturas || Facturas.rolesUsuarios.Tipo == "ROOT")
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
          {
            Decimal num = string.IsNullOrEmpty(retencion) ? 0M : Decimal.Parse(retencion);
            tblFacturasEmitidas facturasEmitidas = new tblFacturasEmitidas()
            {
              IdFacturasEmitidas = Guid.NewGuid(),
              FolioFactura = folioFactura,
              FechaAlta = new DateTime?(DateTime.Now),
              FechaFactura = DateTime.Parse(fecha),
              FechaModificacion = new DateTime?(DateTime.Now),
              IdUsuario = new Guid?(Facturas.usuario.IdUsuario),
              IdUsuarioModificacion = new Guid?(Facturas.usuario.IdUsuario),
              Estatus = int.Parse(Estatus),
              IdProyecto = IdProyecto,
              RfcReceptor = rfcReceptor,
              NombreReceptor = nombreReceptor,
              NoCotizacion = NoCotizacion,
              OrdenCompraRecibida = NoOrdenCompra,
              SubTotal = Decimal.Parse(subTotal),
              Iva = Decimal.Parse(iva),
              Total = Decimal.Parse(total),
              Moneda = moneda,
              PorPagar = new Decimal?(PorPagar.Length > 0 ? Decimal.Parse(PorPagar) : 0M),
              TipoCambio = new Decimal?(Decimal.Parse(tipoCambio)),
              Retencion = new Decimal?(num)
            };
            sisaEntitie.tblFacturasEmitidas.Add(facturasEmitidas);
            sisaEntitie.SaveChanges();
            if (FechaPago.Length > 0)
            {
              facturasEmitidas.FechaPago = new DateTime?(DateTime.Parse(FechaPago));
              sisaEntitie.SaveChanges();
            }
            if (ProgramacionPago.Length > 0)
            {
              facturasEmitidas.ProgramacionPago = new DateTime?(DateTime.Parse(ProgramacionPago));
              sisaEntitie.SaveChanges();
            }
            str = "Factura guardada.";
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
    public static string EliminarFacturas(string pid, string Opcion)
    {
      string str = string.Empty;
      Facturas.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Facturas.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Facturas.rolesUsuarios.ControlFacturas || Facturas.rolesUsuarios.Tipo == "ROOT")
      {
        try
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
          {
            if (Opcion == "FR")
            {
              tblControlFacturas tblControlFacturas = ((IQueryable<tblControlFacturas>) sisaEntitie.tblControlFacturas).FirstOrDefault<tblControlFacturas>((Expression<Func<tblControlFacturas, bool>>) (p => p.IdControlFacturas.ToString() == pid));
              if (tblControlFacturas != null)
              {
                sisaEntitie.tblControlFacturas.Remove(tblControlFacturas);
                sisaEntitie.SaveChanges();
                tblEficienciasDesglose eficienciasDesglose = ((IQueryable<tblEficienciasDesglose>) sisaEntitie.tblEficienciasDesglose).FirstOrDefault<tblEficienciasDesglose>((Expression<Func<tblEficienciasDesglose, bool>>) (p => p.idDocumento == pid));
                if (eficienciasDesglose != null)
                {
                  sisaEntitie.tblEficienciasDesglose.Remove(eficienciasDesglose);
                  sisaEntitie.SaveChanges();
                }
                str = "Documento eliminado.";
              }
              else
                str = "No se encontro información de documento, intenta de nuevo recargando página";
            }
            else if (Opcion == "FE")
            {
              tblFacturasEmitidas facturasEmitidas = ((IQueryable<tblFacturasEmitidas>) sisaEntitie.tblFacturasEmitidas).FirstOrDefault<tblFacturasEmitidas>((Expression<Func<tblFacturasEmitidas, bool>>) (p => p.IdFacturasEmitidas.ToString() == pid));
              if (facturasEmitidas != null)
              {
                sisaEntitie.tblFacturasEmitidas.Remove(facturasEmitidas);
                sisaEntitie.SaveChanges();
                str = "Documento eliminado.";
              }
              else
                str = "No se encontro información de documento, intenta de nuevo recargando página";
            }
          }
        }
        catch (Exception ex)
        {
          str = ex.ToString();
        }
      }
      else
        str = "No tienes permiso de eliminar factura.";
      return str;
    }

    [WebMethod]
    public static string CambiarEstatusFR(string array, string FormaPago)
    {
      string str1 = string.Empty;
      Facturas.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Facturas.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Facturas.rolesUsuarios.ControlFacturas || Facturas.rolesUsuarios.Tipo == "ROOT")
      {
        try
        {
          string[] strArray = array.Split('|');
          using (SisaEntitie sisaEntitie = new SisaEntitie())
          {
            foreach (string str2 in strArray)
            {
              string arr = str2;
              tblControlFacturas tblControlFacturas = ((IQueryable<tblControlFacturas>) sisaEntitie.tblControlFacturas).FirstOrDefault<tblControlFacturas>((Expression<Func<tblControlFacturas, bool>>) (s => s.IdControlFacturas.ToString() == arr));
              if (tblControlFacturas != null)
              {
                tblControlFacturas.Estatus = 1;
                tblControlFacturas.FormaPago = FormaPago;
                sisaEntitie.SaveChanges();
              }
              str1 = "Informacion actualizada.";
            }
          }
        }
        catch (Exception ex)
        {
          str1 = ex.ToString();
        }
      }
      else
        str1 = "No tienes permiso de modificar factura.";
      return str1;
    }

    [WebMethod]
    public static string BuscarProyecto(string pid)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
        return JsonConvert.SerializeObject((object) ((IQueryable<tblOrdenCompra>) sisaEntitie.tblOrdenCompra).Where<tblOrdenCompra>((Expression<Func<tblOrdenCompra, bool>>) (a => a.Folio == pid)).Select(a => new
        {
          IdProyecto = a.IdProyecto,
          Folio = a.Folio
        }));
    }
  }
}
