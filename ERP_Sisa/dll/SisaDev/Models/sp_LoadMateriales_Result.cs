// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.sp_LoadMateriales_Result
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class sp_LoadMateriales_Result
  {
    public Guid IdMaterial { get; set; }

    public string Codigo { get; set; }

    public string Descripcion { get; set; }

    public string Buscador { get; set; }

    public string Usuario { get; set; }

    public int Activo { get; set; }

    public DateTime FechaAlta { get; set; }

    public DateTime FechaModificacion { get; set; }

    public string Categoria { get; set; }
  }
}
