// Decompiled with JetBrains decompiler
// Type: SisaDev.Rpt.SisaTableAdapters.sp_GeneraReporteRFQTableAdapter
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
  public class sp_GeneraReporteRFQTableAdapter : Component
  {
    private SqlDataAdapter _adapter;
    private SqlConnection _connection;
    private SqlTransaction _transaction;
    private SqlCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public sp_GeneraReporteRFQTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "sp_GeneraReporteRFQ",
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
            "idContacto",
            "idContacto"
          },
          {
            "idEmpresa",
            "idEmpresa"
          },
          {
            "NombreContacto",
            "NombreContacto"
          },
          {
            "Telefono",
            "Telefono"
          },
          {
            "Foto",
            "Foto"
          },
          {
            "Correo",
            "Correo"
          },
          {
            "TIMESTAMP",
            "TIMESTAMP"
          },
          {
            "Estatus1",
            "Estatus1"
          },
          {
            "Usuario",
            "Usuario"
          },
          {
            "Clave",
            "Clave"
          },
          {
            "idEmpresa1",
            "idEmpresa1"
          },
          {
            "RazonSocial",
            "RazonSocial"
          },
          {
            "DireccionFiscal",
            "DireccionFiscal"
          },
          {
            "Telefono1",
            "Telefono1"
          },
          {
            "TIMESTAMP1",
            "TIMESTAMP1"
          },
          {
            "RFC",
            "RFC"
          },
          {
            "Correo1",
            "Correo1"
          },
          {
            "CP",
            "CP"
          },
          {
            "Ciudad",
            "Ciudad"
          },
          {
            "Estatus2",
            "Estatus2"
          },
          {
            "IdUsuario",
            "IdUsuario"
          },
          {
            "NombreCompleto",
            "NombreCompleto"
          },
          {
            "Usuario1",
            "Usuario1"
          },
          {
            "Contrasena",
            "Contrasena"
          },
          {
            "Foto1",
            "Foto1"
          },
          {
            "Permisos",
            "Permisos"
          },
          {
            "Puesto",
            "Puesto"
          },
          {
            "Telefono2",
            "Telefono2"
          },
          {
            "Correo2",
            "Correo2"
          },
          {
            "FechaAlta1",
            "FechaAlta1"
          },
          {
            "IdUsuarioModificacion",
            "IdUsuarioModificacion"
          },
          {
            "FechaModificacion1",
            "FechaModificacion1"
          },
          {
            "Activo",
            "Activo"
          },
          {
            "EsLiderProyecto",
            "EsLiderProyecto"
          },
          {
            "Perfil",
            "Perfil"
          },
          {
            "SueldoDiario",
            "SueldoDiario"
          },
          {
            "idSucursal",
            "idSucursal"
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
      this._commandCollection[0].CommandText = "dbo.sp_GeneraReporteRFQ";
      this._commandCollection[0].CommandType = CommandType.StoredProcedure;
      this._commandCollection[0].Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, (byte) 10, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
      this._commandCollection[0].Parameters.Add(new SqlParameter("@IdRfq", SqlDbType.VarChar, 150, ParameterDirection.Input, (byte) 0, (byte) 0, (string) null, DataRowVersion.Current, false, (object) null, "", "", ""));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(Sisa.sp_GeneraReporteRFQDataTable dataTable, string IdRfq)
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      if (IdRfq == null)
        this.Adapter.SelectCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[1].Value = (object) IdRfq;
      if (this.ClearBeforeFill)
        dataTable.Clear();
      return this.Adapter.Fill((DataTable) dataTable);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public virtual Sisa.sp_GeneraReporteRFQDataTable GetData(string IdRfq)
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      if (IdRfq == null)
        this.Adapter.SelectCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.SelectCommand.Parameters[1].Value = (object) IdRfq;
      Sisa.sp_GeneraReporteRFQDataTable reporteRfqDataTable = new Sisa.sp_GeneraReporteRFQDataTable();
      this.Adapter.Fill((DataTable) reporteRfqDataTable);
      return reporteRfqDataTable;
    }
  }
}
