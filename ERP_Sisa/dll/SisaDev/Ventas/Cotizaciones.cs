// Decompiled with JetBrains decompiler
// Type: SisaDev.Ventas.Cotizaciones
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Ventas
{
  public class Cotizaciones : Page
  {
    public static tblUsuarios usuario;
    public static tblRolesUsuarios rolesUsuarios;
    protected TextBox txtPara;
    protected TextBox txtSubject;
    protected FileUpload FileUpload1;
    protected TextBox txtCorreo;
    protected Button btnEnviar;

    protected void Page_Load(object sender, EventArgs e)
    {
      Cotizaciones.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (Cotizaciones.usuario != null)
        Cotizaciones.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      else
        this.Response.Redirect("~/Default.aspx");
    }

    [WebMethod]
    public static string ObtenerCotizaciones(string pid)
    {
      string str = string.Empty;
      Cotizaciones.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Cotizaciones.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Cotizaciones.rolesUsuarios.Administracion || Cotizaciones.rolesUsuarios.Tipo == "ROOT" || Cotizaciones.rolesUsuarios.Tipo == "ADMINISTRACION" || Cotizaciones.rolesUsuarios.Cotizaciones)
      {
        if (pid.Trim() == "1")
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
            str = Cotizaciones.rolesUsuarios.Tipo == "GERENCIAL" || Cotizaciones.rolesUsuarios.Tipo == "ROOT" ? JsonConvert.SerializeObject((object) ((IEnumerable<sp_CargarCotizaciones_Result>) sisaEntitie.sp_CargarCotizaciones()).OrderByDescending<sp_CargarCotizaciones_Result, DateTime>((Func<sp_CargarCotizaciones_Result, DateTime>) (a => a.FechaCotizaciones))) : JsonConvert.SerializeObject((object) ((IEnumerable<sp_CargarCotizaciones_Result>) sisaEntitie.sp_CargarCotizaciones()).OrderByDescending<sp_CargarCotizaciones_Result, DateTime>((Func<sp_CargarCotizaciones_Result, DateTime>) (a => a.FechaCotizaciones)).Distinct<sp_CargarCotizaciones_Result>());
        }
        else
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
            str = JsonConvert.SerializeObject((object) ((IEnumerable<sp_CargarCotizaciones_Result>) sisaEntitie.sp_CargarCotizaciones()).Where<sp_CargarCotizaciones_Result>((Func<sp_CargarCotizaciones_Result, bool>) (c => c.IdCotizaciones.ToString() == pid)));
        }
      }
      else
        str = "";
      return str;
    }

    [WebMethod]
    public static string EliminarCotizaciones(string pid)
    {
      string str = string.Empty;
      Cotizaciones.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Cotizaciones.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Cotizaciones.rolesUsuarios.CotizacionesEliminar || Cotizaciones.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblCotizaciones tblCotizaciones = ((IQueryable<tblCotizaciones>) sisaEntitie.tblCotizaciones).FirstOrDefault<tblCotizaciones>((Expression<Func<tblCotizaciones, bool>>) (s => s.IdCotizaciones.ToString() == pid));
          if (tblCotizaciones != null)
          {
            tblCotizaciones.Estatus = 0;
            str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al eliminar cotización." : "Cotización eliminado.";
          }
        }
      }
      else
        str = "No tienes permiso de eliminar cotización.";
      return str;
    }

    [WebMethod]
    public static string CancelarCotizacion(string pid)
    {
      string str = string.Empty;
      Cotizaciones.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Cotizaciones.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Cotizaciones.rolesUsuarios.CotizacionesEliminar || Cotizaciones.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblCotizaciones tblCotizaciones = ((IQueryable<tblCotizaciones>) sisaEntitie.tblCotizaciones).FirstOrDefault<tblCotizaciones>((Expression<Func<tblCotizaciones, bool>>) (s => s.IdCotizaciones.ToString() == pid));
          if (tblCotizaciones != null)
          {
            tblCotizaciones.Estatus = 2;
            str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al cancelar Cotización." : "Cotización cancelado.";
          }
        }
      }
      else
        str = "No tienes permiso de cancelar Cotización.";
      return str;
    }

    [WebMethod]
    public static string CargarComentarios(string pid)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
        return JsonConvert.SerializeObject((object) ((IEnumerable<sp_CargarComentariosCotizacion_Result>) sisaEntitie.sp_CargarComentariosCotizacion(pid)).OrderByDescending<sp_CargarComentariosCotizacion_Result, string>((Func<sp_CargarComentariosCotizacion_Result, string>) (a => a.Fecha)));
    }

    [WebMethod]
    public static string GuardarComentarios(string pid, string Comentario)
    {
      string empty = string.Empty;
      Cotizaciones.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Cotizaciones.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
        return JsonConvert.SerializeObject((object) sisaEntitie.sp_InsertaComentarioCotizacion(pid, Comentario, Cotizaciones.usuario.IdUsuario.ToString()));
    }

    [WebMethod]
    protected void btnEnviar_Click(object sender, EventArgs e)
    {
    }

    [WebMethod]
    public static string GuardarArchivo(
      string IdCotizacion,
      string NombreArchivo,
      string Documento)
    {
      string str = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
      {
        tblCotizaciones tblCotizaciones = ((IQueryable<tblCotizaciones>) sisaEntitie.tblCotizaciones).FirstOrDefault<tblCotizaciones>((Expression<Func<tblCotizaciones, bool>>) (c => c.IdCotizaciones.ToString() == IdCotizacion));
        if (tblCotizaciones != null)
        {
          if (NombreArchivo.Contains(".pdf"))
          {
            tblCotizaciones.NombreArchivoPdf = NombreArchivo;
            tblCotizaciones.DocumentoPdf = Documento;
            sisaEntitie.SaveChanges();
          }
          else
          {
            if (!NombreArchivo.Contains(".xls"))
            {
              if (!NombreArchivo.Contains(".xlsx"))
                goto label_11;
            }
            tblCotizaciones.NombreArchivoXls = NombreArchivo;
            tblCotizaciones.DocumentoXls = Documento;
            sisaEntitie.SaveChanges();
          }
        }
        else
          str = "Error, no se encontro cotización seleccionada, intenta de nuevo.";
      }
label_11:
      return str;
    }

    [WebMethod]
    public static string ConvertirCotizacion(
      string pid,
      string Concepto,
      string dtInicial,
      string dtFinal,
      string idLider,
      string Nombre,
      string MOC,
      string MC,
      string MEC,
      string MOP,
      string MP,
      string MEP)
    {
      string str = string.Empty;
      Cotizaciones.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Cotizaciones.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Cotizaciones.rolesUsuarios.CotizacionesEditar || Cotizaciones.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblCotizaciones tblCotizaciones = ((IQueryable<tblCotizaciones>) sisaEntitie.tblCotizaciones).FirstOrDefault<tblCotizaciones>((Expression<Func<tblCotizaciones, bool>>) (s => s.IdCotizaciones.ToString() == pid));
          if (tblCotizaciones != null)
          {
            if (!string.IsNullOrEmpty(tblCotizaciones.DocumentoPdf) || !string.IsNullOrEmpty(tblCotizaciones.DocumentoXls))
            {
              string FolioProyecto = tblCotizaciones.NoCotizaciones.Replace("COT", "SIS");
              if (((IQueryable<tblProyectos>) sisaEntitie.tblProyectos).FirstOrDefault<tblProyectos>((Expression<Func<tblProyectos, bool>>) (p => p.FolioProyecto == FolioProyecto)) == null)
              {
                tblCotizaciones.Estatus = 3;
                tblProyectos tblProyectos = new tblProyectos()
                {
                  IdProyecto = Guid.NewGuid(),
                  EstatusDesc = "PENDIENTE",
                  Estatus = "0",
                  Activo = new int?(1),
                  FolioProyecto = FolioProyecto,
                  NombreProyecto = Nombre,
                  Descripcion = Concepto,
                  IdLider = idLider,
                  IdCliente = tblCotizaciones.idContacto.ToString(),
                  IdCotizacion = tblCotizaciones.IdCotizaciones.ToString(),
                  IdUsuarioAlta = new Guid?(Cotizaciones.usuario.IdUsuario),
                  IdUsuarioModificacion = new Guid?(Cotizaciones.usuario.IdUsuario),
                  FechaAlta = new DateTime?(DateTime.Now),
                  FechaModificacion = new DateTime?(DateTime.Now),
                  FechaFin = new DateTime?(DateTime.Parse(dtFinal)),
                  FechaInicio = new DateTime?(DateTime.Parse(dtInicial)),
                  CostoCotizacion = tblCotizaciones.CostoCotizaciones,
                  CostoMOCotizado = new double?(double.Parse(MOC) * 1.16),
                  CostoMaterialCotizado = new double?(double.Parse(MC) * 1.16),
                  CostoMECotizado = new double?(double.Parse(MEC) * 1.16),
                  CostoMOProyectado = new double?(double.Parse(MOP) * 1.16),
                  CostoMaterialProyectado = new double?(double.Parse(MP) * 1.16),
                  CostoMEProyectado = new double?(double.Parse(MEP) * 1.16)
                };
                sisaEntitie.tblProyectos.Add(tblProyectos);
                if (sisaEntitie.SaveChanges() > 0)
                {
                  tblEficiencias tblEficiencias = new tblEficiencias()
                  {
                    idProyecto = new Guid?(tblProyectos.IdProyecto),
                    ManoObra = new Decimal?(0M),
                    Equipo = new Decimal?(0M),
                    Material = new Decimal?(0M)
                  };
                  sisaEntitie.tblEficiencias.Add(tblEficiencias);
                  sisaEntitie.SaveChanges();
                  str = "Cotización convertida.";
                }
                else
                  str = "Ocurrio un problema al convertir Cotización.";
              }
              else
                str = "Cotización ya ha sido convertida a proyecto con anterioridad con folio:" + FolioProyecto;
            }
            else
              str = "Es necesario subir archivo de excel y pdf, para convertir cotización a proyecto.";
          }
          else
            str = "No se encontro información de cotización seleccioanda.";
        }
      }
      else
        str = "No tienes permiso de convertir Cotización.";
      return str;
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
    public static string CargarMontosCotizacion(string pid)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
      {
        Guid op = Guid.Parse(pid);
        return JsonConvert.SerializeObject((object) ((IQueryable<tblCotizaciones>) sisaEntitie.tblCotizaciones).Where<tblCotizaciones>((Expression<Func<tblCotizaciones, bool>>) (a => a.IdCotizaciones == op)).Select(a => new
        {
          CostoMOCotizado = a.CostoMOCotizado,
          CostoMECotizado = a.CostoMECotizado,
          CostoMaterialCotizado = a.CostoMaterialCotizado
        }));
      }
    }

    [WebMethod]
    public static string CargarDocumentos(string id, string Opcion)
    {
      string empty = string.Empty;
      try
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          IQueryable<\u003C\u003Ef__AnonymousType57<string, string, Guid>> queryable = ((IQueryable<tblCotizaciones>) sisaEntitie.tblCotizaciones).Where<tblCotizaciones>((Expression<Func<tblCotizaciones, bool>>) (p => p.IdCotizaciones.ToString() == id)).Select(p => new
          {
            Nombre = p.NombreArchivoPdf != default (string) ? p.NombreArchivoPdf : "",
            Archivo = p.DocumentoPdf != default (string) ? p.DocumentoPdf : "",
            IdCotizaciones = p.IdCotizaciones
          });
          foreach (var data in queryable)
          {
            if (!string.IsNullOrEmpty(data.Nombre) && !string.IsNullOrEmpty(data.Archivo))
            {
              string[] strArray = data.Archivo.Split(',');
              using (FileStream fileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "Ventas\\docs\\" + data.Nombre, FileMode.Create, FileAccess.Write))
                fileStream.Write(Convert.FromBase64String(strArray[1]), 0, Convert.FromBase64String(strArray[1]).Length);
            }
          }
          return JsonConvert.SerializeObject((object) queryable);
        }
      }
      catch (Exception ex)
      {
        return ex.ToString();
      }
    }

    [WebMethod]
    public static string CargarDocumentosExcel(string id, string Opcion)
    {
      string empty = string.Empty;
      try
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          IQueryable<\u003C\u003Ef__AnonymousType57<string, string, Guid>> queryable = ((IQueryable<tblCotizaciones>) sisaEntitie.tblCotizaciones).Where<tblCotizaciones>((Expression<Func<tblCotizaciones, bool>>) (p => p.IdCotizaciones.ToString() == id)).Select(p => new
          {
            Nombre = p.NombreArchivoXls != default (string) ? p.NombreArchivoXls : "",
            Archivo = p.DocumentoXls != default (string) ? p.DocumentoXls : "",
            IdCotizaciones = p.IdCotizaciones
          });
          foreach (var data in queryable)
          {
            if (!string.IsNullOrEmpty(data.Nombre) && !string.IsNullOrEmpty(data.Archivo))
            {
              string[] strArray = data.Archivo.Split(',');
              using (FileStream fileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "Ventas\\docs\\" + data.Nombre, FileMode.Create, FileAccess.Write))
                fileStream.Write(Convert.FromBase64String(strArray[1]), 0, Convert.FromBase64String(strArray[1]).Length);
            }
          }
          return JsonConvert.SerializeObject((object) queryable);
        }
      }
      catch (Exception ex)
      {
        return ex.ToString();
      }
    }
  }
}
