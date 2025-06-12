// Decompiled with JetBrains decompiler
// Type: SisaDev.Cliente.Proyectos
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

namespace SisaDev.Cliente
{
  public class Proyectos : Page
  {
    public static tblClienteContacto usuario;

    protected void Page_Load(object sender, EventArgs e)
    {
      Proyectos.usuario = HttpContext.Current.Session["UsuarioClienteLogueado"] as tblClienteContacto;
      if (Proyectos.usuario != null)
        return;
      this.Response.Redirect("~/Default.aspx");
    }

    [WebMethod]
    public static string ObtenerProyectos(string pid)
    {
      string empty = string.Empty;
      if (pid == "1")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
          return JsonConvert.SerializeObject((object) ((IQueryable<tblProyectos>) sisaEntitie.tblProyectos).Join((IEnumerable<tblClienteContacto>) sisaEntitie.tblClienteContacto, (Expression<Func<tblProyectos, string>>) (p => p.IdCliente), (Expression<Func<tblClienteContacto, string>>) (c => c.idContacto.ToString()), (p, c) => new
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
          }).Where(data => data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.IdCliente == Proyectos.usuario.idContacto.ToString() && data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.Activo == (int?) 1 && data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.Estatus != "6").OrderByDescending(data => data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.FechaAlta).Select(data => new
          {
            IdProyecto = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.IdProyecto,
            FolioProyecto = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.FolioProyecto,
            NombreProyecto = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.NombreProyecto,
            NombreContacto = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.c.NombreContacto,
            RazonSocial = data.\u003C\u003Eh__TransparentIdentifier1.e.RazonSocial,
            Lider = data.u.NombreCompleto,
            FechaI = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.FechaInicio,
            FechaT = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.FechaFin,
            Estatus = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.Estatus,
            Activo = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.Activo
          }));
      }
      else
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
          return JsonConvert.SerializeObject((object) ((IQueryable<tblProyectos>) sisaEntitie.tblProyectos).Join((IEnumerable<tblClienteContacto>) sisaEntitie.tblClienteContacto, (Expression<Func<tblProyectos, string>>) (p => p.IdCliente), (Expression<Func<tblClienteContacto, string>>) (c => c.idContacto.ToString()), (p, c) => new
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
          }).Where(data => data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.IdCliente == Proyectos.usuario.idContacto.ToString() && data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.Activo == (int?) 1 && data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.Estatus != "6" && data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.IdProyecto.ToString() == pid).OrderByDescending(data => data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.FechaAlta).Select(data => new
          {
            IdProyecto = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.IdProyecto,
            FolioProyecto = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.FolioProyecto,
            NombreProyecto = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.NombreProyecto,
            NombreContacto = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.c.NombreContacto,
            RazonSocial = data.\u003C\u003Eh__TransparentIdentifier1.e.RazonSocial,
            Lider = data.u.NombreCompleto,
            FechaI = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.FechaInicio,
            FechaT = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.FechaFin,
            Estatus = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.Estatus,
            Activo = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.Activo
          }));
      }
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
          Fecha = (object) data.p.FechaComentario.Day + "/" + (object) data.p.FechaComentario.Month + "/" + (object) data.p.FechaComentario.Year
        }));
    }
  }
}
