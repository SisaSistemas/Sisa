// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDev_UsuarioTableAdapters.tblSucursalesTableAdapter
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

namespace SisaDev.SisaDev_UsuarioTableAdapters
{
  [DesignerCategory("code")]
  [ToolboxItem(true)]
  [DataObject(true)]
  [Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
  [HelpKeyword("vs.data.TableAdapter")]
  public class tblSucursalesTableAdapter : Component
  {
    private SqlDataAdapter _adapter;
    private SqlConnection _connection;
    private SqlTransaction _transaction;
    private SqlCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public tblSucursalesTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblSucursales",
        ColumnMappings = {
          {
            "idSucursa",
            "idSucursa"
          },
          {
            "CiudadSucursal",
            "CiudadSucursal"
          },
          {
            "DireccionSucursal",
            "DireccionSucursal"
          },
          {
            "TelefonoSucursal",
            "TelefonoSucursal"
          },
          {
            "TIMESTAMP",
            "TIMESTAMP"
          },
          {
            "Estatus",
            "Estatus"
          },
          {
            "Gerente",
            "Gerente"
          }
        }
      });
      this._adapter.DeleteCommand = new SqlCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[tblSucursales] WHERE (([idSucursa] = @Original_idSucursa))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_idSucursa", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "idSucursa", DataRowVersion.Original, false, (object) null, "", "", ""));
      this._adapter.InsertCommand = new SqlCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[tblSucursales] ([idSucursa], [CiudadSucursal], [DireccionSucursal], [TelefonoSucursal], [TIMESTAMP], [Estatus], [Gerente]) VALUES (@idSucursa, @CiudadSucursal, @DireccionSucursal, @TelefonoSucursal, @TIMESTAMP, @Estatus, @Gerente)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@idSucursa", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "idSucursa", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@CiudadSucursal", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CiudadSucursal", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@DireccionSucursal", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DireccionSucursal", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@TelefonoSucursal", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TelefonoSucursal", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@TIMESTAMP", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TIMESTAMP", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Estatus", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Gerente", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Gerente", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand = new SqlCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[tblSucursales] SET [idSucursa] = @idSucursa, [CiudadSucursal] = @CiudadSucursal, [DireccionSucursal] = @DireccionSucursal, [TelefonoSucursal] = @TelefonoSucursal, [TIMESTAMP] = @TIMESTAMP, [Estatus] = @Estatus, [Gerente] = @Gerente WHERE (([idSucursa] = @Original_idSucursa))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@idSucursa", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "idSucursa", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CiudadSucursal", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CiudadSucursal", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@DireccionSucursal", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DireccionSucursal", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@TelefonoSucursal", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TelefonoSucursal", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@TIMESTAMP", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TIMESTAMP", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Estatus", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Gerente", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Gerente", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_idSucursa", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "idSucursa", DataRowVersion.Original, false, (object) null, "", "", ""));
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
      this._commandCollection[0].CommandText = "SELECT idSucursa, CiudadSucursal, DireccionSucursal, TelefonoSucursal, TIMESTAMP, Estatus, Gerente FROM dbo.tblSucursales";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(SisaDev_Usuario.tblSucursalesDataTable dataTable)
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
    public virtual SisaDev_Usuario.tblSucursalesDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      SisaDev_Usuario.tblSucursalesDataTable sucursalesDataTable = new SisaDev_Usuario.tblSucursalesDataTable();
      this.Adapter.Fill((DataTable) sucursalesDataTable);
      return sucursalesDataTable;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDev_Usuario.tblSucursalesDataTable dataTable) => this.Adapter.Update((DataTable) dataTable);

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDev_Usuario dataSet) => this.Adapter.Update((DataSet) dataSet, "tblSucursales");

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
    public virtual int Delete(Guid Original_idSucursa)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) Original_idSucursa;
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
      Guid idSucursa,
      string CiudadSucursal,
      string DireccionSucursal,
      string TelefonoSucursal,
      DateTime? TIMESTAMP,
      bool? Estatus,
      string Gerente)
    {
      this.Adapter.InsertCommand.Parameters[0].Value = (object) idSucursa;
      this.Adapter.InsertCommand.Parameters[1].Value = CiudadSucursal != null ? (object) CiudadSucursal : throw new ArgumentNullException(nameof (CiudadSucursal));
      this.Adapter.InsertCommand.Parameters[2].Value = DireccionSucursal != null ? (object) DireccionSucursal : throw new ArgumentNullException(nameof (DireccionSucursal));
      this.Adapter.InsertCommand.Parameters[3].Value = TelefonoSucursal != null ? (object) TelefonoSucursal : throw new ArgumentNullException(nameof (TelefonoSucursal));
      if (TIMESTAMP.HasValue)
        this.Adapter.InsertCommand.Parameters[4].Value = (object) TIMESTAMP.Value;
      else
        this.Adapter.InsertCommand.Parameters[4].Value = (object) DBNull.Value;
      if (Estatus.HasValue)
        this.Adapter.InsertCommand.Parameters[5].Value = (object) Estatus.Value;
      else
        this.Adapter.InsertCommand.Parameters[5].Value = (object) DBNull.Value;
      if (Gerente == null)
        this.Adapter.InsertCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[6].Value = (object) Gerente;
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
      Guid idSucursa,
      string CiudadSucursal,
      string DireccionSucursal,
      string TelefonoSucursal,
      DateTime? TIMESTAMP,
      bool? Estatus,
      string Gerente,
      Guid Original_idSucursa)
    {
      this.Adapter.UpdateCommand.Parameters[0].Value = (object) idSucursa;
      this.Adapter.UpdateCommand.Parameters[1].Value = CiudadSucursal != null ? (object) CiudadSucursal : throw new ArgumentNullException(nameof (CiudadSucursal));
      this.Adapter.UpdateCommand.Parameters[2].Value = DireccionSucursal != null ? (object) DireccionSucursal : throw new ArgumentNullException(nameof (DireccionSucursal));
      this.Adapter.UpdateCommand.Parameters[3].Value = TelefonoSucursal != null ? (object) TelefonoSucursal : throw new ArgumentNullException(nameof (TelefonoSucursal));
      if (TIMESTAMP.HasValue)
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) TIMESTAMP.Value;
      else
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) DBNull.Value;
      if (Estatus.HasValue)
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) Estatus.Value;
      else
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) DBNull.Value;
      if (Gerente == null)
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) Gerente;
      this.Adapter.UpdateCommand.Parameters[7].Value = (object) Original_idSucursa;
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
      string CiudadSucursal,
      string DireccionSucursal,
      string TelefonoSucursal,
      DateTime? TIMESTAMP,
      bool? Estatus,
      string Gerente,
      Guid Original_idSucursa)
    {
      return this.Update(Original_idSucursa, CiudadSucursal, DireccionSucursal, TelefonoSucursal, TIMESTAMP, Estatus, Gerente, Original_idSucursa);
    }
  }
}
