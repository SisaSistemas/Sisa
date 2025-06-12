// Decompiled with JetBrains decompiler
// Type: SisaDev.Proyectos.Administracion
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
  public class Administracion : Page
  {
    public static tblUsuarios usuario;
    public static tblRolesUsuarios rolesUsuarios;

    protected void Page_Load(object sender, EventArgs e)
    {
      Administracion.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (Administracion.usuario != null)
        Administracion.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      else
        this.Response.Redirect("~/Default.aspx");
    }

    [WebMethod]
    public static string CargarCombos(string Opcion)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
      {
        int int32 = Convert.ToInt32(Opcion);
        return JsonConvert.SerializeObject((object) sisaEntitie.sp_CargaCombos(new int?(int32)));
      }
    }

    [WebMethod]
    public static string CargarTotal(string Opcion)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
      {
        int int32 = Convert.ToInt32(Opcion);
        return JsonConvert.SerializeObject((object) sisaEntitie.sp_TotalSinOrden(new int?(int32)));
      }
    }

    [WebMethod]
    public static string ObtenerProyectos(string pid)
    {
      string str = string.Empty;
      Administracion.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Administracion.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Administracion.rolesUsuarios.Administracion || Administracion.rolesUsuarios.Tipo == "ROOT" || Administracion.rolesUsuarios.Tipo == "GERENCIAL" || Administracion.rolesUsuarios.Tipo == "ADMINISTRACION")
      {
        if (pid.Trim() == "1")
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
            str = Administracion.rolesUsuarios.Tipo == "ROOT" || Administracion.rolesUsuarios.Tipo == "GERENCIAL" || Administracion.rolesUsuarios.Tipo == "ADMINISTRACION" ? JsonConvert.SerializeObject((object) sisaEntitie.sp_Administracion()) : JsonConvert.SerializeObject((object) ((IEnumerable<sp_Administracion_Result>) sisaEntitie.sp_Administracion()).Where<sp_Administracion_Result>((Func<sp_Administracion_Result, bool>) (a =>
            {
              Guid? idSucursal7 = a.idSucursal;
              Guid? idSucursal8 = Administracion.usuario.idSucursal;
              if (idSucursal7.HasValue != idSucursal8.HasValue)
                return false;
              return !idSucursal7.HasValue || idSucursal7.GetValueOrDefault() == idSucursal8.GetValueOrDefault();
            })));
        }
        else
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
            str = JsonConvert.SerializeObject((object) ((IEnumerable<sp_Administracion_Result>) sisaEntitie.sp_Administracion()).Where<sp_Administracion_Result>((Func<sp_Administracion_Result, bool>) (a => a.IdProyecto.ToString() == pid)).OrderBy<sp_Administracion_Result, long?>((Func<sp_Administracion_Result, long?>) (a => a.ID)));
        }
      }
      else
        str = "No tienes permiso.";
      return str;
    }

    [WebMethod]
    public static string CargarDocumentos(string IdProyecto, string Opcion)
    {
      string str = string.Empty;
      try
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          if (Opcion == "OC")
            str = JsonConvert.SerializeObject((object) ((IQueryable<tblProyectos>) sisaEntitie.tblProyectos).Where<tblProyectos>((Expression<Func<tblProyectos, bool>>) (p => p.IdProyecto.ToString() == IdProyecto)).Select(p => new
            {
              NombreOC = p.NombreOC != default (string) ? p.NombreOC : "",
              ArchivoOC = p.ArchivoOC != default (string) ? p.ArchivoOC : "",
              IdProyecto = p.IdProyecto
            }));
          else if (Opcion == "CL")
            str = JsonConvert.SerializeObject((object) ((IQueryable<tblProyectos>) sisaEntitie.tblProyectos).Where<tblProyectos>((Expression<Func<tblProyectos, bool>>) (p => p.IdProyecto.ToString() == IdProyecto)).Select(p => new
            {
              NombreCL = p.NombreCL != default (string) ? p.NombreCL : "",
              ArchivoCL = p.ArchivoCL != default (string) ? p.ArchivoCL : "",
              IdProyecto = p.IdProyecto
            }));
        }
      }
      catch (Exception ex)
      {
        str = ex.ToString();
      }
      return str;
    }

    [WebMethod]
    public static string EliminarDocumento(string IdProyecto, string Opcion)
    {
      string str = string.Empty;
      Administracion.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Administracion.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Administracion.rolesUsuarios.ProyectosEditar || Administracion.rolesUsuarios.Tipo == "ROOT" || Administracion.rolesUsuarios.Tipo == "GERENCIAL" || Administracion.rolesUsuarios.Tipo == "ADMINISTRACION")
      {
        try
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
          {
            if (Opcion == "OC")
            {
              tblProyectos tblProyectos = ((IQueryable<tblProyectos>) sisaEntitie.tblProyectos).FirstOrDefault<tblProyectos>((Expression<Func<tblProyectos, bool>>) (p => p.IdProyecto.ToString() == IdProyecto));
              if (tblProyectos != null)
              {
                tblProyectos.ArchivoOC = "";
                tblProyectos.NombreOC = "";
                sisaEntitie.SaveChanges();
                str = "Documento eliminado.";
              }
              else
                str = "No se encontro información de documento, intenta de nuevo recargando página";
            }
            else if (Opcion == "CL")
            {
              tblProyectos tblProyectos = ((IQueryable<tblProyectos>) sisaEntitie.tblProyectos).FirstOrDefault<tblProyectos>((Expression<Func<tblProyectos, bool>>) (p => p.IdProyecto.ToString() == IdProyecto));
              if (tblProyectos != null)
              {
                tblProyectos.ArchivoCL = "";
                tblProyectos.NombreCL = "";
                sisaEntitie.SaveChanges();
                str = "Documento eliminado.";
              }
              else
                str = "No se encontro información de documento, intenta de nuevo recargando página";
            }
          }
        }
        catch (Exception ex)
        {
          str = ex.ToString();
        }
      }
      else
        str = "No tienes permiso de edición.";
      return str;
    }

    [WebMethod]
    public static string GuardarDocumentos(
      string TipoDoc,
      string IdProyecto,
      string FileName,
      string File)
    {
      string str = string.Empty;
      Administracion.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Administracion.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Administracion.rolesUsuarios.ProyectosEditar || Administracion.rolesUsuarios.Tipo == "ROOT" || Administracion.rolesUsuarios.Tipo == "GERENCIAL" || Administracion.rolesUsuarios.Tipo == "ADMINISTRACION")
      {
        try
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
          {
            Guid id = Guid.Parse(IdProyecto);
            tblProyectos tblProyectos = ((IQueryable<tblProyectos>) sisaEntitie.tblProyectos).FirstOrDefault<tblProyectos>((Expression<Func<tblProyectos, bool>>) (p => p.IdProyecto == id));
            if (tblProyectos != null)
            {
              if (TipoDoc.Trim() == "1")
              {
                tblProyectos.ArchivoOC = File;
                tblProyectos.NombreOC = FileName;
              }
              else if (TipoDoc.Trim() == "2")
              {
                tblProyectos.ArchivoCL = File;
                tblProyectos.NombreCL = FileName;
              }
              tblProyectos.IdUsuarioModificacion = new Guid?(Administracion.usuario.IdUsuario);
              tblProyectos.FechaModificacion = new DateTime?(DateTime.Now);
              sisaEntitie.SaveChanges();
              str = "Archivo guardado";
            }
            else
              str = "Ocurrio un error al obtener información de proyecto, recarga la página e intenta de nuevo.";
          }
        }
        catch (Exception ex)
        {
          str = ex.ToString();
        }
      }
      else
        str = "No tienes permiso de edición.";
      return str;
    }

    [WebMethod]
    public static string CambiarEstatus(string pid, string Estatus)
    {
      string str = string.Empty;
      Administracion.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Administracion.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Administracion.rolesUsuarios.ProyectosEditar || Administracion.rolesUsuarios.Tipo == "ROOT" || Administracion.rolesUsuarios.Tipo == "GERENCIAL" || Administracion.rolesUsuarios.Tipo == "ADMINISTRACION")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblProyectos tblProyectos = ((IQueryable<tblProyectos>) sisaEntitie.tblProyectos).FirstOrDefault<tblProyectos>((Expression<Func<tblProyectos, bool>>) (s => s.IdProyecto.ToString() == pid));
          if (tblProyectos != null)
          {
            tblProyectos.Estatus = Estatus;
            str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al actualizar proyecto." : "Proyecto actualizado.";
          }
        }
      }
      else
        str = "No tienes permiso de actualizar proyecto.";
      return str;
    }

    [WebMethod]
    public static string FinalizarProyecto(string pid)
    {
      string str = string.Empty;
      Administracion.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Administracion.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Administracion.rolesUsuarios.ProyectosEditar || Administracion.rolesUsuarios.Tipo == "ROOT" || Administracion.rolesUsuarios.Tipo == "GERENCIAL" || Administracion.rolesUsuarios.Tipo == "ADMINISTRACION")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblProyectos tblProyectos = ((IQueryable<tblProyectos>) sisaEntitie.tblProyectos).FirstOrDefault<tblProyectos>((Expression<Func<tblProyectos, bool>>) (s => s.IdProyecto.ToString() == pid));
          if (tblProyectos != null)
          {
            tblProyectos.Estatus = "3";
            str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al finalizar proyecto." : "Proyecto finalizado.";
          }
        }
      }
      else
        str = "No tienes permiso de finalizar proyecto.";
      return str;
    }

    [WebMethod]
    public static string CargarGastos(string pid)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
        return JsonConvert.SerializeObject((object) ((IQueryable<tblProyectos>) sisaEntitie.tblProyectos).Where<tblProyectos>((Expression<Func<tblProyectos, bool>>) (a => a.IdProyecto.ToString() == pid)).Select(a => new
        {
          CostoMOProyectado = a.CostoMOProyectado,
          CostoMaterialProyectado = a.CostoMaterialProyectado,
          CostoMEProyectado = a.CostoMEProyectado,
          CostoMOCotizado = a.CostoMOCotizado,
          CostoMaterialCotizado = a.CostoMaterialCotizado,
          CostoMECotizado = a.CostoMECotizado
        }));
    }

    [WebMethod]
    public static string CambiarGastos(
      string pid,
      string MO,
      string M,
      string ME,
      string MOC,
      string MC,
      string MEC)
    {
      string str = string.Empty;
      Administracion.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Administracion.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Administracion.rolesUsuarios.ProyectosEditar || Administracion.rolesUsuarios.Tipo == "ROOT" || Administracion.rolesUsuarios.Tipo == "GERENCIAL" || Administracion.rolesUsuarios.Tipo == "ADMINISTRACION")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblProyectos tblProyectos = ((IQueryable<tblProyectos>) sisaEntitie.tblProyectos).FirstOrDefault<tblProyectos>((Expression<Func<tblProyectos, bool>>) (s => s.IdProyecto.ToString() == pid));
          if (tblProyectos != null)
          {
            tblProyectos.CostoMaterialProyectado = new double?(double.Parse(M));
            tblProyectos.CostoMEProyectado = new double?(double.Parse(ME));
            tblProyectos.CostoMOProyectado = new double?(double.Parse(MO));
            tblProyectos.CostoMOCotizado = new double?(double.Parse(MOC));
            tblProyectos.CostoMaterialCotizado = new double?(double.Parse(MC));
            tblProyectos.CostoMECotizado = new double?(double.Parse(MEC));
            str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al actualizar proyecto, o no se detecto cambios." : "Proyecto actualizado.";
          }
        }
      }
      else
        str = "No tienes permiso de editar proyecto.";
      return str;
    }

    [WebMethod]
    public static string CambiarMonto(string pid, string Monto)
    {
      string str = string.Empty;
      Administracion.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Administracion.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Administracion.rolesUsuarios.ProyectosEditar || Administracion.rolesUsuarios.Tipo == "ROOT" || Administracion.rolesUsuarios.Tipo == "GERENCIAL" || Administracion.rolesUsuarios.Tipo == "ADMINISTRACION")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblProyectos tblProyectos = ((IQueryable<tblProyectos>) sisaEntitie.tblProyectos).FirstOrDefault<tblProyectos>((Expression<Func<tblProyectos, bool>>) (s => s.IdProyecto.ToString() == pid));
          if (tblProyectos != null)
          {
            double num1 = double.Parse(Monto) * 0.16;
            double num2 = double.Parse(Monto) + num1;
            tblProyectos.CostoCotizacion = new Decimal?(Decimal.Parse(num2.ToString()));
            str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al actualizar proyecto, no se encontraron cambios, el monto es igual al registrado actualmente." : "Proyecto actualizado.";
          }
        }
      }
      else
        str = "No tienes permiso de actualizar proyecto.";
      return str;
    }

    [WebMethod]
    public static string CambiarLider(string pid, string idLider)
    {
      string str = string.Empty;
      Administracion.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Administracion.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Administracion.rolesUsuarios.ProyectosEditar || Administracion.rolesUsuarios.Tipo == "ROOT" || Administracion.rolesUsuarios.Tipo == "GERENCIAL" || Administracion.rolesUsuarios.Tipo == "ADMINISTRACION")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblProyectos tblProyectos = ((IQueryable<tblProyectos>) sisaEntitie.tblProyectos).FirstOrDefault<tblProyectos>((Expression<Func<tblProyectos, bool>>) (s => s.IdProyecto.ToString() == pid));
          if (tblProyectos != null)
          {
            tblProyectos.IdLider = idLider;
            str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al actualizar proyecto." : "Proyecto actualizado.";
          }
        }
      }
      else
        str = "No tienes permiso de actualizar proyecto.";
      return str;
    }
  }
}
