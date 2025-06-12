// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblProveedoresContactos
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblProveedoresContactos
  {
    public Guid IdProveedorContacto { get; set; }

    public Guid IdProveedor { get; set; }

    public string NombreContacto { get; set; }

    public string Telefono { get; set; }

    public string Email { get; set; }

    public string Departamento { get; set; }
  }
}
