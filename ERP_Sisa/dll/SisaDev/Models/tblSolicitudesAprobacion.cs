// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblSolicitudesAprobacion
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblSolicitudesAprobacion
  {
    public int idSolicitud { get; set; }

    public string UsuarioSolicita { get; set; }

    public string idUsuarioSolicita { get; set; }

    public DateTime timestamp { get; set; }

    public bool Estatus { get; set; }

    public string CondicionEstatus { get; set; }

    public string Comentarios { get; set; }

    public Guid idDocumento { get; set; }

    public string Tipo { get; set; }

    public Guid? idUsuarioAprobo { get; set; }

    public string usuarioAprobo { get; set; }
  }
}
