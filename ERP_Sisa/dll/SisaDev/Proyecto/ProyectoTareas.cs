// Decompiled with JetBrains decompiler
// Type: SisaDev.Proyecto.ProyectoTareas
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace SisaDev.Proyecto
{
  public class ProyectoTareas : Page
  {
    public static tblUsuarios usuario;
    public static tblRolesUsuarios rolesUsuarios;
    public static string idProyecto = string.Empty;
    protected HtmlGenericControl lblProyectoTarea;
    protected HtmlGenericControl lblFolio;
    protected HtmlGenericControl lblFechas;
    protected HtmlGenericControl lblEmpresa;
    protected HtmlGenericControl lblContacto;
    protected HtmlGenericControl lbllider;
    protected HtmlInputHidden idProyectoTarea;

    protected void Page_Load(object sender, EventArgs e)
    {
      ProyectoTareas.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (ProyectoTareas.usuario != null)
      {
        ProyectoTareas.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
        ProyectoTareas.idProyecto = this.Request.QueryString["id"];
        this.idProyectoTarea.Value = ProyectoTareas.idProyecto;
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          var data1 = ((IQueryable<tblProyectos>) sisaEntitie.tblProyectos).Join((IEnumerable<tblClienteContacto>) sisaEntitie.tblClienteContacto, (Expression<Func<tblProyectos, string>>) (p => p.IdCliente), (Expression<Func<tblClienteContacto, string>>) (c => c.idContacto.ToString()), (p, c) => new
          {
            p = p,
            c = c
          }).Join((IEnumerable<tblEmpresas>) sisaEntitie.tblEmpresas, data => data.c.idEmpresa, (Expression<Func<tblEmpresas, Guid>>) (u => u.idEmpresa), (data, u) => new
          {
            \u003C\u003Eh__TransparentIdentifier0 = data,
            u = u
          }).Join((IEnumerable<tblUsuarios>) sisaEntitie.tblUsuarios, data => data.\u003C\u003Eh__TransparentIdentifier0.p.IdLider, (Expression<Func<tblUsuarios, string>>) (x => x.IdUsuario.ToString()), (data, x) => new
          {
            \u003C\u003Eh__TransparentIdentifier1 = data,
            x = x
          }).Where(data => data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.IdProyecto.ToString() == ProyectoTareas.idProyecto).Select(data => new
          {
            IdProyecto = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.IdProyecto,
            FolioProyecto = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.FolioProyecto,
            NombreProyecto = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.NombreProyecto,
            Descripcion = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.Descripcion,
            RazonSocial = data.\u003C\u003Eh__TransparentIdentifier1.u.RazonSocial,
            FechaIY = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.FechaInicio.Value.Year,
            FechaIM = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.FechaInicio.Value.Month,
            FechaID = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.FechaInicio.Value.Day,
            FechaTY = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.FechaFin.Value.Year,
            FechaTM = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.FechaFin.Value.Month,
            FechaTD = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.p.FechaFin.Value.Day,
            NombreContacto = data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.c.NombreContacto,
            NombreCompleto = data.x.NombreCompleto
          }).FirstOrDefault(s => s.IdProyecto.ToString() == ProyectoTareas.idProyecto);
          this.lblProyectoTarea.InnerText = data1.FolioProyecto + " " + data1.NombreProyecto;
          this.lblFolio.InnerText = "Descripción: " + data1.Descripcion;
          int fechaIm = data1.FechaIM;
          HtmlGenericControl lblFechas = this.lblFechas;
          string[] strArray = new string[12];
          strArray[0] = "Fechas: ";
          strArray[1] = data1.FechaIY.ToString();
          strArray[2] = "-";
          int num = data1.FechaIM;
          string str1;
          if (num.ToString().Length != 1)
          {
            num = data1.FechaIM;
            str1 = num.ToString();
          }
          else
          {
            num = data1.FechaIM;
            str1 = "0" + num.ToString();
          }
          strArray[3] = str1;
          strArray[4] = "-";
          num = data1.FechaID;
          string str2;
          if (num.ToString().Length != 1)
          {
            num = data1.FechaID;
            str2 = num.ToString();
          }
          else
          {
            num = data1.FechaID;
            str2 = "0" + num.ToString();
          }
          strArray[5] = str2;
          strArray[6] = " al ";
          num = data1.FechaTY;
          strArray[7] = num.ToString();
          strArray[8] = "-";
          num = data1.FechaTM;
          string str3;
          if (num.ToString().Length != 1)
          {
            num = data1.FechaTM;
            str3 = num.ToString();
          }
          else
          {
            num = data1.FechaTM;
            str3 = "0" + num.ToString();
          }
          strArray[9] = str3;
          strArray[10] = "-";
          num = data1.FechaTD;
          string str4;
          if (num.ToString().Length != 1)
          {
            num = data1.FechaTD;
            str4 = num.ToString();
          }
          else
          {
            num = data1.FechaTD;
            str4 = "0" + num.ToString();
          }
          strArray[11] = str4;
          string str5 = string.Concat(strArray);
          lblFechas.InnerText = str5;
          this.lblEmpresa.InnerText = "Empresa: " + data1.RazonSocial;
          this.lblContacto.InnerText = "Contácto: " + data1.NombreContacto;
          this.lbllider.InnerText = "Lider proyecto: " + data1.NombreCompleto;
        }
      }
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
    public static string EliminarProyectosTarea(string pid)
    {
      string str = string.Empty;
      ProyectoTareas.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      ProyectoTareas.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (ProyectoTareas.rolesUsuarios.ProyectosEditar || ProyectoTareas.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblProyectoTasks tblProyectoTasks = ((IQueryable<tblProyectoTasks>) sisaEntitie.tblProyectoTasks).FirstOrDefault<tblProyectoTasks>((Expression<Func<tblProyectoTasks, bool>>) (s => s.IdTask.ToString() == pid));
          if (tblProyectoTasks != null)
          {
            tblProyectoTasks.Estatus = 6;
            str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al eliminar tarea." : "Tarea eliminado.";
          }
        }
      }
      else
        str = "No tienes permiso de eliminar tarea.";
      return str;
    }

    [WebMethod]
    public static string CargarGrafica(string IdProyecto)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
        return JsonConvert.SerializeObject((object) sisaEntitie.sp_GraficaTasks(IdProyecto));
    }

    [WebMethod]
    public static string CargarDetalleGrafica(string Nombre, string IdProyecto)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
        return JsonConvert.SerializeObject((object) sisaEntitie.sp_GraficaTasksDetalle(IdProyecto, Nombre));
    }

    [WebMethod]
    public static string CargaTareas()
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
        return JsonConvert.SerializeObject((object) ((IQueryable<tblProyectoTasks>) sisaEntitie.tblProyectoTasks).Join((IEnumerable<tblUsuarios>) sisaEntitie.tblUsuarios, (Expression<Func<tblProyectoTasks, Guid?>>) (tt => tt.IdUsuario), (Expression<Func<tblUsuarios, Guid?>>) (u => (Guid?) u.IdUsuario), (tt, u) => new
        {
          tt = tt,
          u = u
        }).Where(data => data.tt.IdProyecto.ToString() == ProyectoTareas.idProyecto && data.tt.Estatus < 6).Select(data => new
        {
          IdTask = data.tt.IdTask,
          Task = data.tt.Task,
          NombreCompleto = data.u.NombreCompleto,
          FechaInicio = data.tt.FechaInicio,
          FechaFin = data.tt.FechaFin,
          Dias = SqlFunctions.DateDiff("DAY", (DateTime?) data.tt.FechaInicio, (DateTime?) data.tt.FechaFin),
          DiasTranscurridos = SqlFunctions.DateDiff("DAY", (DateTime?) data.tt.FechaInicio, (DateTime?) DateTime.Now),
          Estatus = data.tt.Estatus,
          Comentarios = data.tt.Comentarios,
          Porcentaje = data.tt.Porcentaje,
          FechaAlta = data.tt.FechaAlta
        }).OrderByDescending(a => a.FechaAlta));
    }

    [WebMethod]
    public static string GuardarTarea(
      string pid,
      string Tarea,
      string Inicio,
      string Fin,
      string Comentario,
      string idUsuarioAsignado)
    {
      string str = string.Empty;
      ProyectoTareas.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      ProyectoTareas.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (ProyectoTareas.rolesUsuarios.ProyectosEditar || ProyectoTareas.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          Guid guid1 = Guid.Parse(pid);
          Guid guid2 = Guid.Parse(idUsuarioAsignado);
          tblProyectoTasks tblProyectoTasks = new tblProyectoTasks()
          {
            IdTask = Guid.NewGuid(),
            IdProyecto = guid1,
            Task = Tarea,
            FechaAlta = DateTime.Now,
            Comentarios = Comentario,
            IdUsuario = new Guid?(guid2),
            IdUsuarioAlta = ProyectoTareas.usuario.IdUsuario,
            IdUsuarioModificacion = new Guid?(ProyectoTareas.usuario.IdUsuario),
            FechaModificacion = new DateTime?(DateTime.Now),
            FechaFin = DateTime.Parse(Fin),
            FechaInicio = DateTime.Parse(Inicio),
            Estatus = 0,
            Porcentaje = new Decimal?(0M)
          };
          sisaEntitie.tblProyectoTasks.Add(tblProyectoTasks);
          sisaEntitie.SaveChanges();
          if (Comentario != "")
          {
            tblProyectoTasksComentarios tasksComentarios = new tblProyectoTasksComentarios()
            {
              IdTask = tblProyectoTasks.IdTask,
              Comentario = Comentario,
              IdTaskComentario = Guid.NewGuid(),
              Fecha = DateTime.Now,
              IdUsuario = ProyectoTareas.usuario.IdUsuario
            };
            sisaEntitie.tblProyectoTasksComentarios.Add(tasksComentarios);
            sisaEntitie.SaveChanges();
          }
          str = "Tarea agregada";
        }
      }
      else
        str = "No tienes permiso de agregar tareas.";
      return str;
    }

    [WebMethod]
    public static string ActualizarAvance(string pid, string Porcentaje)
    {
      string str = string.Empty;
      ProyectoTareas.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      ProyectoTareas.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (ProyectoTareas.rolesUsuarios.ProyectosEditar || ProyectoTareas.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblProyectoTasks tblProyectoTasks = ((IQueryable<tblProyectoTasks>) sisaEntitie.tblProyectoTasks).FirstOrDefault<tblProyectoTasks>((Expression<Func<tblProyectoTasks, bool>>) (s => s.IdTask.ToString() == pid));
          if (tblProyectoTasks != null)
          {
            tblProyectoTasks.Estatus = !(Porcentaje.Trim() == "100") ? 1 : 2;
            tblProyectoTasks.Porcentaje = new Decimal?(Decimal.Parse(Porcentaje));
            str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al actualizar avance tarea." : "Tarea actualizada.";
          }
          else
            str = "No se encontro información de la tarea seleccionada, intenta de nuevo actualizando página.";
        }
      }
      else
        str = "No tienes permiso de agregar avance tarea.";
      return str;
    }

    [WebMethod]
    public static string GuardarDocumentos(
      string IdDocumento,
      string IdProyecto,
      string FileName,
      string File,
      string Opcion)
    {
      string empty = string.Empty;
      try
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          Convert.ToInt32(Opcion);
          Guid guid = Guid.Parse(IdProyecto);
          tblDocProyectos tblDocProyectos = new tblDocProyectos()
          {
            IdDocumento = Guid.NewGuid(),
            IdProyecto = guid,
            FileName = FileName,
            File = File,
            Fecha = DateTime.Now
          };
          sisaEntitie.tblDocProyectos.Add(tblDocProyectos);
          sisaEntitie.SaveChanges();
          return "Archivo guardado";
        }
      }
      catch (Exception ex)
      {
        return ex.ToString();
      }
    }

    [WebMethod]
    public static string CargarDocumentos(
      string IdDocumento,
      string IdProyecto,
      string FileName,
      string File,
      string Opcion)
    {
      string empty = string.Empty;
      try
      {
        int int32 = Convert.ToInt32(Opcion);
        using (SisaEntitie sisaEntitie = new SisaEntitie())
          return JsonConvert.SerializeObject((object) sisaEntitie.sp_InsertDeleteDocumentosProyecto(IdDocumento, IdProyecto, FileName, File, new int?(int32)));
      }
      catch (Exception ex)
      {
        return ex.ToString();
      }
    }

    [WebMethod]
    public static string GuardarImagenTarea(
      string idTask,
      string IdProyecto,
      string FileName,
      string File,
      string Opcion)
    {
      string empty = string.Empty;
      ProyectoTareas.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      ProyectoTareas.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      try
      {
        Convert.ToInt32(Opcion);
        Guid guid = Guid.Parse(idTask);
        Guid.Parse(IdProyecto);
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblProyectoTaskImagen proyectoTaskImagen = new tblProyectoTaskImagen()
          {
            IdTaskImagen = Guid.NewGuid(),
            IdTask = guid,
            IdUsuario = ProyectoTareas.usuario.IdUsuario,
            Imagen = File,
            FileName = FileName,
            Descripcion = FileName,
            FileExtension = "",
            FileContentType = FileName,
            FileSize = FileName,
            Fecha = DateTime.Now
          };
          sisaEntitie.tblProyectoTaskImagen.Add(proyectoTaskImagen);
          sisaEntitie.SaveChanges();
          return "Archivo guardado";
        }
      }
      catch (Exception ex)
      {
        return ex.ToString();
      }
    }

    [WebMethod]
    public static string ObtenerImagenTarea(string pid)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
      {
        IQueryable<tblProyectoTaskImagen> queryable = ((IQueryable<tblProyectoTaskImagen>) sisaEntitie.tblProyectoTaskImagen).Where<tblProyectoTaskImagen>((Expression<Func<tblProyectoTaskImagen, bool>>) (a => a.IdTask.ToString() == pid));
        return queryable != null ? JsonConvert.SerializeObject((object) queryable) : "";
      }
    }

    [WebMethod]
    public static string CargarComentariosTareas(string pid)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
      {
        IQueryable<\u003C\u003Ef__AnonymousType20<Guid, string, string, DateTime>> source = ((IQueryable<tblProyectoTasksComentarios>) sisaEntitie.tblProyectoTasksComentarios).Join((IEnumerable<tblUsuarios>) sisaEntitie.tblUsuarios, (Expression<Func<tblProyectoTasksComentarios, Guid>>) (a => a.IdUsuario), (Expression<Func<tblUsuarios, Guid>>) (b => b.IdUsuario), (a, b) => new
        {
          a = a,
          b = b
        }).Where(data => data.a.IdTask.ToString() == pid).Select(data => new
        {
          IdTaskComentario = data.a.IdTaskComentario,
          Comentario = data.a.Comentario,
          NombreCompleto = data.b.NombreCompleto,
          Fecha = data.a.Fecha
        });
        if (source == null)
          return "";
        return JsonConvert.SerializeObject((object) source.OrderByDescending(a => a.Fecha));
      }
    }

    [WebMethod]
    public static string GuardarComentariosTarea(string pid, string Comentario)
    {
      string empty = string.Empty;
      try
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblProyectoTasksComentarios tasksComentarios = new tblProyectoTasksComentarios()
          {
            IdTask = Guid.Parse(pid),
            Comentario = Comentario,
            IdTaskComentario = Guid.NewGuid(),
            Fecha = DateTime.Now,
            IdUsuario = ProyectoTareas.usuario.IdUsuario
          };
          sisaEntitie.tblProyectoTasksComentarios.Add(tasksComentarios);
          sisaEntitie.SaveChanges();
          return "Tarea agregada.";
        }
      }
      catch (Exception ex)
      {
        return "";
      }
    }

    [WebMethod]
    public static string ObtenerFechas(string pid)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
        return JsonConvert.SerializeObject((object) ((IQueryable<tblProyectoTasks>) sisaEntitie.tblProyectoTasks).Where<tblProyectoTasks>((Expression<Func<tblProyectoTasks, bool>>) (p => p.IdTask.ToString() == pid)).Select(p => new
        {
          FechaInicio = p.FechaInicio,
          FechaFin = p.FechaFin
        }));
    }

    [WebMethod]
    public static string GuardarFechas(string pid, string Razon, string Inicio, string Fin)
    {
      string str = string.Empty;
      ProyectoTareas.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      ProyectoTareas.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (ProyectoTareas.rolesUsuarios.ProyectosEditar || ProyectoTareas.rolesUsuarios.Tipo == "ROOT" || ProyectoTareas.rolesUsuarios.Tipo == "GERENCIAL")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblProyectoTasks tblProyectoTasks = ((IQueryable<tblProyectoTasks>) sisaEntitie.tblProyectoTasks).FirstOrDefault<tblProyectoTasks>((Expression<Func<tblProyectoTasks, bool>>) (a => a.IdTask.ToString() == pid));
          if (tblProyectoTasks != null)
          {
            tblProyectoTasks.FechaInicio = DateTime.Parse(Inicio);
            tblProyectoTasks.FechaFin = DateTime.Parse(Fin);
            sisaEntitie.SaveChanges();
            tblProyectoTasksComentarios tasksComentarios = new tblProyectoTasksComentarios()
            {
              IdTask = Guid.Parse(pid),
              Comentario = "CAMBIO DE FECHAS, RAZON: " + Razon,
              IdTaskComentario = Guid.NewGuid(),
              Fecha = DateTime.Now,
              IdUsuario = ProyectoTareas.usuario.IdUsuario
            };
            sisaEntitie.tblProyectoTasksComentarios.Add(tasksComentarios);
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

    [WebMethod]
    public static string VerPdf(string id)
    {
      string str = string.Empty;
      try
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblDocProyectos tblDocProyectos = ((IQueryable<tblDocProyectos>) sisaEntitie.tblDocProyectos).FirstOrDefault<tblDocProyectos>((Expression<Func<tblDocProyectos, bool>>) (a => a.IdDocumento.ToString() == id));
          if (tblDocProyectos != null)
          {
            if (!string.IsNullOrEmpty(tblDocProyectos.FileName) && !string.IsNullOrEmpty(tblDocProyectos.File))
            {
              string[] strArray = tblDocProyectos.File.Split(',');
              using (FileStream fileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "Proyecto\\docs\\" + tblDocProyectos.FileName, FileMode.Create, FileAccess.Write))
                fileStream.Write(Convert.FromBase64String(strArray[1]), 0, Convert.FromBase64String(strArray[1]).Length);
            }
            str = JsonConvert.SerializeObject((object) tblDocProyectos);
          }
          else
            str = "No se encontro archivo.";
        }
      }
      catch (Exception ex)
      {
        str = ex.ToString();
      }
      return str.Replace("FileName", "NombreArchivo");
    }
  }
}
