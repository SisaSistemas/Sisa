// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.sp_CargarCotizacionesReporte_Result
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class sp_CargarCotizacionesReporte_Result
  {
    public Guid IdCotizaciones { get; set; }

    public DateTime FechaCotizaciones { get; set; }

    public string NoCotizaciones { get; set; }

    public string Concepto { get; set; }

    public string NoCotizaciones1 { get; set; }

    public string Ciudad { get; set; }

    public Decimal? CostoCotizaciones { get; set; }

    public string Correo { get; set; }

    public string Creo { get; set; }

    public string NombreContacto { get; set; }

    public string RazonSocial { get; set; }

    public string DireccionFiscal { get; set; }
  }
}
