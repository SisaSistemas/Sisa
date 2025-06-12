// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDevFacturasTableAdapters.tblRolesUsuariosTableAdapter
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SisaDev.SisaDevFacturasTableAdapters
{
  [DesignerCategory("code")]
  [ToolboxItem(true)]
  [DataObject(true)]
  [Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
  [HelpKeyword("vs.data.TableAdapter")]
  public class tblRolesUsuariosTableAdapter : Component
  {
    private SqlDataAdapter _adapter;
    private SqlConnection _connection;
    private SqlTransaction _transaction;
    private SqlCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public tblRolesUsuariosTableAdapter() => this.ClearBeforeFill = true;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    protected internal SqlDataAdapter Adapter
    {
      get
      {
        if (this._adapter == null)
          this.InitAdapter();
        return this._adapter;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    internal SqlConnection Connection
    {
      get
      {
        if (this._connection == null)
          this.InitConnection();
        return this._connection;
      }
      set
      {
        this._connection = value;
        if (this.Adapter.InsertCommand != null)
          this.Adapter.InsertCommand.Connection = value;
        if (this.Adapter.DeleteCommand != null)
          this.Adapter.DeleteCommand.Connection = value;
        if (this.Adapter.UpdateCommand != null)
          this.Adapter.UpdateCommand.Connection = value;
        for (int index = 0; index < this.CommandCollection.Length; ++index)
        {
          if (this.CommandCollection[index] != null)
            this.CommandCollection[index].Connection = value;
        }
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    internal SqlTransaction Transaction
    {
      get => this._transaction;
      set
      {
        this._transaction = value;
        for (int index = 0; index < this.CommandCollection.Length; ++index)
          this.CommandCollection[index].Transaction = this._transaction;
        if (this.Adapter != null && this.Adapter.DeleteCommand != null)
          this.Adapter.DeleteCommand.Transaction = this._transaction;
        if (this.Adapter != null && this.Adapter.InsertCommand != null)
          this.Adapter.InsertCommand.Transaction = this._transaction;
        if (this.Adapter == null || this.Adapter.UpdateCommand == null)
          return;
        this.Adapter.UpdateCommand.Transaction = this._transaction;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    protected SqlCommand[] CommandCollection
    {
      get
      {
        if (this._commandCollection == null)
          this.InitCommandCollection();
        return this._commandCollection;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public bool ClearBeforeFill
    {
      get => this._clearBeforeFill;
      set => this._clearBeforeFill = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private void InitAdapter()
    {
      this._adapter = new SqlDataAdapter();
      this._adapter.TableMappings.Add((object) new DataTableMapping()
      {
        SourceTable = "Table",
        DataSetTable = "tblRolesUsuarios",
        ColumnMappings = {
          {
            "idRol",
            "idRol"
          },
          {
            "Tipo",
            "Tipo"
          },
          {
            "idUsuarios",
            "idUsuarios"
          },
          {
            "ClienteEmpresa",
            "ClienteEmpresa"
          },
          {
            "ClienteEmpresaAgregar",
            "ClienteEmpresaAgregar"
          },
          {
            "ClienteEmpresaEditar",
            "ClienteEmpresaEditar"
          },
          {
            "ClienteEmpresaEliminar",
            "ClienteEmpresaEliminar"
          },
          {
            "ClienteContacto",
            "ClienteContacto"
          },
          {
            "ClienteContactoAgrear",
            "ClienteContactoAgrear"
          },
          {
            "ClienteContactoEditar",
            "ClienteContactoEditar"
          },
          {
            "ClienteContactoEliminar",
            "ClienteContactoEliminar"
          },
          {
            "RFQ",
            "RFQ"
          },
          {
            "RFQAgregar",
            "RFQAgregar"
          },
          {
            "RFQEditar",
            "RFQEditar"
          },
          {
            "RFQEliminar",
            "RFQEliminar"
          },
          {
            "Cotizaciones",
            "Cotizaciones"
          },
          {
            "CotizacionesAgregar",
            "CotizacionesAgregar"
          },
          {
            "CotizacionesEditar",
            "CotizacionesEditar"
          },
          {
            "CotizacionesEliminar",
            "CotizacionesEliminar"
          },
          {
            "Materiales",
            "Materiales"
          },
          {
            "MaterialesAgregar",
            "MaterialesAgregar"
          },
          {
            "MaterialesEditar",
            "MaterialesEditar"
          },
          {
            "MaterialesEliminar",
            "MaterialesEliminar"
          },
          {
            "Proveedores",
            "Proveedores"
          },
          {
            "ProveedoresAgregar",
            "ProveedoresAgregar"
          },
          {
            "ProveedoresEditar",
            "ProveedoresEditar"
          },
          {
            "ProveedoresEliminar",
            "ProveedoresEliminar"
          },
          {
            "Requisiciones",
            "Requisiciones"
          },
          {
            "RequisicionesAgregar",
            "RequisicionesAgregar"
          },
          {
            "RequisicionesEditar",
            "RequisicionesEditar"
          },
          {
            "RequisicionesEliminar",
            "RequisicionesEliminar"
          },
          {
            "OC",
            "OC"
          },
          {
            "OCAgregar",
            "OCAgregar"
          },
          {
            "OCEditar",
            "OCEditar"
          },
          {
            "OCEliminar",
            "OCEliminar"
          },
          {
            "Viaticos",
            "Viaticos"
          },
          {
            "ViaticosAgregar",
            "ViaticosAgregar"
          },
          {
            "ViaticosEditar",
            "ViaticosEditar"
          },
          {
            "ViaticosEliminar",
            "ViaticosEliminar"
          },
          {
            "Proyectos",
            "Proyectos"
          },
          {
            "ProyectosEditar",
            "ProyectosEditar"
          },
          {
            "ProyectosEliminar",
            "ProyectosEliminar"
          },
          {
            "ProyectosAgregar",
            "ProyectosAgregar"
          },
          {
            "CajaChica",
            "CajaChica"
          },
          {
            "CajaChicaAgregar",
            "CajaChicaAgregar"
          },
          {
            "CajaChicaEditar",
            "CajaChicaEditar"
          },
          {
            "CajaChicaEliminar",
            "CajaChicaEliminar"
          },
          {
            "Usuarios",
            "Usuarios"
          },
          {
            "UsuariosAgregar",
            "UsuariosAgregar"
          },
          {
            "UsuariosEditar",
            "UsuariosEditar"
          },
          {
            "UsuariosEliminar",
            "UsuariosEliminar"
          },
          {
            "Sucursales",
            "Sucursales"
          },
          {
            "SucursalesAgregar",
            "SucursalesAgregar"
          },
          {
            "SucursalesEditar",
            "SucursalesEditar"
          },
          {
            "SucursalesEliminar",
            "SucursalesEliminar"
          },
          {
            "ControlFacturas",
            "ControlFacturas"
          },
          {
            "ControlDocumentos",
            "ControlDocumentos"
          },
          {
            "Administracion",
            "Administracion"
          },
          {
            "Timming",
            "Timming"
          },
          {
            "ServiciosCarro",
            "ServiciosCarro"
          },
          {
            "Inventario",
            "Inventario"
          },
          {
            "ServiciosComputo",
            "ServiciosComputo"
          },
          {
            "FacturasEmitidas",
            "FacturasEmitidas"
          }
        }
      });
      this._adapter.DeleteCommand = new SqlCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[tblRolesUsuarios] WHERE (([idRol] = @Original_idRol))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_idRol", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "idRol", DataRowVersion.Original, false, (object) null, "", "", ""));
      this._adapter.InsertCommand = new SqlCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[tblRolesUsuarios] ([idRol], [Tipo], [idUsuarios], [ClienteEmpresa], [ClienteEmpresaAgregar], [ClienteEmpresaEditar], [ClienteEmpresaEliminar], [ClienteContacto], [ClienteContactoAgrear], [ClienteContactoEditar], [ClienteContactoEliminar], [RFQ], [RFQAgregar], [RFQEditar], [RFQEliminar], [Cotizaciones], [CotizacionesAgregar], [CotizacionesEditar], [CotizacionesEliminar], [Materiales], [MaterialesAgregar], [MaterialesEditar], [MaterialesEliminar], [Proveedores], [ProveedoresAgregar], [ProveedoresEditar], [ProveedoresEliminar], [Requisiciones], [RequisicionesAgregar], [RequisicionesEditar], [RequisicionesEliminar], [OC], [OCAgregar], [OCEditar], [OCEliminar], [Viaticos], [ViaticosAgregar], [ViaticosEditar], [ViaticosEliminar], [Proyectos], [ProyectosEditar], [ProyectosEliminar], [ProyectosAgregar], [CajaChica], [CajaChicaAgregar], [CajaChicaEditar], [CajaChicaEliminar], [Usuarios], [UsuariosAgregar], [UsuariosEditar], [UsuariosEliminar], [Sucursales], [SucursalesAgregar], [SucursalesEditar], [SucursalesEliminar], [ControlFacturas], [ControlDocumentos], [Administracion], [Timming], [ServiciosCarro], [Inventario], [ServiciosComputo], [FacturasEmitidas]) VALUES (@idRol, @Tipo, @idUsuarios, @ClienteEmpresa, @ClienteEmpresaAgregar, @ClienteEmpresaEditar, @ClienteEmpresaEliminar, @ClienteContacto, @ClienteContactoAgrear, @ClienteContactoEditar, @ClienteContactoEliminar, @RFQ, @RFQAgregar, @RFQEditar, @RFQEliminar, @Cotizaciones, @CotizacionesAgregar, @CotizacionesEditar, @CotizacionesEliminar, @Materiales, @MaterialesAgregar, @MaterialesEditar, @MaterialesEliminar, @Proveedores, @ProveedoresAgregar, @ProveedoresEditar, @ProveedoresEliminar, @Requisiciones, @RequisicionesAgregar, @RequisicionesEditar, @RequisicionesEliminar, @OC, @OCAgregar, @OCEditar, @OCEliminar, @Viaticos, @ViaticosAgregar, @ViaticosEditar, @ViaticosEliminar, @Proyectos, @ProyectosEditar, @ProyectosEliminar, @ProyectosAgregar, @CajaChica, @CajaChicaAgregar, @CajaChicaEditar, @CajaChicaEliminar, @Usuarios, @UsuariosAgregar, @UsuariosEditar, @UsuariosEliminar, @Sucursales, @SucursalesAgregar, @SucursalesEditar, @SucursalesEliminar, @ControlFacturas, @ControlDocumentos, @Administracion, @Timming, @ServiciosCarro, @Inventario, @ServiciosComputo, @FacturasEmitidas)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@idRol", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "idRol", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Tipo", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Tipo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@idUsuarios", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "idUsuarios", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ClienteEmpresa", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ClienteEmpresa", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ClienteEmpresaAgregar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ClienteEmpresaAgregar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ClienteEmpresaEditar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ClienteEmpresaEditar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ClienteEmpresaEliminar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ClienteEmpresaEliminar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ClienteContacto", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ClienteContacto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ClienteContactoAgrear", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ClienteContactoAgrear", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ClienteContactoEditar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ClienteContactoEditar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ClienteContactoEliminar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ClienteContactoEliminar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@RFQ", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RFQ", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@RFQAgregar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RFQAgregar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@RFQEditar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RFQEditar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@RFQEliminar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RFQEliminar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Cotizaciones", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Cotizaciones", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@CotizacionesAgregar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CotizacionesAgregar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@CotizacionesEditar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CotizacionesEditar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@CotizacionesEliminar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CotizacionesEliminar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Materiales", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Materiales", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@MaterialesAgregar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MaterialesAgregar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@MaterialesEditar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MaterialesEditar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@MaterialesEliminar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MaterialesEliminar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Proveedores", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Proveedores", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ProveedoresAgregar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ProveedoresAgregar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ProveedoresEditar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ProveedoresEditar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ProveedoresEliminar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ProveedoresEliminar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Requisiciones", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Requisiciones", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@RequisicionesAgregar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RequisicionesAgregar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@RequisicionesEditar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RequisicionesEditar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@RequisicionesEliminar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RequisicionesEliminar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@OC", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OC", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@OCAgregar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OCAgregar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@OCEditar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OCEditar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@OCEliminar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OCEliminar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Viaticos", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Viaticos", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ViaticosAgregar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ViaticosAgregar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ViaticosEditar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ViaticosEditar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ViaticosEliminar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ViaticosEliminar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Proyectos", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Proyectos", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ProyectosEditar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ProyectosEditar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ProyectosEliminar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ProyectosEliminar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ProyectosAgregar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ProyectosAgregar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@CajaChica", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CajaChica", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@CajaChicaAgregar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CajaChicaAgregar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@CajaChicaEditar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CajaChicaEditar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@CajaChicaEliminar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CajaChicaEliminar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Usuarios", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Usuarios", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@UsuariosAgregar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "UsuariosAgregar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@UsuariosEditar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "UsuariosEditar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@UsuariosEliminar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "UsuariosEliminar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Sucursales", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Sucursales", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@SucursalesAgregar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SucursalesAgregar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@SucursalesEditar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SucursalesEditar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@SucursalesEliminar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SucursalesEliminar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ControlFacturas", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ControlFacturas", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ControlDocumentos", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ControlDocumentos", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Administracion", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Administracion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Timming", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Timming", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ServiciosCarro", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ServiciosCarro", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Inventario", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Inventario", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ServiciosComputo", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ServiciosComputo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FacturasEmitidas", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FacturasEmitidas", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand = new SqlCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[tblRolesUsuarios] SET [idRol] = @idRol, [Tipo] = @Tipo, [idUsuarios] = @idUsuarios, [ClienteEmpresa] = @ClienteEmpresa, [ClienteEmpresaAgregar] = @ClienteEmpresaAgregar, [ClienteEmpresaEditar] = @ClienteEmpresaEditar, [ClienteEmpresaEliminar] = @ClienteEmpresaEliminar, [ClienteContacto] = @ClienteContacto, [ClienteContactoAgrear] = @ClienteContactoAgrear, [ClienteContactoEditar] = @ClienteContactoEditar, [ClienteContactoEliminar] = @ClienteContactoEliminar, [RFQ] = @RFQ, [RFQAgregar] = @RFQAgregar, [RFQEditar] = @RFQEditar, [RFQEliminar] = @RFQEliminar, [Cotizaciones] = @Cotizaciones, [CotizacionesAgregar] = @CotizacionesAgregar, [CotizacionesEditar] = @CotizacionesEditar, [CotizacionesEliminar] = @CotizacionesEliminar, [Materiales] = @Materiales, [MaterialesAgregar] = @MaterialesAgregar, [MaterialesEditar] = @MaterialesEditar, [MaterialesEliminar] = @MaterialesEliminar, [Proveedores] = @Proveedores, [ProveedoresAgregar] = @ProveedoresAgregar, [ProveedoresEditar] = @ProveedoresEditar, [ProveedoresEliminar] = @ProveedoresEliminar, [Requisiciones] = @Requisiciones, [RequisicionesAgregar] = @RequisicionesAgregar, [RequisicionesEditar] = @RequisicionesEditar, [RequisicionesEliminar] = @RequisicionesEliminar, [OC] = @OC, [OCAgregar] = @OCAgregar, [OCEditar] = @OCEditar, [OCEliminar] = @OCEliminar, [Viaticos] = @Viaticos, [ViaticosAgregar] = @ViaticosAgregar, [ViaticosEditar] = @ViaticosEditar, [ViaticosEliminar] = @ViaticosEliminar, [Proyectos] = @Proyectos, [ProyectosEditar] = @ProyectosEditar, [ProyectosEliminar] = @ProyectosEliminar, [ProyectosAgregar] = @ProyectosAgregar, [CajaChica] = @CajaChica, [CajaChicaAgregar] = @CajaChicaAgregar, [CajaChicaEditar] = @CajaChicaEditar, [CajaChicaEliminar] = @CajaChicaEliminar, [Usuarios] = @Usuarios, [UsuariosAgregar] = @UsuariosAgregar, [UsuariosEditar] = @UsuariosEditar, [UsuariosEliminar] = @UsuariosEliminar, [Sucursales] = @Sucursales, [SucursalesAgregar] = @SucursalesAgregar, [SucursalesEditar] = @SucursalesEditar, [SucursalesEliminar] = @SucursalesEliminar, [ControlFacturas] = @ControlFacturas, [ControlDocumentos] = @ControlDocumentos, [Administracion] = @Administracion, [Timming] = @Timming, [ServiciosCarro] = @ServiciosCarro, [Inventario] = @Inventario, [ServiciosComputo] = @ServiciosComputo, [FacturasEmitidas] = @FacturasEmitidas WHERE (([idRol] = @Original_idRol))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@idRol", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "idRol", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Tipo", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Tipo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@idUsuarios", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "idUsuarios", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ClienteEmpresa", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ClienteEmpresa", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ClienteEmpresaAgregar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ClienteEmpresaAgregar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ClienteEmpresaEditar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ClienteEmpresaEditar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ClienteEmpresaEliminar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ClienteEmpresaEliminar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ClienteContacto", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ClienteContacto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ClienteContactoAgrear", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ClienteContactoAgrear", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ClienteContactoEditar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ClienteContactoEditar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ClienteContactoEliminar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ClienteContactoEliminar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@RFQ", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RFQ", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@RFQAgregar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RFQAgregar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@RFQEditar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RFQEditar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@RFQEliminar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RFQEliminar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Cotizaciones", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Cotizaciones", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CotizacionesAgregar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CotizacionesAgregar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CotizacionesEditar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CotizacionesEditar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CotizacionesEliminar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CotizacionesEliminar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Materiales", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Materiales", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@MaterialesAgregar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MaterialesAgregar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@MaterialesEditar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MaterialesEditar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@MaterialesEliminar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MaterialesEliminar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Proveedores", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Proveedores", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ProveedoresAgregar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ProveedoresAgregar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ProveedoresEditar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ProveedoresEditar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ProveedoresEliminar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ProveedoresEliminar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Requisiciones", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Requisiciones", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@RequisicionesAgregar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RequisicionesAgregar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@RequisicionesEditar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RequisicionesEditar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@RequisicionesEliminar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RequisicionesEliminar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@OC", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OC", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@OCAgregar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OCAgregar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@OCEditar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OCEditar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@OCEliminar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OCEliminar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Viaticos", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Viaticos", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ViaticosAgregar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ViaticosAgregar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ViaticosEditar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ViaticosEditar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ViaticosEliminar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ViaticosEliminar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Proyectos", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Proyectos", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ProyectosEditar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ProyectosEditar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ProyectosEliminar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ProyectosEliminar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ProyectosAgregar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ProyectosAgregar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CajaChica", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CajaChica", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CajaChicaAgregar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CajaChicaAgregar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CajaChicaEditar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CajaChicaEditar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CajaChicaEliminar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CajaChicaEliminar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Usuarios", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Usuarios", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@UsuariosAgregar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "UsuariosAgregar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@UsuariosEditar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "UsuariosEditar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@UsuariosEliminar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "UsuariosEliminar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Sucursales", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Sucursales", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@SucursalesAgregar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SucursalesAgregar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@SucursalesEditar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SucursalesEditar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@SucursalesEliminar", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SucursalesEliminar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ControlFacturas", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ControlFacturas", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ControlDocumentos", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ControlDocumentos", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Administracion", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Administracion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Timming", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Timming", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ServiciosCarro", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ServiciosCarro", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Inventario", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Inventario", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ServiciosComputo", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ServiciosComputo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FacturasEmitidas", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FacturasEmitidas", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_idRol", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "idRol", DataRowVersion.Original, false, (object) null, "", "", ""));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private void InitConnection()
    {
      this._connection = new SqlConnection();
      this._connection.ConnectionString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private void InitCommandCollection()
    {
      this._commandCollection = new SqlCommand[1];
      this._commandCollection[0] = new SqlCommand();
      this._commandCollection[0].Connection = this.Connection;
      this._commandCollection[0].CommandText = "SELECT idRol, Tipo, idUsuarios, ClienteEmpresa, ClienteEmpresaAgregar, ClienteEmpresaEditar, ClienteEmpresaEliminar, ClienteContacto, ClienteContactoAgrear, ClienteContactoEditar, ClienteContactoEliminar, RFQ, RFQAgregar, RFQEditar, RFQEliminar, Cotizaciones, CotizacionesAgregar, CotizacionesEditar, CotizacionesEliminar, Materiales, MaterialesAgregar, MaterialesEditar, MaterialesEliminar, Proveedores, ProveedoresAgregar, ProveedoresEditar, ProveedoresEliminar, Requisiciones, RequisicionesAgregar, RequisicionesEditar, RequisicionesEliminar, OC, OCAgregar, OCEditar, OCEliminar, Viaticos, ViaticosAgregar, ViaticosEditar, ViaticosEliminar, Proyectos, ProyectosEditar, ProyectosEliminar, ProyectosAgregar, CajaChica, CajaChicaAgregar, CajaChicaEditar, CajaChicaEliminar, Usuarios, UsuariosAgregar, UsuariosEditar, UsuariosEliminar, Sucursales, SucursalesAgregar, SucursalesEditar, SucursalesEliminar, ControlFacturas, ControlDocumentos, Administracion, Timming, ServiciosCarro, Inventario, ServiciosComputo, FacturasEmitidas FROM dbo.tblRolesUsuarios";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(
      SisaDevFacturas.tblRolesUsuariosDataTable dataTable)
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      if (this.ClearBeforeFill)
        dataTable.Clear();
      return this.Adapter.Fill((DataTable) dataTable);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public virtual SisaDevFacturas.tblRolesUsuariosDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      SisaDevFacturas.tblRolesUsuariosDataTable usuariosDataTable = new SisaDevFacturas.tblRolesUsuariosDataTable();
      this.Adapter.Fill((DataTable) usuariosDataTable);
      return usuariosDataTable;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(
      SisaDevFacturas.tblRolesUsuariosDataTable dataTable)
    {
      return this.Adapter.Update((DataTable) dataTable);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas dataSet) => this.Adapter.Update((DataSet) dataSet, "tblRolesUsuarios");

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(DataRow dataRow) => this.Adapter.Update(new DataRow[1]
    {
      dataRow
    });

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(DataRow[] dataRows) => this.Adapter.Update(dataRows);

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Delete, true)]
    public virtual int Delete(Guid Original_idRol)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) Original_idRol;
      ConnectionState state = this.Adapter.DeleteCommand.Connection.State;
      if ((this.Adapter.DeleteCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        this.Adapter.DeleteCommand.Connection.Open();
      try
      {
        return this.Adapter.DeleteCommand.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          this.Adapter.DeleteCommand.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Insert, true)]
    public virtual int Insert(
      Guid idRol,
      string Tipo,
      Guid idUsuarios,
      bool ClienteEmpresa,
      bool ClienteEmpresaAgregar,
      bool ClienteEmpresaEditar,
      bool ClienteEmpresaEliminar,
      bool ClienteContacto,
      bool ClienteContactoAgrear,
      bool ClienteContactoEditar,
      bool ClienteContactoEliminar,
      bool RFQ,
      bool RFQAgregar,
      bool RFQEditar,
      bool RFQEliminar,
      bool Cotizaciones,
      bool CotizacionesAgregar,
      bool CotizacionesEditar,
      bool CotizacionesEliminar,
      bool Materiales,
      bool MaterialesAgregar,
      bool MaterialesEditar,
      bool MaterialesEliminar,
      bool Proveedores,
      bool ProveedoresAgregar,
      bool ProveedoresEditar,
      bool ProveedoresEliminar,
      bool Requisiciones,
      bool RequisicionesAgregar,
      bool RequisicionesEditar,
      bool RequisicionesEliminar,
      bool OC,
      bool OCAgregar,
      bool OCEditar,
      bool OCEliminar,
      bool Viaticos,
      bool ViaticosAgregar,
      bool ViaticosEditar,
      bool ViaticosEliminar,
      bool Proyectos,
      bool ProyectosEditar,
      bool ProyectosEliminar,
      bool ProyectosAgregar,
      bool CajaChica,
      bool CajaChicaAgregar,
      bool CajaChicaEditar,
      bool CajaChicaEliminar,
      bool Usuarios,
      bool UsuariosAgregar,
      bool UsuariosEditar,
      bool UsuariosEliminar,
      bool Sucursales,
      bool SucursalesAgregar,
      bool SucursalesEditar,
      bool SucursalesEliminar,
      bool ControlFacturas,
      bool ControlDocumentos,
      bool Administracion,
      bool Timming,
      bool ServiciosCarro,
      bool Inventario,
      bool ServiciosComputo,
      bool? FacturasEmitidas)
    {
      this.Adapter.InsertCommand.Parameters[0].Value = (object) idRol;
      this.Adapter.InsertCommand.Parameters[1].Value = Tipo != null ? (object) Tipo : throw new ArgumentNullException(nameof (Tipo));
      this.Adapter.InsertCommand.Parameters[2].Value = (object) idUsuarios;
      this.Adapter.InsertCommand.Parameters[3].Value = (object) ClienteEmpresa;
      this.Adapter.InsertCommand.Parameters[4].Value = (object) ClienteEmpresaAgregar;
      this.Adapter.InsertCommand.Parameters[5].Value = (object) ClienteEmpresaEditar;
      this.Adapter.InsertCommand.Parameters[6].Value = (object) ClienteEmpresaEliminar;
      this.Adapter.InsertCommand.Parameters[7].Value = (object) ClienteContacto;
      this.Adapter.InsertCommand.Parameters[8].Value = (object) ClienteContactoAgrear;
      this.Adapter.InsertCommand.Parameters[9].Value = (object) ClienteContactoEditar;
      this.Adapter.InsertCommand.Parameters[10].Value = (object) ClienteContactoEliminar;
      this.Adapter.InsertCommand.Parameters[11].Value = (object) RFQ;
      this.Adapter.InsertCommand.Parameters[12].Value = (object) RFQAgregar;
      this.Adapter.InsertCommand.Parameters[13].Value = (object) RFQEditar;
      this.Adapter.InsertCommand.Parameters[14].Value = (object) RFQEliminar;
      this.Adapter.InsertCommand.Parameters[15].Value = (object) Cotizaciones;
      this.Adapter.InsertCommand.Parameters[16].Value = (object) CotizacionesAgregar;
      this.Adapter.InsertCommand.Parameters[17].Value = (object) CotizacionesEditar;
      this.Adapter.InsertCommand.Parameters[18].Value = (object) CotizacionesEliminar;
      this.Adapter.InsertCommand.Parameters[19].Value = (object) Materiales;
      this.Adapter.InsertCommand.Parameters[20].Value = (object) MaterialesAgregar;
      this.Adapter.InsertCommand.Parameters[21].Value = (object) MaterialesEditar;
      this.Adapter.InsertCommand.Parameters[22].Value = (object) MaterialesEliminar;
      this.Adapter.InsertCommand.Parameters[23].Value = (object) Proveedores;
      this.Adapter.InsertCommand.Parameters[24].Value = (object) ProveedoresAgregar;
      this.Adapter.InsertCommand.Parameters[25].Value = (object) ProveedoresEditar;
      this.Adapter.InsertCommand.Parameters[26].Value = (object) ProveedoresEliminar;
      this.Adapter.InsertCommand.Parameters[27].Value = (object) Requisiciones;
      this.Adapter.InsertCommand.Parameters[28].Value = (object) RequisicionesAgregar;
      this.Adapter.InsertCommand.Parameters[29].Value = (object) RequisicionesEditar;
      this.Adapter.InsertCommand.Parameters[30].Value = (object) RequisicionesEliminar;
      this.Adapter.InsertCommand.Parameters[31].Value = (object) OC;
      this.Adapter.InsertCommand.Parameters[32].Value = (object) OCAgregar;
      this.Adapter.InsertCommand.Parameters[33].Value = (object) OCEditar;
      this.Adapter.InsertCommand.Parameters[34].Value = (object) OCEliminar;
      this.Adapter.InsertCommand.Parameters[35].Value = (object) Viaticos;
      this.Adapter.InsertCommand.Parameters[36].Value = (object) ViaticosAgregar;
      this.Adapter.InsertCommand.Parameters[37].Value = (object) ViaticosEditar;
      this.Adapter.InsertCommand.Parameters[38].Value = (object) ViaticosEliminar;
      this.Adapter.InsertCommand.Parameters[39].Value = (object) Proyectos;
      this.Adapter.InsertCommand.Parameters[40].Value = (object) ProyectosEditar;
      this.Adapter.InsertCommand.Parameters[41].Value = (object) ProyectosEliminar;
      this.Adapter.InsertCommand.Parameters[42].Value = (object) ProyectosAgregar;
      this.Adapter.InsertCommand.Parameters[43].Value = (object) CajaChica;
      this.Adapter.InsertCommand.Parameters[44].Value = (object) CajaChicaAgregar;
      this.Adapter.InsertCommand.Parameters[45].Value = (object) CajaChicaEditar;
      this.Adapter.InsertCommand.Parameters[46].Value = (object) CajaChicaEliminar;
      this.Adapter.InsertCommand.Parameters[47].Value = (object) Usuarios;
      this.Adapter.InsertCommand.Parameters[48].Value = (object) UsuariosAgregar;
      this.Adapter.InsertCommand.Parameters[49].Value = (object) UsuariosEditar;
      this.Adapter.InsertCommand.Parameters[50].Value = (object) UsuariosEliminar;
      this.Adapter.InsertCommand.Parameters[51].Value = (object) Sucursales;
      this.Adapter.InsertCommand.Parameters[52].Value = (object) SucursalesAgregar;
      this.Adapter.InsertCommand.Parameters[53].Value = (object) SucursalesEditar;
      this.Adapter.InsertCommand.Parameters[54].Value = (object) SucursalesEliminar;
      this.Adapter.InsertCommand.Parameters[55].Value = (object) ControlFacturas;
      this.Adapter.InsertCommand.Parameters[56].Value = (object) ControlDocumentos;
      this.Adapter.InsertCommand.Parameters[57].Value = (object) Administracion;
      this.Adapter.InsertCommand.Parameters[58].Value = (object) Timming;
      this.Adapter.InsertCommand.Parameters[59].Value = (object) ServiciosCarro;
      this.Adapter.InsertCommand.Parameters[60].Value = (object) Inventario;
      this.Adapter.InsertCommand.Parameters[61].Value = (object) ServiciosComputo;
      if (FacturasEmitidas.HasValue)
        this.Adapter.InsertCommand.Parameters[62].Value = (object) FacturasEmitidas.Value;
      else
        this.Adapter.InsertCommand.Parameters[62].Value = (object) DBNull.Value;
      ConnectionState state = this.Adapter.InsertCommand.Connection.State;
      if ((this.Adapter.InsertCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        this.Adapter.InsertCommand.Connection.Open();
      try
      {
        return this.Adapter.InsertCommand.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          this.Adapter.InsertCommand.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Update, true)]
    public virtual int Update(
      Guid idRol,
      string Tipo,
      Guid idUsuarios,
      bool ClienteEmpresa,
      bool ClienteEmpresaAgregar,
      bool ClienteEmpresaEditar,
      bool ClienteEmpresaEliminar,
      bool ClienteContacto,
      bool ClienteContactoAgrear,
      bool ClienteContactoEditar,
      bool ClienteContactoEliminar,
      bool RFQ,
      bool RFQAgregar,
      bool RFQEditar,
      bool RFQEliminar,
      bool Cotizaciones,
      bool CotizacionesAgregar,
      bool CotizacionesEditar,
      bool CotizacionesEliminar,
      bool Materiales,
      bool MaterialesAgregar,
      bool MaterialesEditar,
      bool MaterialesEliminar,
      bool Proveedores,
      bool ProveedoresAgregar,
      bool ProveedoresEditar,
      bool ProveedoresEliminar,
      bool Requisiciones,
      bool RequisicionesAgregar,
      bool RequisicionesEditar,
      bool RequisicionesEliminar,
      bool OC,
      bool OCAgregar,
      bool OCEditar,
      bool OCEliminar,
      bool Viaticos,
      bool ViaticosAgregar,
      bool ViaticosEditar,
      bool ViaticosEliminar,
      bool Proyectos,
      bool ProyectosEditar,
      bool ProyectosEliminar,
      bool ProyectosAgregar,
      bool CajaChica,
      bool CajaChicaAgregar,
      bool CajaChicaEditar,
      bool CajaChicaEliminar,
      bool Usuarios,
      bool UsuariosAgregar,
      bool UsuariosEditar,
      bool UsuariosEliminar,
      bool Sucursales,
      bool SucursalesAgregar,
      bool SucursalesEditar,
      bool SucursalesEliminar,
      bool ControlFacturas,
      bool ControlDocumentos,
      bool Administracion,
      bool Timming,
      bool ServiciosCarro,
      bool Inventario,
      bool ServiciosComputo,
      bool? FacturasEmitidas,
      Guid Original_idRol)
    {
      this.Adapter.UpdateCommand.Parameters[0].Value = (object) idRol;
      this.Adapter.UpdateCommand.Parameters[1].Value = Tipo != null ? (object) Tipo : throw new ArgumentNullException(nameof (Tipo));
      this.Adapter.UpdateCommand.Parameters[2].Value = (object) idUsuarios;
      this.Adapter.UpdateCommand.Parameters[3].Value = (object) ClienteEmpresa;
      this.Adapter.UpdateCommand.Parameters[4].Value = (object) ClienteEmpresaAgregar;
      this.Adapter.UpdateCommand.Parameters[5].Value = (object) ClienteEmpresaEditar;
      this.Adapter.UpdateCommand.Parameters[6].Value = (object) ClienteEmpresaEliminar;
      this.Adapter.UpdateCommand.Parameters[7].Value = (object) ClienteContacto;
      this.Adapter.UpdateCommand.Parameters[8].Value = (object) ClienteContactoAgrear;
      this.Adapter.UpdateCommand.Parameters[9].Value = (object) ClienteContactoEditar;
      this.Adapter.UpdateCommand.Parameters[10].Value = (object) ClienteContactoEliminar;
      this.Adapter.UpdateCommand.Parameters[11].Value = (object) RFQ;
      this.Adapter.UpdateCommand.Parameters[12].Value = (object) RFQAgregar;
      this.Adapter.UpdateCommand.Parameters[13].Value = (object) RFQEditar;
      this.Adapter.UpdateCommand.Parameters[14].Value = (object) RFQEliminar;
      this.Adapter.UpdateCommand.Parameters[15].Value = (object) Cotizaciones;
      this.Adapter.UpdateCommand.Parameters[16].Value = (object) CotizacionesAgregar;
      this.Adapter.UpdateCommand.Parameters[17].Value = (object) CotizacionesEditar;
      this.Adapter.UpdateCommand.Parameters[18].Value = (object) CotizacionesEliminar;
      this.Adapter.UpdateCommand.Parameters[19].Value = (object) Materiales;
      this.Adapter.UpdateCommand.Parameters[20].Value = (object) MaterialesAgregar;
      this.Adapter.UpdateCommand.Parameters[21].Value = (object) MaterialesEditar;
      this.Adapter.UpdateCommand.Parameters[22].Value = (object) MaterialesEliminar;
      this.Adapter.UpdateCommand.Parameters[23].Value = (object) Proveedores;
      this.Adapter.UpdateCommand.Parameters[24].Value = (object) ProveedoresAgregar;
      this.Adapter.UpdateCommand.Parameters[25].Value = (object) ProveedoresEditar;
      this.Adapter.UpdateCommand.Parameters[26].Value = (object) ProveedoresEliminar;
      this.Adapter.UpdateCommand.Parameters[27].Value = (object) Requisiciones;
      this.Adapter.UpdateCommand.Parameters[28].Value = (object) RequisicionesAgregar;
      this.Adapter.UpdateCommand.Parameters[29].Value = (object) RequisicionesEditar;
      this.Adapter.UpdateCommand.Parameters[30].Value = (object) RequisicionesEliminar;
      this.Adapter.UpdateCommand.Parameters[31].Value = (object) OC;
      this.Adapter.UpdateCommand.Parameters[32].Value = (object) OCAgregar;
      this.Adapter.UpdateCommand.Parameters[33].Value = (object) OCEditar;
      this.Adapter.UpdateCommand.Parameters[34].Value = (object) OCEliminar;
      this.Adapter.UpdateCommand.Parameters[35].Value = (object) Viaticos;
      this.Adapter.UpdateCommand.Parameters[36].Value = (object) ViaticosAgregar;
      this.Adapter.UpdateCommand.Parameters[37].Value = (object) ViaticosEditar;
      this.Adapter.UpdateCommand.Parameters[38].Value = (object) ViaticosEliminar;
      this.Adapter.UpdateCommand.Parameters[39].Value = (object) Proyectos;
      this.Adapter.UpdateCommand.Parameters[40].Value = (object) ProyectosEditar;
      this.Adapter.UpdateCommand.Parameters[41].Value = (object) ProyectosEliminar;
      this.Adapter.UpdateCommand.Parameters[42].Value = (object) ProyectosAgregar;
      this.Adapter.UpdateCommand.Parameters[43].Value = (object) CajaChica;
      this.Adapter.UpdateCommand.Parameters[44].Value = (object) CajaChicaAgregar;
      this.Adapter.UpdateCommand.Parameters[45].Value = (object) CajaChicaEditar;
      this.Adapter.UpdateCommand.Parameters[46].Value = (object) CajaChicaEliminar;
      this.Adapter.UpdateCommand.Parameters[47].Value = (object) Usuarios;
      this.Adapter.UpdateCommand.Parameters[48].Value = (object) UsuariosAgregar;
      this.Adapter.UpdateCommand.Parameters[49].Value = (object) UsuariosEditar;
      this.Adapter.UpdateCommand.Parameters[50].Value = (object) UsuariosEliminar;
      this.Adapter.UpdateCommand.Parameters[51].Value = (object) Sucursales;
      this.Adapter.UpdateCommand.Parameters[52].Value = (object) SucursalesAgregar;
      this.Adapter.UpdateCommand.Parameters[53].Value = (object) SucursalesEditar;
      this.Adapter.UpdateCommand.Parameters[54].Value = (object) SucursalesEliminar;
      this.Adapter.UpdateCommand.Parameters[55].Value = (object) ControlFacturas;
      this.Adapter.UpdateCommand.Parameters[56].Value = (object) ControlDocumentos;
      this.Adapter.UpdateCommand.Parameters[57].Value = (object) Administracion;
      this.Adapter.UpdateCommand.Parameters[58].Value = (object) Timming;
      this.Adapter.UpdateCommand.Parameters[59].Value = (object) ServiciosCarro;
      this.Adapter.UpdateCommand.Parameters[60].Value = (object) Inventario;
      this.Adapter.UpdateCommand.Parameters[61].Value = (object) ServiciosComputo;
      if (FacturasEmitidas.HasValue)
        this.Adapter.UpdateCommand.Parameters[62].Value = (object) FacturasEmitidas.Value;
      else
        this.Adapter.UpdateCommand.Parameters[62].Value = (object) DBNull.Value;
      this.Adapter.UpdateCommand.Parameters[63].Value = (object) Original_idRol;
      ConnectionState state = this.Adapter.UpdateCommand.Connection.State;
      if ((this.Adapter.UpdateCommand.Connection.State & ConnectionState.Open) != ConnectionState.Open)
        this.Adapter.UpdateCommand.Connection.Open();
      try
      {
        return this.Adapter.UpdateCommand.ExecuteNonQuery();
      }
      finally
      {
        if (state == ConnectionState.Closed)
          this.Adapter.UpdateCommand.Connection.Close();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Update, true)]
    public virtual int Update(
      string Tipo,
      Guid idUsuarios,
      bool ClienteEmpresa,
      bool ClienteEmpresaAgregar,
      bool ClienteEmpresaEditar,
      bool ClienteEmpresaEliminar,
      bool ClienteContacto,
      bool ClienteContactoAgrear,
      bool ClienteContactoEditar,
      bool ClienteContactoEliminar,
      bool RFQ,
      bool RFQAgregar,
      bool RFQEditar,
      bool RFQEliminar,
      bool Cotizaciones,
      bool CotizacionesAgregar,
      bool CotizacionesEditar,
      bool CotizacionesEliminar,
      bool Materiales,
      bool MaterialesAgregar,
      bool MaterialesEditar,
      bool MaterialesEliminar,
      bool Proveedores,
      bool ProveedoresAgregar,
      bool ProveedoresEditar,
      bool ProveedoresEliminar,
      bool Requisiciones,
      bool RequisicionesAgregar,
      bool RequisicionesEditar,
      bool RequisicionesEliminar,
      bool OC,
      bool OCAgregar,
      bool OCEditar,
      bool OCEliminar,
      bool Viaticos,
      bool ViaticosAgregar,
      bool ViaticosEditar,
      bool ViaticosEliminar,
      bool Proyectos,
      bool ProyectosEditar,
      bool ProyectosEliminar,
      bool ProyectosAgregar,
      bool CajaChica,
      bool CajaChicaAgregar,
      bool CajaChicaEditar,
      bool CajaChicaEliminar,
      bool Usuarios,
      bool UsuariosAgregar,
      bool UsuariosEditar,
      bool UsuariosEliminar,
      bool Sucursales,
      bool SucursalesAgregar,
      bool SucursalesEditar,
      bool SucursalesEliminar,
      bool ControlFacturas,
      bool ControlDocumentos,
      bool Administracion,
      bool Timming,
      bool ServiciosCarro,
      bool Inventario,
      bool ServiciosComputo,
      bool? FacturasEmitidas,
      Guid Original_idRol)
    {
      return this.Update(Original_idRol, Tipo, idUsuarios, ClienteEmpresa, ClienteEmpresaAgregar, ClienteEmpresaEditar, ClienteEmpresaEliminar, ClienteContacto, ClienteContactoAgrear, ClienteContactoEditar, ClienteContactoEliminar, RFQ, RFQAgregar, RFQEditar, RFQEliminar, Cotizaciones, CotizacionesAgregar, CotizacionesEditar, CotizacionesEliminar, Materiales, MaterialesAgregar, MaterialesEditar, MaterialesEliminar, Proveedores, ProveedoresAgregar, ProveedoresEditar, ProveedoresEliminar, Requisiciones, RequisicionesAgregar, RequisicionesEditar, RequisicionesEliminar, OC, OCAgregar, OCEditar, OCEliminar, Viaticos, ViaticosAgregar, ViaticosEditar, ViaticosEliminar, Proyectos, ProyectosEditar, ProyectosEliminar, ProyectosAgregar, CajaChica, CajaChicaAgregar, CajaChicaEditar, CajaChicaEliminar, Usuarios, UsuariosAgregar, UsuariosEditar, UsuariosEliminar, Sucursales, SucursalesAgregar, SucursalesEditar, SucursalesEliminar, ControlFacturas, ControlDocumentos, Administracion, Timming, ServiciosCarro, Inventario, ServiciosComputo, FacturasEmitidas, Original_idRol);
    }
  }
}
