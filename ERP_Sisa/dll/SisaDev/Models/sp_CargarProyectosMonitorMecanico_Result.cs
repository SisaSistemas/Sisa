// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.sp_CargarProyectosMonitorMecanico_Result
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class sp_CargarProyectosMonitorMecanico_Result
  {
    public Guid IdProyecto { get; set; }

    public string NombreProyecto { get; set; }

    public string Descripcion { get; set; }

    public string RazonSocial { get; set; }

    public string Contacto { get; set; }

    public string Estatus { get; set; }
  }
}
