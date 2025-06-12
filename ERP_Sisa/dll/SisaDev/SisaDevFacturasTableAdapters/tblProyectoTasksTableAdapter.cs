// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDevFacturasTableAdapters.tblProyectoTasksTableAdapter
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
  public class tblProyectoTasksTableAdapter : Component
  {
    private SqlDataAdapter _adapter;
    private SqlConnection _connection;
    private SqlTransaction _transaction;
    private SqlCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public tblProyectoTasksTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblProyectoTasks",
        ColumnMappings = {
          {
            "IdTask",
            "IdTask"
          },
          {
            "IdProyecto",
            "IdProyecto"
          },
          {
            "Task",
            "Task"
          },
          {
            "IdUsuario",
            "IdUsuario"
          },
          {
            "FechaInicio",
            "FechaInicio"
          },
          {
            "FechaFin",
            "FechaFin"
          },
          {
            "Comentarios",
            "Comentarios"
          },
          {
            "Estatus",
            "Estatus"
          },
          {
            "IdUsuarioAlta",
            "IdUsuarioAlta"
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
          },
          {
            "Porcentaje",
            "Porcentaje"
          }
        }
      });
      this._adapter.DeleteCommand = new SqlCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[tblProyectoTasks] WHERE (([IdTask] = @Original_IdTask))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_IdTask", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdTask", DataRowVersion.Original, false, (object) null, "", "", ""));
      this._adapter.InsertCommand = new SqlCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[tblProyectoTasks] ([IdTask], [IdProyecto], [Task], [IdUsuario], [FechaInicio], [FechaFin], [Comentarios], [Estatus], [IdUsuarioAlta], [FechaAlta], [IdUsuarioModificacion], [FechaModificacion], [Porcentaje]) VALUES (@IdTask, @IdProyecto, @Task, @IdUsuario, @FechaInicio, @FechaFin, @Comentarios, @Estatus, @IdUsuarioAlta, @FechaAlta, @IdUsuarioModificacion, @FechaModificacion, @Porcentaje)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdTask", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdTask", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdProyecto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Task", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Task", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuario", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaInicio", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaInicio", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaFin", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaFin", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Comentarios", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Comentarios", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Estatus", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuarioAlta", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaAlta", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuarioModificacion", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaModificacion", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Porcentaje", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Porcentaje", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand = new SqlCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[tblProyectoTasks] SET [IdTask] = @IdTask, [IdProyecto] = @IdProyecto, [Task] = @Task, [IdUsuario] = @IdUsuario, [FechaInicio] = @FechaInicio, [FechaFin] = @FechaFin, [Comentarios] = @Comentarios, [Estatus] = @Estatus, [IdUsuarioAlta] = @IdUsuarioAlta, [FechaAlta] = @FechaAlta, [IdUsuarioModificacion] = @IdUsuarioModificacion, [FechaModificacion] = @FechaModificacion, [Porcentaje] = @Porcentaje WHERE (([IdTask] = @Original_IdTask))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdTask", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdTask", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdProyecto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Task", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Task", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuario", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaInicio", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaInicio", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaFin", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaFin", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Comentarios", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Comentarios", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Estatus", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdUsuarioAlta", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaAlta", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdUsuarioModificacion", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaModificacion", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Porcentaje", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Porcentaje", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_IdTask", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdTask", DataRowVersion.Original, false, (object) null, "", "", ""));
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
      this._commandCollection[0].CommandText = "SELECT IdTask, IdProyecto, Task, IdUsuario, FechaInicio, FechaFin, Comentarios, Estatus, IdUsuarioAlta, FechaAlta, IdUsuarioModificacion, FechaModificacion, Porcentaje FROM dbo.tblProyectoTasks";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(
      SisaDevFacturas.tblProyectoTasksDataTable dataTable)
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
    public virtual SisaDevFacturas.tblProyectoTasksDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      SisaDevFacturas.tblProyectoTasksDataTable proyectoTasksDataTable = new SisaDevFacturas.tblProyectoTasksDataTable();
      this.Adapter.Fill((DataTable) proyectoTasksDataTable);
      return proyectoTasksDataTable;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(
      SisaDevFacturas.tblProyectoTasksDataTable dataTable)
    {
      return this.Adapter.Update((DataTable) dataTable);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas dataSet) => this.Adapter.Update((DataSet) dataSet, "tblProyectoTasks");

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
    public virtual int Delete(Guid Original_IdTask)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) Original_IdTask;
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
      Guid IdTask,
      Guid IdProyecto,
      string Task,
      Guid? IdUsuario,
      DateTime FechaInicio,
      DateTime FechaFin,
      string Comentarios,
      int Estatus,
      Guid IdUsuarioAlta,
      DateTime FechaAlta,
      Guid? IdUsuarioModificacion,
      DateTime? FechaModificacion,
      Decimal? Porcentaje)
    {
      this.Adapter.InsertCommand.Parameters[0].Value = (object) IdTask;
      this.Adapter.InsertCommand.Parameters[1].Value = (object) IdProyecto;
      this.Adapter.InsertCommand.Parameters[2].Value = Task != null ? (object) Task : throw new ArgumentNullException(nameof (Task));
      if (IdUsuario.HasValue)
        this.Adapter.InsertCommand.Parameters[3].Value = (object) IdUsuario.Value;
      else
        this.Adapter.InsertCommand.Parameters[3].Value = (object) DBNull.Value;
      this.Adapter.InsertCommand.Parameters[4].Value = (object) FechaInicio;
      this.Adapter.InsertCommand.Parameters[5].Value = (object) FechaFin;
      this.Adapter.InsertCommand.Parameters[6].Value = Comentarios != null ? (object) Comentarios : throw new ArgumentNullException(nameof (Comentarios));
      this.Adapter.InsertCommand.Parameters[7].Value = (object) Estatus;
      this.Adapter.InsertCommand.Parameters[8].Value = (object) IdUsuarioAlta;
      this.Adapter.InsertCommand.Parameters[9].Value = (object) FechaAlta;
      if (IdUsuarioModificacion.HasValue)
        this.Adapter.InsertCommand.Parameters[10].Value = (object) IdUsuarioModificacion.Value;
      else
        this.Adapter.InsertCommand.Parameters[10].Value = (object) DBNull.Value;
      if (FechaModificacion.HasValue)
        this.Adapter.InsertCommand.Parameters[11].Value = (object) FechaModificacion.Value;
      else
        this.Adapter.InsertCommand.Parameters[11].Value = (object) DBNull.Value;
      if (Porcentaje.HasValue)
        this.Adapter.InsertCommand.Parameters[12].Value = (object) Porcentaje.Value;
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
      Guid IdTask,
      Guid IdProyecto,
      string Task,
      Guid? IdUsuario,
      DateTime FechaInicio,
      DateTime FechaFin,
      string Comentarios,
      int Estatus,
      Guid IdUsuarioAlta,
      DateTime FechaAlta,
      Guid? IdUsuarioModificacion,
      DateTime? FechaModificacion,
      Decimal? Porcentaje,
      Guid Original_IdTask)
    {
      this.Adapter.UpdateCommand.Parameters[0].Value = (object) IdTask;
      this.Adapter.UpdateCommand.Parameters[1].Value = (object) IdProyecto;
      this.Adapter.UpdateCommand.Parameters[2].Value = Task != null ? (object) Task : throw new ArgumentNullException(nameof (Task));
      if (IdUsuario.HasValue)
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) IdUsuario.Value;
      else
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) DBNull.Value;
      this.Adapter.UpdateCommand.Parameters[4].Value = (object) FechaInicio;
      this.Adapter.UpdateCommand.Parameters[5].Value = (object) FechaFin;
      this.Adapter.UpdateCommand.Parameters[6].Value = Comentarios != null ? (object) Comentarios : throw new ArgumentNullException(nameof (Comentarios));
      this.Adapter.UpdateCommand.Parameters[7].Value = (object) Estatus;
      this.Adapter.UpdateCommand.Parameters[8].Value = (object) IdUsuarioAlta;
      this.Adapter.UpdateCommand.Parameters[9].Value = (object) FechaAlta;
      if (IdUsuarioModificacion.HasValue)
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) IdUsuarioModificacion.Value;
      else
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) DBNull.Value;
      if (FechaModificacion.HasValue)
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) FechaModificacion.Value;
      else
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) DBNull.Value;
      if (Porcentaje.HasValue)
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) Porcentaje.Value;
      else
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) DBNull.Value;
      this.Adapter.UpdateCommand.Parameters[13].Value = (object) Original_IdTask;
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
      Guid IdProyecto,
      string Task,
      Guid? IdUsuario,
      DateTime FechaInicio,
      DateTime FechaFin,
      string Comentarios,
      int Estatus,
      Guid IdUsuarioAlta,
      DateTime FechaAlta,
      Guid? IdUsuarioModificacion,
      DateTime? FechaModificacion,
      Decimal? Porcentaje,
      Guid Original_IdTask)
    {
      return this.Update(Original_IdTask, IdProyecto, Task, IdUsuario, FechaInicio, FechaFin, Comentarios, Estatus, IdUsuarioAlta, FechaAlta, IdUsuarioModificacion, FechaModificacion, Porcentaje, Original_IdTask);
    }
  }
}
