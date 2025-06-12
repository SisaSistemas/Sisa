// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblRecuperaciones
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblRecuperaciones
  {
    public int id { get; set; }

    public DateTime fecha { get; set; }

    public string Usuario { get; set; }

    public string Codigo { get; set; }

    public bool Estatus { get; set; }

    public Guid idUsuario { get; set; }

    public string Correo { get; set; }
  }
}
