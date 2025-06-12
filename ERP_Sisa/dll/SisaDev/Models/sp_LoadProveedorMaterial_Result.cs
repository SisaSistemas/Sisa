// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.sp_LoadProveedorMaterial_Result
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class sp_LoadProveedorMaterial_Result
  {
    public Guid IdProveedorMaterial { get; set; }

    public Guid IdProveedor { get; set; }

    public string Proveedor { get; set; }

    public string Contacto { get; set; }

    public string Email { get; set; }

    public string Telefono1 { get; set; }

    public string UnidadMedida { get; set; }

    public Decimal Precio { get; set; }

    public string Abreviatura { get; set; }

    public Guid IdMoneda { get; set; }

    public string Codigo { get; set; }

    public string Descripcion { get; set; }

    public DateTime FechaModificacion { get; set; }

    public string Usuario { get; set; }

    public string NombreComercial { get; set; }
  }
}
