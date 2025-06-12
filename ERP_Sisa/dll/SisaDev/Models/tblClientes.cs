// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblClientes
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblClientes
  {
    public Guid IdCliente { get; set; }

    public string RazonSocial { get; set; }

    public string Contacto { get; set; }

    public string Email { get; set; }

    public string Departamento { get; set; }

    public string TelefonoEmpresa { get; set; }

    public string Celular { get; set; }

    public string UsuarioCliente { get; set; }

    public string ContrasenaCliente { get; set; }

    public string MapaCoordenadas { get; set; }

    public string Logotipo { get; set; }

    public string Direccion { get; set; }

    public Guid IdUsuarioAlta { get; set; }

    public DateTime FechaAlta { get; set; }

    public Guid IdUsuarioModificacion { get; set; }

    public DateTime FechaModificacion { get; set; }

    public int Activo { get; set; }

    public Guid idEmpresa { get; set; }
  }
}
