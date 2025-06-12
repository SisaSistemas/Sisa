// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDevFacturasTableAdapters.tblVehiculoServicioTableAdapter
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
  public class tblVehiculoServicioTableAdapter : Component
  {
    private SqlDataAdapter _adapter;
    private SqlConnection _connection;
    private SqlTransaction _transaction;
    private SqlCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public tblVehiculoServicioTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblVehiculoServicio",
        ColumnMappings = {
          {
            "IdServicioVehiculo",
            "IdServicioVehiculo"
          },
          {
            "IdCarro",
            "IdCarro"
          },
          {
            "KilometrajeActual",
            "KilometrajeActual"
          },
          {
            "Taller",
            "Taller"
          },
          {
            "KilometrajeProximo",
            "KilometrajeProximo"
          },
          {
            "FechaServicio",
            "FechaServicio"
          },
          {
            "TipoServicio",
            "TipoServicio"
          },
          {
            "IdUsuario",
            "IdUsuario"
          },
          {
            "FechaAlta",
            "FechaAlta"
          },
          {
            "IdUsuarioModificacion",
            "IdUsuarioModificacion"
          },
          {
            "FechaModificacion",
            "FechaModificacion"
          }
        }
      });
      this._adapter.DeleteCommand = new SqlCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[tblVehiculoServicio] WHERE (([IdServicioVehiculo] = @Original_IdServicioVehiculo))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_IdServicioVehiculo", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdServicioVehiculo", DataRowVersion.Original, false, (object) null, "", "", ""));
      this._adapter.InsertCommand = new SqlCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[tblVehiculoServicio] ([IdServicioVehiculo], [IdCarro], [KilometrajeActual], [Taller], [KilometrajeProximo], [FechaServicio], [TipoServicio], [IdUsuario], [FechaAlta], [IdUsuarioModificacion], [FechaModificacion]) VALUES (@IdServicioVehiculo, @IdCarro, @KilometrajeActual, @Taller, @KilometrajeProximo, @FechaServicio, @TipoServicio, @IdUsuario, @FechaAlta, @IdUsuarioModificacion, @FechaModificacion)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdServicioVehiculo", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdServicioVehiculo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdCarro", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdCarro", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@KilometrajeActual", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "KilometrajeActual", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Taller", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Taller", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@KilometrajeProximo", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "KilometrajeProximo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaServicio", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaServicio", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@TipoServicio", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TipoServicio", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuario", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaAlta", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuarioModificacion", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaModificacion", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand = new SqlCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[tblVehiculoServicio] SET [IdServicioVehiculo] = @IdServicioVehiculo, [IdCarro] = @IdCarro, [KilometrajeActual] = @KilometrajeActual, [Taller] = @Taller, [KilometrajeProximo] = @KilometrajeProximo, [FechaServicio] = @FechaServicio, [TipoServicio] = @TipoServicio, [IdUsuario] = @IdUsuario, [FechaAlta] = @FechaAlta, [IdUsuarioModificacion] = @IdUsuarioModificacion, [FechaModificacion] = @FechaModificacion WHERE (([IdServicioVehiculo] = @Original_IdServicioVehiculo))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdServicioVehiculo", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdServicioVehiculo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdCarro", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdCarro", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@KilometrajeActual", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "KilometrajeActual", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Taller", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Taller", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@KilometrajeProximo", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "KilometrajeProximo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaServicio", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaServicio", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@TipoServicio", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TipoServicio", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuario", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaAlta", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdUsuarioModificacion", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaModificacion", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_IdServicioVehiculo", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdServicioVehiculo", DataRowVersion.Original, false, (object) null, "", "", ""));
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
      this._commandCollection[0].CommandText = "SELECT IdServicioVehiculo, IdCarro, KilometrajeActual, Taller, KilometrajeProximo, FechaServicio, TipoServicio, IdUsuario, FechaAlta, IdUsuarioModificacion, FechaModificacion FROM dbo.tblVehiculoServicio";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(
      SisaDevFacturas.tblVehiculoServicioDataTable dataTable)
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
    public virtual SisaDevFacturas.tblVehiculoServicioDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      SisaDevFacturas.tblVehiculoServicioDataTable servicioDataTable = new SisaDevFacturas.tblVehiculoServicioDataTable();
      this.Adapter.Fill((DataTable) servicioDataTable);
      return servicioDataTable;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(
      SisaDevFacturas.tblVehiculoServicioDataTable dataTable)
    {
      return this.Adapter.Update((DataTable) dataTable);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas dataSet) => this.Adapter.Update((DataSet) dataSet, "tblVehiculoServicio");

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
    public virtual int Delete(Guid Original_IdServicioVehiculo)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) Original_IdServicioVehiculo;
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
      Guid IdServicioVehiculo,
      Guid IdCarro,
      int KilometrajeActual,
      string Taller,
      int KilometrajeProximo,
      DateTime FechaServicio,
      string TipoServicio,
      Guid IdUsuario,
      DateTime FechaAlta,
      Guid IdUsuarioModificacion,
      DateTime FechaModificacion)
    {
      this.Adapter.InsertCommand.Parameters[0].Value = (object) IdServicioVehiculo;
      this.Adapter.InsertCommand.Parameters[1].Value = (object) IdCarro;
      this.Adapter.InsertCommand.Parameters[2].Value = (object) KilometrajeActual;
      this.Adapter.InsertCommand.Parameters[3].Value = Taller != null ? (object) Taller : throw new ArgumentNullException(nameof (Taller));
      this.Adapter.InsertCommand.Parameters[4].Value = (object) KilometrajeProximo;
      this.Adapter.InsertCommand.Parameters[5].Value = (object) FechaServicio;
      this.Adapter.InsertCommand.Parameters[6].Value = TipoServicio != null ? (object) TipoServicio : throw new ArgumentNullException(nameof (TipoServicio));
      this.Adapter.InsertCommand.Parameters[7].Value = (object) IdUsuario;
      this.Adapter.InsertCommand.Parameters[8].Value = (object) FechaAlta;
      this.Adapter.InsertCommand.Parameters[9].Value = (object) IdUsuarioModificacion;
      this.Adapter.InsertCommand.Parameters[10].Value = (object) FechaModificacion;
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
      Guid IdServicioVehiculo,
      Guid IdCarro,
      int KilometrajeActual,
      string Taller,
      int KilometrajeProximo,
      DateTime FechaServicio,
      string TipoServicio,
      Guid IdUsuario,
      DateTime FechaAlta,
      Guid IdUsuarioModificacion,
      DateTime FechaModificacion,
      Guid Original_IdServicioVehiculo)
    {
      this.Adapter.UpdateCommand.Parameters[0].Value = (object) IdServicioVehiculo;
      this.Adapter.UpdateCommand.Parameters[1].Value = (object) IdCarro;
      this.Adapter.UpdateCommand.Parameters[2].Value = (object) KilometrajeActual;
      this.Adapter.UpdateCommand.Parameters[3].Value = Taller != null ? (object) Taller : throw new ArgumentNullException(nameof (Taller));
      this.Adapter.UpdateCommand.Parameters[4].Value = (object) KilometrajeProximo;
      this.Adapter.UpdateCommand.Parameters[5].Value = (object) FechaServicio;
      this.Adapter.UpdateCommand.Parameters[6].Value = TipoServicio != null ? (object) TipoServicio : throw new ArgumentNullException(nameof (TipoServicio));
      this.Adapter.UpdateCommand.Parameters[7].Value = (object) IdUsuario;
      this.Adapter.UpdateCommand.Parameters[8].Value = (object) FechaAlta;
      this.Adapter.UpdateCommand.Parameters[9].Value = (object) IdUsuarioModificacion;
      this.Adapter.UpdateCommand.Parameters[10].Value = (object) FechaModificacion;
      this.Adapter.UpdateCommand.Parameters[11].Value = (object) Original_IdServicioVehiculo;
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
      Guid IdCarro,
      int KilometrajeActual,
      string Taller,
      int KilometrajeProximo,
      DateTime FechaServicio,
      string TipoServicio,
      Guid IdUsuario,
      DateTime FechaAlta,
      Guid IdUsuarioModificacion,
      DateTime FechaModificacion,
      Guid Original_IdServicioVehiculo)
    {
      return this.Update(Original_IdServicioVehiculo, IdCarro, KilometrajeActual, Taller, KilometrajeProximo, FechaServicio, TipoServicio, IdUsuario, FechaAlta, IdUsuarioModificacion, FechaModificacion, Original_IdServicioVehiculo);
    }
  }
}
