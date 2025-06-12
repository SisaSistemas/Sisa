// Decompiled with JetBrains decompiler
// Type: SisaDev.Compras.OrdenCompraDetalle
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using Newtonsoft.Json;
using SisaDev.Control;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SisaDev.Compras
{
  public class OrdenCompraDetalle : Page
  {
    public static tblUsuarios usuario;
    public static tblRolesUsuarios rolesUsuarios;
    public static string idOCompra = string.Empty;
    protected HiddenField idUsuarioLog;
    protected HiddenField idSucursalLog;
    protected HtmlInputHidden idOC;

    protected void Page_Load(object sender, EventArgs e)
    {
      OrdenCompraDetalle.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (OrdenCompraDetalle.usuario != null)
      {
        OrdenCompraDetalle.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
        OrdenCompraDetalle.idOCompra = this.Request.QueryString["idOrdenCompra"];
        this.idOC.Value = OrdenCompraDetalle.idOCompra;
        this.idUsuarioLog.Value = OrdenCompraDetalle.usuario.IdUsuario.ToString();
        this.idSucursalLog.Value = OrdenCompraDetalle.usuario.idSucursal.ToString();
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
        int num = int.Parse(Opcion);
        return JsonConvert.SerializeObject((object) sisaEntitie.sp_CargaCombos(new int?(num)));
      }
    }

    [WebMethod]
    public static string CargarCombosGerencial(string Opcion)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
      {
        int.Parse(Opcion);
        return JsonConvert.SerializeObject((object) ((IQueryable<tblUsuarios>) sisaEntitie.tblUsuarios).Join((IEnumerable<tblRolesUsuarios>) sisaEntitie.tblRolesUsuarios, (Expression<Func<tblUsuarios, Guid>>) (a => a.IdUsuario), (Expression<Func<tblRolesUsuarios, Guid>>) (b => b.idUsuarios), (a, b) => new
        {
          a = a,
          b = b
        }).Where(data => data.b.Tipo == "GERENCIAL" && data.a.Activo == (int?) 1).Select(data => new
        {
          Id = data.a.IdUsuario,
          Nombre = data.a.NombreCompleto
        }));
      }
    }

    [WebMethod]
    public static string CargarCombos2(string Opcion)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
        return JsonConvert.SerializeObject((object) ((IQueryable<tblProveedores>) sisaEntitie.tblProveedores).Where<tblProveedores>((Expression<Func<tblProveedores, bool>>) (p => p.Activo == 1)).Select(p => new
        {
          Id = p.IdProveedor,
          Nombre = p.Proveedor
        }));
    }

    [WebMethod]
    public static string CargarDatosEncabezado(string IdOrdenCompra, string Opcion)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
      {
        int int32 = Convert.ToInt32(Opcion);
        return JsonConvert.SerializeObject((object) sisaEntitie.sp_LoadOrdenCompraDetalle(IdOrdenCompra, new int?(int32)));
      }
    }

    [WebMethod]
    public static string CargarDatosDetalle(string IdOrdenCompra, string Opcion)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
      {
        Guid id = Guid.Parse(IdOrdenCompra);
        return JsonConvert.SerializeObject((object) ((IQueryable<tblOrdenCompraDet>) sisaEntitie.tblOrdenCompraDet).Where<tblOrdenCompraDet>((Expression<Func<tblOrdenCompraDet, bool>>) (d => d.IdOrdenCompra == id)).OrderBy<tblOrdenCompraDet, int>((Expression<Func<tblOrdenCompraDet, int>>) (a => a.Item)));
      }
    }

    [WebMethod]
    public static string CargarMateriales(string IdProveedor)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
        return JsonConvert.SerializeObject((object) sisaEntitie.sp_CargarMaterialesProveedor(IdProveedor));
    }

    [WebMethod]
    public static string BuscarDatosProveedor(string IdProveedor)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
        return JsonConvert.SerializeObject((object) sisaEntitie.spBuscarProveedorXId(IdProveedor));
    }

    [WebMethod]
    public static string CrearOrdenCompra(
      string Folio,
      string IdProveedor,
      string ReferenciaCot,
      string IdProyecto,
      string PedidoPor,
      string SubTotal,
      string Iva,
      string Estatus,
      string IdMoneda,
      string CondicionPago,
      string Comentarios,
      string Descuento,
      string IdUsuarioAprobo,
      string TipoOC,
      string IdUsuario,
      string ReferenciarReq,
      string idUsuarioLog)
    {
      string str1 = string.Empty;
      string str2 = string.Empty;
      string empty = string.Empty;
      Decimal num1 = 0M;
      OrdenCompraDetalle.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      OrdenCompraDetalle.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (OrdenCompraDetalle.rolesUsuarios.OCAgregar || OrdenCompraDetalle.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          if (!string.IsNullOrEmpty(Folio))
          {
            tblOrdenCompra tblOrdenCompra = ((IQueryable<tblOrdenCompra>) sisaEntitie.tblOrdenCompra).FirstOrDefault<tblOrdenCompra>((Expression<Func<tblOrdenCompra, bool>>) (a => a.Folio == Folio));
            if (tblOrdenCompra == null)
            {
              tblOrdenCompraInsumos ordenCompraInsumos = ((IQueryable<tblOrdenCompraInsumos>) sisaEntitie.tblOrdenCompraInsumos).FirstOrDefault<tblOrdenCompraInsumos>((Expression<Func<tblOrdenCompraInsumos, bool>>) (a => a.Folio == Folio));
              str2 = "Material";
              empty = ordenCompraInsumos.IdProyecto.ToString();
              num1 = ordenCompraInsumos.Total.Value;
            }
            else
            {
              str2 = tblOrdenCompra.TipoOC;
              empty = tblOrdenCompra.IdProyecto.ToString();
              num1 = tblOrdenCompra.Total.Value;
            }
          }
          int int32 = Convert.ToInt32(Estatus);
          Decimal num2 = Decimal.Parse(SubTotal.Replace(",", ""));
          Decimal num3 = Decimal.Parse(Iva.Replace(",", ""));
          Decimal num4 = 0M;
          if (!string.IsNullOrEmpty(Descuento))
            num4 = Decimal.Parse(Descuento.Replace(",", ""));
          Decimal num5 = num2 + num3 - num4;
          str1 = JsonConvert.SerializeObject((object) sisaEntitie.sp_InsertOrdenCompra(Folio, IdProveedor, ReferenciaCot, IdProyecto, PedidoPor, new Decimal?(num2), new Decimal?(num3), new int?(int32), IdMoneda, CondicionPago, Comentarios, idUsuarioLog, new Decimal?(num4), IdUsuarioAprobo, TipoOC, OrdenCompraDetalle.usuario.idSucursal.ToString(), ReferenciarReq));
          OCRegistro ocRegistro = JsonConvert.DeserializeObject<OCRegistro>(str1.Replace("[", "").Replace("]", ""));
          string idordencompra = ocRegistro.IdOrdenCompra;
          string noOrdenCompra = ocRegistro.NoOrdenCompra;
          tblEficienciasDesglose eficienciasDesglose1 = ((IQueryable<tblEficienciasDesglose>) sisaEntitie.tblEficienciasDesglose).FirstOrDefault<tblEficienciasDesglose>((Expression<Func<tblEficienciasDesglose, bool>>) (e => e.idDocumento.ToString() == idordencompra));
          if (IdMoneda == "07F60F95-8F8A-4ABD-9BED-369EE7DFCCFF" || IdMoneda == "07f60f95-8f8a-4abd-9bed-369ee7dfccff")
          {
            Decimal num6 = 20.5M;
            num5 *= num6;
          }
          if (eficienciasDesglose1 != null)
          {
            eficienciasDesglose1.idProyecto = IdProyecto;
            eficienciasDesglose1.idDocumento = idordencompra.ToString();
            eficienciasDesglose1.Categoria = TipoOC.ToUpper();
            eficienciasDesglose1.Total = new Decimal?(num5);
            eficienciasDesglose1.TipoDoc = "OC";
            eficienciasDesglose1.Folio = noOrdenCompra;
            sisaEntitie.SaveChanges();
          }
          else
          {
            tblEficienciasDesglose eficienciasDesglose2 = new tblEficienciasDesglose()
            {
              idProyecto = IdProyecto,
              Categoria = TipoOC.ToUpper(),
              Total = new Decimal?(num5),
              TipoDoc = "OC",
              Folio = noOrdenCompra,
              FechaDoc = new DateTime?(DateTime.Now),
              idUsuarioUltimo = OrdenCompraDetalle.usuario.IdUsuario.ToString(),
              idDocumento = idordencompra.ToString()
            };
            sisaEntitie.tblEficienciasDesglose.Add(eficienciasDesglose2);
            sisaEntitie.SaveChanges();
          }
          if (ReferenciarReq.Length > 0)
          {
            tblReqEnc tblReqEnc = ((IQueryable<tblReqEnc>) sisaEntitie.tblReqEnc).FirstOrDefault<tblReqEnc>((Expression<Func<tblReqEnc, bool>>) (r => r.NoReq == ReferenciarReq));
            if (tblReqEnc != null)
            {
              tblReqEnc.FechaCompra = new DateTime?(DateTime.Now);
              sisaEntitie.SaveChanges();
            }
          }
        }
      }
      else
        str1 = "No tienes permiso de registrar ordenes de compra.";
      return str1;
    }

    [WebMethod]
    public static string InsertarOrdenCompraDetalle(
      string IdOrdenCompra,
      string Item,
      string Codigo,
      string Descripcion,
      string Comentarios,
      string Cantidad,
      string Unidad,
      string Precio,
      string Importe,
      string TiempoEntrega,
      string CantidadRecibida,
      string Opcion)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
      {
        int int32_1 = Convert.ToInt32(Opcion);
        int int32_2 = Convert.ToInt32(Item);
        Decimal num1 = Decimal.Parse(Cantidad.Replace(",", ""));
        Decimal num2 = Decimal.Parse(Precio.Replace(",", ""));
        Decimal num3 = Decimal.Parse(Importe.Replace(",", ""));
        Decimal num4 = Decimal.Parse(CantidadRecibida.Replace(",", ""));
        return JsonConvert.SerializeObject((object) sisaEntitie.sp_InsertOrdenCompraDetalle(IdOrdenCompra, new int?(int32_2), Codigo, Descripcion, Comentarios, new Decimal?(num1), Unidad, new Decimal?(num2), new Decimal?(num3), TiempoEntrega, new Decimal?(num4), new int?(int32_1)));
      }
    }

    [WebMethod]
    public static string ActualizaCantRecibida(
      string IdOrdenCompra,
      string Item,
      string CantidadRecibida)
    {
      string str = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
      {
        int i = Convert.ToInt32(Item);
        tblOrdenCompraDet tblOrdenCompraDet = ((IQueryable<tblOrdenCompraDet>) sisaEntitie.tblOrdenCompraDet).FirstOrDefault<tblOrdenCompraDet>((Expression<Func<tblOrdenCompraDet, bool>>) (d => d.IdOrdenCompra.ToString() == IdOrdenCompra && d.Item == i));
        if (tblOrdenCompraDet != null)
        {
          if (tblOrdenCompraDet.CantidadRecibida > tblOrdenCompraDet.Cantidad)
          {
            str = "Error";
          }
          else
          {
            Decimal num = Decimal.Parse(CantidadRecibida.Replace(",", ""));
            str = JsonConvert.SerializeObject((object) sisaEntitie.sp_ActualizaCantidadEntregadaOC(IdOrdenCompra, new int?(i), new Decimal?(num)));
          }
        }
      }
      return str;
    }

    [WebMethod]
    public static string ItemEliminado(
      string IdOrdenCompra,
      string Item,
      string SubTotal,
      string Iva,
      string Codigo)
    {
      string str = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
      {
        int i = Convert.ToInt32(Item);
        tblOrdenCompraDet tblOrdenCompraDet = ((IQueryable<tblOrdenCompraDet>) sisaEntitie.tblOrdenCompraDet).FirstOrDefault<tblOrdenCompraDet>((Expression<Func<tblOrdenCompraDet, bool>>) (d => d.IdOrdenCompra.ToString() == IdOrdenCompra && d.Item == i && d.Codigo == Codigo));
        if (tblOrdenCompraDet != null)
        {
          sisaEntitie.tblOrdenCompraDet.Remove(tblOrdenCompraDet);
          Guid idoc = Guid.Parse(IdOrdenCompra);
          tblOrdenCompra tblOrdenCompra = ((IQueryable<tblOrdenCompra>) sisaEntitie.tblOrdenCompra).FirstOrDefault<tblOrdenCompra>((Expression<Func<tblOrdenCompra, bool>>) (o => o.IdOrdenCompra == idoc));
          if (tblOrdenCompra != null)
          {
            Decimal num1 = Decimal.Parse(SubTotal.Replace(",", ""));
            Decimal num2 = Decimal.Parse(Iva.Replace(",", ""));
            tblOrdenCompra.SubTotal = num1;
            tblOrdenCompra.Iva = num2;
            sisaEntitie.SaveChanges();
            tblEficienciasDesglose eficienciasDesglose = ((IQueryable<tblEficienciasDesglose>) sisaEntitie.tblEficienciasDesglose).FirstOrDefault<tblEficienciasDesglose>((Expression<Func<tblEficienciasDesglose, bool>>) (e => e.idDocumento.ToString() == IdOrdenCompra));
            if (eficienciasDesglose != null)
            {
              eficienciasDesglose.Total = new Decimal?(num1 + num2);
              sisaEntitie.SaveChanges();
            }
            str = "Actualizado";
          }
        }
        else
          str = "El item aun no se ha guardado.";
      }
      return str;
    }
  }
}
