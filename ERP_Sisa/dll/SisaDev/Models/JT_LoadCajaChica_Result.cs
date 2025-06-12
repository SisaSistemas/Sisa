// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.JT_LoadCajaChica_Result
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class JT_LoadCajaChica_Result
  {
    public Guid IdCajaChica { get; set; }

    public string Responsable { get; set; }

    public string Concepto { get; set; }

    public string Proyecto { get; set; }

    public string Comprobante { get; set; }

    public Decimal Cargo { get; set; }

    public Decimal Abono { get; set; }

    public Decimal Saldo { get; set; }

    public DateTime Fecha { get; set; }

    public int? Estatus { get; set; }

    public string IdProyecto { get; set; }

    public string Categoria { get; set; }

    public string CampoExtra { get; set; }
  }
}
