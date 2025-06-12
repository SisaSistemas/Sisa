// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.sp_ObtenerDatosFacturasEmitidas_Result
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class sp_ObtenerDatosFacturasEmitidas_Result
  {
    public Guid IdFacturasEmitidas { get; set; }

    public string FolioFactura { get; set; }

    public string FechaFactura { get; set; }

    public string RfcReceptor { get; set; }

    public string NombreReceptor { get; set; }

    public string IdProyecto { get; set; }

    public string NoCotizacion { get; set; }

    public string OrdenCompraRecibida { get; set; }

    public Decimal SubTotal { get; set; }

    public Decimal Iva { get; set; }

    public Decimal Total { get; set; }

    public int Moneda { get; set; }

    public DateTime? ProgramacionPago { get; set; }

    public Decimal? PorPagar { get; set; }

    public DateTime? FechaPago { get; set; }

    public int Estatus { get; set; }

    public Decimal? TipoCambio { get; set; }
  }
}
