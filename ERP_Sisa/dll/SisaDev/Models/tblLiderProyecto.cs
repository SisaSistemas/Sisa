// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblLiderProyecto
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblLiderProyecto
  {
    public Guid IdLider { get; set; }

    public string NombreLider { get; set; }

    public string Foto { get; set; }

    public int Activo { get; set; }

    public DateTime FechaAlta { get; set; }

    public DateTime FechaModificacion { get; set; }
  }
}
