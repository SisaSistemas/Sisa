// Decompiled with JetBrains decompiler
// Type: SisaDev.Administracion.ServicioComputo
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
  public class ServicioComputo : Page
  {
    public static tblUsuarios usuario;
    public static tblRolesUsuarios rolesUsuarios;

    protected void Page_Load(object sender, EventArgs e)
    {
      ServicioComputo.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (ServicioComputo.usuario != null)
        ServicioComputo.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      else
        this.Response.Redirect("~/Default.aspx");
    }

    [WebMethod]
    public static string CargarCombosComputo(string Opcion)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
      {
        int int32 = Convert.ToInt32(Opcion);
        return JsonConvert.SerializeObject((object) sisaEntitie.sp_CargaCombos(new int?(int32)));
      }
    }

    [WebMethod]
    public static string ObtenerServicios(string pid)
    {
      string str = string.Empty;
      ServicioComputo.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      ServicioComputo.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (ServicioComputo.rolesUsuarios.ServiciosComputo || ServicioComputo.rolesUsuarios.Tipo == "SISTEMAS" || ServicioComputo.rolesUsuarios.Tipo == "ROOT" || ServicioComputo.rolesUsuarios.Tipo == "GERENCIAL" || ServicioComputo.rolesUsuarios.Tipo == "ADMINISTRACION")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          if (pid == "1")
            str = JsonConvert.SerializeObject((object) ((IQueryable<tblServiciosComputo>) sisaEntitie.tblServiciosComputo).Select(cl => new
            {
              IdComputo = cl.IdComputo,
              PC = cl.PC,
              Tipo = cl.Tipo,
              Comentarios = cl.Comentarios,
              FechaAlta = cl.FechaAlta,
              FechaProximoMantenimiento = cl.FechaProximoMantenimiento,
              Serie = cl.Serie,
              Activo = cl.Activo,
              Usuario = cl.Usuario
            }));
          else
            str = JsonConvert.SerializeObject((object) ((IQueryable<tblServiciosComputo>) sisaEntitie.tblServiciosComputo).Where<tblServiciosComputo>((Expression<Func<tblServiciosComputo, bool>>) (cl => cl.IdComputo.ToString() == pid)).Select(cl => new
            {
              IdComputo = cl.IdComputo,
              PC = cl.PC,
              Tipo = cl.Tipo,
              Comentarios = cl.Comentarios,
              FechaAlta = cl.FechaAlta,
              FechaProximoMantenimiento = cl.FechaProximoMantenimiento,
              Serie = cl.Serie,
              Activo = cl.Activo,
              Usuario = cl.Usuario,
              IdUsuario = cl.IdUsuario
            }));
        }
      }
      else
        str = "No tienes permiso de ver los servicios de computo.";
      return str;
    }

    [WebMethod]
    public static string EliminarServicio(string pid)
    {
      string str = string.Empty;
      ServicioComputo.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      ServicioComputo.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (ServicioComputo.rolesUsuarios.Tipo == "SISTEMAS" || ServicioComputo.rolesUsuarios.Tipo == "ROOT" || ServicioComputo.rolesUsuarios.Tipo == "GERENCIAL" || ServicioComputo.rolesUsuarios.Tipo == "ADMINISTRACION")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblServiciosComputo serviciosComputo = ((IQueryable<tblServiciosComputo>) sisaEntitie.tblServiciosComputo).FirstOrDefault<tblServiciosComputo>((Expression<Func<tblServiciosComputo, bool>>) (s => s.IdComputo.ToString() == pid));
          if (serviciosComputo != null)
          {
            sisaEntitie.tblServiciosComputo.Remove(serviciosComputo);
            str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al eliminar servicio de computo." : "Servicio eliminado.";
          }
          else
            str = "Ocurrio un problema al obtener información de servicio de computo seleccionada.";
        }
      }
      else
        str = "No tienes permiso de eliminar servicio de computo.";
      return str;
    }

    [WebMethod]
    public static string GuardarServicio(
      string PC,
      string Comentarios,
      string Tipo,
      string Serie,
      string FechaMto,
      string idUsuario,
      string NombreUsuario)
    {
      string str = string.Empty;
      ServicioComputo.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      ServicioComputo.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (ServicioComputo.rolesUsuarios.Tipo == "SISTEMAS" || ServicioComputo.rolesUsuarios.Tipo == "ROOT" || ServicioComputo.rolesUsuarios.Tipo == "GERENCIAL" || ServicioComputo.rolesUsuarios.Tipo == "ADMINISTRACION")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblServiciosComputo serviciosComputo = new tblServiciosComputo()
          {
            IdComputo = Guid.NewGuid(),
            IdUsuario = Guid.Parse(idUsuario),
            IdUsuarioModificacion = ServicioComputo.usuario.IdUsuario,
            PC = PC,
            Comentarios = Comentarios,
            Tipo = Tipo,
            Activo = true,
            FechaAlta = DateTime.Now,
            FechaModificacion = DateTime.Now,
            Serie = Serie,
            FechaProximoMantenimiento = new DateTime?(FechaMto.Length > 0 ? DateTime.Parse(FechaMto) : DateTime.Now),
            Usuario = NombreUsuario
          };
          sisaEntitie.tblServiciosComputo.Add(serviciosComputo);
          str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al guardar servicio de computo." : "Computo creado.";
        }
      }
      else
        str = "No tienes permiso de agregar servicio de computo.";
      return str;
    }

    [WebMethod]
    public static string EditarComputo(
      string pid,
      string txtComentariosCerrados,
      string PC,
      string Tipo,
      string Serie,
      string FechaMto)
    {
      string str = string.Empty;
      ServicioComputo.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      ServicioComputo.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (ServicioComputo.rolesUsuarios.Tipo == "SISTEMAS" || ServicioComputo.rolesUsuarios.Tipo == "ROOT" || ServicioComputo.rolesUsuarios.Tipo == "GERENCIAL" || ServicioComputo.rolesUsuarios.Tipo == "ADMINISTRACION")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblServiciosComputo serviciosComputo = ((IQueryable<tblServiciosComputo>) sisaEntitie.tblServiciosComputo).FirstOrDefault<tblServiciosComputo>((Expression<Func<tblServiciosComputo, bool>>) (s => s.IdComputo.ToString() == pid));
          if (serviciosComputo != null)
          {
            serviciosComputo.PC = PC;
            serviciosComputo.Tipo = Tipo;
            serviciosComputo.Serie = Serie;
            serviciosComputo.FechaProximoMantenimiento = new DateTime?(FechaMto.Length > 0 ? DateTime.Parse(FechaMto) : DateTime.Now);
            serviciosComputo.Activo = false;
            serviciosComputo.Comentarios = serviciosComputo.Comentarios + "-" + txtComentariosCerrados;
            str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al cerrar servicio de computo." : "Servicio terminado.";
          }
          else
            str = "Ocurrio un problema al obtener información de servicio de computo seleccionada.";
        }
      }
      else
        str = "No tienes permiso de cerrar servicio de computo.";
      return str;
    }
  }
}
