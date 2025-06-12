// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblUnidadMedida
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblUnidadMedida
  {
    public Guid IdUnidadMedida { get; set; }

    public string Descripcion { get; set; }

    public string DescCorta { get; set; }

    public int Activo { get; set; }

    public DateTime FechaAlta { get; set; }

    public Guid IdUsuarioAlta { get; set; }

    public DateTime FechaModificacion { get; set; }

    public Guid IdUsuarioModificacion { get; set; }
  }
}
