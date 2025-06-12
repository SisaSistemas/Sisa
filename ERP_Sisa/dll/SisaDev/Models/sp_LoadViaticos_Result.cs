// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.sp_LoadViaticos_Result
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class sp_LoadViaticos_Result
  {
    public long? ID { get; set; }

    public Guid IdDet { get; set; }

    public Guid IdViaticos { get; set; }

    public DateTime FechaViaticos { get; set; }

    public Decimal Gasolina { get; set; }

    public Decimal Desayuno { get; set; }

    public Decimal Comida { get; set; }

    public Decimal Cena { get; set; }

    public Decimal Casetas { get; set; }

    public Decimal Hotel { get; set; }

    public Decimal Transporte { get; set; }

    public Decimal Otros { get; set; }

    public string Descripcion { get; set; }

    public string Ticket { get; set; }

    public Decimal? ManoObra { get; set; }

    public Decimal? Equipo { get; set; }

    public Decimal? Materiales { get; set; }

    public Decimal CantEntregada { get; set; }

    public Decimal CantGastada { get; set; }

    public Decimal? Diferencia { get; set; }

    public string NombreProyecto { get; set; }

    public Guid? IdProyecto { get; set; }

    public string NombreCompleto { get; set; }

    public string ProyectoOtorga { get; set; }

    public Guid? idProyectoOtorga { get; set; }
  }
}
