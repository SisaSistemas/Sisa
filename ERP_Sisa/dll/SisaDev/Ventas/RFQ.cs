// Decompiled with JetBrains decompiler
// Type: SisaDev.Ventas.RFQ
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;

namespace SisaDev.Ventas
{
  public class RFQ : Page
  {
    public static tblUsuarios usuario;
    public static tblRolesUsuarios rolesUsuarios;
    public static string idRfqNueva = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
      RFQ.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (RFQ.usuario != null)
        RFQ.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      else
        this.Response.Redirect("~/Default.aspx");
    }

    [WebMethod]
    public static string ObtenerRFQ(string pid)
    {
      string str = string.Empty;
      RFQ.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      RFQ.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (RFQ.rolesUsuarios.Administracion || RFQ.rolesUsuarios.Tipo == "ROOT" || RFQ.rolesUsuarios.Tipo == "ADMINISTRACION" || RFQ.rolesUsuarios.RFQ)
      {
        if (pid.Trim() == "1")
        {
          if (RFQ.rolesUsuarios.Administracion || RFQ.rolesUsuarios.Tipo == "ROOT" || RFQ.rolesUsuarios.Tipo == "ADMINISTRACION" || RFQ.rolesUsuarios.RFQ)
          {
            using (SisaEntitie sisaEntitie = new SisaEntitie())
              str = JsonConvert.SerializeObject((object) ((IQueryable<tblRFQ>) sisaEntitie.tblRFQ).Join((IEnumerable<tblClienteContacto>) sisaEntitie.tblClienteContacto, (Expression<Func<tblRFQ, Guid>>) (r => r.IdCliente), (Expression<Func<tblClienteContacto, Guid>>) (cn => cn.idContacto), (r, cn) => new
              {
                r = r,
                cn = cn
              }).Join((IEnumerable<tblEmpresas>) sisaEntitie.tblEmpresas, data => data.cn.idEmpresa, (Expression<Func<tblEmpresas, Guid>>) (ce => ce.idEmpresa), (data, ce) => new
              {
                \u003C\u003Eh__TransparentIdentifier0 = data,
                ce = ce
              }).Join((IEnumerable<tblUsuarios>) sisaEntitie.tblUsuarios, data => data.\u003C\u003Eh__TransparentIdentifier0.r.idVendedor, (Expression<Func<tblUsuarios, Guid?>>) (uv => (Guid?) uv.IdUsuario), (data, uv) => new
              {
                \u003C\u003Eh__TransparentIdentifier1 = data,
                uv = uv
              }).Join((IEnumerable<tblUsuarios>) sisaEntitie.tblUsuarios, data => data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.idCoordinador, (Expression<Func<tblUsuarios, Guid?>>) (uc => (Guid?) uc.IdUsuario), (data, uc) => new
              {
                \u003C\u003Eh__TransparentIdentifier2 = data,
                uc = uc
              }).Where(data => data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.Estatus > 0).Select(data => new
              {
                IdRfq = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.IdRfq,
                Folio = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.Folio,
                Descripcion = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.Descripcion,
                FechaRFQ = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.FechaAlta,
                FechaCompromiso = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.FechaVencimiento,
                NombreContacto = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.ce.RazonSocial + "-" + data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.cn.NombreContacto,
                Telefono = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.cn.Telefono,
                Seguimiento = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.Seguimiento,
                ArchivoRFQ = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.ArchivoRFQ,
                Vendedor = data.\u003C\u003Eh__TransparentIdentifier2.uv.NombreCompleto,
                Coordinador = data.uc.NombreCompleto,
                Estatus = SqlFunctions.DateDiff("DAY", (DateTime?) DateTime.Now, (DateTime?) data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.FechaVencimiento),
                EstatusN = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.Estatus
              }));
          }
          else
          {
            using (SisaEntitie sisaEntitie = new SisaEntitie())
              str = JsonConvert.SerializeObject((object) ((IQueryable<tblRFQ>) sisaEntitie.tblRFQ).Join((IEnumerable<tblClienteContacto>) sisaEntitie.tblClienteContacto, (Expression<Func<tblRFQ, Guid>>) (r => r.IdCliente), (Expression<Func<tblClienteContacto, Guid>>) (cn => cn.idContacto), (r, cn) => new
              {
                r = r,
                cn = cn
              }).Join((IEnumerable<tblEmpresas>) sisaEntitie.tblEmpresas, data => data.cn.idEmpresa, (Expression<Func<tblEmpresas, Guid>>) (ce => ce.idEmpresa), (data, ce) => new
              {
                \u003C\u003Eh__TransparentIdentifier0 = data,
                ce = ce
              }).Join((IEnumerable<tblUsuarios>) sisaEntitie.tblUsuarios, data => data.\u003C\u003Eh__TransparentIdentifier0.r.idVendedor, (Expression<Func<tblUsuarios, Guid?>>) (uv => (Guid?) uv.IdUsuario), (data, uv) => new
              {
                \u003C\u003Eh__TransparentIdentifier1 = data,
                uv = uv
              }).Join((IEnumerable<tblUsuarios>) sisaEntitie.tblUsuarios, data => data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.idCoordinador, (Expression<Func<tblUsuarios, Guid?>>) (uc => (Guid?) uc.IdUsuario), (data, uc) => new
              {
                \u003C\u003Eh__TransparentIdentifier2 = data,
                uc = uc
              }).Where(data => data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.IdUsuarioAlta == RFQ.usuario.IdUsuario && data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.Estatus > 0).Select(data => new
              {
                IdRfq = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.IdRfq,
                Folio = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.Folio,
                Descripcion = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.Descripcion,
                FechaRFQ = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.FechaAlta,
                FechaCompromiso = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.FechaVencimiento,
                NombreContacto = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.ce.RazonSocial + "-" + data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.cn.NombreContacto,
                Telefono = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.cn.Telefono,
                Seguimiento = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.Seguimiento,
                ArchivoRFQ = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.ArchivoRFQ,
                Vendedor = data.\u003C\u003Eh__TransparentIdentifier2.uv.NombreCompleto,
                Coordinador = data.uc.NombreCompleto,
                Estatus = SqlFunctions.DateDiff("DAY", (DateTime?) DateTime.Now, (DateTime?) data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.FechaVencimiento),
                EstatusN = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.Estatus
              }));
          }
        }
        else
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
            str = JsonConvert.SerializeObject((object) ((IQueryable<tblRFQ>) sisaEntitie.tblRFQ).Join((IEnumerable<tblClienteContacto>) sisaEntitie.tblClienteContacto, (Expression<Func<tblRFQ, Guid>>) (r => r.IdCliente), (Expression<Func<tblClienteContacto, Guid>>) (cn => cn.idContacto), (r, cn) => new
            {
              r = r,
              cn = cn
            }).Join((IEnumerable<tblEmpresas>) sisaEntitie.tblEmpresas, data => data.cn.idEmpresa, (Expression<Func<tblEmpresas, Guid>>) (ce => ce.idEmpresa), (data, ce) => new
            {
              \u003C\u003Eh__TransparentIdentifier0 = data,
              ce = ce
            }).Join((IEnumerable<tblUsuarios>) sisaEntitie.tblUsuarios, data => data.\u003C\u003Eh__TransparentIdentifier0.r.idVendedor, (Expression<Func<tblUsuarios, Guid?>>) (uv => (Guid?) uv.IdUsuario), (data, uv) => new
            {
              \u003C\u003Eh__TransparentIdentifier1 = data,
              uv = uv
            }).Join((IEnumerable<tblUsuarios>) sisaEntitie.tblUsuarios, data => data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.idCoordinador, (Expression<Func<tblUsuarios, Guid?>>) (uc => (Guid?) uc.IdUsuario), (data, uc) => new
            {
              \u003C\u003Eh__TransparentIdentifier2 = data,
              uc = uc
            }).Where(data => data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.IdUsuarioAlta == RFQ.usuario.IdUsuario && data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.IdRfq.ToString() == pid && data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.Estatus > 0).Select(data => new
            {
              IdRfq = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.IdRfq,
              Folio = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.Folio,
              Descripcion = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.Descripcion,
              FechaRFQ = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.FechaAlta,
              FechaCompromiso = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.FechaVencimiento,
              NombreContacto = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.ce.RazonSocial + "-" + data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.cn.NombreContacto,
              Telefono = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.cn.Telefono,
              Seguimiento = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.Seguimiento,
              ArchivoRFQ = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.ArchivoRFQ,
              Vendedor = data.\u003C\u003Eh__TransparentIdentifier2.uv.NombreCompleto,
              Coordinador = data.uc.NombreCompleto,
              Estatus = SqlFunctions.DateDiff("DAY", (DateTime?) DateTime.Now, (DateTime?) data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.FechaVencimiento),
              EstatusN = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.Estatus
            }));
        }
      }
      else
        str = "No tienes permiso.";
      return str;
    }

    public static string ObtenerRFQsDetalles(string pid)
    {
      string str = string.Empty;
      RFQ.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      RFQ.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (pid.Trim() == "2")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
          str = JsonConvert.SerializeObject((object) ((IQueryable<tblRFQDet>) sisaEntitie.tblRFQDet).Where<tblRFQDet>((Expression<Func<tblRFQDet, bool>>) (p => p.IdRfq.ToString() == pid)).OrderBy<tblRFQDet, int>((Expression<Func<tblRFQDet, int>>) (p => p.Item)).Select(p => new
          {
            IdRfq = p.IdRfq,
            Descripcion = p.Descripcion,
            Cantidad = p.Cantidad,
            NumeroParte = p.NumeroParte,
            Marca = p.Marca,
            Unidad = p.Unidad,
            Item = p.Item
          }));
      }
      if (RFQ.rolesUsuarios.RFQ)
      {
        if (pid.Trim() == "1")
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
            str = JsonConvert.SerializeObject((object) ((IQueryable<tblRFQDet>) sisaEntitie.tblRFQDet).Join((IEnumerable<tblRFQ>) sisaEntitie.tblRFQ, (Expression<Func<tblRFQDet, Guid>>) (p => p.IdRfq), (Expression<Func<tblRFQ, Guid>>) (a => a.IdRfq), (p, a) => new
            {
              p = p,
              a = a
            }).Where(data => data.a.IdUsuarioAlta == RFQ.usuario.IdUsuario).OrderBy(data => data.p.Item).Select(data => new
            {
              IdRfq = data.p.IdRfq,
              Descripcion = data.p.Descripcion,
              Cantidad = data.p.Cantidad,
              NumeroParte = data.p.NumeroParte,
              Marca = data.p.Marca,
              Unidad = data.p.Unidad,
              Item = data.p.Item
            }));
        }
        else
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
            str = JsonConvert.SerializeObject((object) ((IQueryable<tblRFQDet>) sisaEntitie.tblRFQDet).Where<tblRFQDet>((Expression<Func<tblRFQDet, bool>>) (p => p.IdRfq.ToString() == pid)).OrderBy<tblRFQDet, int>((Expression<Func<tblRFQDet, int>>) (p => p.Item)).Select(p => new
            {
              IdRfq = p.IdRfq,
              Descripcion = p.Descripcion,
              Cantidad = p.Cantidad,
              NumeroParte = p.NumeroParte,
              Marca = p.Marca,
              Unidad = p.Unidad,
              Item = p.Item
            }));
        }
      }
      return str;
    }

    [WebMethod]
    public static string EliminarRFQ(string pidRFQ)
    {
      string str = string.Empty;
      RFQ.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      RFQ.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (RFQ.rolesUsuarios.RFQEliminar || RFQ.rolesUsuarios.Tipo == "ROOT" || RFQ.rolesUsuarios.Tipo == "ADMINISTRACION")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblRFQ tblRfq = ((IQueryable<tblRFQ>) sisaEntitie.tblRFQ).FirstOrDefault<tblRFQ>((Expression<Func<tblRFQ, bool>>) (s => s.IdRfq.ToString() == pidRFQ));
          if (tblRfq != null)
          {
            tblRfq.Estatus = 0;
            str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al eliminar RFQ." : "RFQ eliminada.";
          }
          else
            str = "Ocurrio un problema al obtener información de RFQ seleccionada.";
        }
      }
      else
        str = "No tienes permiso de eliminar RFQ.";
      return str;
    }

    [WebMethod]
    public static string ObtenerEmpresas(string pid)
    {
      string str = string.Empty;
      RFQ.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      RFQ.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (pid.Trim() == "2")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          if (RFQ.rolesUsuarios.Tipo == "ROOT" || RFQ.rolesUsuarios.Tipo == "ADMINISTRACION" || RFQ.rolesUsuarios.Tipo == "GERENCIAL" || RFQ.rolesUsuarios.Tipo == "COMPRAS")
            str = JsonConvert.SerializeObject((object) ((IQueryable<tblEmpresas>) sisaEntitie.tblEmpresas).Join((IEnumerable<tblClienteContacto>) sisaEntitie.tblClienteContacto, (Expression<Func<tblEmpresas, Guid>>) (r => r.idEmpresa), (Expression<Func<tblClienteContacto, Guid>>) (cn => cn.idEmpresa), (r, cn) => new
            {
              r = r,
              cn = cn
            }).Where(data => data.r.Estatus == (bool?) true && data.cn.Estatus == true).Select(data => new
            {
              idContacto = data.cn.idContacto,
              RazonSocial = data.r.RazonSocial,
              NombreContacto = data.cn.NombreContacto
            }));
          else
            str = JsonConvert.SerializeObject((object) ((IQueryable<tblEmpresas>) sisaEntitie.tblEmpresas).Join((IEnumerable<tblClienteContacto>) sisaEntitie.tblClienteContacto, (Expression<Func<tblEmpresas, Guid>>) (r => r.idEmpresa), (Expression<Func<tblClienteContacto, Guid>>) (cn => cn.idEmpresa), (r, cn) => new
            {
              r = r,
              cn = cn
            }).Where(data => data.r.idSucursalRegistro == RFQ.usuario.idSucursal && data.r.Estatus == (bool?) true && data.cn.Estatus == true).Select(data => new
            {
              idContacto = data.cn.idContacto,
              RazonSocial = data.r.RazonSocial,
              NombreContacto = data.cn.NombreContacto
            }));
        }
      }
      return str;
    }

    [WebMethod]
    public static string ObtenerUsuarios(string pid)
    {
      string empty = string.Empty;
      if (!(pid.Trim() == "2"))
        return empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
        return JsonConvert.SerializeObject((object) ((IQueryable<tblUsuarios>) sisaEntitie.tblUsuarios).Join((IEnumerable<tblRolesUsuarios>) sisaEntitie.tblRolesUsuarios, (Expression<Func<tblUsuarios, Guid>>) (r => r.IdUsuario), (Expression<Func<tblRolesUsuarios, Guid>>) (cn => cn.idUsuarios), (r, cn) => new
        {
          r = r,
          cn = cn
        }).Where(data => data.r.Activo == (int?) 1).Select(data => new
        {
          IdUsuario = data.r.IdUsuario,
          NombreCompleto = data.r.NombreCompleto,
          Tipo = data.cn.Tipo
        }));
    }

    [WebMethod]
    public static string EnviarRFQ(string pidRFQ)
    {
      string str = string.Empty;
      RFQ.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      RFQ.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (RFQ.rolesUsuarios.RFQEditar || RFQ.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblRFQ tblRfq = ((IQueryable<tblRFQ>) sisaEntitie.tblRFQ).FirstOrDefault<tblRFQ>((Expression<Func<tblRFQ, bool>>) (s => s.IdRfq.ToString() == pidRFQ));
          if (tblRfq != null)
          {
            tblRfq.Estatus = 2;
            str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al terminada RFQ." : "RFQ terminada.";
          }
          else
            str = "Ocurrio un problema al obtener información de RFQ seleccionada.";
        }
      }
      else
        str = "No tienes permiso de terminada RFQ.";
      return str;
    }
  }
}
