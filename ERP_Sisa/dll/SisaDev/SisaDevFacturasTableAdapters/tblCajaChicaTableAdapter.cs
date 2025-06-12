// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDevFacturasTableAdapters.tblCajaChicaTableAdapter
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
  public class tblCajaChicaTableAdapter : Component
  {
    private SqlDataAdapter _adapter;
    private SqlConnection _connection;
    private SqlTransaction _transaction;
    private SqlCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public tblCajaChicaTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblCajaChica",
        ColumnMappings = {
          {
            "IdCajaChica",
            "IdCajaChica"
          },
          {
            "Responsable",
            "Responsable"
          },
          {
            "Concepto",
            "Concepto"
          },
          {
            "IdProyecto",
            "IdProyecto"
          },
          {
            "Proyecto",
            "Proyecto"
          },
          {
            "Comprobante",
            "Comprobante"
          },
          {
            "Cargo",
            "Cargo"
          },
          {
            "Abono",
            "Abono"
          },
          {
            "Fecha",
            "Fecha"
          },
          {
            "FechaAlta",
            "FechaAlta"
          },
          {
            "Estatus",
            "Estatus"
          },
          {
            "Categoria",
            "Categoria"
          }
        }
      });
      this._adapter.DeleteCommand = new SqlCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[tblCajaChica] WHERE (([IdCajaChica] = @Original_IdCajaChica))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_IdCajaChica", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdCajaChica", DataRowVersion.Original, false, (object) null, "", "", ""));
      this._adapter.InsertCommand = new SqlCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[tblCajaChica] ([IdCajaChica], [Responsable], [Concepto], [IdProyecto], [Proyecto], [Comprobante], [Cargo], [Abono], [Fecha], [FechaAlta], [Estatus], [Categoria]) VALUES (@IdCajaChica, @Responsable, @Concepto, @IdProyecto, @Proyecto, @Comprobante, @Cargo, @Abono, @Fecha, @FechaAlta, @Estatus, @Categoria)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdCajaChica", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdCajaChica", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Responsable", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Responsable", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Concepto", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Concepto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdProyecto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Proyecto", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Proyecto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Comprobante", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Comprobante", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Cargo", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Cargo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Abono", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Abono", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Fecha", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Fecha", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaAlta", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Estatus", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Categoria", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Categoria", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand = new SqlCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[tblCajaChica] SET [IdCajaChica] = @IdCajaChica, [Responsable] = @Responsable, [Concepto] = @Concepto, [IdProyecto] = @IdProyecto, [Proyecto] = @Proyecto, [Comprobante] = @Comprobante, [Cargo] = @Cargo, [Abono] = @Abono, [Fecha] = @Fecha, [FechaAlta] = @FechaAlta, [Estatus] = @Estatus, [Categoria] = @Categoria WHERE (([IdCajaChica] = @Original_IdCajaChica))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdCajaChica", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdCajaChica", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Responsable", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Responsable", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Concepto", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Concepto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdProyecto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Proyecto", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Proyecto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Comprobante", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Comprobante", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Cargo", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Cargo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Abono", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Abono", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Fecha", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Fecha", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaAlta", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Estatus", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Categoria", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Categoria", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_IdCajaChica", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdCajaChica", DataRowVersion.Original, false, (object) null, "", "", ""));
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
      this._commandCollection[0].CommandText = "SELECT IdCajaChica, Responsable, Concepto, IdProyecto, Proyecto, Comprobante, Cargo, Abono, Fecha, FechaAlta, Estatus, Categoria FROM dbo.tblCajaChica";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(SisaDevFacturas.tblCajaChicaDataTable dataTable)
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
    public virtual SisaDevFacturas.tblCajaChicaDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      SisaDevFacturas.tblCajaChicaDataTable cajaChicaDataTable = new SisaDevFacturas.tblCajaChicaDataTable();
      this.Adapter.Fill((DataTable) cajaChicaDataTable);
      return cajaChicaDataTable;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas.tblCajaChicaDataTable dataTable) => this.Adapter.Update((DataTable) dataTable);

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas dataSet) => this.Adapter.Update((DataSet) dataSet, "tblCajaChica");

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
    public virtual int Delete(Guid Original_IdCajaChica)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) Original_IdCajaChica;
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
      Guid IdCajaChica,
      string Responsable,
      string Concepto,
      string IdProyecto,
      string Proyecto,
      string Comprobante,
      Decimal Cargo,
      Decimal Abono,
      DateTime Fecha,
      DateTime FechaAlta,
      int? Estatus,
      string Categoria)
    {
      this.Adapter.InsertCommand.Parameters[0].Value = (object) IdCajaChica;
      this.Adapter.InsertCommand.Parameters[1].Value = Responsable != null ? (object) Responsable : throw new ArgumentNullException(nameof (Responsable));
      this.Adapter.InsertCommand.Parameters[2].Value = Concepto != null ? (object) Concepto : throw new ArgumentNullException(nameof (Concepto));
      if (IdProyecto == null)
        this.Adapter.InsertCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[3].Value = (object) IdProyecto;
      this.Adapter.InsertCommand.Parameters[4].Value = Proyecto != null ? (object) Proyecto : throw new ArgumentNullException(nameof (Proyecto));
      this.Adapter.InsertCommand.Parameters[5].Value = Comprobante != null ? (object) Comprobante : throw new ArgumentNullException(nameof (Comprobante));
      this.Adapter.InsertCommand.Parameters[6].Value = (object) Cargo;
      this.Adapter.InsertCommand.Parameters[7].Value = (object) Abono;
      this.Adapter.InsertCommand.Parameters[8].Value = (object) Fecha;
      this.Adapter.InsertCommand.Parameters[9].Value = (object) FechaAlta;
      if (Estatus.HasValue)
        this.Adapter.InsertCommand.Parameters[10].Value = (object) Estatus.Value;
      else
        this.Adapter.InsertCommand.Parameters[10].Value = (object) DBNull.Value;
      if (Categoria == null)
        this.Adapter.InsertCommand.Parameters[11].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[11].Value = (object) Categoria;
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
      Guid IdCajaChica,
      string Responsable,
      string Concepto,
      string IdProyecto,
      string Proyecto,
      string Comprobante,
      Decimal Cargo,
      Decimal Abono,
      DateTime Fecha,
      DateTime FechaAlta,
      int? Estatus,
      string Categoria,
      Guid Original_IdCajaChica)
    {
      this.Adapter.UpdateCommand.Parameters[0].Value = (object) IdCajaChica;
      this.Adapter.UpdateCommand.Parameters[1].Value = Responsable != null ? (object) Responsable : throw new ArgumentNullException(nameof (Responsable));
      this.Adapter.UpdateCommand.Parameters[2].Value = Concepto != null ? (object) Concepto : throw new ArgumentNullException(nameof (Concepto));
      if (IdProyecto == null)
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) IdProyecto;
      this.Adapter.UpdateCommand.Parameters[4].Value = Proyecto != null ? (object) Proyecto : throw new ArgumentNullException(nameof (Proyecto));
      this.Adapter.UpdateCommand.Parameters[5].Value = Comprobante != null ? (object) Comprobante : throw new ArgumentNullException(nameof (Comprobante));
      this.Adapter.UpdateCommand.Parameters[6].Value = (object) Cargo;
      this.Adapter.UpdateCommand.Parameters[7].Value = (object) Abono;
      this.Adapter.UpdateCommand.Parameters[8].Value = (object) Fecha;
      this.Adapter.UpdateCommand.Parameters[9].Value = (object) FechaAlta;
      if (Estatus.HasValue)
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) Estatus.Value;
      else
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) DBNull.Value;
      if (Categoria == null)
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) Categoria;
      this.Adapter.UpdateCommand.Parameters[12].Value = (object) Original_IdCajaChica;
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
      string Responsable,
      string Concepto,
      string IdProyecto,
      string Proyecto,
      string Comprobante,
      Decimal Cargo,
      Decimal Abono,
      DateTime Fecha,
      DateTime FechaAlta,
      int? Estatus,
      string Categoria,
      Guid Original_IdCajaChica)
    {
      return this.Update(Original_IdCajaChica, Responsable, Concepto, IdProyecto, Proyecto, Comprobante, Cargo, Abono, Fecha, FechaAlta, Estatus, Categoria, Original_IdCajaChica);
    }
  }
}
