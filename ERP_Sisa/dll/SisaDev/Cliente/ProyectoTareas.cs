// Decompiled with JetBrains decompiler
// Type: SisaDev.Cliente.ProyectoTareas
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

namespace SisaDev.Cliente
{
  public class ProyectoTareas : Page
  {
    public static tblClienteContacto usuario;
    public static string idProyecto = string.Empty;
    protected HtmlGenericControl lblProyectoTarea;
    protected HtmlGenericControl lblFolio;
    protected HtmlInputHidden idProyectoTarea;

    protected void Page_Load(object sender, EventArgs e)
    {
      ProyectoTareas.usuario = HttpContext.Current.Session["UsuarioClienteLogueado"] as tblClienteContacto;
      if (ProyectoTareas.usuario != null)
      {
        ProyectoTareas.idProyecto = this.Request.QueryString["id"];
        this.idProyectoTarea.Value = ProyectoTareas.idProyecto;
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblProyectos tblProyectos = ((IQueryable<tblProyectos>) sisaEntitie.tblProyectos).FirstOrDefault<tblProyectos>((Expression<Func<tblProyectos, bool>>) (p => p.IdProyecto.ToString() == ProyectoTareas.idProyecto));
          this.lblProyectoTarea.InnerText = tblProyectos.FolioProyecto + " " + tblProyectos.NombreProyecto + " Descripción: " + tblProyectos.Descripcion;
          this.lblFolio.InnerText = tblProyectos.NombreProyecto;
        }
      }
      else
        this.Response.Redirect("~/Default.aspx");
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
              using (FileStream fileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "Cliente\\docs\\" + tblDocProyectos.FileName, FileMode.Create, FileAccess.Write))
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
          Porcentaje = data.tt.Porcentaje
        }));
    }

    [WebMethod]
    public static string ObtenerImagenTarea(string pid)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
      {
        tblProyectoTaskImagen proyectoTaskImagen = ((IQueryable<tblProyectoTaskImagen>) sisaEntitie.tblProyectoTaskImagen).FirstOrDefault<tblProyectoTaskImagen>((Expression<Func<tblProyectoTaskImagen, bool>>) (a => a.IdTask.ToString() == pid));
        return proyectoTaskImagen != null ? JsonConvert.SerializeObject((object) proyectoTaskImagen) : "";
      }
    }

    [WebMethod]
    public static string CargarComentariosTareas(string pid)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
      {
        IQueryable<\u003C\u003Ef__AnonymousType20<Guid, string, string, DateTime>> queryable = ((IQueryable<tblProyectoTasksComentarios>) sisaEntitie.tblProyectoTasksComentarios).Join((IEnumerable<tblUsuarios>) sisaEntitie.tblUsuarios, (Expression<Func<tblProyectoTasksComentarios, Guid>>) (a => a.IdUsuario), (Expression<Func<tblUsuarios, Guid>>) (b => b.IdUsuario), (a, b) => new
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
        return queryable != null ? JsonConvert.SerializeObject((object) queryable) : "";
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
  }
}
