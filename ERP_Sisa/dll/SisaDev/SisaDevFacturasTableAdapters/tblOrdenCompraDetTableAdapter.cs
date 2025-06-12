// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDevFacturasTableAdapters.tblOrdenCompraDetTableAdapter
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
  public class tblOrdenCompraDetTableAdapter : Component
  {
    private SqlDataAdapter _adapter;
    private SqlConnection _connection;
    private SqlTransaction _transaction;
    private SqlCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public tblOrdenCompraDetTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblOrdenCompraDet",
        ColumnMappings = {
          {
            "IdOrdenCompraDet",
            "IdOrdenCompraDet"
          },
          {
            "IdOrdenCompra",
            "IdOrdenCompra"
          },
          {
            "Item",
            "Item"
          },
          {
            "Codigo",
            "Codigo"
          },
          {
            "Descripcion",
            "Descripcion"
          },
          {
            "Comentarios",
            "Comentarios"
          },
          {
            "Cantidad",
            "Cantidad"
          },
          {
            "Unidad",
            "Unidad"
          },
          {
            "Precio",
            "Precio"
          },
          {
            "Importe",
            "Importe"
          },
          {
            "TiempoEntrega",
            "TiempoEntrega"
          },
          {
            "CantidadRecibida",
            "CantidadRecibida"
          },
          {
            "FechaRecibida",
            "FechaRecibida"
          }
        }
      });
      this._adapter.DeleteCommand = new SqlCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[tblOrdenCompraDet] WHERE (([IdOrdenCompraDet] = @Original_IdOrdenCompraDet))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_IdOrdenCompraDet", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdOrdenCompraDet", DataRowVersion.Original, false, (object) null, "", "", ""));
      this._adapter.InsertCommand = new SqlCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[tblOrdenCompraDet] ([IdOrdenCompraDet], [IdOrdenCompra], [Item], [Codigo], [Descripcion], [Comentarios], [Cantidad], [Unidad], [Precio], [Importe], [TiempoEntrega], [CantidadRecibida], [FechaRecibida]) VALUES (@IdOrdenCompraDet, @IdOrdenCompra, @Item, @Codigo, @Descripcion, @Comentarios, @Cantidad, @Unidad, @Precio, @Importe, @TiempoEntrega, @CantidadRecibida, @FechaRecibida)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdOrdenCompraDet", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdOrdenCompraDet", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdOrdenCompra", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdOrdenCompra", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Item", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Item", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Codigo", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Codigo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Descripcion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Comentarios", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Comentarios", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Cantidad", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Cantidad", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Unidad", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Unidad", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Precio", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Precio", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Importe", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Importe", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@TiempoEntrega", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TiempoEntrega", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@CantidadRecibida", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "CantidadRecibida", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaRecibida", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaRecibida", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand = new SqlCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[tblOrdenCompraDet] SET [IdOrdenCompraDet] = @IdOrdenCompraDet, [IdOrdenCompra] = @IdOrdenCompra, [Item] = @Item, [Codigo] = @Codigo, [Descripcion] = @Descripcion, [Comentarios] = @Comentarios, [Cantidad] = @Cantidad, [Unidad] = @Unidad, [Precio] = @Precio, [Importe] = @Importe, [TiempoEntrega] = @TiempoEntrega, [CantidadRecibida] = @CantidadRecibida, [FechaRecibida] = @FechaRecibida WHERE (([IdOrdenCompraDet] = @Original_IdOrdenCompraDet))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdOrdenCompraDet", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdOrdenCompraDet", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdOrdenCompra", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdOrdenCompra", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Item", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Item", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Codigo", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Codigo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Descripcion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Comentarios", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Comentarios", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Cantidad", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Cantidad", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Unidad", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Unidad", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Precio", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Precio", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Importe", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Importe", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@TiempoEntrega", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TiempoEntrega", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CantidadRecibida", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "CantidadRecibida", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaRecibida", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaRecibida", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_IdOrdenCompraDet", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdOrdenCompraDet", DataRowVersion.Original, false, (object) null, "", "", ""));
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
      this._commandCollection[0].CommandText = "SELECT IdOrdenCompraDet, IdOrdenCompra, Item, Codigo, Descripcion, Comentarios, Cantidad, Unidad, Precio, Importe, TiempoEntrega, CantidadRecibida, FechaRecibida FROM dbo.tblOrdenCompraDet";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(
      SisaDevFacturas.tblOrdenCompraDetDataTable dataTable)
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
    public virtual SisaDevFacturas.tblOrdenCompraDetDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      SisaDevFacturas.tblOrdenCompraDetDataTable compraDetDataTable = new SisaDevFacturas.tblOrdenCompraDetDataTable();
      this.Adapter.Fill((DataTable) compraDetDataTable);
      return compraDetDataTable;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(
      SisaDevFacturas.tblOrdenCompraDetDataTable dataTable)
    {
      return this.Adapter.Update((DataTable) dataTable);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas dataSet) => this.Adapter.Update((DataSet) dataSet, "tblOrdenCompraDet");

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
    public virtual int Delete(Guid Original_IdOrdenCompraDet)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) Original_IdOrdenCompraDet;
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
      Guid IdOrdenCompraDet,
      Guid IdOrdenCompra,
      int Item,
      string Codigo,
      string Descripcion,
      string Comentarios,
      Decimal Cantidad,
      string Unidad,
      Decimal Precio,
      Decimal Importe,
      string TiempoEntrega,
      Decimal CantidadRecibida,
      DateTime? FechaRecibida)
    {
      this.Adapter.InsertCommand.Parameters[0].Value = (object) IdOrdenCompraDet;
      this.Adapter.InsertCommand.Parameters[1].Value = (object) IdOrdenCompra;
      this.Adapter.InsertCommand.Parameters[2].Value = (object) Item;
      this.Adapter.InsertCommand.Parameters[3].Value = Codigo != null ? (object) Codigo : throw new ArgumentNullException(nameof (Codigo));
      this.Adapter.InsertCommand.Parameters[4].Value = Descripcion != null ? (object) Descripcion : throw new ArgumentNullException(nameof (Descripcion));
      if (Comentarios == null)
        this.Adapter.InsertCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[5].Value = (object) Comentarios;
      this.Adapter.InsertCommand.Parameters[6].Value = (object) Cantidad;
      this.Adapter.InsertCommand.Parameters[7].Value = Unidad != null ? (object) Unidad : throw new ArgumentNullException(nameof (Unidad));
      this.Adapter.InsertCommand.Parameters[8].Value = (object) Precio;
      this.Adapter.InsertCommand.Parameters[9].Value = (object) Importe;
      if (TiempoEntrega == null)
        this.Adapter.InsertCommand.Parameters[10].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[10].Value = (object) TiempoEntrega;
      this.Adapter.InsertCommand.Parameters[11].Value = (object) CantidadRecibida;
      if (FechaRecibida.HasValue)
        this.Adapter.InsertCommand.Parameters[12].Value = (object) FechaRecibida.Value;
      else
        this.Adapter.InsertCommand.Parameters[12].Value = (object) DBNull.Value;
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
      Guid IdOrdenCompraDet,
      Guid IdOrdenCompra,
      int Item,
      string Codigo,
      string Descripcion,
      string Comentarios,
      Decimal Cantidad,
      string Unidad,
      Decimal Precio,
      Decimal Importe,
      string TiempoEntrega,
      Decimal CantidadRecibida,
      DateTime? FechaRecibida,
      Guid Original_IdOrdenCompraDet)
    {
      this.Adapter.UpdateCommand.Parameters[0].Value = (object) IdOrdenCompraDet;
      this.Adapter.UpdateCommand.Parameters[1].Value = (object) IdOrdenCompra;
      this.Adapter.UpdateCommand.Parameters[2].Value = (object) Item;
      this.Adapter.UpdateCommand.Parameters[3].Value = Codigo != null ? (object) Codigo : throw new ArgumentNullException(nameof (Codigo));
      this.Adapter.UpdateCommand.Parameters[4].Value = Descripcion != null ? (object) Descripcion : throw new ArgumentNullException(nameof (Descripcion));
      if (Comentarios == null)
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) Comentarios;
      this.Adapter.UpdateCommand.Parameters[6].Value = (object) Cantidad;
      this.Adapter.UpdateCommand.Parameters[7].Value = Unidad != null ? (object) Unidad : throw new ArgumentNullException(nameof (Unidad));
      this.Adapter.UpdateCommand.Parameters[8].Value = (object) Precio;
      this.Adapter.UpdateCommand.Parameters[9].Value = (object) Importe;
      if (TiempoEntrega == null)
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) TiempoEntrega;
      this.Adapter.UpdateCommand.Parameters[11].Value = (object) CantidadRecibida;
      if (FechaRecibida.HasValue)
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) FechaRecibida.Value;
      else
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) DBNull.Value;
      this.Adapter.UpdateCommand.Parameters[13].Value = (object) Original_IdOrdenCompraDet;
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
      Guid IdOrdenCompra,
      int Item,
      string Codigo,
      string Descripcion,
      string Comentarios,
      Decimal Cantidad,
      string Unidad,
      Decimal Precio,
      Decimal Importe,
      string TiempoEntrega,
      Decimal CantidadRecibida,
      DateTime? FechaRecibida,
      Guid Original_IdOrdenCompraDet)
    {
      return this.Update(Original_IdOrdenCompraDet, IdOrdenCompra, Item, Codigo, Descripcion, Comentarios, Cantidad, Unidad, Precio, Importe, TiempoEntrega, CantidadRecibida, FechaRecibida, Original_IdOrdenCompraDet);
    }
  }
}
