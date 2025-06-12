// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.sp_CargarDetalleGrafica_Result
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class sp_CargarDetalleGrafica_Result
  {
    public string FechaViaticos { get; set; }

    public Decimal Gasolina { get; set; }

    public Decimal Desayuno { get; set; }

    public Decimal Comida { get; set; }

    public Decimal Cena { get; set; }

    public Decimal Casetas { get; set; }

    public Decimal Hotel { get; set; }

    public Decimal Transporte { get; set; }

    public Decimal Otros { get; set; }

    public string Descripcion { get; set; }

    public string FechaFactura { get; set; }

    public string NoFactura { get; set; }

    public string NombreComercial { get; set; }

    public string OrdenCompra { get; set; }

    public Decimal? SubTotal { get; set; }

    public Decimal? Iva { get; set; }

    public Decimal? Total { get; set; }

    public string FechaGasto { get; set; }

    public string Responsable { get; set; }

    public string Concepto { get; set; }

    public string Comprobante { get; set; }

    public string Folio { get; set; }

    public string ReferenciaCot { get; set; }

    public string Fecha { get; set; }

    public string IdHorasHombre { get; set; }

    public string IdProyecto { get; set; }

    public string IdUsuario { get; set; }

    public string FolioProyecto { get; set; }

    public string NombreProyecto { get; set; }

    public string NombreCompleto { get; set; }
  }
}
