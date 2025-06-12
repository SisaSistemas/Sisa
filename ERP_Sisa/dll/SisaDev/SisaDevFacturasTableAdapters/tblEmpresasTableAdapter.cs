// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDevFacturasTableAdapters.tblEmpresasTableAdapter
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
  public class tblEmpresasTableAdapter : Component
  {
    private SqlDataAdapter _adapter;
    private SqlConnection _connection;
    private SqlTransaction _transaction;
    private SqlCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public tblEmpresasTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblEmpresas",
        ColumnMappings = {
          {
            "idEmpresa",
            "idEmpresa"
          },
          {
            "RazonSocial",
            "RazonSocial"
          },
          {
            "DireccionFiscal",
            "DireccionFiscal"
          },
          {
            "Telefono",
            "Telefono"
          },
          {
            "TIMESTAMP",
            "TIMESTAMP"
          },
          {
            "RFC",
            "RFC"
          },
          {
            "Correo",
            "Correo"
          },
          {
            "CP",
            "CP"
          },
          {
            "Ciudad",
            "Ciudad"
          },
          {
            "Estatus",
            "Estatus"
          },
          {
            "idSucursalRegistro",
            "idSucursalRegistro"
          }
        }
      });
      this._adapter.DeleteCommand = new SqlCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[tblEmpresas] WHERE (([idEmpresa] = @Original_idEmpresa))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_idEmpresa", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "idEmpresa", DataRowVersion.Original, false, (object) null, "", "", ""));
      this._adapter.InsertCommand = new SqlCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[tblEmpresas] ([idEmpresa], [RazonSocial], [DireccionFiscal], [Telefono], [TIMESTAMP], [RFC], [Correo], [CP], [Ciudad], [Estatus], [idSucursalRegistro]) VALUES (@idEmpresa, @RazonSocial, @DireccionFiscal, @Telefono, @TIMESTAMP, @RFC, @Correo, @CP, @Ciudad, @Estatus, @idSucursalRegistro)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@idEmpresa", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "idEmpresa", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@RazonSocial", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RazonSocial", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@DireccionFiscal", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DireccionFiscal", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Telefono", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Telefono", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@TIMESTAMP", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TIMESTAMP", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@RFC", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RFC", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Correo", SqlDbType.NVarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Correo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@CP", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CP", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Ciudad", SqlDbType.NVarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Ciudad", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Estatus", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@idSucursalRegistro", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "idSucursalRegistro", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand = new SqlCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[tblEmpresas] SET [idEmpresa] = @idEmpresa, [RazonSocial] = @RazonSocial, [DireccionFiscal] = @DireccionFiscal, [Telefono] = @Telefono, [TIMESTAMP] = @TIMESTAMP, [RFC] = @RFC, [Correo] = @Correo, [CP] = @CP, [Ciudad] = @Ciudad, [Estatus] = @Estatus, [idSucursalRegistro] = @idSucursalRegistro WHERE (([idEmpresa] = @Original_idEmpresa))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@idEmpresa", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "idEmpresa", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@RazonSocial", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RazonSocial", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@DireccionFiscal", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DireccionFiscal", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Telefono", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Telefono", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@TIMESTAMP", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TIMESTAMP", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@RFC", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RFC", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Correo", SqlDbType.NVarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Correo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CP", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CP", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Ciudad", SqlDbType.NVarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Ciudad", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Bit, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Estatus", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@idSucursalRegistro", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "idSucursalRegistro", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_idEmpresa", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "idEmpresa", DataRowVersion.Original, false, (object) null, "", "", ""));
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
      this._commandCollection[0].CommandText = "SELECT idEmpresa, RazonSocial, DireccionFiscal, Telefono, TIMESTAMP, RFC, Correo, CP, Ciudad, Estatus, idSucursalRegistro FROM dbo.tblEmpresas";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(SisaDevFacturas.tblEmpresasDataTable dataTable)
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
    public virtual SisaDevFacturas.tblEmpresasDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      SisaDevFacturas.tblEmpresasDataTable empresasDataTable = new SisaDevFacturas.tblEmpresasDataTable();
      this.Adapter.Fill((DataTable) empresasDataTable);
      return empresasDataTable;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas.tblEmpresasDataTable dataTable) => this.Adapter.Update((DataTable) dataTable);

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas dataSet) => this.Adapter.Update((DataSet) dataSet, "tblEmpresas");

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
    public virtual int Delete(Guid Original_idEmpresa)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) Original_idEmpresa;
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
      Guid idEmpresa,
      string RazonSocial,
      string DireccionFiscal,
      string Telefono,
      DateTime TIMESTAMP,
      string RFC,
      string Correo,
      int CP,
      string Ciudad,
      bool? Estatus,
      Guid? idSucursalRegistro)
    {
      this.Adapter.InsertCommand.Parameters[0].Value = (object) idEmpresa;
      this.Adapter.InsertCommand.Parameters[1].Value = RazonSocial != null ? (object) RazonSocial : throw new ArgumentNullException(nameof (RazonSocial));
      this.Adapter.InsertCommand.Parameters[2].Value = DireccionFiscal != null ? (object) DireccionFiscal : throw new ArgumentNullException(nameof (DireccionFiscal));
      this.Adapter.InsertCommand.Parameters[3].Value = Telefono != null ? (object) Telefono : throw new ArgumentNullException(nameof (Telefono));
      this.Adapter.InsertCommand.Parameters[4].Value = (object) TIMESTAMP;
      this.Adapter.InsertCommand.Parameters[5].Value = RFC != null ? (object) RFC : throw new ArgumentNullException(nameof (RFC));
      this.Adapter.InsertCommand.Parameters[6].Value = Correo != null ? (object) Correo : throw new ArgumentNullException(nameof (Correo));
      this.Adapter.InsertCommand.Parameters[7].Value = (object) CP;
      this.Adapter.InsertCommand.Parameters[8].Value = Ciudad != null ? (object) Ciudad : throw new ArgumentNullException(nameof (Ciudad));
      if (Estatus.HasValue)
        this.Adapter.InsertCommand.Parameters[9].Value = (object) Estatus.Value;
      else
        this.Adapter.InsertCommand.Parameters[9].Value = (object) DBNull.Value;
      if (idSucursalRegistro.HasValue)
        this.Adapter.InsertCommand.Parameters[10].Value = (object) idSucursalRegistro.Value;
      else
        this.Adapter.InsertCommand.Parameters[10].Value = (object) DBNull.Value;
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
      Guid idEmpresa,
      string RazonSocial,
      string DireccionFiscal,
      string Telefono,
      DateTime TIMESTAMP,
      string RFC,
      string Correo,
      int CP,
      string Ciudad,
      bool? Estatus,
      Guid? idSucursalRegistro,
      Guid Original_idEmpresa)
    {
      this.Adapter.UpdateCommand.Parameters[0].Value = (object) idEmpresa;
      this.Adapter.UpdateCommand.Parameters[1].Value = RazonSocial != null ? (object) RazonSocial : throw new ArgumentNullException(nameof (RazonSocial));
      this.Adapter.UpdateCommand.Parameters[2].Value = DireccionFiscal != null ? (object) DireccionFiscal : throw new ArgumentNullException(nameof (DireccionFiscal));
      this.Adapter.UpdateCommand.Parameters[3].Value = Telefono != null ? (object) Telefono : throw new ArgumentNullException(nameof (Telefono));
      this.Adapter.UpdateCommand.Parameters[4].Value = (object) TIMESTAMP;
      this.Adapter.UpdateCommand.Parameters[5].Value = RFC != null ? (object) RFC : throw new ArgumentNullException(nameof (RFC));
      this.Adapter.UpdateCommand.Parameters[6].Value = Correo != null ? (object) Correo : throw new ArgumentNullException(nameof (Correo));
      this.Adapter.UpdateCommand.Parameters[7].Value = (object) CP;
      this.Adapter.UpdateCommand.Parameters[8].Value = Ciudad != null ? (object) Ciudad : throw new ArgumentNullException(nameof (Ciudad));
      if (Estatus.HasValue)
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) Estatus.Value;
      else
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) DBNull.Value;
      if (idSucursalRegistro.HasValue)
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) idSucursalRegistro.Value;
      else
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) DBNull.Value;
      this.Adapter.UpdateCommand.Parameters[11].Value = (object) Original_idEmpresa;
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
      string RazonSocial,
      string DireccionFiscal,
      string Telefono,
      DateTime TIMESTAMP,
      string RFC,
      string Correo,
      int CP,
      string Ciudad,
      bool? Estatus,
      Guid? idSucursalRegistro,
      Guid Original_idEmpresa)
    {
      return this.Update(Original_idEmpresa, RazonSocial, DireccionFiscal, Telefono, TIMESTAMP, RFC, Correo, CP, Ciudad, Estatus, idSucursalRegistro, Original_idEmpresa);
    }
  }
}
