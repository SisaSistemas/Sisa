// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDevFacturasTableAdapters.tblProyectosBKTableAdapter
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
  public class tblProyectosBKTableAdapter : Component
  {
    private SqlDataAdapter _adapter;
    private SqlConnection _connection;
    private SqlTransaction _transaction;
    private SqlCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public tblProyectosBKTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblProyectosBK",
        ColumnMappings = {
          {
            "IdProyecto",
            "IdProyecto"
          },
          {
            "ID",
            "ID"
          },
          {
            "NombreProyecto",
            "NombreProyecto"
          },
          {
            "Descripcion",
            "Descripcion"
          },
          {
            "IdLider",
            "IdLider"
          },
          {
            "IdCliente",
            "IdCliente"
          },
          {
            "Estatus",
            "Estatus"
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
            "Activo",
            "Activo"
          },
          {
            "UserProject1",
            "UserProject1"
          },
          {
            "UserProject2",
            "UserProject2"
          },
          {
            "UserProject3",
            "UserProject3"
          },
          {
            "UserProject4",
            "UserProject4"
          },
          {
            "IdCotizacion",
            "IdCotizacion"
          },
          {
            "CostoCotizacion",
            "CostoCotizacion"
          }
        }
      });
      this._adapter.InsertCommand = new SqlCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[tblProyectosBK] ([ID], [NombreProyecto], [Descripcion], [IdLider], [IdCliente], [Estatus], [FechaInicio], [FechaFin], [IdUsuarioAlta], [FechaAlta], [IdUsuarioModificacion], [FechaModificacion], [Activo], [UserProject1], [UserProject2], [UserProject3], [UserProject4], [IdCotizacion], [CostoCotizacion]) VALUES (@ID, @NombreProyecto, @Descripcion, @IdLider, @IdCliente, @Estatus, @FechaInicio, @FechaFin, @IdUsuarioAlta, @FechaAlta, @IdUsuarioModificacion, @FechaModificacion, @Activo, @UserProject1, @UserProject2, @UserProject3, @UserProject4, @IdCotizacion, @CostoCotizacion)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ID", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@NombreProyecto", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NombreProyecto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Descripcion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdLider", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdLider", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdCliente", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdCliente", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Estatus", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Estatus", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaInicio", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaInicio", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaFin", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaFin", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuarioAlta", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaAlta", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuarioModificacion", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaModificacion", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Activo", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Activo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@UserProject1", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "UserProject1", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@UserProject2", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "UserProject2", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@UserProject3", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "UserProject3", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@UserProject4", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "UserProject4", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdCotizacion", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdCotizacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@CostoCotizacion", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 20, (byte) 2, "CostoCotizacion", DataRowVersion.Current, false, (object) null, "", "", ""));
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
      this._commandCollection[0].CommandText = "SELECT IdProyecto, ID, NombreProyecto, Descripcion, IdLider, IdCliente, Estatus, FechaInicio, FechaFin, IdUsuarioAlta, FechaAlta, IdUsuarioModificacion, FechaModificacion, Activo, UserProject1, UserProject2, UserProject3, UserProject4, IdCotizacion, CostoCotizacion FROM dbo.tblProyectosBK";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(SisaDevFacturas.tblProyectosBKDataTable dataTable)
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
    public virtual SisaDevFacturas.tblProyectosBKDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      SisaDevFacturas.tblProyectosBKDataTable proyectosBkDataTable = new SisaDevFacturas.tblProyectosBKDataTable();
      this.Adapter.Fill((DataTable) proyectosBkDataTable);
      return proyectosBkDataTable;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas.tblProyectosBKDataTable dataTable) => this.Adapter.Update((DataTable) dataTable);

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas dataSet) => this.Adapter.Update((DataSet) dataSet, "tblProyectosBK");

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
      Guid ID,
      string NombreProyecto,
      string Descripcion,
      Guid IdLider,
      Guid? IdCliente,
      string Estatus,
      DateTime FechaInicio,
      DateTime FechaFin,
      Guid IdUsuarioAlta,
      DateTime FechaAlta,
      Guid IdUsuarioModificacion,
      DateTime FechaModificacion,
      int Activo,
      Guid? UserProject1,
      Guid? UserProject2,
      Guid? UserProject3,
      Guid? UserProject4,
      Guid? IdCotizacion,
      Decimal? CostoCotizacion)
    {
      this.Adapter.InsertCommand.Parameters[0].Value = (object) ID;
      this.Adapter.InsertCommand.Parameters[1].Value = NombreProyecto != null ? (object) NombreProyecto : throw new ArgumentNullException(nameof (NombreProyecto));
      this.Adapter.InsertCommand.Parameters[2].Value = Descripcion != null ? (object) Descripcion : throw new ArgumentNullException(nameof (Descripcion));
      this.Adapter.InsertCommand.Parameters[3].Value = (object) IdLider;
      if (IdCliente.HasValue)
        this.Adapter.InsertCommand.Parameters[4].Value = (object) IdCliente.Value;
      else
        this.Adapter.InsertCommand.Parameters[4].Value = (object) DBNull.Value;
      this.Adapter.InsertCommand.Parameters[5].Value = Estatus != null ? (object) Estatus : throw new ArgumentNullException(nameof (Estatus));
      this.Adapter.InsertCommand.Parameters[6].Value = (object) FechaInicio;
      this.Adapter.InsertCommand.Parameters[7].Value = (object) FechaFin;
      this.Adapter.InsertCommand.Parameters[8].Value = (object) IdUsuarioAlta;
      this.Adapter.InsertCommand.Parameters[9].Value = (object) FechaAlta;
      this.Adapter.InsertCommand.Parameters[10].Value = (object) IdUsuarioModificacion;
      this.Adapter.InsertCommand.Parameters[11].Value = (object) FechaModificacion;
      this.Adapter.InsertCommand.Parameters[12].Value = (object) Activo;
      if (UserProject1.HasValue)
        this.Adapter.InsertCommand.Parameters[13].Value = (object) UserProject1.Value;
      else
        this.Adapter.InsertCommand.Parameters[13].Value = (object) DBNull.Value;
      if (UserProject2.HasValue)
        this.Adapter.InsertCommand.Parameters[14].Value = (object) UserProject2.Value;
      else
        this.Adapter.InsertCommand.Parameters[14].Value = (object) DBNull.Value;
      if (UserProject3.HasValue)
        this.Adapter.InsertCommand.Parameters[15].Value = (object) UserProject3.Value;
      else
        this.Adapter.InsertCommand.Parameters[15].Value = (object) DBNull.Value;
      if (UserProject4.HasValue)
        this.Adapter.InsertCommand.Parameters[16].Value = (object) UserProject4.Value;
      else
        this.Adapter.InsertCommand.Parameters[16].Value = (object) DBNull.Value;
      if (IdCotizacion.HasValue)
        this.Adapter.InsertCommand.Parameters[17].Value = (object) IdCotizacion.Value;
      else
        this.Adapter.InsertCommand.Parameters[17].Value = (object) DBNull.Value;
      if (CostoCotizacion.HasValue)
        this.Adapter.InsertCommand.Parameters[18].Value = (object) CostoCotizacion.Value;
      else
        this.Adapter.InsertCommand.Parameters[18].Value = (object) DBNull.Value;
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
