// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblMatrizMecanico
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblMatrizMecanico
  {
    public Guid IdMaquinado { get; set; }

    public Guid IdProyecto { get; set; }

    public string NombreProyecto { get; set; }

    public string NoParte { get; set; }

    public DateTime FechaOC { get; set; }

    public DateTime FechaEntrega { get; set; }

    public Guid? IdDiseno { get; set; }

    public Guid? IdMasterCam { get; set; }

    public int Estatus { get; set; }

    public Guid IdEncargadoProyecto { get; set; }

    public Guid IdDisenador { get; set; }

    public Guid IdQuienHizo { get; set; }

    public string Observaciones { get; set; }

    public int HorasMaquina { get; set; }

    public int CantidadPzas { get; set; }

    public DateTime FechaAlta { get; set; }

    public DateTime? FechaTermino { get; set; }

    public DateTime? FechaInicio { get; set; }
  }
}
