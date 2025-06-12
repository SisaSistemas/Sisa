// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblDatosEmpresa
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblDatosEmpresa
  {
    public Guid IdDatos { get; set; }

    public Decimal TipoCambio { get; set; }

    public Decimal IvaFrontera { get; set; }

    public Decimal IvaInterior { get; set; }
  }
}
