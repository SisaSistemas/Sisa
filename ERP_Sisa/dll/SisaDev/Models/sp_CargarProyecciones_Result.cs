// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.sp_CargarProyecciones_Result
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class sp_CargarProyecciones_Result
  {
    public double? CostoMaterialCotizado { get; set; }

    public double? CostoMOCotizado { get; set; }

    public double? CostoMECotizado { get; set; }

    public double? CostoMaterialProyectado { get; set; }

    public double? CostoMEProyectado { get; set; }

    public double? CostoMOProyectado { get; set; }

    public Decimal? ManoObra { get; set; }

    public Decimal? Equipo { get; set; }

    public Decimal? Material { get; set; }
  }
}
