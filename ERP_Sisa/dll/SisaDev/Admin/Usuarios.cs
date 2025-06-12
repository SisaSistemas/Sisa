// Decompiled with JetBrains decompiler
// Type: SisaDev.Admin.Usuarios
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using Newtonsoft.Json;
using SisaDev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SisaDev.Admin
{
  public class Usuarios : Page
  {
    public static tblUsuarios usuario;
    public static tblRolesUsuarios rolesUsuario;
    protected Image ImgPrvUsuarios;
    protected FileUpload FlupImage;

    protected void Page_Load(object sender, EventArgs e)
    {
      Usuarios.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      if (Usuarios.usuario != null)
        Usuarios.rolesUsuario = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      else
        this.Response.Redirect("~/Default.aspx");
    }

    [WebMethod]
    public static string ObtenerUsuarios(string pid)
    {
      string str = string.Empty;
      Usuarios.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Usuarios.rolesUsuario = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Usuarios.rolesUsuario.Usuarios || Usuarios.rolesUsuario.Tipo == "ROOT")
      {
        if (pid.Trim() == "1")
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
            str = JsonConvert.SerializeObject((object) ((IQueryable<tblUsuarios>) sisaEntitie.tblUsuarios).Join((IEnumerable<tblRolesUsuarios>) sisaEntitie.tblRolesUsuarios, (Expression<Func<tblUsuarios, Guid>>) (cl => cl.IdUsuario), (Expression<Func<tblRolesUsuarios, Guid>>) (rl => rl.idUsuarios), (cl, rl) => new
            {
              cl = cl,
              rl = rl
            }).Join((IEnumerable<tblSucursales>) sisaEntitie.tblSucursales, data => data.cl.idSucursal, (Expression<Func<tblSucursales, Guid?>>) (suc => (Guid?) suc.idSucursa), (data, suc) => new
            {
              \u003C\u003Eh__TransparentIdentifier0 = data,
              suc = suc
            }).Where(data => data.\u003C\u003Eh__TransparentIdentifier0.cl.Activo == (int?) 1).Select(data => new
            {
              IdUsuario = data.\u003C\u003Eh__TransparentIdentifier0.cl.IdUsuario,
              NombreCompleto = data.\u003C\u003Eh__TransparentIdentifier0.cl.NombreCompleto,
              Usuario = data.\u003C\u003Eh__TransparentIdentifier0.cl.Usuario,
              Telefono = data.\u003C\u003Eh__TransparentIdentifier0.cl.Telefono,
              Correo = data.\u003C\u003Eh__TransparentIdentifier0.cl.Correo,
              Tipo = data.\u003C\u003Eh__TransparentIdentifier0.rl.Tipo,
              CiudadSucursal = data.suc.CiudadSucursal
            }).OrderBy(a => a.NombreCompleto));
        }
        else
        {
          using (SisaEntitie sisaEntitie = new SisaEntitie())
            str = JsonConvert.SerializeObject((object) ((IQueryable<tblUsuarios>) sisaEntitie.tblUsuarios).Join((IEnumerable<tblRolesUsuarios>) sisaEntitie.tblRolesUsuarios, (Expression<Func<tblUsuarios, Guid>>) (cl => cl.IdUsuario), (Expression<Func<tblRolesUsuarios, Guid>>) (rl => rl.idUsuarios), (cl, rl) => new
            {
              cl = cl,
              rl = rl
            }).Join((IEnumerable<tblSucursales>) sisaEntitie.tblSucursales, data => data.cl.idSucursal, (Expression<Func<tblSucursales, Guid?>>) (suc => (Guid?) suc.idSucursa), (data, suc) => new
            {
              \u003C\u003Eh__TransparentIdentifier0 = data,
              suc = suc
            }).Where(data => data.\u003C\u003Eh__TransparentIdentifier0.cl.IdUsuario.ToString() == pid).Select(data => new
            {
              IdUsuario = data.\u003C\u003Eh__TransparentIdentifier0.cl.IdUsuario,
              Activo = data.\u003C\u003Eh__TransparentIdentifier0.cl.Activo,
              NombreCompleto = data.\u003C\u003Eh__TransparentIdentifier0.cl.NombreCompleto,
              Usuario = data.\u003C\u003Eh__TransparentIdentifier0.cl.Usuario,
              Telefono = data.\u003C\u003Eh__TransparentIdentifier0.cl.Telefono,
              Correo = data.\u003C\u003Eh__TransparentIdentifier0.cl.Correo,
              Tipo = data.\u003C\u003Eh__TransparentIdentifier0.rl.Tipo,
              idSucursal = data.\u003C\u003Eh__TransparentIdentifier0.cl.idSucursal,
              SueldoDiario = data.\u003C\u003Eh__TransparentIdentifier0.cl.SueldoDiario,
              ClienteEmpresa = data.\u003C\u003Eh__TransparentIdentifier0.rl.ClienteEmpresa ? "checked" : "",
              ClienteEmpresaAgregar = data.\u003C\u003Eh__TransparentIdentifier0.rl.ClienteEmpresaAgregar ? "checked" : "",
              ClienteEmpresaEditar = data.\u003C\u003Eh__TransparentIdentifier0.rl.ClienteEmpresaEditar ? "checked" : "",
              ClienteEmpresaEliminar = data.\u003C\u003Eh__TransparentIdentifier0.rl.ClienteEmpresaEliminar ? "checked" : "",
              ClienteContacto = data.\u003C\u003Eh__TransparentIdentifier0.rl.ClienteContacto ? "checked" : "",
              ClienteContactoAgrear = data.\u003C\u003Eh__TransparentIdentifier0.rl.ClienteContactoAgrear ? "checked" : "",
              ClienteContactoEditar = data.\u003C\u003Eh__TransparentIdentifier0.rl.ClienteContactoEditar ? "checked" : "",
              ClienteContactoEliminar = data.\u003C\u003Eh__TransparentIdentifier0.rl.ClienteContactoEliminar ? "checked" : "",
              RFQ = data.\u003C\u003Eh__TransparentIdentifier0.rl.RFQ ? "checked" : "",
              RFQAgregar = data.\u003C\u003Eh__TransparentIdentifier0.rl.RFQAgregar ? "checked" : "",
              RFQEditar = data.\u003C\u003Eh__TransparentIdentifier0.rl.RFQEditar ? "checked" : "",
              RFQEliminar = data.\u003C\u003Eh__TransparentIdentifier0.rl.RFQEliminar ? "checked" : "",
              Cotizaciones = data.\u003C\u003Eh__TransparentIdentifier0.rl.Cotizaciones ? "checked" : "",
              CotizacionesAgregar = data.\u003C\u003Eh__TransparentIdentifier0.rl.CotizacionesAgregar ? "checked" : "",
              CotizacionesEditar = data.\u003C\u003Eh__TransparentIdentifier0.rl.CotizacionesEditar ? "checked" : "",
              CotizacionesEliminar = data.\u003C\u003Eh__TransparentIdentifier0.rl.CotizacionesEliminar ? "checked" : "",
              Materiales = data.\u003C\u003Eh__TransparentIdentifier0.rl.Materiales ? "checked" : "",
              MaterialesAgregar = data.\u003C\u003Eh__TransparentIdentifier0.rl.MaterialesAgregar ? "checked" : "",
              MaterialesEditar = data.\u003C\u003Eh__TransparentIdentifier0.rl.MaterialesEditar ? "checked" : "",
              MaterialesEliminar = data.\u003C\u003Eh__TransparentIdentifier0.rl.MaterialesEliminar ? "checked" : "",
              Proveedores = data.\u003C\u003Eh__TransparentIdentifier0.rl.Proveedores ? "checked" : "",
              ProveedoresAgregar = data.\u003C\u003Eh__TransparentIdentifier0.rl.ProveedoresAgregar ? "checked" : "",
              ProveedoresEditar = data.\u003C\u003Eh__TransparentIdentifier0.rl.ProveedoresEditar ? "checked" : "",
              ProveedoresEliminar = data.\u003C\u003Eh__TransparentIdentifier0.rl.ProveedoresEliminar ? "checked" : "",
              Requisiciones = data.\u003C\u003Eh__TransparentIdentifier0.rl.Requisiciones ? "checked" : "",
              RequisicionesAgregar = data.\u003C\u003Eh__TransparentIdentifier0.rl.RequisicionesAgregar ? "checked" : "",
              RequisicionesEditar = data.\u003C\u003Eh__TransparentIdentifier0.rl.RequisicionesEditar ? "checked" : "",
              RequisicionesEliminar = data.\u003C\u003Eh__TransparentIdentifier0.rl.RequisicionesEliminar ? "checked" : "",
              OC = data.\u003C\u003Eh__TransparentIdentifier0.rl.OC ? "checked" : "",
              OCAgregar = data.\u003C\u003Eh__TransparentIdentifier0.rl.OCAgregar ? "checked" : "",
              OCEditar = data.\u003C\u003Eh__TransparentIdentifier0.rl.OCEditar ? "checked" : "",
              OCEliminar = data.\u003C\u003Eh__TransparentIdentifier0.rl.OCEliminar ? "checked" : "",
              Viaticos = data.\u003C\u003Eh__TransparentIdentifier0.rl.Viaticos ? "checked" : "",
              ViaticosAgregar = data.\u003C\u003Eh__TransparentIdentifier0.rl.ViaticosAgregar ? "checked" : "",
              ViaticosEditar = data.\u003C\u003Eh__TransparentIdentifier0.rl.ViaticosEditar ? "checked" : "",
              ViaticosEliminar = data.\u003C\u003Eh__TransparentIdentifier0.rl.ViaticosEliminar ? "checked" : "",
              Proyectos = data.\u003C\u003Eh__TransparentIdentifier0.rl.Proyectos ? "checked" : "",
              ProyectosAgregar = data.\u003C\u003Eh__TransparentIdentifier0.rl.ProyectosAgregar ? "checked" : "",
              ProyectosEditar = data.\u003C\u003Eh__TransparentIdentifier0.rl.ProyectosEditar ? "checked" : "",
              ProyectosEliminar = data.\u003C\u003Eh__TransparentIdentifier0.rl.ProyectosEliminar ? "checked" : "",
              CajaChica = data.\u003C\u003Eh__TransparentIdentifier0.rl.CajaChica ? "checked" : "",
              CajaChicaAgregar = data.\u003C\u003Eh__TransparentIdentifier0.rl.CajaChicaAgregar ? "checked" : "",
              CajaChicaEditar = data.\u003C\u003Eh__TransparentIdentifier0.rl.CajaChicaEditar ? "checked" : "",
              CajaChicaEliminar = data.\u003C\u003Eh__TransparentIdentifier0.rl.CajaChicaEliminar ? "checked" : "",
              Usuarios = data.\u003C\u003Eh__TransparentIdentifier0.rl.Usuarios ? "checked" : "",
              UsuariosAgregar = data.\u003C\u003Eh__TransparentIdentifier0.rl.UsuariosAgregar ? "checked" : "",
              UsuariosEditar = data.\u003C\u003Eh__TransparentIdentifier0.rl.UsuariosEditar ? "checked" : "",
              UsuariosEliminar = data.\u003C\u003Eh__TransparentIdentifier0.rl.UsuariosEliminar ? "checked" : "",
              Sucursales = data.\u003C\u003Eh__TransparentIdentifier0.rl.Sucursales ? "checked" : "",
              SucursalesAgregar = data.\u003C\u003Eh__TransparentIdentifier0.rl.SucursalesAgregar ? "checked" : "",
              SucursalesEditar = data.\u003C\u003Eh__TransparentIdentifier0.rl.SucursalesEditar ? "checked" : "",
              SucursalesEliminar = data.\u003C\u003Eh__TransparentIdentifier0.rl.SucursalesEliminar ? "checked" : "",
              ControlFacturas = data.\u003C\u003Eh__TransparentIdentifier0.rl.ControlFacturas ? "checked" : "",
              ControlDocumentos = data.\u003C\u003Eh__TransparentIdentifier0.rl.ControlDocumentos ? "checked" : "",
              Administracion = data.\u003C\u003Eh__TransparentIdentifier0.rl.Administracion ? "checked" : "",
              Timming = data.\u003C\u003Eh__TransparentIdentifier0.rl.Timming ? "checked" : "",
              ServiciosCarro = data.\u003C\u003Eh__TransparentIdentifier0.rl.ServiciosCarro ? "checked" : "",
              Inventario = data.\u003C\u003Eh__TransparentIdentifier0.rl.Inventario ? "checked" : "",
              ServiciosComputo = data.\u003C\u003Eh__TransparentIdentifier0.rl.ServiciosComputo ? "checked" : "",
              FacturasEmitidas = (bool) data.\u003C\u003Eh__TransparentIdentifier0.rl.FacturasEmitidas ? "checked" : "",
              Reportes = (bool) data.\u003C\u003Eh__TransparentIdentifier0.rl.Reportes ? "checked" : ""
            }));
        }
      }
      else
        str = "No tienes permiso.";
      return str;
    }

    [WebMethod]
    public static string GuardarUsuarios(
      string pNombreCompleto,
      string pCorreoUsuario,
      string pTelefonoUsuario,
      string pClaveUsuario,
      string pUsuario,
      string pTipo,
      string pSucursal,
      bool pchkCliEmpVer,
      bool pchkCliEmpAdd,
      bool pchkCliEmpEdit,
      bool pchkCliEmpDel,
      bool pchkCliConVer,
      bool pchkCliConAdd,
      bool pchkCliConEdit,
      bool pchkCliConDel,
      bool pchkRFQVer,
      bool pchkRFQAdd,
      bool pchkRFQEdit,
      bool pchkRFQDel,
      bool pchkCotVer,
      bool pchkCotAdd,
      bool pchkCotEdit,
      bool pchkCotDel,
      bool pchkMatVer,
      bool pchkMatAdd,
      bool pchkMatEdit,
      bool pchkMatDel,
      bool pchkProvVer,
      bool pchkProvAdd,
      bool pchkProvEdit,
      bool pchkProvDel,
      bool pchkRequiVer,
      bool pchkRequiAdd,
      bool pchkRequiEdit,
      bool pchkRequiDel,
      bool pchkOCVer,
      bool pchkOCAdd,
      bool pchkOCEdit,
      bool pchkOCDel,
      bool pchkViaVer,
      bool pchkViaAdd,
      bool pchkViaEdit,
      bool pchkViaDel,
      bool pchkProyVer,
      bool pchkProyAdd,
      bool pchkProyEdit,
      bool pchkProyDel,
      bool pchkCajaVer,
      bool pchkCajaAdd,
      bool pchkCajaEdit,
      bool pchkCajaDel,
      bool pchkUserVer,
      bool pchkUserAdd,
      bool pchkUserEdit,
      bool pchkUserDel,
      bool pchkSucVer,
      bool pchkSucAdd,
      bool pchkSucEdit,
      bool pchkSucDel,
      bool pchkFacVer,
      bool pchkDocsAdd,
      bool pchkAdminVer,
      bool pchkInventaAdd,
      bool pchkTimmEdit,
      bool pchkCarroVer,
      bool pchkPCAdd,
      string pSalario,
      bool pchkFacVerEmitidas,
      bool pReportes)
    {
      string str = string.Empty;
      Usuarios.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Usuarios.rolesUsuario = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Usuarios.rolesUsuario.UsuariosAgregar || Usuarios.rolesUsuario.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblUsuarios tblUsuarios = new tblUsuarios()
          {
            IdUsuario = Guid.NewGuid(),
            NombreCompleto = pNombreCompleto,
            Correo = pCorreoUsuario,
            Telefono = pTelefonoUsuario,
            Contrasena = pClaveUsuario,
            Usuario = pUsuario,
            idSucursal = new Guid?(Guid.Parse(pSucursal)),
            Permisos = new int?(1),
            Puesto = pTipo,
            Foto = "",
            FechaAlta = new DateTime?(DateTime.Now),
            IdUsuarioModificacion = new Guid?(Usuarios.usuario.IdUsuario),
            FechaModificacion = new DateTime?(DateTime.Now),
            Activo = new int?(1),
            SueldoDiario = new Decimal?(pSalario == "" ? 0M : Decimal.Parse(pSalario))
          };
          sisaEntitie.tblUsuarios.Add(tblUsuarios);
          if (sisaEntitie.SaveChanges() > 0)
          {
            tblRolesUsuarios tblRolesUsuarios = new tblRolesUsuarios()
            {
              idRol = Guid.NewGuid(),
              idUsuarios = tblUsuarios.IdUsuario,
              Tipo = pTipo,
              ClienteEmpresa = pchkCliEmpVer,
              ClienteEmpresaAgregar = pchkCliEmpAdd,
              ClienteEmpresaEditar = pchkCliEmpEdit,
              ClienteEmpresaEliminar = pchkCliEmpDel,
              ClienteContacto = pchkCliConVer,
              ClienteContactoAgrear = pchkCliConAdd,
              ClienteContactoEditar = pchkCliConEdit,
              ClienteContactoEliminar = pchkCliConDel,
              RFQ = pchkRFQVer,
              RFQAgregar = pchkRFQAdd,
              RFQEditar = pchkRFQEdit,
              RFQEliminar = pchkRFQDel,
              Cotizaciones = pchkCotVer,
              CotizacionesAgregar = pchkCotAdd,
              CotizacionesEditar = pchkCotEdit,
              CotizacionesEliminar = pchkCotDel,
              Materiales = pchkMatVer,
              MaterialesAgregar = pchkMatAdd,
              MaterialesEditar = pchkMatEdit,
              MaterialesEliminar = pchkMatDel,
              Proveedores = pchkProvVer,
              ProveedoresAgregar = pchkProvAdd,
              ProveedoresEditar = pchkProvEdit,
              ProveedoresEliminar = pchkProvDel,
              Requisiciones = pchkRequiVer,
              RequisicionesAgregar = pchkRequiAdd,
              RequisicionesEditar = pchkRequiEdit,
              RequisicionesEliminar = pchkRequiDel,
              OC = pchkOCVer,
              OCAgregar = pchkOCAdd,
              OCEditar = pchkOCEdit,
              OCEliminar = pchkOCDel,
              Viaticos = pchkViaVer,
              ViaticosAgregar = pchkViaAdd,
              ViaticosEditar = pchkViaEdit,
              ViaticosEliminar = pchkViaDel,
              Proyectos = pchkProyVer,
              ProyectosAgregar = pchkProyAdd,
              ProyectosEditar = pchkProyEdit,
              ProyectosEliminar = pchkProyDel,
              CajaChica = pchkCajaVer,
              CajaChicaAgregar = pchkCajaAdd,
              CajaChicaEditar = pchkCajaEdit,
              CajaChicaEliminar = pchkCajaDel,
              Usuarios = pchkUserVer,
              UsuariosAgregar = pchkUserAdd,
              UsuariosEditar = pchkUserEdit,
              UsuariosEliminar = pchkUserDel,
              Sucursales = pchkSucVer,
              SucursalesAgregar = pchkSucAdd,
              SucursalesEditar = pchkSucEdit,
              SucursalesEliminar = pchkSucDel,
              ControlFacturas = pchkFacVer,
              ControlDocumentos = pchkDocsAdd,
              Administracion = pchkAdminVer,
              Timming = pchkTimmEdit,
              ServiciosCarro = pchkCarroVer,
              Inventario = pchkInventaAdd,
              ServiciosComputo = pchkPCAdd,
              FacturasEmitidas = new bool?(pchkFacVerEmitidas),
              Reportes = new bool?(pReportes)
            };
            sisaEntitie.tblRolesUsuarios.Add(tblRolesUsuarios);
            str = sisaEntitie.SaveChanges() <= 0 ? "Error al agregar los roles de usuario, contácta el administrador del sistema." : "Usuario creado.";
          }
          else
            str = "Error al agregar usuario.";
        }
      }
      else
        str = "No tienes permiso para agregar usuarios.";
      return str;
    }

    [WebMethod]
    public static string EditarUsuarios(
      string pidUsuario,
      string pNombreCompleto,
      string pCorreoUsuario,
      string pTelefonoUsuario,
      string pUsuario,
      bool pchkCliEmpVerEdit,
      bool pchkCliEmpAddEdit,
      bool pchkCliEmpEditEdit,
      bool pchkCliEmpDelEdit,
      bool pchkCliConVerEdit,
      bool pchkCliConAddEdit,
      bool pchkCliConEditEdit,
      bool pchkCliConDelEdit,
      bool pchkRFQVerEdit,
      bool pchkRFQAddEdit,
      bool pchkRFQEditEdit,
      bool pchkRFQDelEdit,
      bool pchkCotVerEdit,
      bool pchkCotAddEdit,
      bool pchkCotEditEdit,
      bool pchkCotDelEdit,
      bool pchkMatVerEdit,
      bool pchkMatAddEdit,
      bool pchkMatEditEdit,
      bool pchkMatDelEdit,
      bool pchkProvVerEdit,
      bool pchkProvAddEdit,
      bool pchkProvEditEdit,
      bool pchkProvDelEdit,
      bool pchkRequiVerEdit,
      bool pchkRequiAddEdit,
      bool pchkRequiEditEdit,
      bool pchkRequiDelEdit,
      bool pchkOCVerEdit,
      bool pchkOCAddEdit,
      bool pchkOCEditEdit,
      bool pchkOCDelEdit,
      bool pchkViaVerEdit,
      bool pchkViaAddEdit,
      bool pchkViaEditEdit,
      bool pchkViaDelEdit,
      bool pchkProyVerEdit,
      bool pchkProyAddEdit,
      bool pchkProyEditEdit,
      bool pchkProyDelEdit,
      bool pchkCajaVerEdit,
      bool pchkCajaAddEdit,
      bool pchkCajaEditEdit,
      bool pchkCajaDelEdit,
      bool pchkUserVerEdit,
      bool pchkUserAddEdit,
      bool pchkUserEditEdit,
      bool pchkUserDelEdit,
      bool pchkSucVerEdit,
      bool pchkSucAddEdit,
      bool pchkSucEditEdit,
      bool pchkSucDelEdit,
      bool pchkFacVerEdit,
      bool pchkDocsAddEdit,
      bool pchkAdminVerEdit,
      bool pchkInventaAddEdit,
      bool pchkTimmEditEdit,
      bool pchkCarroVerEdit,
      bool pchkPCAddEdit,
      string pActivo,
      string pTipo,
      string pidSucursal,
      string pSalario,
      bool pchkFacVerEmitidas,
      bool pReportes)
    {
      string str = string.Empty;
      Usuarios.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Usuarios.rolesUsuario = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Usuarios.rolesUsuario.UsuariosEditar || Usuarios.rolesUsuario.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblUsuarios tblUsuarios = ((IQueryable<tblUsuarios>) sisaEntitie.tblUsuarios).FirstOrDefault<tblUsuarios>((Expression<Func<tblUsuarios, bool>>) (u => u.IdUsuario.ToString() == pidUsuario));
          if (tblUsuarios != null)
          {
            tblUsuarios.NombreCompleto = pNombreCompleto;
            tblUsuarios.Correo = pCorreoUsuario;
            tblUsuarios.Telefono = pTelefonoUsuario;
            tblUsuarios.Usuario = pUsuario;
            tblUsuarios.IdUsuarioModificacion = new Guid?(Usuarios.usuario.IdUsuario);
            tblUsuarios.FechaModificacion = new DateTime?(DateTime.Now);
            tblUsuarios.Activo = new int?(pActivo == "ACTIVO" ? 1 : 0);
            tblUsuarios.idSucursal = new Guid?(Guid.Parse(pidSucursal));
            tblUsuarios.SueldoDiario = new Decimal?(pSalario == "" ? 0M : Decimal.Parse(pSalario));
            sisaEntitie.SaveChanges();
            tblRolesUsuarios tblRolesUsuarios = ((IQueryable<tblRolesUsuarios>) sisaEntitie.tblRolesUsuarios).FirstOrDefault<tblRolesUsuarios>((Expression<Func<tblRolesUsuarios, bool>>) (r => r.idUsuarios.ToString() == pidUsuario));
            if (tblRolesUsuarios != null)
            {
              tblRolesUsuarios.Tipo = pTipo;
              tblRolesUsuarios.ClienteEmpresa = pchkCliEmpVerEdit;
              tblRolesUsuarios.ClienteEmpresaAgregar = pchkCliEmpAddEdit;
              tblRolesUsuarios.ClienteEmpresaEditar = pchkCliEmpEditEdit;
              tblRolesUsuarios.ClienteEmpresaEliminar = pchkCliEmpDelEdit;
              tblRolesUsuarios.ClienteContacto = pchkCliConVerEdit;
              tblRolesUsuarios.ClienteContactoAgrear = pchkCliConAddEdit;
              tblRolesUsuarios.ClienteContactoEditar = pchkCliConEditEdit;
              tblRolesUsuarios.ClienteContactoEliminar = pchkCliConDelEdit;
              tblRolesUsuarios.RFQ = pchkRFQVerEdit;
              tblRolesUsuarios.RFQAgregar = pchkRFQAddEdit;
              tblRolesUsuarios.RFQEditar = pchkRFQEditEdit;
              tblRolesUsuarios.RFQEliminar = pchkRFQDelEdit;
              tblRolesUsuarios.Cotizaciones = pchkCotVerEdit;
              tblRolesUsuarios.CotizacionesAgregar = pchkCotAddEdit;
              tblRolesUsuarios.CotizacionesEditar = pchkCotEditEdit;
              tblRolesUsuarios.CotizacionesEliminar = pchkCotDelEdit;
              tblRolesUsuarios.Materiales = pchkMatVerEdit;
              tblRolesUsuarios.MaterialesAgregar = pchkMatAddEdit;
              tblRolesUsuarios.MaterialesEditar = pchkMatEditEdit;
              tblRolesUsuarios.MaterialesEliminar = pchkMatDelEdit;
              tblRolesUsuarios.Proveedores = pchkProvVerEdit;
              tblRolesUsuarios.ProveedoresAgregar = pchkProvAddEdit;
              tblRolesUsuarios.ProveedoresEditar = pchkProvEditEdit;
              tblRolesUsuarios.ProveedoresEliminar = pchkProvDelEdit;
              tblRolesUsuarios.Requisiciones = pchkRequiVerEdit;
              tblRolesUsuarios.RequisicionesAgregar = pchkRequiAddEdit;
              tblRolesUsuarios.RequisicionesEditar = pchkRequiEditEdit;
              tblRolesUsuarios.RequisicionesEliminar = pchkRequiDelEdit;
              tblRolesUsuarios.OC = pchkOCVerEdit;
              tblRolesUsuarios.OCAgregar = pchkOCAddEdit;
              tblRolesUsuarios.OCEditar = pchkOCEditEdit;
              tblRolesUsuarios.OCEliminar = pchkOCDelEdit;
              tblRolesUsuarios.Viaticos = pchkViaVerEdit;
              tblRolesUsuarios.ViaticosAgregar = pchkViaAddEdit;
              tblRolesUsuarios.ViaticosEditar = pchkViaEditEdit;
              tblRolesUsuarios.ViaticosEliminar = pchkViaDelEdit;
              tblRolesUsuarios.Proyectos = pchkProyVerEdit;
              tblRolesUsuarios.ProyectosAgregar = pchkProyAddEdit;
              tblRolesUsuarios.ProyectosEditar = pchkProyEditEdit;
              tblRolesUsuarios.ProyectosEliminar = pchkProyDelEdit;
              tblRolesUsuarios.CajaChica = pchkCajaVerEdit;
              tblRolesUsuarios.CajaChicaAgregar = pchkCajaAddEdit;
              tblRolesUsuarios.CajaChicaEditar = pchkCajaEditEdit;
              tblRolesUsuarios.CajaChicaEliminar = pchkCajaDelEdit;
              tblRolesUsuarios.Usuarios = pchkUserVerEdit;
              tblRolesUsuarios.UsuariosAgregar = pchkUserAddEdit;
              tblRolesUsuarios.UsuariosEditar = pchkUserEditEdit;
              tblRolesUsuarios.UsuariosEliminar = pchkUserDelEdit;
              tblRolesUsuarios.Sucursales = pchkSucVerEdit;
              tblRolesUsuarios.SucursalesAgregar = pchkSucAddEdit;
              tblRolesUsuarios.SucursalesEditar = pchkSucEditEdit;
              tblRolesUsuarios.SucursalesEliminar = pchkSucDelEdit;
              tblRolesUsuarios.ControlFacturas = pchkFacVerEdit;
              tblRolesUsuarios.ControlDocumentos = pchkDocsAddEdit;
              tblRolesUsuarios.Administracion = pchkAdminVerEdit;
              tblRolesUsuarios.Timming = pchkTimmEditEdit;
              tblRolesUsuarios.ServiciosCarro = pchkCarroVerEdit;
              tblRolesUsuarios.Inventario = pchkInventaAddEdit;
              tblRolesUsuarios.ServiciosComputo = pchkPCAddEdit;
              tblRolesUsuarios.FacturasEmitidas = new bool?(pchkFacVerEmitidas);
              tblRolesUsuarios.Reportes = new bool?(pReportes);
              sisaEntitie.SaveChanges();
              str = "Usuario actualizado.";
            }
            else
              str = "No se pudo obtener información de permisos usuario seleccionado, recarga la página e intenta de nuevo.";
          }
          else
            str = "No se pudo obtener información de usuario seleccionado, recarga la página e intenta de nuevo.";
        }
      }
      else
        str = "No tienes permiso de edición de usuarios.";
      return str;
    }

    [WebMethod]
    public static string EliminarUsuarios(string pidUsuarios)
    {
      string str = string.Empty;
      Usuarios.usuario = HttpContext.Current.Session["UsuarioLogueado"] as tblUsuarios;
      Usuarios.rolesUsuario = HttpContext.Current.Session["RolesUsuarioLogueado"] as tblRolesUsuarios;
      if (Usuarios.rolesUsuario.UsuariosEliminar || Usuarios.rolesUsuario.Tipo == "ROOT")
      {
        using (SisaEntitie sisaEntitie = new SisaEntitie())
        {
          tblUsuarios tblUsuarios = ((IQueryable<tblUsuarios>) sisaEntitie.tblUsuarios).FirstOrDefault<tblUsuarios>((Expression<Func<tblUsuarios, bool>>) (u => u.IdUsuario.ToString() == pidUsuarios));
          if (tblUsuarios != null)
          {
            tblUsuarios.Activo = new int?(0);
            str = sisaEntitie.SaveChanges() <= 0 ? "No se pudo dar de baja información de usuario seleccionado, recarga la página e intenta de nuevo." : "Usuario actualizado.";
          }
          else
            str = "No se pudo obtener información de usuario seleccionado, recarga la página e intenta de nuevo.";
        }
      }
      else
        str = "No tienes permiso de dar de baja usuarios.";
      return str;
    }

    [WebMethod]
    public static string ObtenerUsuariosFoto(string pid)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
        return JsonConvert.SerializeObject((object) ((IQueryable<tblUsuarios>) sisaEntitie.tblUsuarios).Where<tblUsuarios>((Expression<Func<tblUsuarios, bool>>) (cl => cl.IdUsuario.ToString() == pid)).Select(cl => new
        {
          IdUsuario = cl.IdUsuario,
          Foto = cl.Foto
        }));
    }

    [WebMethod]
    public static string ActualizarUsuariosFoto(string pid, string pFoto)
    {
      string empty = string.Empty;
      using (SisaEntitie sisaEntitie = new SisaEntitie())
      {
        tblUsuarios tblUsuarios = ((IQueryable<tblUsuarios>) sisaEntitie.tblUsuarios).FirstOrDefault<tblUsuarios>((Expression<Func<tblUsuarios, bool>>) (r => r.IdUsuario.ToString().Trim() == pid.Trim()));
        if (tblUsuarios == null)
          return "Problema al guardar información, recarga la página.";
        tblUsuarios.Foto = pFoto;
        return sisaEntitie.SaveChanges() > 0 ? "Datos guardados." : "No se hicieron cambios, es la misma foto.";
      }
    }
  }
}
