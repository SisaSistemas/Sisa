// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDevFacturasTableAdapters.tblRFQTableAdapter
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
  public class tblRFQTableAdapter : Component
  {
    private SqlDataAdapter _adapter;
    private SqlConnection _connection;
    private SqlTransaction _transaction;
    private SqlCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public tblRFQTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblRFQ",
        ColumnMappings = {
          {
            "IdRfq",
            "IdRfq"
          },
          {
            "Folio",
            "Folio"
          },
          {
            "Round",
            "Round"
          },
          {
            "Fecha",
            "Fecha"
          },
          {
            "FechaVencimiento",
            "FechaVencimiento"
          },
          {
            "IdCliente",
            "IdCliente"
          },
          {
            "FolioRQ",
            "FolioRQ"
          },
          {
            "IdComprador",
            "IdComprador"
          },
          {
            "IdCotizacion",
            "IdCotizacion"
          },
          {
            "ArchivoRFQ",
            "ArchivoRFQ"
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
            "IdUsuarioModificar",
            "IdUsuarioModificar"
          },
          {
            "FechaModificacion",
            "FechaModificacion"
          },
          {
            "Descripcion",
            "Descripcion"
          },
          {
            "idVendedor",
            "idVendedor"
          },
          {
            "idCoordinador",
            "idCoordinador"
          },
          {
            "Seguimiento",
            "Seguimiento"
          }
        }
      });
      this._adapter.DeleteCommand = new SqlCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[tblRFQ] WHERE (([IdRfq] = @Original_IdRfq))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_IdRfq", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdRfq", DataRowVersion.Original, false, (object) null, "", "", ""));
      this._adapter.InsertCommand = new SqlCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[tblRFQ] ([IdRfq], [Folio], [Round], [Fecha], [FechaVencimiento], [IdCliente], [FolioRQ], [IdComprador], [IdCotizacion], [ArchivoRFQ], [Estatus], [IdUsuarioAlta], [FechaAlta], [IdUsuarioModificar], [FechaModificacion], [Descripcion], [idVendedor], [idCoordinador], [Seguimiento]) VALUES (@IdRfq, @Folio, @Round, @Fecha, @FechaVencimiento, @IdCliente, @FolioRQ, @IdComprador, @IdCotizacion, @ArchivoRFQ, @Estatus, @IdUsuarioAlta, @FechaAlta, @IdUsuarioModificar, @FechaModificacion, @Descripcion, @idVendedor, @idCoordinador, @Seguimiento)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdRfq", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdRfq", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Folio", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Folio", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Round", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Round", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Fecha", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Fecha", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaVencimiento", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaVencimiento", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdCliente", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdCliente", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FolioRQ", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FolioRQ", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdComprador", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdComprador", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdCotizacion", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdCotizacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ArchivoRFQ", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ArchivoRFQ", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Estatus", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuarioAlta", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaAlta", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuarioModificar", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioModificar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaModificacion", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Descripcion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@idVendedor", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "idVendedor", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@idCoordinador", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "idCoordinador", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Seguimiento", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Seguimiento", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand = new SqlCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[tblRFQ] SET [IdRfq] = @IdRfq, [Folio] = @Folio, [Round] = @Round, [Fecha] = @Fecha, [FechaVencimiento] = @FechaVencimiento, [IdCliente] = @IdCliente, [FolioRQ] = @FolioRQ, [IdComprador] = @IdComprador, [IdCotizacion] = @IdCotizacion, [ArchivoRFQ] = @ArchivoRFQ, [Estatus] = @Estatus, [IdUsuarioAlta] = @IdUsuarioAlta, [FechaAlta] = @FechaAlta, [IdUsuarioModificar] = @IdUsuarioModificar, [FechaModificacion] = @FechaModificacion, [Descripcion] = @Descripcion, [idVendedor] = @idVendedor, [idCoordinador] = @idCoordinador, [Seguimiento] = @Seguimiento WHERE (([IdRfq] = @Original_IdRfq))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdRfq", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdRfq", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Folio", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Folio", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Round", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Round", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Fecha", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Fecha", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaVencimiento", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaVencimiento", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdCliente", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdCliente", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FolioRQ", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FolioRQ", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdComprador", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdComprador", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdCotizacion", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdCotizacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ArchivoRFQ", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ArchivoRFQ", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Estatus", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdUsuarioAlta", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaAlta", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdUsuarioModificar", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioModificar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaModificacion", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Descripcion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@idVendedor", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "idVendedor", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@idCoordinador", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "idCoordinador", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Seguimiento", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Seguimiento", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_IdRfq", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdRfq", DataRowVersion.Original, false, (object) null, "", "", ""));
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
      this._commandCollection[0].CommandText = "SELECT IdRfq, Folio, Round, Fecha, FechaVencimiento, IdCliente, FolioRQ, IdComprador, IdCotizacion, ArchivoRFQ, Estatus, IdUsuarioAlta, FechaAlta, IdUsuarioModificar, FechaModificacion, Descripcion, idVendedor, idCoordinador, Seguimiento FROM dbo.tblRFQ";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(SisaDevFacturas.tblRFQDataTable dataTable)
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
    public virtual SisaDevFacturas.tblRFQDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      SisaDevFacturas.tblRFQDataTable tblRfqDataTable = new SisaDevFacturas.tblRFQDataTable();
      this.Adapter.Fill((DataTable) tblRfqDataTable);
      return tblRfqDataTable;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas.tblRFQDataTable dataTable) => this.Adapter.Update((DataTable) dataTable);

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas dataSet) => this.Adapter.Update((DataSet) dataSet, "tblRFQ");

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
    public virtual int Delete(Guid Original_IdRfq)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) Original_IdRfq;
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
      Guid IdRfq,
      string Folio,
      string Round,
      string Fecha,
      DateTime FechaVencimiento,
      Guid IdCliente,
      string FolioRQ,
      Guid IdComprador,
      Guid? IdCotizacion,
      string ArchivoRFQ,
      int Estatus,
      Guid IdUsuarioAlta,
      DateTime FechaAlta,
      Guid IdUsuarioModificar,
      DateTime FechaModificacion,
      string Descripcion,
      Guid? idVendedor,
      Guid? idCoordinador,
      string Seguimiento)
    {
      this.Adapter.InsertCommand.Parameters[0].Value = (object) IdRfq;
      this.Adapter.InsertCommand.Parameters[1].Value = Folio != null ? (object) Folio : throw new ArgumentNullException(nameof (Folio));
      this.Adapter.InsertCommand.Parameters[2].Value = Round != null ? (object) Round : throw new ArgumentNullException(nameof (Round));
      this.Adapter.InsertCommand.Parameters[3].Value = Fecha != null ? (object) Fecha : throw new ArgumentNullException(nameof (Fecha));
      this.Adapter.InsertCommand.Parameters[4].Value = (object) FechaVencimiento;
      this.Adapter.InsertCommand.Parameters[5].Value = (object) IdCliente;
      this.Adapter.InsertCommand.Parameters[6].Value = FolioRQ != null ? (object) FolioRQ : throw new ArgumentNullException(nameof (FolioRQ));
      this.Adapter.InsertCommand.Parameters[7].Value = (object) IdComprador;
      if (IdCotizacion.HasValue)
        this.Adapter.InsertCommand.Parameters[8].Value = (object) IdCotizacion.Value;
      else
        this.Adapter.InsertCommand.Parameters[8].Value = (object) DBNull.Value;
      if (ArchivoRFQ == null)
        this.Adapter.InsertCommand.Parameters[9].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[9].Value = (object) ArchivoRFQ;
      this.Adapter.InsertCommand.Parameters[10].Value = (object) Estatus;
      this.Adapter.InsertCommand.Parameters[11].Value = (object) IdUsuarioAlta;
      this.Adapter.InsertCommand.Parameters[12].Value = (object) FechaAlta;
      this.Adapter.InsertCommand.Parameters[13].Value = (object) IdUsuarioModificar;
      this.Adapter.InsertCommand.Parameters[14].Value = (object) FechaModificacion;
      if (Descripcion == null)
        this.Adapter.InsertCommand.Parameters[15].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[15].Value = (object) Descripcion;
      if (idVendedor.HasValue)
        this.Adapter.InsertCommand.Parameters[16].Value = (object) idVendedor.Value;
      else
        this.Adapter.InsertCommand.Parameters[16].Value = (object) DBNull.Value;
      if (idCoordinador.HasValue)
        this.Adapter.InsertCommand.Parameters[17].Value = (object) idCoordinador.Value;
      else
        this.Adapter.InsertCommand.Parameters[17].Value = (object) DBNull.Value;
      if (Seguimiento == null)
        this.Adapter.InsertCommand.Parameters[18].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[18].Value = (object) Seguimiento;
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
      Guid IdRfq,
      string Folio,
      string Round,
      string Fecha,
      DateTime FechaVencimiento,
      Guid IdCliente,
      string FolioRQ,
      Guid IdComprador,
      Guid? IdCotizacion,
      string ArchivoRFQ,
      int Estatus,
      Guid IdUsuarioAlta,
      DateTime FechaAlta,
      Guid IdUsuarioModificar,
      DateTime FechaModificacion,
      string Descripcion,
      Guid? idVendedor,
      Guid? idCoordinador,
      string Seguimiento,
      Guid Original_IdRfq)
    {
      this.Adapter.UpdateCommand.Parameters[0].Value = (object) IdRfq;
      this.Adapter.UpdateCommand.Parameters[1].Value = Folio != null ? (object) Folio : throw new ArgumentNullException(nameof (Folio));
      this.Adapter.UpdateCommand.Parameters[2].Value = Round != null ? (object) Round : throw new ArgumentNullException(nameof (Round));
      this.Adapter.UpdateCommand.Parameters[3].Value = Fecha != null ? (object) Fecha : throw new ArgumentNullException(nameof (Fecha));
      this.Adapter.UpdateCommand.Parameters[4].Value = (object) FechaVencimiento;
      this.Adapter.UpdateCommand.Parameters[5].Value = (object) IdCliente;
      this.Adapter.UpdateCommand.Parameters[6].Value = FolioRQ != null ? (object) FolioRQ : throw new ArgumentNullException(nameof (FolioRQ));
      this.Adapter.UpdateCommand.Parameters[7].Value = (object) IdComprador;
      if (IdCotizacion.HasValue)
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) IdCotizacion.Value;
      else
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) DBNull.Value;
      if (ArchivoRFQ == null)
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) ArchivoRFQ;
      this.Adapter.UpdateCommand.Parameters[10].Value = (object) Estatus;
      this.Adapter.UpdateCommand.Parameters[11].Value = (object) IdUsuarioAlta;
      this.Adapter.UpdateCommand.Parameters[12].Value = (object) FechaAlta;
      this.Adapter.UpdateCommand.Parameters[13].Value = (object) IdUsuarioModificar;
      this.Adapter.UpdateCommand.Parameters[14].Value = (object) FechaModificacion;
      if (Descripcion == null)
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) Descripcion;
      if (idVendedor.HasValue)
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) idVendedor.Value;
      else
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) DBNull.Value;
      if (idCoordinador.HasValue)
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) idCoordinador.Value;
      else
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) DBNull.Value;
      if (Seguimiento == null)
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) Seguimiento;
      this.Adapter.UpdateCommand.Parameters[19].Value = (object) Original_IdRfq;
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
      string Round,
      string Fecha,
      DateTime FechaVencimiento,
      Guid IdCliente,
      string FolioRQ,
      Guid IdComprador,
      Guid? IdCotizacion,
      string ArchivoRFQ,
      int Estatus,
      Guid IdUsuarioAlta,
      DateTime FechaAlta,
      Guid IdUsuarioModificar,
      DateTime FechaModificacion,
      string Descripcion,
      Guid? idVendedor,
      Guid? idCoordinador,
      string Seguimiento,
      Guid Original_IdRfq)
    {
      return this.Update(Original_IdRfq, Folio, Round, Fecha, FechaVencimiento, IdCliente, FolioRQ, IdComprador, IdCotizacion, ArchivoRFQ, Estatus, IdUsuarioAlta, FechaAlta, IdUsuarioModificar, FechaModificacion, Descripcion, idVendedor, idCoordinador, Seguimiento, Original_IdRfq);
    }
  }
}
