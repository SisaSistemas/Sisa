// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.SisaEntitie
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace SisaDev.Models
{
  public class SisaEntitie : DbContext
  {
    public SisaEntitie()
      : base("name=SisaEntitie")
    {
    }

    protected virtual void OnModelCreating(DbModelBuilder modelBuilder) => throw new UnintentionalCodeFirstException();

    public virtual DbSet<SisaDev.Models.DateDimension> DateDimension { get; set; }

    public virtual DbSet<SisaDev.Models.Productos> Productos { get; set; }

    public virtual DbSet<SisaDev.Models.tblBoletin> tblBoletin { get; set; }

    public virtual DbSet<SisaDev.Models.tblCajaChica> tblCajaChica { get; set; }

    public virtual DbSet<SisaDev.Models.tblCalendario> tblCalendario { get; set; }

    public virtual DbSet<SisaDev.Models.tblCategoria> tblCategoria { get; set; }

    public virtual DbSet<SisaDev.Models.tblChat> tblChat { get; set; }

    public virtual DbSet<SisaDev.Models.tblClienteContacto> tblClienteContacto { get; set; }

    public virtual DbSet<SisaDev.Models.tblClientes> tblClientes { get; set; }

    public virtual DbSet<SisaDev.Models.tblComentariosCotizacion> tblComentariosCotizacion { get; set; }

    public virtual DbSet<SisaDev.Models.tblComentariosProyecto> tblComentariosProyecto { get; set; }

    public virtual DbSet<SisaDev.Models.tblControlFacturas> tblControlFacturas { get; set; }

    public virtual DbSet<SisaDev.Models.tblCotizaciones> tblCotizaciones { get; set; }

    public virtual DbSet<SisaDev.Models.tblCotizacionesDet> tblCotizacionesDet { get; set; }

    public virtual DbSet<SisaDev.Models.tblCotizacionNew> tblCotizacionNew { get; set; }

    public virtual DbSet<SisaDev.Models.tblDatosEmpresa> tblDatosEmpresa { get; set; }

    public virtual DbSet<SisaDev.Models.tblDocDisenosMecanico> tblDocDisenosMecanico { get; set; }

    public virtual DbSet<SisaDev.Models.tblDocMasterCamMecanico> tblDocMasterCamMecanico { get; set; }

    public virtual DbSet<SisaDev.Models.tblDocProyectos> tblDocProyectos { get; set; }

    public virtual DbSet<SisaDev.Models.tblEficiencias> tblEficiencias { get; set; }

    public virtual DbSet<SisaDev.Models.tblEmpresas> tblEmpresas { get; set; }

    public virtual DbSet<SisaDev.Models.tblFacturasEmitidas> tblFacturasEmitidas { get; set; }

    public virtual DbSet<SisaDev.Models.tblFacturasXML> tblFacturasXML { get; set; }

    public virtual DbSet<SisaDev.Models.tblFallas> tblFallas { get; set; }

    public virtual DbSet<SisaDev.Models.tblFolioCotizacion> tblFolioCotizacion { get; set; }

    public virtual DbSet<SisaDev.Models.tblFolioOrdenCompra> tblFolioOrdenCompra { get; set; }

    public virtual DbSet<SisaDev.Models.tblFolioReq> tblFolioReq { get; set; }

    public virtual DbSet<SisaDev.Models.tblFolioRFQ> tblFolioRFQ { get; set; }

    public virtual DbSet<SisaDev.Models.tblGastos> tblGastos { get; set; }

    public virtual DbSet<SisaDev.Models.tblGPS> tblGPS { get; set; }

    public virtual DbSet<SisaDev.Models.tblHorasHombre> tblHorasHombre { get; set; }

    public virtual DbSet<SisaDev.Models.tblInventario> tblInventario { get; set; }

    public virtual DbSet<SisaDev.Models.tblInventarioDet> tblInventarioDet { get; set; }

    public virtual DbSet<SisaDev.Models.tblInvHerramientas> tblInvHerramientas { get; set; }

    public virtual DbSet<SisaDev.Models.tblInvHerramientasDet> tblInvHerramientasDet { get; set; }

    public virtual DbSet<SisaDev.Models.tblLiderProyecto> tblLiderProyecto { get; set; }

    public virtual DbSet<SisaDev.Models.tblListaPendientes> tblListaPendientes { get; set; }

    public virtual DbSet<SisaDev.Models.tblMateriales> tblMateriales { get; set; }

    public virtual DbSet<SisaDev.Models.tblMaterialImagen> tblMaterialImagen { get; set; }

    public virtual DbSet<SisaDev.Models.tblMatrizMecanico> tblMatrizMecanico { get; set; }

    public virtual DbSet<SisaDev.Models.tblMenu> tblMenu { get; set; }

    public virtual DbSet<SisaDev.Models.tblMonedas> tblMonedas { get; set; }

    public virtual DbSet<SisaDev.Models.tblNotaAclaratoria> tblNotaAclaratoria { get; set; }

    public virtual DbSet<SisaDev.Models.tblOrdenCompra> tblOrdenCompra { get; set; }

    public virtual DbSet<SisaDev.Models.tblOrdenCompraComentarios> tblOrdenCompraComentarios { get; set; }

    public virtual DbSet<SisaDev.Models.tblOrdenCompraDet> tblOrdenCompraDet { get; set; }

    public virtual DbSet<SisaDev.Models.tblOrdenCompraInsumos> tblOrdenCompraInsumos { get; set; }

    public virtual DbSet<SisaDev.Models.tblOrdenCompraNota> tblOrdenCompraNota { get; set; }

    public virtual DbSet<SisaDev.Models.tblPermisos> tblPermisos { get; set; }

    public virtual DbSet<SisaDev.Models.tblProveedores> tblProveedores { get; set; }

    public virtual DbSet<SisaDev.Models.tblProveedoresContactos> tblProveedoresContactos { get; set; }

    public virtual DbSet<SisaDev.Models.tblProveedorMaterial> tblProveedorMaterial { get; set; }

    public virtual DbSet<SisaDev.Models.tblProyectoRequerimiento> tblProyectoRequerimiento { get; set; }

    public virtual DbSet<SisaDev.Models.tblProyectos> tblProyectos { get; set; }

    public virtual DbSet<SisaDev.Models.tblProyectosGastos> tblProyectosGastos { get; set; }

    public virtual DbSet<SisaDev.Models.tblProyectoTaskImagen> tblProyectoTaskImagen { get; set; }

    public virtual DbSet<SisaDev.Models.tblProyectoTasks> tblProyectoTasks { get; set; }

    public virtual DbSet<SisaDev.Models.tblProyectoTasksComentarios> tblProyectoTasksComentarios { get; set; }

    public virtual DbSet<SisaDev.Models.tblRecuperaciones> tblRecuperaciones { get; set; }

    public virtual DbSet<SisaDev.Models.tblReqDet> tblReqDet { get; set; }

    public virtual DbSet<SisaDev.Models.tblReqEnc> tblReqEnc { get; set; }

    public virtual DbSet<SisaDev.Models.tblRequisicion> tblRequisicion { get; set; }

    public virtual DbSet<SisaDev.Models.tblRFQ> tblRFQ { get; set; }

    public virtual DbSet<SisaDev.Models.tblRFQDet> tblRFQDet { get; set; }

    public virtual DbSet<SisaDev.Models.tblRfqSeguimiento> tblRfqSeguimiento { get; set; }

    public virtual DbSet<SisaDev.Models.tblRfqVentas> tblRfqVentas { get; set; }

    public virtual DbSet<SisaDev.Models.tblRolesUsuarios> tblRolesUsuarios { get; set; }

    public virtual DbSet<SisaDev.Models.tblServicioComputo> tblServicioComputo { get; set; }

    public virtual DbSet<SisaDev.Models.tblServiciosComputo> tblServiciosComputo { get; set; }

    public virtual DbSet<SisaDev.Models.tblSolicitudesAprobacion> tblSolicitudesAprobacion { get; set; }

    public virtual DbSet<SisaDev.Models.tblSubMenu> tblSubMenu { get; set; }

    public virtual DbSet<SisaDev.Models.tblSucursales> tblSucursales { get; set; }

    public virtual DbSet<SisaDev.Models.tblTeamProject> tblTeamProject { get; set; }

    public virtual DbSet<SisaDev.Models.tblUnidadMedida> tblUnidadMedida { get; set; }

    public virtual DbSet<SisaDev.Models.tblUsuarios> tblUsuarios { get; set; }

    public virtual DbSet<SisaDev.Models.tblVehiculos> tblVehiculos { get; set; }

    public virtual DbSet<SisaDev.Models.tblVehiculoServicio> tblVehiculoServicio { get; set; }

    public virtual DbSet<SisaDev.Models.tblVehiculoServicioItem> tblVehiculoServicioItem { get; set; }

    public virtual DbSet<SisaDev.Models.tblViaticos> tblViaticos { get; set; }

    public virtual DbSet<SisaDev.Models.tblViaticosDet> tblViaticosDet { get; set; }

    public virtual DbSet<SisaDev.Models.tblViaticosDetImagenes> tblViaticosDetImagenes { get; set; }

    public virtual DbSet<SisaDev.Models.Utilidad> Utilidad { get; set; }

    public virtual DbSet<SisaDev.Models.UtilidadPastel> UtilidadPastel { get; set; }

    public virtual DbSet<SisaDev.Models.tblHabilidades> tblHabilidades { get; set; }

    public virtual DbSet<SisaDev.Models.tblOrdenTrabajo> tblOrdenTrabajo { get; set; }

    public virtual DbSet<SisaDev.Models.tblProyectosBK> tblProyectosBK { get; set; }

    public virtual DbSet<SisaDev.Models.tblProyectoTasksBK> tblProyectoTasksBK { get; set; }

    public virtual DbSet<SisaDev.Models.tblTimmingProyecto> tblTimmingProyecto { get; set; }

    public virtual DbSet<SisaDev.Models.tblUsuariosBK> tblUsuariosBK { get; set; }

    public virtual DbSet<SisaDev.Models.tblProyectosGastosEficiencias> tblProyectosGastosEficiencias { get; set; }

    public virtual DbSet<SisaDev.Models.tblEficienciasDesglose> tblEficienciasDesglose { get; set; }

    public virtual ObjectResult<CargarEficiencias_Result> CargarEficiencias(
      string idProyecto)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<CargarEficiencias_Result>(nameof (CargarEficiencias), new ObjectParameter[1]
      {
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string))
      });
    }

    public virtual ObjectResult<string> JT_DeleteCajaChica(string idCajaChica) => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<string>(nameof (JT_DeleteCajaChica), new ObjectParameter[1]
    {
      idCajaChica != null ? new ObjectParameter("IdCajaChica", (object) idCajaChica) : new ObjectParameter("IdCajaChica", typeof (string))
    });

    public virtual ObjectResult<string> JT_InsertUpdateCajaChica(
      string idCajaChica,
      string responsable,
      string concepto,
      string idProyecto,
      string comprobante,
      Decimal? cargo,
      Decimal? abono,
      DateTime? fecha,
      int? estatus)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<string>(nameof (JT_InsertUpdateCajaChica), new ObjectParameter[9]
      {
        idCajaChica != null ? new ObjectParameter("IdCajaChica", (object) idCajaChica) : new ObjectParameter("IdCajaChica", typeof (string)),
        responsable != null ? new ObjectParameter("Responsable", (object) responsable) : new ObjectParameter("Responsable", typeof (string)),
        concepto != null ? new ObjectParameter("Concepto", (object) concepto) : new ObjectParameter("Concepto", typeof (string)),
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string)),
        comprobante != null ? new ObjectParameter("Comprobante", (object) comprobante) : new ObjectParameter("Comprobante", typeof (string)),
        cargo.HasValue ? new ObjectParameter("Cargo", (object) cargo) : new ObjectParameter("Cargo", typeof (Decimal)),
        abono.HasValue ? new ObjectParameter("Abono", (object) abono) : new ObjectParameter("Abono", typeof (Decimal)),
        fecha.HasValue ? new ObjectParameter("Fecha", (object) fecha) : new ObjectParameter("Fecha", typeof (DateTime)),
        estatus.HasValue ? new ObjectParameter("Estatus", (object) estatus) : new ObjectParameter("Estatus", typeof (int))
      });
    }

    public virtual ObjectResult<string> JT_InsertUpdateControlFacturas(
      string idControlFacturas,
      DateTime? fechaFactura,
      string idProveedor,
      string noFactura,
      string ordenCompra,
      string idProyecto,
      string moneda,
      Decimal? subTotal,
      Decimal? descuento,
      Decimal? iVA,
      Decimal? total,
      int? estatus,
      string formaPago,
      int? vaticos,
      string idUsuario,
      string categoria,
      Decimal? anticipo,
      Decimal? notaCredito,
      string proyecto,
      string nombreArchivo,
      string archivoFactura)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<string>(nameof (JT_InsertUpdateControlFacturas), new ObjectParameter[21]
      {
        idControlFacturas != null ? new ObjectParameter("IdControlFacturas", (object) idControlFacturas) : new ObjectParameter("IdControlFacturas", typeof (string)),
        fechaFactura.HasValue ? new ObjectParameter("FechaFactura", (object) fechaFactura) : new ObjectParameter("FechaFactura", typeof (DateTime)),
        idProveedor != null ? new ObjectParameter("IdProveedor", (object) idProveedor) : new ObjectParameter("IdProveedor", typeof (string)),
        noFactura != null ? new ObjectParameter("NoFactura", (object) noFactura) : new ObjectParameter("NoFactura", typeof (string)),
        ordenCompra != null ? new ObjectParameter("OrdenCompra", (object) ordenCompra) : new ObjectParameter("OrdenCompra", typeof (string)),
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string)),
        moneda != null ? new ObjectParameter("Moneda", (object) moneda) : new ObjectParameter("Moneda", typeof (string)),
        subTotal.HasValue ? new ObjectParameter("SubTotal", (object) subTotal) : new ObjectParameter("SubTotal", typeof (Decimal)),
        descuento.HasValue ? new ObjectParameter("Descuento", (object) descuento) : new ObjectParameter("Descuento", typeof (Decimal)),
        iVA.HasValue ? new ObjectParameter("IVA", (object) iVA) : new ObjectParameter("IVA", typeof (Decimal)),
        total.HasValue ? new ObjectParameter("Total", (object) total) : new ObjectParameter("Total", typeof (Decimal)),
        estatus.HasValue ? new ObjectParameter("Estatus", (object) estatus) : new ObjectParameter("Estatus", typeof (int)),
        formaPago != null ? new ObjectParameter("FormaPago", (object) formaPago) : new ObjectParameter("FormaPago", typeof (string)),
        vaticos.HasValue ? new ObjectParameter("Vaticos", (object) vaticos) : new ObjectParameter("Vaticos", typeof (int)),
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string)),
        categoria != null ? new ObjectParameter("Categoria", (object) categoria) : new ObjectParameter("Categoria", typeof (string)),
        anticipo.HasValue ? new ObjectParameter("Anticipo", (object) anticipo) : new ObjectParameter("Anticipo", typeof (Decimal)),
        notaCredito.HasValue ? new ObjectParameter("NotaCredito", (object) notaCredito) : new ObjectParameter("NotaCredito", typeof (Decimal)),
        proyecto != null ? new ObjectParameter("Proyecto", (object) proyecto) : new ObjectParameter("Proyecto", typeof (string)),
        nombreArchivo != null ? new ObjectParameter("NombreArchivo", (object) nombreArchivo) : new ObjectParameter("NombreArchivo", typeof (string)),
        archivoFactura != null ? new ObjectParameter("ArchivoFactura", (object) archivoFactura) : new ObjectParameter("ArchivoFactura", typeof (string))
      });
    }

    public virtual ObjectResult<string> JT_InsertUpdateServicioComputo(
      string idServicioComputo,
      string idUsuario,
      string tipo,
      string marca,
      string modelo,
      string noSerie,
      string comentarios,
      DateTime? fechaMantenimiento,
      int? completado)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<string>(nameof (JT_InsertUpdateServicioComputo), new ObjectParameter[9]
      {
        idServicioComputo != null ? new ObjectParameter("IdServicioComputo", (object) idServicioComputo) : new ObjectParameter("IdServicioComputo", typeof (string)),
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string)),
        tipo != null ? new ObjectParameter("Tipo", (object) tipo) : new ObjectParameter("Tipo", typeof (string)),
        marca != null ? new ObjectParameter("Marca", (object) marca) : new ObjectParameter("Marca", typeof (string)),
        modelo != null ? new ObjectParameter("Modelo", (object) modelo) : new ObjectParameter("Modelo", typeof (string)),
        noSerie != null ? new ObjectParameter("NoSerie", (object) noSerie) : new ObjectParameter("NoSerie", typeof (string)),
        comentarios != null ? new ObjectParameter("Comentarios", (object) comentarios) : new ObjectParameter("Comentarios", typeof (string)),
        fechaMantenimiento.HasValue ? new ObjectParameter("FechaMantenimiento", (object) fechaMantenimiento) : new ObjectParameter("FechaMantenimiento", typeof (DateTime)),
        completado.HasValue ? new ObjectParameter("Completado", (object) completado) : new ObjectParameter("Completado", typeof (int))
      });
    }

    public virtual ObjectResult<string> JT_InsertUpdateVehiculos(
      string idCarro,
      string vehiculo,
      int? anio,
      int? activo,
      string idUsuario)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<string>(nameof (JT_InsertUpdateVehiculos), new ObjectParameter[5]
      {
        idCarro != null ? new ObjectParameter("IdCarro", (object) idCarro) : new ObjectParameter("IdCarro", typeof (string)),
        vehiculo != null ? new ObjectParameter("Vehiculo", (object) vehiculo) : new ObjectParameter("Vehiculo", typeof (string)),
        anio.HasValue ? new ObjectParameter("Anio", (object) anio) : new ObjectParameter("Anio", typeof (int)),
        activo.HasValue ? new ObjectParameter("Activo", (object) activo) : new ObjectParameter("Activo", typeof (int)),
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string))
      });
    }

    public virtual ObjectResult<string> JT_InsertUpdateVehiculoServicio(
      string idServicioVehiculo,
      string idCarro,
      int? kilometrajeActual,
      string taller,
      int? kilometrajeProximo,
      DateTime? fechaServicio,
      string idUsuario)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<string>(nameof (JT_InsertUpdateVehiculoServicio), new ObjectParameter[7]
      {
        idServicioVehiculo != null ? new ObjectParameter("IdServicioVehiculo", (object) idServicioVehiculo) : new ObjectParameter("IdServicioVehiculo", typeof (string)),
        idCarro != null ? new ObjectParameter("IdCarro", (object) idCarro) : new ObjectParameter("IdCarro", typeof (string)),
        kilometrajeActual.HasValue ? new ObjectParameter("KilometrajeActual", (object) kilometrajeActual) : new ObjectParameter("KilometrajeActual", typeof (int)),
        taller != null ? new ObjectParameter("Taller", (object) taller) : new ObjectParameter("Taller", typeof (string)),
        kilometrajeProximo.HasValue ? new ObjectParameter("KilometrajeProximo", (object) kilometrajeProximo) : new ObjectParameter("KilometrajeProximo", typeof (int)),
        fechaServicio.HasValue ? new ObjectParameter("FechaServicio", (object) fechaServicio) : new ObjectParameter("FechaServicio", typeof (DateTime)),
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string))
      });
    }

    public virtual ObjectResult<string> JT_InsertUpdateVehiculoServicioItem(
      string idServicioVehiculoItem,
      string idServicioVehiculo,
      string servicio,
      string idUsuario)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<string>(nameof (JT_InsertUpdateVehiculoServicioItem), new ObjectParameter[4]
      {
        idServicioVehiculoItem != null ? new ObjectParameter("IdServicioVehiculoItem", (object) idServicioVehiculoItem) : new ObjectParameter("IdServicioVehiculoItem", typeof (string)),
        idServicioVehiculo != null ? new ObjectParameter("IdServicioVehiculo", (object) idServicioVehiculo) : new ObjectParameter("IdServicioVehiculo", typeof (string)),
        servicio != null ? new ObjectParameter("Servicio", (object) servicio) : new ObjectParameter("Servicio", typeof (string)),
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string))
      });
    }

    public virtual ObjectResult<JT_LoadCajaChica_Result> JT_LoadCajaChica() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<JT_LoadCajaChica_Result>(nameof (JT_LoadCajaChica), new ObjectParameter[0]);

    public virtual int JT_LoadControlFacturas(
      string mes,
      string idProveedor,
      string noFactura,
      string proyecto,
      string moneda,
      int? estatus)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (JT_LoadControlFacturas), new ObjectParameter[6]
      {
        mes != null ? new ObjectParameter("Mes", (object) mes) : new ObjectParameter("Mes", typeof (string)),
        idProveedor != null ? new ObjectParameter("IdProveedor", (object) idProveedor) : new ObjectParameter("IdProveedor", typeof (string)),
        noFactura != null ? new ObjectParameter("NoFactura", (object) noFactura) : new ObjectParameter("NoFactura", typeof (string)),
        proyecto != null ? new ObjectParameter("Proyecto", (object) proyecto) : new ObjectParameter("Proyecto", typeof (string)),
        moneda != null ? new ObjectParameter("Moneda", (object) moneda) : new ObjectParameter("Moneda", typeof (string)),
        estatus.HasValue ? new ObjectParameter("Estatus", (object) estatus) : new ObjectParameter("Estatus", typeof (int))
      });
    }

    public virtual int JT_LoadFacturasEmitidas(
      string anio,
      string cliente,
      string idProyecto,
      string moneda,
      int? estatus)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (JT_LoadFacturasEmitidas), new ObjectParameter[5]
      {
        anio != null ? new ObjectParameter("Anio", (object) anio) : new ObjectParameter("Anio", typeof (string)),
        cliente != null ? new ObjectParameter("Cliente", (object) cliente) : new ObjectParameter("Cliente", typeof (string)),
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string)),
        moneda != null ? new ObjectParameter("Moneda", (object) moneda) : new ObjectParameter("Moneda", typeof (string)),
        estatus.HasValue ? new ObjectParameter("Estatus", (object) estatus) : new ObjectParameter("Estatus", typeof (int))
      });
    }

    public virtual ObjectResult<JT_LoadInvHerramienta_Result> JT_LoadInvHerramienta() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<JT_LoadInvHerramienta_Result>(nameof (JT_LoadInvHerramienta), new ObjectParameter[0]);

    public virtual ObjectResult<JT_LoadInvHerramientaDet_Result> JT_LoadInvHerramientaDet(
      string idHerramienta)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<JT_LoadInvHerramientaDet_Result>(nameof (JT_LoadInvHerramientaDet), new ObjectParameter[1]
      {
        idHerramienta != null ? new ObjectParameter("IdHerramienta", (object) idHerramienta) : new ObjectParameter("IdHerramienta", typeof (string))
      });
    }

    public virtual ObjectResult<JT_LoadMonitorMecanico_Result> JT_LoadMonitorMecanico() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<JT_LoadMonitorMecanico_Result>(nameof (JT_LoadMonitorMecanico), new ObjectParameter[0]);

    public virtual ObjectResult<JT_LoadServicioComputo_Result> JT_LoadServicioComputo() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<JT_LoadServicioComputo_Result>(nameof (JT_LoadServicioComputo), new ObjectParameter[0]);

    public virtual ObjectResult<JT_LoadVehiculos_Result> JT_LoadVehiculos() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<JT_LoadVehiculos_Result>(nameof (JT_LoadVehiculos), new ObjectParameter[0]);

    public virtual ObjectResult<JT_LoadVehiculoServicio_Result> JT_LoadVehiculoServicio(
      string idCarro)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<JT_LoadVehiculoServicio_Result>(nameof (JT_LoadVehiculoServicio), new ObjectParameter[1]
      {
        idCarro != null ? new ObjectParameter("IdCarro", (object) idCarro) : new ObjectParameter("IdCarro", typeof (string))
      });
    }

    public virtual ObjectResult<JT_LoadVehiculoServicioItem_Result> JT_LoadVehiculoServicioItem(
      string idServicioVehiculo)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<JT_LoadVehiculoServicioItem_Result>(nameof (JT_LoadVehiculoServicioItem), new ObjectParameter[1]
      {
        idServicioVehiculo != null ? new ObjectParameter("IdServicioVehiculo", (object) idServicioVehiculo) : new ObjectParameter("IdServicioVehiculo", typeof (string))
      });
    }

    public virtual ObjectResult<string> JT_UpdateFacturasEmitidas(
      string idFacturasEmitidas,
      string idProyecto,
      string noCotizacion,
      string ordenCompraRecibida,
      DateTime? programacionPago,
      Decimal? porPagar,
      DateTime? fechaPago,
      int? estatus)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<string>(nameof (JT_UpdateFacturasEmitidas), new ObjectParameter[8]
      {
        idFacturasEmitidas != null ? new ObjectParameter("IdFacturasEmitidas", (object) idFacturasEmitidas) : new ObjectParameter("IdFacturasEmitidas", typeof (string)),
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string)),
        noCotizacion != null ? new ObjectParameter("NoCotizacion", (object) noCotizacion) : new ObjectParameter("NoCotizacion", typeof (string)),
        ordenCompraRecibida != null ? new ObjectParameter("OrdenCompraRecibida", (object) ordenCompraRecibida) : new ObjectParameter("OrdenCompraRecibida", typeof (string)),
        programacionPago.HasValue ? new ObjectParameter("ProgramacionPago", (object) programacionPago) : new ObjectParameter("ProgramacionPago", typeof (DateTime)),
        porPagar.HasValue ? new ObjectParameter("PorPagar", (object) porPagar) : new ObjectParameter("PorPagar", typeof (Decimal)),
        fechaPago.HasValue ? new ObjectParameter("FechaPago", (object) fechaPago) : new ObjectParameter("FechaPago", typeof (DateTime)),
        estatus.HasValue ? new ObjectParameter("Estatus", (object) estatus) : new ObjectParameter("Estatus", typeof (int))
      });
    }

    public virtual int MezclaProductos() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (MezclaProductos), new ObjectParameter[0]);

    public virtual int sp_ActualizaCantidadEntregadaOC(
      string idOrdenCompra,
      int? item,
      Decimal? cantidadRecibida)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_ActualizaCantidadEntregadaOC), new ObjectParameter[3]
      {
        idOrdenCompra != null ? new ObjectParameter("IdOrdenCompra", (object) idOrdenCompra) : new ObjectParameter("IdOrdenCompra", typeof (string)),
        item.HasValue ? new ObjectParameter("Item", (object) item) : new ObjectParameter("Item", typeof (int)),
        cantidadRecibida.HasValue ? new ObjectParameter("CantidadRecibida", (object) cantidadRecibida) : new ObjectParameter("CantidadRecibida", typeof (Decimal))
      });
    }

    public virtual int sp_ActualizaDatosInfoCenter(
      string nombreRobot,
      Decimal? trabajoElectrico,
      Decimal? trabajoMecanico)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_ActualizaDatosInfoCenter), new ObjectParameter[3]
      {
        nombreRobot != null ? new ObjectParameter("NombreRobot", (object) nombreRobot) : new ObjectParameter("NombreRobot", typeof (string)),
        trabajoElectrico.HasValue ? new ObjectParameter("TrabajoElectrico", (object) trabajoElectrico) : new ObjectParameter("TrabajoElectrico", typeof (Decimal)),
        trabajoMecanico.HasValue ? new ObjectParameter("TrabajoMecanico", (object) trabajoMecanico) : new ObjectParameter("TrabajoMecanico", typeof (Decimal))
      });
    }

    public virtual int sp_ActualizaDatosInfoCenterValiant(
      int? idEstacion,
      Decimal? electrico,
      Decimal? mecanico,
      string comentarios)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_ActualizaDatosInfoCenterValiant), new ObjectParameter[4]
      {
        idEstacion.HasValue ? new ObjectParameter("IdEstacion", (object) idEstacion) : new ObjectParameter("IdEstacion", typeof (int)),
        electrico.HasValue ? new ObjectParameter("Electrico", (object) electrico) : new ObjectParameter("Electrico", typeof (Decimal)),
        mecanico.HasValue ? new ObjectParameter("Mecanico", (object) mecanico) : new ObjectParameter("Mecanico", typeof (Decimal)),
        comentarios != null ? new ObjectParameter("Comentarios", (object) comentarios) : new ObjectParameter("Comentarios", typeof (string))
      });
    }

    public virtual int sp_ActualizaSueldoUsuario(
      string idUsuario,
      Decimal? sueldo,
      string idUsuarioModifico)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_ActualizaSueldoUsuario), new ObjectParameter[3]
      {
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string)),
        sueldo.HasValue ? new ObjectParameter("Sueldo", (object) sueldo) : new ObjectParameter("Sueldo", typeof (Decimal)),
        idUsuarioModifico != null ? new ObjectParameter("IdUsuarioModifico", (object) idUsuarioModifico) : new ObjectParameter("IdUsuarioModifico", typeof (string))
      });
    }

    public virtual ObjectResult<sp_Administracion_Result> sp_Administracion() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_Administracion_Result>(nameof (sp_Administracion), new ObjectParameter[0]);

    public virtual int sp_BDExcelRober() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_BDExcelRober), new ObjectParameter[0]);

    public virtual int sp_BuscarFacturasEmitidas(
      string anio,
      string cliente,
      string idProyecto,
      string moneda,
      int? estatus)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_BuscarFacturasEmitidas), new ObjectParameter[5]
      {
        anio != null ? new ObjectParameter("Anio", (object) anio) : new ObjectParameter("Anio", typeof (string)),
        cliente != null ? new ObjectParameter("Cliente", (object) cliente) : new ObjectParameter("Cliente", typeof (string)),
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string)),
        moneda != null ? new ObjectParameter("Moneda", (object) moneda) : new ObjectParameter("Moneda", typeof (string)),
        estatus.HasValue ? new ObjectParameter("Estatus", (object) estatus) : new ObjectParameter("Estatus", typeof (int))
      });
    }

    public virtual int sp_BuscarFacturasEmitidas_2(
      string anio,
      string cliente,
      string idProyecto,
      string moneda,
      string estatus)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_BuscarFacturasEmitidas_2), new ObjectParameter[5]
      {
        anio != null ? new ObjectParameter("Anio", (object) anio) : new ObjectParameter("Anio", typeof (string)),
        cliente != null ? new ObjectParameter("Cliente", (object) cliente) : new ObjectParameter("Cliente", typeof (string)),
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string)),
        moneda != null ? new ObjectParameter("Moneda", (object) moneda) : new ObjectParameter("Moneda", typeof (string)),
        estatus != null ? new ObjectParameter("Estatus", (object) estatus) : new ObjectParameter("Estatus", typeof (string))
      });
    }

    public virtual int sp_CambiaEstatusMaquinado(string idMaquinado, int? estatus) => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_CambiaEstatusMaquinado), new ObjectParameter[2]
    {
      idMaquinado != null ? new ObjectParameter("IdMaquinado", (object) idMaquinado) : new ObjectParameter("IdMaquinado", typeof (string)),
      estatus.HasValue ? new ObjectParameter("Estatus", (object) estatus) : new ObjectParameter("Estatus", typeof (int))
    });

    public virtual int sp_CambiaEstatusTask(string idTask, int? estatus, int? opcion) => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_CambiaEstatusTask), new ObjectParameter[3]
    {
      idTask != null ? new ObjectParameter("IdTask", (object) idTask) : new ObjectParameter("IdTask", typeof (string)),
      estatus.HasValue ? new ObjectParameter("Estatus", (object) estatus) : new ObjectParameter("Estatus", typeof (int)),
      opcion.HasValue ? new ObjectParameter("Opcion", (object) opcion) : new ObjectParameter("Opcion", typeof (int))
    });

    public virtual int sp_CambiarEstatusProyecto(
      string idProyecto,
      string idUsuario,
      string estatus)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_CambiarEstatusProyecto), new ObjectParameter[3]
      {
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string)),
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string)),
        estatus != null ? new ObjectParameter("Estatus", (object) estatus) : new ObjectParameter("Estatus", typeof (string))
      });
    }

    public virtual int sp_CancelaCotizacion(
      string idCotizacion,
      string idUsuario,
      string comentario)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_CancelaCotizacion), new ObjectParameter[3]
      {
        idCotizacion != null ? new ObjectParameter("IdCotizacion", (object) idCotizacion) : new ObjectParameter("IdCotizacion", typeof (string)),
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string)),
        comentario != null ? new ObjectParameter("Comentario", (object) comentario) : new ObjectParameter("Comentario", typeof (string))
      });
    }

    public virtual int sp_CancelaOrdenCompra(string idOrdenCompra, string motivo, string idUsuario) => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_CancelaOrdenCompra), new ObjectParameter[3]
    {
      idOrdenCompra != null ? new ObjectParameter("IdOrdenCompra", (object) idOrdenCompra) : new ObjectParameter("IdOrdenCompra", typeof (string)),
      motivo != null ? new ObjectParameter("Motivo", (object) motivo) : new ObjectParameter("Motivo", typeof (string)),
      idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string))
    });

    public virtual ObjectResult<sp_CargaCombos_Result> sp_CargaCombos(
      int? opcion)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_CargaCombos_Result>(nameof (sp_CargaCombos), new ObjectParameter[1]
      {
        opcion.HasValue ? new ObjectParameter("Opcion", (object) opcion) : new ObjectParameter("Opcion", typeof (int))
      });
    }

    public virtual ObjectResult<sp_CargaCombosFacturasEmitidas_Result> sp_CargaCombosFacturasEmitidas(
      int? opcion)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_CargaCombosFacturasEmitidas_Result>(nameof (sp_CargaCombosFacturasEmitidas), new ObjectParameter[1]
      {
        opcion.HasValue ? new ObjectParameter("Opcion", (object) opcion) : new ObjectParameter("Opcion", typeof (int))
      });
    }

    public virtual ObjectResult<sp_CargaComentariosOrdenCompra_Result> sp_CargaComentariosOrdenCompra(
      string idOrdenCompra)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_CargaComentariosOrdenCompra_Result>(nameof (sp_CargaComentariosOrdenCompra), new ObjectParameter[1]
      {
        idOrdenCompra != null ? new ObjectParameter("IdOrdenCompra", (object) idOrdenCompra) : new ObjectParameter("IdOrdenCompra", typeof (string))
      });
    }

    public virtual ObjectResult<sp_CargaListaViaticos_Result> sp_CargaListaViaticos() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_CargaListaViaticos_Result>(nameof (sp_CargaListaViaticos), new ObjectParameter[0]);

    public virtual ObjectResult<sp_CargaPerfilUsuario_Result> sp_CargaPerfilUsuario(
      string idUsuario,
      int? opcion)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_CargaPerfilUsuario_Result>(nameof (sp_CargaPerfilUsuario), new ObjectParameter[2]
      {
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string)),
        opcion.HasValue ? new ObjectParameter("Opcion", (object) opcion) : new ObjectParameter("Opcion", typeof (int))
      });
    }

    public virtual ObjectResult<sp_CargarArchivosFacturas_Result> sp_CargarArchivosFacturas(
      string idControlFacturas)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_CargarArchivosFacturas_Result>(nameof (sp_CargarArchivosFacturas), new ObjectParameter[1]
      {
        idControlFacturas != null ? new ObjectParameter("IdControlFacturas", (object) idControlFacturas) : new ObjectParameter("IdControlFacturas", typeof (string))
      });
    }

    public virtual ObjectResult<sp_CargarCombosControlFacturas_Result> sp_CargarCombosControlFacturas(
      int? opcion)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_CargarCombosControlFacturas_Result>(nameof (sp_CargarCombosControlFacturas), new ObjectParameter[1]
      {
        opcion.HasValue ? new ObjectParameter("Opcion", (object) opcion) : new ObjectParameter("Opcion", typeof (int))
      });
    }

    public virtual ObjectResult<sp_CargarCombosFacturasRecibidas_Result> sp_CargarCombosFacturasRecibidas(
      int? opcion)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_CargarCombosFacturasRecibidas_Result>(nameof (sp_CargarCombosFacturasRecibidas), new ObjectParameter[1]
      {
        opcion.HasValue ? new ObjectParameter("Opcion", (object) opcion) : new ObjectParameter("Opcion", typeof (int))
      });
    }

    public virtual ObjectResult<sp_CargarComentariosCotizacion_Result> sp_CargarComentariosCotizacion(
      string idCotizacion)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_CargarComentariosCotizacion_Result>(nameof (sp_CargarComentariosCotizacion), new ObjectParameter[1]
      {
        idCotizacion != null ? new ObjectParameter("IdCotizacion", (object) idCotizacion) : new ObjectParameter("IdCotizacion", typeof (string))
      });
    }

    public virtual ObjectResult<sp_CargarCotizaciones_Result> sp_CargarCotizaciones() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_CargarCotizaciones_Result>(nameof (sp_CargarCotizaciones), new ObjectParameter[0]);

    public virtual ObjectResult<sp_CargarCotizacionesReporte_Result> sp_CargarCotizacionesReporte(
      string id)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_CargarCotizacionesReporte_Result>(nameof (sp_CargarCotizacionesReporte), new ObjectParameter[1]
      {
        id != null ? new ObjectParameter("Id", (object) id) : new ObjectParameter("Id", typeof (string))
      });
    }

    public virtual ObjectResult<sp_CargarCotizacionesReporteDetalles_Result> sp_CargarCotizacionesReporteDetalles(
      string id)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_CargarCotizacionesReporteDetalles_Result>(nameof (sp_CargarCotizacionesReporteDetalles), new ObjectParameter[1]
      {
        id != null ? new ObjectParameter("Id", (object) id) : new ObjectParameter("Id", typeof (string))
      });
    }

    public virtual ObjectResult<sp_CargarCotizacionesReporteNotasAclaratorias_Result> sp_CargarCotizacionesReporteNotasAclaratorias(
      string id)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_CargarCotizacionesReporteNotasAclaratorias_Result>(nameof (sp_CargarCotizacionesReporteNotasAclaratorias), new ObjectParameter[1]
      {
        id != null ? new ObjectParameter("Id", (object) id) : new ObjectParameter("Id", typeof (string))
      });
    }

    public virtual ObjectResult<sp_CargarDetalleGrafica_Result> sp_CargarDetalleGrafica(
      string punto,
      string idProyecto)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_CargarDetalleGrafica_Result>(nameof (sp_CargarDetalleGrafica), new ObjectParameter[2]
      {
        punto != null ? new ObjectParameter("Punto", (object) punto) : new ObjectParameter("Punto", typeof (string)),
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string))
      });
    }

    public virtual ObjectResult<sp_CargarDetalleGraficaCajaChica_Result> sp_CargarDetalleGraficaCajaChica(
      string punto,
      string idProyecto)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_CargarDetalleGraficaCajaChica_Result>(nameof (sp_CargarDetalleGraficaCajaChica), new ObjectParameter[2]
      {
        punto != null ? new ObjectParameter("Punto", (object) punto) : new ObjectParameter("Punto", typeof (string)),
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string))
      });
    }

    public virtual ObjectResult<sp_CargarDetalleGraficaMO_Result> sp_CargarDetalleGraficaMO(
      string punto,
      string idProyecto)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_CargarDetalleGraficaMO_Result>(nameof (sp_CargarDetalleGraficaMO), new ObjectParameter[2]
      {
        punto != null ? new ObjectParameter("Punto", (object) punto) : new ObjectParameter("Punto", typeof (string)),
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string))
      });
    }

    public virtual ObjectResult<sp_CargarDetalleGraficaViaticos_Result> sp_CargarDetalleGraficaViaticos(
      string punto,
      string idProyecto)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_CargarDetalleGraficaViaticos_Result>(nameof (sp_CargarDetalleGraficaViaticos), new ObjectParameter[2]
      {
        punto != null ? new ObjectParameter("Punto", (object) punto) : new ObjectParameter("Punto", typeof (string)),
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string))
      });
    }

    public virtual ObjectResult<sp_CargarDetalleProyecto_Result> sp_CargarDetalleProyecto(
      string idProyecto,
      int? opcion)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_CargarDetalleProyecto_Result>(nameof (sp_CargarDetalleProyecto), new ObjectParameter[2]
      {
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string)),
        opcion.HasValue ? new ObjectParameter("Opcion", (object) opcion) : new ObjectParameter("Opcion", typeof (int))
      });
    }

    public virtual int sp_CargarFacturas(
      string mes,
      string idProveedor,
      string noFactura,
      string proyecto,
      string moneda,
      int? estatus)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_CargarFacturas), new ObjectParameter[6]
      {
        mes != null ? new ObjectParameter("Mes", (object) mes) : new ObjectParameter("Mes", typeof (string)),
        idProveedor != null ? new ObjectParameter("IdProveedor", (object) idProveedor) : new ObjectParameter("IdProveedor", typeof (string)),
        noFactura != null ? new ObjectParameter("NoFactura", (object) noFactura) : new ObjectParameter("NoFactura", typeof (string)),
        proyecto != null ? new ObjectParameter("Proyecto", (object) proyecto) : new ObjectParameter("Proyecto", typeof (string)),
        moneda != null ? new ObjectParameter("Moneda", (object) moneda) : new ObjectParameter("Moneda", typeof (string)),
        estatus.HasValue ? new ObjectParameter("Estatus", (object) estatus) : new ObjectParameter("Estatus", typeof (int))
      });
    }

    public virtual ObjectResult<sp_CargarFacturasEmitidas_Result> sp_CargarFacturasEmitidas(
      string id)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_CargarFacturasEmitidas_Result>(nameof (sp_CargarFacturasEmitidas), new ObjectParameter[1]
      {
        id != null ? new ObjectParameter(nameof (id), (object) id) : new ObjectParameter(nameof (id), typeof (string))
      });
    }

    public virtual ObjectResult<sp_CargarFacturasRecibidas_Result> sp_CargarFacturasRecibidas(
      string id)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_CargarFacturasRecibidas_Result>(nameof (sp_CargarFacturasRecibidas), new ObjectParameter[1]
      {
        id != null ? new ObjectParameter(nameof (id), (object) id) : new ObjectParameter(nameof (id), typeof (string))
      });
    }

    public virtual ObjectResult<sp_CargarMaterialesProveedor_Result> sp_CargarMaterialesProveedor(
      string idProveedor)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_CargarMaterialesProveedor_Result>(nameof (sp_CargarMaterialesProveedor), new ObjectParameter[1]
      {
        idProveedor != null ? new ObjectParameter("IdProveedor", (object) idProveedor) : new ObjectParameter("IdProveedor", typeof (string))
      });
    }

    public virtual int sp_CargarOrdenCompraProveedor(string idProveedor) => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_CargarOrdenCompraProveedor), new ObjectParameter[1]
    {
      idProveedor != null ? new ObjectParameter("IdProveedor", (object) idProveedor) : new ObjectParameter("IdProveedor", typeof (string))
    });

    public virtual ObjectResult<sp_CargarProveedores_Result> sp_CargarProveedores() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_CargarProveedores_Result>(nameof (sp_CargarProveedores), new ObjectParameter[0]);

    public virtual ObjectResult<sp_CargarProyecciones_Result> sp_CargarProyecciones(
      string id)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_CargarProyecciones_Result>(nameof (sp_CargarProyecciones), new ObjectParameter[1]
      {
        id != null ? new ObjectParameter(nameof (id), (object) id) : new ObjectParameter(nameof (id), typeof (string))
      });
    }

    public virtual ObjectResult<sp_CargarProyectosCajaChica_Result> sp_CargarProyectosCajaChica() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_CargarProyectosCajaChica_Result>(nameof (sp_CargarProyectosCajaChica), new ObjectParameter[0]);

    public virtual ObjectResult<sp_CargarProyectosFacturas_Result> sp_CargarProyectosFacturas(
      string idOrdenCompra)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_CargarProyectosFacturas_Result>(nameof (sp_CargarProyectosFacturas), new ObjectParameter[1]
      {
        idOrdenCompra != null ? new ObjectParameter("IdOrdenCompra", (object) idOrdenCompra) : new ObjectParameter("IdOrdenCompra", typeof (string))
      });
    }

    public virtual ObjectResult<sp_CargarProyectosMonitorMecanico_Result> sp_CargarProyectosMonitorMecanico() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_CargarProyectosMonitorMecanico_Result>(nameof (sp_CargarProyectosMonitorMecanico), new ObjectParameter[0]);

    public virtual ObjectResult<sp_CargarTotalSinOrden_Result> sp_CargarTotalSinOrden(
      int? opcion)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_CargarTotalSinOrden_Result>(nameof (sp_CargarTotalSinOrden), new ObjectParameter[1]
      {
        opcion.HasValue ? new ObjectParameter("Opcion", (object) opcion) : new ObjectParameter("Opcion", typeof (int))
      });
    }

    public virtual ObjectResult<sp_CargarUsuarios_Result> sp_CargarUsuarios() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_CargarUsuarios_Result>(nameof (sp_CargarUsuarios), new ObjectParameter[0]);

    public virtual ObjectResult<sp_CargarViaticosEnc_Result> sp_CargarViaticosEnc(
      string idViaticos)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_CargarViaticosEnc_Result>(nameof (sp_CargarViaticosEnc), new ObjectParameter[1]
      {
        idViaticos != null ? new ObjectParameter("IdViaticos", (object) idViaticos) : new ObjectParameter("IdViaticos", typeof (string))
      });
    }

    public virtual ObjectResult<sp_CargaUsuariosProyecto_Result> sp_CargaUsuariosProyecto(
      string idProyecto)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_CargaUsuariosProyecto_Result>(nameof (sp_CargaUsuariosProyecto), new ObjectParameter[1]
      {
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string))
      });
    }

    public virtual int sp_ChatMessageInsert(
      string idFrom,
      string from,
      string idTo,
      string to,
      string message)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_ChatMessageInsert), new ObjectParameter[5]
      {
        idFrom != null ? new ObjectParameter("IdFrom", (object) idFrom) : new ObjectParameter("IdFrom", typeof (string)),
        from != null ? new ObjectParameter("From", (object) from) : new ObjectParameter("From", typeof (string)),
        idTo != null ? new ObjectParameter("IdTo", (object) idTo) : new ObjectParameter("IdTo", typeof (string)),
        to != null ? new ObjectParameter("To", (object) to) : new ObjectParameter("To", typeof (string)),
        message != null ? new ObjectParameter("Message", (object) message) : new ObjectParameter("Message", typeof (string))
      });
    }

    public virtual ObjectResult<sp_DatosClientes_Result> sp_DatosClientes(
      string idCliente)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_DatosClientes_Result>(nameof (sp_DatosClientes), new ObjectParameter[1]
      {
        idCliente != null ? new ObjectParameter("IdCliente", (object) idCliente) : new ObjectParameter("IdCliente", typeof (string))
      });
    }

    public virtual int sp_DesactivaCliente(string idCliente, string idUsuario) => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_DesactivaCliente), new ObjectParameter[2]
    {
      idCliente != null ? new ObjectParameter("IdCliente", (object) idCliente) : new ObjectParameter("IdCliente", typeof (string)),
      idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string))
    });

    public virtual int sp_DesactivaMaterial(string idMaterial, string idUsuario) => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_DesactivaMaterial), new ObjectParameter[2]
    {
      idMaterial != null ? new ObjectParameter("IdMaterial", (object) idMaterial) : new ObjectParameter("IdMaterial", typeof (string)),
      idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string))
    });

    public virtual int sp_DesactivaProveedor(string idProveedor, string idUsuario) => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_DesactivaProveedor), new ObjectParameter[2]
    {
      idProveedor != null ? new ObjectParameter("IdProveedor", (object) idProveedor) : new ObjectParameter("IdProveedor", typeof (string)),
      idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string))
    });

    public virtual int sp_DesactivaProveedorMaterial(string idProveedorMaterial, string idUsuario) => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_DesactivaProveedorMaterial), new ObjectParameter[2]
    {
      idProveedorMaterial != null ? new ObjectParameter("IdProveedorMaterial", (object) idProveedorMaterial) : new ObjectParameter("IdProveedorMaterial", typeof (string)),
      idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string))
    });

    public virtual int sp_DesactivaProyecto(string idProyecto, string idUsuario) => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_DesactivaProyecto), new ObjectParameter[2]
    {
      idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string)),
      idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string))
    });

    public virtual int sp_DesactivaUsuario(string idUsuario, string idUsuarioQuien) => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_DesactivaUsuario), new ObjectParameter[2]
    {
      idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string)),
      idUsuarioQuien != null ? new ObjectParameter("IdUsuarioQuien", (object) idUsuarioQuien) : new ObjectParameter("IdUsuarioQuien", typeof (string))
    });

    public virtual int sp_EnviaCorreo(string idCotizacion, string idUsuario) => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_EnviaCorreo), new ObjectParameter[2]
    {
      idCotizacion != null ? new ObjectParameter("IdCotizacion", (object) idCotizacion) : new ObjectParameter("IdCotizacion", typeof (string)),
      idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string))
    });

    public virtual ObjectResult<sp_GeneraReporteOCInfo_Result> sp_GeneraReporteOCInfo(
      string idOrdenCompra)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_GeneraReporteOCInfo_Result>(nameof (sp_GeneraReporteOCInfo), new ObjectParameter[1]
      {
        idOrdenCompra != null ? new ObjectParameter("IdOrdenCompra", (object) idOrdenCompra) : new ObjectParameter("IdOrdenCompra", typeof (string))
      });
    }

    public virtual ObjectResult<sp_GeneraReporteOrdenCompraDet_Result> sp_GeneraReporteOrdenCompraDet(
      string idOrdenCompra)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_GeneraReporteOrdenCompraDet_Result>(nameof (sp_GeneraReporteOrdenCompraDet), new ObjectParameter[1]
      {
        idOrdenCompra != null ? new ObjectParameter("IdOrdenCompra", (object) idOrdenCompra) : new ObjectParameter("IdOrdenCompra", typeof (string))
      });
    }

    public virtual ObjectResult<sp_GeneraReporteOrdenCompraEnc_Result> sp_GeneraReporteOrdenCompraEnc(
      string idOrdenCompra)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_GeneraReporteOrdenCompraEnc_Result>(nameof (sp_GeneraReporteOrdenCompraEnc), new ObjectParameter[1]
      {
        idOrdenCompra != null ? new ObjectParameter("IdOrdenCompra", (object) idOrdenCompra) : new ObjectParameter("IdOrdenCompra", typeof (string))
      });
    }

    public virtual ObjectResult<sp_GeneraReporteRFQ_Result> sp_GeneraReporteRFQ(
      string idRfq)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_GeneraReporteRFQ_Result>(nameof (sp_GeneraReporteRFQ), new ObjectParameter[1]
      {
        idRfq != null ? new ObjectParameter("IdRfq", (object) idRfq) : new ObjectParameter("IdRfq", typeof (string))
      });
    }

    public virtual ObjectResult<sp_GeneraReporteRFQDet_Result> sp_GeneraReporteRFQDet(
      string idRfq)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_GeneraReporteRFQDet_Result>(nameof (sp_GeneraReporteRFQDet), new ObjectParameter[1]
      {
        idRfq != null ? new ObjectParameter("IdRfq", (object) idRfq) : new ObjectParameter("IdRfq", typeof (string))
      });
    }

    public virtual ObjectResult<sp_GeneraReporteValiant_Result> sp_GeneraReporteValiant(
      int? idEstacion)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_GeneraReporteValiant_Result>(nameof (sp_GeneraReporteValiant), new ObjectParameter[1]
      {
        idEstacion.HasValue ? new ObjectParameter("IdEstacion", (object) idEstacion) : new ObjectParameter("IdEstacion", typeof (int))
      });
    }

    public virtual ObjectResult<sp_GeneraReporteValiantImagen_Result> sp_GeneraReporteValiantImagen(
      int? idEstacion)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_GeneraReporteValiantImagen_Result>(nameof (sp_GeneraReporteValiantImagen), new ObjectParameter[1]
      {
        idEstacion.HasValue ? new ObjectParameter("IdEstacion", (object) idEstacion) : new ObjectParameter("IdEstacion", typeof (int))
      });
    }

    public virtual ObjectResult<sp_GetPermisos_Result> sp_GetPermisos(
      string idUsuario,
      int? option)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_GetPermisos_Result>(nameof (sp_GetPermisos), new ObjectParameter[2]
      {
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string)),
        option.HasValue ? new ObjectParameter("Option", (object) option) : new ObjectParameter("Option", typeof (int))
      });
    }

    public virtual ObjectResult<sp_GraficaPastelDetalle_Result> sp_GraficaPastelDetalle(
      string idProyecto,
      string nombre,
      Decimal? gastado)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_GraficaPastelDetalle_Result>(nameof (sp_GraficaPastelDetalle), new ObjectParameter[3]
      {
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string)),
        nombre != null ? new ObjectParameter("Nombre", (object) nombre) : new ObjectParameter("Nombre", typeof (string)),
        gastado.HasValue ? new ObjectParameter("Gastado", (object) gastado) : new ObjectParameter("Gastado", typeof (Decimal))
      });
    }

    public virtual ObjectResult<sp_GraficaPastelUtilidad_Result> sp_GraficaPastelUtilidad(
      string idProyecto)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_GraficaPastelUtilidad_Result>(nameof (sp_GraficaPastelUtilidad), new ObjectParameter[1]
      {
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string))
      });
    }

    public virtual ObjectResult<sp_GraficaTasks_Result> sp_GraficaTasks(
      string idProyecto)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_GraficaTasks_Result>(nameof (sp_GraficaTasks), new ObjectParameter[1]
      {
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string))
      });
    }

    public virtual ObjectResult<sp_GraficaTasksDetalle_Result> sp_GraficaTasksDetalle(
      string idProyecto,
      string nombre)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_GraficaTasksDetalle_Result>(nameof (sp_GraficaTasksDetalle), new ObjectParameter[2]
      {
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string)),
        nombre != null ? new ObjectParameter("Nombre", (object) nombre) : new ObjectParameter("Nombre", typeof (string))
      });
    }

    public virtual ObjectResult<sp_GraficaUtilidad_Result> sp_GraficaUtilidad(
      string idProyecto)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_GraficaUtilidad_Result>(nameof (sp_GraficaUtilidad), new ObjectParameter[1]
      {
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string))
      });
    }

    public virtual int sp_GuardarFacturaEmitida(
      string idFacturasEmitidas,
      string idProyecto,
      string noCotizacion,
      string noOrdenCompra,
      string programacionPago,
      Decimal? porPagar,
      string fechaPago,
      int? estatus,
      string idUsuario)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_GuardarFacturaEmitida), new ObjectParameter[9]
      {
        idFacturasEmitidas != null ? new ObjectParameter("IdFacturasEmitidas", (object) idFacturasEmitidas) : new ObjectParameter("IdFacturasEmitidas", typeof (string)),
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string)),
        noCotizacion != null ? new ObjectParameter("NoCotizacion", (object) noCotizacion) : new ObjectParameter("NoCotizacion", typeof (string)),
        noOrdenCompra != null ? new ObjectParameter("NoOrdenCompra", (object) noOrdenCompra) : new ObjectParameter("NoOrdenCompra", typeof (string)),
        programacionPago != null ? new ObjectParameter("ProgramacionPago", (object) programacionPago) : new ObjectParameter("ProgramacionPago", typeof (string)),
        porPagar.HasValue ? new ObjectParameter("PorPagar", (object) porPagar) : new ObjectParameter("PorPagar", typeof (Decimal)),
        fechaPago != null ? new ObjectParameter("FechaPago", (object) fechaPago) : new ObjectParameter("FechaPago", typeof (string)),
        estatus.HasValue ? new ObjectParameter("Estatus", (object) estatus) : new ObjectParameter("Estatus", typeof (int)),
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string))
      });
    }

    public virtual int sp_InsertaComentarioCotizacion(
      string idCotizacion,
      string comentario,
      string idUsuario)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_InsertaComentarioCotizacion), new ObjectParameter[3]
      {
        idCotizacion != null ? new ObjectParameter("IdCotizacion", (object) idCotizacion) : new ObjectParameter("IdCotizacion", typeof (string)),
        comentario != null ? new ObjectParameter("Comentario", (object) comentario) : new ObjectParameter("Comentario", typeof (string)),
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string))
      });
    }

    public virtual int sp_InsertaComentarioProyecto(
      string idProyecto,
      string comentario,
      string idUsuario)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_InsertaComentarioProyecto), new ObjectParameter[3]
      {
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string)),
        comentario != null ? new ObjectParameter("Comentario", (object) comentario) : new ObjectParameter("Comentario", typeof (string)),
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string))
      });
    }

    public virtual int sp_InsertaComentariosOrdenCompra(
      string idOrdenCompra,
      string comentario,
      string idUsuario)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_InsertaComentariosOrdenCompra), new ObjectParameter[3]
      {
        idOrdenCompra != null ? new ObjectParameter("IdOrdenCompra", (object) idOrdenCompra) : new ObjectParameter("IdOrdenCompra", typeof (string)),
        comentario != null ? new ObjectParameter("Comentario", (object) comentario) : new ObjectParameter("Comentario", typeof (string)),
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string))
      });
    }

    public virtual int sp_InsertaFallaReconocimientoVoz(string vin, string falla) => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_InsertaFallaReconocimientoVoz), new ObjectParameter[2]
    {
      vin != null ? new ObjectParameter("Vin", (object) vin) : new ObjectParameter("Vin", typeof (string)),
      falla != null ? new ObjectParameter("Falla", (object) falla) : new ObjectParameter("Falla", typeof (string))
    });

    public virtual int sp_InsertaImagenesInfoCenter(int? idEstacion, byte[] imagenReporte) => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_InsertaImagenesInfoCenter), new ObjectParameter[2]
    {
      idEstacion.HasValue ? new ObjectParameter("IdEstacion", (object) idEstacion) : new ObjectParameter("IdEstacion", typeof (int)),
      imagenReporte != null ? new ObjectParameter("ImagenReporte", (object) imagenReporte) : new ObjectParameter("ImagenReporte", typeof (byte[]))
    });

    public virtual int sp_InsertaNotaAclaratoria(string idCotizacion, string notaAclaratoria) => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_InsertaNotaAclaratoria), new ObjectParameter[2]
    {
      idCotizacion != null ? new ObjectParameter("IdCotizacion", (object) idCotizacion) : new ObjectParameter("IdCotizacion", typeof (string)),
      notaAclaratoria != null ? new ObjectParameter("NotaAclaratoria", (object) notaAclaratoria) : new ObjectParameter("NotaAclaratoria", typeof (string))
    });

    public virtual int sp_InsertaProveedorContacto(
      string idProveedor,
      string nombreContacto,
      string telefono,
      string email,
      string departamento)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_InsertaProveedorContacto), new ObjectParameter[5]
      {
        idProveedor != null ? new ObjectParameter("IdProveedor", (object) idProveedor) : new ObjectParameter("IdProveedor", typeof (string)),
        nombreContacto != null ? new ObjectParameter("NombreContacto", (object) nombreContacto) : new ObjectParameter("NombreContacto", typeof (string)),
        telefono != null ? new ObjectParameter("Telefono", (object) telefono) : new ObjectParameter("Telefono", typeof (string)),
        email != null ? new ObjectParameter("Email", (object) email) : new ObjectParameter("Email", typeof (string)),
        departamento != null ? new ObjectParameter("Departamento", (object) departamento) : new ObjectParameter("Departamento", typeof (string))
      });
    }

    public virtual ObjectResult<Decimal?> sp_InsertArchivoDiseno(
      string fileName,
      string fileExtension,
      string fileSize)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<Decimal?>(nameof (sp_InsertArchivoDiseno), new ObjectParameter[3]
      {
        fileName != null ? new ObjectParameter("FileName", (object) fileName) : new ObjectParameter("FileName", typeof (string)),
        fileExtension != null ? new ObjectParameter("FileExtension", (object) fileExtension) : new ObjectParameter("FileExtension", typeof (string)),
        fileSize != null ? new ObjectParameter("FileSize", (object) fileSize) : new ObjectParameter("FileSize", typeof (string))
      });
    }

    public virtual ObjectResult<Decimal?> sp_InsertArchivoMasterCam(
      string fileName,
      string fileExtension,
      string fileSize)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<Decimal?>(nameof (sp_InsertArchivoMasterCam), new ObjectParameter[3]
      {
        fileName != null ? new ObjectParameter("FileName", (object) fileName) : new ObjectParameter("FileName", typeof (string)),
        fileExtension != null ? new ObjectParameter("FileExtension", (object) fileExtension) : new ObjectParameter("FileExtension", typeof (string)),
        fileSize != null ? new ObjectParameter("FileSize", (object) fileSize) : new ObjectParameter("FileSize", typeof (string))
      });
    }

    public virtual ObjectResult<Guid?> sp_InsertCotizacion(
      string idCliente,
      string empresa,
      string direccion,
      string ciudad,
      string concepto,
      Decimal? costoCotizacion,
      string creoCotizacion,
      string idUsuario)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<Guid?>(nameof (sp_InsertCotizacion), new ObjectParameter[8]
      {
        idCliente != null ? new ObjectParameter("IdCliente", (object) idCliente) : new ObjectParameter("IdCliente", typeof (string)),
        empresa != null ? new ObjectParameter("Empresa", (object) empresa) : new ObjectParameter("Empresa", typeof (string)),
        direccion != null ? new ObjectParameter("Direccion", (object) direccion) : new ObjectParameter("Direccion", typeof (string)),
        ciudad != null ? new ObjectParameter("Ciudad", (object) ciudad) : new ObjectParameter("Ciudad", typeof (string)),
        concepto != null ? new ObjectParameter("Concepto", (object) concepto) : new ObjectParameter("Concepto", typeof (string)),
        costoCotizacion.HasValue ? new ObjectParameter("CostoCotizacion", (object) costoCotizacion) : new ObjectParameter("CostoCotizacion", typeof (Decimal)),
        creoCotizacion != null ? new ObjectParameter("CreoCotizacion", (object) creoCotizacion) : new ObjectParameter("CreoCotizacion", typeof (string)),
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string))
      });
    }

    public virtual ObjectResult<sp_InsertDeleteDocumentosProyecto_Result> sp_InsertDeleteDocumentosProyecto(
      string idDocumento,
      string idProyecto,
      string fileName,
      string file,
      int? opcion)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_InsertDeleteDocumentosProyecto_Result>(nameof (sp_InsertDeleteDocumentosProyecto), new ObjectParameter[5]
      {
        idDocumento != null ? new ObjectParameter("IdDocumento", (object) idDocumento) : new ObjectParameter("IdDocumento", typeof (string)),
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string)),
        fileName != null ? new ObjectParameter("FileName", (object) fileName) : new ObjectParameter("FileName", typeof (string)),
        file != null ? new ObjectParameter("File", (object) file) : new ObjectParameter("File", typeof (string)),
        opcion.HasValue ? new ObjectParameter("Opcion", (object) opcion) : new ObjectParameter("Opcion", typeof (int))
      });
    }

    public virtual int sp_InsertFacturasEmitidas(
      string folioFactura,
      DateTime? fechaFactura,
      string rfcReceptor,
      string nombreReceptor,
      Decimal? subTotal,
      Decimal? iva,
      Decimal? retencion,
      Decimal? total,
      string moneda,
      Decimal? tipoCambio,
      string idUsuario)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_InsertFacturasEmitidas), new ObjectParameter[11]
      {
        folioFactura != null ? new ObjectParameter("FolioFactura", (object) folioFactura) : new ObjectParameter("FolioFactura", typeof (string)),
        fechaFactura.HasValue ? new ObjectParameter("FechaFactura", (object) fechaFactura) : new ObjectParameter("FechaFactura", typeof (DateTime)),
        rfcReceptor != null ? new ObjectParameter("RfcReceptor", (object) rfcReceptor) : new ObjectParameter("RfcReceptor", typeof (string)),
        nombreReceptor != null ? new ObjectParameter("NombreReceptor", (object) nombreReceptor) : new ObjectParameter("NombreReceptor", typeof (string)),
        subTotal.HasValue ? new ObjectParameter("SubTotal", (object) subTotal) : new ObjectParameter("SubTotal", typeof (Decimal)),
        iva.HasValue ? new ObjectParameter("Iva", (object) iva) : new ObjectParameter("Iva", typeof (Decimal)),
        retencion.HasValue ? new ObjectParameter("Retencion", (object) retencion) : new ObjectParameter("Retencion", typeof (Decimal)),
        total.HasValue ? new ObjectParameter("Total", (object) total) : new ObjectParameter("Total", typeof (Decimal)),
        moneda != null ? new ObjectParameter("Moneda", (object) moneda) : new ObjectParameter("Moneda", typeof (string)),
        tipoCambio.HasValue ? new ObjectParameter("TipoCambio", (object) tipoCambio) : new ObjectParameter("TipoCambio", typeof (Decimal)),
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string))
      });
    }

    public virtual int sp_InsertFacturaXML(string nombreArchivo, string archivo) => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_InsertFacturaXML), new ObjectParameter[2]
    {
      nombreArchivo != null ? new ObjectParameter("NombreArchivo", (object) nombreArchivo) : new ObjectParameter("NombreArchivo", typeof (string)),
      archivo != null ? new ObjectParameter("Archivo", (object) archivo) : new ObjectParameter("Archivo", typeof (string))
    });

    public virtual int sp_InsertGasto(
      string idProyecto,
      string noFactura,
      string tipoGasto,
      string descripcion,
      Decimal? importe,
      Decimal? iva,
      Decimal? total,
      DateTime? fecha,
      string idUsuario)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_InsertGasto), new ObjectParameter[9]
      {
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string)),
        noFactura != null ? new ObjectParameter("NoFactura", (object) noFactura) : new ObjectParameter("NoFactura", typeof (string)),
        tipoGasto != null ? new ObjectParameter("TipoGasto", (object) tipoGasto) : new ObjectParameter("TipoGasto", typeof (string)),
        descripcion != null ? new ObjectParameter("Descripcion", (object) descripcion) : new ObjectParameter("Descripcion", typeof (string)),
        importe.HasValue ? new ObjectParameter("Importe", (object) importe) : new ObjectParameter("Importe", typeof (Decimal)),
        iva.HasValue ? new ObjectParameter("Iva", (object) iva) : new ObjectParameter("Iva", typeof (Decimal)),
        total.HasValue ? new ObjectParameter("Total", (object) total) : new ObjectParameter("Total", typeof (Decimal)),
        fecha.HasValue ? new ObjectParameter("Fecha", (object) fecha) : new ObjectParameter("Fecha", typeof (DateTime)),
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string))
      });
    }

    public virtual int sp_InsertLocalizacion(string iD, Decimal? latitud, Decimal? longitud) => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_InsertLocalizacion), new ObjectParameter[3]
    {
      iD != null ? new ObjectParameter("ID", (object) iD) : new ObjectParameter("ID", typeof (string)),
      latitud.HasValue ? new ObjectParameter("Latitud", (object) latitud) : new ObjectParameter("Latitud", typeof (Decimal)),
      longitud.HasValue ? new ObjectParameter("Longitud", (object) longitud) : new ObjectParameter("Longitud", typeof (Decimal))
    });

    public virtual int sp_InsertMaterialImagen(
      string idMaterial,
      string imagen,
      string fileName,
      string fileExtension,
      string fileSize,
      string fileContentType,
      string idUsuario)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_InsertMaterialImagen), new ObjectParameter[7]
      {
        idMaterial != null ? new ObjectParameter("IdMaterial", (object) idMaterial) : new ObjectParameter("IdMaterial", typeof (string)),
        imagen != null ? new ObjectParameter("Imagen", (object) imagen) : new ObjectParameter("Imagen", typeof (string)),
        fileName != null ? new ObjectParameter("FileName", (object) fileName) : new ObjectParameter("FileName", typeof (string)),
        fileExtension != null ? new ObjectParameter("FileExtension", (object) fileExtension) : new ObjectParameter("FileExtension", typeof (string)),
        fileSize != null ? new ObjectParameter("FileSize", (object) fileSize) : new ObjectParameter("FileSize", typeof (string)),
        fileContentType != null ? new ObjectParameter("FileContentType", (object) fileContentType) : new ObjectParameter("FileContentType", typeof (string)),
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string))
      });
    }

    public virtual ObjectResult<sp_InsertOrdenCompra_Result> sp_InsertOrdenCompra(
      string folio,
      string idProveedor,
      string referenciaCot,
      string idProyecto,
      string idUsuario,
      Decimal? subTotal,
      Decimal? iva,
      int? estatus,
      string idMoneda,
      string condicionPago,
      string comentarios,
      string idUsuarioModifica,
      Decimal? descuento,
      string idUsuarioAprobo,
      string tipoOC,
      string sucursal,
      string requisicion)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_InsertOrdenCompra_Result>(nameof (sp_InsertOrdenCompra), new ObjectParameter[17]
      {
        folio != null ? new ObjectParameter("Folio", (object) folio) : new ObjectParameter("Folio", typeof (string)),
        idProveedor != null ? new ObjectParameter("IdProveedor", (object) idProveedor) : new ObjectParameter("IdProveedor", typeof (string)),
        referenciaCot != null ? new ObjectParameter("ReferenciaCot", (object) referenciaCot) : new ObjectParameter("ReferenciaCot", typeof (string)),
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string)),
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string)),
        subTotal.HasValue ? new ObjectParameter("SubTotal", (object) subTotal) : new ObjectParameter("SubTotal", typeof (Decimal)),
        iva.HasValue ? new ObjectParameter("Iva", (object) iva) : new ObjectParameter("Iva", typeof (Decimal)),
        estatus.HasValue ? new ObjectParameter("Estatus", (object) estatus) : new ObjectParameter("Estatus", typeof (int)),
        idMoneda != null ? new ObjectParameter("IdMoneda", (object) idMoneda) : new ObjectParameter("IdMoneda", typeof (string)),
        condicionPago != null ? new ObjectParameter("CondicionPago", (object) condicionPago) : new ObjectParameter("CondicionPago", typeof (string)),
        comentarios != null ? new ObjectParameter("Comentarios", (object) comentarios) : new ObjectParameter("Comentarios", typeof (string)),
        idUsuarioModifica != null ? new ObjectParameter("IdUsuarioModifica", (object) idUsuarioModifica) : new ObjectParameter("IdUsuarioModifica", typeof (string)),
        descuento.HasValue ? new ObjectParameter("Descuento", (object) descuento) : new ObjectParameter("Descuento", typeof (Decimal)),
        idUsuarioAprobo != null ? new ObjectParameter("IdUsuarioAprobo", (object) idUsuarioAprobo) : new ObjectParameter("IdUsuarioAprobo", typeof (string)),
        tipoOC != null ? new ObjectParameter("TipoOC", (object) tipoOC) : new ObjectParameter("TipoOC", typeof (string)),
        sucursal != null ? new ObjectParameter("Sucursal", (object) sucursal) : new ObjectParameter("Sucursal", typeof (string)),
        requisicion != null ? new ObjectParameter("Requisicion", (object) requisicion) : new ObjectParameter("Requisicion", typeof (string))
      });
    }

    public virtual int sp_InsertOrdenCompraDetalle(
      string idOrdenCompra,
      int? item,
      string codigo,
      string descripcion,
      string comentarios,
      Decimal? cantidad,
      string unidad,
      Decimal? precio,
      Decimal? importe,
      string tiempoEntrega,
      Decimal? cantidadRecibida,
      int? opcion)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_InsertOrdenCompraDetalle), new ObjectParameter[12]
      {
        idOrdenCompra != null ? new ObjectParameter("IdOrdenCompra", (object) idOrdenCompra) : new ObjectParameter("IdOrdenCompra", typeof (string)),
        item.HasValue ? new ObjectParameter("Item", (object) item) : new ObjectParameter("Item", typeof (int)),
        codigo != null ? new ObjectParameter("Codigo", (object) codigo) : new ObjectParameter("Codigo", typeof (string)),
        descripcion != null ? new ObjectParameter("Descripcion", (object) descripcion) : new ObjectParameter("Descripcion", typeof (string)),
        comentarios != null ? new ObjectParameter("Comentarios", (object) comentarios) : new ObjectParameter("Comentarios", typeof (string)),
        cantidad.HasValue ? new ObjectParameter("Cantidad", (object) cantidad) : new ObjectParameter("Cantidad", typeof (Decimal)),
        unidad != null ? new ObjectParameter("Unidad", (object) unidad) : new ObjectParameter("Unidad", typeof (string)),
        precio.HasValue ? new ObjectParameter("Precio", (object) precio) : new ObjectParameter("Precio", typeof (Decimal)),
        importe.HasValue ? new ObjectParameter("Importe", (object) importe) : new ObjectParameter("Importe", typeof (Decimal)),
        tiempoEntrega != null ? new ObjectParameter("TiempoEntrega", (object) tiempoEntrega) : new ObjectParameter("TiempoEntrega", typeof (string)),
        cantidadRecibida.HasValue ? new ObjectParameter("CantidadRecibida", (object) cantidadRecibida) : new ObjectParameter("CantidadRecibida", typeof (Decimal)),
        opcion.HasValue ? new ObjectParameter("Opcion", (object) opcion) : new ObjectParameter("Opcion", typeof (int))
      });
    }

    public virtual int sp_InsertOrdenTrabajo(
      string idProyecto,
      string fechaPruebas,
      string fechaEntrega,
      string idUsuarioCoordinador)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_InsertOrdenTrabajo), new ObjectParameter[4]
      {
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string)),
        fechaPruebas != null ? new ObjectParameter("FechaPruebas", (object) fechaPruebas) : new ObjectParameter("FechaPruebas", typeof (string)),
        fechaEntrega != null ? new ObjectParameter("FechaEntrega", (object) fechaEntrega) : new ObjectParameter("FechaEntrega", typeof (string)),
        idUsuarioCoordinador != null ? new ObjectParameter("IdUsuarioCoordinador", (object) idUsuarioCoordinador) : new ObjectParameter("IdUsuarioCoordinador", typeof (string))
      });
    }

    public virtual int sp_InsertProveedorMaterialPrecio(
      string idProveedor,
      string idMaterial,
      string unidadMedida,
      Decimal? precio,
      string idMoneda,
      string idProveedorMaterial,
      string idUsuario)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_InsertProveedorMaterialPrecio), new ObjectParameter[7]
      {
        idProveedor != null ? new ObjectParameter("IdProveedor", (object) idProveedor) : new ObjectParameter("IdProveedor", typeof (string)),
        idMaterial != null ? new ObjectParameter("IdMaterial", (object) idMaterial) : new ObjectParameter("IdMaterial", typeof (string)),
        unidadMedida != null ? new ObjectParameter("UnidadMedida", (object) unidadMedida) : new ObjectParameter("UnidadMedida", typeof (string)),
        precio.HasValue ? new ObjectParameter("Precio", (object) precio) : new ObjectParameter("Precio", typeof (Decimal)),
        idMoneda != null ? new ObjectParameter("IdMoneda", (object) idMoneda) : new ObjectParameter("IdMoneda", typeof (string)),
        idProveedorMaterial != null ? new ObjectParameter("IdProveedorMaterial", (object) idProveedorMaterial) : new ObjectParameter("IdProveedorMaterial", typeof (string)),
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string))
      });
    }

    public virtual int sp_InsertProyectoRequerimiento(
      string idProyecto,
      string requerimiento,
      string idUsuario)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_InsertProyectoRequerimiento), new ObjectParameter[3]
      {
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string)),
        requerimiento != null ? new ObjectParameter("Requerimiento", (object) requerimiento) : new ObjectParameter("Requerimiento", typeof (string)),
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string))
      });
    }

    public virtual int sp_InsertProyectoTask(
      string idProyecto,
      string task,
      string idUsuario,
      DateTime? fechaInicio,
      DateTime? fechaFin,
      string comentarios,
      string idUsuarioAlta)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_InsertProyectoTask), new ObjectParameter[7]
      {
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string)),
        task != null ? new ObjectParameter("Task", (object) task) : new ObjectParameter("Task", typeof (string)),
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string)),
        fechaInicio.HasValue ? new ObjectParameter("FechaInicio", (object) fechaInicio) : new ObjectParameter("FechaInicio", typeof (DateTime)),
        fechaFin.HasValue ? new ObjectParameter("FechaFin", (object) fechaFin) : new ObjectParameter("FechaFin", typeof (DateTime)),
        comentarios != null ? new ObjectParameter("Comentarios", (object) comentarios) : new ObjectParameter("Comentarios", typeof (string)),
        idUsuarioAlta != null ? new ObjectParameter("IdUsuarioAlta", (object) idUsuarioAlta) : new ObjectParameter("IdUsuarioAlta", typeof (string))
      });
    }

    public virtual int sp_InsertReqDet(
      string idReqEnc,
      int? item,
      string descripcion,
      int? cantidad,
      string unidad,
      string numParte,
      string marca)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_InsertReqDet), new ObjectParameter[7]
      {
        idReqEnc != null ? new ObjectParameter("IdReqEnc", (object) idReqEnc) : new ObjectParameter("IdReqEnc", typeof (string)),
        item.HasValue ? new ObjectParameter("Item", (object) item) : new ObjectParameter("Item", typeof (int)),
        descripcion != null ? new ObjectParameter("Descripcion", (object) descripcion) : new ObjectParameter("Descripcion", typeof (string)),
        cantidad.HasValue ? new ObjectParameter("Cantidad", (object) cantidad) : new ObjectParameter("Cantidad", typeof (int)),
        unidad != null ? new ObjectParameter("Unidad", (object) unidad) : new ObjectParameter("Unidad", typeof (string)),
        numParte != null ? new ObjectParameter("NumParte", (object) numParte) : new ObjectParameter("NumParte", typeof (string)),
        marca != null ? new ObjectParameter("Marca", (object) marca) : new ObjectParameter("Marca", typeof (string))
      });
    }

    public virtual ObjectResult<Guid?> sp_InsertReqEnc(
      string idProyecto,
      int? estatus,
      int? solicitarCotizacion,
      string observaciones,
      string idUsuarioElaboro)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<Guid?>(nameof (sp_InsertReqEnc), new ObjectParameter[5]
      {
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string)),
        estatus.HasValue ? new ObjectParameter("Estatus", (object) estatus) : new ObjectParameter("Estatus", typeof (int)),
        solicitarCotizacion.HasValue ? new ObjectParameter("SolicitarCotizacion", (object) solicitarCotizacion) : new ObjectParameter("SolicitarCotizacion", typeof (int)),
        observaciones != null ? new ObjectParameter("Observaciones", (object) observaciones) : new ObjectParameter("Observaciones", typeof (string)),
        idUsuarioElaboro != null ? new ObjectParameter("IdUsuarioElaboro", (object) idUsuarioElaboro) : new ObjectParameter("IdUsuarioElaboro", typeof (string))
      });
    }

    public virtual int sp_InsertRFQ(
      string idRfq,
      string folio,
      string round,
      DateTime? fecha,
      DateTime? fechaVencimiento,
      string idCliente,
      string folioRQ,
      string idComprador,
      int? estatus,
      string idUsuario)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_InsertRFQ), new ObjectParameter[10]
      {
        idRfq != null ? new ObjectParameter("IdRfq", (object) idRfq) : new ObjectParameter("IdRfq", typeof (string)),
        folio != null ? new ObjectParameter("Folio", (object) folio) : new ObjectParameter("Folio", typeof (string)),
        round != null ? new ObjectParameter("Round", (object) round) : new ObjectParameter("Round", typeof (string)),
        fecha.HasValue ? new ObjectParameter("Fecha", (object) fecha) : new ObjectParameter("Fecha", typeof (DateTime)),
        fechaVencimiento.HasValue ? new ObjectParameter("FechaVencimiento", (object) fechaVencimiento) : new ObjectParameter("FechaVencimiento", typeof (DateTime)),
        idCliente != null ? new ObjectParameter("IdCliente", (object) idCliente) : new ObjectParameter("IdCliente", typeof (string)),
        folioRQ != null ? new ObjectParameter("FolioRQ", (object) folioRQ) : new ObjectParameter("FolioRQ", typeof (string)),
        idComprador != null ? new ObjectParameter("IdComprador", (object) idComprador) : new ObjectParameter("IdComprador", typeof (string)),
        estatus.HasValue ? new ObjectParameter("Estatus", (object) estatus) : new ObjectParameter("Estatus", typeof (int)),
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string))
      });
    }

    public virtual int sp_InsertSeguimientoRFQ(string idRfq, string seguimiento, string idUsuario) => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_InsertSeguimientoRFQ), new ObjectParameter[3]
    {
      idRfq != null ? new ObjectParameter("IdRfq", (object) idRfq) : new ObjectParameter("IdRfq", typeof (string)),
      seguimiento != null ? new ObjectParameter("Seguimiento", (object) seguimiento) : new ObjectParameter("Seguimiento", typeof (string)),
      idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string))
    });

    public virtual int sp_InsertTaskComentarios(string idTask, string idUsuario, string comentario) => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_InsertTaskComentarios), new ObjectParameter[3]
    {
      idTask != null ? new ObjectParameter("IdTask", (object) idTask) : new ObjectParameter("IdTask", typeof (string)),
      idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string)),
      comentario != null ? new ObjectParameter("Comentario", (object) comentario) : new ObjectParameter("Comentario", typeof (string))
    });

    public virtual int sp_InsertTaskImagen(
      string idTask,
      string imagen,
      string descripcion,
      string fileName,
      string fileExtension,
      string fileSize,
      string fileContentType,
      string idUsuario)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_InsertTaskImagen), new ObjectParameter[8]
      {
        idTask != null ? new ObjectParameter("IdTask", (object) idTask) : new ObjectParameter("IdTask", typeof (string)),
        imagen != null ? new ObjectParameter("Imagen", (object) imagen) : new ObjectParameter("Imagen", typeof (string)),
        descripcion != null ? new ObjectParameter("Descripcion", (object) descripcion) : new ObjectParameter("Descripcion", typeof (string)),
        fileName != null ? new ObjectParameter("FileName", (object) fileName) : new ObjectParameter("FileName", typeof (string)),
        fileExtension != null ? new ObjectParameter("FileExtension", (object) fileExtension) : new ObjectParameter("FileExtension", typeof (string)),
        fileSize != null ? new ObjectParameter("FileSize", (object) fileSize) : new ObjectParameter("FileSize", typeof (string)),
        fileContentType != null ? new ObjectParameter("FileContentType", (object) fileContentType) : new ObjectParameter("FileContentType", typeof (string)),
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string))
      });
    }

    public virtual int sp_InsertTimmingsExcel(
      string nombreProyecto,
      string actividad,
      string tarea,
      string fechaIni,
      string fechaFin,
      string asignado,
      string diasTrans,
      string avance,
      int? fila)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_InsertTimmingsExcel), new ObjectParameter[9]
      {
        nombreProyecto != null ? new ObjectParameter("NombreProyecto", (object) nombreProyecto) : new ObjectParameter("NombreProyecto", typeof (string)),
        actividad != null ? new ObjectParameter("Actividad", (object) actividad) : new ObjectParameter("Actividad", typeof (string)),
        tarea != null ? new ObjectParameter("Tarea", (object) tarea) : new ObjectParameter("Tarea", typeof (string)),
        fechaIni != null ? new ObjectParameter("FechaIni", (object) fechaIni) : new ObjectParameter("FechaIni", typeof (string)),
        fechaFin != null ? new ObjectParameter("FechaFin", (object) fechaFin) : new ObjectParameter("FechaFin", typeof (string)),
        asignado != null ? new ObjectParameter("Asignado", (object) asignado) : new ObjectParameter("Asignado", typeof (string)),
        diasTrans != null ? new ObjectParameter("DiasTrans", (object) diasTrans) : new ObjectParameter("DiasTrans", typeof (string)),
        avance != null ? new ObjectParameter("Avance", (object) avance) : new ObjectParameter("Avance", typeof (string)),
        fila.HasValue ? new ObjectParameter("Fila", (object) fila) : new ObjectParameter("Fila", typeof (int))
      });
    }

    public virtual int sp_InsertUpdateClientes(
      string idCliente,
      string razonSocial,
      string contacto,
      string email,
      string departamento,
      string telefonoEmpresa,
      string celular,
      string usuarioCliente,
      string contrasenaCliente,
      string mapaCoordenadas,
      string logotipo,
      string direccion,
      string idUsuario,
      int? activo)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_InsertUpdateClientes), new ObjectParameter[14]
      {
        idCliente != null ? new ObjectParameter("IdCliente", (object) idCliente) : new ObjectParameter("IdCliente", typeof (string)),
        razonSocial != null ? new ObjectParameter("RazonSocial", (object) razonSocial) : new ObjectParameter("RazonSocial", typeof (string)),
        contacto != null ? new ObjectParameter("Contacto", (object) contacto) : new ObjectParameter("Contacto", typeof (string)),
        email != null ? new ObjectParameter("Email", (object) email) : new ObjectParameter("Email", typeof (string)),
        departamento != null ? new ObjectParameter("Departamento", (object) departamento) : new ObjectParameter("Departamento", typeof (string)),
        telefonoEmpresa != null ? new ObjectParameter("TelefonoEmpresa", (object) telefonoEmpresa) : new ObjectParameter("TelefonoEmpresa", typeof (string)),
        celular != null ? new ObjectParameter("Celular", (object) celular) : new ObjectParameter("Celular", typeof (string)),
        usuarioCliente != null ? new ObjectParameter("UsuarioCliente", (object) usuarioCliente) : new ObjectParameter("UsuarioCliente", typeof (string)),
        contrasenaCliente != null ? new ObjectParameter("ContrasenaCliente", (object) contrasenaCliente) : new ObjectParameter("ContrasenaCliente", typeof (string)),
        mapaCoordenadas != null ? new ObjectParameter("MapaCoordenadas", (object) mapaCoordenadas) : new ObjectParameter("MapaCoordenadas", typeof (string)),
        logotipo != null ? new ObjectParameter("Logotipo", (object) logotipo) : new ObjectParameter("Logotipo", typeof (string)),
        direccion != null ? new ObjectParameter("Direccion", (object) direccion) : new ObjectParameter("Direccion", typeof (string)),
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string)),
        activo.HasValue ? new ObjectParameter("Activo", (object) activo) : new ObjectParameter("Activo", typeof (int))
      });
    }

    public virtual int sp_InsertUpdateEventoCalendario(
      string idCalendario,
      string titulo,
      string descripcion,
      DateTime? fechaInicio,
      DateTime? fechaFinal,
      bool? todoDia,
      string idUsuario)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_InsertUpdateEventoCalendario), new ObjectParameter[7]
      {
        idCalendario != null ? new ObjectParameter("IdCalendario", (object) idCalendario) : new ObjectParameter("IdCalendario", typeof (string)),
        titulo != null ? new ObjectParameter("Titulo", (object) titulo) : new ObjectParameter("Titulo", typeof (string)),
        descripcion != null ? new ObjectParameter("Descripcion", (object) descripcion) : new ObjectParameter("Descripcion", typeof (string)),
        fechaInicio.HasValue ? new ObjectParameter("FechaInicio", (object) fechaInicio) : new ObjectParameter("FechaInicio", typeof (DateTime)),
        fechaFinal.HasValue ? new ObjectParameter("FechaFinal", (object) fechaFinal) : new ObjectParameter("FechaFinal", typeof (DateTime)),
        todoDia.HasValue ? new ObjectParameter("TodoDia", (object) todoDia) : new ObjectParameter("TodoDia", typeof (bool)),
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string))
      });
    }

    public virtual int sp_InsertUpdateHabilidad(
      string idHabilidad,
      string idUsuario,
      string habilidad,
      Decimal? porcentaje,
      string comentarios)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_InsertUpdateHabilidad), new ObjectParameter[5]
      {
        idHabilidad != null ? new ObjectParameter("IdHabilidad", (object) idHabilidad) : new ObjectParameter("IdHabilidad", typeof (string)),
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string)),
        habilidad != null ? new ObjectParameter("Habilidad", (object) habilidad) : new ObjectParameter("Habilidad", typeof (string)),
        porcentaje.HasValue ? new ObjectParameter("Porcentaje", (object) porcentaje) : new ObjectParameter("Porcentaje", typeof (Decimal)),
        comentarios != null ? new ObjectParameter("Comentarios", (object) comentarios) : new ObjectParameter("Comentarios", typeof (string))
      });
    }

    public virtual int sp_InsertUpdateHorasHombre(
      string idProyecto,
      string idHorasHombre,
      string idUsuario,
      int? lunes,
      int? martes,
      int? miercoles,
      int? jueves,
      int? viernes,
      int? sabado,
      int? domingo,
      int? activo)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_InsertUpdateHorasHombre), new ObjectParameter[11]
      {
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string)),
        idHorasHombre != null ? new ObjectParameter("IdHorasHombre", (object) idHorasHombre) : new ObjectParameter("IdHorasHombre", typeof (string)),
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string)),
        lunes.HasValue ? new ObjectParameter("Lunes", (object) lunes) : new ObjectParameter("Lunes", typeof (int)),
        martes.HasValue ? new ObjectParameter("Martes", (object) martes) : new ObjectParameter("Martes", typeof (int)),
        miercoles.HasValue ? new ObjectParameter("Miercoles", (object) miercoles) : new ObjectParameter("Miercoles", typeof (int)),
        jueves.HasValue ? new ObjectParameter("Jueves", (object) jueves) : new ObjectParameter("Jueves", typeof (int)),
        viernes.HasValue ? new ObjectParameter("Viernes", (object) viernes) : new ObjectParameter("Viernes", typeof (int)),
        sabado.HasValue ? new ObjectParameter("Sabado", (object) sabado) : new ObjectParameter("Sabado", typeof (int)),
        domingo.HasValue ? new ObjectParameter("Domingo", (object) domingo) : new ObjectParameter("Domingo", typeof (int)),
        activo.HasValue ? new ObjectParameter("Activo", (object) activo) : new ObjectParameter("Activo", typeof (int))
      });
    }

    public virtual int sp_InsertUpdateListaPendientes(
      string idListaPendientes,
      string idUsuario,
      string pendiente,
      int? completado)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_InsertUpdateListaPendientes), new ObjectParameter[4]
      {
        idListaPendientes != null ? new ObjectParameter("IdListaPendientes", (object) idListaPendientes) : new ObjectParameter("IdListaPendientes", typeof (string)),
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string)),
        pendiente != null ? new ObjectParameter("Pendiente", (object) pendiente) : new ObjectParameter("Pendiente", typeof (string)),
        completado.HasValue ? new ObjectParameter("Completado", (object) completado) : new ObjectParameter("Completado", typeof (int))
      });
    }

    public virtual int sp_InsertUpdateMaquinado(
      string idMaquina,
      string idProyecto,
      string nombreProyecto,
      string noParte,
      DateTime? fechaOC,
      DateTime? fechaEntrega,
      string idDiseno,
      string idMasterCam,
      int? estatus,
      string idEncargadoProyecto,
      string idDisenador,
      string idQuienHizo,
      string observaciones,
      int? horasMaquina,
      int? cantidadPzas)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_InsertUpdateMaquinado), new ObjectParameter[15]
      {
        idMaquina != null ? new ObjectParameter("IdMaquina", (object) idMaquina) : new ObjectParameter("IdMaquina", typeof (string)),
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string)),
        nombreProyecto != null ? new ObjectParameter("NombreProyecto", (object) nombreProyecto) : new ObjectParameter("NombreProyecto", typeof (string)),
        noParte != null ? new ObjectParameter("NoParte", (object) noParte) : new ObjectParameter("NoParte", typeof (string)),
        fechaOC.HasValue ? new ObjectParameter("FechaOC", (object) fechaOC) : new ObjectParameter("FechaOC", typeof (DateTime)),
        fechaEntrega.HasValue ? new ObjectParameter("FechaEntrega", (object) fechaEntrega) : new ObjectParameter("FechaEntrega", typeof (DateTime)),
        idDiseno != null ? new ObjectParameter("IdDiseno", (object) idDiseno) : new ObjectParameter("IdDiseno", typeof (string)),
        idMasterCam != null ? new ObjectParameter("IdMasterCam", (object) idMasterCam) : new ObjectParameter("IdMasterCam", typeof (string)),
        estatus.HasValue ? new ObjectParameter("Estatus", (object) estatus) : new ObjectParameter("Estatus", typeof (int)),
        idEncargadoProyecto != null ? new ObjectParameter("IdEncargadoProyecto", (object) idEncargadoProyecto) : new ObjectParameter("IdEncargadoProyecto", typeof (string)),
        idDisenador != null ? new ObjectParameter("IdDisenador", (object) idDisenador) : new ObjectParameter("IdDisenador", typeof (string)),
        idQuienHizo != null ? new ObjectParameter("IdQuienHizo", (object) idQuienHizo) : new ObjectParameter("IdQuienHizo", typeof (string)),
        observaciones != null ? new ObjectParameter("Observaciones", (object) observaciones) : new ObjectParameter("Observaciones", typeof (string)),
        horasMaquina.HasValue ? new ObjectParameter("HorasMaquina", (object) horasMaquina) : new ObjectParameter("HorasMaquina", typeof (int)),
        cantidadPzas.HasValue ? new ObjectParameter("CantidadPzas", (object) cantidadPzas) : new ObjectParameter("CantidadPzas", typeof (int))
      });
    }

    public virtual ObjectResult<string> sp_InsertUpdateMateriales(
      string idMaterial,
      string codigo,
      string descripcion,
      string idCategoria,
      string buscador,
      int? activo,
      string idUsuario)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<string>(nameof (sp_InsertUpdateMateriales), new ObjectParameter[7]
      {
        idMaterial != null ? new ObjectParameter("IdMaterial", (object) idMaterial) : new ObjectParameter("IdMaterial", typeof (string)),
        codigo != null ? new ObjectParameter("Codigo", (object) codigo) : new ObjectParameter("Codigo", typeof (string)),
        descripcion != null ? new ObjectParameter("Descripcion", (object) descripcion) : new ObjectParameter("Descripcion", typeof (string)),
        idCategoria != null ? new ObjectParameter("IdCategoria", (object) idCategoria) : new ObjectParameter("IdCategoria", typeof (string)),
        buscador != null ? new ObjectParameter("Buscador", (object) buscador) : new ObjectParameter("Buscador", typeof (string)),
        activo.HasValue ? new ObjectParameter("Activo", (object) activo) : new ObjectParameter("Activo", typeof (int)),
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string))
      });
    }

    public virtual int sp_InsertUpdatePermisos(string idUsuario, int? idMenu, int? visible) => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_InsertUpdatePermisos), new ObjectParameter[3]
    {
      idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string)),
      idMenu.HasValue ? new ObjectParameter("IdMenu", (object) idMenu) : new ObjectParameter("IdMenu", typeof (int)),
      visible.HasValue ? new ObjectParameter("Visible", (object) visible) : new ObjectParameter("Visible", typeof (int))
    });

    public virtual ObjectResult<string> sp_InsertUpdateProveedores(
      string idProveedor,
      string proveedor,
      string telefonoEmpresa,
      string giro,
      string nombreComercial,
      string comentarios,
      string logotipo,
      string idUsuario,
      int? activo)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<string>(nameof (sp_InsertUpdateProveedores), new ObjectParameter[9]
      {
        idProveedor != null ? new ObjectParameter("IdProveedor", (object) idProveedor) : new ObjectParameter("IdProveedor", typeof (string)),
        proveedor != null ? new ObjectParameter("Proveedor", (object) proveedor) : new ObjectParameter("Proveedor", typeof (string)),
        telefonoEmpresa != null ? new ObjectParameter("TelefonoEmpresa", (object) telefonoEmpresa) : new ObjectParameter("TelefonoEmpresa", typeof (string)),
        giro != null ? new ObjectParameter("Giro", (object) giro) : new ObjectParameter("Giro", typeof (string)),
        nombreComercial != null ? new ObjectParameter("NombreComercial", (object) nombreComercial) : new ObjectParameter("NombreComercial", typeof (string)),
        comentarios != null ? new ObjectParameter("Comentarios", (object) comentarios) : new ObjectParameter("Comentarios", typeof (string)),
        logotipo != null ? new ObjectParameter("Logotipo", (object) logotipo) : new ObjectParameter("Logotipo", typeof (string)),
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string)),
        activo.HasValue ? new ObjectParameter("Activo", (object) activo) : new ObjectParameter("Activo", typeof (int))
      });
    }

    public virtual int sp_InsertUpdateProyectos(
      string idProyecto,
      string nombreProyecto,
      string descripcion,
      string idLider,
      string idCliente,
      int? estatus,
      DateTime? fechaInicio,
      DateTime? fechaFin,
      string idUsuario,
      string idCotizacion,
      Decimal? costoCotizacion)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_InsertUpdateProyectos), new ObjectParameter[11]
      {
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string)),
        nombreProyecto != null ? new ObjectParameter("NombreProyecto", (object) nombreProyecto) : new ObjectParameter("NombreProyecto", typeof (string)),
        descripcion != null ? new ObjectParameter("Descripcion", (object) descripcion) : new ObjectParameter("Descripcion", typeof (string)),
        idLider != null ? new ObjectParameter("IdLider", (object) idLider) : new ObjectParameter("IdLider", typeof (string)),
        idCliente != null ? new ObjectParameter("IdCliente", (object) idCliente) : new ObjectParameter("IdCliente", typeof (string)),
        estatus.HasValue ? new ObjectParameter("Estatus", (object) estatus) : new ObjectParameter("Estatus", typeof (int)),
        fechaInicio.HasValue ? new ObjectParameter("FechaInicio", (object) fechaInicio) : new ObjectParameter("FechaInicio", typeof (DateTime)),
        fechaFin.HasValue ? new ObjectParameter("FechaFin", (object) fechaFin) : new ObjectParameter("FechaFin", typeof (DateTime)),
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string)),
        idCotizacion != null ? new ObjectParameter("IdCotizacion", (object) idCotizacion) : new ObjectParameter("IdCotizacion", typeof (string)),
        costoCotizacion.HasValue ? new ObjectParameter("CostoCotizacion", (object) costoCotizacion) : new ObjectParameter("CostoCotizacion", typeof (Decimal))
      });
    }

    public virtual int sp_InsertUpdateRFQVentas(
      string idRFQ,
      string folioRfq,
      string descripcion,
      string idUsuarioVendedor,
      string idUsuarioCoordinador,
      string empresa,
      string contacto,
      DateTime? fechaRFQ,
      DateTime? fechaEntrega,
      int? enviado,
      int? estatus,
      string seguimiento,
      string idUsuario)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_InsertUpdateRFQVentas), new ObjectParameter[13]
      {
        idRFQ != null ? new ObjectParameter("IdRFQ", (object) idRFQ) : new ObjectParameter("IdRFQ", typeof (string)),
        folioRfq != null ? new ObjectParameter("FolioRfq", (object) folioRfq) : new ObjectParameter("FolioRfq", typeof (string)),
        descripcion != null ? new ObjectParameter("Descripcion", (object) descripcion) : new ObjectParameter("Descripcion", typeof (string)),
        idUsuarioVendedor != null ? new ObjectParameter("IdUsuarioVendedor", (object) idUsuarioVendedor) : new ObjectParameter("IdUsuarioVendedor", typeof (string)),
        idUsuarioCoordinador != null ? new ObjectParameter("IdUsuarioCoordinador", (object) idUsuarioCoordinador) : new ObjectParameter("IdUsuarioCoordinador", typeof (string)),
        empresa != null ? new ObjectParameter("Empresa", (object) empresa) : new ObjectParameter("Empresa", typeof (string)),
        contacto != null ? new ObjectParameter("Contacto", (object) contacto) : new ObjectParameter("Contacto", typeof (string)),
        fechaRFQ.HasValue ? new ObjectParameter("FechaRFQ", (object) fechaRFQ) : new ObjectParameter("FechaRFQ", typeof (DateTime)),
        fechaEntrega.HasValue ? new ObjectParameter("FechaEntrega", (object) fechaEntrega) : new ObjectParameter("FechaEntrega", typeof (DateTime)),
        enviado.HasValue ? new ObjectParameter("Enviado", (object) enviado) : new ObjectParameter("Enviado", typeof (int)),
        estatus.HasValue ? new ObjectParameter("Estatus", (object) estatus) : new ObjectParameter("Estatus", typeof (int)),
        seguimiento != null ? new ObjectParameter("Seguimiento", (object) seguimiento) : new ObjectParameter("Seguimiento", typeof (string)),
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string))
      });
    }

    public virtual int sp_InsertUpdateUsuarios(
      string idUsuario,
      string nombreCompleto,
      string usuario,
      string contrasena,
      string foto,
      int? permisos,
      string puesto,
      string telefono,
      string correo,
      string idUsuarioActualiza,
      int? activo,
      int? esLider)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_InsertUpdateUsuarios), new ObjectParameter[12]
      {
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string)),
        nombreCompleto != null ? new ObjectParameter("NombreCompleto", (object) nombreCompleto) : new ObjectParameter("NombreCompleto", typeof (string)),
        usuario != null ? new ObjectParameter("Usuario", (object) usuario) : new ObjectParameter("Usuario", typeof (string)),
        contrasena != null ? new ObjectParameter("Contrasena", (object) contrasena) : new ObjectParameter("Contrasena", typeof (string)),
        foto != null ? new ObjectParameter("Foto", (object) foto) : new ObjectParameter("Foto", typeof (string)),
        permisos.HasValue ? new ObjectParameter("Permisos", (object) permisos) : new ObjectParameter("Permisos", typeof (int)),
        puesto != null ? new ObjectParameter("Puesto", (object) puesto) : new ObjectParameter("Puesto", typeof (string)),
        telefono != null ? new ObjectParameter("Telefono", (object) telefono) : new ObjectParameter("Telefono", typeof (string)),
        correo != null ? new ObjectParameter("Correo", (object) correo) : new ObjectParameter("Correo", typeof (string)),
        idUsuarioActualiza != null ? new ObjectParameter("IdUsuarioActualiza", (object) idUsuarioActualiza) : new ObjectParameter("IdUsuarioActualiza", typeof (string)),
        activo.HasValue ? new ObjectParameter("Activo", (object) activo) : new ObjectParameter("Activo", typeof (int)),
        esLider.HasValue ? new ObjectParameter("EsLider", (object) esLider) : new ObjectParameter("EsLider", typeof (int))
      });
    }

    public virtual int sp_InsertUsuarioHorasHombre(string idProyecto, string idUsuario) => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_InsertUsuarioHorasHombre), new ObjectParameter[2]
    {
      idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string)),
      idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string))
    });

    public virtual ObjectResult<Decimal?> sp_InsertViaticos(
      string idProyecto,
      Decimal? cantEntregada,
      string idUsuario)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<Decimal?>(nameof (sp_InsertViaticos), new ObjectParameter[3]
      {
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string)),
        cantEntregada.HasValue ? new ObjectParameter("CantEntregada", (object) cantEntregada) : new ObjectParameter("CantEntregada", typeof (Decimal)),
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string))
      });
    }

    public virtual ObjectResult<int?> sp_InsertViaticosDet(
      string idViaticos,
      DateTime? fechaViaticos,
      Decimal? gasolina,
      Decimal? desayuno,
      Decimal? comida,
      Decimal? cena,
      Decimal? casetas,
      Decimal? hotel,
      Decimal? transporte,
      Decimal? otros,
      string descripcion,
      Decimal? totalGastado)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<int?>(nameof (sp_InsertViaticosDet), new ObjectParameter[12]
      {
        idViaticos != null ? new ObjectParameter("IdViaticos", (object) idViaticos) : new ObjectParameter("IdViaticos", typeof (string)),
        fechaViaticos.HasValue ? new ObjectParameter("FechaViaticos", (object) fechaViaticos) : new ObjectParameter("FechaViaticos", typeof (DateTime)),
        gasolina.HasValue ? new ObjectParameter("Gasolina", (object) gasolina) : new ObjectParameter("Gasolina", typeof (Decimal)),
        desayuno.HasValue ? new ObjectParameter("Desayuno", (object) desayuno) : new ObjectParameter("Desayuno", typeof (Decimal)),
        comida.HasValue ? new ObjectParameter("Comida", (object) comida) : new ObjectParameter("Comida", typeof (Decimal)),
        cena.HasValue ? new ObjectParameter("Cena", (object) cena) : new ObjectParameter("Cena", typeof (Decimal)),
        casetas.HasValue ? new ObjectParameter("Casetas", (object) casetas) : new ObjectParameter("Casetas", typeof (Decimal)),
        hotel.HasValue ? new ObjectParameter("Hotel", (object) hotel) : new ObjectParameter("Hotel", typeof (Decimal)),
        transporte.HasValue ? new ObjectParameter("Transporte", (object) transporte) : new ObjectParameter("Transporte", typeof (Decimal)),
        otros.HasValue ? new ObjectParameter("Otros", (object) otros) : new ObjectParameter("Otros", typeof (Decimal)),
        descripcion != null ? new ObjectParameter("Descripcion", (object) descripcion) : new ObjectParameter("Descripcion", typeof (string)),
        totalGastado.HasValue ? new ObjectParameter("TotalGastado", (object) totalGastado) : new ObjectParameter("TotalGastado", typeof (Decimal))
      });
    }

    public virtual ObjectResult<sp_LoadCitasPendientes_Result> sp_LoadCitasPendientes(
      string idUsuario,
      int? opcion)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_LoadCitasPendientes_Result>(nameof (sp_LoadCitasPendientes), new ObjectParameter[2]
      {
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string)),
        opcion.HasValue ? new ObjectParameter("Opcion", (object) opcion) : new ObjectParameter("Opcion", typeof (int))
      });
    }

    public virtual ObjectResult<sp_LoadHabilidadesUsuario_Result> sp_LoadHabilidadesUsuario(
      string idUsuario)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_LoadHabilidadesUsuario_Result>(nameof (sp_LoadHabilidadesUsuario), new ObjectParameter[1]
      {
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string))
      });
    }

    public virtual ObjectResult<sp_LoadHorasHombre_Result> sp_LoadHorasHombre(
      string idProyecto,
      int? current)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_LoadHorasHombre_Result>(nameof (sp_LoadHorasHombre), new ObjectParameter[2]
      {
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string)),
        current.HasValue ? new ObjectParameter("Current", (object) current) : new ObjectParameter("Current", typeof (int))
      });
    }

    public virtual ObjectResult<sp_LoadListaPendientes_Result> sp_LoadListaPendientes(
      string idUsuario)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_LoadListaPendientes_Result>(nameof (sp_LoadListaPendientes), new ObjectParameter[1]
      {
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string))
      });
    }

    public virtual ObjectResult<sp_LoadMateriales_Result> sp_LoadMateriales() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_LoadMateriales_Result>(nameof (sp_LoadMateriales), new ObjectParameter[0]);

    public virtual ObjectResult<sp_LoadMaterialImagenes_Result> sp_LoadMaterialImagenes(
      string idMaterial)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_LoadMaterialImagenes_Result>(nameof (sp_LoadMaterialImagenes), new ObjectParameter[1]
      {
        idMaterial != null ? new ObjectParameter("IdMaterial", (object) idMaterial) : new ObjectParameter("IdMaterial", typeof (string))
      });
    }

    public virtual ObjectResult<sp_LoadOrdenCompra_Result> sp_LoadOrdenCompra() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_LoadOrdenCompra_Result>(nameof (sp_LoadOrdenCompra), new ObjectParameter[0]);

    public virtual ObjectResult<sp_LoadOrdenCompraDetalle_Result> sp_LoadOrdenCompraDetalle(
      string idOrdenCompra,
      int? opcion)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_LoadOrdenCompraDetalle_Result>(nameof (sp_LoadOrdenCompraDetalle), new ObjectParameter[2]
      {
        idOrdenCompra != null ? new ObjectParameter("IdOrdenCompra", (object) idOrdenCompra) : new ObjectParameter("IdOrdenCompra", typeof (string)),
        opcion.HasValue ? new ObjectParameter("Opcion", (object) opcion) : new ObjectParameter("Opcion", typeof (int))
      });
    }

    public virtual ObjectResult<sp_LoadOrdenTrabajo_Result> sp_LoadOrdenTrabajo() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_LoadOrdenTrabajo_Result>(nameof (sp_LoadOrdenTrabajo), new ObjectParameter[0]);

    public virtual ObjectResult<sp_LoadProveedorMaterial_Result> sp_LoadProveedorMaterial(
      string idMaterial)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_LoadProveedorMaterial_Result>(nameof (sp_LoadProveedorMaterial), new ObjectParameter[1]
      {
        idMaterial != null ? new ObjectParameter("IdMaterial", (object) idMaterial) : new ObjectParameter("IdMaterial", typeof (string))
      });
    }

    public virtual ObjectResult<sp_LoadProyectoGastos_Result> sp_LoadProyectoGastos(
      string idProyecto)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_LoadProyectoGastos_Result>(nameof (sp_LoadProyectoGastos), new ObjectParameter[1]
      {
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string))
      });
    }

    public virtual ObjectResult<sp_LoadProyectoRequerimiento_Result> sp_LoadProyectoRequerimiento(
      string idProyecto)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_LoadProyectoRequerimiento_Result>(nameof (sp_LoadProyectoRequerimiento), new ObjectParameter[1]
      {
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string))
      });
    }

    public virtual ObjectResult<sp_LoadProyectosAdmin_Result> sp_LoadProyectosAdmin() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_LoadProyectosAdmin_Result>(nameof (sp_LoadProyectosAdmin), new ObjectParameter[0]);

    public virtual ObjectResult<sp_LoadProyectoTasks_Result> sp_LoadProyectoTasks(
      string idProyecto)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_LoadProyectoTasks_Result>(nameof (sp_LoadProyectoTasks), new ObjectParameter[1]
      {
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string))
      });
    }

    public virtual ObjectResult<sp_LoadRFQ_Result> sp_LoadRFQ() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_LoadRFQ_Result>(nameof (sp_LoadRFQ), new ObjectParameter[0]);

    public virtual ObjectResult<sp_LoadSumaColumnasViaticos_Result> sp_LoadSumaColumnasViaticos(
      string idViaticos)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_LoadSumaColumnasViaticos_Result>(nameof (sp_LoadSumaColumnasViaticos), new ObjectParameter[1]
      {
        idViaticos != null ? new ObjectParameter("IdViaticos", (object) idViaticos) : new ObjectParameter("IdViaticos", typeof (string))
      });
    }

    public virtual ObjectResult<sp_LoadTaskComentarios_Result> sp_LoadTaskComentarios(
      string idTask)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_LoadTaskComentarios_Result>(nameof (sp_LoadTaskComentarios), new ObjectParameter[1]
      {
        idTask != null ? new ObjectParameter("IdTask", (object) idTask) : new ObjectParameter("IdTask", typeof (string))
      });
    }

    public virtual ObjectResult<sp_LoadTaskImagenes_Result> sp_LoadTaskImagenes(
      string idTask)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_LoadTaskImagenes_Result>(nameof (sp_LoadTaskImagenes), new ObjectParameter[1]
      {
        idTask != null ? new ObjectParameter("IdTask", (object) idTask) : new ObjectParameter("IdTask", typeof (string))
      });
    }

    public virtual int sp_LoadTimming() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_LoadTimming), new ObjectParameter[0]);

    public virtual ObjectResult<sp_LoadUsuarios_Result> sp_LoadUsuarios() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_LoadUsuarios_Result>(nameof (sp_LoadUsuarios), new ObjectParameter[0]);

    public virtual ObjectResult<sp_LoadViaticos_Result> sp_LoadViaticos(
      string idViaticos)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_LoadViaticos_Result>(nameof (sp_LoadViaticos), new ObjectParameter[1]
      {
        idViaticos != null ? new ObjectParameter("IdViaticos", (object) idViaticos) : new ObjectParameter("IdViaticos", typeof (string))
      });
    }

    public virtual ObjectResult<sp_Login_Result> sp_Login(
      string usuario,
      string pass)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_Login_Result>(nameof (sp_Login), new ObjectParameter[2]
      {
        usuario != null ? new ObjectParameter("Usuario", (object) usuario) : new ObjectParameter("Usuario", typeof (string)),
        pass != null ? new ObjectParameter("Pass", (object) pass) : new ObjectParameter("Pass", typeof (string))
      });
    }

    public virtual ObjectResult<string> sp_ObtenerArchivosProyectos(
      string idProyecto,
      string opcion)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<string>(nameof (sp_ObtenerArchivosProyectos), new ObjectParameter[2]
      {
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string)),
        opcion != null ? new ObjectParameter("Opcion", (object) opcion) : new ObjectParameter("Opcion", typeof (string))
      });
    }

    public virtual ObjectResult<sp_ObtenerDatosControlFacturas_Result> sp_ObtenerDatosControlFacturas(
      string idControlFacturas)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_ObtenerDatosControlFacturas_Result>(nameof (sp_ObtenerDatosControlFacturas), new ObjectParameter[1]
      {
        idControlFacturas != null ? new ObjectParameter("IdControlFacturas", (object) idControlFacturas) : new ObjectParameter("IdControlFacturas", typeof (string))
      });
    }

    public virtual ObjectResult<sp_ObtenerDatosFacturasEmitidas_Result> sp_ObtenerDatosFacturasEmitidas(
      string idFacturasEmitidas)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_ObtenerDatosFacturasEmitidas_Result>(nameof (sp_ObtenerDatosFacturasEmitidas), new ObjectParameter[1]
      {
        idFacturasEmitidas != null ? new ObjectParameter("IdFacturasEmitidas", (object) idFacturasEmitidas) : new ObjectParameter("IdFacturasEmitidas", typeof (string))
      });
    }

    public virtual ObjectResult<sp_ObtenerDatosTarea_Result> sp_ObtenerDatosTarea(
      string idTask)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_ObtenerDatosTarea_Result>(nameof (sp_ObtenerDatosTarea), new ObjectParameter[1]
      {
        idTask != null ? new ObjectParameter("IdTask", (object) idTask) : new ObjectParameter("IdTask", typeof (string))
      });
    }

    public virtual ObjectResult<sp_ObtenerInfoCotizacion_Result> sp_ObtenerInfoCotizacion(
      string idCotizacion)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_ObtenerInfoCotizacion_Result>(nameof (sp_ObtenerInfoCotizacion), new ObjectParameter[1]
      {
        idCotizacion != null ? new ObjectParameter("IdCotizacion", (object) idCotizacion) : new ObjectParameter("IdCotizacion", typeof (string))
      });
    }

    public virtual ObjectResult<sp_ObtenerNotasAclaratorias_Result> sp_ObtenerNotasAclaratorias(
      string idCotizacion)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_ObtenerNotasAclaratorias_Result>(nameof (sp_ObtenerNotasAclaratorias), new ObjectParameter[1]
      {
        idCotizacion != null ? new ObjectParameter("IdCotizacion", (object) idCotizacion) : new ObjectParameter("IdCotizacion", typeof (string))
      });
    }

    public virtual ObjectResult<sp_ObtenerSeguimientoRFQ_Result> sp_ObtenerSeguimientoRFQ(
      string idRfq)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_ObtenerSeguimientoRFQ_Result>(nameof (sp_ObtenerSeguimientoRFQ), new ObjectParameter[1]
      {
        idRfq != null ? new ObjectParameter("IdRfq", (object) idRfq) : new ObjectParameter("IdRfq", typeof (string))
      });
    }

    public virtual int sp_ObtieneFolioCotizacion(ObjectParameter folio) => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_ObtieneFolioCotizacion), new ObjectParameter[1]
    {
      folio
    });

    public virtual int sp_ObtieneFolioOrdenCompra(ObjectParameter folioOC) => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_ObtieneFolioOrdenCompra), new ObjectParameter[1]
    {
      folioOC
    });

    public virtual int sp_ObtieneFolioReq(ObjectParameter folio) => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_ObtieneFolioReq), new ObjectParameter[1]
    {
      folio
    });

    public virtual int sp_ObtieneFolioRFQ(ObjectParameter folio) => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_ObtieneFolioRFQ), new ObjectParameter[1]
    {
      folio
    });

    public virtual ObjectResult<sp_ObtieneRFQVentas_Result> sp_ObtieneRFQVentas() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_ObtieneRFQVentas_Result>(nameof (sp_ObtieneRFQVentas), new ObjectParameter[0]);

    public virtual int sp_ReporteProyectosGastos() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_ReporteProyectosGastos), new ObjectParameter[0]);

    public virtual ObjectResult<sp_ReporteProyectosGastosVistas_Result> sp_ReporteProyectosGastosVistas() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_ReporteProyectosGastosVistas_Result>(nameof (sp_ReporteProyectosGastosVistas), new ObjectParameter[0]);

    public virtual int sp_ResumenClientesProyectos() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_ResumenClientesProyectos), new ObjectParameter[0]);

    public virtual int sp_ResumenTotales(
      string mes,
      string idProveedor,
      string noFactura,
      string proyecto,
      string moneda,
      int? estatus)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_ResumenTotales), new ObjectParameter[6]
      {
        mes != null ? new ObjectParameter("Mes", (object) mes) : new ObjectParameter("Mes", typeof (string)),
        idProveedor != null ? new ObjectParameter("IdProveedor", (object) idProveedor) : new ObjectParameter("IdProveedor", typeof (string)),
        noFactura != null ? new ObjectParameter("NoFactura", (object) noFactura) : new ObjectParameter("NoFactura", typeof (string)),
        proyecto != null ? new ObjectParameter("Proyecto", (object) proyecto) : new ObjectParameter("Proyecto", typeof (string)),
        moneda != null ? new ObjectParameter("Moneda", (object) moneda) : new ObjectParameter("Moneda", typeof (string)),
        estatus.HasValue ? new ObjectParameter("Estatus", (object) estatus) : new ObjectParameter("Estatus", typeof (int))
      });
    }

    public virtual int sp_ResumenTotalesFacturasEmitidas(
      string anio,
      string cliente,
      string idProyecto,
      string moneda,
      int? estatus)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_ResumenTotalesFacturasEmitidas), new ObjectParameter[5]
      {
        anio != null ? new ObjectParameter("Anio", (object) anio) : new ObjectParameter("Anio", typeof (string)),
        cliente != null ? new ObjectParameter("Cliente", (object) cliente) : new ObjectParameter("Cliente", typeof (string)),
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string)),
        moneda != null ? new ObjectParameter("Moneda", (object) moneda) : new ObjectParameter("Moneda", typeof (string)),
        estatus.HasValue ? new ObjectParameter("Estatus", (object) estatus) : new ObjectParameter("Estatus", typeof (int))
      });
    }

    public virtual int sp_ResumenTotalesOC(string valor) => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_ResumenTotalesOC), new ObjectParameter[1]
    {
      valor != null ? new ObjectParameter("Valor", (object) valor) : new ObjectParameter("Valor", typeof (string))
    });

    public virtual ObjectResult<sp_ResumenTotalesRecibidas_Result> sp_ResumenTotalesRecibidas(
      string a)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_ResumenTotalesRecibidas_Result>(nameof (sp_ResumenTotalesRecibidas), new ObjectParameter[1]
      {
        a != null ? new ObjectParameter(nameof (a), (object) a) : new ObjectParameter(nameof (a), typeof (string))
      });
    }

    public virtual ObjectResult<sp_SelectEventosCalendario_Result> sp_SelectEventosCalendario(
      string idUsuario)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_SelectEventosCalendario_Result>(nameof (sp_SelectEventosCalendario), new ObjectParameter[1]
      {
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string))
      });
    }

    public virtual ObjectResult<sp_SelectLocalizacion_Result> sp_SelectLocalizacion(
      string iD)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_SelectLocalizacion_Result>(nameof (sp_SelectLocalizacion), new ObjectParameter[1]
      {
        iD != null ? new ObjectParameter("ID", (object) iD) : new ObjectParameter("ID", typeof (string))
      });
    }

    public virtual ObjectResult<string> sp_SelectVinReconocimientoVoz(string vin) => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<string>(nameof (sp_SelectVinReconocimientoVoz), new ObjectParameter[1]
    {
      vin != null ? new ObjectParameter("Vin", (object) vin) : new ObjectParameter("Vin", typeof (string))
    });

    public virtual int sp_Sincronizacion_Clientes() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_Sincronizacion_Clientes), new ObjectParameter[0]);

    public virtual int sp_Sincronizacion_ComentariosProyecto() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_Sincronizacion_ComentariosProyecto), new ObjectParameter[0]);

    public virtual int sp_Sincronizacion_Cotizacion() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_Sincronizacion_Cotizacion), new ObjectParameter[0]);

    public virtual int sp_Sincronizacion_FolioCotizacion() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_Sincronizacion_FolioCotizacion), new ObjectParameter[0]);

    public virtual int sp_Sincronizacion_Gastos() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_Sincronizacion_Gastos), new ObjectParameter[0]);

    public virtual int sp_Sincronizacion_Habilidades() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_Sincronizacion_Habilidades), new ObjectParameter[0]);

    public virtual int sp_Sincronizacion_ListaPendientes() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_Sincronizacion_ListaPendientes), new ObjectParameter[0]);

    public virtual int sp_Sincronizacion_MatrizMecanico() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_Sincronizacion_MatrizMecanico), new ObjectParameter[0]);

    public virtual int sp_Sincronizacion_Menu() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_Sincronizacion_Menu), new ObjectParameter[0]);

    public virtual int sp_Sincronizacion_NotaAclaratoria() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_Sincronizacion_NotaAclaratoria), new ObjectParameter[0]);

    public virtual int sp_Sincronizacion_Permisos() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_Sincronizacion_Permisos), new ObjectParameter[0]);

    public virtual int sp_Sincronizacion_Proveedores() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_Sincronizacion_Proveedores), new ObjectParameter[0]);

    public virtual int sp_Sincronizacion_Proyectos() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_Sincronizacion_Proyectos), new ObjectParameter[0]);

    public virtual int sp_Sincronizacion_ProyectosTaskImagen() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_Sincronizacion_ProyectosTaskImagen), new ObjectParameter[0]);

    public virtual int sp_Sincronizacion_ProyectoTasks() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_Sincronizacion_ProyectoTasks), new ObjectParameter[0]);

    public virtual int sp_Sincronizacion_ProyectoTasksComentarios() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_Sincronizacion_ProyectoTasksComentarios), new ObjectParameter[0]);

    public virtual int sp_Sincronizacion_Usuarios() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_Sincronizacion_Usuarios), new ObjectParameter[0]);

    public virtual int sp_Sincronizacion_Viaticos() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_Sincronizacion_Viaticos), new ObjectParameter[0]);

    public virtual int sp_Sincronizacion_ViaticosDet() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_Sincronizacion_ViaticosDet), new ObjectParameter[0]);

    public virtual int sp_SubeArchivoCotizacion(
      string idCotizacion,
      string nombreArchivo,
      string documento)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_SubeArchivoCotizacion), new ObjectParameter[3]
      {
        idCotizacion != null ? new ObjectParameter("IdCotizacion", (object) idCotizacion) : new ObjectParameter("IdCotizacion", typeof (string)),
        nombreArchivo != null ? new ObjectParameter("NombreArchivo", (object) nombreArchivo) : new ObjectParameter("NombreArchivo", typeof (string)),
        documento != null ? new ObjectParameter("Documento", (object) documento) : new ObjectParameter("Documento", typeof (string))
      });
    }

    public virtual int sp_SubeArchivosFacturas(
      string idControlFacturas,
      string nombreArchivo,
      string documento)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_SubeArchivosFacturas), new ObjectParameter[3]
      {
        idControlFacturas != null ? new ObjectParameter("IdControlFacturas", (object) idControlFacturas) : new ObjectParameter("IdControlFacturas", typeof (string)),
        nombreArchivo != null ? new ObjectParameter("NombreArchivo", (object) nombreArchivo) : new ObjectParameter("NombreArchivo", typeof (string)),
        documento != null ? new ObjectParameter("Documento", (object) documento) : new ObjectParameter("Documento", typeof (string))
      });
    }

    public virtual int sp_SubeArchivosProyectos(
      string idProyecto,
      string nombreArchivo,
      string documento,
      string opcion)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_SubeArchivosProyectos), new ObjectParameter[4]
      {
        idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string)),
        nombreArchivo != null ? new ObjectParameter("NombreArchivo", (object) nombreArchivo) : new ObjectParameter("NombreArchivo", typeof (string)),
        documento != null ? new ObjectParameter("Documento", (object) documento) : new ObjectParameter("Documento", typeof (string)),
        opcion != null ? new ObjectParameter("Opcion", (object) opcion) : new ObjectParameter("Opcion", typeof (string))
      });
    }

    public virtual int sp_TerminarCapturaHorasHombre(string idProyecto, string idUsuario) => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_TerminarCapturaHorasHombre), new ObjectParameter[2]
    {
      idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string)),
      idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string))
    });

    public virtual int sp_TerminarProyecto(string idProyecto, string idUsuario) => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_TerminarProyecto), new ObjectParameter[2]
    {
      idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string)),
      idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string))
    });

    public virtual ObjectResult<sp_TotalesOC_Result> sp_TotalesOC(
      string valor)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_TotalesOC_Result>(nameof (sp_TotalesOC), new ObjectParameter[1]
      {
        valor != null ? new ObjectParameter("Valor", (object) valor) : new ObjectParameter("Valor", typeof (string))
      });
    }

    public virtual ObjectResult<sp_TotalSinOrden_Result> sp_TotalSinOrden(
      int? opcion)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_TotalSinOrden_Result>(nameof (sp_TotalSinOrden), new ObjectParameter[1]
      {
        opcion.HasValue ? new ObjectParameter("Opcion", (object) opcion) : new ObjectParameter("Opcion", typeof (int))
      });
    }

    public virtual int sp_UpdateCostoProyecto(string idProyecto, Decimal? costo, string idUsuario) => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_UpdateCostoProyecto), new ObjectParameter[3]
    {
      idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string)),
      costo.HasValue ? new ObjectParameter("Costo", (object) costo) : new ObjectParameter("Costo", typeof (Decimal)),
      idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string))
    });

    public virtual int sp_UpdateImagenUsuario(string idUsuario, string imagen) => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_UpdateImagenUsuario), new ObjectParameter[2]
    {
      idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string)),
      imagen != null ? new ObjectParameter("Imagen", (object) imagen) : new ObjectParameter("Imagen", typeof (string))
    });

    public virtual int sp_UpdatePerfilUsuario(string idUsuario, string perfil) => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_UpdatePerfilUsuario), new ObjectParameter[2]
    {
      idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string)),
      perfil != null ? new ObjectParameter("Perfil", (object) perfil) : new ObjectParameter("Perfil", typeof (string))
    });

    public virtual int sp_UpdateTask(
      string idTask,
      string task,
      string idUsuario,
      DateTime? fechaInicio,
      DateTime? fechaFin,
      string comentarios,
      string idUsuarioAlta)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_UpdateTask), new ObjectParameter[7]
      {
        idTask != null ? new ObjectParameter("IdTask", (object) idTask) : new ObjectParameter("IdTask", typeof (string)),
        task != null ? new ObjectParameter("Task", (object) task) : new ObjectParameter("Task", typeof (string)),
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string)),
        fechaInicio.HasValue ? new ObjectParameter("FechaInicio", (object) fechaInicio) : new ObjectParameter("FechaInicio", typeof (DateTime)),
        fechaFin.HasValue ? new ObjectParameter("FechaFin", (object) fechaFin) : new ObjectParameter("FechaFin", typeof (DateTime)),
        comentarios != null ? new ObjectParameter("Comentarios", (object) comentarios) : new ObjectParameter("Comentarios", typeof (string)),
        idUsuarioAlta != null ? new ObjectParameter("IdUsuarioAlta", (object) idUsuarioAlta) : new ObjectParameter("IdUsuarioAlta", typeof (string))
      });
    }

    public virtual ObjectResult<spBuscarClienteXId_Result> spBuscarClienteXId(
      string idCliente)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<spBuscarClienteXId_Result>(nameof (spBuscarClienteXId), new ObjectParameter[1]
      {
        idCliente != null ? new ObjectParameter("IdCliente", (object) idCliente) : new ObjectParameter("IdCliente", typeof (string))
      });
    }

    public virtual ObjectResult<spBuscarContactosXIdProveedor_Result> spBuscarContactosXIdProveedor(
      string idProveedor)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<spBuscarContactosXIdProveedor_Result>(nameof (spBuscarContactosXIdProveedor), new ObjectParameter[1]
      {
        idProveedor != null ? new ObjectParameter("IdProveedor", (object) idProveedor) : new ObjectParameter("IdProveedor", typeof (string))
      });
    }

    public virtual ObjectResult<spBuscarMaterialXId_Result> spBuscarMaterialXId(
      string idMaterial)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<spBuscarMaterialXId_Result>(nameof (spBuscarMaterialXId), new ObjectParameter[1]
      {
        idMaterial != null ? new ObjectParameter("IdMaterial", (object) idMaterial) : new ObjectParameter("IdMaterial", typeof (string))
      });
    }

    public virtual ObjectResult<spBuscarProveedorXId_Result> spBuscarProveedorXId(
      string idProveedor)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<spBuscarProveedorXId_Result>(nameof (spBuscarProveedorXId), new ObjectParameter[1]
      {
        idProveedor != null ? new ObjectParameter("IdProveedor", (object) idProveedor) : new ObjectParameter("IdProveedor", typeof (string))
      });
    }

    public virtual ObjectResult<spBuscarUsuarioXId_Result> spBuscarUsuarioXId(
      string idUsuario)
    {
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<spBuscarUsuarioXId_Result>(nameof (spBuscarUsuarioXId), new ObjectParameter[1]
      {
        idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string))
      });
    }

    public virtual int W_Sp_Pag_CapturaViaticos(
      int? iDisplayStart,
      int? iDisplayLength,
      string sSortingCol_delim,
      string sSortingDir_delim,
      int? iSortingCols,
      string sSearch,
      string sSearchableCol_delim,
      int? iSearchableCols,
      ObjectParameter iTotalRecords,
      ObjectParameter iTotalDisplayRecords,
      string idUsuario)
    {
      ObjectParameter objectParameter1 = iDisplayStart.HasValue ? new ObjectParameter(nameof (iDisplayStart), (object) iDisplayStart) : new ObjectParameter(nameof (iDisplayStart), typeof (int));
      ObjectParameter objectParameter2 = iDisplayLength.HasValue ? new ObjectParameter(nameof (iDisplayLength), (object) iDisplayLength) : new ObjectParameter(nameof (iDisplayLength), typeof (int));
      ObjectParameter objectParameter3 = sSortingCol_delim != null ? new ObjectParameter(nameof (sSortingCol_delim), (object) sSortingCol_delim) : new ObjectParameter(nameof (sSortingCol_delim), typeof (string));
      ObjectParameter objectParameter4 = sSortingDir_delim != null ? new ObjectParameter(nameof (sSortingDir_delim), (object) sSortingDir_delim) : new ObjectParameter(nameof (sSortingDir_delim), typeof (string));
      ObjectParameter objectParameter5 = iSortingCols.HasValue ? new ObjectParameter(nameof (iSortingCols), (object) iSortingCols) : new ObjectParameter(nameof (iSortingCols), typeof (int));
      ObjectParameter objectParameter6 = sSearch != null ? new ObjectParameter(nameof (sSearch), (object) sSearch) : new ObjectParameter(nameof (sSearch), typeof (string));
      ObjectParameter objectParameter7 = sSearchableCol_delim != null ? new ObjectParameter(nameof (sSearchableCol_delim), (object) sSearchableCol_delim) : new ObjectParameter(nameof (sSearchableCol_delim), typeof (string));
      ObjectParameter objectParameter8 = iSearchableCols.HasValue ? new ObjectParameter(nameof (iSearchableCols), (object) iSearchableCols) : new ObjectParameter(nameof (iSearchableCols), typeof (int));
      ObjectParameter objectParameter9 = idUsuario != null ? new ObjectParameter("IdUsuario", (object) idUsuario) : new ObjectParameter("IdUsuario", typeof (string));
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (W_Sp_Pag_CapturaViaticos), new ObjectParameter[11]
      {
        objectParameter1,
        objectParameter2,
        objectParameter3,
        objectParameter4,
        objectParameter5,
        objectParameter6,
        objectParameter7,
        objectParameter8,
        iTotalRecords,
        iTotalDisplayRecords,
        objectParameter9
      });
    }

    public virtual int W_Sp_Pag_Clientes(
      int? iDisplayStart,
      int? iDisplayLength,
      string sSortingCol_delim,
      string sSortingDir_delim,
      int? iSortingCols,
      string sSearch,
      string sSearchableCol_delim,
      int? iSearchableCols,
      ObjectParameter iTotalRecords,
      ObjectParameter iTotalDisplayRecords,
      int? opcion)
    {
      ObjectParameter objectParameter1 = iDisplayStart.HasValue ? new ObjectParameter(nameof (iDisplayStart), (object) iDisplayStart) : new ObjectParameter(nameof (iDisplayStart), typeof (int));
      ObjectParameter objectParameter2 = iDisplayLength.HasValue ? new ObjectParameter(nameof (iDisplayLength), (object) iDisplayLength) : new ObjectParameter(nameof (iDisplayLength), typeof (int));
      ObjectParameter objectParameter3 = sSortingCol_delim != null ? new ObjectParameter(nameof (sSortingCol_delim), (object) sSortingCol_delim) : new ObjectParameter(nameof (sSortingCol_delim), typeof (string));
      ObjectParameter objectParameter4 = sSortingDir_delim != null ? new ObjectParameter(nameof (sSortingDir_delim), (object) sSortingDir_delim) : new ObjectParameter(nameof (sSortingDir_delim), typeof (string));
      ObjectParameter objectParameter5 = iSortingCols.HasValue ? new ObjectParameter(nameof (iSortingCols), (object) iSortingCols) : new ObjectParameter(nameof (iSortingCols), typeof (int));
      ObjectParameter objectParameter6 = sSearch != null ? new ObjectParameter(nameof (sSearch), (object) sSearch) : new ObjectParameter(nameof (sSearch), typeof (string));
      ObjectParameter objectParameter7 = sSearchableCol_delim != null ? new ObjectParameter(nameof (sSearchableCol_delim), (object) sSearchableCol_delim) : new ObjectParameter(nameof (sSearchableCol_delim), typeof (string));
      ObjectParameter objectParameter8 = iSearchableCols.HasValue ? new ObjectParameter(nameof (iSearchableCols), (object) iSearchableCols) : new ObjectParameter(nameof (iSearchableCols), typeof (int));
      ObjectParameter objectParameter9 = opcion.HasValue ? new ObjectParameter("Opcion", (object) opcion) : new ObjectParameter("Opcion", typeof (int));
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (W_Sp_Pag_Clientes), new ObjectParameter[11]
      {
        objectParameter1,
        objectParameter2,
        objectParameter3,
        objectParameter4,
        objectParameter5,
        objectParameter6,
        objectParameter7,
        objectParameter8,
        iTotalRecords,
        iTotalDisplayRecords,
        objectParameter9
      });
    }

    public virtual int W_Sp_Pag_Cotizaciones(
      int? iDisplayStart,
      int? iDisplayLength,
      string sSortingCol_delim,
      string sSortingDir_delim,
      int? iSortingCols,
      string sSearch,
      string sSearchableCol_delim,
      int? iSearchableCols,
      ObjectParameter iTotalRecords,
      ObjectParameter iTotalDisplayRecords,
      int? opcion)
    {
      ObjectParameter objectParameter1 = iDisplayStart.HasValue ? new ObjectParameter(nameof (iDisplayStart), (object) iDisplayStart) : new ObjectParameter(nameof (iDisplayStart), typeof (int));
      ObjectParameter objectParameter2 = iDisplayLength.HasValue ? new ObjectParameter(nameof (iDisplayLength), (object) iDisplayLength) : new ObjectParameter(nameof (iDisplayLength), typeof (int));
      ObjectParameter objectParameter3 = sSortingCol_delim != null ? new ObjectParameter(nameof (sSortingCol_delim), (object) sSortingCol_delim) : new ObjectParameter(nameof (sSortingCol_delim), typeof (string));
      ObjectParameter objectParameter4 = sSortingDir_delim != null ? new ObjectParameter(nameof (sSortingDir_delim), (object) sSortingDir_delim) : new ObjectParameter(nameof (sSortingDir_delim), typeof (string));
      ObjectParameter objectParameter5 = iSortingCols.HasValue ? new ObjectParameter(nameof (iSortingCols), (object) iSortingCols) : new ObjectParameter(nameof (iSortingCols), typeof (int));
      ObjectParameter objectParameter6 = sSearch != null ? new ObjectParameter(nameof (sSearch), (object) sSearch) : new ObjectParameter(nameof (sSearch), typeof (string));
      ObjectParameter objectParameter7 = sSearchableCol_delim != null ? new ObjectParameter(nameof (sSearchableCol_delim), (object) sSearchableCol_delim) : new ObjectParameter(nameof (sSearchableCol_delim), typeof (string));
      ObjectParameter objectParameter8 = iSearchableCols.HasValue ? new ObjectParameter(nameof (iSearchableCols), (object) iSearchableCols) : new ObjectParameter(nameof (iSearchableCols), typeof (int));
      ObjectParameter objectParameter9 = opcion.HasValue ? new ObjectParameter("Opcion", (object) opcion) : new ObjectParameter("Opcion", typeof (int));
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (W_Sp_Pag_Cotizaciones), new ObjectParameter[11]
      {
        objectParameter1,
        objectParameter2,
        objectParameter3,
        objectParameter4,
        objectParameter5,
        objectParameter6,
        objectParameter7,
        objectParameter8,
        iTotalRecords,
        iTotalDisplayRecords,
        objectParameter9
      });
    }

    public virtual int W_Sp_Pag_Maquinados(
      int? iDisplayStart,
      int? iDisplayLength,
      string sSortingCol_delim,
      string sSortingDir_delim,
      int? iSortingCols,
      string sSearch,
      string sSearchableCol_delim,
      int? iSearchableCols,
      ObjectParameter iTotalRecords,
      ObjectParameter iTotalDisplayRecords,
      int? opcion)
    {
      ObjectParameter objectParameter1 = iDisplayStart.HasValue ? new ObjectParameter(nameof (iDisplayStart), (object) iDisplayStart) : new ObjectParameter(nameof (iDisplayStart), typeof (int));
      ObjectParameter objectParameter2 = iDisplayLength.HasValue ? new ObjectParameter(nameof (iDisplayLength), (object) iDisplayLength) : new ObjectParameter(nameof (iDisplayLength), typeof (int));
      ObjectParameter objectParameter3 = sSortingCol_delim != null ? new ObjectParameter(nameof (sSortingCol_delim), (object) sSortingCol_delim) : new ObjectParameter(nameof (sSortingCol_delim), typeof (string));
      ObjectParameter objectParameter4 = sSortingDir_delim != null ? new ObjectParameter(nameof (sSortingDir_delim), (object) sSortingDir_delim) : new ObjectParameter(nameof (sSortingDir_delim), typeof (string));
      ObjectParameter objectParameter5 = iSortingCols.HasValue ? new ObjectParameter(nameof (iSortingCols), (object) iSortingCols) : new ObjectParameter(nameof (iSortingCols), typeof (int));
      ObjectParameter objectParameter6 = sSearch != null ? new ObjectParameter(nameof (sSearch), (object) sSearch) : new ObjectParameter(nameof (sSearch), typeof (string));
      ObjectParameter objectParameter7 = sSearchableCol_delim != null ? new ObjectParameter(nameof (sSearchableCol_delim), (object) sSearchableCol_delim) : new ObjectParameter(nameof (sSearchableCol_delim), typeof (string));
      ObjectParameter objectParameter8 = iSearchableCols.HasValue ? new ObjectParameter(nameof (iSearchableCols), (object) iSearchableCols) : new ObjectParameter(nameof (iSearchableCols), typeof (int));
      ObjectParameter objectParameter9 = opcion.HasValue ? new ObjectParameter("Opcion", (object) opcion) : new ObjectParameter("Opcion", typeof (int));
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (W_Sp_Pag_Maquinados), new ObjectParameter[11]
      {
        objectParameter1,
        objectParameter2,
        objectParameter3,
        objectParameter4,
        objectParameter5,
        objectParameter6,
        objectParameter7,
        objectParameter8,
        iTotalRecords,
        iTotalDisplayRecords,
        objectParameter9
      });
    }

    public virtual int W_Sp_Pag_Materiales(
      int? iDisplayStart,
      int? iDisplayLength,
      string sSortingCol_delim,
      string sSortingDir_delim,
      int? iSortingCols,
      string sSearch,
      string sSearchableCol_delim,
      int? iSearchableCols,
      ObjectParameter iTotalRecords,
      ObjectParameter iTotalDisplayRecords,
      int? opcion)
    {
      ObjectParameter objectParameter1 = iDisplayStart.HasValue ? new ObjectParameter(nameof (iDisplayStart), (object) iDisplayStart) : new ObjectParameter(nameof (iDisplayStart), typeof (int));
      ObjectParameter objectParameter2 = iDisplayLength.HasValue ? new ObjectParameter(nameof (iDisplayLength), (object) iDisplayLength) : new ObjectParameter(nameof (iDisplayLength), typeof (int));
      ObjectParameter objectParameter3 = sSortingCol_delim != null ? new ObjectParameter(nameof (sSortingCol_delim), (object) sSortingCol_delim) : new ObjectParameter(nameof (sSortingCol_delim), typeof (string));
      ObjectParameter objectParameter4 = sSortingDir_delim != null ? new ObjectParameter(nameof (sSortingDir_delim), (object) sSortingDir_delim) : new ObjectParameter(nameof (sSortingDir_delim), typeof (string));
      ObjectParameter objectParameter5 = iSortingCols.HasValue ? new ObjectParameter(nameof (iSortingCols), (object) iSortingCols) : new ObjectParameter(nameof (iSortingCols), typeof (int));
      ObjectParameter objectParameter6 = sSearch != null ? new ObjectParameter(nameof (sSearch), (object) sSearch) : new ObjectParameter(nameof (sSearch), typeof (string));
      ObjectParameter objectParameter7 = sSearchableCol_delim != null ? new ObjectParameter(nameof (sSearchableCol_delim), (object) sSearchableCol_delim) : new ObjectParameter(nameof (sSearchableCol_delim), typeof (string));
      ObjectParameter objectParameter8 = iSearchableCols.HasValue ? new ObjectParameter(nameof (iSearchableCols), (object) iSearchableCols) : new ObjectParameter(nameof (iSearchableCols), typeof (int));
      ObjectParameter objectParameter9 = opcion.HasValue ? new ObjectParameter("Opcion", (object) opcion) : new ObjectParameter("Opcion", typeof (int));
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (W_Sp_Pag_Materiales), new ObjectParameter[11]
      {
        objectParameter1,
        objectParameter2,
        objectParameter3,
        objectParameter4,
        objectParameter5,
        objectParameter6,
        objectParameter7,
        objectParameter8,
        iTotalRecords,
        iTotalDisplayRecords,
        objectParameter9
      });
    }

    public virtual int W_Sp_Pag_Proveedores(
      int? iDisplayStart,
      int? iDisplayLength,
      string sSortingCol_delim,
      string sSortingDir_delim,
      int? iSortingCols,
      string sSearch,
      string sSearchableCol_delim,
      int? iSearchableCols,
      ObjectParameter iTotalRecords,
      ObjectParameter iTotalDisplayRecords,
      int? opcion)
    {
      ObjectParameter objectParameter1 = iDisplayStart.HasValue ? new ObjectParameter(nameof (iDisplayStart), (object) iDisplayStart) : new ObjectParameter(nameof (iDisplayStart), typeof (int));
      ObjectParameter objectParameter2 = iDisplayLength.HasValue ? new ObjectParameter(nameof (iDisplayLength), (object) iDisplayLength) : new ObjectParameter(nameof (iDisplayLength), typeof (int));
      ObjectParameter objectParameter3 = sSortingCol_delim != null ? new ObjectParameter(nameof (sSortingCol_delim), (object) sSortingCol_delim) : new ObjectParameter(nameof (sSortingCol_delim), typeof (string));
      ObjectParameter objectParameter4 = sSortingDir_delim != null ? new ObjectParameter(nameof (sSortingDir_delim), (object) sSortingDir_delim) : new ObjectParameter(nameof (sSortingDir_delim), typeof (string));
      ObjectParameter objectParameter5 = iSortingCols.HasValue ? new ObjectParameter(nameof (iSortingCols), (object) iSortingCols) : new ObjectParameter(nameof (iSortingCols), typeof (int));
      ObjectParameter objectParameter6 = sSearch != null ? new ObjectParameter(nameof (sSearch), (object) sSearch) : new ObjectParameter(nameof (sSearch), typeof (string));
      ObjectParameter objectParameter7 = sSearchableCol_delim != null ? new ObjectParameter(nameof (sSearchableCol_delim), (object) sSearchableCol_delim) : new ObjectParameter(nameof (sSearchableCol_delim), typeof (string));
      ObjectParameter objectParameter8 = iSearchableCols.HasValue ? new ObjectParameter(nameof (iSearchableCols), (object) iSearchableCols) : new ObjectParameter(nameof (iSearchableCols), typeof (int));
      ObjectParameter objectParameter9 = opcion.HasValue ? new ObjectParameter("Opcion", (object) opcion) : new ObjectParameter("Opcion", typeof (int));
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (W_Sp_Pag_Proveedores), new ObjectParameter[11]
      {
        objectParameter1,
        objectParameter2,
        objectParameter3,
        objectParameter4,
        objectParameter5,
        objectParameter6,
        objectParameter7,
        objectParameter8,
        iTotalRecords,
        iTotalDisplayRecords,
        objectParameter9
      });
    }

    public virtual int W_Sp_Pag_Proyectos(
      int? iDisplayStart,
      int? iDisplayLength,
      string sSortingCol_delim,
      string sSortingDir_delim,
      int? iSortingCols,
      string sSearch,
      string sSearchableCol_delim,
      int? iSearchableCols,
      ObjectParameter iTotalRecords,
      ObjectParameter iTotalDisplayRecords,
      string opcion)
    {
      ObjectParameter objectParameter1 = iDisplayStart.HasValue ? new ObjectParameter(nameof (iDisplayStart), (object) iDisplayStart) : new ObjectParameter(nameof (iDisplayStart), typeof (int));
      ObjectParameter objectParameter2 = iDisplayLength.HasValue ? new ObjectParameter(nameof (iDisplayLength), (object) iDisplayLength) : new ObjectParameter(nameof (iDisplayLength), typeof (int));
      ObjectParameter objectParameter3 = sSortingCol_delim != null ? new ObjectParameter(nameof (sSortingCol_delim), (object) sSortingCol_delim) : new ObjectParameter(nameof (sSortingCol_delim), typeof (string));
      ObjectParameter objectParameter4 = sSortingDir_delim != null ? new ObjectParameter(nameof (sSortingDir_delim), (object) sSortingDir_delim) : new ObjectParameter(nameof (sSortingDir_delim), typeof (string));
      ObjectParameter objectParameter5 = iSortingCols.HasValue ? new ObjectParameter(nameof (iSortingCols), (object) iSortingCols) : new ObjectParameter(nameof (iSortingCols), typeof (int));
      ObjectParameter objectParameter6 = sSearch != null ? new ObjectParameter(nameof (sSearch), (object) sSearch) : new ObjectParameter(nameof (sSearch), typeof (string));
      ObjectParameter objectParameter7 = sSearchableCol_delim != null ? new ObjectParameter(nameof (sSearchableCol_delim), (object) sSearchableCol_delim) : new ObjectParameter(nameof (sSearchableCol_delim), typeof (string));
      ObjectParameter objectParameter8 = iSearchableCols.HasValue ? new ObjectParameter(nameof (iSearchableCols), (object) iSearchableCols) : new ObjectParameter(nameof (iSearchableCols), typeof (int));
      ObjectParameter objectParameter9 = opcion != null ? new ObjectParameter("Opcion", (object) opcion) : new ObjectParameter("Opcion", typeof (string));
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (W_Sp_Pag_Proyectos), new ObjectParameter[11]
      {
        objectParameter1,
        objectParameter2,
        objectParameter3,
        objectParameter4,
        objectParameter5,
        objectParameter6,
        objectParameter7,
        objectParameter8,
        iTotalRecords,
        iTotalDisplayRecords,
        objectParameter9
      });
    }

    public virtual int W_Sp_Pag_ProyectoTasks(
      int? iDisplayStart,
      int? iDisplayLength,
      string sSortingCol_delim,
      string sSortingDir_delim,
      int? iSortingCols,
      string sSearch,
      string sSearchableCol_delim,
      int? iSearchableCols,
      ObjectParameter iTotalRecords,
      ObjectParameter iTotalDisplayRecords,
      string idProyecto)
    {
      ObjectParameter objectParameter1 = iDisplayStart.HasValue ? new ObjectParameter(nameof (iDisplayStart), (object) iDisplayStart) : new ObjectParameter(nameof (iDisplayStart), typeof (int));
      ObjectParameter objectParameter2 = iDisplayLength.HasValue ? new ObjectParameter(nameof (iDisplayLength), (object) iDisplayLength) : new ObjectParameter(nameof (iDisplayLength), typeof (int));
      ObjectParameter objectParameter3 = sSortingCol_delim != null ? new ObjectParameter(nameof (sSortingCol_delim), (object) sSortingCol_delim) : new ObjectParameter(nameof (sSortingCol_delim), typeof (string));
      ObjectParameter objectParameter4 = sSortingDir_delim != null ? new ObjectParameter(nameof (sSortingDir_delim), (object) sSortingDir_delim) : new ObjectParameter(nameof (sSortingDir_delim), typeof (string));
      ObjectParameter objectParameter5 = iSortingCols.HasValue ? new ObjectParameter(nameof (iSortingCols), (object) iSortingCols) : new ObjectParameter(nameof (iSortingCols), typeof (int));
      ObjectParameter objectParameter6 = sSearch != null ? new ObjectParameter(nameof (sSearch), (object) sSearch) : new ObjectParameter(nameof (sSearch), typeof (string));
      ObjectParameter objectParameter7 = sSearchableCol_delim != null ? new ObjectParameter(nameof (sSearchableCol_delim), (object) sSearchableCol_delim) : new ObjectParameter(nameof (sSearchableCol_delim), typeof (string));
      ObjectParameter objectParameter8 = iSearchableCols.HasValue ? new ObjectParameter(nameof (iSearchableCols), (object) iSearchableCols) : new ObjectParameter(nameof (iSearchableCols), typeof (int));
      ObjectParameter objectParameter9 = idProyecto != null ? new ObjectParameter("IdProyecto", (object) idProyecto) : new ObjectParameter("IdProyecto", typeof (string));
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (W_Sp_Pag_ProyectoTasks), new ObjectParameter[11]
      {
        objectParameter1,
        objectParameter2,
        objectParameter3,
        objectParameter4,
        objectParameter5,
        objectParameter6,
        objectParameter7,
        objectParameter8,
        iTotalRecords,
        iTotalDisplayRecords,
        objectParameter9
      });
    }

    public virtual int W_Sp_Pag_Requisiciones(
      int? iDisplayStart,
      int? iDisplayLength,
      string sSortingCol_delim,
      string sSortingDir_delim,
      int? iSortingCols,
      string sSearch,
      string sSearchableCol_delim,
      int? iSearchableCols,
      ObjectParameter iTotalRecords,
      ObjectParameter iTotalDisplayRecords,
      int? opcion)
    {
      ObjectParameter objectParameter1 = iDisplayStart.HasValue ? new ObjectParameter(nameof (iDisplayStart), (object) iDisplayStart) : new ObjectParameter(nameof (iDisplayStart), typeof (int));
      ObjectParameter objectParameter2 = iDisplayLength.HasValue ? new ObjectParameter(nameof (iDisplayLength), (object) iDisplayLength) : new ObjectParameter(nameof (iDisplayLength), typeof (int));
      ObjectParameter objectParameter3 = sSortingCol_delim != null ? new ObjectParameter(nameof (sSortingCol_delim), (object) sSortingCol_delim) : new ObjectParameter(nameof (sSortingCol_delim), typeof (string));
      ObjectParameter objectParameter4 = sSortingDir_delim != null ? new ObjectParameter(nameof (sSortingDir_delim), (object) sSortingDir_delim) : new ObjectParameter(nameof (sSortingDir_delim), typeof (string));
      ObjectParameter objectParameter5 = iSortingCols.HasValue ? new ObjectParameter(nameof (iSortingCols), (object) iSortingCols) : new ObjectParameter(nameof (iSortingCols), typeof (int));
      ObjectParameter objectParameter6 = sSearch != null ? new ObjectParameter(nameof (sSearch), (object) sSearch) : new ObjectParameter(nameof (sSearch), typeof (string));
      ObjectParameter objectParameter7 = sSearchableCol_delim != null ? new ObjectParameter(nameof (sSearchableCol_delim), (object) sSearchableCol_delim) : new ObjectParameter(nameof (sSearchableCol_delim), typeof (string));
      ObjectParameter objectParameter8 = iSearchableCols.HasValue ? new ObjectParameter(nameof (iSearchableCols), (object) iSearchableCols) : new ObjectParameter(nameof (iSearchableCols), typeof (int));
      ObjectParameter objectParameter9 = opcion.HasValue ? new ObjectParameter("Opcion", (object) opcion) : new ObjectParameter("Opcion", typeof (int));
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (W_Sp_Pag_Requisiciones), new ObjectParameter[11]
      {
        objectParameter1,
        objectParameter2,
        objectParameter3,
        objectParameter4,
        objectParameter5,
        objectParameter6,
        objectParameter7,
        objectParameter8,
        iTotalRecords,
        iTotalDisplayRecords,
        objectParameter9
      });
    }

    public virtual int W_Sp_Pag_Viaticos(
      int? iDisplayStart,
      int? iDisplayLength,
      string sSortingCol_delim,
      string sSortingDir_delim,
      int? iSortingCols,
      string sSearch,
      string sSearchableCol_delim,
      int? iSearchableCols,
      ObjectParameter iTotalRecords,
      ObjectParameter iTotalDisplayRecords,
      string opcion)
    {
      ObjectParameter objectParameter1 = iDisplayStart.HasValue ? new ObjectParameter(nameof (iDisplayStart), (object) iDisplayStart) : new ObjectParameter(nameof (iDisplayStart), typeof (int));
      ObjectParameter objectParameter2 = iDisplayLength.HasValue ? new ObjectParameter(nameof (iDisplayLength), (object) iDisplayLength) : new ObjectParameter(nameof (iDisplayLength), typeof (int));
      ObjectParameter objectParameter3 = sSortingCol_delim != null ? new ObjectParameter(nameof (sSortingCol_delim), (object) sSortingCol_delim) : new ObjectParameter(nameof (sSortingCol_delim), typeof (string));
      ObjectParameter objectParameter4 = sSortingDir_delim != null ? new ObjectParameter(nameof (sSortingDir_delim), (object) sSortingDir_delim) : new ObjectParameter(nameof (sSortingDir_delim), typeof (string));
      ObjectParameter objectParameter5 = iSortingCols.HasValue ? new ObjectParameter(nameof (iSortingCols), (object) iSortingCols) : new ObjectParameter(nameof (iSortingCols), typeof (int));
      ObjectParameter objectParameter6 = sSearch != null ? new ObjectParameter(nameof (sSearch), (object) sSearch) : new ObjectParameter(nameof (sSearch), typeof (string));
      ObjectParameter objectParameter7 = sSearchableCol_delim != null ? new ObjectParameter(nameof (sSearchableCol_delim), (object) sSearchableCol_delim) : new ObjectParameter(nameof (sSearchableCol_delim), typeof (string));
      ObjectParameter objectParameter8 = iSearchableCols.HasValue ? new ObjectParameter(nameof (iSearchableCols), (object) iSearchableCols) : new ObjectParameter(nameof (iSearchableCols), typeof (int));
      ObjectParameter objectParameter9 = opcion != null ? new ObjectParameter("Opcion", (object) opcion) : new ObjectParameter("Opcion", typeof (string));
      return ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (W_Sp_Pag_Viaticos), new ObjectParameter[11]
      {
        objectParameter1,
        objectParameter2,
        objectParameter3,
        objectParameter4,
        objectParameter5,
        objectParameter6,
        objectParameter7,
        objectParameter8,
        iTotalRecords,
        iTotalDisplayRecords,
        objectParameter9
      });
    }

    public virtual int sp_ReporteProyectosEficiencias() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction(nameof (sp_ReporteProyectosEficiencias), new ObjectParameter[0]);

    public virtual ObjectResult<sp_ReporteProyectosEficienciasVistas_Result> sp_ReporteProyectosEficienciasVistas() => ((IObjectContextAdapter) this).ObjectContext.ExecuteFunction<sp_ReporteProyectosEficienciasVistas_Result>(nameof (sp_ReporteProyectosEficienciasVistas), new ObjectParameter[0]);
  }
}
