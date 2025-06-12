// Decompiled with JetBrains decompiler
// Type: SisaDev.Compras.Mensajes
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Compras
{
  public class Mensajes : Page
  {
    public static tblUsuarios usuario;
    public static tblRolesUsuarios rolesUsuarios;
    public static tblSolicitudesAprobacion ReqEditable;
    public static string idRFQ = string.Empty;
    public static bool Todos = true;
    protected PlaceHolder ErrorMessage;
    protected Literal FailureText;

    protected void Page_Load(object sender, EventArgs e)
    {
      Mensajes.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (Mensajes.usuario != null)
      {
        Mensajes.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
        Mensajes.idRFQ = this.Request.QueryString["idMsj"];
        if (Mensajes.idRFQ != null)
          Mensajes.Todos = false;
        else
          Mensajes.Todos = true;
      }
      else
        this.Response.Redirect("~/Default.aspx");
    }

    [WebMethod]
    public static string CargarSolicitud()
    {
      string empty = string.Empty;
      Mensajes.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Mensajes.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Mensajes.Todos)
      {
        if (Mensajes.rolesUsuarios.Tipo == "GERENCIAL" || Mensajes.rolesUsuarios.Tipo == "ROOT" || Mensajes.rolesUsuarios.Tipo == "COMPRAS")
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
            return JsonConvert.SerializeObject((object) ((IQueryable<tblSolicitudesAprobacion>) sisaEntitie.tblSolicitudesAprobacion).Where<tblSolicitudesAprobacion>((Expression<Func<tblSolicitudesAprobacion, bool>>) (r => r.Tipo == "MENSAJES")).OrderByDescending<tblSolicitudesAprobacion, int>((Expression<Func<tblSolicitudesAprobacion, int>>) (r => r.idSolicitud)).Select(r => new
            {
              idSolicitud = r.idSolicitud,
              timestamp = DbFunctions.TruncateTime((DateTime?) r.timestamp),
              Comentarios = r.Comentarios,
              UsuarioSolicita = r.UsuarioSolicita,
              idDocumento = r.idDocumento,
              CondicionEstatus = r.CondicionEstatus,
              Tipo = r.Tipo
            }));
        }
        else
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
            return JsonConvert.SerializeObject((object) ((IQueryable<tblSolicitudesAprobacion>) sisaEntitie.tblSolicitudesAprobacion).Where<tblSolicitudesAprobacion>((Expression<Func<tblSolicitudesAprobacion, bool>>) (r => r.Tipo == "MENSAJES" && r.idUsuarioSolicita == Mensajes.usuario.IdUsuario.ToString())).OrderByDescending<tblSolicitudesAprobacion, int>((Expression<Func<tblSolicitudesAprobacion, int>>) (r => r.idSolicitud)).Select(r => new
            {
              idSolicitud = r.idSolicitud,
              timestamp = DbFunctions.TruncateTime((DateTime?) r.timestamp),
              Comentarios = r.Comentarios,
              UsuarioSolicita = r.UsuarioSolicita,
              idDocumento = r.idDocumento,
              CondicionEstatus = r.CondicionEstatus,
              Tipo = r.Tipo
            }));
        }
      }
      else
      {
        Guid id = Guid.Parse(Mensajes.idRFQ);
        using (SisaEntitie sisaEntitie = new SisaEntitie())
          return JsonConvert.SerializeObject((object) ((IQueryable<tblSolicitudesAprobacion>) sisaEntitie.tblSolicitudesAprobacion).Where<tblSolicitudesAprobacion>((Expression<Func<tblSolicitudesAprobacion, bool>>) (r => r.idDocumento == id)).Select(r => new
          {
            idSolicitud = r.idSolicitud,
            timestamp = DbFunctions.TruncateTime((DateTime?) r.timestamp),
            Comentarios = r.Comentarios,
            UsuarioSolicita = r.UsuarioSolicita,
            idDocumento = r.idDocumento,
            CondicionEstatus = r.CondicionEstatus,
            Tipo = r.Tipo
          }));
      }
    }

    [WebMethod]
    public static string AprobarRechazar(string pid, string pEstatus)
    {
      string empty = string.Empty;
      int id = Convert.ToInt32(pid);
      using (SisaEntitie sisaEntitie = new SisaEntitie())
      {
        tblSolicitudesAprobacion solicitudesAprobacion = ((IQueryable<tblSolicitudesAprobacion>) sisaEntitie.tblSolicitudesAprobacion).FirstOrDefault<tblSolicitudesAprobacion>((Expression<Func<tblSolicitudesAprobacion, bool>>) (s => s.idSolicitud == id));
        if (solicitudesAprobacion == null)
          return "Ocurrio un problema al obtener información.";
        solicitudesAprobacion.Comentarios += " LEIDO";
        solicitudesAprobacion.Estatus = false;
        sisaEntitie.SaveChanges();
        return "Mensajes actualizada.";
      }
    }
  }
}
