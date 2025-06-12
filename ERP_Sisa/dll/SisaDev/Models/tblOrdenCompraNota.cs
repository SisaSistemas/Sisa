// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblOrdenCompraNota
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblOrdenCompraNota
  {
    public Guid IdOrdenCompraNota { get; set; }

    public Guid IdOdenCompra { get; set; }

    public int Item { get; set; }

    public string NotaAclaratoria { get; set; }
  }
}
