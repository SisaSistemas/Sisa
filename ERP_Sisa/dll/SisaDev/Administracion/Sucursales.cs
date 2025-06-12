// Decompiled with JetBrains decompiler
// Type: SisaDev.Administracion.Sucursales
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;

namespace SisaDev.Administracion
{
  public class Sucursales : Page
  {
    public static tblUsuarios usuario;
    public static tblRolesUsuarios rolesUsuario;

    protected void Page_Load(object sender, EventArgs e)
    {
      Sucursales.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (Sucursales.usuario != null)
        Sucursales.rolesUsuario = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      else
        this.Response.Redirect("~/Default.aspx");
    }

    [WebMethod]
    public static string ObtenerSucursales(string pid)
    {
      string str = string.Empty;
      Sucursales.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Sucursales.rolesUsuario = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (pid.Trim() == "2")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
          return JsonConvert.SerializeObject((object) ((IQueryable<tblSucursales>) sisaEntitie.tblSucursales).Where<tblSucursales>((Expression<Func<tblSucursales, bool>>) (s => s.Estatus == (bool?) true)));
      }
      else
      {
        if (Sucursales.rolesUsuario.Sucursales || Sucursales.rolesUsuario.Tipo == "ROOT")
        {
          if (pid.Trim() == "1")
          {
            using (SisaEntitie sisaEntitie = new SisaEntitie())
              str = JsonConvert.SerializeObject((object) ((IQueryable<tblSucursales>) sisaEntitie.tblSucursales).Where<tblSucursales>((Expression<Func<tblSucursales, bool>>) (s => s.Estatus == (bool?) true)));
          }
          else
          {
            using (SisaEntitie sisaEntitie = new SisaEntitie())
              str = JsonConvert.SerializeObject((object) ((IQueryable<tblSucursales>) sisaEntitie.tblSucursales).FirstOrDefault<tblSucursales>((Expression<Func<tblSucursales, bool>>) (s => s.idSucursa.ToString() == pid)));
          }
        }
        else
          str = "";
        return str;
      }
    }

    [WebMethod]
    public static string GuardarSucursal(
      string pCiudad,
      string pTelefono,
      string pDireccion,
      string pGerente)
    {
      string str = string.Empty;
      Sucursales.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Sucursales.rolesUsuario = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Sucursales.rolesUsuario.SucursalesAgregar || Sucursales.rolesUsuario.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblSucursales tblSucursales = new tblSucursales()
          {
            idSucursa = Guid.NewGuid(),
            CiudadSucursal = pCiudad,
            TelefonoSucursal = pTelefono,
            DireccionSucursal = pDireccion,
            Estatus = new bool?(true),
            Gerente = pGerente,
            TIMESTAMP = new DateTime?(DateTime.Now)
          };
          sisaEntitie.tblSucursales.Add(tblSucursales);
          str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al guardar sucursal." : "Sucursal creada.";
        }
      }
      else
        str = "No tienes permiso de crear sucursal.";
      return str;
    }

    [WebMethod]
    public static string EliminarSucursal(string pidSucursal)
    {
      string str = string.Empty;
      Sucursales.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Sucursales.rolesUsuario = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Sucursales.rolesUsuario.SucursalesEliminar || Sucursales.rolesUsuario.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblSucursales tblSucursales = ((IQueryable<tblSucursales>) sisaEntitie.tblSucursales).FirstOrDefault<tblSucursales>((Expression<Func<tblSucursales, bool>>) (s => s.idSucursa.ToString() == pidSucursal));
          if (tblSucursales != null)
          {
            tblSucursales.Estatus = new bool?(false);
            str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al eliminar sucursal." : "Sucursal eliminada.";
          }
          else
            str = "Ocurrio un problema al obtener información de sucursal seleccionada.";
        }
      }
      else
        str = "No tienes permiso de dar de baja sucursales.";
      return str;
    }

    [WebMethod]
    public static string EditarSucursal(
      string pid,
      string pCiudad,
      string pDireccion,
      string pTelefono,
      string pGerente)
    {
      string str = string.Empty;
      Sucursales.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Sucursales.rolesUsuario = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Sucursales.rolesUsuario.SucursalesEditar || Sucursales.rolesUsuario.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblSucursales tblSucursales = ((IQueryable<tblSucursales>) sisaEntitie.tblSucursales).FirstOrDefault<tblSucursales>((Expression<Func<tblSucursales, bool>>) (s => s.idSucursa.ToString() == pid.Trim()));
          if (tblSucursales != null)
          {
            tblSucursales.DireccionSucursal = pDireccion;
            tblSucursales.TelefonoSucursal = pTelefono;
            tblSucursales.Gerente = pGerente;
            str = sisaEntitie.SaveChanges() <= 0 ? "No se detectaron cambios." : "Sucursal actualizada.";
          }
          else
            str = "No se obtuvo información de sucursal seleccionada.";
        }
      }
      else
        str = "No tienes permiso de edición.";
      return str;
    }
  }
}
