// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.sp_CargarCotizacionesReporteDetalles_Result
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class sp_CargarCotizacionesReporteDetalles_Result
  {
    public long? Item { get; set; }

    public string Descripcion { get; set; }

    public Decimal? Cantidad { get; set; }

    public Decimal? Precio { get; set; }

    public Decimal? Importe { get; set; }

    public string Unidad { get; set; }
  }
}
