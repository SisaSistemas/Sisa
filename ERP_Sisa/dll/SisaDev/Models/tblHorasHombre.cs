// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblHorasHombre
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblHorasHombre
  {
    public Guid IdHorasHombre { get; set; }

    public Guid IdProyecto { get; set; }

    public Guid IdUsuario { get; set; }

    public int Lunes { get; set; }

    public int Martes { get; set; }

    public int Miercoles { get; set; }

    public int Jueves { get; set; }

    public int Viernes { get; set; }

    public int Sabado { get; set; }

    public int Domingo { get; set; }

    public int? Total { get; set; }

    public int Activo { get; set; }

    public DateTime? FechaAlta { get; set; }
  }
}
