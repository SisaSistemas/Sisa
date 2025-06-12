// Decompiled with JetBrains decompiler
// Type: SisaDev.Compras.ServicioCarros
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

namespace SisaDev.Compras
{
  public class ServicioCarros : Page
  {
    public static tblUsuarios usuario;
    public static tblRolesUsuarios rolesUsuarios;

    protected void Page_Load(object sender, EventArgs e)
    {
      ServicioCarros.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (ServicioCarros.usuario != null)
        ServicioCarros.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      else
        this.Response.Redirect("~/Default.aspx");
    }

    [WebMethod]
    public static string ObtenerCarros(string pid)
    {
      string str = string.Empty;
      ServicioCarros.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      ServicioCarros.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (ServicioCarros.rolesUsuarios.ServiciosCarro || ServicioCarros.rolesUsuarios.Tipo == "ROOT" || ServicioCarros.rolesUsuarios.Tipo == "GERENCIAL" || ServicioCarros.rolesUsuarios.Tipo == "ADMINISTRACION")
      {
        if (pid.Trim() == "1")
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
            str = JsonConvert.SerializeObject((object) ((IQueryable<tblVehiculos>) sisaEntitie.tblVehiculos).Where<tblVehiculos>((Expression<Func<tblVehiculos, bool>>) (cl => cl.Activo > 0)).Select(cl => new
            {
              IdCarro = cl.IdCarro,
              Vehiculo = cl.Vehiculo,
              Anio = cl.Anio,
              Comentarios = cl.Comentarios,
              FechaAlta = cl.FechaAlta
            }));
        }
        else
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
            str = JsonConvert.SerializeObject((object) ((IQueryable<tblVehiculos>) sisaEntitie.tblVehiculos).Where<tblVehiculos>((Expression<Func<tblVehiculos, bool>>) (cl => cl.IdCarro.ToString() == pid)).Select(cl => new
            {
              IdCarro = cl.IdCarro,
              Vehiculo = cl.Vehiculo,
              Anio = cl.Anio,
              Comentarios = cl.Comentarios,
              FechaAlta = cl.FechaAlta
            }));
        }
      }
      else
        str = "No tienes permiso de ver los automoviles";
      return str;
    }

    [WebMethod]
    public static string EliminarCarro(string pid)
    {
      string str = string.Empty;
      ServicioCarros.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      ServicioCarros.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (ServicioCarros.rolesUsuarios.Tipo == "ROOT" || ServicioCarros.rolesUsuarios.Tipo == "GERENCIAL" || ServicioCarros.rolesUsuarios.Tipo == "ADMINISTRACION")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblVehiculos tblVehiculos = ((IQueryable<tblVehiculos>) sisaEntitie.tblVehiculos).FirstOrDefault<tblVehiculos>((Expression<Func<tblVehiculos, bool>>) (s => s.IdCarro.ToString() == pid));
          if (tblVehiculos != null)
          {
            tblVehiculos.Activo = 0;
            str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al eliminar carro." : "Carro eliminado.";
          }
          else
            str = "Ocurrio un problema al obtener información de carro seleccionada.";
        }
      }
      else
        str = "No tienes permiso de eliminar carro.";
      return str;
    }

    [WebMethod]
    public static string GuardarCarro(string pCarro, string pAno, string cComentarios)
    {
      string str = string.Empty;
      ServicioCarros.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      ServicioCarros.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (ServicioCarros.rolesUsuarios.Tipo == "ROOT" || ServicioCarros.rolesUsuarios.Tipo == "GERENCIAL" || ServicioCarros.rolesUsuarios.Tipo == "ADMINISTRACION")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblVehiculos tblVehiculos = new tblVehiculos()
          {
            IdCarro = Guid.NewGuid(),
            Anio = int.Parse(pAno),
            Comentarios = cComentarios,
            Vehiculo = pCarro,
            Activo = 1,
            IdUsuario = ServicioCarros.usuario.IdUsuario,
            IdUsuarioModificacion = ServicioCarros.usuario.IdUsuario,
            FechaAlta = DateTime.Now,
            FechaModificacion = DateTime.Now
          };
          sisaEntitie.tblVehiculos.Add(tblVehiculos);
          str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al guardar carro." : "Carro creado.";
        }
      }
      else
        str = "No tienes permiso de agregar carro.";
      return str;
    }

    [WebMethod]
    public static string EditarCarro(string pid, string cComentarios)
    {
      string str = string.Empty;
      ServicioCarros.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      ServicioCarros.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (ServicioCarros.rolesUsuarios.Tipo == "ROOT" || ServicioCarros.rolesUsuarios.Tipo == "GERENCIAL" || ServicioCarros.rolesUsuarios.Tipo == "ADMINISTRACION")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblVehiculos tblVehiculos = ((IQueryable<tblVehiculos>) sisaEntitie.tblVehiculos).FirstOrDefault<tblVehiculos>((Expression<Func<tblVehiculos, bool>>) (s => s.IdCarro.ToString() == pid.Trim()));
          if (tblVehiculos != null)
          {
            tblVehiculos.Comentarios = cComentarios;
            str = sisaEntitie.SaveChanges() <= 0 ? "No se realizaron cambios." : "Carro actualizada.";
          }
          else
            str = "No se obtuvo información de carro seleccionado.";
        }
      }
      else
        str = "NO tienes permiso de edición de carros.";
      return str;
    }

    [WebMethod]
    public static string CargarServicios(string pid)
    {
      string str = string.Empty;
      ServicioCarros.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      ServicioCarros.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (ServicioCarros.rolesUsuarios.ServiciosCarro || ServicioCarros.rolesUsuarios.Tipo == "ROOT" || ServicioCarros.rolesUsuarios.Tipo == "GERENCIAL" || ServicioCarros.rolesUsuarios.Tipo == "ADMINISTRACION")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
          str = JsonConvert.SerializeObject((object) ((IQueryable<tblVehiculoServicio>) sisaEntitie.tblVehiculoServicio).Where<tblVehiculoServicio>((Expression<Func<tblVehiculoServicio, bool>>) (cl => cl.IdCarro.ToString() == pid)).Select(cl => new
          {
            IdCarro = cl.IdCarro,
            IdServicioVehiculo = cl.IdServicioVehiculo,
            KilometrajeActual = cl.KilometrajeActual,
            KilometrajeProximo = cl.KilometrajeProximo,
            FechaServicio = cl.FechaServicio.Day.ToString() + "/" + cl.FechaServicio.Month.ToString() + "/" + cl.FechaServicio.Year.ToString(),
            Taller = cl.Taller,
            TipoServicio = cl.TipoServicio
          }));
      }
      else
        str = "No tienes permiso de ver los automoviles";
      return str;
    }

    [WebMethod]
    public static string GuardarServicio(
      string pid,
      string pkmAc,
      string pKmpro,
      string pTaller,
      string pTipo,
      string pFecha)
    {
      string str = string.Empty;
      ServicioCarros.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      ServicioCarros.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (ServicioCarros.rolesUsuarios.Tipo == "ROOT" || ServicioCarros.rolesUsuarios.Tipo == "GERENCIAL" || ServicioCarros.rolesUsuarios.Tipo == "ADMINISTRACION")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblVehiculoServicio vehiculoServicio = new tblVehiculoServicio()
          {
            IdServicioVehiculo = Guid.NewGuid(),
            IdCarro = Guid.Parse(pid),
            IdUsuario = ServicioCarros.usuario.IdUsuario,
            IdUsuarioModificacion = ServicioCarros.usuario.IdUsuario,
            FechaAlta = DateTime.Now,
            FechaModificacion = DateTime.Now,
            FechaServicio = DateTime.Parse(pFecha),
            KilometrajeActual = int.Parse(pkmAc),
            KilometrajeProximo = int.Parse(pKmpro),
            Taller = pTaller,
            TipoServicio = pTipo
          };
          sisaEntitie.tblVehiculoServicio.Add(vehiculoServicio);
          str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al guardar servicio." : "Servicio creado.";
        }
      }
      else
        str = "No tienes permiso de agregar servicio.";
      return str;
    }
  }
}
