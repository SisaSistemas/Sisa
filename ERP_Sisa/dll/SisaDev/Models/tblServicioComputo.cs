// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblServicioComputo
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblServicioComputo
  {
    public Guid IdServicioComputo { get; set; }

    public Guid IdUsuario { get; set; }

    public string Tipo { get; set; }

    public string Marca { get; set; }

    public string Modelo { get; set; }

    public string NoSerie { get; set; }

    public string Comentarios { get; set; }

    public DateTime FechaMantenimiento { get; set; }

    public DateTime FechaProximoMantenimiento { get; set; }

    public int Completado { get; set; }
  }
}
