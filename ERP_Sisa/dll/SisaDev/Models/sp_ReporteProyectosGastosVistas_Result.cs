// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.sp_ReporteProyectosGastosVistas_Result
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class sp_ReporteProyectosGastosVistas_Result
  {
    public int id { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string Folio { get; set; }

    public string FechaInicio { get; set; }

    public string FechaFin { get; set; }

    public string Lider { get; set; }

    public string NombreProyecto { get; set; }

    public string Estatus { get; set; }

    public Decimal? CostoCotizacion { get; set; }

    public string RazonSocial { get; set; }

    public string NombreContacto { get; set; }

    public string OC { get; set; }

    public string CL { get; set; }

    public Decimal? Facturado { get; set; }

    public Decimal? Porcentaje { get; set; }

    public Decimal? Pagado { get; set; }

    public Decimal? PorcentajePagado { get; set; }

    public Decimal? Gastos { get; set; }

    public Decimal? OCNumero { get; set; }

    public Decimal? OCPend { get; set; }

    public Decimal? Facturas { get; set; }

    public Decimal? ManoObra { get; set; }

    public Decimal? Viaticos { get; set; }

    public Decimal? CajaChica { get; set; }
  }
}
