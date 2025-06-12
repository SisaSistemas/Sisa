// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDevFacturasTableAdapters.tblInvHerramientasDetTableAdapter
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
  public class tblInvHerramientasDetTableAdapter : Component
  {
    private SqlDataAdapter _adapter;
    private SqlConnection _connection;
    private SqlTransaction _transaction;
    private SqlCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public tblInvHerramientasDetTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblInvHerramientasDet",
        ColumnMappings = {
          {
            "IdHerramientaDet",
            "IdHerramientaDet"
          },
          {
            "IdHerramienta",
            "IdHerramienta"
          },
          {
            "NoCodigo",
            "NoCodigo"
          },
          {
            "Descripcion",
            "Descripcion"
          },
          {
            "Tipo",
            "Tipo"
          },
          {
            "NoSerie",
            "NoSerie"
          },
          {
            "Observaciones",
            "Observaciones"
          },
          {
            "Estatus",
            "Estatus"
          }
        }
      });
      this._adapter.DeleteCommand = new SqlCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[tblInvHerramientasDet] WHERE (([IdHerramientaDet] = @Original_IdHerramientaDet))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_IdHerramientaDet", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdHerramientaDet", DataRowVersion.Original, false, (object) null, "", "", ""));
      this._adapter.InsertCommand = new SqlCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[tblInvHerramientasDet] ([IdHerramientaDet], [IdHerramienta], [NoCodigo], [Descripcion], [Tipo], [NoSerie], [Observaciones], [Estatus]) VALUES (@IdHerramientaDet, @IdHerramienta, @NoCodigo, @Descripcion, @Tipo, @NoSerie, @Observaciones, @Estatus)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdHerramientaDet", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdHerramientaDet", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdHerramienta", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdHerramienta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@NoCodigo", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoCodigo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Descripcion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Tipo", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Tipo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@NoSerie", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoSerie", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Observaciones", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Observaciones", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Estatus", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Estatus", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand = new SqlCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[tblInvHerramientasDet] SET [IdHerramientaDet] = @IdHerramientaDet, [IdHerramienta] = @IdHerramienta, [NoCodigo] = @NoCodigo, [Descripcion] = @Descripcion, [Tipo] = @Tipo, [NoSerie] = @NoSerie, [Observaciones] = @Observaciones, [Estatus] = @Estatus WHERE (([IdHerramientaDet] = @Original_IdHerramientaDet))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdHerramientaDet", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdHerramientaDet", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdHerramienta", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdHerramienta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@NoCodigo", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoCodigo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Descripcion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Tipo", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Tipo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@NoSerie", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoSerie", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Observaciones", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Observaciones", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Estatus", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Estatus", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_IdHerramientaDet", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdHerramientaDet", DataRowVersion.Original, false, (object) null, "", "", ""));
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
      this._commandCollection[0].CommandText = "SELECT IdHerramientaDet, IdHerramienta, NoCodigo, Descripcion, Tipo, NoSerie, Observaciones, Estatus FROM dbo.tblInvHerramientasDet";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(
      SisaDevFacturas.tblInvHerramientasDetDataTable dataTable)
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
    public virtual SisaDevFacturas.tblInvHerramientasDetDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      SisaDevFacturas.tblInvHerramientasDetDataTable herramientasDetDataTable = new SisaDevFacturas.tblInvHerramientasDetDataTable();
      this.Adapter.Fill((DataTable) herramientasDetDataTable);
      return herramientasDetDataTable;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(
      SisaDevFacturas.tblInvHerramientasDetDataTable dataTable)
    {
      return this.Adapter.Update((DataTable) dataTable);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas dataSet) => this.Adapter.Update((DataSet) dataSet, "tblInvHerramientasDet");

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
    public virtual int Delete(Guid Original_IdHerramientaDet)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) Original_IdHerramientaDet;
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
      Guid IdHerramientaDet,
      Guid IdHerramienta,
      string NoCodigo,
      string Descripcion,
      string Tipo,
      string NoSerie,
      string Observaciones,
      string Estatus)
    {
      this.Adapter.InsertCommand.Parameters[0].Value = (object) IdHerramientaDet;
      this.Adapter.InsertCommand.Parameters[1].Value = (object) IdHerramienta;
      this.Adapter.InsertCommand.Parameters[2].Value = NoCodigo != null ? (object) NoCodigo : throw new ArgumentNullException(nameof (NoCodigo));
      this.Adapter.InsertCommand.Parameters[3].Value = Descripcion != null ? (object) Descripcion : throw new ArgumentNullException(nameof (Descripcion));
      this.Adapter.InsertCommand.Parameters[4].Value = Tipo != null ? (object) Tipo : throw new ArgumentNullException(nameof (Tipo));
      this.Adapter.InsertCommand.Parameters[5].Value = NoSerie != null ? (object) NoSerie : throw new ArgumentNullException(nameof (NoSerie));
      this.Adapter.InsertCommand.Parameters[6].Value = Observaciones != null ? (object) Observaciones : throw new ArgumentNullException(nameof (Observaciones));
      this.Adapter.InsertCommand.Parameters[7].Value = Estatus != null ? (object) Estatus : throw new ArgumentNullException(nameof (Estatus));
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
      Guid IdHerramientaDet,
      Guid IdHerramienta,
      string NoCodigo,
      string Descripcion,
      string Tipo,
      string NoSerie,
      string Observaciones,
      string Estatus,
      Guid Original_IdHerramientaDet)
    {
      this.Adapter.UpdateCommand.Parameters[0].Value = (object) IdHerramientaDet;
      this.Adapter.UpdateCommand.Parameters[1].Value = (object) IdHerramienta;
      this.Adapter.UpdateCommand.Parameters[2].Value = NoCodigo != null ? (object) NoCodigo : throw new ArgumentNullException(nameof (NoCodigo));
      this.Adapter.UpdateCommand.Parameters[3].Value = Descripcion != null ? (object) Descripcion : throw new ArgumentNullException(nameof (Descripcion));
      this.Adapter.UpdateCommand.Parameters[4].Value = Tipo != null ? (object) Tipo : throw new ArgumentNullException(nameof (Tipo));
      this.Adapter.UpdateCommand.Parameters[5].Value = NoSerie != null ? (object) NoSerie : throw new ArgumentNullException(nameof (NoSerie));
      this.Adapter.UpdateCommand.Parameters[6].Value = Observaciones != null ? (object) Observaciones : throw new ArgumentNullException(nameof (Observaciones));
      this.Adapter.UpdateCommand.Parameters[7].Value = Estatus != null ? (object) Estatus : throw new ArgumentNullException(nameof (Estatus));
      this.Adapter.UpdateCommand.Parameters[8].Value = (object) Original_IdHerramientaDet;
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
      Guid IdHerramienta,
      string NoCodigo,
      string Descripcion,
      string Tipo,
      string NoSerie,
      string Observaciones,
      string Estatus,
      Guid Original_IdHerramientaDet)
    {
      return this.Update(Original_IdHerramientaDet, IdHerramienta, NoCodigo, Descripcion, Tipo, NoSerie, Observaciones, Estatus, Original_IdHerramientaDet);
    }
  }
}
