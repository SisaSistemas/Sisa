// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDev_RecibidaTableAdapters.sp_CargarFacturasRecibidasTableAdapter
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

namespace SisaDev.SisaDev_RecibidaTableAdapters
{
  [DesignerCategory("code")]
  [ToolboxItem(true)]
  [DataObject(true)]
  [Designer("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
  [HelpKeyword("vs.data.TableAdapter")]
  public class sp_CargarFacturasRecibidasTableAdapter : Component
  {
    private SqlDataAdapter _adapter;
    private SqlConnection _connection;
    private SqlTransaction _transaction;
    private SqlCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public sp_CargarFacturasRecibidasTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "sp_CargarFacturasRecibidas",
        ColumnMappings = {
          {
            "IdControlFacturas",
            "IdControlFacturas"
          },
          {
            "FechaFactura",
            "FechaFactura"
          },
          {
            "IdProveedor",
            "IdProveedor"
          },
          {
            "NoFactura",
            "NoFactura"
          },
          {
            "OrdenCompra",
            "OrdenCompra"
          },
          {
            "Proyecto",
            "Proyecto"
          },
          {
            "Moneda",
            "Moneda"
          },
          {
            "SubTotal",
            "SubTotal"
          },
          {
            "Descuento",
            "Descuento"
          },
          {
            "IVA",
            "IVA"
          },
          {
            "Total",
            "Total"
          },
          {
            "Estatus",
            "Estatus"
          },
          {
            "FormaPago",
            "FormaPago"
          },
          {
            "Proveedor",
            "Proveedor"
          },
          {
            "IdOrdenCompra",
            "IdOrdenCompra"
          },
          {
            "IdProyecto",
            "IdProyecto"
          },
          {
            "Viaticos",
            "Viaticos"
          },
          {
            "FechaPago",
            "FechaPago"
          },
          {
            "NombreArchivo",
            "NombreArchivo"
          },
          {
            "Categoria",
            "Categoria"
          },
          {
            "Anticipo",
            "Anticipo"
          },
          {
            "NotaCredito",
            "NotaCredito"
          },
          {
            "APagar",
            "APagar"
          },
          {
            "EstatusProyecto",
            "EstatusProyecto"
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
      this._commandCollection[0].CommandText = "dbo.sp_CargarFacturasRecibidas";
      this._commandCollection[0].CommandType = CommandType.StoredProcedure;
      this._commandCollection[0].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[0].Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar, 6, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(
      SisaDev_Recibida.sp_CargarFacturasRecibidasDataTable dataTable,
      string id)
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      if (id == null)
        this.Adapter.SelectCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[1].Value = (object) id;
      if (this.ClearBeforeFill)
        dataTable.Clear();
      return this.Adapter.Fill((DataTable) dataTable);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public virtual SisaDev_Recibida.sp_CargarFacturasRecibidasDataTable GetData(
      string id)
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      if (id == null)
        this.Adapter.SelectCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[1].Value = (object) id;
      SisaDev_Recibida.sp_CargarFacturasRecibidasDataTable recibidasDataTable = new SisaDev_Recibida.sp_CargarFacturasRecibidasDataTable();
      this.Adapter.Fill((DataTable) recibidasDataTable);
      return recibidasDataTable;
    }
  }
}
