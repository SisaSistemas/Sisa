// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.sp_LoadCitasPendientes_Result
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class sp_LoadCitasPendientes_Result
  {
    public Guid IdCalendario { get; set; }

    public string Titulo { get; set; }

    public string Descripcion { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFinal { get; set; }

    public bool TodoDia { get; set; }

    public Guid IdUsuario { get; set; }

    public DateTime FechaAlta { get; set; }

    public DateTime FechaModificacion { get; set; }

    public string Mes { get; set; }

    public string Dia { get; set; }

    public string Hora { get; set; }
  }
}
