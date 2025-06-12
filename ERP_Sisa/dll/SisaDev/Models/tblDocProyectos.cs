// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblDocProyectos
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblDocProyectos
  {
    public Guid IdDocumento { get; set; }

    public Guid IdProyecto { get; set; }

    public string FileName { get; set; }

    public string File { get; set; }

    public DateTime Fecha { get; set; }
  }
}
