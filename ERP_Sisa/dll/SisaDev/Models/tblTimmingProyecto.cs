// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblTimmingProyecto
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblTimmingProyecto
  {
    public Guid IdTimming { get; set; }

    public string NombreProyecto { get; set; }

    public string Actividad { get; set; }

    public string Tarea { get; set; }

    public string FechaInicio { get; set; }

    public string FechaFin { get; set; }

    public string Persona { get; set; }

    public string DiasTrans { get; set; }

    public Decimal? Avance { get; set; }

    public DateTime? FechaAlta { get; set; }

    public Guid? IdUsuarioAlta { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public Guid? IdUsuarioModificacion { get; set; }
  }
}
