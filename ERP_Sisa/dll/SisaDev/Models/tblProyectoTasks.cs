// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblProyectoTasks
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblProyectoTasks
  {
    public Guid IdTask { get; set; }

    public Guid IdProyecto { get; set; }

    public string Task { get; set; }

    public Guid? IdUsuario { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }

    public string Comentarios { get; set; }

    public int Estatus { get; set; }

    public Guid IdUsuarioAlta { get; set; }

    public DateTime FechaAlta { get; set; }

    public Guid? IdUsuarioModificacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public Decimal? Porcentaje { get; set; }
  }
}
