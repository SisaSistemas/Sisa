// Decompiled with JetBrains decompiler
// Type: SisaDev.Rpt.SisaTableAdapters.JT_InsertUpdateServicioComputoTableAdapter
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

namespace SisaDev.Rpt.SisaTableAdapters
{
  [DesignerCategory("code")]
  [ToolboxItem(true)]
  [DataObject(true)]
  [Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
  [HelpKeyword("vs.data.TableAdapter")]
  public class JT_InsertUpdateServicioComputoTableAdapter : Component
  {
    private SqlDataAdapter _adapter;
    private SqlConnection _connection;
    private SqlTransaction _transaction;
    private SqlCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public JT_InsertUpdateServicioComputoTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "JT_InsertUpdateServicioComputo",
        ColumnMappings = {
          {
            "IdServicioComputo",
            "IdServicioComputo"
          }
        }
      });
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
      this._commandCollection[0].CommandText = "dbo.JT_InsertUpdateServicioComputo";
      this._commandCollection[0].CommandType = CommandType.StoredProcedure;
      this._commandCollection[0].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[0].Parameters.Add(new SqlParameter("@IdServicioComputo", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[0].Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[0].Parameters.Add(new SqlParameter("@Tipo", SqlDbType.VarChar, 50, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[0].Parameters.Add(new SqlParameter("@Marca", SqlDbType.VarChar, 100, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[0].Parameters.Add(new SqlParameter("@Modelo", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[0].Parameters.Add(new SqlParameter("@NoSerie", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[0].Parameters.Add(new SqlParameter("@Comentarios", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[0].Parameters.Add(new SqlParameter("@FechaMantenimiento", SqlDbType.Date, 3, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[0].Parameters.Add(new SqlParameter("@Completado", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(
      Sisa.JT_InsertUpdateServicioComputoDataTable dataTable,
      string IdServicioComputo,
      string IdUsuario,
      string Tipo,
      string Marca,
      string Modelo,
      string NoSerie,
      string Comentarios,
      DateTime? FechaMantenimiento,
      int? Completado)
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      if (IdServicioComputo == null)
        this.Adapter.SelectCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[1].Value = (object) IdServicioComputo;
      if (IdUsuario == null)
        this.Adapter.SelectCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[2].Value = (object) IdUsuario;
      if (Tipo == null)
        this.Adapter.SelectCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[3].Value = (object) Tipo;
      if (Marca == null)
        this.Adapter.SelectCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[4].Value = (object) Marca;
      if (Modelo == null)
        this.Adapter.SelectCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[5].Value = (object) Modelo;
      if (NoSerie == null)
        this.Adapter.SelectCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[6].Value = (object) NoSerie;
      if (Comentarios == null)
        this.Adapter.SelectCommand.Parameters[7].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[7].Value = (object) Comentarios;
      if (FechaMantenimiento.HasValue)
        this.Adapter.SelectCommand.Parameters[8].Value = (object) FechaMantenimiento.Value;
      else
        this.Adapter.SelectCommand.Parameters[8].Value = (object) DBNull.Value;
      if (Completado.HasValue)
        this.Adapter.SelectCommand.Parameters[9].Value = (object) Completado.Value;
      else
        this.Adapter.SelectCommand.Parameters[9].Value = (object) DBNull.Value;
      if (this.ClearBeforeFill)
        dataTable.Clear();
      return this.Adapter.Fill((DataTable) dataTable);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public virtual Sisa.JT_InsertUpdateServicioComputoDataTable GetData(
      string IdServicioComputo,
      string IdUsuario,
      string Tipo,
      string Marca,
      string Modelo,
      string NoSerie,
      string Comentarios,
      DateTime? FechaMantenimiento,
      int? Completado)
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      if (IdServicioComputo == null)
        this.Adapter.SelectCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[1].Value = (object) IdServicioComputo;
      if (IdUsuario == null)
        this.Adapter.SelectCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[2].Value = (object) IdUsuario;
      if (Tipo == null)
        this.Adapter.SelectCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[3].Value = (object) Tipo;
      if (Marca == null)
        this.Adapter.SelectCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[4].Value = (object) Marca;
      if (Modelo == null)
        this.Adapter.SelectCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[5].Value = (object) Modelo;
      if (NoSerie == null)
        this.Adapter.SelectCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[6].Value = (object) NoSerie;
      if (Comentarios == null)
        this.Adapter.SelectCommand.Parameters[7].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[7].Value = (object) Comentarios;
      if (FechaMantenimiento.HasValue)
        this.Adapter.SelectCommand.Parameters[8].Value = (object) FechaMantenimiento.Value;
      else
        this.Adapter.SelectCommand.Parameters[8].Value = (object) DBNull.Value;
      if (Completado.HasValue)
        this.Adapter.SelectCommand.Parameters[9].Value = (object) Completado.Value;
      else
        this.Adapter.SelectCommand.Parameters[9].Value = (object) DBNull.Value;
      Sisa.JT_InsertUpdateServicioComputoDataTable computoDataTable = new Sisa.JT_InsertUpdateServicioComputoDataTable();
      this.Adapter.Fill((DataTable) computoDataTable);
      return computoDataTable;
    }
  }
}
