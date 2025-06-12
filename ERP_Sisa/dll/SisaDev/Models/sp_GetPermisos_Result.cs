// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.sp_GetPermisos_Result
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class sp_GetPermisos_Result
  {
    public int IdMenu { get; set; }

    public Guid Identificador { get; set; }

    public string Seccion { get; set; }

    public string Icono { get; set; }

    public string Menu { get; set; }

    public string Accion { get; set; }

    public int? Orden { get; set; }

    public string Pagina { get; set; }

    public int Visible { get; set; }
  }
}
