// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblClienteContacto
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblClienteContacto
  {
    public Guid idContacto { get; set; }

    public Guid idEmpresa { get; set; }

    public string NombreContacto { get; set; }

    public string Telefono { get; set; }

    public string Foto { get; set; }

    public string Correo { get; set; }

    public string TIMESTAMP { get; set; }

    public bool Estatus { get; set; }

    public string Usuario { get; set; }

    public string Clave { get; set; }

    public string Imagen { get; set; }

    public string NombreImagen { get; set; }
  }
}
