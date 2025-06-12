// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.sp_CargarFacturasEmitidas_Result
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class sp_CargarFacturasEmitidas_Result
  {
    public Guid IdFacturasEmitidas { get; set; }

    public string FolioFactura { get; set; }

    public DateTime FechaFactura { get; set; }

    public string RfcReceptor { get; set; }

    public string NombreReceptor { get; set; }

    public string NombreProyecto { get; set; }

    public string NoCotizacion { get; set; }

    public string OrdenCompraRecibida { get; set; }

    public Decimal SubTotal { get; set; }

    public Decimal Iva { get; set; }

    public Decimal? Retencion { get; set; }

    public Decimal Total { get; set; }

    public string Moneda { get; set; }

    public DateTime ProgramacionPago { get; set; }

    public Decimal? PorPagar { get; set; }

    public DateTime FechaPago { get; set; }

    public int Estatus { get; set; }

    public string IdProyecto { get; set; }

    public string ProgramacionPago1 { get; set; }

    public string Estatus1 { get; set; }

    public string FechaFactura1 { get; set; }

    public string FechaPago1 { get; set; }

    public string NombreArchivo { get; set; }

    public string ArchivoPDF { get; set; }
  }
}
