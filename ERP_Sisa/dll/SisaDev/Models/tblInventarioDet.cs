// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblInventarioDet
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblInventarioDet
  {
    public int idHDet { get; set; }

    public int? idHerramienta { get; set; }

    public DateTime? Fecha { get; set; }

    public Decimal? Entrada { get; set; }

    public Decimal? Salida { get; set; }

    public Guid? idUsuario { get; set; }
  }
}
