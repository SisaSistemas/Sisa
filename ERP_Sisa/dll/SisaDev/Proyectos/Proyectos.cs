// Decompiled with JetBrains decompiler
// Type: SisaDev.Proyectos.Proyectos
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
  public class Proyectos : Page
  {
    public static tblUsuarios usuario;
    public static tblRolesUsuarios rolesUsuarios;

    protected void Page_Load(object sender, EventArgs e)
    {
      SisaDev.Proyectos.Proyectos.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (SisaDev.Proyectos.Proyectos.usuario != null)
        SisaDev.Proyectos.Proyectos.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      else
        this.Response.Redirect("~/Default.aspx");
    }

    [WebMethod]
    public static string ObtenerProyectos(string pid)
    {
      string str = string.Empty;
      SisaDev.Proyectos.Proyectos.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      SisaDev.Proyectos.Proyectos.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (SisaDev.Proyectos.Proyectos.rolesUsuarios.Proyectos || SisaDev.Proyectos.Proyectos.rolesUsuarios.Tipo == "ROOT" || SisaDev.Proyectos.Proyectos.rolesUsuarios.Tipo == "ADMINISTRACION" || SisaDev.Proyectos.Proyectos.rolesUsuarios.Tipo == "GERENCIAL")
      {
        if (pid.Trim() == "1")
        {
          if (SisaDev.Proyectos.Proyectos.rolesUsuarios.Tipo == "ROOT" || SisaDev.Proyectos.Proyectos.rolesUsuarios.Tipo == "ADMINISTRACION" || SisaDev.Proyectos.Proyectos.rolesUsuarios.Tipo == "GERENCIAL" || SisaDev.Proyectos.Proyectos.rolesUsuarios.Tipo == "COMPRAS")
          {
            using (SisaEntitie sisaEntitie = new SisaEntitie())
              str = JsonConvert.SerializeObject((object) ((IQueryable<tblProyectos>) sisaEntitie.tblProyectos).Join((IEnumerable<tblClienteContacto>) sisaEntitie.tblClienteContacto, (Expression<Func<tblProyectos, string>>) (p => p.IdCliente), (Expression<Func<tblClienteContacto, string>>) (c => c.idContacto.ToString()), (p, c) => new
              {
                p = p,
                c = c
              }).Join((IEnumerable<tblEmpresas>) sisaEntitie.tblEmpresas, data => data.c.idEmpresa, (Expression<Func<tblEmpresas, Guid>>) (e => e.idEmpresa), (data, e) => new
              {
                \u003C\u003Eh__TransparentIdentifier0 = data,
                e = e
              }).Join((IEnumerable<tblUsuarios>) sisaEntitie.tblUsuarios, data => data.\u003C\u003Eh__TransparentIdentifier0.p.IdLider, (Expression<Func<tblUsuarios, string>>) (u => u.IdUsuario.ToString()), (data, u) => new
              {
                \u003C\u003Eh__TransparentIdentifier1 = data,
                u = u
              }).Where(data => data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.Activo == (int?) 1 && data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.Estatus != "6").OrderBy(data => data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.Estatus).ThenByDescending(data => data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.FechaAlta).Select(data => new
              {
                IdProyecto = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.IdProyecto,
                FolioProyecto = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.FolioProyecto,
                NombreProyecto = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.NombreProyecto,
                NombreContacto = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.c.NombreContacto,
                RazonSocial = data.\u003C\u003Eh__TransparentIdentifier1.e.Cliente,
                Lider = data.u.NombreCompleto,
                FechaI = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.FechaInicio,
                FechaT = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.FechaFin,
                Estatus = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.Estatus,
                Activo = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.Activo,
                FechaAlta = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.FechaAlta
              }));
          }
          else
          {
            using (SisaEntitie sisaEntitie = new SisaEntitie())
              str = JsonConvert.SerializeObject((object) ((IQueryable<tblProyectos>) sisaEntitie.tblProyectos).Join((IEnumerable<tblClienteContacto>) sisaEntitie.tblClienteContacto, (Expression<Func<tblProyectos, string>>) (p => p.IdCliente), (Expression<Func<tblClienteContacto, string>>) (c => c.idContacto.ToString()), (p, c) => new
              {
                p = p,
                c = c
              }).Join((IEnumerable<tblEmpresas>) sisaEntitie.tblEmpresas, data => data.c.idEmpresa, (Expression<Func<tblEmpresas, Guid>>) (e => e.idEmpresa), (data, e) => new
              {
                \u003C\u003Eh__TransparentIdentifier0 = data,
                e = e
              }).Join((IEnumerable<tblUsuarios>) sisaEntitie.tblUsuarios, data => data.\u003C\u003Eh__TransparentIdentifier0.p.IdLider, (Expression<Func<tblUsuarios, string>>) (u => u.IdUsuario.ToString()), (data, u) => new
              {
                \u003C\u003Eh__TransparentIdentifier1 = data,
                u = u
              }).Where(data => data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.Activo == (int?) 1 && data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.Estatus != "6" && (data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.IdLider.ToString() == SisaDev.Proyectos.Proyectos.usuario.IdUsuario.ToString() || data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.IdUsuarioAlta.ToString() == SisaDev.Proyectos.Proyectos.usuario.IdUsuario.ToString())).OrderBy(data => data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.Estatus).ThenByDescending(data => data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.FechaAlta).Select(data => new
              {
                IdProyecto = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.IdProyecto,
                FolioProyecto = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.FolioProyecto,
                NombreProyecto = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.NombreProyecto,
                NombreContacto = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.c.NombreContacto,
                RazonSocial = data.\u003C\u003Eh__TransparentIdentifier1.e.Cliente,
                Lider = data.u.NombreCompleto,
                FechaI = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.FechaInicio,
                FechaT = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.FechaFin,
                Estatus = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.Estatus,
                Activo = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.Activo,
                FechaAlta = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.FechaAlta
              }));
          }
        }
        else
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
            str = JsonConvert.SerializeObject((object) ((IQueryable<tblProyectos>) sisaEntitie.tblProyectos).Join((IEnumerable<tblClienteContacto>) sisaEntitie.tblClienteContacto, (Expression<Func<tblProyectos, string>>) (p => p.IdCliente), (Expression<Func<tblClienteContacto, string>>) (c => c.idContacto.ToString()), (p, c) => new
            {
              p = p,
              c = c
            }).Join((IEnumerable<tblEmpresas>) sisaEntitie.tblEmpresas, data => data.c.idEmpresa, (Expression<Func<tblEmpresas, Guid>>) (e => e.idEmpresa), (data, e) => new
            {
              \u003C\u003Eh__TransparentIdentifier0 = data,
              e = e
            }).Join((IEnumerable<tblUsuarios>) sisaEntitie.tblUsuarios, data => data.\u003C\u003Eh__TransparentIdentifier0.p.IdLider, (Expression<Func<tblUsuarios, string>>) (u => u.IdUsuario.ToString()), (data, u) => new
            {
              \u003C\u003Eh__TransparentIdentifier1 = data,
              u = u
            }).Where(data => data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.IdProyecto.ToString() == pid && data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.Activo == (int?) 1 && data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.Estatus != "6").OrderByDescending(data => data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.FechaAlta).Select(data => new
            {
              IdProyecto = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.IdProyecto,
              FolioProyecto = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.FolioProyecto,
              NombreProyecto = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.NombreProyecto,
              NombreContacto = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.c.NombreContacto,
              RazonSocial = data.\u003C\u003Eh__TransparentIdentifier1.e.Cliente,
              Lider = data.u.NombreCompleto,
              FechaI = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.FechaInicio,
              FechaT = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.FechaFin,
              Estatus = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.Estatus,
              Activo = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.Activo,
              FechaAlta = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.FechaAlta
            }));
        }
      }
      else
        str = "No tienes permiso.";
      return str;
    }

    [WebMethod]
    public static string EliminarProyectos(string pid)
    {
      string str = string.Empty;
      SisaDev.Proyectos.Proyectos.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      SisaDev.Proyectos.Proyectos.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (SisaDev.Proyectos.Proyectos.rolesUsuarios.ProyectosEliminar || SisaDev.Proyectos.Proyectos.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblProyectos tblProyectos = ((IQueryable<tblProyectos>) sisaEntitie.tblProyectos).FirstOrDefault<tblProyectos>((Expression<Func<tblProyectos, bool>>) (s => s.IdProyecto.ToString() == pid));
          if (tblProyectos != null)
          {
            tblProyectos.Activo = new int?(0);
            str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al eliminar proyecto." : "Proyecto eliminado.";
          }
        }
      }
      else
        str = "No tienes permiso de eliminar proyecto.";
      return str;
    }

    [WebMethod]
    public static string CancelarProyectos(string pid)
    {
      string str = string.Empty;
      SisaDev.Proyectos.Proyectos.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      SisaDev.Proyectos.Proyectos.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (SisaDev.Proyectos.Proyectos.rolesUsuarios.ProyectosEliminar || SisaDev.Proyectos.Proyectos.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblProyectos tblProyectos = ((IQueryable<tblProyectos>) sisaEntitie.tblProyectos).FirstOrDefault<tblProyectos>((Expression<Func<tblProyectos, bool>>) (s => s.IdProyecto.ToString() == pid));
          if (tblProyectos != null)
          {
            tblProyectos.Estatus = "4";
            str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al cancelar Proyecto." : "Proyecto cancelado.";
          }
        }
      }
      else
        str = "No tienes permiso de cancelar Proyecto.";
      return str;
    }

    [WebMethod]
    public static string CargarComentarios(string pid)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
        return JsonConvert.SerializeObject((object) ((IQueryable<tblComentariosProyecto>) sisaEntitie.tblComentariosProyecto).Join((IEnumerable<tblUsuarios>) sisaEntitie.tblUsuarios, (Expression<Func<tblComentariosProyecto, Guid>>) (p => p.IdUsuario), (Expression<Func<tblUsuarios, Guid>>) (u => u.IdUsuario), (p, u) => new
        {
          p = p,
          u = u
        }).Where(data => data.p.IdProyecto.ToString() == pid).OrderByDescending(data => data.p.FechaComentario).Select(data => new
        {
          IdProyecto = data.p.IdProyecto,
          Comentario = data.p.Comentario,
          NombreCompleto = data.u.NombreCompleto,
          Fecha = data.p.FechaComentario
        }).OrderByDescending(a => a.Fecha));
    }

    [WebMethod]
    public static string GuardarComentarios(string pid, string Comentario)
    {
      string empty = string.Empty;
      SisaDev.Proyectos.Proyectos.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      SisaDev.Proyectos.Proyectos.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
        return JsonConvert.SerializeObject((object) sisaEntitie.sp_InsertaComentarioProyecto(pid, Comentario, SisaDev.Proyectos.Proyectos.usuario.IdUsuario.ToString()));
    }

    [WebMethod]
    public static string ObtenerFechas(string pid)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
        return JsonConvert.SerializeObject((object) ((IQueryable<tblProyectos>) sisaEntitie.tblProyectos).Where<tblProyectos>((Expression<Func<tblProyectos, bool>>) (p => p.IdProyecto.ToString() == pid)).Select(p => new
        {
          FechaInicio = p.FechaInicio,
          FechaFin = p.FechaFin
        }));
    }

    [WebMethod]
    public static string GuardarFechas(string pid, string Razon, string Inicio, string Fin)
    {
      string str = string.Empty;
      SisaDev.Proyectos.Proyectos.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      SisaDev.Proyectos.Proyectos.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (SisaDev.Proyectos.Proyectos.rolesUsuarios.ProyectosEditar || SisaDev.Proyectos.Proyectos.rolesUsuarios.Tipo == "ROOT" || SisaDev.Proyectos.Proyectos.rolesUsuarios.Tipo == "GERENCIAL")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblProyectos tblProyectos = ((IQueryable<tblProyectos>) sisaEntitie.tblProyectos).FirstOrDefault<tblProyectos>((Expression<Func<tblProyectos, bool>>) (a => a.IdProyecto.ToString() == pid));
          if (tblProyectos != null)
          {
            tblProyectos.FechaInicio = new DateTime?(DateTime.Parse(Inicio));
            tblProyectos.FechaFin = new DateTime?(DateTime.Parse(Fin));
            tblProyectos.UserProject1 = Razon;
            sisaEntitie.SaveChanges();
            str = "Fechas actualizadas.";
          }
          else
            str = "Ocurrio un problema al obtener información, recarga página.";
        }
      }
      else
        str = "No tienes permiso de editar proyectos.";
      return str;
    }
  }
}
