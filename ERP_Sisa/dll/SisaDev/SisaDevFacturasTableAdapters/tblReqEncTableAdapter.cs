// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDevFacturasTableAdapters.tblReqEncTableAdapter
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
  public class tblReqEncTableAdapter : Component
  {
    private SqlDataAdapter _adapter;
    private SqlConnection _connection;
    private SqlTransaction _transaction;
    private SqlCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public tblReqEncTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblReqEnc",
        ColumnMappings = {
          {
            "IdReqEnc",
            "IdReqEnc"
          },
          {
            "NoReq",
            "NoReq"
          },
          {
            "IdProyecto",
            "IdProyecto"
          },
          {
            "Estatus",
            "Estatus"
          },
          {
            "SolicitarCotizacion",
            "SolicitarCotizacion"
          },
          {
            "RealizarCompra",
            "RealizarCompra"
          },
          {
            "Observaciones",
            "Observaciones"
          },
          {
            "Fecha",
            "Fecha"
          },
          {
            "IdUsuarioElaboro",
            "IdUsuarioElaboro"
          },
          {
            "FechaElaboracion",
            "FechaElaboracion"
          },
          {
            "IdUsuarioAutorizo",
            "IdUsuarioAutorizo"
          },
          {
            "FechaAutorizada",
            "FechaAutorizada"
          },
          {
            "IdUsuarioCompra",
            "IdUsuarioCompra"
          },
          {
            "FechaCompra",
            "FechaCompra"
          }
        }
      });
      this._adapter.DeleteCommand = new SqlCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[tblReqEnc] WHERE (([IdReqEnc] = @Original_IdReqEnc))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_IdReqEnc", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdReqEnc", DataRowVersion.Original, false, (object) null, "", "", ""));
      this._adapter.InsertCommand = new SqlCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[tblReqEnc] ([IdReqEnc], [NoReq], [IdProyecto], [Estatus], [SolicitarCotizacion], [RealizarCompra], [Observaciones], [Fecha], [IdUsuarioElaboro], [FechaElaboracion], [IdUsuarioAutorizo], [FechaAutorizada], [IdUsuarioCompra], [FechaCompra]) VALUES (@IdReqEnc, @NoReq, @IdProyecto, @Estatus, @SolicitarCotizacion, @RealizarCompra, @Observaciones, @Fecha, @IdUsuarioElaboro, @FechaElaboracion, @IdUsuarioAutorizo, @FechaAutorizada, @IdUsuarioCompra, @FechaCompra)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdReqEnc", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdReqEnc", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@NoReq", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoReq", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdProyecto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Estatus", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@SolicitarCotizacion", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SolicitarCotizacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@RealizarCompra", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RealizarCompra", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Observaciones", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Observaciones", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Fecha", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Fecha", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuarioElaboro", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioElaboro", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaElaboracion", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaElaboracion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuarioAutorizo", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioAutorizo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaAutorizada", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaAutorizada", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuarioCompra", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioCompra", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaCompra", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaCompra", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand = new SqlCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[tblReqEnc] SET [IdReqEnc] = @IdReqEnc, [NoReq] = @NoReq, [IdProyecto] = @IdProyecto, [Estatus] = @Estatus, [SolicitarCotizacion] = @SolicitarCotizacion, [RealizarCompra] = @RealizarCompra, [Observaciones] = @Observaciones, [Fecha] = @Fecha, [IdUsuarioElaboro] = @IdUsuarioElaboro, [FechaElaboracion] = @FechaElaboracion, [IdUsuarioAutorizo] = @IdUsuarioAutorizo, [FechaAutorizada] = @FechaAutorizada, [IdUsuarioCompra] = @IdUsuarioCompra, [FechaCompra] = @FechaCompra WHERE (([IdReqEnc] = @Original_IdReqEnc))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdReqEnc", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdReqEnc", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@NoReq", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoReq", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdProyecto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Estatus", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@SolicitarCotizacion", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "SolicitarCotizacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@RealizarCompra", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RealizarCompra", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Observaciones", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Observaciones", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Fecha", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Fecha", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdUsuarioElaboro", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioElaboro", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaElaboracion", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaElaboracion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdUsuarioAutorizo", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioAutorizo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaAutorizada", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaAutorizada", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdUsuarioCompra", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioCompra", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaCompra", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaCompra", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_IdReqEnc", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdReqEnc", DataRowVersion.Original, false, (object) null, "", "", ""));
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
      this._commandCollection[0].CommandText = "SELECT IdReqEnc, NoReq, IdProyecto, Estatus, SolicitarCotizacion, RealizarCompra, Observaciones, Fecha, IdUsuarioElaboro, FechaElaboracion, IdUsuarioAutorizo, FechaAutorizada, IdUsuarioCompra, FechaCompra FROM dbo.tblReqEnc";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(SisaDevFacturas.tblReqEncDataTable dataTable)
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
    public virtual SisaDevFacturas.tblReqEncDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      SisaDevFacturas.tblReqEncDataTable tblReqEncDataTable = new SisaDevFacturas.tblReqEncDataTable();
      this.Adapter.Fill((DataTable) tblReqEncDataTable);
      return tblReqEncDataTable;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas.tblReqEncDataTable dataTable) => this.Adapter.Update((DataTable) dataTable);

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas dataSet) => this.Adapter.Update((DataSet) dataSet, "tblReqEnc");

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
    public virtual int Delete(Guid Original_IdReqEnc)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) Original_IdReqEnc;
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
      Guid IdReqEnc,
      string NoReq,
      Guid IdProyecto,
      int Estatus,
      int SolicitarCotizacion,
      int? RealizarCompra,
      string Observaciones,
      string Fecha,
      Guid IdUsuarioElaboro,
      DateTime FechaElaboracion,
      Guid? IdUsuarioAutorizo,
      DateTime? FechaAutorizada,
      Guid? IdUsuarioCompra,
      DateTime? FechaCompra)
    {
      this.Adapter.InsertCommand.Parameters[0].Value = (object) IdReqEnc;
      this.Adapter.InsertCommand.Parameters[1].Value = NoReq != null ? (object) NoReq : throw new ArgumentNullException(nameof (NoReq));
      this.Adapter.InsertCommand.Parameters[2].Value = (object) IdProyecto;
      this.Adapter.InsertCommand.Parameters[3].Value = (object) Estatus;
      this.Adapter.InsertCommand.Parameters[4].Value = (object) SolicitarCotizacion;
      if (RealizarCompra.HasValue)
        this.Adapter.InsertCommand.Parameters[5].Value = (object) RealizarCompra.Value;
      else
        this.Adapter.InsertCommand.Parameters[5].Value = (object) DBNull.Value;
      this.Adapter.InsertCommand.Parameters[6].Value = Observaciones != null ? (object) Observaciones : throw new ArgumentNullException(nameof (Observaciones));
      this.Adapter.InsertCommand.Parameters[7].Value = Fecha != null ? (object) Fecha : throw new ArgumentNullException(nameof (Fecha));
      this.Adapter.InsertCommand.Parameters[8].Value = (object) IdUsuarioElaboro;
      this.Adapter.InsertCommand.Parameters[9].Value = (object) FechaElaboracion;
      if (IdUsuarioAutorizo.HasValue)
        this.Adapter.InsertCommand.Parameters[10].Value = (object) IdUsuarioAutorizo.Value;
      else
        this.Adapter.InsertCommand.Parameters[10].Value = (object) DBNull.Value;
      if (FechaAutorizada.HasValue)
        this.Adapter.InsertCommand.Parameters[11].Value = (object) FechaAutorizada.Value;
      else
        this.Adapter.InsertCommand.Parameters[11].Value = (object) DBNull.Value;
      if (IdUsuarioCompra.HasValue)
        this.Adapter.InsertCommand.Parameters[12].Value = (object) IdUsuarioCompra.Value;
      else
        this.Adapter.InsertCommand.Parameters[12].Value = (object) DBNull.Value;
      if (FechaCompra.HasValue)
        this.Adapter.InsertCommand.Parameters[13].Value = (object) FechaCompra.Value;
      else
        this.Adapter.InsertCommand.Parameters[13].Value = (object) DBNull.Value;
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
      Guid IdReqEnc,
      string NoReq,
      Guid IdProyecto,
      int Estatus,
      int SolicitarCotizacion,
      int? RealizarCompra,
      string Observaciones,
      string Fecha,
      Guid IdUsuarioElaboro,
      DateTime FechaElaboracion,
      Guid? IdUsuarioAutorizo,
      DateTime? FechaAutorizada,
      Guid? IdUsuarioCompra,
      DateTime? FechaCompra,
      Guid Original_IdReqEnc)
    {
      this.Adapter.UpdateCommand.Parameters[0].Value = (object) IdReqEnc;
      this.Adapter.UpdateCommand.Parameters[1].Value = NoReq != null ? (object) NoReq : throw new ArgumentNullException(nameof (NoReq));
      this.Adapter.UpdateCommand.Parameters[2].Value = (object) IdProyecto;
      this.Adapter.UpdateCommand.Parameters[3].Value = (object) Estatus;
      this.Adapter.UpdateCommand.Parameters[4].Value = (object) SolicitarCotizacion;
      if (RealizarCompra.HasValue)
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) RealizarCompra.Value;
      else
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) DBNull.Value;
      this.Adapter.UpdateCommand.Parameters[6].Value = Observaciones != null ? (object) Observaciones : throw new ArgumentNullException(nameof (Observaciones));
      this.Adapter.UpdateCommand.Parameters[7].Value = Fecha != null ? (object) Fecha : throw new ArgumentNullException(nameof (Fecha));
      this.Adapter.UpdateCommand.Parameters[8].Value = (object) IdUsuarioElaboro;
      this.Adapter.UpdateCommand.Parameters[9].Value = (object) FechaElaboracion;
      if (IdUsuarioAutorizo.HasValue)
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) IdUsuarioAutorizo.Value;
      else
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) DBNull.Value;
      if (FechaAutorizada.HasValue)
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) FechaAutorizada.Value;
      else
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) DBNull.Value;
      if (IdUsuarioCompra.HasValue)
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) IdUsuarioCompra.Value;
      else
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) DBNull.Value;
      if (FechaCompra.HasValue)
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) FechaCompra.Value;
      else
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) DBNull.Value;
      this.Adapter.UpdateCommand.Parameters[14].Value = (object) Original_IdReqEnc;
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
      string NoReq,
      Guid IdProyecto,
      int Estatus,
      int SolicitarCotizacion,
      int? RealizarCompra,
      string Observaciones,
      string Fecha,
      Guid IdUsuarioElaboro,
      DateTime FechaElaboracion,
      Guid? IdUsuarioAutorizo,
      DateTime? FechaAutorizada,
      Guid? IdUsuarioCompra,
      DateTime? FechaCompra,
      Guid Original_IdReqEnc)
    {
      return this.Update(Original_IdReqEnc, NoReq, IdProyecto, Estatus, SolicitarCotizacion, RealizarCompra, Observaciones, Fecha, IdUsuarioElaboro, FechaElaboracion, IdUsuarioAutorizo, FechaAutorizada, IdUsuarioCompra, FechaCompra, Original_IdReqEnc);
    }
  }
}
