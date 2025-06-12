// Decompiled with JetBrains decompiler
// Type: SisaDev.Compras.Requisiciones
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;

namespace SisaDev.Compras
{
  public class Requisiciones : Page
  {
    public static tblUsuarios usuario;
    public static tblRolesUsuarios rolesUsuarios;
    public static string idReqNueva = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
      Requisiciones.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (Requisiciones.usuario != null)
        Requisiciones.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      else
        this.Response.Redirect("~/Default.aspx");
    }

    [WebMethod]
    public static string ProyectosCombos(string Opcion)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
      {
        int num = int.Parse(Opcion);
        return JsonConvert.SerializeObject((object) sisaEntitie.sp_CargaCombos(new int?(num)));
      }
    }

    [WebMethod]
    public static string ObtenerRequisiciones(string pid)
    {
      string str = string.Empty;
      Requisiciones.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Requisiciones.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (pid.Trim() == "2")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
          return JsonConvert.SerializeObject((object) ((IQueryable<tblReqEnc>) sisaEntitie.tblReqEnc).Join((IEnumerable<tblProyectos>) sisaEntitie.tblProyectos, (Expression<Func<tblReqEnc, Guid>>) (r => r.IdProyecto), (Expression<Func<tblProyectos, Guid>>) (p => p.IdProyecto), (r, p) => new
          {
            r = r,
            p = p
          }).Where(data => data.r.Estatus > 0).OrderByDescending(data => data.r.FechaElaboracion).Select(data => new
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
      else
      {
        if (Requisiciones.rolesUsuarios.Requisiciones || Requisiciones.rolesUsuarios.Tipo == "ROOT" || Requisiciones.rolesUsuarios.Tipo == "GERENCIAL" || Requisiciones.rolesUsuarios.Tipo == "COMPRAS")
        {
          if (pid.Trim() == "1")
          {
            using (SisaEntitie sisaEntitie = new SisaEntitie())
              str = JsonConvert.SerializeObject((object) ((IQueryable<tblReqEnc>) sisaEntitie.tblReqEnc).Join((IEnumerable<tblProyectos>) sisaEntitie.tblProyectos, (Expression<Func<tblReqEnc, Guid>>) (r => r.IdProyecto), (Expression<Func<tblProyectos, Guid>>) (p => p.IdProyecto), (r, p) => new
              {
                r = r,
                p = p
              }).Where(data => data.r.Estatus > 0 && data.r.IdUsuarioElaboro == Requisiciones.usuario.IdUsuario).OrderByDescending(data => data.r.FechaElaboracion).Select(data => new
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
          else
          {
            using (SisaEntitie sisaEntitie = new SisaEntitie())
              str = JsonConvert.SerializeObject((object) ((IQueryable<tblReqEnc>) sisaEntitie.tblReqEnc).Join((IEnumerable<tblProyectos>) sisaEntitie.tblProyectos, (Expression<Func<tblReqEnc, Guid>>) (r => r.IdProyecto), (Expression<Func<tblProyectos, Guid>>) (p => p.IdProyecto), (r, p) => new
              {
                r = r,
                p = p
              }).Where(data => data.r.Estatus > 0 && data.r.IdUsuarioElaboro == Requisiciones.usuario.IdUsuario).OrderByDescending(data => data.r.FechaElaboracion).Select(data => new
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
        return str;
      }
    }

    [WebMethod]
    public static string ObtenerRequisicionesDetalles(string pid)
    {
      string str = string.Empty;
      if (pid.Trim() == "2")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
          str = JsonConvert.SerializeObject((object) ((IQueryable<tblReqDet>) sisaEntitie.tblReqDet).Where<tblReqDet>((Expression<Func<tblReqDet, bool>>) (p => p.IdReqEnc.ToString() == pid)).OrderBy<tblReqDet, int>((Expression<Func<tblReqDet, int>>) (p => p.Item)).Select(p => new
          {
            IdReqEnc = p.IdReqEnc,
            Descripcion = p.Descripcion,
            Cantidad = p.Cantidad,
            NumeroParte = p.NumeroParte,
            Marca = p.Marca,
            Unidad = p.Unidad,
            Item = p.Item
          }));
      }
      if (Requisiciones.rolesUsuarios.Requisiciones || Requisiciones.rolesUsuarios.Tipo == "ROOT")
      {
        if (pid.Trim() == "1")
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
            str = JsonConvert.SerializeObject((object) ((IQueryable<tblReqEnc>) sisaEntitie.tblReqEnc).Join((IEnumerable<tblProyectos>) sisaEntitie.tblProyectos, (Expression<Func<tblReqEnc, Guid>>) (r => r.IdProyecto), (Expression<Func<tblProyectos, Guid>>) (p => p.IdProyecto), (r, p) => new
            {
              r = r,
              p = p
            }).Where(data => data.r.IdUsuarioElaboro == Requisiciones.usuario.IdUsuario).Select(data => new
            {
              IdReqEnc = data.r.IdReqEnc,
              NoReq = data.r.NoReq,
              NombreProyecto = data.p.NombreProyecto,
              Fecha = data.r.Fecha,
              FechaAutorizada = data.r.FechaAutorizada,
              FechaCompra = data.r.FechaCompra,
              Observaciones = data.r.Observaciones
            }));
        }
        else
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
            str = JsonConvert.SerializeObject((object) ((IQueryable<tblReqDet>) sisaEntitie.tblReqDet).Where<tblReqDet>((Expression<Func<tblReqDet, bool>>) (p => p.IdReqEnc.ToString() == pid)).OrderBy<tblReqDet, int>((Expression<Func<tblReqDet, int>>) (p => p.Item)).Select(p => new
            {
              IdReqEnc = p.IdReqEnc,
              Descripcion = p.Descripcion,
              Cantidad = p.Cantidad,
              NumeroParte = p.NumeroParte,
              Marca = p.Marca,
              Unidad = p.Unidad,
              Item = p.Item
            }));
        }
      }
      return str;
    }

    [WebMethod]
    public static string GuardarRequisiciones(string pObservaciones, string pidProyecto)
    {
      string str1 = string.Empty;
      Requisiciones.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Requisiciones.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Requisiciones.rolesUsuarios.RequisicionesAgregar || Requisiciones.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          ObjectParameter folio = new ObjectParameter("Folio", typeof (string));
          sisaEntitie.sp_ObtieneFolioReq(folio).ToString();
          tblReqEnc tblReqEnc1 = new tblReqEnc();
          tblReqEnc1.IdProyecto = Guid.Parse(pidProyecto);
          tblReqEnc1.IdReqEnc = Guid.NewGuid();
          tblReqEnc1.Observaciones = pObservaciones;
          tblReqEnc1.Estatus = 1;
          tblReqEnc1.FechaElaboracion = DateTime.Now;
          DateTime now = DateTime.Now;
          tblReqEnc1.Fecha = now.ToString("dd/MM/yyyy");
          tblReqEnc1.IdUsuarioElaboro = Requisiciones.usuario.IdUsuario;
          tblReqEnc1.NoReq = folio.Value.ToString();
          tblReqEnc tblReqEnc2 = tblReqEnc1;
          sisaEntitie.tblReqEnc.Add(tblReqEnc2);
          if (sisaEntitie.SaveChanges() > 0)
          {
            Requisiciones.idReqNueva = tblReqEnc2.IdReqEnc.ToString();
            tblSolicitudesAprobacion solicitudesAprobacion1 = new tblSolicitudesAprobacion();
            solicitudesAprobacion1.UsuarioSolicita = Requisiciones.usuario.Usuario;
            solicitudesAprobacion1.idUsuarioSolicita = Requisiciones.usuario.IdUsuario.ToString();
            solicitudesAprobacion1.timestamp = DateTime.Now;
            solicitudesAprobacion1.Estatus = true;
            solicitudesAprobacion1.CondicionEstatus = "Enviado";
            string noReq = tblReqEnc2.NoReq;
            now = DateTime.Now;
            string str2 = now.ToString("dd/MM/yyyy");
            solicitudesAprobacion1.Comentarios = noReq + " Requisicion fecha " + str2;
            solicitudesAprobacion1.idDocumento = tblReqEnc2.IdReqEnc;
            solicitudesAprobacion1.Tipo = "REQUISICION";
            tblSolicitudesAprobacion solicitudesAprobacion2 = solicitudesAprobacion1;
            sisaEntitie.tblSolicitudesAprobacion.Add(solicitudesAprobacion2);
            sisaEntitie.SaveChanges();
            str1 = "Requisiciones creada.";
          }
          else
            str1 = "Ocurrio un problema al guardar Requisición.";
        }
      }
      else
        str1 = "No tienes permiso de agregar Requisición.";
      return str1;
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
      Requisiciones.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Requisiciones.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Requisiciones.rolesUsuarios.RequisicionesAgregar || Requisiciones.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          ObjectParameter folio = new ObjectParameter("Folio", typeof (string));
          sisaEntitie.sp_ObtieneFolioReq(folio).ToString();
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
            IdReqEnc = Guid.Parse(Requisiciones.idReqNueva)
          };
          sisaEntitie.tblReqDet.Add(tblReqDet);
          str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al guardar detalle Requisición." : "Detalle Requisición guardado.";
        }
      }
      else
        str = "No tienes permiso de agregar Requisición.";
      return str;
    }

    [WebMethod]
    public static string EliminarRequisicion(string pidRequisicion)
    {
      string str = string.Empty;
      Requisiciones.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Requisiciones.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Requisiciones.rolesUsuarios.RequisicionesEliminar || Requisiciones.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblReqEnc tblReqEnc = ((IQueryable<tblReqEnc>) sisaEntitie.tblReqEnc).FirstOrDefault<tblReqEnc>((Expression<Func<tblReqEnc, bool>>) (s => s.IdReqEnc.ToString() == pidRequisicion));
          if (tblReqEnc != null)
          {
            tblReqEnc.Estatus = 0;
            str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al eliminar requisición." : "Requisiciones eliminada.";
          }
          else
            str = "Ocurrio un problema al obtener información de requisición seleccionada.";
        }
      }
      else
        str = "No tienes permiso de eliminar requisición.";
      return str;
    }

    [WebMethod]
    public static string EditarRequisicion(
      string pid,
      string pNombre,
      string pTelefono,
      string pCorreo,
      string pUsuario,
      string pClave)
    {
      string str = string.Empty;
      Requisiciones.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Requisiciones.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Requisiciones.rolesUsuarios.ClienteContactoEditar || Requisiciones.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblClienteContacto tblClienteContacto = ((IQueryable<tblClienteContacto>) sisaEntitie.tblClienteContacto).FirstOrDefault<tblClienteContacto>((Expression<Func<tblClienteContacto, bool>>) (s => s.idEmpresa.ToString() == pid.Trim()));
          if (tblClienteContacto != null)
          {
            tblClienteContacto.NombreContacto = pNombre;
            tblClienteContacto.Telefono = pTelefono;
            tblClienteContacto.Correo = pCorreo;
            tblClienteContacto.Usuario = pUsuario;
            tblClienteContacto.Clave = pClave;
            str = sisaEntitie.SaveChanges() <= 0 ? "No se realizaron cambios." : "Contacto actualizada.";
          }
          else
            str = "No se obtuvo información de Contacto seleccionado.";
        }
      }
      else
        str = "NO tienes permiso de edición de Contacto.";
      return str;
    }
  }
}
