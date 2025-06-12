// Decompiled with JetBrains decompiler
// Type: SisaDev.Rpt.SisaTableAdapters.sp_InsertOrdenCompraTableAdapter
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
  public class sp_InsertOrdenCompraTableAdapter : Component
  {
    private SqlDataAdapter _adapter;
    private SqlConnection _connection;
    private SqlTransaction _transaction;
    private SqlCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public sp_InsertOrdenCompraTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "sp_InsertOrdenCompra",
        ColumnMappings = {
          {
            "IdOrdenCompra",
            "IdOrdenCompra"
          },
          {
            "NoOrdenCompra",
            "NoOrdenCompra"
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
      this._commandCollection[0].CommandText = "dbo.sp_InsertOrdenCompra";
      this._commandCollection[0].CommandType = CommandType.StoredProcedure;
      this._commandCollection[0].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[0].Parameters.Add(new SqlParameter("@Folio", SqlDbType.VarChar, 50, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[0].Parameters.Add(new SqlParameter("@IdProveedor", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[0].Parameters.Add(new SqlParameter("@ReferenciaCot", SqlDbType.VarChar, 200, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[0].Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[0].Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[0].Parameters.Add(new SqlParameter("@SubTotal", SqlDbType.Decimal, 9, ParameterDirection.Input, (byte) 18, (byte) 2, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[0].Parameters.Add(new SqlParameter("@Iva", SqlDbType.Decimal, 9, ParameterDirection.Input, (byte) 18, (byte) 2, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[0].Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Int, 4, ParameterDirection.Input, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[0].Parameters.Add(new SqlParameter("@IdMoneda", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[0].Parameters.Add(new SqlParameter("@CondicionPago", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[0].Parameters.Add(new SqlParameter("@Comentarios", SqlDbType.VarChar, int.MaxValue, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[0].Parameters.Add(new SqlParameter("@IdUsuarioModifica", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[0].Parameters.Add(new SqlParameter("@Descuento", SqlDbType.Decimal, 9, ParameterDirection.Input, (byte) 18, (byte) 2, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[0].Parameters.Add(new SqlParameter("@IdUsuarioAprobo", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[0].Parameters.Add(new SqlParameter("@TipoOC", SqlDbType.VarChar, 50, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[0].Parameters.Add(new SqlParameter("@Sucursal", SqlDbType.VarChar, 50, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(
      Sisa.sp_InsertOrdenCompraDataTable dataTable,
      string Folio,
      string IdProveedor,
      string ReferenciaCot,
      string IdProyecto,
      string IdUsuario,
      Decimal? SubTotal,
      Decimal? Iva,
      int? Estatus,
      string IdMoneda,
      string CondicionPago,
      string Comentarios,
      string IdUsuarioModifica,
      Decimal? Descuento,
      string IdUsuarioAprobo,
      string TipoOC,
      string Sucursal)
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      if (Folio == null)
        this.Adapter.SelectCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[1].Value = (object) Folio;
      if (IdProveedor == null)
        this.Adapter.SelectCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[2].Value = (object) IdProveedor;
      if (ReferenciaCot == null)
        this.Adapter.SelectCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[3].Value = (object) ReferenciaCot;
      if (IdProyecto == null)
        this.Adapter.SelectCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[4].Value = (object) IdProyecto;
      if (IdUsuario == null)
        this.Adapter.SelectCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[5].Value = (object) IdUsuario;
      if (SubTotal.HasValue)
        this.Adapter.SelectCommand.Parameters[6].Value = (object) SubTotal.Value;
      else
        this.Adapter.SelectCommand.Parameters[6].Value = (object) DBNull.Value;
      if (Iva.HasValue)
        this.Adapter.SelectCommand.Parameters[7].Value = (object) Iva.Value;
      else
        this.Adapter.SelectCommand.Parameters[7].Value = (object) DBNull.Value;
      if (Estatus.HasValue)
        this.Adapter.SelectCommand.Parameters[8].Value = (object) Estatus.Value;
      else
        this.Adapter.SelectCommand.Parameters[8].Value = (object) DBNull.Value;
      if (IdMoneda == null)
        this.Adapter.SelectCommand.Parameters[9].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[9].Value = (object) IdMoneda;
      if (CondicionPago == null)
        this.Adapter.SelectCommand.Parameters[10].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[10].Value = (object) CondicionPago;
      if (Comentarios == null)
        this.Adapter.SelectCommand.Parameters[11].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[11].Value = (object) Comentarios;
      if (IdUsuarioModifica == null)
        this.Adapter.SelectCommand.Parameters[12].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[12].Value = (object) IdUsuarioModifica;
      if (Descuento.HasValue)
        this.Adapter.SelectCommand.Parameters[13].Value = (object) Descuento.Value;
      else
        this.Adapter.SelectCommand.Parameters[13].Value = (object) DBNull.Value;
      if (IdUsuarioAprobo == null)
        this.Adapter.SelectCommand.Parameters[14].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[14].Value = (object) IdUsuarioAprobo;
      if (TipoOC == null)
        this.Adapter.SelectCommand.Parameters[15].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[15].Value = (object) TipoOC;
      if (Sucursal == null)
        this.Adapter.SelectCommand.Parameters[16].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[16].Value = (object) Sucursal;
      if (this.ClearBeforeFill)
        dataTable.Clear();
      return this.Adapter.Fill((DataTable) dataTable);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public virtual Sisa.sp_InsertOrdenCompraDataTable GetData(
      string Folio,
      string IdProveedor,
      string ReferenciaCot,
      string IdProyecto,
      string IdUsuario,
      Decimal? SubTotal,
      Decimal? Iva,
      int? Estatus,
      string IdMoneda,
      string CondicionPago,
      string Comentarios,
      string IdUsuarioModifica,
      Decimal? Descuento,
      string IdUsuarioAprobo,
      string TipoOC,
      string Sucursal)
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      if (Folio == null)
        this.Adapter.SelectCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[1].Value = (object) Folio;
      if (IdProveedor == null)
        this.Adapter.SelectCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[2].Value = (object) IdProveedor;
      if (ReferenciaCot == null)
        this.Adapter.SelectCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[3].Value = (object) ReferenciaCot;
      if (IdProyecto == null)
        this.Adapter.SelectCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[4].Value = (object) IdProyecto;
      if (IdUsuario == null)
        this.Adapter.SelectCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[5].Value = (object) IdUsuario;
      if (SubTotal.HasValue)
        this.Adapter.SelectCommand.Parameters[6].Value = (object) SubTotal.Value;
      else
        this.Adapter.SelectCommand.Parameters[6].Value = (object) DBNull.Value;
      if (Iva.HasValue)
        this.Adapter.SelectCommand.Parameters[7].Value = (object) Iva.Value;
      else
        this.Adapter.SelectCommand.Parameters[7].Value = (object) DBNull.Value;
      if (Estatus.HasValue)
        this.Adapter.SelectCommand.Parameters[8].Value = (object) Estatus.Value;
      else
        this.Adapter.SelectCommand.Parameters[8].Value = (object) DBNull.Value;
      if (IdMoneda == null)
        this.Adapter.SelectCommand.Parameters[9].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[9].Value = (object) IdMoneda;
      if (CondicionPago == null)
        this.Adapter.SelectCommand.Parameters[10].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[10].Value = (object) CondicionPago;
      if (Comentarios == null)
        this.Adapter.SelectCommand.Parameters[11].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[11].Value = (object) Comentarios;
      if (IdUsuarioModifica == null)
        this.Adapter.SelectCommand.Parameters[12].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[12].Value = (object) IdUsuarioModifica;
      if (Descuento.HasValue)
        this.Adapter.SelectCommand.Parameters[13].Value = (object) Descuento.Value;
      else
        this.Adapter.SelectCommand.Parameters[13].Value = (object) DBNull.Value;
      if (IdUsuarioAprobo == null)
        this.Adapter.SelectCommand.Parameters[14].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[14].Value = (object) IdUsuarioAprobo;
      if (TipoOC == null)
        this.Adapter.SelectCommand.Parameters[15].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[15].Value = (object) TipoOC;
      if (Sucursal == null)
        this.Adapter.SelectCommand.Parameters[16].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[16].Value = (object) Sucursal;
      Sisa.sp_InsertOrdenCompraDataTable ordenCompraDataTable = new Sisa.sp_InsertOrdenCompraDataTable();
      this.Adapter.Fill((DataTable) ordenCompraDataTable);
      return ordenCompraDataTable;
    }
  }
}
