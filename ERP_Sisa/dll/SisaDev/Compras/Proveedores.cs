// Decompiled with JetBrains decompiler
// Type: SisaDev.Compras.Proveedores
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using Newtonsoft.Json;
using SisaDev.Control;
using SisaDev.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;

namespace SisaDev.Compras
{
  public class Proveedores : Page
  {
    public static tblUsuarios usuario;
    public static tblRolesUsuarios rolesUsuarios;

    protected void Page_Load(object sender, EventArgs e)
    {
      Proveedores.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (Proveedores.usuario != null)
        Proveedores.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      else
        this.Response.Redirect("~/Default.aspx");
    }

    [WebMethod]
    public static string ObtenerProveedores(string pid)
    {
      string str = string.Empty;
      if (pid.Trim() == "2")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
          str = JsonConvert.SerializeObject((object) ((IQueryable<tblProveedores>) sisaEntitie.tblProveedores).Where<tblProveedores>((Expression<Func<tblProveedores, bool>>) (p => p.Activo == 1)).Select(p => new
          {
            IdProveedor = p.IdProveedor,
            NombreComercial = p.NombreComercial,
            Proveedor = p.Proveedor,
            Contacto = p.Contacto,
            Email = p.Email,
            Telefono1 = p.Telefono1,
            Telefono2 = p.Telefono2,
            Domicilio = p.Domicilio,
            DiasCredito = p.DiasCredito,
            RFC = p.RFC
          }));
      }
      if (Proceso.rolesUsuariosGlobal.Proveedores || Proceso.rolesUsuariosGlobal.Tipo == "ROOT")
      {
        if (pid.Trim() == "1")
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
            str = JsonConvert.SerializeObject((object) ((IQueryable<tblProveedores>) sisaEntitie.tblProveedores).Where<tblProveedores>((Expression<Func<tblProveedores, bool>>) (p => p.Activo == 1)).Select(p => new
            {
              IdProveedor = p.IdProveedor,
              NombreComercial = p.NombreComercial,
              Proveedor = p.Proveedor,
              Contacto = p.Contacto,
              Email = p.Email,
              Telefono1 = p.Telefono1,
              Telefono2 = p.Telefono2,
              Domicilio = p.Domicilio,
              DiasCredito = p.DiasCredito,
              RFC = p.RFC
            }));
        }
        else
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
            str = JsonConvert.SerializeObject((object) ((IQueryable<tblProveedores>) sisaEntitie.tblProveedores).Where<tblProveedores>((Expression<Func<tblProveedores, bool>>) (p => p.IdProveedor.ToString() == pid)).Select(p => new
            {
              IdProveedor = p.IdProveedor,
              NombreComercial = p.NombreComercial,
              Proveedor = p.Proveedor,
              Contacto = p.Contacto,
              Email = p.Email,
              Telefono1 = p.Telefono1,
              Telefono2 = p.Telefono2,
              Domicilio = p.Domicilio,
              DiasCredito = p.DiasCredito,
              RFC = p.RFC
            }));
        }
      }
      else
        str = "";
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
    public static string GuardarProveedores(
      string pNombre,
      string pComercial,
      string pTelefono,
      string pCorreo,
      string pContacto,
      string pDireccion,
      string pCredito,
      string pRFC)
    {
      string str = string.Empty;
      Proveedores.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Proveedores.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Proveedores.rolesUsuarios.ProveedoresAgregar || Proveedores.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblProveedores tblProveedores = new tblProveedores()
          {
            IdProveedor = Guid.NewGuid(),
            Proveedor = pNombre,
            NombreComercial = pComercial,
            Telefono1 = pTelefono,
            Email = pCorreo,
            Contacto = pContacto,
            Domicilio = pDireccion,
            DiasCredito = new int?(pCredito.Length == 0 ? 0 : Convert.ToInt32(pCredito)),
            FechaAlta = DateTime.Now,
            Activo = 1,
            IdUsuarioAlta = Proveedores.usuario.IdUsuario,
            IdUsuarioModifica = Proveedores.usuario.IdUsuario,
            FechaModificacion = DateTime.Now,
            idSucursal = Proveedores.usuario.idSucursal,
            RFC = pRFC
          };
          sisaEntitie.tblProveedores.Add(tblProveedores);
          str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al guardar proveedor." : "Proveedor creado.";
        }
      }
      else
        str = "No tienes permiso de agregar proveedores.";
      return str;
    }

    [WebMethod]
    public static string EliminarProveedores(string pidProveedores)
    {
      string str = string.Empty;
      Proveedores.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Proveedores.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Proveedores.rolesUsuarios.ProveedoresEliminar || Proveedores.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblProveedores tblProveedores = ((IQueryable<tblProveedores>) sisaEntitie.tblProveedores).FirstOrDefault<tblProveedores>((Expression<Func<tblProveedores, bool>>) (s => s.IdProveedor.ToString() == pidProveedores));
          if (tblProveedores != null)
          {
            tblProveedores.Activo = 0;
            str = sisaEntitie.SaveChanges() <= 0 ? "Ocurrio un problema al eliminar Proveedor." : "Proveedor eliminado.";
          }
          else
            str = "Ocurrio un problema al obtener información de Proveedor seleccionada.";
        }
      }
      else
        str = "No tienes permiso de eliminar Proveedor.";
      return str;
    }

    [WebMethod]
    public static string EditarProveedores(
      string pid,
      string pNombre,
      string pComercial,
      string pTelefono,
      string pCorreo,
      string pContacto,
      string pDireccion,
      string pCredito,
      string pRFC)
    {
      string str = string.Empty;
      Proveedores.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Proveedores.rolesUsuarios = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Proveedores.rolesUsuarios.ProveedoresEditar || Proveedores.rolesUsuarios.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblProveedores tblProveedores = ((IQueryable<tblProveedores>) sisaEntitie.tblProveedores).FirstOrDefault<tblProveedores>((Expression<Func<tblProveedores, bool>>) (s => s.IdProveedor.ToString() == pid.Trim()));
          if (tblProveedores != null)
          {
            tblProveedores.Proveedor = pNombre;
            tblProveedores.Telefono1 = pTelefono;
            tblProveedores.Email = pCorreo;
            tblProveedores.NombreComercial = pComercial;
            tblProveedores.Contacto = pContacto;
            tblProveedores.Domicilio = pDireccion;
            tblProveedores.DiasCredito = new int?(Convert.ToInt32(pCredito == "" ? "0" : pCredito));
            tblProveedores.RFC = pRFC;
            str = sisaEntitie.SaveChanges() <= 0 ? "No se realizaron cambios." : "Proveedor actualizado.";
          }
          else
            str = "No se obtuvo información de Proveedor seleccionado.";
        }
      }
      else
        str = "NO tienes permiso de edición de Proveedor.";
      return str;
    }
  }
}
