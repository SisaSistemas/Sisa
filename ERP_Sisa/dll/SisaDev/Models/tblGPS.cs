// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblGPS
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblGPS
  {
    public int IdLocation { get; set; }

    public string ID { get; set; }

    public Decimal Latitud { get; set; }

    public Decimal Longitud { get; set; }

    public DateTime Fecha { get; set; }
  }
}
