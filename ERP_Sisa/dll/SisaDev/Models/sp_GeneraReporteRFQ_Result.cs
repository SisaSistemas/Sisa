// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.sp_GeneraReporteRFQ_Result
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class sp_GeneraReporteRFQ_Result
  {
    public Guid IdRfq { get; set; }

    public string Folio { get; set; }

    public string Round { get; set; }

    public string Fecha { get; set; }

    public DateTime FechaVencimiento { get; set; }

    public Guid IdCliente { get; set; }

    public string FolioRQ { get; set; }

    public Guid IdComprador { get; set; }

    public Guid? IdCotizacion { get; set; }

    public string ArchivoRFQ { get; set; }

    public int Estatus { get; set; }

    public Guid IdUsuarioAlta { get; set; }

    public DateTime FechaAlta { get; set; }

    public Guid IdUsuarioModificar { get; set; }

    public DateTime FechaModificacion { get; set; }

    public string Descripcion { get; set; }

    public Guid? idVendedor { get; set; }

    public Guid? idCoordinador { get; set; }

    public string Seguimiento { get; set; }

    public Guid idContacto { get; set; }

    public Guid idEmpresa { get; set; }

    public string NombreContacto { get; set; }

    public string Telefono { get; set; }

    public string Foto { get; set; }

    public string Correo { get; set; }

    public string TIMESTAMP { get; set; }

    public bool Estatus1 { get; set; }

    public string Usuario { get; set; }

    public string Clave { get; set; }

    public Guid idEmpresa1 { get; set; }

    public string RazonSocial { get; set; }

    public string DireccionFiscal { get; set; }

    public string Telefono1 { get; set; }

    public DateTime TIMESTAMP1 { get; set; }

    public string RFC { get; set; }

    public string Correo1 { get; set; }

    public int CP { get; set; }

    public string Ciudad { get; set; }

    public bool? Estatus2 { get; set; }

    public Guid? idSucursalRegistro { get; set; }

    public string Cliente { get; set; }

    public Guid IdUsuario { get; set; }

    public string NombreCompleto { get; set; }

    public string Usuario1 { get; set; }

    public string Contrasena { get; set; }

    public string Foto1 { get; set; }

    public int? Permisos { get; set; }

    public string Puesto { get; set; }

    public string Telefono2 { get; set; }

    public string Correo2 { get; set; }

    public DateTime? FechaAlta1 { get; set; }

    public Guid? IdUsuarioModificacion { get; set; }

    public DateTime? FechaModificacion1 { get; set; }

    public int? Activo { get; set; }

    public int? EsLiderProyecto { get; set; }

    public string Perfil { get; set; }

    public Decimal? SueldoDiario { get; set; }

    public Guid? idSucursal { get; set; }
  }
}
