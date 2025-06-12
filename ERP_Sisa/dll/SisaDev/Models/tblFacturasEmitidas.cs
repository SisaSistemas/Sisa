// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblFacturasEmitidas
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblFacturasEmitidas
  {
    public Guid IdFacturasEmitidas { get; set; }

    public string FolioFactura { get; set; }

    public DateTime FechaFactura { get; set; }

    public string RfcReceptor { get; set; }

    public string NombreReceptor { get; set; }

    public string IdProyecto { get; set; }

    public string NoCotizacion { get; set; }

    public string OrdenCompraRecibida { get; set; }

    public Decimal SubTotal { get; set; }

    public Decimal Iva { get; set; }

    public Decimal Total { get; set; }

    public string Moneda { get; set; }

    public DateTime? ProgramacionPago { get; set; }

    public Decimal? PorPagar { get; set; }

    public DateTime? FechaPago { get; set; }

    public int Estatus { get; set; }

    public Decimal? TipoCambio { get; set; }

    public Guid? IdUsuario { get; set; }

    public DateTime? FechaAlta { get; set; }

    public Guid? IdUsuarioModificacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public Decimal? Retencion { get; set; }

    public string NombreArchivo { get; set; }

    public string ArchivoPDF { get; set; }
  }
}
