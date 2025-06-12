// Decompiled with JetBrains decompiler
// Type: SisaDev.Compras.Requisicion_Edicion
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
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SisaDev.Compras
{
  public class Requisicion_Edicion : Page
  {
    public static tblUsuarios usuario;
    public static tblRolesUsuarios rolesUsuarios;
    public static tblReqEnc ReqEditable;
    public static List<tblReqDet> ReqEditableDetalles;
    public static string idRequisicion = string.Empty;
    protected PlaceHolder ErrorMessage;
    protected Literal FailureText;
    protected HtmlInputHidden txtIdRequicion;

    protected void Page_Load(object sender, EventArgs e)
    {
      Requisicion_Edicion.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (Requisicion_Edicion.usuario != null)
      {
        Requisicion_Edicion.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
        Requisicion_Edicion.idRequisicion = this.Request.QueryString["idReq"];
        this.txtIdRequicion.Value = Requisicion_Edicion.idRequisicion;
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          Guid id = Guid.Parse(Requisicion_Edicion.idRequisicion);
          Requisicion_Edicion.ReqEditable = ((IQueryable<tblReqEnc>) sisaEntitie.tblReqEnc).FirstOrDefault<tblReqEnc>((Expression<Func<tblReqEnc, bool>>) (r => r.IdReqEnc == id));
          if (Requisicion_Edicion.ReqEditable != null)
          {
            Requisicion_Edicion.ReqEditableDetalles = ((IQueryable<tblReqDet>) sisaEntitie.tblReqDet).Where<tblReqDet>((Expression<Func<tblReqDet, bool>>) (r => r.IdReqEnc == id)).ToList<tblReqDet>();
          }
          else
          {
            this.FailureText.Text = "No se encontro información.";
            this.ErrorMessage.Visible = true;
          }
        }
      }
      else
        this.Response.Redirect("~/Default.aspx");
    }

    [WebMethod]
    public static string ObtenerRequisicion()
    {
      using (SisaEntitie sisaEntitie = new SisaEntitie())
      {
        Guid id = Guid.Parse(Requisicion_Edicion.idRequisicion);
        return JsonConvert.SerializeObject((object) ((IQueryable<tblReqEnc>) sisaEntitie.tblReqEnc).Join((IEnumerable<tblProyectos>) sisaEntitie.tblProyectos, (Expression<Func<tblReqEnc, Guid>>) (r => r.IdProyecto), (Expression<Func<tblProyectos, Guid>>) (p => p.IdProyecto), (r, p) => new
        {
          r = r,
          p = p
        }).Where(data => data.r.IdReqEnc == id).OrderByDescending(data => data.r.FechaElaboracion).Select(data => new
        {
          IdReqEnc = data.r.IdReqEnc,
          NoReq = data.r.NoReq,
          NombreProyecto = data.p.NombreProyecto,
          Fecha = data.r.Fecha,
          FechaAutorizada = DbFunctions.TruncateTime(data.r.FechaAutorizada),
          FechaCompra = DbFunctions.TruncateTime(data.r.FechaCompra),
          Observaciones = data.r.Observaciones
        }));
      }
    }

    [WebMethod]
    public static string ObtenerRequisicionDetalle() => JsonConvert.SerializeObject((object) Requisicion_Edicion.ReqEditableDetalles);

    [WebMethod]
    public static string GuardarRequisiciones(string pObservaciones, string pid)
    {
      string str = string.Empty;
      Requisicion_Edicion.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Requisicion_Edicion.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Requisicion_Edicion.rolesUsuarios.RequisicionesEditar || Requisicion_Edicion.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          Guid id = Guid.Parse(Requisicion_Edicion.idRequisicion);
          tblReqEnc tblReqEnc = ((IQueryable<tblReqEnc>) sisaEntitie.tblReqEnc).FirstOrDefault<tblReqEnc>((Expression<Func<tblReqEnc, bool>>) (r => r.IdReqEnc == id));
          if (tblReqEnc != null)
          {
            tblReqEnc.Observaciones = pObservaciones.Trim().Length > 0 ? pObservaciones : tblReqEnc.Observaciones;
            sisaEntitie.SaveChanges();
            tblSolicitudesAprobacion solicitudesAprobacion = new tblSolicitudesAprobacion()
            {
              UsuarioSolicita = Requisicion_Edicion.usuario.Usuario,
              idUsuarioSolicita = Requisicion_Edicion.usuario.IdUsuario.ToString(),
              timestamp = DateTime.Now,
              Estatus = true,
              CondicionEstatus = "Enviado",
              Comentarios = tblReqEnc.NoReq + ", se modifico requisición, fecha " + DateTime.Now.ToString("dd/MM/yyyy"),
              idDocumento = tblReqEnc.IdReqEnc,
              Tipo = "REQUISICION"
            };
            sisaEntitie.tblSolicitudesAprobacion.Add(solicitudesAprobacion);
            sisaEntitie.SaveChanges();
            IQueryable<tblReqDet> queryable = ((IQueryable<tblReqDet>) sisaEntitie.tblReqDet).Where<tblReqDet>((Expression<Func<tblReqDet, bool>>) (d => d.IdReqEnc == id));
            if (queryable != null)
            {
              foreach (tblReqDet tblReqDet in (IEnumerable<tblReqDet>) queryable)
                sisaEntitie.tblReqDet.Remove(tblReqDet);
              sisaEntitie.SaveChanges();
            }
            str = "Requisiciones actualizadas.";
          }
          else
            str = "No se encontro información, intenta de nuevo.";
        }
      }
      else
        str = "No tienes permiso de editar Requisición.";
      return str;
    }

    [WebMethod]
    public static string GuardarRequisicionesDetalle(
      string pItem,
      string pDescripcio,
      string pCantidad,
      string pUnidad,
      string pNumParte,
      string pMarca)
    {
      string str = string.Empty;
      Requisicion_Edicion.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Requisicion_Edicion.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Requisicion_Edicion.rolesUsuarios.RequisicionesEditar || Requisicion_Edicion.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblReqDet tblReqDet = new tblReqDet()
          {
            IdReqDet = Guid.NewGuid(),
            TimeStamp = new DateTime?(DateTime.Now),
            Item = Convert.ToInt32(pItem),
            Descripcion = pDescripcio,
            Cantidad = Convert.ToInt32(pCantidad),
            Unidad = pUnidad,
            NumeroParte = pNumParte,
            Marca = pMarca,
            Estatus = new bool?(true),
            IdReqEnc = Guid.Parse(Requisicion_Edicion.idRequisicion)
          };
          sisaEntitie.tblReqDet.Add(tblReqDet);
          str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al guardar detalle Requisición." : "Detalle Requisición guardado.";
        }
      }
      else
        str = "No tienes permiso de editar Requisición.";
      return str;
    }
  }
}
