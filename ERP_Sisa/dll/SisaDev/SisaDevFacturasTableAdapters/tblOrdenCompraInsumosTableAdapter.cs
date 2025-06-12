// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDevFacturasTableAdapters.tblOrdenCompraInsumosTableAdapter
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
  public class tblOrdenCompraInsumosTableAdapter : Component
  {
    private SqlDataAdapter _adapter;
    private SqlConnection _connection;
    private SqlTransaction _transaction;
    private SqlCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public tblOrdenCompraInsumosTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblOrdenCompraInsumos",
        ColumnMappings = {
          {
            "IdOrdenCompra",
            "IdOrdenCompra"
          },
          {
            "Folio",
            "Folio"
          },
          {
            "IdProveedor",
            "IdProveedor"
          },
          {
            "ReferenciaCot",
            "ReferenciaCot"
          },
          {
            "IdProyecto",
            "IdProyecto"
          },
          {
            "IdUsuario",
            "IdUsuario"
          },
          {
            "SubTotal",
            "SubTotal"
          },
          {
            "Iva",
            "Iva"
          },
          {
            "Total",
            "Total"
          },
          {
            "Estatus",
            "Estatus"
          },
          {
            "Enviada",
            "Enviada"
          },
          {
            "EnviarA",
            "EnviarA"
          },
          {
            "IdMoneda",
            "IdMoneda"
          },
          {
            "CondicionPago",
            "CondicionPago"
          },
          {
            "Comentarios",
            "Comentarios"
          },
          {
            "FechaCreacion",
            "FechaCreacion"
          },
          {
            "IdUsuarioCreacion",
            "IdUsuarioCreacion"
          },
          {
            "FechaModificacion",
            "FechaModificacion"
          },
          {
            "IdUsuarioModificacion",
            "IdUsuarioModificacion"
          },
          {
            "FechaCancelacion",
            "FechaCancelacion"
          },
          {
            "IdUsuarioCancelacion",
            "IdUsuarioCancelacion"
          },
          {
            "MotivoCancelacion",
            "MotivoCancelacion"
          },
          {
            "Descuento",
            "Descuento"
          },
          {
            "IdUsuarioAprobo",
            "IdUsuarioAprobo"
          },
          {
            "idSucursal",
            "idSucursal"
          }
        }
      });
      this._adapter.DeleteCommand = new SqlCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[tblOrdenCompraInsumos] WHERE (([IdOrdenCompra] = @Original_IdOrdenCompra))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_IdOrdenCompra", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdOrdenCompra", DataRowVersion.Original, false, (object) null, "", "", ""));
      this._adapter.InsertCommand = new SqlCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[tblOrdenCompraInsumos] ([IdOrdenCompra], [Folio], [IdProveedor], [ReferenciaCot], [IdProyecto], [IdUsuario], [SubTotal], [Iva], [Estatus], [Enviada], [EnviarA], [IdMoneda], [CondicionPago], [Comentarios], [FechaCreacion], [IdUsuarioCreacion], [FechaModificacion], [IdUsuarioModificacion], [FechaCancelacion], [IdUsuarioCancelacion], [MotivoCancelacion], [Descuento], [IdUsuarioAprobo], [idSucursal]) VALUES (@IdOrdenCompra, @Folio, @IdProveedor, @ReferenciaCot, @IdProyecto, @IdUsuario, @SubTotal, @Iva, @Estatus, @Enviada, @EnviarA, @IdMoneda, @CondicionPago, @Comentarios, @FechaCreacion, @IdUsuarioCreacion, @FechaModificacion, @IdUsuarioModificacion, @FechaCancelacion, @IdUsuarioCancelacion, @MotivoCancelacion, @Descuento, @IdUsuarioAprobo, @idSucursal)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdOrdenCompra", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdOrdenCompra", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Folio", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Folio", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdProveedor", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdProveedor", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ReferenciaCot", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ReferenciaCot", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdProyecto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuario", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@SubTotal", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "SubTotal", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Iva", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Iva", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Estatus", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Enviada", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Enviada", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@EnviarA", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EnviarA", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdMoneda", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdMoneda", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@CondicionPago", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CondicionPago", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Comentarios", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Comentarios", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaCreacion", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaCreacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuarioCreacion", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioCreacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaModificacion", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuarioModificacion", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaCancelacion", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaCancelacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuarioCancelacion", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioCancelacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@MotivoCancelacion", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MotivoCancelacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Descuento", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Descuento", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuarioAprobo", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioAprobo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@idSucursal", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "idSucursal", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand = new SqlCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[tblOrdenCompraInsumos] SET [IdOrdenCompra] = @IdOrdenCompra, [Folio] = @Folio, [IdProveedor] = @IdProveedor, [ReferenciaCot] = @ReferenciaCot, [IdProyecto] = @IdProyecto, [IdUsuario] = @IdUsuario, [SubTotal] = @SubTotal, [Iva] = @Iva, [Estatus] = @Estatus, [Enviada] = @Enviada, [EnviarA] = @EnviarA, [IdMoneda] = @IdMoneda, [CondicionPago] = @CondicionPago, [Comentarios] = @Comentarios, [FechaCreacion] = @FechaCreacion, [IdUsuarioCreacion] = @IdUsuarioCreacion, [FechaModificacion] = @FechaModificacion, [IdUsuarioModificacion] = @IdUsuarioModificacion, [FechaCancelacion] = @FechaCancelacion, [IdUsuarioCancelacion] = @IdUsuarioCancelacion, [MotivoCancelacion] = @MotivoCancelacion, [Descuento] = @Descuento, [IdUsuarioAprobo] = @IdUsuarioAprobo, [idSucursal] = @idSucursal WHERE (([IdOrdenCompra] = @Original_IdOrdenCompra))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdOrdenCompra", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdOrdenCompra", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Folio", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Folio", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdProveedor", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdProveedor", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ReferenciaCot", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ReferenciaCot", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdProyecto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuario", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@SubTotal", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "SubTotal", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Iva", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Iva", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Estatus", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Enviada", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Enviada", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@EnviarA", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EnviarA", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdMoneda", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdMoneda", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CondicionPago", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CondicionPago", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Comentarios", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Comentarios", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaCreacion", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaCreacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdUsuarioCreacion", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioCreacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaModificacion", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdUsuarioModificacion", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaCancelacion", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaCancelacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdUsuarioCancelacion", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioCancelacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@MotivoCancelacion", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MotivoCancelacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Descuento", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Descuento", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdUsuarioAprobo", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioAprobo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@idSucursal", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "idSucursal", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_IdOrdenCompra", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdOrdenCompra", DataRowVersion.Original, false, (object) null, "", "", ""));
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
      this._commandCollection[0].CommandText = "SELECT IdOrdenCompra, Folio, IdProveedor, ReferenciaCot, IdProyecto, IdUsuario, SubTotal, Iva, Total, Estatus, Enviada, EnviarA, IdMoneda, CondicionPago, Comentarios, FechaCreacion, IdUsuarioCreacion, FechaModificacion, IdUsuarioModificacion, FechaCancelacion, IdUsuarioCancelacion, MotivoCancelacion, Descuento, IdUsuarioAprobo, idSucursal FROM dbo.tblOrdenCompraInsumos";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(
      SisaDevFacturas.tblOrdenCompraInsumosDataTable dataTable)
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
    public virtual SisaDevFacturas.tblOrdenCompraInsumosDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      SisaDevFacturas.tblOrdenCompraInsumosDataTable insumosDataTable = new SisaDevFacturas.tblOrdenCompraInsumosDataTable();
      this.Adapter.Fill((DataTable) insumosDataTable);
      return insumosDataTable;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(
      SisaDevFacturas.tblOrdenCompraInsumosDataTable dataTable)
    {
      return this.Adapter.Update((DataTable) dataTable);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas dataSet) => this.Adapter.Update((DataSet) dataSet, "tblOrdenCompraInsumos");

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
    public virtual int Delete(Guid Original_IdOrdenCompra)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) Original_IdOrdenCompra;
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
      Guid IdOrdenCompra,
      string Folio,
      Guid IdProveedor,
      string ReferenciaCot,
      string IdProyecto,
      Guid IdUsuario,
      Decimal SubTotal,
      Decimal Iva,
      int Estatus,
      int Enviada,
      string EnviarA,
      Guid IdMoneda,
      string CondicionPago,
      string Comentarios,
      DateTime FechaCreacion,
      Guid IdUsuarioCreacion,
      DateTime FechaModificacion,
      Guid IdUsuarioModificacion,
      DateTime? FechaCancelacion,
      string IdUsuarioCancelacion,
      string MotivoCancelacion,
      Decimal? Descuento,
      Guid? IdUsuarioAprobo,
      Guid? idSucursal)
    {
      this.Adapter.InsertCommand.Parameters[0].Value = (object) IdOrdenCompra;
      this.Adapter.InsertCommand.Parameters[1].Value = Folio != null ? (object) Folio : throw new ArgumentNullException(nameof (Folio));
      this.Adapter.InsertCommand.Parameters[2].Value = (object) IdProveedor;
      this.Adapter.InsertCommand.Parameters[3].Value = ReferenciaCot != null ? (object) ReferenciaCot : throw new ArgumentNullException(nameof (ReferenciaCot));
      this.Adapter.InsertCommand.Parameters[4].Value = IdProyecto != null ? (object) IdProyecto : throw new ArgumentNullException(nameof (IdProyecto));
      this.Adapter.InsertCommand.Parameters[5].Value = (object) IdUsuario;
      this.Adapter.InsertCommand.Parameters[6].Value = (object) SubTotal;
      this.Adapter.InsertCommand.Parameters[7].Value = (object) Iva;
      this.Adapter.InsertCommand.Parameters[8].Value = (object) Estatus;
      this.Adapter.InsertCommand.Parameters[9].Value = (object) Enviada;
      this.Adapter.InsertCommand.Parameters[10].Value = EnviarA != null ? (object) EnviarA : throw new ArgumentNullException(nameof (EnviarA));
      this.Adapter.InsertCommand.Parameters[11].Value = (object) IdMoneda;
      this.Adapter.InsertCommand.Parameters[12].Value = CondicionPago != null ? (object) CondicionPago : throw new ArgumentNullException(nameof (CondicionPago));
      this.Adapter.InsertCommand.Parameters[13].Value = Comentarios != null ? (object) Comentarios : throw new ArgumentNullException(nameof (Comentarios));
      this.Adapter.InsertCommand.Parameters[14].Value = (object) FechaCreacion;
      this.Adapter.InsertCommand.Parameters[15].Value = (object) IdUsuarioCreacion;
      this.Adapter.InsertCommand.Parameters[16].Value = (object) FechaModificacion;
      this.Adapter.InsertCommand.Parameters[17].Value = (object) IdUsuarioModificacion;
      if (FechaCancelacion.HasValue)
        this.Adapter.InsertCommand.Parameters[18].Value = (object) FechaCancelacion.Value;
      else
        this.Adapter.InsertCommand.Parameters[18].Value = (object) DBNull.Value;
      if (IdUsuarioCancelacion == null)
        this.Adapter.InsertCommand.Parameters[19].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[19].Value = (object) IdUsuarioCancelacion;
      if (MotivoCancelacion == null)
        this.Adapter.InsertCommand.Parameters[20].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[20].Value = (object) MotivoCancelacion;
      if (Descuento.HasValue)
        this.Adapter.InsertCommand.Parameters[21].Value = (object) Descuento.Value;
      else
        this.Adapter.InsertCommand.Parameters[21].Value = (object) DBNull.Value;
      if (IdUsuarioAprobo.HasValue)
        this.Adapter.InsertCommand.Parameters[22].Value = (object) IdUsuarioAprobo.Value;
      else
        this.Adapter.InsertCommand.Parameters[22].Value = (object) DBNull.Value;
      if (idSucursal.HasValue)
        this.Adapter.InsertCommand.Parameters[23].Value = (object) idSucursal.Value;
      else
        this.Adapter.InsertCommand.Parameters[23].Value = (object) DBNull.Value;
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
      Guid IdOrdenCompra,
      string Folio,
      Guid IdProveedor,
      string ReferenciaCot,
      string IdProyecto,
      Guid IdUsuario,
      Decimal SubTotal,
      Decimal Iva,
      int Estatus,
      int Enviada,
      string EnviarA,
      Guid IdMoneda,
      string CondicionPago,
      string Comentarios,
      DateTime FechaCreacion,
      Guid IdUsuarioCreacion,
      DateTime FechaModificacion,
      Guid IdUsuarioModificacion,
      DateTime? FechaCancelacion,
      string IdUsuarioCancelacion,
      string MotivoCancelacion,
      Decimal? Descuento,
      Guid? IdUsuarioAprobo,
      Guid? idSucursal,
      Guid Original_IdOrdenCompra)
    {
      this.Adapter.UpdateCommand.Parameters[0].Value = (object) IdOrdenCompra;
      this.Adapter.UpdateCommand.Parameters[1].Value = Folio != null ? (object) Folio : throw new ArgumentNullException(nameof (Folio));
      this.Adapter.UpdateCommand.Parameters[2].Value = (object) IdProveedor;
      this.Adapter.UpdateCommand.Parameters[3].Value = ReferenciaCot != null ? (object) ReferenciaCot : throw new ArgumentNullException(nameof (ReferenciaCot));
      this.Adapter.UpdateCommand.Parameters[4].Value = IdProyecto != null ? (object) IdProyecto : throw new ArgumentNullException(nameof (IdProyecto));
      this.Adapter.UpdateCommand.Parameters[5].Value = (object) IdUsuario;
      this.Adapter.UpdateCommand.Parameters[6].Value = (object) SubTotal;
      this.Adapter.UpdateCommand.Parameters[7].Value = (object) Iva;
      this.Adapter.UpdateCommand.Parameters[8].Value = (object) Estatus;
      this.Adapter.UpdateCommand.Parameters[9].Value = (object) Enviada;
      this.Adapter.UpdateCommand.Parameters[10].Value = EnviarA != null ? (object) EnviarA : throw new ArgumentNullException(nameof (EnviarA));
      this.Adapter.UpdateCommand.Parameters[11].Value = (object) IdMoneda;
      this.Adapter.UpdateCommand.Parameters[12].Value = CondicionPago != null ? (object) CondicionPago : throw new ArgumentNullException(nameof (CondicionPago));
      this.Adapter.UpdateCommand.Parameters[13].Value = Comentarios != null ? (object) Comentarios : throw new ArgumentNullException(nameof (Comentarios));
      this.Adapter.UpdateCommand.Parameters[14].Value = (object) FechaCreacion;
      this.Adapter.UpdateCommand.Parameters[15].Value = (object) IdUsuarioCreacion;
      this.Adapter.UpdateCommand.Parameters[16].Value = (object) FechaModificacion;
      this.Adapter.UpdateCommand.Parameters[17].Value = (object) IdUsuarioModificacion;
      if (FechaCancelacion.HasValue)
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) FechaCancelacion.Value;
      else
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) DBNull.Value;
      if (IdUsuarioCancelacion == null)
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) IdUsuarioCancelacion;
      if (MotivoCancelacion == null)
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) MotivoCancelacion;
      if (Descuento.HasValue)
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) Descuento.Value;
      else
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) DBNull.Value;
      if (IdUsuarioAprobo.HasValue)
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) IdUsuarioAprobo.Value;
      else
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) DBNull.Value;
      if (idSucursal.HasValue)
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) idSucursal.Value;
      else
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) DBNull.Value;
      this.Adapter.UpdateCommand.Parameters[24].Value = (object) Original_IdOrdenCompra;
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
      string Folio,
      Guid IdProveedor,
      string ReferenciaCot,
      string IdProyecto,
      Guid IdUsuario,
      Decimal SubTotal,
      Decimal Iva,
      int Estatus,
      int Enviada,
      string EnviarA,
      Guid IdMoneda,
      string CondicionPago,
      string Comentarios,
      DateTime FechaCreacion,
      Guid IdUsuarioCreacion,
      DateTime FechaModificacion,
      Guid IdUsuarioModificacion,
      DateTime? FechaCancelacion,
      string IdUsuarioCancelacion,
      string MotivoCancelacion,
      Decimal? Descuento,
      Guid? IdUsuarioAprobo,
      Guid? idSucursal,
      Guid Original_IdOrdenCompra)
    {
      return this.Update(Original_IdOrdenCompra, Folio, IdProveedor, ReferenciaCot, IdProyecto, IdUsuario, SubTotal, Iva, Estatus, Enviada, EnviarA, IdMoneda, CondicionPago, Comentarios, FechaCreacion, IdUsuarioCreacion, FechaModificacion, IdUsuarioModificacion, FechaCancelacion, IdUsuarioCancelacion, MotivoCancelacion, Descuento, IdUsuarioAprobo, idSucursal, Original_IdOrdenCompra);
    }
  }
}
