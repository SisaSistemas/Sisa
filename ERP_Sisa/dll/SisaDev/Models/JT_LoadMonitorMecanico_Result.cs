// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.JT_LoadMonitorMecanico_Result
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class JT_LoadMonitorMecanico_Result
  {
    public Guid IdMaquinado { get; set; }

    public Guid IdProyecto { get; set; }

    public string NombreProyecto { get; set; }

    public string NoParte { get; set; }

    public string FechaOC { get; set; }

    public string FechaEntrega { get; set; }

    public string EncargadoProyecto { get; set; }

    public string Disenador { get; set; }

    public string QuienHizo { get; set; }

    public int HorasMaquina { get; set; }

    public int CantidadPzas { get; set; }

    public int Estatus { get; set; }

    public string NomArchivoDiseno { get; set; }

    public string NomArchivoMasterCam { get; set; }
  }
}
