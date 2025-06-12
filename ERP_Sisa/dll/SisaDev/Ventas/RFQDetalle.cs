// Decompiled with JetBrains decompiler
// Type: SisaDev.Ventas.RFQDetalle
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SisaDev.Ventas
{
  public class RFQDetalle : Page
  {
    public static tblUsuarios usuario;
    public static tblRolesUsuarios rolesUsuarios;
    public static string idRfqNueva = string.Empty;
    public static string idRFQ = string.Empty;
    protected Label lblRFQFolio;
    protected HtmlInputHidden txtIdRFQ;

    protected void Page_Load(object sender, EventArgs e)
    {
      RFQDetalle.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (RFQDetalle.usuario != null)
      {
        RFQDetalle.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
        RFQDetalle.idRFQ = this.Request.QueryString["idRFQ"];
        this.txtIdRFQ.Value = RFQDetalle.idRFQ;
      }
      else
        this.Response.Redirect("~/Default.aspx");
    }

    [WebMethod]
    public static string ObtenerEmpresas(string pid)
    {
      string str = string.Empty;
      RFQDetalle.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      RFQDetalle.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (pid.Trim() == "2")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          if (RFQDetalle.rolesUsuarios.Tipo == "ROOT" || RFQDetalle.rolesUsuarios.Tipo == "ADMINISTRACION" || RFQDetalle.rolesUsuarios.Tipo == "GERENCIAL" || RFQDetalle.rolesUsuarios.Tipo == "COMPRAS")
            str = JsonConvert.SerializeObject((object) ((IQueryable<tblEmpresas>) sisaEntitie.tblEmpresas).Join((IEnumerable<tblClienteContacto>) sisaEntitie.tblClienteContacto, (Expression<Func<tblEmpresas, Guid>>) (r => r.idEmpresa), (Expression<Func<tblClienteContacto, Guid>>) (cn => cn.idEmpresa), (r, cn) => new
            {
              r = r,
              cn = cn
            }).Where(data => data.r.Estatus == (bool?) true && data.cn.Estatus == true).Select(data => new
            {
              idContacto = data.cn.idContacto,
              RazonSocial = data.r.RazonSocial,
              NombreContacto = data.cn.NombreContacto
            }));
          else
            str = JsonConvert.SerializeObject((object) ((IQueryable<tblEmpresas>) sisaEntitie.tblEmpresas).Join((IEnumerable<tblClienteContacto>) sisaEntitie.tblClienteContacto, (Expression<Func<tblEmpresas, Guid>>) (r => r.idEmpresa), (Expression<Func<tblClienteContacto, Guid>>) (cn => cn.idEmpresa), (r, cn) => new
            {
              r = r,
              cn = cn
            }).Where(data => data.r.idSucursalRegistro == RFQDetalle.usuario.idSucursal && data.r.Estatus == (bool?) true && data.cn.Estatus == true).Select(data => new
            {
              idContacto = data.cn.idContacto,
              RazonSocial = data.r.RazonSocial,
              NombreContacto = data.cn.NombreContacto
            }));
        }
      }
      return str;
    }

    [WebMethod]
    public static string GuardarRFQes(
      string pO,
      string dtCaduca,
      string idContacto,
      string idVendedor,
      string idCoordinador,
      string Seguimiento,
      string Descripcion)
    {
      string str = string.Empty;
      RFQDetalle.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      RFQDetalle.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (RFQDetalle.rolesUsuarios.RFQAgregar || RFQDetalle.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          ObjectParameter folio = new ObjectParameter("Folio", typeof (string));
          sisaEntitie.sp_ObtieneFolioRFQ(folio).ToString();
          tblRFQ tblRfq = new tblRFQ()
          {
            IdRfq = Guid.NewGuid(),
            Estatus = 1,
            FechaAlta = DateTime.Now,
            Fecha = DateTime.Now.ToString("dd/MM/yyyy"),
            IdUsuarioAlta = RFQDetalle.usuario.IdUsuario,
            IdUsuarioModificar = RFQDetalle.usuario.IdUsuario,
            Folio = folio.Value.ToString(),
            FechaVencimiento = DateTime.Parse(dtCaduca),
            FechaModificacion = DateTime.Now,
            Round = "",
            FolioRQ = folio.Value.ToString(),
            IdCliente = Guid.Parse(idContacto),
            idVendedor = new Guid?(Guid.Parse(idVendedor)),
            idCoordinador = new Guid?(Guid.Parse(idCoordinador)),
            Seguimiento = Seguimiento,
            Descripcion = Descripcion
          };
          sisaEntitie.tblRFQ.Add(tblRfq);
          if (sisaEntitie.SaveChanges() > 0)
          {
            RFQDetalle.idRfqNueva = tblRfq.IdRfq.ToString();
            tblSolicitudesAprobacion solicitudesAprobacion = new tblSolicitudesAprobacion()
            {
              UsuarioSolicita = RFQDetalle.usuario.Usuario,
              idUsuarioSolicita = tblRfq.idVendedor.ToString(),
              timestamp = DateTime.Now,
              Estatus = true,
              CondicionEstatus = "Enviado",
              Comentarios = tblRfq.Folio + " RFQ fecha " + DateTime.Now.ToString("dd/MM/yyyy"),
              idDocumento = Guid.Parse(RFQDetalle.idRfqNueva),
              Tipo = "MENSAJES"
            };
            sisaEntitie.tblSolicitudesAprobacion.Add(solicitudesAprobacion);
            sisaEntitie.SaveChanges();
            str = "RFQ creada." + RFQDetalle.idRfqNueva;
          }
          else
            str = "Ocurrio un problema al guardar RFQ.";
        }
      }
      else
        str = "No tienes permiso de agregar RFQ.";
      return str;
    }

    [WebMethod]
    public static string GuardarRFQesDetalle(
      string pItem,
      string pDescripcio,
      string pCantidad,
      string pUnidad)
    {
      string str = string.Empty;
      RFQDetalle.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      RFQDetalle.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (RFQDetalle.rolesUsuarios.RFQAgregar || RFQDetalle.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblRFQDet tblRfqDet = new tblRFQDet()
          {
            IdRFQDet = Guid.NewGuid(),
            TimeStamp = new DateTime?(DateTime.Now),
            Item = Convert.ToInt32(pItem),
            Descripcion = pDescripcio,
            Cantidad = Convert.ToInt32(pCantidad),
            Unidad = pUnidad,
            NumeroParte = "",
            Marca = "",
            Estatus = new bool?(true),
            IdRfq = Guid.Parse(RFQDetalle.idRfqNueva)
          };
          sisaEntitie.tblRFQDet.Add(tblRfqDet);
          str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al guardar Comentario RFQ." : "Comentario RFQ guardado.";
        }
      }
      else
        str = "No tienes permiso de agregar Comentario de RFQ.";
      return str;
    }

    [WebMethod]
    public static string CargarDatosDetalle(string IdRFQ, string Opcion)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
      {
        Guid id = Guid.Parse(IdRFQ);
        return JsonConvert.SerializeObject((object) ((IQueryable<tblRFQDet>) sisaEntitie.tblRFQDet).Where<tblRFQDet>((Expression<Func<tblRFQDet, bool>>) (d => d.IdRfq == id)));
      }
    }

    [WebMethod]
    public static string CargarDatosEncabezado(string IdRFQ, string Opcion)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
      {
        Guid.Parse(IdRFQ);
        return JsonConvert.SerializeObject((object) ((IQueryable<tblRFQ>) sisaEntitie.tblRFQ).Join((IEnumerable<tblClienteContacto>) sisaEntitie.tblClienteContacto, (Expression<Func<tblRFQ, Guid>>) (r => r.IdCliente), (Expression<Func<tblClienteContacto, Guid>>) (cn => cn.idContacto), (r, cn) => new
        {
          r = r,
          cn = cn
        }).Join((IEnumerable<tblEmpresas>) sisaEntitie.tblEmpresas, data => data.cn.idEmpresa, (Expression<Func<tblEmpresas, Guid>>) (ce => ce.idEmpresa), (data, ce) => new
        {
          \u003C\u003Eh__TransparentIdentifier0 = data,
          ce = ce
        }).Join((IEnumerable<tblUsuarios>) sisaEntitie.tblUsuarios, data => data.\u003C\u003Eh__TransparentIdentifier0.r.idVendedor, (Expression<Func<tblUsuarios, Guid?>>) (uv => (Guid?) uv.IdUsuario), (data, uv) => new
        {
          \u003C\u003Eh__TransparentIdentifier1 = data,
          uv = uv
        }).Join((IEnumerable<tblUsuarios>) sisaEntitie.tblUsuarios, data => data.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.idCoordinador, (Expression<Func<tblUsuarios, Guid?>>) (uc => (Guid?) uc.IdUsuario), (data, uc) => new
        {
          \u003C\u003Eh__TransparentIdentifier2 = data,
          uc = uc
        }).Where(data => data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.IdRfq.ToString() == IdRFQ && data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.Estatus > 0).Select(data => new
        {
          IdRfq = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.IdRfq,
          IdCliente = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.IdCliente,
          idVendedor = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.idVendedor,
          idCoordinador = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.idCoordinador,
          Folio = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.Folio,
          Descripcion = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.Descripcion,
          FechaRFQ = (object) data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.FechaAlta.Day + "/" + (object) data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.FechaAlta.Month + "/" + (object) data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.FechaAlta.Year,
          FechaVencimiento = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.FechaVencimiento,
          NombreContacto = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.ce.RazonSocial + "-" + data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.cn.NombreContacto,
          Telefono = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.cn.Telefono,
          Seguimiento = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.Seguimiento,
          ArchivoRFQ = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.ArchivoRFQ,
          Vendedor = data.\u003C\u003Eh__TransparentIdentifier2.uv.NombreCompleto,
          Coordinador = data.uc.NombreCompleto,
          Estatus = SqlFunctions.DateDiff("DAY", (DateTime?) DateTime.Now, (DateTime?) data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.FechaVencimiento),
          EstatusN = data.\u003C\u003Eh__TransparentIdentifier2.\u003C\u003Eh__TransparentIdentifier1.\u003C\u003Eh__TransparentIdentifier0.r.Estatus
        }));
      }
    }

    [WebMethod]
    public static string ModificarRFQes(
      string id,
      string dtCaduca,
      string idContacto,
      string idVendedor,
      string idCoordinador,
      string Seguimiento,
      string Descripcion)
    {
      string str = string.Empty;
      RFQDetalle.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      RFQDetalle.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (RFQDetalle.rolesUsuarios.RFQEditar || RFQDetalle.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          Guid i = Guid.Parse(id);
          tblRFQ tblRfq = ((IQueryable<tblRFQ>) sisaEntitie.tblRFQ).FirstOrDefault<tblRFQ>((Expression<Func<tblRFQ, bool>>) (r => r.IdRfq == i));
          if (tblRfq != null)
          {
            DbSet<tblRFQDet> tblRfqDet1 = sisaEntitie.tblRFQDet;
            Expression<Func<tblRFQDet, bool>> predicate = (Expression<Func<tblRFQDet, bool>>) (s => s.IdRfq == i);
            foreach (tblRFQDet tblRfqDet2 in (IEnumerable<tblRFQDet>) ((IQueryable<tblRFQDet>) tblRfqDet1).Where<tblRFQDet>(predicate))
              sisaEntitie.tblRFQDet.Remove(tblRfqDet2);
            sisaEntitie.SaveChanges();
            tblRfq.Descripcion = Descripcion;
            tblRfq.FechaModificacion = DateTime.Now;
            tblRfq.IdUsuarioModificar = RFQDetalle.usuario.IdUsuario;
            tblRfq.Seguimiento = Seguimiento;
            tblRfq.FechaVencimiento = DateTime.Parse(dtCaduca);
            sisaEntitie.SaveChanges();
            tblSolicitudesAprobacion solicitudesAprobacion = new tblSolicitudesAprobacion()
            {
              UsuarioSolicita = RFQDetalle.usuario.Usuario,
              idUsuarioSolicita = idVendedor.ToString(),
              timestamp = DateTime.Now,
              Estatus = true,
              CondicionEstatus = "Enviado",
              Comentarios = tblRfq.Folio + " RFQ fecha " + DateTime.Now.ToString("dd/MM/yyyy"),
              idDocumento = Guid.Parse(id),
              Tipo = "MENSAJES"
            };
            RFQDetalle.idRfqNueva = id;
            sisaEntitie.tblSolicitudesAprobacion.Add(solicitudesAprobacion);
            sisaEntitie.SaveChanges();
            str = "RFQ modificada. " + tblRfq.Folio;
          }
          else
            str = "Ocurrio un problema al obtener información de RFQ.";
        }
      }
      else
        str = "No tienes permiso de modificar RFQ.";
      return str;
    }
  }
}
