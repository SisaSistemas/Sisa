﻿// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDevFacturasTableAdapters.tblHorasHombreTableAdapter
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
  public class tblHorasHombreTableAdapter : Component
  {
    private SqlDataAdapter _adapter;
    private SqlConnection _connection;
    private SqlTransaction _transaction;
    private SqlCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public tblHorasHombreTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblHorasHombre",
        ColumnMappings = {
          {
            "IdHorasHombre",
            "IdHorasHombre"
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
            "Lunes",
            "Lunes"
          },
          {
            "Martes",
            "Martes"
          },
          {
            "Miercoles",
            "Miercoles"
          },
          {
            "Jueves",
            "Jueves"
          },
          {
            "Viernes",
            "Viernes"
          },
          {
            "Sabado",
            "Sabado"
          },
          {
            "Domingo",
            "Domingo"
          },
          {
            "Total",
            "Total"
          },
          {
            "Activo",
            "Activo"
          },
          {
            "FechaAlta",
            "FechaAlta"
          }
        }
      });
      this._adapter.DeleteCommand = new SqlCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[tblHorasHombre] WHERE (([IdHorasHombre] = @Original_IdHorasHombre))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_IdHorasHombre", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdHorasHombre", DataRowVersion.Original, false, (object) null, "", "", ""));
      this._adapter.InsertCommand = new SqlCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[tblHorasHombre] ([IdHorasHombre], [IdProyecto], [IdUsuario], [Lunes], [Martes], [Miercoles], [Jueves], [Viernes], [Sabado], [Domingo], [Activo], [FechaAlta]) VALUES (@IdHorasHombre, @IdProyecto, @IdUsuario, @Lunes, @Martes, @Miercoles, @Jueves, @Viernes, @Sabado, @Domingo, @Activo, @FechaAlta)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdHorasHombre", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdHorasHombre", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdProyecto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuario", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Lunes", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Lunes", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Martes", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Martes", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Miercoles", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Miercoles", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Jueves", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Jueves", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Viernes", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Viernes", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Sabado", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Sabado", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Domingo", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Domingo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Activo", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Activo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaAlta", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand = new SqlCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[tblHorasHombre] SET [IdHorasHombre] = @IdHorasHombre, [IdProyecto] = @IdProyecto, [IdUsuario] = @IdUsuario, [Lunes] = @Lunes, [Martes] = @Martes, [Miercoles] = @Miercoles, [Jueves] = @Jueves, [Viernes] = @Viernes, [Sabado] = @Sabado, [Domingo] = @Domingo, [Activo] = @Activo, [FechaAlta] = @FechaAlta WHERE (([IdHorasHombre] = @Original_IdHorasHombre))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdHorasHombre", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdHorasHombre", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdProyecto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuario", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Lunes", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Lunes", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Martes", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Martes", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Miercoles", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Miercoles", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Jueves", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Jueves", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Viernes", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Viernes", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Sabado", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Sabado", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Domingo", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Domingo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Activo", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Activo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaAlta", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_IdHorasHombre", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdHorasHombre", DataRowVersion.Original, false, (object) null, "", "", ""));
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
      this._commandCollection[0].CommandText = "SELECT IdHorasHombre, IdProyecto, IdUsuario, Lunes, Martes, Miercoles, Jueves, Viernes, Sabado, Domingo, Total, Activo, FechaAlta FROM dbo.tblHorasHombre";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(SisaDevFacturas.tblHorasHombreDataTable dataTable)
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
    public virtual SisaDevFacturas.tblHorasHombreDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      SisaDevFacturas.tblHorasHombreDataTable horasHombreDataTable = new SisaDevFacturas.tblHorasHombreDataTable();
      this.Adapter.Fill((DataTable) horasHombreDataTable);
      return horasHombreDataTable;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas.tblHorasHombreDataTable dataTable) => this.Adapter.Update((DataTable) dataTable);

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas dataSet) => this.Adapter.Update((DataSet) dataSet, "tblHorasHombre");

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
    public virtual int Delete(Guid Original_IdHorasHombre)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) Original_IdHorasHombre;
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
      Guid IdHorasHombre,
      Guid IdProyecto,
      Guid IdUsuario,
      int Lunes,
      int Martes,
      int Miercoles,
      int Jueves,
      int Viernes,
      int Sabado,
      int Domingo,
      int Activo,
      DateTime? FechaAlta)
    {
      this.Adapter.InsertCommand.Parameters[0].Value = (object) IdHorasHombre;
      this.Adapter.InsertCommand.Parameters[1].Value = (object) IdProyecto;
      this.Adapter.InsertCommand.Parameters[2].Value = (object) IdUsuario;
      this.Adapter.InsertCommand.Parameters[3].Value = (object) Lunes;
      this.Adapter.InsertCommand.Parameters[4].Value = (object) Martes;
      this.Adapter.InsertCommand.Parameters[5].Value = (object) Miercoles;
      this.Adapter.InsertCommand.Parameters[6].Value = (object) Jueves;
      this.Adapter.InsertCommand.Parameters[7].Value = (object) Viernes;
      this.Adapter.InsertCommand.Parameters[8].Value = (object) Sabado;
      this.Adapter.InsertCommand.Parameters[9].Value = (object) Domingo;
      this.Adapter.InsertCommand.Parameters[10].Value = (object) Activo;
      if (FechaAlta.HasValue)
        this.Adapter.InsertCommand.Parameters[11].Value = (object) FechaAlta.Value;
      else
        this.Adapter.InsertCommand.Parameters[11].Value = (object) DBNull.Value;
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
      Guid IdHorasHombre,
      Guid IdProyecto,
      Guid IdUsuario,
      int Lunes,
      int Martes,
      int Miercoles,
      int Jueves,
      int Viernes,
      int Sabado,
      int Domingo,
      int Activo,
      DateTime? FechaAlta,
      Guid Original_IdHorasHombre)
    {
      this.Adapter.UpdateCommand.Parameters[0].Value = (object) IdHorasHombre;
      this.Adapter.UpdateCommand.Parameters[1].Value = (object) IdProyecto;
      this.Adapter.UpdateCommand.Parameters[2].Value = (object) IdUsuario;
      this.Adapter.UpdateCommand.Parameters[3].Value = (object) Lunes;
      this.Adapter.UpdateCommand.Parameters[4].Value = (object) Martes;
      this.Adapter.UpdateCommand.Parameters[5].Value = (object) Miercoles;
      this.Adapter.UpdateCommand.Parameters[6].Value = (object) Jueves;
      this.Adapter.UpdateCommand.Parameters[7].Value = (object) Viernes;
      this.Adapter.UpdateCommand.Parameters[8].Value = (object) Sabado;
      this.Adapter.UpdateCommand.Parameters[9].Value = (object) Domingo;
      this.Adapter.UpdateCommand.Parameters[10].Value = (object) Activo;
      if (FechaAlta.HasValue)
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) FechaAlta.Value;
      else
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) DBNull.Value;
      this.Adapter.UpdateCommand.Parameters[12].Value = (object) Original_IdHorasHombre;
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
      Guid IdUsuario,
      int Lunes,
      int Martes,
      int Miercoles,
      int Jueves,
      int Viernes,
      int Sabado,
      int Domingo,
      int Activo,
      DateTime? FechaAlta,
      Guid Original_IdHorasHombre)
    {
      return this.Update(Original_IdHorasHombre, IdProyecto, IdUsuario, Lunes, Martes, Miercoles, Jueves, Viernes, Sabado, Domingo, Activo, FechaAlta, Original_IdHorasHombre);
    }
  }
}
