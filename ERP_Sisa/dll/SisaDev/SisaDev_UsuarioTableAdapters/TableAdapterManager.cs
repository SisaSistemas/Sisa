// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDev_UsuarioTableAdapters.TableAdapterManager
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SisaDev.SisaDev_UsuarioTableAdapters
{
  [DesignerCategory("code")]
  [ToolboxItem(true)]
  [Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
  [HelpKeyword("vs.data.TableAdapterManager")]
  public class TableAdapterManager : Component
  {
    private TableAdapterManager.UpdateOrderOption _updateOrder;
    private tblSucursalesTableAdapter _tblSucursalesTableAdapter;
    private tblUsuariosTableAdapter _tblUsuariosTableAdapter;
    private bool _backupDataSetBeforeUpdate;
    private IDbConnection _connection;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public TableAdapterManager.UpdateOrderOption UpdateOrder
    {
      get => this._updateOrder;
      set => this._updateOrder = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblSucursalesTableAdapter tblSucursalesTableAdapter
    {
      get => this._tblSucursalesTableAdapter;
      set => this._tblSucursalesTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Editor("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor")]
    public tblUsuariosTableAdapter tblUsuariosTableAdapter
    {
      get => this._tblUsuariosTableAdapter;
      set => this._tblUsuariosTableAdapter = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public bool BackupDataSetBeforeUpdate
    {
      get => this._backupDataSetBeforeUpdate;
      set => this._backupDataSetBeforeUpdate = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Browsable(false)]
    public IDbConnection Connection
    {
      get
      {
        if (this._connection != null)
          return this._connection;
        if (this._tblSucursalesTableAdapter != null && this._tblSucursalesTableAdapter.Connection != null)
          return (IDbConnection) this._tblSucursalesTableAdapter.Connection;
        return this._tblUsuariosTableAdapter != null && this._tblUsuariosTableAdapter.Connection != null ? (IDbConnection) this._tblUsuariosTableAdapter.Connection : (IDbConnection) null;
      }
      set => this._connection = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Browsable(false)]
    public int TableAdapterInstanceCount
    {
      get
      {
        int num = 0;
        if (this._tblSucursalesTableAdapter != null)
          ++num;
        if (this._tblUsuariosTableAdapter != null)
          ++num;
        return num;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private int UpdateUpdatedRows(
      SisaDev_Usuario dataSet,
      List<DataRow> allChangedRows,
      List<DataRow> allAddedRows)
    {
      int num = 0;
      if (this._tblSucursalesTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblSucursales.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblSucursalesTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      if (this._tblUsuariosTableAdapter != null)
      {
        DataRow[] realUpdatedRows = this.GetRealUpdatedRows(dataSet.tblUsuarios.Select((string) null, (string) null, DataViewRowState.ModifiedCurrent), allAddedRows);
        if (realUpdatedRows != null && realUpdatedRows.Length != 0)
        {
          num += this._tblUsuariosTableAdapter.Update(realUpdatedRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) realUpdatedRows);
        }
      }
      return num;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private int UpdateInsertedRows(SisaDev_Usuario dataSet, List<DataRow> allAddedRows)
    {
      int num = 0;
      if (this._tblSucursalesTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblSucursales.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblSucursalesTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblUsuariosTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblUsuarios.Select((string) null, (string) null, DataViewRowState.Added);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblUsuariosTableAdapter.Update(dataRows);
          allAddedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      return num;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private int UpdateDeletedRows(SisaDev_Usuario dataSet, List<DataRow> allChangedRows)
    {
      int num = 0;
      if (this._tblUsuariosTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblUsuarios.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblUsuariosTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      if (this._tblSucursalesTableAdapter != null)
      {
        DataRow[] dataRows = dataSet.tblSucursales.Select((string) null, (string) null, DataViewRowState.Deleted);
        if (dataRows != null && dataRows.Length != 0)
        {
          num += this._tblSucursalesTableAdapter.Update(dataRows);
          allChangedRows.AddRange((IEnumerable<DataRow>) dataRows);
        }
      }
      return num;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private DataRow[] GetRealUpdatedRows(DataRow[] updatedRows, List<DataRow> allAddedRows)
    {
      if (updatedRows == null || updatedRows.Length < 1 || allAddedRows == null || allAddedRows.Count < 1)
        return updatedRows;
      List<DataRow> dataRowList = new List<DataRow>();
      for (int index = 0; index < updatedRows.Length; ++index)
      {
        DataRow updatedRow = updatedRows[index];
        if (!allAddedRows.Contains(updatedRow))
          dataRowList.Add(updatedRow);
      }
      return dataRowList.ToArray();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public virtual int UpdateAll(SisaDev_Usuario dataSet)
    {
      if (dataSet == null)
        throw new ArgumentNullException(nameof (dataSet));
      if (!dataSet.HasChanges())
        return 0;
      if (this._tblSucursalesTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblSucursalesTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      if (this._tblUsuariosTableAdapter != null && !this.MatchTableAdapterConnection((IDbConnection) this._tblUsuariosTableAdapter.Connection))
        throw new ArgumentException("Todos los TableAdapters administrados por un TableAdapterManager deben usar la misma cadena de conexión.");
      IDbConnection connection = this.Connection;
      if (connection == null)
        throw new ApplicationException("TableAdapterManager no contiene información de conexión. Establezca cada propiedad TableAdapterManager TableAdapter en una instancia TableAdapter válida.");
      bool flag = false;
      if ((connection.State & ConnectionState.Broken) == ConnectionState.Broken)
        connection.Close();
      if (connection.State == ConnectionState.Closed)
      {
        connection.Open();
        flag = true;
      }
      IDbTransaction dbTransaction = connection.BeginTransaction();
      if (dbTransaction == null)
        throw new ApplicationException("La transacción no puede comenzar. La conexión de datos actual no es compatible con las transacciones o el estado actual no permite que comience la transacción.");
      List<DataRow> allChangedRows = new List<DataRow>();
      List<DataRow> allAddedRows = new List<DataRow>();
      List<DataAdapter> dataAdapterList = new List<DataAdapter>();
      Dictionary<object, IDbConnection> dictionary = new Dictionary<object, IDbConnection>();
      int num = 0;
      DataSet dataSet1 = (DataSet) null;
      if (this.BackupDataSetBeforeUpdate)
      {
        dataSet1 = new DataSet();
        dataSet1.Merge((DataSet) dataSet);
      }
      try
      {
        if (this._tblSucursalesTableAdapter != null)
        {
          dictionary.Add((object) this._tblSucursalesTableAdapter, (IDbConnection) this._tblSucursalesTableAdapter.Connection);
          this._tblSucursalesTableAdapter.Connection = (SqlConnection) connection;
          this._tblSucursalesTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblSucursalesTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblSucursalesTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblSucursalesTableAdapter.Adapter);
          }
        }
        if (this._tblUsuariosTableAdapter != null)
        {
          dictionary.Add((object) this._tblUsuariosTableAdapter, (IDbConnection) this._tblUsuariosTableAdapter.Connection);
          this._tblUsuariosTableAdapter.Connection = (SqlConnection) connection;
          this._tblUsuariosTableAdapter.Transaction = (SqlTransaction) dbTransaction;
          if (this._tblUsuariosTableAdapter.Adapter.AcceptChangesDuringUpdate)
          {
            this._tblUsuariosTableAdapter.Adapter.AcceptChangesDuringUpdate = false;
            dataAdapterList.Add((DataAdapter) this._tblUsuariosTableAdapter.Adapter);
          }
        }
        if (this.UpdateOrder == TableAdapterManager.UpdateOrderOption.UpdateInsertDelete)
        {
          num += this.UpdateUpdatedRows(dataSet, allChangedRows, allAddedRows);
          num += this.UpdateInsertedRows(dataSet, allAddedRows);
        }
        else
        {
          num += this.UpdateInsertedRows(dataSet, allAddedRows);
          num += this.UpdateUpdatedRows(dataSet, allChangedRows, allAddedRows);
        }
        num += this.UpdateDeletedRows(dataSet, allChangedRows);
        dbTransaction.Commit();
        if (0 < allAddedRows.Count)
        {
          DataRow[] array = new DataRow[allAddedRows.Count];
          allAddedRows.CopyTo(array);
          for (int index = 0; index < array.Length; ++index)
            array[index].AcceptChanges();
        }
        if (0 < allChangedRows.Count)
        {
          DataRow[] array = new DataRow[allChangedRows.Count];
          allChangedRows.CopyTo(array);
          for (int index = 0; index < array.Length; ++index)
            array[index].AcceptChanges();
        }
      }
      catch (Exception ex)
      {
        dbTransaction.Rollback();
        if (this.BackupDataSetBeforeUpdate)
        {
          dataSet.Clear();
          dataSet.Merge(dataSet1);
        }
        else if (0 < allAddedRows.Count)
        {
          DataRow[] array = new DataRow[allAddedRows.Count];
          allAddedRows.CopyTo(array);
          for (int index = 0; index < array.Length; ++index)
          {
            DataRow dataRow = array[index];
            dataRow.AcceptChanges();
            dataRow.SetAdded();
          }
        }
        throw ex;
      }
      finally
      {
        if (flag)
          connection.Close();
        if (this._tblSucursalesTableAdapter != null)
        {
          this._tblSucursalesTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblSucursalesTableAdapter];
          this._tblSucursalesTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (this._tblUsuariosTableAdapter != null)
        {
          this._tblUsuariosTableAdapter.Connection = (SqlConnection) dictionary[(object) this._tblUsuariosTableAdapter];
          this._tblUsuariosTableAdapter.Transaction = (SqlTransaction) null;
        }
        if (0 < dataAdapterList.Count)
        {
          DataAdapter[] array = new DataAdapter[dataAdapterList.Count];
          dataAdapterList.CopyTo(array);
          for (int index = 0; index < array.Length; ++index)
            array[index].AcceptChangesDuringUpdate = true;
        }
      }
      return num;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    protected virtual void SortSelfReferenceRows(
      DataRow[] rows,
      DataRelation relation,
      bool childFirst)
    {
      Array.Sort<DataRow>(rows, (IComparer<DataRow>) new TableAdapterManager.SelfReferenceComparer(relation, childFirst));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    protected virtual bool MatchTableAdapterConnection(IDbConnection inputConnection) => this._connection != null || this.Connection == null || inputConnection == null || string.Equals(this.Connection.ConnectionString, inputConnection.ConnectionString, StringComparison.Ordinal);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public enum UpdateOrderOption
    {
      InsertUpdateDelete,
      UpdateInsertDelete,
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private class SelfReferenceComparer : IComparer<DataRow>
    {
      private DataRelation _relation;
      private int _childFirst;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal SelfReferenceComparer(DataRelation relation, bool childFirst)
      {
        this._relation = relation;
        if (childFirst)
          this._childFirst = -1;
        else
          this._childFirst = 1;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private DataRow GetRoot(DataRow row, out int distance)
      {
        DataRow dataRow = row;
        distance = 0;
        IDictionary<DataRow, DataRow> dictionary = (IDictionary<DataRow, DataRow>) new Dictionary<DataRow, DataRow>();
        dictionary[row] = row;
        for (DataRow parentRow = row.GetParentRow(this._relation, DataRowVersion.Default); parentRow != null && !dictionary.ContainsKey(parentRow); parentRow = parentRow.GetParentRow(this._relation, DataRowVersion.Default))
        {
          ++distance;
          dataRow = parentRow;
          dictionary[parentRow] = parentRow;
        }
        if (distance == 0)
        {
          dictionary.Clear();
          dictionary[row] = row;
          for (DataRow parentRow = row.GetParentRow(this._relation, DataRowVersion.Original); parentRow != null && !dictionary.ContainsKey(parentRow); parentRow = parentRow.GetParentRow(this._relation, DataRowVersion.Original))
          {
            ++distance;
            dataRow = parentRow;
            dictionary[parentRow] = parentRow;
          }
        }
        return dataRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Compare(DataRow row1, DataRow row2)
      {
        if (row1 == row2)
          return 0;
        if (row1 == null)
          return -1;
        if (row2 == null)
          return 1;
        int distance1 = 0;
        DataRow root1 = this.GetRoot(row1, out distance1);
        int distance2 = 0;
        DataRow root2 = this.GetRoot(row2, out distance2);
        if (root1 == root2)
          return this._childFirst * distance1.CompareTo(distance2);
        return root1.Table.Rows.IndexOf(root1) < root2.Table.Rows.IndexOf(root2) ? -1 : 1;
      }
    }
  }
}
