// Decompiled with JetBrains decompiler
// Type: SisaDev.Models.tblRolesUsuarios
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;

namespace SisaDev.Models
{
  public class tblRolesUsuarios
  {
    public Guid idRol { get; set; }

    public string Tipo { get; set; }

    public Guid idUsuarios { get; set; }

    public bool ClienteEmpresa { get; set; }

    public bool ClienteEmpresaAgregar { get; set; }

    public bool ClienteEmpresaEditar { get; set; }

    public bool ClienteEmpresaEliminar { get; set; }

    public bool ClienteContacto { get; set; }

    public bool ClienteContactoAgrear { get; set; }

    public bool ClienteContactoEditar { get; set; }

    public bool ClienteContactoEliminar { get; set; }

    public bool RFQ { get; set; }

    public bool RFQAgregar { get; set; }

    public bool RFQEditar { get; set; }

    public bool RFQEliminar { get; set; }

    public bool Cotizaciones { get; set; }

    public bool CotizacionesAgregar { get; set; }

    public bool CotizacionesEditar { get; set; }

    public bool CotizacionesEliminar { get; set; }

    public bool Materiales { get; set; }

    public bool MaterialesAgregar { get; set; }

    public bool MaterialesEditar { get; set; }

    public bool MaterialesEliminar { get; set; }

    public bool Proveedores { get; set; }

    public bool ProveedoresAgregar { get; set; }

    public bool ProveedoresEditar { get; set; }

    public bool ProveedoresEliminar { get; set; }

    public bool Requisiciones { get; set; }

    public bool RequisicionesAgregar { get; set; }

    public bool RequisicionesEditar { get; set; }

    public bool RequisicionesEliminar { get; set; }

    public bool OC { get; set; }

    public bool OCAgregar { get; set; }

    public bool OCEditar { get; set; }

    public bool OCEliminar { get; set; }

    public bool Viaticos { get; set; }

    public bool ViaticosAgregar { get; set; }

    public bool ViaticosEditar { get; set; }

    public bool ViaticosEliminar { get; set; }

    public bool Proyectos { get; set; }

    public bool ProyectosEditar { get; set; }

    public bool ProyectosEliminar { get; set; }

    public bool ProyectosAgregar { get; set; }

    public bool CajaChica { get; set; }

    public bool CajaChicaAgregar { get; set; }

    public bool CajaChicaEditar { get; set; }

    public bool CajaChicaEliminar { get; set; }

    public bool Usuarios { get; set; }

    public bool UsuariosAgregar { get; set; }

    public bool UsuariosEditar { get; set; }

    public bool UsuariosEliminar { get; set; }

    public bool Sucursales { get; set; }

    public bool SucursalesAgregar { get; set; }

    public bool SucursalesEditar { get; set; }

    public bool SucursalesEliminar { get; set; }

    public bool ControlFacturas { get; set; }

    public bool ControlDocumentos { get; set; }

    public bool Administracion { get; set; }

    public bool Timming { get; set; }

    public bool ServiciosCarro { get; set; }

    public bool Inventario { get; set; }

    public bool ServiciosComputo { get; set; }

    public bool? FacturasEmitidas { get; set; }

    public bool? Reportes { get; set; }
  }
}
