// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.spBuscarMaterialXId_Result
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class spBuscarMaterialXId_Result
  {
    public Guid IdMaterial { get; set; }

    public string Codigo { get; set; }

    public string Descripcion { get; set; }

    public Guid IdCategoria { get; set; }

    public string Buscador { get; set; }

    public int Activo { get; set; }
  }
}
