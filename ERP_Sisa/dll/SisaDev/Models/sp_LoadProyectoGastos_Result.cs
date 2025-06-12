// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.sp_LoadProyectoGastos_Result
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class sp_LoadProyectoGastos_Result
  {
    public long? ID { get; set; }

    public string NoFactura { get; set; }

    public string TipoGasto { get; set; }

    public string Descripcion { get; set; }

    public Decimal Importe { get; set; }

    public Decimal IVA { get; set; }

    public Decimal Total { get; set; }

    public string FechaGasto { get; set; }
  }
}
