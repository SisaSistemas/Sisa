// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblOrdenCompraComentarios
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblOrdenCompraComentarios
  {
    public Guid IdComentarioOC { get; set; }

    public Guid IdOrdenCompra { get; set; }

    public string Comentario { get; set; }

    public Guid IdUsuario { get; set; }

    public DateTime FechaComentario { get; set; }
  }
}
