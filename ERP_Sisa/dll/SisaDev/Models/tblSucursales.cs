// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblSucursales
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblSucursales
  {
    public Guid idSucursa { get; set; }

    public string CiudadSucursal { get; set; }

    public string DireccionSucursal { get; set; }

    public string TelefonoSucursal { get; set; }

    public DateTime? TIMESTAMP { get; set; }

    public bool? Estatus { get; set; }

    public string Gerente { get; set; }
  }
}
