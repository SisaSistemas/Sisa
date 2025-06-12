// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.CargarEficiencias_Result
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class CargarEficiencias_Result
  {
    public Decimal? ManoObra { get; set; }

    public Decimal? Material { get; set; }

    public Decimal? Equipo { get; set; }

    public Decimal? MOPorcentaje { get; set; }

    public Decimal? MPorcentaje { get; set; }

    public Decimal? EPorcentaje { get; set; }

    public double? MEficientia { get; set; }

    public double? EEficientia { get; set; }

    public double? MOEficientia { get; set; }
  }
}
