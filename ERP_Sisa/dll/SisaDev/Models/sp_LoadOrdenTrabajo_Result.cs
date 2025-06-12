// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.sp_LoadOrdenTrabajo_Result
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class sp_LoadOrdenTrabajo_Result
  {
    public Guid IdOrdenTrabajo { get; set; }

    public string FolioOrden { get; set; }

    public Guid IdProyecto { get; set; }

    public string NombreProyecto { get; set; }

    public string NombreCompleto { get; set; }

    public string FechaPruebas { get; set; }

    public string FechaEntrega { get; set; }

    public DateTime FechaAlta { get; set; }
  }
}
