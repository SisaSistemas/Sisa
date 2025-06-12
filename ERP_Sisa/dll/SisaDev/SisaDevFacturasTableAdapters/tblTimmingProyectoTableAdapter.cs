// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDevFacturasTableAdapters.tblTimmingProyectoTableAdapter
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
  public class tblTimmingProyectoTableAdapter : Component
  {
    private SqlDataAdapter _adapter;
    private SqlConnection _connection;
    private SqlTransaction _transaction;
    private SqlCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public tblTimmingProyectoTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblTimmingProyecto",
        ColumnMappings = {
          {
            "IdTimming",
            "IdTimming"
          },
          {
            "NombreProyecto",
            "NombreProyecto"
          },
          {
            "Actividad",
            "Actividad"
          },
          {
            "Tarea",
            "Tarea"
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
            "Persona",
            "Persona"
          },
          {
            "DiasTrans",
            "DiasTrans"
          },
          {
            "Avance",
            "Avance"
          },
          {
            "FechaAlta",
            "FechaAlta"
          },
          {
            "IdUsuarioAlta",
            "IdUsuarioAlta"
          },
          {
            "FechaModificacion",
            "FechaModificacion"
          },
          {
            "IdUsuarioModificacion",
            "IdUsuarioModificacion"
          }
        }
      });
      this._adapter.InsertCommand = new SqlCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[tblTimmingProyecto] ([IdTimming], [NombreProyecto], [Actividad], [Tarea], [FechaInicio], [FechaFin], [Persona], [DiasTrans], [Avance], [FechaAlta], [IdUsuarioAlta], [FechaModificacion], [IdUsuarioModificacion]) VALUES (@IdTimming, @NombreProyecto, @Actividad, @Tarea, @FechaInicio, @FechaFin, @Persona, @DiasTrans, @Avance, @FechaAlta, @IdUsuarioAlta, @FechaModificacion, @IdUsuarioModificacion)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdTimming", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdTimming", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@NombreProyecto", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NombreProyecto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Actividad", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Actividad", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Tarea", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Tarea", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaInicio", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaInicio", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaFin", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaFin", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Persona", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Persona", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@DiasTrans", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DiasTrans", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Avance", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 3, "Avance", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaAlta", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuarioAlta", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaModificacion", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuarioModificacion", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
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
      this._commandCollection[0].CommandText = "SELECT IdTimming, NombreProyecto, Actividad, Tarea, FechaInicio, FechaFin, Persona, DiasTrans, Avance, FechaAlta, IdUsuarioAlta, FechaModificacion, IdUsuarioModificacion FROM dbo.tblTimmingProyecto";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(
      SisaDevFacturas.tblTimmingProyectoDataTable dataTable)
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
    public virtual SisaDevFacturas.tblTimmingProyectoDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      SisaDevFacturas.tblTimmingProyectoDataTable proyectoDataTable = new SisaDevFacturas.tblTimmingProyectoDataTable();
      this.Adapter.Fill((DataTable) proyectoDataTable);
      return proyectoDataTable;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(
      SisaDevFacturas.tblTimmingProyectoDataTable dataTable)
    {
      return this.Adapter.Update((DataTable) dataTable);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas dataSet) => this.Adapter.Update((DataSet) dataSet, "tblTimmingProyecto");

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
    [DataObjectMethod(DataObjectMethodType.Insert, true)]
    public virtual int Insert(
      Guid IdTimming,
      string NombreProyecto,
      string Actividad,
      string Tarea,
      string FechaInicio,
      string FechaFin,
      string Persona,
      string DiasTrans,
      Decimal? Avance,
      DateTime? FechaAlta,
      Guid? IdUsuarioAlta,
      DateTime? FechaModificacion,
      Guid? IdUsuarioModificacion)
    {
      this.Adapter.InsertCommand.Parameters[0].Value = (object) IdTimming;
      this.Adapter.InsertCommand.Parameters[1].Value = NombreProyecto != null ? (object) NombreProyecto : throw new ArgumentNullException(nameof (NombreProyecto));
      if (Actividad == null)
        this.Adapter.InsertCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[2].Value = (object) Actividad;
      if (Tarea == null)
        this.Adapter.InsertCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[3].Value = (object) Tarea;
      if (FechaInicio == null)
        this.Adapter.InsertCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[4].Value = (object) FechaInicio;
      if (FechaFin == null)
        this.Adapter.InsertCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[5].Value = (object) FechaFin;
      if (Persona == null)
        this.Adapter.InsertCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[6].Value = (object) Persona;
      if (DiasTrans == null)
        this.Adapter.InsertCommand.Parameters[7].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[7].Value = (object) DiasTrans;
      if (Avance.HasValue)
        this.Adapter.InsertCommand.Parameters[8].Value = (object) Avance.Value;
      else
        this.Adapter.InsertCommand.Parameters[8].Value = (object) DBNull.Value;
      if (FechaAlta.HasValue)
        this.Adapter.InsertCommand.Parameters[9].Value = (object) FechaAlta.Value;
      else
        this.Adapter.InsertCommand.Parameters[9].Value = (object) DBNull.Value;
      if (IdUsuarioAlta.HasValue)
        this.Adapter.InsertCommand.Parameters[10].Value = (object) IdUsuarioAlta.Value;
      else
        this.Adapter.InsertCommand.Parameters[10].Value = (object) DBNull.Value;
      if (FechaModificacion.HasValue)
        this.Adapter.InsertCommand.Parameters[11].Value = (object) FechaModificacion.Value;
      else
        this.Adapter.InsertCommand.Parameters[11].Value = (object) DBNull.Value;
      if (IdUsuarioModificacion.HasValue)
        this.Adapter.InsertCommand.Parameters[12].Value = (object) IdUsuarioModificacion.Value;
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
  }
}
