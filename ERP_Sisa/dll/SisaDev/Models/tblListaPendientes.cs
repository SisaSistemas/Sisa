// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblListaPendientes
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblListaPendientes
  {
    public Guid IdListaPendientes { get; set; }

    public Guid IdUsuario { get; set; }

    public string Pendiente { get; set; }

    public int Completado { get; set; }

    public DateTime FechaAlta { get; set; }

    public DateTime FechaCompletado { get; set; }
  }
}
