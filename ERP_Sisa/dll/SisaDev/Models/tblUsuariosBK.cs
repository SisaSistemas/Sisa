// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblUsuariosBK
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblUsuariosBK
  {
    public int IdUsuario { get; set; }

    public string NombreCompleto { get; set; }

    public string Usuario { get; set; }

    public string Contrasena { get; set; }

    public string Foto { get; set; }

    public int Permisos { get; set; }

    public string Puesto { get; set; }

    public string Telefono { get; set; }

    public string Correo { get; set; }

    public DateTime FechaAlta { get; set; }

    public int IdUsuarioModificacion { get; set; }

    public DateTime FechaModificacion { get; set; }

    public int Activo { get; set; }

    public int? EsLiderProyecto { get; set; }

    public string Perfil { get; set; }
  }
}
