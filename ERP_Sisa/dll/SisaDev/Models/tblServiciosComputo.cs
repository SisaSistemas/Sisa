// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblServiciosComputo
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblServiciosComputo
  {
    public Guid IdComputo { get; set; }

    public string PC { get; set; }

    public string Tipo { get; set; }

    public string Comentarios { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaAlta { get; set; }

    public Guid IdUsuario { get; set; }

    public DateTime FechaModificacion { get; set; }

    public Guid IdUsuarioModificacion { get; set; }

    public string Serie { get; set; }

    public DateTime? FechaProximoMantenimiento { get; set; }

    public string Usuario { get; set; }
  }
}
