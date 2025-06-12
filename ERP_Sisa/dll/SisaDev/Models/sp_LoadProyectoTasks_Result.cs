// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.sp_LoadProyectoTasks_Result
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class sp_LoadProyectoTasks_Result
  {
    public Guid IdProyecto { get; set; }

    public string NombreProyecto { get; set; }

    public int TotalTask { get; set; }

    public int FinalizadosTask { get; set; }

    public Decimal? Porcentaje { get; set; }
  }
}
