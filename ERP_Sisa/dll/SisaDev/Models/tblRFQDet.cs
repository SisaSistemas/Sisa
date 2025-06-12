// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblRFQDet
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblRFQDet
  {
    public Guid IdRFQDet { get; set; }

    public Guid IdRfq { get; set; }

    public int Item { get; set; }

    public string Descripcion { get; set; }

    public int Cantidad { get; set; }

    public string Unidad { get; set; }

    public string NumeroParte { get; set; }

    public string Marca { get; set; }

    public bool? Estatus { get; set; }

    public DateTime? TimeStamp { get; set; }
  }
}
