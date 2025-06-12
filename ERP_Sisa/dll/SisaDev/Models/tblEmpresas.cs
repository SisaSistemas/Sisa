// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblEmpresas
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblEmpresas
  {
    public Guid idEmpresa { get; set; }

    public string RazonSocial { get; set; }

    public string DireccionFiscal { get; set; }

    public string Telefono { get; set; }

    public DateTime TIMESTAMP { get; set; }

    public string RFC { get; set; }

    public string Correo { get; set; }

    public int CP { get; set; }

    public string Ciudad { get; set; }

    public bool? Estatus { get; set; }

    public Guid? idSucursalRegistro { get; set; }

    public string Cliente { get; set; }
  }
}
