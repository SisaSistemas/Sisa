// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblInventario
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblInventario
  {
    public int IdHerramienta { get; set; }

    public string NoCodigo { get; set; }

    public string Descripcion { get; set; }

    public string Tipo { get; set; }

    public string NoSerie { get; set; }

    public string Observaciones { get; set; }

    public int Contenedor { get; set; }

    public bool Estatus { get; set; }

    public Decimal Entradas { get; set; }

    public Decimal Salidas { get; set; }

    public Decimal TotalAlmacen { get; set; }
  }
}
