// Decompiled with JetBrains decompiler
// Type: SisaDev.Proyectos.Viaticos
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;

namespace SisaDev.Proyectos
{
  public class Viaticos : Page
  {
    public static tblUsuarios usuario;
    public static tblRolesUsuarios rolesUsuarios;

    protected void Page_Load(object sender, EventArgs e)
    {
      Viaticos.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (Viaticos.usuario != null)
        Viaticos.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      else
        this.Response.Redirect("~/Default.aspx");
    }

    [WebMethod]
    public static string ObtenerViaticos(string pid)
    {
      string str = string.Empty;
      Viaticos.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Viaticos.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (pid.Trim() == "2")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
          str = JsonConvert.SerializeObject((object) sisaEntitie.sp_CargaListaViaticos());
      }
      if (Viaticos.rolesUsuarios.Viaticos || Viaticos.rolesUsuarios.Administracion || Viaticos.rolesUsuarios.Tipo == "ROOT" || Viaticos.rolesUsuarios.Tipo == "ADMINISTRACION")
      {
        if (pid.Trim() == "1")
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
            str = Viaticos.rolesUsuarios.Tipo == "ROOT" || Viaticos.rolesUsuarios.Tipo == "ADMINISTRACION" ? JsonConvert.SerializeObject((object) sisaEntitie.sp_CargaListaViaticos()) : JsonConvert.SerializeObject((object) ((IEnumerable<sp_CargaListaViaticos_Result>) sisaEntitie.sp_CargaListaViaticos()).Where<sp_CargaListaViaticos_Result>((Func<sp_CargaListaViaticos_Result, bool>) (A => A.IdUsuario == Viaticos.usuario.IdUsuario)));
        }
        else
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
            str = JsonConvert.SerializeObject((object) ((IEnumerable<sp_CargaListaViaticos_Result>) sisaEntitie.sp_CargaListaViaticos()).FirstOrDefault<sp_CargaListaViaticos_Result>((Func<sp_CargaListaViaticos_Result, bool>) (a => a.ID.ToString() == pid)));
        }
      }
      else
        str = "No tienes permiso de lectura en los viaticos.";
      return str;
    }

    [WebMethod]
    public static string CargarProyectos(string pid)
    {
      string str = string.Empty;
      if (pid.Trim() == "2")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
          str = JsonConvert.SerializeObject((object) ((IQueryable<tblProyectos>) sisaEntitie.tblProyectos).Where<tblProyectos>((Expression<Func<tblProyectos, bool>>) (a => a.Activo == (int?) 1)).Select(a => new
          {
            IdProyecto = a.IdProyecto,
            NombreProyecto = a.NombreProyecto,
            FolioProyecto = a.FolioProyecto
          }));
      }
      return str;
    }

    [WebMethod]
    public static string CargarUsuarios(string pid)
    {
      string str = string.Empty;
      Viaticos.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Viaticos.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (pid.Trim() == "2")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
          str = JsonConvert.SerializeObject((object) ((IQueryable<tblUsuarios>) sisaEntitie.tblUsuarios).Where<tblUsuarios>((Expression<Func<tblUsuarios, bool>>) (a => a.Activo == (int?) 1)).Select(a => new
          {
            IdUsuario = a.IdUsuario,
            NombreCompleto = a.NombreCompleto
          }));
      }
      return str;
    }

    [WebMethod]
    public static string GuardarViatico(
      string Usuario,
      string Proyecto,
      string Cantidad,
      string Concepto,
      string FechaViatico)
    {
      string str = string.Empty;
      Viaticos.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Viaticos.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Viaticos.rolesUsuarios.Tipo == "ROOT" || Viaticos.rolesUsuarios.Tipo == "GERENCIAL" || Viaticos.rolesUsuarios.Tipo == "ADMINISTRACION")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblViaticos tblViaticos = new tblViaticos()
          {
            ID = Guid.NewGuid(),
            IdProyecto = new Guid?(Guid.Parse(Proyecto)),
            IdUsuario = Guid.Parse(Usuario),
            CantEntregada = Decimal.Parse(Cantidad),
            CantGastada = 0M,
            Estatus = new int?(1),
            FechaAlta = DateTime.Now,
            FechaCaptura = new DateTime?(DateTime.Parse(FechaViatico)),
            Concepto = Concepto
          };
          sisaEntitie.tblViaticos.Add(tblViaticos);
          str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al guardar viaticos." : "Viatico creado.";
        }
      }
      else
        str = "No tienes permiso de agregar viaticos.";
      return str;
    }

    [WebMethod]
    public static string EliminarViaticos(string pid)
    {
      string str = string.Empty;
      Viaticos.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Viaticos.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Viaticos.rolesUsuarios.Tipo == "ROOT" || Viaticos.rolesUsuarios.Tipo == "GERENCIAL" || Viaticos.rolesUsuarios.Tipo == "ADMINISTRACION")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          if (((IQueryable<tblViaticosDet>) sisaEntitie.tblViaticosDet).FirstOrDefault<tblViaticosDet>((Expression<Func<tblViaticosDet, bool>>) (v => v.IdViaticos.ToString() == pid)) != null)
          {
            str = "Se encontraron gastos registrados dentro de viático seleccionado, favor de eliminar primero los gastos y despues el viático proporcionado.";
          }
          else
          {
            tblViaticos tblViaticos = ((IQueryable<tblViaticos>) sisaEntitie.tblViaticos).FirstOrDefault<tblViaticos>((Expression<Func<tblViaticos, bool>>) (v => v.ID.ToString() == pid));
            if (tblViaticos != null)
            {
              sisaEntitie.tblViaticos.Remove(tblViaticos);
              sisaEntitie.SaveChanges();
              str = "Viatico eliminado.";
            }
            else
              str = "Ocurrio un problema al buscar viático, recarga página e intenta de nuevo.";
          }
        }
      }
      else
        str = "No tienes permiso de eliminar viático.";
      return str;
    }
  }
}
