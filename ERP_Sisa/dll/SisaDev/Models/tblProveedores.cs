// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblProveedores
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblProveedores
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

    public DateTime FechaAlta { get; set; }

    public Guid IdUsuarioAlta { get; set; }

    public DateTime FechaModificacion { get; set; }

    public Guid IdUsuarioModifica { get; set; }

    public int Activo { get; set; }

    public string NombreComercial { get; set; }

    public int? DiasCredito { get; set; }

    public Guid? idSucursal { get; set; }

    public string RFC { get; set; }
  }
}
