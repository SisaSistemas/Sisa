// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.sp_SelectEventosCalendario_Result
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class sp_SelectEventosCalendario_Result
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

    public int? AnioInicio { get; set; }

    public int? MesInicio { get; set; }

    public int? DiaInicio { get; set; }

    public int? HoraInicio { get; set; }

    public string MinutosInicio { get; set; }

    public int? AnioFin { get; set; }

    public int? MesFin { get; set; }

    public int? DiaFin { get; set; }

    public int? HoraFin { get; set; }

    public string MinutosFin { get; set; }
  }
}
