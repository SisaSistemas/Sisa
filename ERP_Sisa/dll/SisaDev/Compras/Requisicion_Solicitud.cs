// Decompiled with JetBrains decompiler
// Type: SisaDev.Compras.Requisicion_Solicitud
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Compras
{
  public class Requisicion_Solicitud : Page
  {
    public static tblUsuarios usuario;
    public static tblRolesUsuarios rolesUsuarios;
    public static tblSolicitudesAprobacion ReqEditable;
    public static string idRequisicion = string.Empty;
    public static bool Todos = true;
    protected PlaceHolder ErrorMessage;
    protected Literal FailureText;

    protected void Page_Load(object sender, EventArgs e)
    {
      Requisicion_Solicitud.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (Requisicion_Solicitud.usuario != null)
      {
        Requisicion_Solicitud.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
        Requisicion_Solicitud.idRequisicion = this.Request.QueryString["idReq"];
        if (Requisicion_Solicitud.idRequisicion != null)
          Requisicion_Solicitud.Todos = false;
        else
          Requisicion_Solicitud.Todos = true;
      }
      else
        this.Response.Redirect("~/Default.aspx");
    }

    [WebMethod]
    public static string CargarSolicitud()
    {
      string empty = string.Empty;
      Requisicion_Solicitud.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Requisicion_Solicitud.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Requisicion_Solicitud.Todos)
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          if (Requisicion_Solicitud.rolesUsuarios.Tipo == "GERENCIAL" || Requisicion_Solicitud.rolesUsuarios.Tipo == "ROOT" || Requisicion_Solicitud.rolesUsuarios.Tipo == "COMPRAS")
            return JsonConvert.SerializeObject((object) ((IQueryable<tblSolicitudesAprobacion>) sisaEntitie.tblSolicitudesAprobacion).Where<tblSolicitudesAprobacion>((Expression<Func<tblSolicitudesAprobacion, bool>>) (r => r.Tipo == "REQUISICION")).OrderByDescending<tblSolicitudesAprobacion, int>((Expression<Func<tblSolicitudesAprobacion, int>>) (r => r.idSolicitud)).Select(r => new
            {
              idSolicitud = r.idSolicitud,
              timestamp = DbFunctions.TruncateTime((DateTime?) r.timestamp),
              Comentarios = r.Comentarios,
              UsuarioSolicita = r.UsuarioSolicita,
              idDocumento = r.idDocumento,
              CondicionEstatus = r.CondicionEstatus
            }));
          return JsonConvert.SerializeObject((object) ((IQueryable<tblSolicitudesAprobacion>) sisaEntitie.tblSolicitudesAprobacion).Where<tblSolicitudesAprobacion>((Expression<Func<tblSolicitudesAprobacion, bool>>) (r => r.Tipo == "REQUISICION" && r.idUsuarioSolicita == Requisicion_Solicitud.usuario.IdUsuario.ToString())).OrderByDescending<tblSolicitudesAprobacion, int>((Expression<Func<tblSolicitudesAprobacion, int>>) (r => r.idSolicitud)).Select(r => new
          {
            idSolicitud = r.idSolicitud,
            timestamp = DbFunctions.TruncateTime((DateTime?) r.timestamp),
            Comentarios = r.Comentarios,
            UsuarioSolicita = r.UsuarioSolicita,
            idDocumento = r.idDocumento,
            CondicionEstatus = r.CondicionEstatus
          }));
        }
      }
      else
      {
        Guid id = Guid.Parse(Requisicion_Solicitud.idRequisicion);
        using (SisaEntitie sisaEntitie = new SisaEntitie())
          return JsonConvert.SerializeObject((object) ((IQueryable<tblSolicitudesAprobacion>) sisaEntitie.tblSolicitudesAprobacion).Where<tblSolicitudesAprobacion>((Expression<Func<tblSolicitudesAprobacion, bool>>) (r => r.idDocumento == id)).Select(r => new
          {
            idSolicitud = r.idSolicitud,
            timestamp = DbFunctions.TruncateTime((DateTime?) r.timestamp),
            Comentarios = r.Comentarios,
            UsuarioSolicita = r.UsuarioSolicita,
            idDocumento = r.idDocumento,
            CondicionEstatus = r.CondicionEstatus
          }));
      }
    }

    [WebMethod]
    public static string AprobarRechazar(string pid, string pEstatus)
    {
      string str = string.Empty;
      int id = Convert.ToInt32(pid);
      Requisicion_Solicitud.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Requisicion_Solicitud.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Requisicion_Solicitud.rolesUsuarios.Tipo == "GERENCIAL" || Requisicion_Solicitud.rolesUsuarios.Tipo == "COMPRAS" || Requisicion_Solicitud.rolesUsuarios.Tipo == "ROOT")
      {
        if (pEstatus == "true")
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
          {
            tblSolicitudesAprobacion a = ((IQueryable<tblSolicitudesAprobacion>) sisaEntitie.tblSolicitudesAprobacion).FirstOrDefault<tblSolicitudesAprobacion>((Expression<Func<tblSolicitudesAprobacion, bool>>) (s => s.idSolicitud == id));
            if (a != null)
            {
              tblReqEnc tblReqEnc = ((IQueryable<tblReqEnc>) sisaEntitie.tblReqEnc).FirstOrDefault<tblReqEnc>((Expression<Func<tblReqEnc, bool>>) (r => r.IdReqEnc == a.idDocumento));
              if (tblReqEnc != null)
              {
                tblReqEnc.FechaAutorizada = new DateTime?(DateTime.Now);
                IQueryable<tblSolicitudesAprobacion> queryable = ((IQueryable<tblSolicitudesAprobacion>) sisaEntitie.tblSolicitudesAprobacion).Where<tblSolicitudesAprobacion>((Expression<Func<tblSolicitudesAprobacion, bool>>) (r => r.idDocumento == a.idDocumento && r.Estatus == true));
                if (queryable != null)
                {
                  foreach (tblSolicitudesAprobacion solicitudesAprobacion in (IEnumerable<tblSolicitudesAprobacion>) queryable)
                    solicitudesAprobacion.Estatus = false;
                }
                sisaEntitie.SaveChanges();
              }
              a.Estatus = false;
              a.CondicionEstatus = "APROBADA";
              sisaEntitie.SaveChanges();
              tblSolicitudesAprobacion solicitudesAprobacion1 = new tblSolicitudesAprobacion()
              {
                idUsuarioAprobo = new Guid?(Requisicion_Solicitud.usuario.IdUsuario),
                idUsuarioSolicita = a.idUsuarioSolicita,
                usuarioAprobo = Requisicion_Solicitud.usuario.Usuario,
                UsuarioSolicita = a.UsuarioSolicita,
                Comentarios = "APROBADA " + a.Comentarios,
                Estatus = true,
                CondicionEstatus = "Enviado",
                idDocumento = a.idDocumento,
                timestamp = DateTime.Now,
                Tipo = "MENSAJES"
              };
              sisaEntitie.tblSolicitudesAprobacion.Add(solicitudesAprobacion1);
              sisaEntitie.SaveChanges();
              str = "Requisición actualizada.";
            }
            else
              str = "Ocurrio un problema al obtener información.";
          }
        }
        else
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
          {
            tblSolicitudesAprobacion solicitudesAprobacion = ((IQueryable<tblSolicitudesAprobacion>) sisaEntitie.tblSolicitudesAprobacion).FirstOrDefault<tblSolicitudesAprobacion>((Expression<Func<tblSolicitudesAprobacion, bool>>) (s => s.idSolicitud == id));
            if (solicitudesAprobacion != null)
            {
              solicitudesAprobacion.Estatus = false;
              solicitudesAprobacion.CondicionEstatus = "RECHAZADA";
              sisaEntitie.SaveChanges();
              str = "Requisición actualizada.";
            }
            else
              str = "Ocurrio un problema al obtener información.";
          }
        }
      }
      else
        str = "No tienes privilegios de usuario.";
      return str;
    }
  }
}
