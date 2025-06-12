// Decompiled with JetBrains decompiler
// Type: SisaDev.Compras.OrdenCompra
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

namespace SisaDev.Compras
{
  public class OrdenCompra : Page
  {
    public static tblUsuarios usuario;
    public static tblRolesUsuarios rolesUsuarios;

    protected void Page_Load(object sender, EventArgs e)
    {
      OrdenCompra.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (OrdenCompra.usuario != null)
        OrdenCompra.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      else
        this.Response.Redirect("~/Default.aspx");
    }

    [WebMethod]
    public static string ObtenerOC(string pid)
    {
      string str = string.Empty;
      OrdenCompra.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      OrdenCompra.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (OrdenCompra.rolesUsuarios.OC || OrdenCompra.rolesUsuarios.Tipo == "ROOT")
      {
        if (pid.Trim() == "1")
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
            str = OrdenCompra.rolesUsuarios.Tipo == "GERENCIAL" || OrdenCompra.rolesUsuarios.Tipo == "COMPRAS" || OrdenCompra.rolesUsuarios.Tipo == "ROOT" ? JsonConvert.SerializeObject((object) ((IEnumerable<sp_LoadOrdenCompra_Result>) sisaEntitie.sp_LoadOrdenCompra()).OrderByDescending<sp_LoadOrdenCompra_Result, DateTime>((Func<sp_LoadOrdenCompra_Result, DateTime>) (a => a.FechaCreacion))) : JsonConvert.SerializeObject((object) ((IEnumerable<sp_LoadOrdenCompra_Result>) sisaEntitie.sp_LoadOrdenCompra()).Where<sp_LoadOrdenCompra_Result>((Func<sp_LoadOrdenCompra_Result, bool>) (s =>
            {
              Guid? idSucursal7 = s.idSucursal;
              Guid? idSucursal8 = OrdenCompra.usuario.idSucursal;
              if (idSucursal7.HasValue != idSucursal8.HasValue)
                return false;
              return !idSucursal7.HasValue || idSucursal7.GetValueOrDefault() == idSucursal8.GetValueOrDefault();
            })).OrderByDescending<sp_LoadOrdenCompra_Result, DateTime>((Func<sp_LoadOrdenCompra_Result, DateTime>) (a => a.FechaCreacion)));
        }
        else
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
            str = JsonConvert.SerializeObject((object) ((IQueryable<tblOrdenCompra>) sisaEntitie.tblOrdenCompra).Join((IEnumerable<tblProveedores>) sisaEntitie.tblProveedores, (Expression<Func<tblOrdenCompra, Guid>>) (r => r.IdProveedor), (Expression<Func<tblProveedores, Guid>>) (p => p.IdProveedor), (r, p) => new
            {
              r = r,
              p = p
            }).Where(data => data.r.idSucursal == OrdenCompra.usuario.idSucursal && data.r.IdOrdenCompra.ToString() == pid).Select(data => new
            {
              IdOrdenCompra = data.r.IdOrdenCompra,
              Folio = data.r.Folio,
              Proveedor = data.p.Proveedor,
              Email = data.p.Email,
              Correo = OrdenCompra.usuario.Correo
            }));
        }
      }
      else
        str = "No tienes permiso de lectura.";
      return str;
    }

    [WebMethod]
    public static string CargarResumen(string valor)
    {
      string str = string.Empty;
      OrdenCompra.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      OrdenCompra.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (OrdenCompra.rolesUsuarios.OC || OrdenCompra.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
          str = JsonConvert.SerializeObject((object) sisaEntitie.sp_TotalesOC(valor));
      }
      else
        str = "No tienes permiso de lectura.";
      return str;
    }

    [WebMethod]
    public static string EliminarOC(string pidOC)
    {
      string str = string.Empty;
      OrdenCompra.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      OrdenCompra.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (OrdenCompra.rolesUsuarios.OCEliminar || OrdenCompra.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblOrdenCompra tblOrdenCompra = ((IQueryable<tblOrdenCompra>) sisaEntitie.tblOrdenCompra).FirstOrDefault<tblOrdenCompra>((Expression<Func<tblOrdenCompra, bool>>) (s => s.IdOrdenCompra.ToString() == pidOC));
          if (tblOrdenCompra != null)
          {
            tblOrdenCompra.Estatus = 3;
            if (sisaEntitie.SaveChanges() > 0)
            {
              str = "OC eliminado.";
              tblEficienciasDesglose eficienciasDesglose = ((IQueryable<tblEficienciasDesglose>) sisaEntitie.tblEficienciasDesglose).FirstOrDefault<tblEficienciasDesglose>((Expression<Func<tblEficienciasDesglose, bool>>) (a => a.idDocumento == pidOC));
              if (eficienciasDesglose != null)
              {
                sisaEntitie.tblEficienciasDesglose.Remove(eficienciasDesglose);
                sisaEntitie.SaveChanges();
              }
            }
            else
              str = "Ocurrio un problema al eliminar OC.";
          }
          else
          {
            tblOrdenCompraInsumos ordenCompraInsumos = ((IQueryable<tblOrdenCompraInsumos>) sisaEntitie.tblOrdenCompraInsumos).FirstOrDefault<tblOrdenCompraInsumos>((Expression<Func<tblOrdenCompraInsumos, bool>>) (s => s.IdOrdenCompra.ToString() == pidOC));
            if (ordenCompraInsumos != null)
            {
              ordenCompraInsumos.Estatus = 0;
              if (sisaEntitie.SaveChanges() > 0)
              {
                str = "OC eliminado.";
                tblEficienciasDesglose eficienciasDesglose = ((IQueryable<tblEficienciasDesglose>) sisaEntitie.tblEficienciasDesglose).FirstOrDefault<tblEficienciasDesglose>((Expression<Func<tblEficienciasDesglose, bool>>) (a => a.idDocumento == pidOC));
                if (eficienciasDesglose != null)
                {
                  sisaEntitie.tblEficienciasDesglose.Remove(eficienciasDesglose);
                  sisaEntitie.SaveChanges();
                }
              }
              else
                str = "Ocurrio un problema al eliminar OC.";
            }
            else
              str = "Ocurrio un problema al obtener información de OC seleccionada.";
          }
        }
      }
      else
        str = "No tienes permiso de eliminar OC.";
      return str;
    }

    [WebMethod]
    public static string CancelarOC(string pidOC)
    {
      string str = string.Empty;
      OrdenCompra.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      OrdenCompra.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (OrdenCompra.rolesUsuarios.OCEditar || OrdenCompra.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblOrdenCompra tblOrdenCompra = ((IQueryable<tblOrdenCompra>) sisaEntitie.tblOrdenCompra).FirstOrDefault<tblOrdenCompra>((Expression<Func<tblOrdenCompra, bool>>) (s => s.IdOrdenCompra.ToString() == pidOC));
          if (tblOrdenCompra != null)
          {
            tblOrdenCompra.Estatus = 2;
            if (sisaEntitie.SaveChanges() > 0)
            {
              str = "OC cancelado.";
              tblEficienciasDesglose eficienciasDesglose = ((IQueryable<tblEficienciasDesglose>) sisaEntitie.tblEficienciasDesglose).FirstOrDefault<tblEficienciasDesglose>((Expression<Func<tblEficienciasDesglose, bool>>) (a => a.idDocumento == pidOC));
              if (eficienciasDesglose != null)
              {
                sisaEntitie.tblEficienciasDesglose.Remove(eficienciasDesglose);
                sisaEntitie.SaveChanges();
              }
            }
            else
              str = "Ocurrio un problema al cancelar OC, es posible que ya haya sido cancelada con anterioridad.";
          }
          else
          {
            tblOrdenCompraInsumos ordenCompraInsumos = ((IQueryable<tblOrdenCompraInsumos>) sisaEntitie.tblOrdenCompraInsumos).FirstOrDefault<tblOrdenCompraInsumos>((Expression<Func<tblOrdenCompraInsumos, bool>>) (s => s.IdOrdenCompra.ToString() == pidOC));
            if (ordenCompraInsumos != null)
            {
              ordenCompraInsumos.Estatus = 2;
              if (sisaEntitie.SaveChanges() > 0)
              {
                str = "OC cancelado.";
                tblEficienciasDesglose eficienciasDesglose = ((IQueryable<tblEficienciasDesglose>) sisaEntitie.tblEficienciasDesglose).FirstOrDefault<tblEficienciasDesglose>((Expression<Func<tblEficienciasDesglose, bool>>) (a => a.idDocumento == pidOC));
                if (eficienciasDesglose != null)
                {
                  sisaEntitie.tblEficienciasDesglose.Remove(eficienciasDesglose);
                  sisaEntitie.SaveChanges();
                }
              }
              else
                str = "Ocurrio un problema al cancelar OC, es posible que ya haya sido cancelada con anterioridad.";
            }
            else
              str = "Ocurrio un problema al obtener información de OC seleccionada.";
          }
        }
      }
      else
        str = "No tienes permiso de cancelar OC.";
      return str;
    }

    [WebMethod]
    public static string CargarComentarios(string IdOrdenCompra)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
        return JsonConvert.SerializeObject((object) sisaEntitie.sp_CargaComentariosOrdenCompra(IdOrdenCompra));
    }

    [WebMethod]
    public static string GuardarComentarios(string IdOrdenCompra, string Comentario)
    {
      string empty = string.Empty;
      OrdenCompra.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      OrdenCompra.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
        return JsonConvert.SerializeObject((object) sisaEntitie.sp_InsertaComentariosOrdenCompra(IdOrdenCompra, Comentario, OrdenCompra.usuario.IdUsuario.ToString()));
    }

    [WebMethod]
    protected void btnEnviar_Click(object sender, EventArgs e)
    {
    }
  }
}
