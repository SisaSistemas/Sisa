// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblCotizacionesDet
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblCotizacionesDet
  {
    public Guid idCotDetalle { get; set; }

    public Guid? idCotizacion { get; set; }

    public DateTime? TimeStamp { get; set; }

    public string Descripcion { get; set; }

    public Decimal? Cantidad { get; set; }

    public Decimal? Precio { get; set; }

    public Decimal? Importe { get; set; }

    public string Unidad { get; set; }

    public Guid? idUsuarioAlta { get; set; }

    public int? Estatus { get; set; }
  }
}
