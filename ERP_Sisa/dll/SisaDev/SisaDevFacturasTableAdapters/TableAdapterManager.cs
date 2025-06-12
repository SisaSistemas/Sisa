// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDevFacturasTableAdapters.TableAdapterManager
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SisaDev.SisaDevFacturasTableAdapters
{
  [DesignerCategory("code")]
  [ToolboxItem(true)]
  [Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
  [HelpKeyword("vs.data.TableAdapterManager")]
  public class TableAdapterManager : Component
  {
    private TableAdapterManager.UpdateOrderOption _updateOrder;
    private DateDimensionTableAdapter _dateDimensionTableAdapter;
    private MatTableAdapter _matTableAdapter;
    private Mat2TableAdapter _mat2TableAdapter;
    private Mat3TableAdapter _mat3TableAdapter;
    private MatUrreaTableAdapter _matUrreaTableAdapter;
    private ProductosTableAdapter _productosTableAdapter;
    private tblBoletinTableAdapter _tblBoletinTableAdapter;
    private tblCajaChicaTableAdapter _tblCajaChicaTableAdapter;
    private tblCalendarioTableAdapter _tblCalendarioTableAdapter;
    private tblCategoriaTableAdapter _tblCategoriaTableAdapter;
    private tblChatTableAdapter _tblChatTableAdapter;
    private tblClienteContactoTableAdapter _tblClienteContactoTableAdapter;
    private tblClientesTableAdapter _tblClientesTableAdapter;
    private tblComentariosCotizacionTableAdapter _tblComentariosCotizacionTableAdapter;
    private tblComentariosProyectoTableAdapter _tblComentariosProyectoTableAdapter;
    private tblControlFacturasTableAdapter _tblControlFacturasTableAdapter;
    private tblCotizacionesTableAdapter _tblCotizacionesTableAdapter;
    private tblCotizacionesDetTableAdapter _tblCotizacionesDetTableAdapter;
    private tblCotizacionNewTableAdapter _tblCotizacionNewTableAdapter;
    private tblDatosEmpresaTableAdapter _tblDatosEmpresaTableAdapter;
    private tblDocDisenosMecanicoTableAdapter _tblDocDisenosMecanicoTableAdapter;
    private tblDocMasterCamMecanicoTableAdapter _tblDocMasterCamMecanicoTableAdapter;
    private tblDocProyectosTableAdapter _tblDocProyectosTableAdapter;
    private tblEficienciasTableAdapter _tblEficienciasTableAdapter;
    private tblEmpresasTableAdapter _tblEmpresasTableAdapter;
    private tblFacturasEmitidasTableAdapter _tblFacturasEmitidasTableAdapter;
    private tblFacturasXMLTableAdapter _tblFacturasXMLTableAdapter;
    private tblFallasTableAdapter _tblFallasTableAdapter;
    private tblFolioCotizacionTableAdapter _tblFolioCotizacionTableAdapter;
    private tblFolioOrdenCompraTableAdapter _tblFolioOrdenCompraTableAdapter;
    private tblFolioReqTableAdapter _tblFolioReqTableAdapter;
    private tblFolioRFQTableAdapter _tblFolioRFQTableAdapter;
    private tblGastosTableAdapter _tblGastosTableAdapter;
    private tblGPSTableAdapter _tblGPSTableAdapter;
    private tblHabilidadesTableAdapter _tblHabilidadesTableAdapter;
    private tblHorasHombreTableAdapter _tblHorasHombreTableAdapter;
    private tblInventarioTableAdapter _tblInventarioTableAdapter;
    private tblInventarioDetTableAdapter _tblInventarioDetTableAdapter;
    private tblInvHerramientasTableAdapter _tblInvHerramientasTableAdapter;
    private tblInvHerramientasDetTableAdapter _tblInvHerramientasDetTableAdapter;
    private tblLiderProyectoTableAdapter _tblLiderProyectoTableAdapter;
    private tblListaPendientesTableAdapter _tblListaPendientesTableAdapter;
    private tblMaterialesTableAdapter _tblMaterialesTableAdapter;
    private tblMaterialImagenTableAdapter _tblMaterialImagenTableAdapter;
    private tblMatrizMecanicoTableAdapter _tblMatrizMecanicoTableAdapter;
    private tblMenuTableAdapter _tblMenuTableAdapter;
    private tblMonedasTableAdapter _tblMonedasTableAdapter;
    private tblNotaAclaratoriaTableAdapter _tblNotaAclaratoriaTableAdapter;
    private tblOrdenCompraTableAdapter _tblOrdenCompraTableAdapter;
    private tblOrdenCompraComentariosTableAdapter _tblOrdenCompraComentariosTableAdapter;
    private tblOrdenCompraDetTableAdapter _tblOrdenCompraDetTableAdapter;
    private tblOrdenCompraInsumosTableAdapter _tblOrdenCompraInsumosTableAdapter;
    private tblOrdenCompraNotaTableAdapter _tblOrdenCompraNotaTableAdapter;
    private tblOrdenTrabajoTableAdapter _tblOrdenTrabajoTableAdapter;
    private tblPermisosTableAdapter _tblPermisosTableAdapter;
    private tblProveedoresTableAdapter _tblProveedoresTableAdapter;
    private tblProveedoresContactosTableAdapter _tblProveedoresContactosTableAdapter;
    private tblProveedorMaterialTableAdapter _tblProveedorMaterialTableAdapter;
    private tblProyectoRequerimientoTableAdapter _tblProyectoRequerimientoTableAdapter;
    private tblProyectosTableAdapter _tblProyectosTableAdapter;
    private tblProyectosBKTableAdapter _tblProyectosBKTableAdapter;
    private tblProyectoTaskImagenTableAdapter _tblProyectoTaskImagenTableAdapter;
    private tblProyectoTasksTableAdapter _tblProyectoTasksTableAdapter;
    private tblProyectoTasksBKTableAdapter _tblProyectoTasksBKTableAdapter;
    private tblProyectoTasksComentariosTableAdapter _tblProyectoTasksComentariosTableAdapter;
    private tblRecuperacionesTableAdapter _tblRecuperacionesTableAdapter;
    private tblReqDetTableAdapter _tblReqDetTableAdapter;
    private tblReqEncTableAdapter _tblReqEncTableAdapter;
    private tblRequisicionTableAdapter _tblRequisicionTableAdapter;
    private tblRFQTableAdapter _tblRFQTableAdapter;
    private tblRFQDetTableAdapter _tblRFQDetTableAdapter;
    private tblRfqSeguimientoTableAdapter _tblRfqSeguimientoTableAdapter;
    private tblRfqVentasTableAdapter _tblRfqVentasTableAdapter;
    private tblRolesUsuariosTableAdapter _tblRolesUsuariosTableAdapter;
    private tblServicioComputoTableAdapter _tblServicioComputoTableAdapter;
    private tblServiciosComputoTableAdapter _tblServiciosComputoTableAdapter;
    private tblSolicitudesAprobacionTableAdapter _tblSolicitudesAprobacionTableAdapter;
    private tblSubMenuTableAdapter _tblSubMenuTableAdapter;
    private tblSucursalesTableAdapter _tblSucursalesTableAdapter;
    private tblTeamProjectTableAdapter _tblTeamProjectTableAdapter;
    private tblTimmingProyectoTableAdapter _tblTimmingProyectoTableAdapter;
    private tblUnidadMedidaTableAdapter _tblUnidadMedidaTableAdapter;
    private tblUsuariosTableAdapter _tblUsuariosTableAdapter;
    private tblUsuariosBKTableAdapter _tblUsuariosBKTableAdapter;
    private tblVehiculosTableAdapter _tblVehiculosTableAdapter;
    private tblVehiculoServicioTableAdapter _tblVehiculoServicioTableAdapter;
    private tblVehiculoServicioItemTableAdapter _tblVehiculoServicioItemTableAdapter;
    private tblViaticosTableAdapter _tblViaticosTableAdapter;
    private tblViaticosDetTableAdapter _tblViaticosDetTableAdapter;
    private UtilidadTableAdapter _utilidadTableAdapter;
    private UtilidadPastelTableAdapter _utilidadPastelTableAdapter;
    private bool _backupDataSetBeforeUpdate;
    private IDbConnection _connection;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public TableAdapterManager.UpdateOrderOption UpdateOrder
    {
      get => this._updateOrder;
      set => this._updateOrder = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public DateDimensionTableAdapter DateDimensionTableAdapter
    {
      get => this._dateDimensionTableAdapter;
      set => this._dateDimensionTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public MatTableAdapter MatTableAdapter
    {
      get => this._matTableAdapter;
      set => this._matTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public Mat2TableAdapter Mat2TableAdapter
    {
      get => this._mat2TableAdapter;
      set => this._mat2TableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public Mat3TableAdapter Mat3TableAdapter
    {
      get => this._mat3TableAdapter;
      set => this._mat3TableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public MatUrreaTableAdapter MatUrreaTableAdapter
    {
      get => this._matUrreaTableAdapter;
      set => this._matUrreaTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public ProductosTableAdapter ProductosTableAdapter
    {
      get => this._productosTableAdapter;
      set => this._productosTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblBoletinTableAdapter tblBoletinTableAdapter
    {
      get => this._tblBoletinTableAdapter;
      set => this._tblBoletinTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblCajaChicaTableAdapter tblCajaChicaTableAdapter
    {
      get => this._tblCajaChicaTableAdapter;
      set => this._tblCajaChicaTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblCalendarioTableAdapter tblCalendarioTableAdapter
    {
      get => this._tblCalendarioTableAdapter;
      set => this._tblCalendarioTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblCategoriaTableAdapter tblCategoriaTableAdapter
    {
      get => this._tblCategoriaTableAdapter;
      set => this._tblCategoriaTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblChatTableAdapter tblChatTableAdapter
    {
      get => this._tblChatTableAdapter;
      set => this._tblChatTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblClienteContactoTableAdapter tblClienteContactoTableAdapter
    {
      get => this._tblClienteContactoTableAdapter;
      set => this._tblClienteContactoTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblClientesTableAdapter tblClientesTableAdapter
    {
      get => this._tblClientesTableAdapter;
      set => this._tblClientesTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblComentariosCotizacionTableAdapter tblComentariosCotizacionTableAdapter
    {
      get => this._tblComentariosCotizacionTableAdapter;
      set => this._tblComentariosCotizacionTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblComentariosProyectoTableAdapter tblComentariosProyectoTableAdapter
    {
      get => this._tblComentariosProyectoTableAdapter;
      set => this._tblComentariosProyectoTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblControlFacturasTableAdapter tblControlFacturasTableAdapter
    {
      get => this._tblControlFacturasTableAdapter;
      set => this._tblControlFacturasTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblCotizacionesTableAdapter tblCotizacionesTableAdapter
    {
      get => this._tblCotizacionesTableAdapter;
      set => this._tblCotizacionesTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblCotizacionesDetTableAdapter tblCotizacionesDetTableAdapter
    {
      get => this._tblCotizacionesDetTableAdapter;
      set => this._tblCotizacionesDetTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblCotizacionNewTableAdapter tblCotizacionNewTableAdapter
    {
      get => this._tblCotizacionNewTableAdapter;
      set => this._tblCotizacionNewTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblDatosEmpresaTableAdapter tblDatosEmpresaTableAdapter
    {
      get => this._tblDatosEmpresaTableAdapter;
      set => this._tblDatosEmpresaTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblDocDisenosMecanicoTableAdapter tblDocDisenosMecanicoTableAdapter
    {
      get => this._tblDocDisenosMecanicoTableAdapter;
      set => this._tblDocDisenosMecanicoTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblDocMasterCamMecanicoTableAdapter tblDocMasterCamMecanicoTableAdapter
    {
      get => this._tblDocMasterCamMecanicoTableAdapter;
      set => this._tblDocMasterCamMecanicoTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblDocProyectosTableAdapter tblDocProyectosTableAdapter
    {
      get => this._tblDocProyectosTableAdapter;
      set => this._tblDocProyectosTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblEficienciasTableAdapter tblEficienciasTableAdapter
    {
      get => this._tblEficienciasTableAdapter;
      set => this._tblEficienciasTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblEmpresasTableAdapter tblEmpresasTableAdapter
    {
      get => this._tblEmpresasTableAdapter;
      set => this._tblEmpresasTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblFacturasEmitidasTableAdapter tblFacturasEmitidasTableAdapter
    {
      get => this._tblFacturasEmitidasTableAdapter;
      set => this._tblFacturasEmitidasTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblFacturasXMLTableAdapter tblFacturasXMLTableAdapter
    {
      get => this._tblFacturasXMLTableAdapter;
      set => this._tblFacturasXMLTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblFallasTableAdapter tblFallasTableAdapter
    {
      get => this._tblFallasTableAdapter;
      set => this._tblFallasTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblFolioCotizacionTableAdapter tblFolioCotizacionTableAdapter
    {
      get => this._tblFolioCotizacionTableAdapter;
      set => this._tblFolioCotizacionTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblFolioOrdenCompraTableAdapter tblFolioOrdenCompraTableAdapter
    {
      get => this._tblFolioOrdenCompraTableAdapter;
      set => this._tblFolioOrdenCompraTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblFolioReqTableAdapter tblFolioReqTableAdapter
    {
      get => this._tblFolioReqTableAdapter;
      set => this._tblFolioReqTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblFolioRFQTableAdapter tblFolioRFQTableAdapter
    {
      get => this._tblFolioRFQTableAdapter;
      set => this._tblFolioRFQTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblGastosTableAdapter tblGastosTableAdapter
    {
      get => this._tblGastosTableAdapter;
      set => this._tblGastosTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblGPSTableAdapter tblGPSTableAdapter
    {
      get => this._tblGPSTableAdapter;
      set => this._tblGPSTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblHabilidadesTableAdapter tblHabilidadesTableAdapter
    {
      get => this._tblHabilidadesTableAdapter;
      set => this._tblHabilidadesTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblHorasHombreTableAdapter tblHorasHombreTableAdapter
    {
      get => this._tblHorasHombreTableAdapter;
      set => this._tblHorasHombreTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblInventarioTableAdapter tblInventarioTableAdapter
    {
      get => this._tblInventarioTableAdapter;
      set => this._tblInventarioTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblInventarioDetTableAdapter tblInventarioDetTableAdapter
    {
      get => this._tblInventarioDetTableAdapter;
      set => this._tblInventarioDetTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblInvHerramientasTableAdapter tblInvHerramientasTableAdapter
    {
      get => this._tblInvHerramientasTableAdapter;
      set => this._tblInvHerramientasTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblInvHerramientasDetTableAdapter tblInvHerramientasDetTableAdapter
    {
      get => this._tblInvHerramientasDetTableAdapter;
      set => this._tblInvHerramientasDetTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblLiderProyectoTableAdapter tblLiderProyectoTableAdapter
    {
      get => this._tblLiderProyectoTableAdapter;
      set => this._tblLiderProyectoTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblListaPendientesTableAdapter tblListaPendientesTableAdapter
    {
      get => this._tblListaPendientesTableAdapter;
      set => this._tblListaPendientesTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblMaterialesTableAdapter tblMaterialesTableAdapter
    {
      get => this._tblMaterialesTableAdapter;
      set => this._tblMaterialesTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblMaterialImagenTableAdapter tblMaterialImagenTableAdapter
    {
      get => this._tblMaterialImagenTableAdapter;
      set => this._tblMaterialImagenTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblMatrizMecanicoTableAdapter tblMatrizMecanicoTableAdapter
    {
      get => this._tblMatrizMecanicoTableAdapter;
      set => this._tblMatrizMecanicoTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblMenuTableAdapter tblMenuTableAdapter
    {
      get => this._tblMenuTableAdapter;
      set => this._tblMenuTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblMonedasTableAdapter tblMonedasTableAdapter
    {
      get => this._tblMonedasTableAdapter;
      set => this._tblMonedasTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblNotaAclaratoriaTableAdapter tblNotaAclaratoriaTableAdapter
    {
      get => this._tblNotaAclaratoriaTableAdapter;
      set => this._tblNotaAclaratoriaTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblOrdenCompraTableAdapter tblOrdenCompraTableAdapter
    {
      get => this._tblOrdenCompraTableAdapter;
      set => this._tblOrdenCompraTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblOrdenCompraComentariosTableAdapter tblOrdenCompraComentariosTableAdapter
    {
      get => this._tblOrdenCompraComentariosTableAdapter;
      set => this._tblOrdenCompraComentariosTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblOrdenCompraDetTableAdapter tblOrdenCompraDetTableAdapter
    {
      get => this._tblOrdenCompraDetTableAdapter;
      set => this._tblOrdenCompraDetTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblOrdenCompraInsumosTableAdapter tblOrdenCompraInsumosTableAdapter
    {
      get => this._tblOrdenCompraInsumosTableAdapter;
      set => this._tblOrdenCompraInsumosTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblOrdenCompraNotaTableAdapter tblOrdenCompraNotaTableAdapter
    {
      get => this._tblOrdenCompraNotaTableAdapter;
      set => this._tblOrdenCompraNotaTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblOrdenTrabajoTableAdapter tblOrdenTrabajoTableAdapter
    {
      get => this._tblOrdenTrabajoTableAdapter;
      set => this._tblOrdenTrabajoTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblPermisosTableAdapter tblPermisosTableAdapter
    {
      get => this._tblPermisosTableAdapter;
      set => this._tblPermisosTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblProveedoresTableAdapter tblProveedoresTableAdapter
    {
      get => this._tblProveedoresTableAdapter;
      set => this._tblProveedoresTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblProveedoresContactosTableAdapter tblProveedoresContactosTableAdapter
    {
      get => this._tblProveedoresContactosTableAdapter;
      set => this._tblProveedoresContactosTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblProveedorMaterialTableAdapter tblProveedorMaterialTableAdapter
    {
      get => this._tblProveedorMaterialTableAdapter;
      set => this._tblProveedorMaterialTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblProyectoRequerimientoTableAdapter tblProyectoRequerimientoTableAdapter
    {
      get => this._tblProyectoRequerimientoTableAdapter;
      set => this._tblProyectoRequerimientoTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblProyectosTableAdapter tblProyectosTableAdapter
    {
      get => this._tblProyectosTableAdapter;
      set => this._tblProyectosTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblProyectosBKTableAdapter tblProyectosBKTableAdapter
    {
      get => this._tblProyectosBKTableAdapter;
      set => this._tblProyectosBKTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblProyectoTaskImagenTableAdapter tblProyectoTaskImagenTableAdapter
    {
      get => this._tblProyectoTaskImagenTableAdapter;
      set => this._tblProyectoTaskImagenTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblProyectoTasksTableAdapter tblProyectoTasksTableAdapter
    {
      get => this._tblProyectoTasksTableAdapter;
      set => this._tblProyectoTasksTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblProyectoTasksBKTableAdapter tblProyectoTasksBKTableAdapter
    {
      get => this._tblProyectoTasksBKTableAdapter;
      set => this._tblProyectoTasksBKTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblProyectoTasksComentariosTableAdapter tblProyectoTasksComentariosTableAdapter
    {
      get => this._tblProyectoTasksComentariosTableAdapter;
      set => this._tblProyectoTasksComentariosTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblRecuperacionesTableAdapter tblRecuperacionesTableAdapter
    {
      get => this._tblRecuperacionesTableAdapter;
      set => this._tblRecuperacionesTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblReqDetTableAdapter tblReqDetTableAdapter
    {
      get => this._tblReqDetTableAdapter;
      set => this._tblReqDetTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblReqEncTableAdapter tblReqEncTableAdapter
    {
      get => this._tblReqEncTableAdapter;
      set => this._tblReqEncTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblRequisicionTableAdapter tblRequisicionTableAdapter
    {
      get => this._tblRequisicionTableAdapter;
      set => this._tblRequisicionTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblRFQTableAdapter tblRFQTableAdapter
    {
      get => this._tblRFQTableAdapter;
      set => this._tblRFQTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblRFQDetTableAdapter tblRFQDetTableAdapter
    {
      get => this._tblRFQDetTableAdapter;
      set => this._tblRFQDetTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblRfqSeguimientoTableAdapter tblRfqSeguimientoTableAdapter
    {
      get => this._tblRfqSeguimientoTableAdapter;
      set => this._tblRfqSeguimientoTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblRfqVentasTableAdapter tblRfqVentasTableAdapter
    {
      get => this._tblRfqVentasTableAdapter;
      set => this._tblRfqVentasTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblRolesUsuariosTableAdapter tblRolesUsuariosTableAdapter
    {
      get => this._tblRolesUsuariosTableAdapter;
      set => this._tblRolesUsuariosTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblServicioComputoTableAdapter tblServicioComputoTableAdapter
    {
      get => this._tblServicioComputoTableAdapter;
      set => this._tblServicioComputoTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblServiciosComputoTableAdapter tblServiciosComputoTableAdapter
    {
      get => this._tblServiciosComputoTableAdapter;
      set => this._tblServiciosComputoTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblSolicitudesAprobacionTableAdapter tblSolicitudesAprobacionTableAdapter
    {
      get => this._tblSolicitudesAprobacionTableAdapter;
      set => this._tblSolicitudesAprobacionTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblSubMenuTableAdapter tblSubMenuTableAdapter
    {
      get => this._tblSubMenuTableAdapter;
      set => this._tblSubMenuTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblSucursalesTableAdapter tblSucursalesTableAdapter
    {
      get => this._tblSucursalesTableAdapter;
      set => this._tblSucursalesTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblTeamProjectTableAdapter tblTeamProjectTableAdapter
    {
      get => this._tblTeamProjectTableAdapter;
      set => this._tblTeamProjectTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblTimmingProyectoTableAdapter tblTimmingProyectoTableAdapter
    {
      get => this._tblTimmingProyectoTableAdapter;
      set => this._tblTimmingProyectoTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblUnidadMedidaTableAdapter tblUnidadMedidaTableAdapter
    {
      get => this._tblUnidadMedidaTableAdapter;
      set => this._tblUnidadMedidaTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblUsuariosTableAdapter tblUsuariosTableAdapter
    {
      get => this._tblUsuariosTableAdapter;
      set => this._tblUsuariosTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblUsuariosBKTableAdapter tblUsuariosBKTableAdapter
    {
      get => this._tblUsuariosBKTableAdapter;
      set => this._tblUsuariosBKTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblVehiculosTableAdapter tblVehiculosTableAdapter
    {
      get => this._tblVehiculosTableAdapter;
      set => this._tblVehiculosTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblVehiculoServicioTableAdapter tblVehiculoServicioTableAdapter
    {
      get => this._tblVehiculoServicioTableAdapter;
      set => this._tblVehiculoServicioTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblVehiculoServicioItemTableAdapter tblVehiculoServicioItemTableAdapter
    {
      get => this._tblVehiculoServicioItemTableAdapter;
      set => this._tblVehiculoServicioItemTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblViaticosTableAdapter tblViaticosTableAdapter
    {
      get => this._tblViaticosTableAdapter;
      set => this._tblViaticosTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblViaticosDetTableAdapter tblViaticosDetTableAdapter
    {
      get => this._tblViaticosDetTableAdapter;
      set => this._tblViaticosDetTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public UtilidadTableAdapter UtilidadTableAdapter
    {
      get => this._utilidadTableAdapter;
      set => this._utilidadTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public UtilidadPastelTableAdapter UtilidadPastelTableAdapter
    {
      get => this._utilidadPastelTableAdapter;
      set => this._utilidadPastelTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public bool BackupDataSetBeforeUpdate
    {
      get => this._backupDataSetBeforeUpdate;
      set => this._backupDataSetBeforeUpdate = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Browsable(false)]
    public IDbConnection Connection
    {
      get
      {
        if (this._connection != null)
          return this._connection;
        if (this._dateDimensionTableAdapter != null && this._dateDimensionTableAdapter.Connection != null)
          return (IDbConnection) this._dateDimensionTableAdapter.Connection;
        if (this._matTableAdapter != null && this._matTableAdapter.Connection != null)
          return (IDbConnection) this._matTableAdapter.Connection;
        if (this._mat2TableAdapter != null && this._mat2TableAdapter.Connection != null)
          return (IDbConnection) this._mat2TableAdapter.Connection;
        if (this._mat3TableAdapter != null && this._mat3TableAdapter.Connection != null)
          return (IDbConnection) this._mat3TableAdapter.Connection;
        if (this._matUrreaTableAdapter != null && this._matUrreaTableAdapter.Connection != null)
          return (IDbConnection) this._matUrreaTableAdapter.Connection;
        if (this._productosTableAdapter != null && this._productosTableAdapter.Connection != null)
          return (IDbConnection) this._productosTableAdapter.Connection;
        if (this._tblBoletinTableAdapter != null && this._tblBoletinTableAdapter.Connection != null)
          return (IDbConnection) this._tblBoletinTableAdapter.Connection;
        if (this._tblCajaChicaTableAdapter != null && this._tblCajaChicaTableAdapter.Connection != null)
          return (IDbConnection) this._tblCajaChicaTableAdapter.Connection;
        if (this._tblCalendarioTableAdapter != null && this._tblCalendarioTableAdapter.Connection != null)
          return (IDbConnection) this._tblCalendarioTableAdapter.Connection;
        if (this._tblCategoriaTableAdapter != null && this._tblCategoriaTableAdapter.Connection != null)
          return (IDbConnection) this._tblCategoriaTableAdapter.Connection;
        if (this._tblChatTableAdapter != null && this._tblChatTableAdapter.Connection != null)
          return (IDbConnection) this._tblChatTableAdapter.Connection;
        if (this._tblClienteContactoTableAdapter != null && this._tblClienteContactoTableAdapter.Connection != null)
          return (IDbConnection) this._tblClienteContactoTableAdapter.Connection;
        if (this._tblClientesTableAdapter != null && this._tblClientesTableAdapter.Connection != null)
          return (IDbConnection) this._tblClientesTableAdapter.Connection;
        if (this._tblComentariosCotizacionTableAdapter != null && this._tblComentariosCotizacionTableAdapter.Connection != null)
          return (IDbConnection) this._tblComentariosCotizacionTableAdapter.Connection;
        if (this._tblComentariosProyectoTableAdapter != null && this._tblComentariosProyectoTableAdapter.Connection != null)
          return (IDbConnection) this._tblComentariosProyectoTableAdapter.Connection;
        if (this._tblControlFacturasTableAdapter != null && this._tblControlFacturasTableAdapter.Connection != null)
          return (IDbConnection) this._tblControlFacturasTableAdapter.Connection;
        if (this._tblCotizacionesTableAdapter != null && this._tblCotizacionesTableAdapter.Connection != null)
          return (IDbConnection) this._tblCotizacionesTableAdapter.Connection;
        if (this._tblCotizacionesDetTableAdapter != null && this._tblCotizacionesDetTableAdapter.Connection != null)
          return (IDbConnection) this._tblCotizacionesDetTableAdapter.Connection;
        if (this._tblCotizacionNewTableAdapter != null && this._tblCotizacionNewTableAdapter.Connection != null)
          return (IDbConnection) this._tblCotizacionNewTableAdapter.Connection;
        if (this._tblDatosEmpresaTableAdapter != null && this._tblDatosEmpresaTableAdapter.Connection != null)
          return (IDbConnection) this._tblDatosEmpresaTableAdapter.Connection;
        if (this._tblDocDisenosMecanicoTableAdapter != null && this._tblDocDisenosMecanicoTableAdapter.Connection != null)
          return (IDbConnection) this._tblDocDisenosMecanicoTableAdapter.Connection;
        if (this._tblDocMasterCamMecanicoTableAdapter != null && this._tblDocMasterCamMecanicoTableAdapter.Connection != null)
          return (IDbConnection) this._tblDocMasterCamMecanicoTableAdapter.Connection;
        if (this._tblDocProyectosTableAdapter != null && this._tblDocProyectosTableAdapter.Connection != null)
          return (IDbConnection) this._tblDocProyectosTableAdapter.Connection;
        if (this._tblEficienciasTableAdapter != null && this._tblEficienciasTableAdapter.Connection != null)
          return (IDbConnection) this._tblEficienciasTableAdapter.Connection;
        if (this._tblEmpresasTableAdapter != null && this._tblEmpresasTableAdapter.Connection != null)
          return (IDbConnection) this._tblEmpresasTableAdapter.Connection;
        if (this._tblFacturasEmitidasTableAdapter != null && this._tblFacturasEmitidasTableAdapter.Connection != null)
          return (IDbConnection) this._tblFacturasEmitidasTableAdapter.Connection;
        if (this._tblFacturasXMLTableAdapter != null && this._tblFacturasXMLTableAdapter.Connection != null)
          return (IDbConnection) this._tblFacturasXMLTableAdapter.Connection;
        if (this._tblFallasTableAdapter != null && this._tblFallasTableAdapter.Connection != null)
          return (IDbConnection) this._tblFallasTableAdapter.Connection;
        if (this._tblFolioCotizacionTableAdapter != null && this._tblFolioCotizacionTableAdapter.Connection != null)
          return (IDbConnection) this._tblFolioCotizacionTableAdapter.Connection;
        if (this._tblFolioOrdenCompraTableAdapter != null && this._tblFolioOrdenCompraTableAdapter.Connection != null)
          return (IDbConnection) this._tblFolioOrdenCompraTableAdapter.Connection;
        if (this._tblFolioReqTableAdapter != null && this._tblFolioReqTableAdapter.Connection != null)
          return (IDbConnection) this._tblFolioReqTableAdapter.Connection;
        if (this._tblFolioRFQTableAdapter != null && this._tblFolioRFQTableAdapter.Connection != null)
          return (IDbConnection) this._tblFolioRFQTableAdapter.Connection;
        if (this._tblGastosTableAdapter != null && this._tblGastosTableAdapter.Connection != null)
          return (IDbConnection) this._tblGastosTableAdapter.Connection;
        if (this._tblGPSTableAdapter != null && this._tblGPSTableAdapter.Connection != null)
          return (IDbConnection) this._tblGPSTableAdapter.Connection;
        if (this._tblHabilidadesTableAdapter != null && this._tblHabilidadesTableAdapter.Connection != null)
          return (IDbConnection) this._tblHabilidadesTableAdapter.Connection;
        if (this._tblHorasHombreTableAdapter != null && this._tblHorasHombreTableAdapter.Connection != null)
          return (IDbConnection) this._tblHorasHombreTableAdapter.Connection;
        if (this._tblInventarioTableAdapter != null && this._tblInventarioTableAdapter.Connection != null)
          return (IDbConnection) this._tblInventarioTableAdapter.Connection;
        if (this._tblInventarioDetTableAdapter != null && this._tblInventarioDetTableAdapter.Connection != null)
          return (IDbConnection) this._tblInventarioDetTableAdapter.Connection;
        if (this._tblInvHerramientasTableAdapter != null && this._tblInvHerramientasTableAdapter.Connection != null)
          return (IDbConnection) this._tblInvHerramientasTableAdapter.Connection;
        if (this._tblInvHerramientasDetTableAdapter != null && this._tblInvHerramientasDetTableAdapter.Connection != null)
          return (IDbConnection) this._tblInvHerramientasDetTableAdapter.Connection;
        if (this._tblLiderProyectoTableAdapter != null && this._tblLiderProyectoTableAdapter.Connection != null)
          return (IDbConnection) this._tblLiderProyectoTableAdapter.Connection;
        if (this._tblListaPendientesTableAdapter != null && this._tblListaPendientesTableAdapter.Connection != null)
          return (IDbConnection) this._tblListaPendientesTableAdapter.Connection;
        if (this._tblMaterialesTableAdapter != null && this._tblMaterialesTableAdapter.Connection != null)
          return (IDbConnection) this._tblMaterialesTableAdapter.Connection;
        if (this._tblMaterialImagenTableAdapter != null && this._tblMaterialImagenTableAdapter.Connection != null)
          return (IDbConnection) this._tblMaterialImagenTableAdapter.Connection;
        if (this._tblMatrizMecanicoTableAdapter != null && this._tblMatrizMecanicoTableAdapter.Connection != null)
          return (IDbConnection) this._tblMatrizMecanicoTableAdapter.Connection;
        if (this._tblMenuTableAdapter != null && this._tblMenuTableAdapter.Connection != null)
          return (IDbConnection) this._tblMenuTableAdapter.Connection;
        if (this._tblMonedasTableAdapter != null && this._tblMonedasTableAdapter.Connection != null)
          return (IDbConnection) this._tblMonedasTableAdapter.Connection;
        if (this._tblNotaAclaratoriaTableAdapter != null && this._tblNotaAclaratoriaTableAdapter.Connection != null)
          return (IDbConnection) this._tblNotaAclaratoriaTableAdapter.Connection;
        if (this._tblOrdenCompraTableAdapter != null && this._tblOrdenCompraTableAdapter.Connection != null)
          return (IDbConnection) this._tblOrdenCompraTableAdapter.Connection;
        if (this._tblOrdenCompraComentariosTableAdapter != null && this._tblOrdenCompraComentariosTableAdapter.Connection != null)
          return (IDbConnection) this._tblOrdenCompraComentariosTableAdapter.Connection;
        if (this._tblOrdenCompraDetTableAdapter != null && this._tblOrdenCompraDetTableAdapter.Connection != null)
          return (IDbConnection) this._tblOrdenCompraDetTableAdapter.Connection;
        if (this._tblOrdenCompraInsumosTableAdapter != null && this._tblOrdenCompraInsumosTableAdapter.Connection != null)
          return (IDbConnection) this._tblOrdenCompraInsumosTableAdapter.Connection;
        if (this._tblOrdenCompraNotaTableAdapter != null && this._tblOrdenCompraNotaTableAdapter.Connection != null)
          return (IDbConnection) this._tblOrdenCompraNotaTableAdapter.Connection;
        if (this._tblOrdenTrabajoTableAdapter != null && this._tblOrdenTrabajoTableAdapter.Connection != null)
          return (IDbConnection) this._tblOrdenTrabajoTableAdapter.Connection;
        if (this._tblPermisosTableAdapter != null && this._tblPermisosTableAdapter.Connection != null)
          return (IDbConnection) this._tblPermisosTableAdapter.Connection;
        if (this._tblProveedoresTableAdapter != null && this._tblProveedoresTableAdapter.Connection != null)
          return (IDbConnection) this._tblProveedoresTableAdapter.Connection;
        if (this._tblProveedoresContactosTableAdapter != null && this._tblProveedoresContactosTableAdapter.Connection != null)
          return (IDbConnection) this._tblProveedoresContactosTableAdapter.Connection;
        if (this._tblProveedorMaterialTableAdapter != null && this._tblProveedorMaterialTableAdapter.Connection != null)
          return (IDbConnection) this._tblProveedorMaterialTableAdapter.Connection;
        if (this._tblProyectoRequerimientoTableAdapter != null && this._tblProyectoRequerimientoTableAdapter.Connection != null)
          return (IDbConnection) this._tblProyectoRequerimientoTableAdapter.Connection;
        if (this._tblProyectosTableAdapter != null && this._tblProyectosTableAdapter.Connection != null)
          return (IDbConnection) this._tblProyectosTableAdapter.Connection;
        if (this._tblProyectosBKTableAdapter != null && this._tblProyectosBKTableAdapter.Connection != null)
          return (IDbConnection) this._tblProyectosBKTableAdapter.Connection;
        if (this._tblProyectoTaskImagenTableAdapter != null && this._tblProyectoTaskImagenTableAdapter.Connection != null)
          return (IDbConnection) this._tblProyectoTaskImagenTableAdapter.Connection;
        if (this._tblProyectoTasksTableAdapter != null && this._tblProyectoTasksTableAdapter.Connection != null)
          return (IDbConnection) this._tblProyectoTasksTableAdapter.Connection;
        if (this._tblProyectoTasksBKTableAdapter != null && this._tblProyectoTasksBKTableAdapter.Connection != null)
          return (IDbConnection) this._tblProyectoTasksBKTableAdapter.Connection;
        if (this._tblProyectoTasksComentariosTableAdapter != null && this._tblProyectoTasksComentariosTableAdapter.Connection != null)
          return (IDbConnection) this._tblProyectoTasksComentariosTableAdapter.Connection;
        if (this._tblRecuperacionesTableAdapter != null && this._tblRecuperacionesTableAdapter.Connection != null)
          return (IDbConnection) this._tblRecuperacionesTableAdapter.Connection;
        if (this._tblReqDetTableAdapter != null && this._tblReqDetTableAdapter.Connection != null)
          return (IDbConnection) this._tblReqDetTableAdapter.Connection;
        if (this._tblReqEncTableAdapter != null && this._tblReqEncTableAdapter.Connection != null)
          return (IDbConnection) this._tblReqEncTableAdapter.Connection;
        if (this._tblRequisicionTableAdapter != null && this._tblRequisicionTableAdapter.Connection != null)
          return (IDbConnection) this._tblRequisicionTableAdapter.Connection;
        if (this._tblRFQTableAdapter != null && this._tblRFQTableAdapter.Connection != null)
          return (IDbConnection) this._tblRFQTableAdapter.Connection;
        if (this._tblRFQDetTableAdapter != null && this._tblRFQDetTableAdapter.Connection != null)
          return (IDbConnection) this._tblRFQDetTableAdapter.Connection;
        if (this._tblRfqSeguimientoTableAdapter != null && this._tblRfqSeguimientoTableAdapter.Connection != null)
          return (IDbConnection) this._tblRfqSeguimientoTableAdapter.Connection;
        if (this._tblRfqVentasTableAdapter != null && this._tblRfqVentasTableAdapter.Connection != null)
          return (IDbConnection) this._tblRfqVentasTableAdapter.Connection;
        if (this._tblRolesUsuariosTableAdapter != null && this._tblRolesUsuariosTableAdapter.Connection != null)
          return (IDbConnection) this._tblRolesUsuariosTableAdapter.Connection;
        if (this._tblServicioComputoTableAdapter != null && this._tblServicioComputoTableAdapter.Connection != null)
          return (IDbConnection) this._tblServicioComputoTableAdapter.Connection;
        if (this._tblServiciosComputoTableAdapter != null && this._tblServiciosComputoTableAdapter.Connection != null)
          return (IDbConnection) this._tblServiciosComputoTableAdapter.Connection;
        if (this._tblSolicitudesAprobacionTableAdapter != null && this._tblSolicitudesAprobacionTableAdapter.Connection != null)
          return (IDbConnection) this._tblSolicitudesAprobacionTableAdapter.Connection;
        if (this._tblSubMenuTableAdapter != null && this._tblSubMenuTableAdapter.Connection != null)
          return (IDbConnection) this._tblSubMenuTableAdapter.Connection;
        if (this._tblSucursalesTableAdapter != null && this._tblSucursalesTableAdapter.Connection != null)
          return (IDbConnection) this._tblSucursalesTableAdapter.Connection;
        if (this._tblTeamProjectTableAdapter != null && this._tblTeamProjectTableAdapter.Connection != null)
          return (IDbConnection) this._tblTeamProjectTableAdapter.Connection;
        if (this._tblTimmingProyectoTableAdapter != null && this._tblTimmingProyectoTableAdapter.Connection != null)
          return (IDbConnection) this._tblTimmingProyectoTableAdapter.Connection;
        if (this._tblUnidadMedidaTableAdapter != null && this._tblUnidadMedidaTableAdapter.Connection != null)
          return (IDbConnection) this._tblUnidadMedidaTableAdapter.Connection;
        if (this._tblUsuariosTableAdapter != null && this._tblUsuariosTableAdapter.Connection != null)
          return (IDbConnection) this._tblUsuariosTableAdapter.Connection;
        if (this._tblUsuariosBKTableAdapter != null && this._tblUsuariosBKTableAdapter.Connection != null)
          return (IDbConnection) this._tblUsuariosBKTableAdapter.Connection;
        if (this._tblVehiculosTableAdapter != null && this._tblVehiculosTableAdapter.Connection != null)
          return (IDbConnection) this._tblVehiculosTableAdapter.Connection;
        if (this._tblVehiculoServicioTableAdapter != null && this._tblVehiculoServicioTableAdapter.Connection != null)
          return (IDbConnection) this._tblVehiculoServicioTableAdapter.Connection;
        if (this._tblVehiculoServicioItemTableAdapter != null && this._tblVehiculoServicioItemTableAdapter.Connection != null)
          return (IDbConnection) this._tblVehiculoServicioItemTableAdapter.Connection;
        if (this._tblViaticosTableAdapter != null && this._tblViaticosTableAdapter.Connection != null)
          return (IDbConnection) this._tblViaticosTableAdapter.Connection;
        if (this._tblViaticosDetTableAdapter != null && this._tblViaticosDetTableAdapter.Connection != null)
          return (IDbConnection) this._tblViaticosDetTableAdapter.Connection;
        if (this._utilidadTableAdapter != null && this._utilidadTableAdapter.Connection != null)
          return (IDbConnection) this._utilidadTableAdapter.Connection;
        return this._utilidadPastelTableAdapter != null && this._utilidadPastelTableAdapter.Connection != null ? (IDbConnection) this._utilidadPastelTableAdapter.Connection : (IDbConnection) null;
      }
      set => this._connection = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Browsable(false)]
    public int TableAdapterInstanceCount
    {
      get
      {
        int num = 0;
        if (this._dateDimensionTableAdapter != null)
          ++num;
        if (this._matTableAdapter != null)
          ++num;
        if (this._mat2TableAdapter != null)
          ++num;
        if (this._mat3TableAdapter != null)
          ++num;
        if (this._matUrreaTableAdapter != null)
          ++num;
        if (this._productosTableAdapter != null)
          ++num;
        if (this._tblBoletinTableAdapter != null)
          ++num;
        if (this._tblCajaChicaTableAdapter != null)
          ++num;
        if (this._tblCalendarioTableAdapter != null)
          ++num;
        if (this._tblCategoriaTableAdapter != null)
          ++num;
        if (this._tblChatTableAdapter != null)
          ++num;
        if (this._tblClienteContactoTableAdapter != null)
          ++num;
        if (this._tblClientesTableAdapter != null)
          ++num;
        if (this._tblComentariosCotizacionTableAdapter != null)
          ++num;
        if (this._tblComentariosProyectoTableAdapter != null)
          ++num;
        if (this._tblControlFacturasTableAdapter != null)
          ++num;
        if (this._tblCotizacionesTableAdapter != null)
          ++num;
        if (this._tblCotizacionesDetTableAdapter != null)
          ++num;
        if (this._tblCotizacionNewTableAdapter != null)
          ++num;
        if (this._tblDatosEmpresaTableAdapter != null)
          ++num;
        if (this._tblDocDisenosMecanicoTableAdapter != null)
          ++num;
        if (this._tblDocMasterCamMecanicoTableAdapter != null)
          ++num;
        if (this._tblDocProyectosTableAdapter != null)
          ++num;
        if (this._tblEficienciasTableAdapter != null)
          ++num;
        if (this._tblEmpresasTableAdapter != null)
          ++num;
        if (this._tblFacturasEmitidasTableAdapter != null)
          ++num;
        if (this._tblFacturasXMLTableAdapter != null)
          ++num;
        if (this._tblFallasTableAdapter != null)
          ++num;
        if (this._tblFolioCotizacionTableAdapter != null)
          ++num;
        if (this._tblFolioOrdenCompraTableAdapter != null)
          ++num;
        if (this._tblFolioReqTableAdapter != null)
          ++num;
        if (this._tblFolioRFQTableAdapter != null)
          ++num;
        if (this._tblGastosTableAdapter != null)
          ++num;
        if (this._tblGPSTableAdapter != null)
          ++num;
        if (this._tblHabilidadesTableAdapter != null)
          ++num;
        if (this._tblHorasHombreTableAdapter != null)
          ++num;
        if (this._tblInventarioTableAdapter != null)
          ++num;
        if (this._tblInventarioDetTableAdapter != null)
          ++num;
        if (this._tblInvHerramientasTableAdapter != null)
          ++num;
        if (this._tblInvHerramientasDetTableAdapter != null)
          ++num;
        if (this._tblLiderProyectoTableAdapter != null)
          ++num;
        if (this._tblListaPendientesTableAdapter != null)
          ++num;
        if (this._tblMaterialesTableAdapter != null)
          ++num;
        if (this._tblMaterialImagenTableAdapter != null)
          ++num;
        if (this._tblMatrizMecanicoTableAdapter != null)
          ++num;
        if (this._tblMenuTableAdapter != null)
          ++num;
        if (this._tblMonedasTableAdapter != null)
          ++num;
        if (this._tblNotaAclaratoriaTableAdapter != null)
          ++num;
        if (this._tblOrdenCompraTableAdapter != null)
          ++num;
        if (this._tblOrdenCompraComentariosTableAdapter != null)
          ++num;
        if (this._tblOrdenCompraDetTableAdapter != null)
          ++num;
        if (this._tblOrdenCompraInsumosTableAdapter != null)
          ++num;
        if (this._tblOrdenCompraNotaTableAdapter != null)
          ++num;
        if (this._tblOrdenTrabajoTableAdapter != null)
          ++num;
        if (this._tblPermisosTableAdapter != null)
          ++num;
        if (this._tblProveedoresTableAdapter != null)
          ++num;
        if (this._tblProveedoresContactosTableAdapter != null)
          ++num;
        if (this._tblProveedorMaterialTableAdapter != null)
          ++num;
        if (this._tblProyectoRequerimientoTableAdapter != null)
          ++num;
        if (this._tblProyectosTableAdapter != null)
          ++num;
        if (this._tblProyectosBKTableAdapter != null)
          ++num;
        if (this._tblProyectoTaskImagenTableAdapter != null)
          ++num;
        if (this._tblProyectoTasksTableAdapter != null)
          ++num;
        if (this._tblProyectoTasksBKTableAdapter != null)
          ++num;
        if (this._tblProyectoTasksComentariosTableAdapter != null)
          ++num;
        if (this._tblRecuperacionesTableAdapter != null)
          ++num;
        if (this._tblReqDetTableAdapter != null)
          ++num;
        if (this._tblReqEncTableAdapter != null)
          ++num;
        if (this._tblRequisicionTableAdapter != null)
          ++num;
        if (this._tblRFQTableAdapter != null)
          ++num;
        if (this._tblRFQDetTableAdapter != null)
          ++num;
        if (this._tblRfqSeguimientoTableAdapter != null)
          ++num;
        if (this._tblRfqVentasTableAdapter != null)
          ++num;
        if (this._tblRolesUsuariosTableAdapter != null)
          ++num;
        if (this._tblServicioComputoTableAdapter != null)
          ++num;
        if (this._tblServiciosComputoTableAdapter != null)
          ++num;
        if (this._tblSolicitudesAprobacionTableAdapter != null)
          ++num;
        if (this._tblSubMenuTableAdapter != null)
          ++num;
        if (this._tblSucursalesTableAdapter != null)
          ++num;
        if (this._tblTeamProjectTableAdapter != null)
          ++num;
        if (this._tblTimmingProyectoTableAdapter != null)
          ++num;
        if (this._tblUnidadMedidaTableAdapter != null)
          ++num;
        if (this._tblUsuariosTableAdapter != null)
          ++num;
        if (this._tblUsuariosBKTableAdapter != null)
          ++num;
        if (this._tblVehiculosTableAdapter != null)
          ++num;
        if (this._tblVehiculoServicioTableAdapter != null)
          ++num;
        if (this._tblVehiculoServicioItemTableAdapter != null)
          ++num;
        if (this._tblViaticosTableAdapter != null)
          ++num;
        if (this._tblViaticosDetTableAdapter != null)
          ++num;
        if (this._utilidadTableAdapter != null)
          ++num;
        if (this._utilidadPastelTableAdapter != null)
          ++num;
        return num;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private int UpdateUpdatedRows(
      SisaDevFacturas dataSet,
      List<DataRow> allChangedRows,
      List<DataRow> allAddedRows)
    {
      int num = 0;
      if (this._dateDimensionTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.DateDimension.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._dateDimensionTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblRecuperacionesTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblRecuperaciones.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblRecuperacionesTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblProyectoTasksComentariosTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblProyectoTasksComentarios.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblProyectoTasksComentariosTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblProyectoTasksBKTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblProyectoTasksBK.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblProyectoTasksBKTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblProyectoTasksTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblProyectoTasks.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblProyectoTasksTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblProyectoTaskImagenTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblProyectoTaskImagen.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblProyectoTaskImagenTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblProyectosBKTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblProyectosBK.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblProyectosBKTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblProyectosTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblProyectos.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblProyectosTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblProyectoRequerimientoTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblProyectoRequerimiento.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblProyectoRequerimientoTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblProveedorMaterialTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblProveedorMaterial.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblProveedorMaterialTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblProveedoresContactosTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblProveedoresContactos.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblProveedoresContactosTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblProveedoresTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblProveedores.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblProveedoresTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblPermisosTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblPermisos.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblPermisosTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblOrdenTrabajoTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblOrdenTrabajo.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblOrdenTrabajoTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblOrdenCompraNotaTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblOrdenCompraNota.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblOrdenCompraNotaTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblOrdenCompraInsumosTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblOrdenCompraInsumos.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblOrdenCompraInsumosTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblOrdenCompraDetTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblOrdenCompraDet.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblOrdenCompraDetTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblOrdenCompraComentariosTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblOrdenCompraComentarios.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblOrdenCompraComentariosTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblOrdenCompraTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblOrdenCompra.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblOrdenCompraTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblNotaAclaratoriaTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblNotaAclaratoria.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblNotaAclaratoriaTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblReqDetTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblReqDet.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblReqDetTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblMonedasTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblMonedas.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblMonedasTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblReqEncTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblReqEnc.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblReqEncTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblRFQTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblRFQ.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblRFQTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblViaticosDetTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblViaticosDet.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblViaticosDetTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblViaticosTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblViaticos.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblViaticosTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblVehiculoServicioItemTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblVehiculoServicioItem.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblVehiculoServicioItemTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblVehiculoServicioTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblVehiculoServicio.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblVehiculoServicioTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblVehiculosTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblVehiculos.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblVehiculosTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblUsuariosBKTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblUsuariosBK.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblUsuariosBKTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblUsuariosTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblUsuarios.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblUsuariosTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblUnidadMedidaTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblUnidadMedida.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblUnidadMedidaTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblTimmingProyectoTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblTimmingProyecto.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblTimmingProyectoTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblTeamProjectTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblTeamProject.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblTeamProjectTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblSucursalesTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblSucursales.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblSucursalesTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblSubMenuTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblSubMenu.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblSubMenuTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblSolicitudesAprobacionTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblSolicitudesAprobacion.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblSolicitudesAprobacionTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblServiciosComputoTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblServiciosComputo.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblServiciosComputoTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblServicioComputoTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblServicioComputo.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblServicioComputoTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblRolesUsuariosTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblRolesUsuarios.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblRolesUsuariosTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblRfqVentasTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblRfqVentas.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblRfqVentasTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblRfqSeguimientoTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblRfqSeguimiento.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblRfqSeguimientoTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblRFQDetTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblRFQDet.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblRFQDetTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblRequisicionTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblRequisicion.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblRequisicionTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._utilidadTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.Utilidad.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._utilidadTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblMenuTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblMenu.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblMenuTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblMaterialImagenTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblMaterialImagen.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblMaterialImagenTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblDatosEmpresaTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblDatosEmpresa.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblDatosEmpresaTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblCotizacionNewTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblCotizacionNew.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblCotizacionNewTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblCotizacionesDetTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblCotizacionesDet.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblCotizacionesDetTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblCotizacionesTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblCotizaciones.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblCotizacionesTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblControlFacturasTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblControlFacturas.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblControlFacturasTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblComentariosProyectoTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblComentariosProyecto.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblComentariosProyectoTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblComentariosCotizacionTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblComentariosCotizacion.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblComentariosCotizacionTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblClientesTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblClientes.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblClientesTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblClienteContactoTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblClienteContacto.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblClienteContactoTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblChatTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblChat.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblChatTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblCategoriaTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblCategoria.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblCategoriaTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblCalendarioTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblCalendario.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblCalendarioTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblCajaChicaTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblCajaChica.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblCajaChicaTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblBoletinTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblBoletin.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblBoletinTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._productosTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.Productos.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._productosTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._matUrreaTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.MatUrrea.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._matUrreaTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._mat3TableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.Mat3.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._mat3TableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._mat2TableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.Mat2.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._mat2TableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._matTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.Mat.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._matTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblDocDisenosMecanicoTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblDocDisenosMecanico.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblDocDisenosMecanicoTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblMatrizMecanicoTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblMatrizMecanico.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblMatrizMecanicoTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblDocMasterCamMecanicoTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblDocMasterCamMecanico.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblDocMasterCamMecanicoTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblEficienciasTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblEficiencias.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblEficienciasTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblMaterialesTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblMateriales.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblMaterialesTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblListaPendientesTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblListaPendientes.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblListaPendientesTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblLiderProyectoTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblLiderProyecto.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblLiderProyectoTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblInvHerramientasDetTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblInvHerramientasDet.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblInvHerramientasDetTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblInvHerramientasTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblInvHerramientas.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblInvHerramientasTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblInventarioDetTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblInventarioDet.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblInventarioDetTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblInventarioTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblInventario.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblInventarioTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblHorasHombreTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblHorasHombre.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblHorasHombreTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblHabilidadesTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblHabilidades.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblHabilidadesTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblGPSTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblGPS.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblGPSTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblGastosTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblGastos.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblGastosTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblFolioRFQTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblFolioRFQ.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblFolioRFQTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblFolioReqTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblFolioReq.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblFolioReqTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblFolioOrdenCompraTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblFolioOrdenCompra.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblFolioOrdenCompraTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblFolioCotizacionTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblFolioCotizacion.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblFolioCotizacionTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblFallasTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblFallas.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblFallasTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblFacturasXMLTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblFacturasXML.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblFacturasXMLTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblFacturasEmitidasTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblFacturasEmitidas.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblFacturasEmitidasTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblEmpresasTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblEmpresas.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblEmpresasTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblDocProyectosTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblDocProyectos.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblDocProyectosTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._utilidadPastelTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.UtilidadPastel.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._utilidadPastelTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      return num;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private int UpdateInsertedRows(SisaDevFacturas dataSet, List<DataRow> allAddedRows)
    {
      int num = 0;
      if (this._dateDimensionTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.DateDimension.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._dateDimensionTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblRecuperacionesTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblRecuperaciones.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblRecuperacionesTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblProyectoTasksComentariosTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblProyectoTasksComentarios.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblProyectoTasksComentariosTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblProyectoTasksBKTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblProyectoTasksBK.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblProyectoTasksBKTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblProyectoTasksTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblProyectoTasks.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblProyectoTasksTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblProyectoTaskImagenTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblProyectoTaskImagen.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblProyectoTaskImagenTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblProyectosBKTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblProyectosBK.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblProyectosBKTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblProyectosTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblProyectos.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblProyectosTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblProyectoRequerimientoTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblProyectoRequerimiento.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblProyectoRequerimientoTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblProveedorMaterialTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblProveedorMaterial.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblProveedorMaterialTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblProveedoresContactosTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblProveedoresContactos.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblProveedoresContactosTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblProveedoresTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblProveedores.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblProveedoresTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblPermisosTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblPermisos.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblPermisosTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblOrdenTrabajoTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblOrdenTrabajo.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblOrdenTrabajoTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblOrdenCompraNotaTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblOrdenCompraNota.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblOrdenCompraNotaTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblOrdenCompraInsumosTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblOrdenCompraInsumos.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblOrdenCompraInsumosTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblOrdenCompraDetTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblOrdenCompraDet.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblOrdenCompraDetTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblOrdenCompraComentariosTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblOrdenCompraComentarios.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblOrdenCompraComentariosTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblOrdenCompraTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblOrdenCompra.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblOrdenCompraTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblNotaAclaratoriaTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblNotaAclaratoria.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblNotaAclaratoriaTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblReqDetTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblReqDet.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblReqDetTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblMonedasTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblMonedas.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblMonedasTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblReqEncTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblReqEnc.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblReqEncTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblRFQTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblRFQ.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblRFQTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblViaticosDetTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblViaticosDet.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblViaticosDetTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblViaticosTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblViaticos.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblViaticosTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblVehiculoServicioItemTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblVehiculoServicioItem.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblVehiculoServicioItemTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblVehiculoServicioTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblVehiculoServicio.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblVehiculoServicioTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblVehiculosTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblVehiculos.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblVehiculosTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblUsuariosBKTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblUsuariosBK.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblUsuariosBKTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblUsuariosTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblUsuarios.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblUsuariosTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblUnidadMedidaTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblUnidadMedida.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblUnidadMedidaTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblTimmingProyectoTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblTimmingProyecto.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblTimmingProyectoTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblTeamProjectTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblTeamProject.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblTeamProjectTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblSucursalesTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblSucursales.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblSucursalesTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblSubMenuTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblSubMenu.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblSubMenuTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblSolicitudesAprobacionTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblSolicitudesAprobacion.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblSolicitudesAprobacionTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblServiciosComputoTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblServiciosComputo.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblServiciosComputoTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblServicioComputoTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblServicioComputo.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblServicioComputoTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblRolesUsuariosTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblRolesUsuarios.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblRolesUsuariosTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblRfqVentasTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblRfqVentas.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblRfqVentasTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblRfqSeguimientoTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblRfqSeguimiento.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblRfqSeguimientoTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblRFQDetTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblRFQDet.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblRFQDetTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblRequisicionTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblRequisicion.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblRequisicionTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._utilidadTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.Utilidad.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._utilidadTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblMenuTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblMenu.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblMenuTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblMaterialImagenTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblMaterialImagen.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblMaterialImagenTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblDatosEmpresaTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblDatosEmpresa.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblDatosEmpresaTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblCotizacionNewTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblCotizacionNew.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblCotizacionNewTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblCotizacionesDetTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblCotizacionesDet.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblCotizacionesDetTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblCotizacionesTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblCotizaciones.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblCotizacionesTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblControlFacturasTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblControlFacturas.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblControlFacturasTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblComentariosProyectoTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblComentariosProyecto.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblComentariosProyectoTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblComentariosCotizacionTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblComentariosCotizacion.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblComentariosCotizacionTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblClientesTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblClientes.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblClientesTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblClienteContactoTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblClienteContacto.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblClienteContactoTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblChatTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblChat.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblChatTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblCategoriaTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblCategoria.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblCategoriaTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblCalendarioTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblCalendario.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblCalendarioTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblCajaChicaTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblCajaChica.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblCajaChicaTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblBoletinTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblBoletin.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblBoletinTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._productosTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.Productos.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._productosTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._matUrreaTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.MatUrrea.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._matUrreaTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._mat3TableAdapter != null)
      {
        DataRow[] dataRows = dataSet.Mat3.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._mat3TableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._mat2TableAdapter != null)
      {
        DataRow[] dataRows = dataSet.Mat2.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._mat2TableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._matTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.Mat.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._matTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblDocDisenosMecanicoTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblDocDisenosMecanico.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblDocDisenosMecanicoTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblMatrizMecanicoTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblMatrizMecanico.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblMatrizMecanicoTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblDocMasterCamMecanicoTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblDocMasterCamMecanico.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblDocMasterCamMecanicoTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblEficienciasTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblEficiencias.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblEficienciasTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblMaterialesTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblMateriales.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblMaterialesTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblListaPendientesTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblListaPendientes.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblListaPendientesTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblLiderProyectoTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblLiderProyecto.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblLiderProyectoTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblInvHerramientasDetTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblInvHerramientasDet.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblInvHerramientasDetTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblInvHerramientasTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblInvHerramientas.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblInvHerramientasTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblInventarioDetTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblInventarioDet.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblInventarioDetTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblInventarioTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblInventario.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblInventarioTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblHorasHombreTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblHorasHombre.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblHorasHombreTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblHabilidadesTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblHabilidades.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblHabilidadesTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblGPSTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblGPS.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblGPSTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblGastosTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblGastos.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblGastosTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblFolioRFQTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblFolioRFQ.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblFolioRFQTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblFolioReqTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblFolioReq.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblFolioReqTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblFolioOrdenCompraTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblFolioOrdenCompra.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblFolioOrdenCompraTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblFolioCotizacionTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblFolioCotizacion.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblFolioCotizacionTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblFallasTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblFallas.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblFallasTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblFacturasXMLTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblFacturasXML.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblFacturasXMLTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblFacturasEmitidasTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblFacturasEmitidas.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblFacturasEmitidasTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblEmpresasTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblEmpresas.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblEmpresasTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblDocProyectosTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblDocProyectos.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblDocProyectosTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._utilidadPastelTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.UtilidadPastel.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._utilidadPastelTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      return num;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private int UpdateDeletedRows(SisaDevFacturas dataSet, List<DataRow> allChangedRows)
    {
      int num = 0;
      if (this._utilidadPastelTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.UtilidadPastel.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._utilidadPastelTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblDocProyectosTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblDocProyectos.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblDocProyectosTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblEmpresasTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblEmpresas.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblEmpresasTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblFacturasEmitidasTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblFacturasEmitidas.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblFacturasEmitidasTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblFacturasXMLTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblFacturasXML.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblFacturasXMLTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblFallasTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblFallas.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblFallasTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblFolioCotizacionTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblFolioCotizacion.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblFolioCotizacionTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblFolioOrdenCompraTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblFolioOrdenCompra.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblFolioOrdenCompraTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblFolioReqTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblFolioReq.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblFolioReqTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblFolioRFQTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblFolioRFQ.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblFolioRFQTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblGastosTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblGastos.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblGastosTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblGPSTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblGPS.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblGPSTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblHabilidadesTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblHabilidades.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblHabilidadesTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblHorasHombreTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblHorasHombre.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblHorasHombreTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblInventarioTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblInventario.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblInventarioTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblInventarioDetTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblInventarioDet.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblInventarioDetTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblInvHerramientasTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblInvHerramientas.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblInvHerramientasTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblInvHerramientasDetTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblInvHerramientasDet.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblInvHerramientasDetTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblLiderProyectoTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblLiderProyecto.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblLiderProyectoTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblListaPendientesTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblListaPendientes.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblListaPendientesTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblMaterialesTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblMateriales.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblMaterialesTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblEficienciasTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblEficiencias.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblEficienciasTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblDocMasterCamMecanicoTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblDocMasterCamMecanico.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblDocMasterCamMecanicoTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblMatrizMecanicoTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblMatrizMecanico.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblMatrizMecanicoTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblDocDisenosMecanicoTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblDocDisenosMecanico.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblDocDisenosMecanicoTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._matTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.Mat.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._matTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._mat2TableAdapter != null)
      {
        DataRow[] dataRows = dataSet.Mat2.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._mat2TableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._mat3TableAdapter != null)
      {
        DataRow[] dataRows = dataSet.Mat3.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._mat3TableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._matUrreaTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.MatUrrea.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._matUrreaTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._productosTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.Productos.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._productosTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblBoletinTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblBoletin.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblBoletinTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblCajaChicaTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblCajaChica.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblCajaChicaTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblCalendarioTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblCalendario.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblCalendarioTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblCategoriaTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblCategoria.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblCategoriaTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblChatTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblChat.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblChatTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblClienteContactoTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblClienteContacto.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblClienteContactoTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblClientesTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblClientes.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblClientesTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblComentariosCotizacionTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblComentariosCotizacion.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblComentariosCotizacionTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblComentariosProyectoTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblComentariosProyecto.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblComentariosProyectoTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblControlFacturasTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblControlFacturas.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblControlFacturasTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblCotizacionesTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblCotizaciones.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblCotizacionesTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblCotizacionesDetTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblCotizacionesDet.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblCotizacionesDetTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblCotizacionNewTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblCotizacionNew.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblCotizacionNewTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblDatosEmpresaTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblDatosEmpresa.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblDatosEmpresaTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblMaterialImagenTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblMaterialImagen.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblMaterialImagenTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblMenuTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblMenu.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblMenuTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._utilidadTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.Utilidad.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._utilidadTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblRequisicionTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblRequisicion.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblRequisicionTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblRFQDetTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblRFQDet.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblRFQDetTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblRfqSeguimientoTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblRfqSeguimiento.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblRfqSeguimientoTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblRfqVentasTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblRfqVentas.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblRfqVentasTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblRolesUsuariosTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblRolesUsuarios.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblRolesUsuariosTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblServicioComputoTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblServicioComputo.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblServicioComputoTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblServiciosComputoTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblServiciosComputo.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblServiciosComputoTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblSolicitudesAprobacionTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblSolicitudesAprobacion.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblSolicitudesAprobacionTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblSubMenuTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblSubMenu.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblSubMenuTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblSucursalesTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblSucursales.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblSucursalesTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblTeamProjectTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblTeamProject.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblTeamProjectTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblTimmingProyectoTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblTimmingProyecto.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblTimmingProyectoTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblUnidadMedidaTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblUnidadMedida.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblUnidadMedidaTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblUsuariosTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblUsuarios.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblUsuariosTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblUsuariosBKTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblUsuariosBK.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblUsuariosBKTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblVehiculosTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblVehiculos.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblVehiculosTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblVehiculoServicioTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblVehiculoServicio.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblVehiculoServicioTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblVehiculoServicioItemTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblVehiculoServicioItem.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblVehiculoServicioItemTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblViaticosTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblViaticos.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblViaticosTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblViaticosDetTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblViaticosDet.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblViaticosDetTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblRFQTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblRFQ.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblRFQTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblReqEncTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblReqEnc.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblReqEncTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblMonedasTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblMonedas.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblMonedasTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblReqDetTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblReqDet.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblReqDetTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblNotaAclaratoriaTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblNotaAclaratoria.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblNotaAclaratoriaTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblOrdenCompraTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblOrdenCompra.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblOrdenCompraTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblOrdenCompraComentariosTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblOrdenCompraComentarios.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblOrdenCompraComentariosTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblOrdenCompraDetTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblOrdenCompraDet.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblOrdenCompraDetTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblOrdenCompraInsumosTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblOrdenCompraInsumos.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblOrdenCompraInsumosTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblOrdenCompraNotaTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblOrdenCompraNota.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblOrdenCompraNotaTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblOrdenTrabajoTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblOrdenTrabajo.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblOrdenTrabajoTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblPermisosTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblPermisos.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblPermisosTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblProveedoresTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblProveedores.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblProveedoresTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblProveedoresContactosTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblProveedoresContactos.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblProveedoresContactosTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblProveedorMaterialTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblProveedorMaterial.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblProveedorMaterialTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblProyectoRequerimientoTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblProyectoRequerimiento.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblProyectoRequerimientoTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblProyectosTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblProyectos.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblProyectosTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblProyectosBKTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblProyectosBK.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblProyectosBKTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblProyectoTaskImagenTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblProyectoTaskImagen.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblProyectoTaskImagenTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblProyectoTasksTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblProyectoTasks.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblProyectoTasksTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblProyectoTasksBKTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblProyectoTasksBK.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblProyectoTasksBKTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblProyectoTasksComentariosTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblProyectoTasksComentarios.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblProyectoTasksComentariosTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblRecuperacionesTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblRecuperaciones.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblRecuperacionesTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._dateDimensionTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.DateDimension.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._dateDimensionTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      return num;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private DataRow[] GetRealUpdatedRows(DataRow[] updatedRows, List<DataRow> allAddedRows)
    {
      if (updatedRows == null || updatedRows.Length < 1 || allAddedRows == null || allAddedRows.Count < 1)
        return updatedRows;
      List<DataRow> dataRowList = new List<DataRow>();
      for (int index = 0; index < updatedRows.Length; ++index)
      {
        DataRow updatedRow = updatedRows[index];
        if (!allAddedRows.Contains(updatedRow))
          dataRowList.Add(updatedRow);
      }
      return dataRowList.ToArray();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public virtual int UpdateAll(SisaDevFacturas dataSet)
    {
      if (dataSet == null)
        throw new ArgumentNullException(nameof (dataSet));
      if (!dataSet.HasChanges())
        return 0;
      if (this._dateDimensionTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._dateDimensionTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._matTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._matTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._mat2TableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._mat2TableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._mat3TableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._mat3TableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._matUrreaTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._matUrreaTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._productosTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._productosTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblBoletinTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblBoletinTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblCajaChicaTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblCajaChicaTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblCalendarioTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblCalendarioTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblCategoriaTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblCategoriaTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblChatTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblChatTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblClienteContactoTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblClienteContactoTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblClientesTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblClientesTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblComentariosCotizacionTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblComentariosCotizacionTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblComentariosProyectoTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblComentariosProyectoTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblControlFacturasTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblControlFacturasTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblCotizacionesTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblCotizacionesTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblCotizacionesDetTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblCotizacionesDetTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblCotizacionNewTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblCotizacionNewTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblDatosEmpresaTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblDatosEmpresaTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblDocDisenosMecanicoTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblDocDisenosMecanicoTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblDocMasterCamMecanicoTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblDocMasterCamMecanicoTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblDocProyectosTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblDocProyectosTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblEficienciasTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblEficienciasTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblEmpresasTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblEmpresasTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblFacturasEmitidasTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblFacturasEmitidasTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblFacturasXMLTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblFacturasXMLTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblFallasTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblFallasTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblFolioCotizacionTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblFolioCotizacionTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblFolioOrdenCompraTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblFolioOrdenCompraTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblFolioReqTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblFolioReqTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblFolioRFQTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblFolioRFQTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblGastosTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblGastosTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblGPSTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblGPSTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblHabilidadesTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblHabilidadesTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblHorasHombreTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblHorasHombreTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblInventarioTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblInventarioTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblInventarioDetTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblInventarioDetTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblInvHerramientasTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblInvHerramientasTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblInvHerramientasDetTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblInvHerramientasDetTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblLiderProyectoTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblLiderProyectoTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblListaPendientesTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblListaPendientesTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblMaterialesTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblMaterialesTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblMaterialImagenTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblMaterialImagenTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblMatrizMecanicoTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblMatrizMecanicoTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblMenuTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblMenuTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblMonedasTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblMonedasTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblNotaAclaratoriaTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblNotaAclaratoriaTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblOrdenCompraTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblOrdenCompraTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblOrdenCompraComentariosTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblOrdenCompraComentariosTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblOrdenCompraDetTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblOrdenCompraDetTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblOrdenCompraInsumosTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblOrdenCompraInsumosTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblOrdenCompraNotaTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblOrdenCompraNotaTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblOrdenTrabajoTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblOrdenTrabajoTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblPermisosTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblPermisosTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblProveedoresTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblProveedoresTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblProveedoresContactosTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblProveedoresContactosTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblProveedorMaterialTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblProveedorMaterialTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblProyectoRequerimientoTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblProyectoRequerimientoTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblProyectosTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblProyectosTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblProyectosBKTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblProyectosBKTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblProyectoTaskImagenTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblProyectoTaskImagenTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblProyectoTasksTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblProyectoTasksTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblProyectoTasksBKTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblProyectoTasksBKTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblProyectoTasksComentariosTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblProyectoTasksComentariosTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblRecuperacionesTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblRecuperacionesTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblReqDetTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblReqDetTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblReqEncTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblReqEncTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblRequisicionTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblRequisicionTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblRFQTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblRFQTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblRFQDetTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblRFQDetTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblRfqSeguimientoTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblRfqSeguimientoTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblRfqVentasTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblRfqVentasTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblRolesUsuariosTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblRolesUsuariosTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblServicioComputoTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblServicioComputoTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblServiciosComputoTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblServiciosComputoTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblSolicitudesAprobacionTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblSolicitudesAprobacionTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblSubMenuTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblSubMenuTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblSucursalesTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblSucursalesTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblTeamProjectTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblTeamProjectTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblTimmingProyectoTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblTimmingProyectoTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblUnidadMedidaTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblUnidadMedidaTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblUsuariosTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblUsuariosTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblUsuariosBKTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblUsuariosBKTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblVehiculosTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblVehiculosTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblVehiculoServicioTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblVehiculoServicioTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblVehiculoServicioItemTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblVehiculoServicioItemTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblViaticosTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblViaticosTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblViaticosDetTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblViaticosDetTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._utilidadTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._utilidadTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._utilidadPastelTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._utilidadPastelTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      IDbConnection connection = this.Connection;
      if (connection == null)
        throw new ApplicationException("TableAdapterManager no contiene información de conexión. Establezca cada propiedad TableAdapterManager TableAdapter en una instancia TableAdapter válida.");
      bool flag = false;
      if ((connection.State & ConnectionState.Broken) == ConnectionState.Broken)
        connection.Close();
      if (connection.State == ConnectionState.Closed)
      {
        connection.Open();
        flag = true;
      }
      IDbTransaction dbTransaction = connection.BeginTransaction();
      if (dbTransaction == null)
        throw new ApplicationException("La transacción no puede comenzar. La conexión de datos actual no es compatible con las transacciones o el estado actual no permite que comience la transacción.");
      List<DataRow> allChangedRows = new List<DataRow>();
      List<DataRow> allAddedRows = new List<DataRow>();
      List<DataAdapter> dataAdapterList = new List<DataAdapter>();
      Dictionary<object, IDbConnection> dictionary = new Dictionary<object, IDbConnection>();
      int num = 0;
      DataSet dataSet1 = (DataSet) null;
      if (this.BackupDataSetBeforeUpdate)
      {
        dataSet1 = new DataSet();
        dataSet1.Merge((DataSet) dataSet);
      }
      try
      {
        if (this._dateDimensionTableAdapter != null)
        {
          dictionary.Add((object) this._dateDimensionTableAdapter, (IDbConnection) this._dateDimensionTableAdapter.Connection);
          this._dateDimensionTableAdapter.Connection = (SqlConnection) connection;
          this._dateDimensionTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._dateDimensionTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._dateDimensionTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._dateDimensionTableAdapter.Adapter);
          }
        }
        if (this._matTableAdapter != null)
        {
          dictionary.Add((object) this._matTableAdapter, (IDbConnection) this._matTableAdapter.Connection);
          this._matTableAdapter.Connection = (SqlConnection) connection;
          this._matTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._matTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._matTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._matTableAdapter.Adapter);
          }
        }
        if (this._mat2TableAdapter != null)
        {
          dictionary.Add((object) this._mat2TableAdapter, (IDbConnection) this._mat2TableAdapter.Connection);
          this._mat2TableAdapter.Connection = (SqlConnection) connection;
          this._mat2TableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._mat2TableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._mat2TableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._mat2TableAdapter.Adapter);
          }
        }
        if (this._mat3TableAdapter != null)
        {
          dictionary.Add((object) this._mat3TableAdapter, (IDbConnection) this._mat3TableAdapter.Connection);
          this._mat3TableAdapter.Connection = (SqlConnection) connection;
          this._mat3TableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._mat3TableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._mat3TableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._mat3TableAdapter.Adapter);
          }
        }
        if (this._matUrreaTableAdapter != null)
        {
          dictionary.Add((object) this._matUrreaTableAdapter, (IDbConnection) this._matUrreaTableAdapter.Connection);
          this._matUrreaTableAdapter.Connection = (SqlConnection) connection;
          this._matUrreaTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._matUrreaTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._matUrreaTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._matUrreaTableAdapter.Adapter);
          }
        }
        if (this._productosTableAdapter != null)
        {
          dictionary.Add((object) this._productosTableAdapter, (IDbConnection) this._productosTableAdapter.Connection);
          this._productosTableAdapter.Connection = (SqlConnection) connection;
          this._productosTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._productosTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._productosTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._productosTableAdapter.Adapter);
          }
        }
        if (this._tblBoletinTableAdapter != null)
        {
          dictionary.Add((object) this._tblBoletinTableAdapter, (IDbConnection) this._tblBoletinTableAdapter.Connection);
          this._tblBoletinTableAdapter.Connection = (SqlConnection) connection;
          this._tblBoletinTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblBoletinTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblBoletinTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblBoletinTableAdapter.Adapter);
          }
        }
        if (this._tblCajaChicaTableAdapter != null)
        {
          dictionary.Add((object) this._tblCajaChicaTableAdapter, (IDbConnection) this._tblCajaChicaTableAdapter.Connection);
          this._tblCajaChicaTableAdapter.Connection = (SqlConnection) connection;
          this._tblCajaChicaTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblCajaChicaTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblCajaChicaTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblCajaChicaTableAdapter.Adapter);
          }
        }
        if (this._tblCalendarioTableAdapter != null)
        {
          dictionary.Add((object) this._tblCalendarioTableAdapter, (IDbConnection) this._tblCalendarioTableAdapter.Connection);
          this._tblCalendarioTableAdapter.Connection = (SqlConnection) connection;
          this._tblCalendarioTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblCalendarioTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblCalendarioTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblCalendarioTableAdapter.Adapter);
          }
        }
        if (this._tblCategoriaTableAdapter != null)
        {
          dictionary.Add((object) this._tblCategoriaTableAdapter, (IDbConnection) this._tblCategoriaTableAdapter.Connection);
          this._tblCategoriaTableAdapter.Connection = (SqlConnection) connection;
          this._tblCategoriaTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblCategoriaTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblCategoriaTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblCategoriaTableAdapter.Adapter);
          }
        }
        if (this._tblChatTableAdapter != null)
        {
          dictionary.Add((object) this._tblChatTableAdapter, (IDbConnection) this._tblChatTableAdapter.Connection);
          this._tblChatTableAdapter.Connection = (SqlConnection) connection;
          this._tblChatTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblChatTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblChatTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblChatTableAdapter.Adapter);
          }
        }
        if (this._tblClienteContactoTableAdapter != null)
        {
          dictionary.Add((object) this._tblClienteContactoTableAdapter, (IDbConnection) this._tblClienteContactoTableAdapter.Connection);
          this._tblClienteContactoTableAdapter.Connection = (SqlConnection) connection;
          this._tblClienteContactoTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblClienteContactoTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblClienteContactoTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblClienteContactoTableAdapter.Adapter);
          }
        }
        if (this._tblClientesTableAdapter != null)
        {
          dictionary.Add((object) this._tblClientesTableAdapter, (IDbConnection) this._tblClientesTableAdapter.Connection);
          this._tblClientesTableAdapter.Connection = (SqlConnection) connection;
          this._tblClientesTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblClientesTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblClientesTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblClientesTableAdapter.Adapter);
          }
        }
        if (this._tblComentariosCotizacionTableAdapter != null)
        {
          dictionary.Add((object) this._tblComentariosCotizacionTableAdapter, (IDbConnection) this._tblComentariosCotizacionTableAdapter.Connection);
          this._tblComentariosCotizacionTableAdapter.Connection = (SqlConnection) connection;
          this._tblComentariosCotizacionTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblComentariosCotizacionTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblComentariosCotizacionTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblComentariosCotizacionTableAdapter.Adapter);
          }
        }
        if (this._tblComentariosProyectoTableAdapter != null)
        {
          dictionary.Add((object) this._tblComentariosProyectoTableAdapter, (IDbConnection) this._tblComentariosProyectoTableAdapter.Connection);
          this._tblComentariosProyectoTableAdapter.Connection = (SqlConnection) connection;
          this._tblComentariosProyectoTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblComentariosProyectoTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblComentariosProyectoTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblComentariosProyectoTableAdapter.Adapter);
          }
        }
        if (this._tblControlFacturasTableAdapter != null)
        {
          dictionary.Add((object) this._tblControlFacturasTableAdapter, (IDbConnection) this._tblControlFacturasTableAdapter.Connection);
          this._tblControlFacturasTableAdapter.Connection = (SqlConnection) connection;
          this._tblControlFacturasTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblControlFacturasTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblControlFacturasTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblControlFacturasTableAdapter.Adapter);
          }
        }
        if (this._tblCotizacionesTableAdapter != null)
        {
          dictionary.Add((object) this._tblCotizacionesTableAdapter, (IDbConnection) this._tblCotizacionesTableAdapter.Connection);
          this._tblCotizacionesTableAdapter.Connection = (SqlConnection) connection;
          this._tblCotizacionesTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblCotizacionesTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblCotizacionesTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblCotizacionesTableAdapter.Adapter);
          }
        }
        if (this._tblCotizacionesDetTableAdapter != null)
        {
          dictionary.Add((object) this._tblCotizacionesDetTableAdapter, (IDbConnection) this._tblCotizacionesDetTableAdapter.Connection);
          this._tblCotizacionesDetTableAdapter.Connection = (SqlConnection) connection;
          this._tblCotizacionesDetTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblCotizacionesDetTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblCotizacionesDetTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblCotizacionesDetTableAdapter.Adapter);
          }
        }
        if (this._tblCotizacionNewTableAdapter != null)
        {
          dictionary.Add((object) this._tblCotizacionNewTableAdapter, (IDbConnection) this._tblCotizacionNewTableAdapter.Connection);
          this._tblCotizacionNewTableAdapter.Connection = (SqlConnection) connection;
          this._tblCotizacionNewTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblCotizacionNewTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblCotizacionNewTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblCotizacionNewTableAdapter.Adapter);
          }
        }
        if (this._tblDatosEmpresaTableAdapter != null)
        {
          dictionary.Add((object) this._tblDatosEmpresaTableAdapter, (IDbConnection) this._tblDatosEmpresaTableAdapter.Connection);
          this._tblDatosEmpresaTableAdapter.Connection = (SqlConnection) connection;
          this._tblDatosEmpresaTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblDatosEmpresaTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblDatosEmpresaTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblDatosEmpresaTableAdapter.Adapter);
          }
        }
        if (this._tblDocDisenosMecanicoTableAdapter != null)
        {
          dictionary.Add((object) this._tblDocDisenosMecanicoTableAdapter, (IDbConnection) this._tblDocDisenosMecanicoTableAdapter.Connection);
          this._tblDocDisenosMecanicoTableAdapter.Connection = (SqlConnection) connection;
          this._tblDocDisenosMecanicoTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblDocDisenosMecanicoTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblDocDisenosMecanicoTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblDocDisenosMecanicoTableAdapter.Adapter);
          }
        }
        if (this._tblDocMasterCamMecanicoTableAdapter != null)
        {
          dictionary.Add((object) this._tblDocMasterCamMecanicoTableAdapter, (IDbConnection) this._tblDocMasterCamMecanicoTableAdapter.Connection);
          this._tblDocMasterCamMecanicoTableAdapter.Connection = (SqlConnection) connection;
          this._tblDocMasterCamMecanicoTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblDocMasterCamMecanicoTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblDocMasterCamMecanicoTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblDocMasterCamMecanicoTableAdapter.Adapter);
          }
        }
        if (this._tblDocProyectosTableAdapter != null)
        {
          dictionary.Add((object) this._tblDocProyectosTableAdapter, (IDbConnection) this._tblDocProyectosTableAdapter.Connection);
          this._tblDocProyectosTableAdapter.Connection = (SqlConnection) connection;
          this._tblDocProyectosTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblDocProyectosTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblDocProyectosTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblDocProyectosTableAdapter.Adapter);
          }
        }
        if (this._tblEficienciasTableAdapter != null)
        {
          dictionary.Add((object) this._tblEficienciasTableAdapter, (IDbConnection) this._tblEficienciasTableAdapter.Connection);
          this._tblEficienciasTableAdapter.Connection = (SqlConnection) connection;
          this._tblEficienciasTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblEficienciasTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblEficienciasTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblEficienciasTableAdapter.Adapter);
          }
        }
        if (this._tblEmpresasTableAdapter != null)
        {
          dictionary.Add((object) this._tblEmpresasTableAdapter, (IDbConnection) this._tblEmpresasTableAdapter.Connection);
          this._tblEmpresasTableAdapter.Connection = (SqlConnection) connection;
          this._tblEmpresasTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblEmpresasTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblEmpresasTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblEmpresasTableAdapter.Adapter);
          }
        }
        if (this._tblFacturasEmitidasTableAdapter != null)
        {
          dictionary.Add((object) this._tblFacturasEmitidasTableAdapter, (IDbConnection) this._tblFacturasEmitidasTableAdapter.Connection);
          this._tblFacturasEmitidasTableAdapter.Connection = (SqlConnection) connection;
          this._tblFacturasEmitidasTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblFacturasEmitidasTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblFacturasEmitidasTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblFacturasEmitidasTableAdapter.Adapter);
          }
        }
        if (this._tblFacturasXMLTableAdapter != null)
        {
          dictionary.Add((object) this._tblFacturasXMLTableAdapter, (IDbConnection) this._tblFacturasXMLTableAdapter.Connection);
          this._tblFacturasXMLTableAdapter.Connection = (SqlConnection) connection;
          this._tblFacturasXMLTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblFacturasXMLTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblFacturasXMLTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblFacturasXMLTableAdapter.Adapter);
          }
        }
        if (this._tblFallasTableAdapter != null)
        {
          dictionary.Add((object) this._tblFallasTableAdapter, (IDbConnection) this._tblFallasTableAdapter.Connection);
          this._tblFallasTableAdapter.Connection = (SqlConnection) connection;
          this._tblFallasTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblFallasTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblFallasTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblFallasTableAdapter.Adapter);
          }
        }
        if (this._tblFolioCotizacionTableAdapter != null)
        {
          dictionary.Add((object) this._tblFolioCotizacionTableAdapter, (IDbConnection) this._tblFolioCotizacionTableAdapter.Connection);
          this._tblFolioCotizacionTableAdapter.Connection = (SqlConnection) connection;
          this._tblFolioCotizacionTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblFolioCotizacionTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblFolioCotizacionTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblFolioCotizacionTableAdapter.Adapter);
          }
        }
        if (this._tblFolioOrdenCompraTableAdapter != null)
        {
          dictionary.Add((object) this._tblFolioOrdenCompraTableAdapter, (IDbConnection) this._tblFolioOrdenCompraTableAdapter.Connection);
          this._tblFolioOrdenCompraTableAdapter.Connection = (SqlConnection) connection;
          this._tblFolioOrdenCompraTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblFolioOrdenCompraTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblFolioOrdenCompraTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblFolioOrdenCompraTableAdapter.Adapter);
          }
        }
        if (this._tblFolioReqTableAdapter != null)
        {
          dictionary.Add((object) this._tblFolioReqTableAdapter, (IDbConnection) this._tblFolioReqTableAdapter.Connection);
          this._tblFolioReqTableAdapter.Connection = (SqlConnection) connection;
          this._tblFolioReqTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblFolioReqTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblFolioReqTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblFolioReqTableAdapter.Adapter);
          }
        }
        if (this._tblFolioRFQTableAdapter != null)
        {
          dictionary.Add((object) this._tblFolioRFQTableAdapter, (IDbConnection) this._tblFolioRFQTableAdapter.Connection);
          this._tblFolioRFQTableAdapter.Connection = (SqlConnection) connection;
          this._tblFolioRFQTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblFolioRFQTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblFolioRFQTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblFolioRFQTableAdapter.Adapter);
          }
        }
        if (this._tblGastosTableAdapter != null)
        {
          dictionary.Add((object) this._tblGastosTableAdapter, (IDbConnection) this._tblGastosTableAdapter.Connection);
          this._tblGastosTableAdapter.Connection = (SqlConnection) connection;
          this._tblGastosTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblGastosTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblGastosTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblGastosTableAdapter.Adapter);
          }
        }
        if (this._tblGPSTableAdapter != null)
        {
          dictionary.Add((object) this._tblGPSTableAdapter, (IDbConnection) this._tblGPSTableAdapter.Connection);
          this._tblGPSTableAdapter.Connection = (SqlConnection) connection;
          this._tblGPSTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblGPSTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblGPSTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblGPSTableAdapter.Adapter);
          }
        }
        if (this._tblHabilidadesTableAdapter != null)
        {
          dictionary.Add((object) this._tblHabilidadesTableAdapter, (IDbConnection) this._tblHabilidadesTableAdapter.Connection);
          this._tblHabilidadesTableAdapter.Connection = (SqlConnection) connection;
          this._tblHabilidadesTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblHabilidadesTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblHabilidadesTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblHabilidadesTableAdapter.Adapter);
          }
        }
        if (this._tblHorasHombreTableAdapter != null)
        {
          dictionary.Add((object) this._tblHorasHombreTableAdapter, (IDbConnection) this._tblHorasHombreTableAdapter.Connection);
          this._tblHorasHombreTableAdapter.Connection = (SqlConnection) connection;
          this._tblHorasHombreTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblHorasHombreTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblHorasHombreTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblHorasHombreTableAdapter.Adapter);
          }
        }
        if (this._tblInventarioTableAdapter != null)
        {
          dictionary.Add((object) this._tblInventarioTableAdapter, (IDbConnection) this._tblInventarioTableAdapter.Connection);
          this._tblInventarioTableAdapter.Connection = (SqlConnection) connection;
          this._tblInventarioTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblInventarioTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblInventarioTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblInventarioTableAdapter.Adapter);
          }
        }
        if (this._tblInventarioDetTableAdapter != null)
        {
          dictionary.Add((object) this._tblInventarioDetTableAdapter, (IDbConnection) this._tblInventarioDetTableAdapter.Connection);
          this._tblInventarioDetTableAdapter.Connection = (SqlConnection) connection;
          this._tblInventarioDetTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblInventarioDetTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblInventarioDetTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblInventarioDetTableAdapter.Adapter);
          }
        }
        if (this._tblInvHerramientasTableAdapter != null)
        {
          dictionary.Add((object) this._tblInvHerramientasTableAdapter, (IDbConnection) this._tblInvHerramientasTableAdapter.Connection);
          this._tblInvHerramientasTableAdapter.Connection = (SqlConnection) connection;
          this._tblInvHerramientasTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblInvHerramientasTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblInvHerramientasTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblInvHerramientasTableAdapter.Adapter);
          }
        }
        if (this._tblInvHerramientasDetTableAdapter != null)
        {
          dictionary.Add((object) this._tblInvHerramientasDetTableAdapter, (IDbConnection) this._tblInvHerramientasDetTableAdapter.Connection);
          this._tblInvHerramientasDetTableAdapter.Connection = (SqlConnection) connection;
          this._tblInvHerramientasDetTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblInvHerramientasDetTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblInvHerramientasDetTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblInvHerramientasDetTableAdapter.Adapter);
          }
        }
        if (this._tblLiderProyectoTableAdapter != null)
        {
          dictionary.Add((object) this._tblLiderProyectoTableAdapter, (IDbConnection) this._tblLiderProyectoTableAdapter.Connection);
          this._tblLiderProyectoTableAdapter.Connection = (SqlConnection) connection;
          this._tblLiderProyectoTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblLiderProyectoTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblLiderProyectoTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblLiderProyectoTableAdapter.Adapter);
          }
        }
        if (this._tblListaPendientesTableAdapter != null)
        {
          dictionary.Add((object) this._tblListaPendientesTableAdapter, (IDbConnection) this._tblListaPendientesTableAdapter.Connection);
          this._tblListaPendientesTableAdapter.Connection = (SqlConnection) connection;
          this._tblListaPendientesTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblListaPendientesTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblListaPendientesTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblListaPendientesTableAdapter.Adapter);
          }
        }
        if (this._tblMaterialesTableAdapter != null)
        {
          dictionary.Add((object) this._tblMaterialesTableAdapter, (IDbConnection) this._tblMaterialesTableAdapter.Connection);
          this._tblMaterialesTableAdapter.Connection = (SqlConnection) connection;
          this._tblMaterialesTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblMaterialesTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblMaterialesTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblMaterialesTableAdapter.Adapter);
          }
        }
        if (this._tblMaterialImagenTableAdapter != null)
        {
          dictionary.Add((object) this._tblMaterialImagenTableAdapter, (IDbConnection) this._tblMaterialImagenTableAdapter.Connection);
          this._tblMaterialImagenTableAdapter.Connection = (SqlConnection) connection;
          this._tblMaterialImagenTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblMaterialImagenTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblMaterialImagenTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblMaterialImagenTableAdapter.Adapter);
          }
        }
        if (this._tblMatrizMecanicoTableAdapter != null)
        {
          dictionary.Add((object) this._tblMatrizMecanicoTableAdapter, (IDbConnection) this._tblMatrizMecanicoTableAdapter.Connection);
          this._tblMatrizMecanicoTableAdapter.Connection = (SqlConnection) connection;
          this._tblMatrizMecanicoTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblMatrizMecanicoTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblMatrizMecanicoTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblMatrizMecanicoTableAdapter.Adapter);
          }
        }
        if (this._tblMenuTableAdapter != null)
        {
          dictionary.Add((object) this._tblMenuTableAdapter, (IDbConnection) this._tblMenuTableAdapter.Connection);
          this._tblMenuTableAdapter.Connection = (SqlConnection) connection;
          this._tblMenuTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblMenuTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblMenuTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblMenuTableAdapter.Adapter);
          }
        }
        if (this._tblMonedasTableAdapter != null)
        {
          dictionary.Add((object) this._tblMonedasTableAdapter, (IDbConnection) this._tblMonedasTableAdapter.Connection);
          this._tblMonedasTableAdapter.Connection = (SqlConnection) connection;
          this._tblMonedasTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblMonedasTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblMonedasTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblMonedasTableAdapter.Adapter);
          }
        }
        if (this._tblNotaAclaratoriaTableAdapter != null)
        {
          dictionary.Add((object) this._tblNotaAclaratoriaTableAdapter, (IDbConnection) this._tblNotaAclaratoriaTableAdapter.Connection);
          this._tblNotaAclaratoriaTableAdapter.Connection = (SqlConnection) connection;
          this._tblNotaAclaratoriaTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblNotaAclaratoriaTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblNotaAclaratoriaTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblNotaAclaratoriaTableAdapter.Adapter);
          }
        }
        if (this._tblOrdenCompraTableAdapter != null)
        {
          dictionary.Add((object) this._tblOrdenCompraTableAdapter, (IDbConnection) this._tblOrdenCompraTableAdapter.Connection);
          this._tblOrdenCompraTableAdapter.Connection = (SqlConnection) connection;
          this._tblOrdenCompraTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblOrdenCompraTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblOrdenCompraTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblOrdenCompraTableAdapter.Adapter);
          }
        }
        if (this._tblOrdenCompraComentariosTableAdapter != null)
        {
          dictionary.Add((object) this._tblOrdenCompraComentariosTableAdapter, (IDbConnection) this._tblOrdenCompraComentariosTableAdapter.Connection);
          this._tblOrdenCompraComentariosTableAdapter.Connection = (SqlConnection) connection;
          this._tblOrdenCompraComentariosTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblOrdenCompraComentariosTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblOrdenCompraComentariosTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblOrdenCompraComentariosTableAdapter.Adapter);
          }
        }
        if (this._tblOrdenCompraDetTableAdapter != null)
        {
          dictionary.Add((object) this._tblOrdenCompraDetTableAdapter, (IDbConnection) this._tblOrdenCompraDetTableAdapter.Connection);
          this._tblOrdenCompraDetTableAdapter.Connection = (SqlConnection) connection;
          this._tblOrdenCompraDetTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblOrdenCompraDetTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblOrdenCompraDetTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblOrdenCompraDetTableAdapter.Adapter);
          }
        }
        if (this._tblOrdenCompraInsumosTableAdapter != null)
        {
          dictionary.Add((object) this._tblOrdenCompraInsumosTableAdapter, (IDbConnection) this._tblOrdenCompraInsumosTableAdapter.Connection);
          this._tblOrdenCompraInsumosTableAdapter.Connection = (SqlConnection) connection;
          this._tblOrdenCompraInsumosTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblOrdenCompraInsumosTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblOrdenCompraInsumosTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblOrdenCompraInsumosTableAdapter.Adapter);
          }
        }
        if (this._tblOrdenCompraNotaTableAdapter != null)
        {
          dictionary.Add((object) this._tblOrdenCompraNotaTableAdapter, (IDbConnection) this._tblOrdenCompraNotaTableAdapter.Connection);
          this._tblOrdenCompraNotaTableAdapter.Connection = (SqlConnection) connection;
          this._tblOrdenCompraNotaTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblOrdenCompraNotaTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblOrdenCompraNotaTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblOrdenCompraNotaTableAdapter.Adapter);
          }
        }
        if (this._tblOrdenTrabajoTableAdapter != null)
        {
          dictionary.Add((object) this._tblOrdenTrabajoTableAdapter, (IDbConnection) this._tblOrdenTrabajoTableAdapter.Connection);
          this._tblOrdenTrabajoTableAdapter.Connection = (SqlConnection) connection;
          this._tblOrdenTrabajoTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblOrdenTrabajoTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblOrdenTrabajoTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblOrdenTrabajoTableAdapter.Adapter);
          }
        }
        if (this._tblPermisosTableAdapter != null)
        {
          dictionary.Add((object) this._tblPermisosTableAdapter, (IDbConnection) this._tblPermisosTableAdapter.Connection);
          this._tblPermisosTableAdapter.Connection = (SqlConnection) connection;
          this._tblPermisosTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblPermisosTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblPermisosTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblPermisosTableAdapter.Adapter);
          }
        }
        if (this._tblProveedoresTableAdapter != null)
        {
          dictionary.Add((object) this._tblProveedoresTableAdapter, (IDbConnection) this._tblProveedoresTableAdapter.Connection);
          this._tblProveedoresTableAdapter.Connection = (SqlConnection) connection;
          this._tblProveedoresTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblProveedoresTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblProveedoresTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblProveedoresTableAdapter.Adapter);
          }
        }
        if (this._tblProveedoresContactosTableAdapter != null)
        {
          dictionary.Add((object) this._tblProveedoresContactosTableAdapter, (IDbConnection) this._tblProveedoresContactosTableAdapter.Connection);
          this._tblProveedoresContactosTableAdapter.Connection = (SqlConnection) connection;
          this._tblProveedoresContactosTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblProveedoresContactosTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblProveedoresContactosTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblProveedoresContactosTableAdapter.Adapter);
          }
        }
        if (this._tblProveedorMaterialTableAdapter != null)
        {
          dictionary.Add((object) this._tblProveedorMaterialTableAdapter, (IDbConnection) this._tblProveedorMaterialTableAdapter.Connection);
          this._tblProveedorMaterialTableAdapter.Connection = (SqlConnection) connection;
          this._tblProveedorMaterialTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblProveedorMaterialTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblProveedorMaterialTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblProveedorMaterialTableAdapter.Adapter);
          }
        }
        if (this._tblProyectoRequerimientoTableAdapter != null)
        {
          dictionary.Add((object) this._tblProyectoRequerimientoTableAdapter, (IDbConnection) this._tblProyectoRequerimientoTableAdapter.Connection);
          this._tblProyectoRequerimientoTableAdapter.Connection = (SqlConnection) connection;
          this._tblProyectoRequerimientoTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblProyectoRequerimientoTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblProyectoRequerimientoTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblProyectoRequerimientoTableAdapter.Adapter);
          }
        }
        if (this._tblProyectosTableAdapter != null)
        {
          dictionary.Add((object) this._tblProyectosTableAdapter, (IDbConnection) this._tblProyectosTableAdapter.Connection);
          this._tblProyectosTableAdapter.Connection = (SqlConnection) connection;
          this._tblProyectosTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblProyectosTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblProyectosTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblProyectosTableAdapter.Adapter);
          }
        }
        if (this._tblProyectosBKTableAdapter != null)
        {
          dictionary.Add((object) this._tblProyectosBKTableAdapter, (IDbConnection) this._tblProyectosBKTableAdapter.Connection);
          this._tblProyectosBKTableAdapter.Connection = (SqlConnection) connection;
          this._tblProyectosBKTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblProyectosBKTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblProyectosBKTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblProyectosBKTableAdapter.Adapter);
          }
        }
        if (this._tblProyectoTaskImagenTableAdapter != null)
        {
          dictionary.Add((object) this._tblProyectoTaskImagenTableAdapter, (IDbConnection) this._tblProyectoTaskImagenTableAdapter.Connection);
          this._tblProyectoTaskImagenTableAdapter.Connection = (SqlConnection) connection;
          this._tblProyectoTaskImagenTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblProyectoTaskImagenTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblProyectoTaskImagenTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblProyectoTaskImagenTableAdapter.Adapter);
          }
        }
        if (this._tblProyectoTasksTableAdapter != null)
        {
          dictionary.Add((object) this._tblProyectoTasksTableAdapter, (IDbConnection) this._tblProyectoTasksTableAdapter.Connection);
          this._tblProyectoTasksTableAdapter.Connection = (SqlConnection) connection;
          this._tblProyectoTasksTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblProyectoTasksTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblProyectoTasksTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblProyectoTasksTableAdapter.Adapter);
          }
        }
        if (this._tblProyectoTasksBKTableAdapter != null)
        {
          dictionary.Add((object) this._tblProyectoTasksBKTableAdapter, (IDbConnection) this._tblProyectoTasksBKTableAdapter.Connection);
          this._tblProyectoTasksBKTableAdapter.Connection = (SqlConnection) connection;
          this._tblProyectoTasksBKTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblProyectoTasksBKTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblProyectoTasksBKTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblProyectoTasksBKTableAdapter.Adapter);
          }
        }
        if (this._tblProyectoTasksComentariosTableAdapter != null)
        {
          dictionary.Add((object) this._tblProyectoTasksComentariosTableAdapter, (IDbConnection) this._tblProyectoTasksComentariosTableAdapter.Connection);
          this._tblProyectoTasksComentariosTableAdapter.Connection = (SqlConnection) connection;
          this._tblProyectoTasksComentariosTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblProyectoTasksComentariosTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblProyectoTasksComentariosTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblProyectoTasksComentariosTableAdapter.Adapter);
          }
        }
        if (this._tblRecuperacionesTableAdapter != null)
        {
          dictionary.Add((object) this._tblRecuperacionesTableAdapter, (IDbConnection) this._tblRecuperacionesTableAdapter.Connection);
          this._tblRecuperacionesTableAdapter.Connection = (SqlConnection) connection;
          this._tblRecuperacionesTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblRecuperacionesTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblRecuperacionesTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblRecuperacionesTableAdapter.Adapter);
          }
        }
        if (this._tblReqDetTableAdapter != null)
        {
          dictionary.Add((object) this._tblReqDetTableAdapter, (IDbConnection) this._tblReqDetTableAdapter.Connection);
          this._tblReqDetTableAdapter.Connection = (SqlConnection) connection;
          this._tblReqDetTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblReqDetTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblReqDetTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblReqDetTableAdapter.Adapter);
          }
        }
        if (this._tblReqEncTableAdapter != null)
        {
          dictionary.Add((object) this._tblReqEncTableAdapter, (IDbConnection) this._tblReqEncTableAdapter.Connection);
          this._tblReqEncTableAdapter.Connection = (SqlConnection) connection;
          this._tblReqEncTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblReqEncTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblReqEncTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblReqEncTableAdapter.Adapter);
          }
        }
        if (this._tblRequisicionTableAdapter != null)
        {
          dictionary.Add((object) this._tblRequisicionTableAdapter, (IDbConnection) this._tblRequisicionTableAdapter.Connection);
          this._tblRequisicionTableAdapter.Connection = (SqlConnection) connection;
          this._tblRequisicionTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblRequisicionTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblRequisicionTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblRequisicionTableAdapter.Adapter);
          }
        }
        if (this._tblRFQTableAdapter != null)
        {
          dictionary.Add((object) this._tblRFQTableAdapter, (IDbConnection) this._tblRFQTableAdapter.Connection);
          this._tblRFQTableAdapter.Connection = (SqlConnection) connection;
          this._tblRFQTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblRFQTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblRFQTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblRFQTableAdapter.Adapter);
          }
        }
        if (this._tblRFQDetTableAdapter != null)
        {
          dictionary.Add((object) this._tblRFQDetTableAdapter, (IDbConnection) this._tblRFQDetTableAdapter.Connection);
          this._tblRFQDetTableAdapter.Connection = (SqlConnection) connection;
          this._tblRFQDetTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblRFQDetTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblRFQDetTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblRFQDetTableAdapter.Adapter);
          }
        }
        if (this._tblRfqSeguimientoTableAdapter != null)
        {
          dictionary.Add((object) this._tblRfqSeguimientoTableAdapter, (IDbConnection) this._tblRfqSeguimientoTableAdapter.Connection);
          this._tblRfqSeguimientoTableAdapter.Connection = (SqlConnection) connection;
          this._tblRfqSeguimientoTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblRfqSeguimientoTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblRfqSeguimientoTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblRfqSeguimientoTableAdapter.Adapter);
          }
        }
        if (this._tblRfqVentasTableAdapter != null)
        {
          dictionary.Add((object) this._tblRfqVentasTableAdapter, (IDbConnection) this._tblRfqVentasTableAdapter.Connection);
          this._tblRfqVentasTableAdapter.Connection = (SqlConnection) connection;
          this._tblRfqVentasTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblRfqVentasTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblRfqVentasTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblRfqVentasTableAdapter.Adapter);
          }
        }
        if (this._tblRolesUsuariosTableAdapter != null)
        {
          dictionary.Add((object) this._tblRolesUsuariosTableAdapter, (IDbConnection) this._tblRolesUsuariosTableAdapter.Connection);
          this._tblRolesUsuariosTableAdapter.Connection = (SqlConnection) connection;
          this._tblRolesUsuariosTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblRolesUsuariosTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblRolesUsuariosTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblRolesUsuariosTableAdapter.Adapter);
          }
        }
        if (this._tblServicioComputoTableAdapter != null)
        {
          dictionary.Add((object) this._tblServicioComputoTableAdapter, (IDbConnection) this._tblServicioComputoTableAdapter.Connection);
          this._tblServicioComputoTableAdapter.Connection = (SqlConnection) connection;
          this._tblServicioComputoTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblServicioComputoTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblServicioComputoTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblServicioComputoTableAdapter.Adapter);
          }
        }
        if (this._tblServiciosComputoTableAdapter != null)
        {
          dictionary.Add((object) this._tblServiciosComputoTableAdapter, (IDbConnection) this._tblServiciosComputoTableAdapter.Connection);
          this._tblServiciosComputoTableAdapter.Connection = (SqlConnection) connection;
          this._tblServiciosComputoTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblServiciosComputoTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblServiciosComputoTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblServiciosComputoTableAdapter.Adapter);
          }
        }
        if (this._tblSolicitudesAprobacionTableAdapter != null)
        {
          dictionary.Add((object) this._tblSolicitudesAprobacionTableAdapter, (IDbConnection) this._tblSolicitudesAprobacionTableAdapter.Connection);
          this._tblSolicitudesAprobacionTableAdapter.Connection = (SqlConnection) connection;
          this._tblSolicitudesAprobacionTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblSolicitudesAprobacionTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblSolicitudesAprobacionTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblSolicitudesAprobacionTableAdapter.Adapter);
          }
        }
        if (this._tblSubMenuTableAdapter != null)
        {
          dictionary.Add((object) this._tblSubMenuTableAdapter, (IDbConnection) this._tblSubMenuTableAdapter.Connection);
          this._tblSubMenuTableAdapter.Connection = (SqlConnection) connection;
          this._tblSubMenuTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblSubMenuTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblSubMenuTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblSubMenuTableAdapter.Adapter);
          }
        }
        if (this._tblSucursalesTableAdapter != null)
        {
          dictionary.Add((object) this._tblSucursalesTableAdapter, (IDbConnection) this._tblSucursalesTableAdapter.Connection);
          this._tblSucursalesTableAdapter.Connection = (SqlConnection) connection;
          this._tblSucursalesTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblSucursalesTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblSucursalesTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblSucursalesTableAdapter.Adapter);
          }
        }
        if (this._tblTeamProjectTableAdapter != null)
        {
          dictionary.Add((object) this._tblTeamProjectTableAdapter, (IDbConnection) this._tblTeamProjectTableAdapter.Connection);
          this._tblTeamProjectTableAdapter.Connection = (SqlConnection) connection;
          this._tblTeamProjectTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblTeamProjectTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblTeamProjectTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblTeamProjectTableAdapter.Adapter);
          }
        }
        if (this._tblTimmingProyectoTableAdapter != null)
        {
          dictionary.Add((object) this._tblTimmingProyectoTableAdapter, (IDbConnection) this._tblTimmingProyectoTableAdapter.Connection);
          this._tblTimmingProyectoTableAdapter.Connection = (SqlConnection) connection;
          this._tblTimmingProyectoTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblTimmingProyectoTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblTimmingProyectoTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblTimmingProyectoTableAdapter.Adapter);
          }
        }
        if (this._tblUnidadMedidaTableAdapter != null)
        {
          dictionary.Add((object) this._tblUnidadMedidaTableAdapter, (IDbConnection) this._tblUnidadMedidaTableAdapter.Connection);
          this._tblUnidadMedidaTableAdapter.Connection = (SqlConnection) connection;
          this._tblUnidadMedidaTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblUnidadMedidaTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblUnidadMedidaTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblUnidadMedidaTableAdapter.Adapter);
          }
        }
        if (this._tblUsuariosTableAdapter != null)
        {
          dictionary.Add((object) this._tblUsuariosTableAdapter, (IDbConnection) this._tblUsuariosTableAdapter.Connection);
          this._tblUsuariosTableAdapter.Connection = (SqlConnection) connection;
          this._tblUsuariosTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblUsuariosTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblUsuariosTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblUsuariosTableAdapter.Adapter);
          }
        }
        if (this._tblUsuariosBKTableAdapter != null)
        {
          dictionary.Add((object) this._tblUsuariosBKTableAdapter, (IDbConnection) this._tblUsuariosBKTableAdapter.Connection);
          this._tblUsuariosBKTableAdapter.Connection = (SqlConnection) connection;
          this._tblUsuariosBKTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblUsuariosBKTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblUsuariosBKTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblUsuariosBKTableAdapter.Adapter);
          }
        }
        if (this._tblVehiculosTableAdapter != null)
        {
          dictionary.Add((object) this._tblVehiculosTableAdapter, (IDbConnection) this._tblVehiculosTableAdapter.Connection);
          this._tblVehiculosTableAdapter.Connection = (SqlConnection) connection;
          this._tblVehiculosTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblVehiculosTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblVehiculosTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblVehiculosTableAdapter.Adapter);
          }
        }
        if (this._tblVehiculoServicioTableAdapter != null)
        {
          dictionary.Add((object) this._tblVehiculoServicioTableAdapter, (IDbConnection) this._tblVehiculoServicioTableAdapter.Connection);
          this._tblVehiculoServicioTableAdapter.Connection = (SqlConnection) connection;
          this._tblVehiculoServicioTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblVehiculoServicioTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblVehiculoServicioTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblVehiculoServicioTableAdapter.Adapter);
          }
        }
        if (this._tblVehiculoServicioItemTableAdapter != null)
        {
          dictionary.Add((object) this._tblVehiculoServicioItemTableAdapter, (IDbConnection) this._tblVehiculoServicioItemTableAdapter.Connection);
          this._tblVehiculoServicioItemTableAdapter.Connection = (SqlConnection) connection;
          this._tblVehiculoServicioItemTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblVehiculoServicioItemTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblVehiculoServicioItemTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblVehiculoServicioItemTableAdapter.Adapter);
          }
        }
        if (this._tblViaticosTableAdapter != null)
        {
          dictionary.Add((object) this._tblViaticosTableAdapter, (IDbConnection) this._tblViaticosTableAdapter.Connection);
          this._tblViaticosTableAdapter.Connection = (SqlConnection) connection;
          this._tblViaticosTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblViaticosTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblViaticosTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblViaticosTableAdapter.Adapter);
          }
        }
        if (this._tblViaticosDetTableAdapter != null)
        {
          dictionary.Add((object) this._tblViaticosDetTableAdapter, (IDbConnection) this._tblViaticosDetTableAdapter.Connection);
          this._tblViaticosDetTableAdapter.Connection = (SqlConnection) connection;
          this._tblViaticosDetTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblViaticosDetTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblViaticosDetTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblViaticosDetTableAdapter.Adapter);
          }
        }
        if (this._utilidadTableAdapter != null)
        {
          dictionary.Add((object) this._utilidadTableAdapter, (IDbConnection) this._utilidadTableAdapter.Connection);
          this._utilidadTableAdapter.Connection = (SqlConnection) connection;
          this._utilidadTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._utilidadTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._utilidadTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._utilidadTableAdapter.Adapter);
          }
        }
        if (this._utilidadPastelTableAdapter != null)
        {
          dictionary.Add((object) this._utilidadPastelTableAdapter, (IDbConnection) this._utilidadPastelTableAdapter.Connection);
          this._utilidadPastelTableAdapter.Connection = (SqlConnection) connection;
          this._utilidadPastelTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._utilidadPastelTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._utilidadPastelTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._utilidadPastelTableAdapter.Adapter);
          }
        }
        if (this.UpdateOrder == TableAdapterManager.UpdateOrderOption.UpdateInsertDelete)
        {
          num += this.UpdateUpdatedRows(dataSet, allChangedRows, allAddedRows);
          num += this.UpdateInsertedRows(dataSet, allAddedRows);
        }
        else
        {
          num += this.UpdateInsertedRows(dataSet, allAddedRows);
          num += this.UpdateUpdatedRows(dataSet, allChangedRows, allAddedRows);
        }
        num += this.UpdateDeletedRows(dataSet, allChangedRows);
        dbTransaction.Commit();
        if (0 < allAddedRows.Count)
        {
          DataRow[] array = new DataRow[allAddedRows.Count];
          allAddedRows.CopyTo(array);
          for (int index = 0; index < array.Length; ++index)
            array[index].AcceptChanges();
        }
        if (0 < allChangedRows.Count)
        {
          DataRow[] array = new DataRow[allChangedRows.Count];
          allChangedRows.CopyTo(array);
          for (int index = 0; index < array.Length; ++index)
            array[index].AcceptChanges();
        }
      }
      catch (Exception ex)
      {
        dbTransaction.Rollback();
        if (this.BackupDataSetBeforeUpdate)
        {
          dataSet.Clear();
          dataSet.Merge(dataSet1);
        }
        else if (0 < allAddedRows.Count)
        {
          DataRow[] array = new DataRow[allAddedRows.Count];
          allAddedRows.CopyTo(array);
          for (int index = 0; index < array.Length; ++index)
          {
            DataRow dataRow = array[index];
            dataRow.AcceptChanges();
            dataRow.SetAdded();
          }
        }
        throw ex;
      }
      finally
      {
        if (flag)
          connection.Close();
        if (this._dateDimensionTableAdapter != null)
        {
          this._dateDimensionTableAdapter.Connection = (SqlConnection) dictionary[(object) this._dateDimensionTableAdapter];
          this._dateDimensionTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._matTableAdapter != null)
        {
          this._matTableAdapter.Connection = (SqlConnection) dictionary[(object) this._matTableAdapter];
          this._matTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._mat2TableAdapter != null)
        {
          this._mat2TableAdapter.Connection = (SqlConnection) dictionary[(object) this._mat2TableAdapter];
          this._mat2TableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._mat3TableAdapter != null)
        {
          this._mat3TableAdapter.Connection = (SqlConnection) dictionary[(object) this._mat3TableAdapter];
          this._mat3TableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._matUrreaTableAdapter != null)
        {
          this._matUrreaTableAdapter.Connection = (SqlConnection) dictionary[(object) this._matUrreaTableAdapter];
          this._matUrreaTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._productosTableAdapter != null)
        {
          this._productosTableAdapter.Connection = (SqlConnection) dictionary[(object) this._productosTableAdapter];
          this._productosTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblBoletinTableAdapter != null)
        {
          this._tblBoletinTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblBoletinTableAdapter];
          this._tblBoletinTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblCajaChicaTableAdapter != null)
        {
          this._tblCajaChicaTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblCajaChicaTableAdapter];
          this._tblCajaChicaTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblCalendarioTableAdapter != null)
        {
          this._tblCalendarioTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblCalendarioTableAdapter];
          this._tblCalendarioTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblCategoriaTableAdapter != null)
        {
          this._tblCategoriaTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblCategoriaTableAdapter];
          this._tblCategoriaTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblChatTableAdapter != null)
        {
          this._tblChatTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblChatTableAdapter];
          this._tblChatTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblClienteContactoTableAdapter != null)
        {
          this._tblClienteContactoTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblClienteContactoTableAdapter];
          this._tblClienteContactoTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblClientesTableAdapter != null)
        {
          this._tblClientesTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblClientesTableAdapter];
          this._tblClientesTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblComentariosCotizacionTableAdapter != null)
        {
          this._tblComentariosCotizacionTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblComentariosCotizacionTableAdapter];
          this._tblComentariosCotizacionTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblComentariosProyectoTableAdapter != null)
        {
          this._tblComentariosProyectoTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblComentariosProyectoTableAdapter];
          this._tblComentariosProyectoTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblControlFacturasTableAdapter != null)
        {
          this._tblControlFacturasTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblControlFacturasTableAdapter];
          this._tblControlFacturasTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblCotizacionesTableAdapter != null)
        {
          this._tblCotizacionesTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblCotizacionesTableAdapter];
          this._tblCotizacionesTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblCotizacionesDetTableAdapter != null)
        {
          this._tblCotizacionesDetTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblCotizacionesDetTableAdapter];
          this._tblCotizacionesDetTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblCotizacionNewTableAdapter != null)
        {
          this._tblCotizacionNewTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblCotizacionNewTableAdapter];
          this._tblCotizacionNewTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblDatosEmpresaTableAdapter != null)
        {
          this._tblDatosEmpresaTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblDatosEmpresaTableAdapter];
          this._tblDatosEmpresaTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblDocDisenosMecanicoTableAdapter != null)
        {
          this._tblDocDisenosMecanicoTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblDocDisenosMecanicoTableAdapter];
          this._tblDocDisenosMecanicoTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblDocMasterCamMecanicoTableAdapter != null)
        {
          this._tblDocMasterCamMecanicoTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblDocMasterCamMecanicoTableAdapter];
          this._tblDocMasterCamMecanicoTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblDocProyectosTableAdapter != null)
        {
          this._tblDocProyectosTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblDocProyectosTableAdapter];
          this._tblDocProyectosTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblEficienciasTableAdapter != null)
        {
          this._tblEficienciasTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblEficienciasTableAdapter];
          this._tblEficienciasTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblEmpresasTableAdapter != null)
        {
          this._tblEmpresasTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblEmpresasTableAdapter];
          this._tblEmpresasTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblFacturasEmitidasTableAdapter != null)
        {
          this._tblFacturasEmitidasTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblFacturasEmitidasTableAdapter];
          this._tblFacturasEmitidasTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblFacturasXMLTableAdapter != null)
        {
          this._tblFacturasXMLTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblFacturasXMLTableAdapter];
          this._tblFacturasXMLTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblFallasTableAdapter != null)
        {
          this._tblFallasTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblFallasTableAdapter];
          this._tblFallasTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblFolioCotizacionTableAdapter != null)
        {
          this._tblFolioCotizacionTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblFolioCotizacionTableAdapter];
          this._tblFolioCotizacionTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblFolioOrdenCompraTableAdapter != null)
        {
          this._tblFolioOrdenCompraTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblFolioOrdenCompraTableAdapter];
          this._tblFolioOrdenCompraTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblFolioReqTableAdapter != null)
        {
          this._tblFolioReqTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblFolioReqTableAdapter];
          this._tblFolioReqTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblFolioRFQTableAdapter != null)
        {
          this._tblFolioRFQTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblFolioRFQTableAdapter];
          this._tblFolioRFQTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblGastosTableAdapter != null)
        {
          this._tblGastosTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblGastosTableAdapter];
          this._tblGastosTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblGPSTableAdapter != null)
        {
          this._tblGPSTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblGPSTableAdapter];
          this._tblGPSTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblHabilidadesTableAdapter != null)
        {
          this._tblHabilidadesTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblHabilidadesTableAdapter];
          this._tblHabilidadesTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblHorasHombreTableAdapter != null)
        {
          this._tblHorasHombreTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblHorasHombreTableAdapter];
          this._tblHorasHombreTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblInventarioTableAdapter != null)
        {
          this._tblInventarioTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblInventarioTableAdapter];
          this._tblInventarioTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblInventarioDetTableAdapter != null)
        {
          this._tblInventarioDetTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblInventarioDetTableAdapter];
          this._tblInventarioDetTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblInvHerramientasTableAdapter != null)
        {
          this._tblInvHerramientasTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblInvHerramientasTableAdapter];
          this._tblInvHerramientasTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblInvHerramientasDetTableAdapter != null)
        {
          this._tblInvHerramientasDetTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblInvHerramientasDetTableAdapter];
          this._tblInvHerramientasDetTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblLiderProyectoTableAdapter != null)
        {
          this._tblLiderProyectoTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblLiderProyectoTableAdapter];
          this._tblLiderProyectoTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblListaPendientesTableAdapter != null)
        {
          this._tblListaPendientesTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblListaPendientesTableAdapter];
          this._tblListaPendientesTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblMaterialesTableAdapter != null)
        {
          this._tblMaterialesTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblMaterialesTableAdapter];
          this._tblMaterialesTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblMaterialImagenTableAdapter != null)
        {
          this._tblMaterialImagenTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblMaterialImagenTableAdapter];
          this._tblMaterialImagenTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblMatrizMecanicoTableAdapter != null)
        {
          this._tblMatrizMecanicoTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblMatrizMecanicoTableAdapter];
          this._tblMatrizMecanicoTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblMenuTableAdapter != null)
        {
          this._tblMenuTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblMenuTableAdapter];
          this._tblMenuTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblMonedasTableAdapter != null)
        {
          this._tblMonedasTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblMonedasTableAdapter];
          this._tblMonedasTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblNotaAclaratoriaTableAdapter != null)
        {
          this._tblNotaAclaratoriaTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblNotaAclaratoriaTableAdapter];
          this._tblNotaAclaratoriaTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblOrdenCompraTableAdapter != null)
        {
          this._tblOrdenCompraTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblOrdenCompraTableAdapter];
          this._tblOrdenCompraTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblOrdenCompraComentariosTableAdapter != null)
        {
          this._tblOrdenCompraComentariosTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblOrdenCompraComentariosTableAdapter];
          this._tblOrdenCompraComentariosTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblOrdenCompraDetTableAdapter != null)
        {
          this._tblOrdenCompraDetTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblOrdenCompraDetTableAdapter];
          this._tblOrdenCompraDetTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblOrdenCompraInsumosTableAdapter != null)
        {
          this._tblOrdenCompraInsumosTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblOrdenCompraInsumosTableAdapter];
          this._tblOrdenCompraInsumosTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblOrdenCompraNotaTableAdapter != null)
        {
          this._tblOrdenCompraNotaTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblOrdenCompraNotaTableAdapter];
          this._tblOrdenCompraNotaTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblOrdenTrabajoTableAdapter != null)
        {
          this._tblOrdenTrabajoTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblOrdenTrabajoTableAdapter];
          this._tblOrdenTrabajoTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblPermisosTableAdapter != null)
        {
          this._tblPermisosTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblPermisosTableAdapter];
          this._tblPermisosTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblProveedoresTableAdapter != null)
        {
          this._tblProveedoresTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblProveedoresTableAdapter];
          this._tblProveedoresTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblProveedoresContactosTableAdapter != null)
        {
          this._tblProveedoresContactosTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblProveedoresContactosTableAdapter];
          this._tblProveedoresContactosTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblProveedorMaterialTableAdapter != null)
        {
          this._tblProveedorMaterialTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblProveedorMaterialTableAdapter];
          this._tblProveedorMaterialTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblProyectoRequerimientoTableAdapter != null)
        {
          this._tblProyectoRequerimientoTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblProyectoRequerimientoTableAdapter];
          this._tblProyectoRequerimientoTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblProyectosTableAdapter != null)
        {
          this._tblProyectosTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblProyectosTableAdapter];
          this._tblProyectosTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblProyectosBKTableAdapter != null)
        {
          this._tblProyectosBKTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblProyectosBKTableAdapter];
          this._tblProyectosBKTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblProyectoTaskImagenTableAdapter != null)
        {
          this._tblProyectoTaskImagenTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblProyectoTaskImagenTableAdapter];
          this._tblProyectoTaskImagenTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblProyectoTasksTableAdapter != null)
        {
          this._tblProyectoTasksTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblProyectoTasksTableAdapter];
          this._tblProyectoTasksTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblProyectoTasksBKTableAdapter != null)
        {
          this._tblProyectoTasksBKTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblProyectoTasksBKTableAdapter];
          this._tblProyectoTasksBKTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblProyectoTasksComentariosTableAdapter != null)
        {
          this._tblProyectoTasksComentariosTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblProyectoTasksComentariosTableAdapter];
          this._tblProyectoTasksComentariosTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblRecuperacionesTableAdapter != null)
        {
          this._tblRecuperacionesTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblRecuperacionesTableAdapter];
          this._tblRecuperacionesTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblReqDetTableAdapter != null)
        {
          this._tblReqDetTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblReqDetTableAdapter];
          this._tblReqDetTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblReqEncTableAdapter != null)
        {
          this._tblReqEncTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblReqEncTableAdapter];
          this._tblReqEncTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblRequisicionTableAdapter != null)
        {
          this._tblRequisicionTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblRequisicionTableAdapter];
          this._tblRequisicionTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblRFQTableAdapter != null)
        {
          this._tblRFQTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblRFQTableAdapter];
          this._tblRFQTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblRFQDetTableAdapter != null)
        {
          this._tblRFQDetTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblRFQDetTableAdapter];
          this._tblRFQDetTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblRfqSeguimientoTableAdapter != null)
        {
          this._tblRfqSeguimientoTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblRfqSeguimientoTableAdapter];
          this._tblRfqSeguimientoTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblRfqVentasTableAdapter != null)
        {
          this._tblRfqVentasTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblRfqVentasTableAdapter];
          this._tblRfqVentasTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblRolesUsuariosTableAdapter != null)
        {
          this._tblRolesUsuariosTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblRolesUsuariosTableAdapter];
          this._tblRolesUsuariosTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblServicioComputoTableAdapter != null)
        {
          this._tblServicioComputoTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblServicioComputoTableAdapter];
          this._tblServicioComputoTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblServiciosComputoTableAdapter != null)
        {
          this._tblServiciosComputoTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblServiciosComputoTableAdapter];
          this._tblServiciosComputoTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblSolicitudesAprobacionTableAdapter != null)
        {
          this._tblSolicitudesAprobacionTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblSolicitudesAprobacionTableAdapter];
          this._tblSolicitudesAprobacionTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblSubMenuTableAdapter != null)
        {
          this._tblSubMenuTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblSubMenuTableAdapter];
          this._tblSubMenuTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblSucursalesTableAdapter != null)
        {
          this._tblSucursalesTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblSucursalesTableAdapter];
          this._tblSucursalesTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblTeamProjectTableAdapter != null)
        {
          this._tblTeamProjectTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblTeamProjectTableAdapter];
          this._tblTeamProjectTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblTimmingProyectoTableAdapter != null)
        {
          this._tblTimmingProyectoTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblTimmingProyectoTableAdapter];
          this._tblTimmingProyectoTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblUnidadMedidaTableAdapter != null)
        {
          this._tblUnidadMedidaTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblUnidadMedidaTableAdapter];
          this._tblUnidadMedidaTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblUsuariosTableAdapter != null)
        {
          this._tblUsuariosTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblUsuariosTableAdapter];
          this._tblUsuariosTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblUsuariosBKTableAdapter != null)
        {
          this._tblUsuariosBKTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblUsuariosBKTableAdapter];
          this._tblUsuariosBKTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblVehiculosTableAdapter != null)
        {
          this._tblVehiculosTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblVehiculosTableAdapter];
          this._tblVehiculosTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblVehiculoServicioTableAdapter != null)
        {
          this._tblVehiculoServicioTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblVehiculoServicioTableAdapter];
          this._tblVehiculoServicioTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblVehiculoServicioItemTableAdapter != null)
        {
          this._tblVehiculoServicioItemTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblVehiculoServicioItemTableAdapter];
          this._tblVehiculoServicioItemTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblViaticosTableAdapter != null)
        {
          this._tblViaticosTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblViaticosTableAdapter];
          this._tblViaticosTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblViaticosDetTableAdapter != null)
        {
          this._tblViaticosDetTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblViaticosDetTableAdapter];
          this._tblViaticosDetTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._utilidadTableAdapter != null)
        {
          this._utilidadTableAdapter.Connection = (SqlConnection) dictionary[(object) this._utilidadTableAdapter];
          this._utilidadTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._utilidadPastelTableAdapter != null)
        {
          this._utilidadPastelTableAdapter.Connection = (SqlConnection) dictionary[(object) this._utilidadPastelTableAdapter];
          this._utilidadPastelTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (0 < dataAdapterList.Count)
        {
          DataAdapter[] array = new DataAdapter[dataAdapterList.Count];
          dataAdapterList.CopyTo(array);
          for (int index = 0; index < array.Length; ++index)
            array[index].AcceptChangesDuringUpdate = true;
        }
      }
      return num;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    protected virtual void SortSelfReferenceRows(
      DataRow[] rows,
      DataRelation relation,
      bool childFirst)
    {
      Array.Sort<DataRow>(rows, (IComparer<DataRow>) new TableAdapterManager.SelfReferenceComparer(relation, childFirst));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    protected virtual bool MatchTableAdapterConnection(IDbConnection inputConnection) => this._connection != null || this.Connection == null || inputConnection == null || string.Equals(this.Connection.ConnectionString, inputConnection.ConnectionString, StringComparison.Ordinal);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public enum UpdateOrderOption
    {
      InsertUpdateDelete,
      UpdateInsertDelete,
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private class SelfReferenceComparer : IComparer<DataRow>
    {
      private DataRelation _relation;
      private int _childFirst;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal SelfReferenceComparer(DataRelation relation, bool childFirst)
      {
        this._relation = relation;
        if (childFirst)
          this._childFirst = -1;
        else
          this._childFirst = 1;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private DataRow GetRoot(DataRow row, out int distance)
      {
        DataRow dataRow = row;
        distance = 0;
        IDictionary<DataRow, DataRow> dictionary = (IDictionary<DataRow, DataRow>) new Dictionary<DataRow, DataRow>();
        dictionary[row] = row;
        for (DataRow parentRow = row.GetParentRow(this._relation, DataRowVersion.Default); parentRow != null && !dictionary.ContainsKey(parentRow); parentRow = parentRow.GetParentRow(this._relation, DataRowVersion.Default))
        {
          ++distance;
          dataRow = parentRow;
          dictionary[parentRow] = parentRow;
        }
        if (distance == 0)
        {
          dictionary.Clear();
          dictionary[row] = row;
          for (DataRow parentRow = row.GetParentRow(this._relation, DataRowVersion.Original); parentRow != null && !dictionary.ContainsKey(parentRow); parentRow = parentRow.GetParentRow(this._relation, DataRowVersion.Original))
          {
            ++distance;
            dataRow = parentRow;
            dictionary[parentRow] = parentRow;
          }
        }
        return dataRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Compare(DataRow row1, DataRow row2)
      {
        if (row1 == row2)
          return 0;
        if (row1 == null)
          return -1;
        if (row2 == null)
          return 1;
        int distance1 = 0;
        DataRow root1 = this.GetRoot(row1, out distance1);
        int distance2 = 0;
        DataRow root2 = this.GetRoot(row2, out distance2);
        if (root1 == root2)
          return this._childFirst * distance1.CompareTo(distance2);
        return root1.Table.Rows.IndexOf(root1) < root2.Table.Rows.IndexOf(root2) ? -1 : 1;
      }
    }
  }
}
