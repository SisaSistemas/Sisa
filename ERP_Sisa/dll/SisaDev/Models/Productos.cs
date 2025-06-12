// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.Productos
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class Productos
  {
    public Guid ID { get; set; }

    public string Nombre { get; set; }

    public Decimal? Precio { get; set; }

    public bool Eliminado { get; set; }

    public DateTime ModificadoEn { get; set; }
  }
}
