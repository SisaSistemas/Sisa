// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.sp_ObtenerDatosControlFacturas_Result
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class sp_ObtenerDatosControlFacturas_Result
  {
    public Guid IdControlFacturas { get; set; }

    public string FechaFactura { get; set; }

    public Guid IdProveedor { get; set; }

    public string NoFactura { get; set; }

    public string OrdenCompra { get; set; }

    public string IdProyecto { get; set; }

    public string Proyecto { get; set; }

    public string Moneda { get; set; }

    public Decimal SubTotal { get; set; }

    public Decimal Descuento { get; set; }

    public Decimal IVA { get; set; }

    public Decimal Total { get; set; }

    public int Estatus { get; set; }

    public string FormaPago { get; set; }

    public int? Viaticos { get; set; }
  }
}
