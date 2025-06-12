// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblVehiculoServicio
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblVehiculoServicio
  {
    public Guid IdServicioVehiculo { get; set; }

    public Guid IdCarro { get; set; }

    public int KilometrajeActual { get; set; }

    public string Taller { get; set; }

    public int KilometrajeProximo { get; set; }

    public DateTime FechaServicio { get; set; }

    public string TipoServicio { get; set; }

    public Guid IdUsuario { get; set; }

    public DateTime FechaAlta { get; set; }

    public Guid IdUsuarioModificacion { get; set; }

    public DateTime FechaModificacion { get; set; }
  }
}
