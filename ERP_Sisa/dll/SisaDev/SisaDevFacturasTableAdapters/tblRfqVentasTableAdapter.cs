// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDevFacturasTableAdapters.tblRfqVentasTableAdapter
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
  public class tblRfqVentasTableAdapter : Component
  {
    private SqlDataAdapter _adapter;
    private SqlConnection _connection;
    private SqlTransaction _transaction;
    private SqlCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public tblRfqVentasTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblRfqVentas",
        ColumnMappings = {
          {
            "IdRfqVentas",
            "IdRfqVentas"
          },
          {
            "FolioRfq",
            "FolioRfq"
          },
          {
            "Descripcion",
            "Descripcion"
          },
          {
            "IdUsuarioVendedor",
            "IdUsuarioVendedor"
          },
          {
            "IdUsuarioCoordinador",
            "IdUsuarioCoordinador"
          },
          {
            "Empresa",
            "Empresa"
          },
          {
            "Contacto",
            "Contacto"
          },
          {
            "FechaRfq",
            "FechaRfq"
          },
          {
            "FechaEntrega",
            "FechaEntrega"
          },
          {
            "Enviado",
            "Enviado"
          },
          {
            "Estatus",
            "Estatus"
          },
          {
            "Seguimiento",
            "Seguimiento"
          },
          {
            "FechaAlta",
            "FechaAlta"
          },
          {
            "IdUsuarioAlta",
            "IdUsuarioAlta"
          }
        }
      });
      this._adapter.DeleteCommand = new SqlCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[tblRfqVentas] WHERE (([IdRfqVentas] = @Original_IdRfqVentas))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_IdRfqVentas", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdRfqVentas", DataRowVersion.Original, false, (object) null, "", "", ""));
      this._adapter.InsertCommand = new SqlCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[tblRfqVentas] ([IdRfqVentas], [FolioRfq], [Descripcion], [IdUsuarioVendedor], [IdUsuarioCoordinador], [Empresa], [Contacto], [FechaRfq], [FechaEntrega], [Enviado], [Estatus], [Seguimiento], [FechaAlta], [IdUsuarioAlta]) VALUES (@IdRfqVentas, @FolioRfq, @Descripcion, @IdUsuarioVendedor, @IdUsuarioCoordinador, @Empresa, @Contacto, @FechaRfq, @FechaEntrega, @Enviado, @Estatus, @Seguimiento, @FechaAlta, @IdUsuarioAlta)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdRfqVentas", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdRfqVentas", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FolioRfq", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FolioRfq", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Descripcion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuarioVendedor", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioVendedor", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuarioCoordinador", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioCoordinador", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Empresa", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Empresa", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Contacto", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Contacto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaRfq", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaRfq", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaEntrega", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaEntrega", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Enviado", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Enviado", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Estatus", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Seguimiento", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Seguimiento", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaAlta", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuarioAlta", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand = new SqlCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[tblRfqVentas] SET [IdRfqVentas] = @IdRfqVentas, [FolioRfq] = @FolioRfq, [Descripcion] = @Descripcion, [IdUsuarioVendedor] = @IdUsuarioVendedor, [IdUsuarioCoordinador] = @IdUsuarioCoordinador, [Empresa] = @Empresa, [Contacto] = @Contacto, [FechaRfq] = @FechaRfq, [FechaEntrega] = @FechaEntrega, [Enviado] = @Enviado, [Estatus] = @Estatus, [Seguimiento] = @Seguimiento, [FechaAlta] = @FechaAlta, [IdUsuarioAlta] = @IdUsuarioAlta WHERE (([IdRfqVentas] = @Original_IdRfqVentas))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdRfqVentas", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdRfqVentas", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FolioRfq", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FolioRfq", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Descripcion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdUsuarioVendedor", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioVendedor", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdUsuarioCoordinador", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioCoordinador", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Empresa", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Empresa", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Contacto", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Contacto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaRfq", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaRfq", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaEntrega", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaEntrega", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Enviado", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Enviado", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Estatus", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Seguimiento", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Seguimiento", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaAlta", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdUsuarioAlta", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_IdRfqVentas", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdRfqVentas", DataRowVersion.Original, false, (object) null, "", "", ""));
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
      this._commandCollection[0].CommandText = "SELECT IdRfqVentas, FolioRfq, Descripcion, IdUsuarioVendedor, IdUsuarioCoordinador, Empresa, Contacto, FechaRfq, FechaEntrega, Enviado, Estatus, Seguimiento, FechaAlta, IdUsuarioAlta FROM dbo.tblRfqVentas";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(SisaDevFacturas.tblRfqVentasDataTable dataTable)
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
    public virtual SisaDevFacturas.tblRfqVentasDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      SisaDevFacturas.tblRfqVentasDataTable rfqVentasDataTable = new SisaDevFacturas.tblRfqVentasDataTable();
      this.Adapter.Fill((DataTable) rfqVentasDataTable);
      return rfqVentasDataTable;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas.tblRfqVentasDataTable dataTable) => this.Adapter.Update((DataTable) dataTable);

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas dataSet) => this.Adapter.Update((DataSet) dataSet, "tblRfqVentas");

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
    public virtual int Delete(Guid Original_IdRfqVentas)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) Original_IdRfqVentas;
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
      Guid IdRfqVentas,
      string FolioRfq,
      string Descripcion,
      Guid IdUsuarioVendedor,
      Guid IdUsuarioCoordinador,
      string Empresa,
      string Contacto,
      DateTime? FechaRfq,
      DateTime? FechaEntrega,
      int? Enviado,
      int? Estatus,
      string Seguimiento,
      DateTime? FechaAlta,
      Guid? IdUsuarioAlta)
    {
      this.Adapter.InsertCommand.Parameters[0].Value = (object) IdRfqVentas;
      this.Adapter.InsertCommand.Parameters[1].Value = FolioRfq != null ? (object) FolioRfq : throw new ArgumentNullException(nameof (FolioRfq));
      if (Descripcion == null)
        this.Adapter.InsertCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[2].Value = (object) Descripcion;
      this.Adapter.InsertCommand.Parameters[3].Value = (object) IdUsuarioVendedor;
      this.Adapter.InsertCommand.Parameters[4].Value = (object) IdUsuarioCoordinador;
      if (Empresa == null)
        this.Adapter.InsertCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[5].Value = (object) Empresa;
      if (Contacto == null)
        this.Adapter.InsertCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[6].Value = (object) Contacto;
      if (FechaRfq.HasValue)
        this.Adapter.InsertCommand.Parameters[7].Value = (object) FechaRfq.Value;
      else
        this.Adapter.InsertCommand.Parameters[7].Value = (object) DBNull.Value;
      if (FechaEntrega.HasValue)
        this.Adapter.InsertCommand.Parameters[8].Value = (object) FechaEntrega.Value;
      else
        this.Adapter.InsertCommand.Parameters[8].Value = (object) DBNull.Value;
      if (Enviado.HasValue)
        this.Adapter.InsertCommand.Parameters[9].Value = (object) Enviado.Value;
      else
        this.Adapter.InsertCommand.Parameters[9].Value = (object) DBNull.Value;
      if (Estatus.HasValue)
        this.Adapter.InsertCommand.Parameters[10].Value = (object) Estatus.Value;
      else
        this.Adapter.InsertCommand.Parameters[10].Value = (object) DBNull.Value;
      if (Seguimiento == null)
        this.Adapter.InsertCommand.Parameters[11].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[11].Value = (object) Seguimiento;
      if (FechaAlta.HasValue)
        this.Adapter.InsertCommand.Parameters[12].Value = (object) FechaAlta.Value;
      else
        this.Adapter.InsertCommand.Parameters[12].Value = (object) DBNull.Value;
      if (IdUsuarioAlta.HasValue)
        this.Adapter.InsertCommand.Parameters[13].Value = (object) IdUsuarioAlta.Value;
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
      Guid IdRfqVentas,
      string FolioRfq,
      string Descripcion,
      Guid IdUsuarioVendedor,
      Guid IdUsuarioCoordinador,
      string Empresa,
      string Contacto,
      DateTime? FechaRfq,
      DateTime? FechaEntrega,
      int? Enviado,
      int? Estatus,
      string Seguimiento,
      DateTime? FechaAlta,
      Guid? IdUsuarioAlta,
      Guid Original_IdRfqVentas)
    {
      this.Adapter.UpdateCommand.Parameters[0].Value = (object) IdRfqVentas;
      this.Adapter.UpdateCommand.Parameters[1].Value = FolioRfq != null ? (object) FolioRfq : throw new ArgumentNullException(nameof (FolioRfq));
      if (Descripcion == null)
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) Descripcion;
      this.Adapter.UpdateCommand.Parameters[3].Value = (object) IdUsuarioVendedor;
      this.Adapter.UpdateCommand.Parameters[4].Value = (object) IdUsuarioCoordinador;
      if (Empresa == null)
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) Empresa;
      if (Contacto == null)
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) Contacto;
      if (FechaRfq.HasValue)
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) FechaRfq.Value;
      else
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) DBNull.Value;
      if (FechaEntrega.HasValue)
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) FechaEntrega.Value;
      else
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) DBNull.Value;
      if (Enviado.HasValue)
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) Enviado.Value;
      else
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) DBNull.Value;
      if (Estatus.HasValue)
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) Estatus.Value;
      else
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) DBNull.Value;
      if (Seguimiento == null)
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) Seguimiento;
      if (FechaAlta.HasValue)
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) FechaAlta.Value;
      else
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) DBNull.Value;
      if (IdUsuarioAlta.HasValue)
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) IdUsuarioAlta.Value;
      else
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) DBNull.Value;
      this.Adapter.UpdateCommand.Parameters[14].Value = (object) Original_IdRfqVentas;
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
      string FolioRfq,
      string Descripcion,
      Guid IdUsuarioVendedor,
      Guid IdUsuarioCoordinador,
      string Empresa,
      string Contacto,
      DateTime? FechaRfq,
      DateTime? FechaEntrega,
      int? Enviado,
      int? Estatus,
      string Seguimiento,
      DateTime? FechaAlta,
      Guid? IdUsuarioAlta,
      Guid Original_IdRfqVentas)
    {
      return this.Update(Original_IdRfqVentas, FolioRfq, Descripcion, IdUsuarioVendedor, IdUsuarioCoordinador, Empresa, Contacto, FechaRfq, FechaEntrega, Enviado, Estatus, Seguimiento, FechaAlta, IdUsuarioAlta, Original_IdRfqVentas);
    }
  }
}
