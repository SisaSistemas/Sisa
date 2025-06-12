// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.sp_CargarCotizaciones_Result
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class sp_CargarCotizaciones_Result
  {
    public Guid IdCotizaciones { get; set; }

    public DateTime FechaCotizaciones { get; set; }

    public string NoCotizaciones { get; set; }

    public string NombreContacto { get; set; }

    public string RazonSocial { get; set; }

    public string Concepto { get; set; }

    public string HechaPor { get; set; }

    public string EnviadaPor { get; set; }

    public int Estatus { get; set; }

    public Decimal? CostoCotizaciones { get; set; }

    public string NombreArchivoPdf { get; set; }

    public string Correo { get; set; }

    public string RFQ { get; set; }

    public Guid? IdUsuarioCreo { get; set; }

    public Guid? IdUsuarioEnvia { get; set; }
  }
}
