// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblPermisos
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblPermisos
  {
    public int IdPermiso { get; set; }

    public Guid Identificador { get; set; }

    public Guid IdUsuario { get; set; }

    public int IdMenu { get; set; }

    public int Visible { get; set; }
  }
}
