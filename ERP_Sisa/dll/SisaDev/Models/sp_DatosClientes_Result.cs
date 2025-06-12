// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.sp_DatosClientes_Result
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class sp_DatosClientes_Result
  {
    public Guid IdCliente { get; set; }

    public string RazonSocial { get; set; }

    public string TelefonoEmpresa { get; set; }

    public string Contacto { get; set; }

    public string Celular { get; set; }

    public string Email { get; set; }

    public string Direccion { get; set; }
  }
}
