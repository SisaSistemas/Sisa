// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.spBuscarProveedorXId_Result
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class spBuscarProveedorXId_Result
  {
    public Guid IdProveedor { get; set; }

    public string Proveedor { get; set; }

    public string Contacto { get; set; }

    public string Domicilio { get; set; }

    public string Coordenadas { get; set; }

    public string Email { get; set; }

    public string Telefono1 { get; set; }

    public string Telefono2 { get; set; }

    public string Giro { get; set; }

    public string Comentarios { get; set; }

    public string Imagen { get; set; }

    public string NombreComercial { get; set; }

    public int? Contactos { get; set; }
  }
}
