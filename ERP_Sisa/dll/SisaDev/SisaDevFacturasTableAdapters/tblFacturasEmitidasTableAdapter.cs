// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDevFacturasTableAdapters.tblFacturasEmitidasTableAdapter
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
  public class tblFacturasEmitidasTableAdapter : Component
  {
    private SqlDataAdapter _adapter;
    private SqlConnection _connection;
    private SqlTransaction _transaction;
    private SqlCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public tblFacturasEmitidasTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblFacturasEmitidas",
        ColumnMappings = {
          {
            "IdFacturasEmitidas",
            "IdFacturasEmitidas"
          },
          {
            "FolioFactura",
            "FolioFactura"
          },
          {
            "FechaFactura",
            "FechaFactura"
          },
          {
            "RfcReceptor",
            "RfcReceptor"
          },
          {
            "NombreReceptor",
            "NombreReceptor"
          },
          {
            "IdProyecto",
            "IdProyecto"
          },
          {
            "NoCotizacion",
            "NoCotizacion"
          },
          {
            "OrdenCompraRecibida",
            "OrdenCompraRecibida"
          },
          {
            "SubTotal",
            "SubTotal"
          },
          {
            "Iva",
            "Iva"
          },
          {
            "Total",
            "Total"
          },
          {
            "Moneda",
            "Moneda"
          },
          {
            "ProgramacionPago",
            "ProgramacionPago"
          },
          {
            "PorPagar",
            "PorPagar"
          },
          {
            "FechaPago",
            "FechaPago"
          },
          {
            "Estatus",
            "Estatus"
          },
          {
            "TipoCambio",
            "TipoCambio"
          },
          {
            "IdUsuario",
            "IdUsuario"
          },
          {
            "FechaAlta",
            "FechaAlta"
          },
          {
            "IdUsuarioModificacion",
            "IdUsuarioModificacion"
          },
          {
            "FechaModificacion",
            "FechaModificacion"
          },
          {
            "Retencion",
            "Retencion"
          },
          {
            "NombreArchivo",
            "NombreArchivo"
          },
          {
            "ArchivoPDF",
            "ArchivoPDF"
          }
        }
      });
      this._adapter.DeleteCommand = new SqlCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[tblFacturasEmitidas] WHERE (([IdFacturasEmitidas] = @Original_IdFacturasEmitidas))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_IdFacturasEmitidas", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdFacturasEmitidas", DataRowVersion.Original, false, (object) null, "", "", ""));
      this._adapter.InsertCommand = new SqlCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[tblFacturasEmitidas] ([IdFacturasEmitidas], [FolioFactura], [FechaFactura], [RfcReceptor], [NombreReceptor], [IdProyecto], [NoCotizacion], [OrdenCompraRecibida], [SubTotal], [Iva], [Total], [Moneda], [ProgramacionPago], [PorPagar], [FechaPago], [Estatus], [TipoCambio], [IdUsuario], [FechaAlta], [IdUsuarioModificacion], [FechaModificacion], [Retencion], [NombreArchivo], [ArchivoPDF]) VALUES (@IdFacturasEmitidas, @FolioFactura, @FechaFactura, @RfcReceptor, @NombreReceptor, @IdProyecto, @NoCotizacion, @OrdenCompraRecibida, @SubTotal, @Iva, @Total, @Moneda, @ProgramacionPago, @PorPagar, @FechaPago, @Estatus, @TipoCambio, @IdUsuario, @FechaAlta, @IdUsuarioModificacion, @FechaModificacion, @Retencion, @NombreArchivo, @ArchivoPDF)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdFacturasEmitidas", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdFacturasEmitidas", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FolioFactura", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FolioFactura", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaFactura", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaFactura", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@RfcReceptor", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RfcReceptor", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@NombreReceptor", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NombreReceptor", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdProyecto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@NoCotizacion", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoCotizacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@OrdenCompraRecibida", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OrdenCompraRecibida", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@SubTotal", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 20, (byte) 2, "SubTotal", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Iva", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 20, (byte) 2, "Iva", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Total", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 20, (byte) 2, "Total", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Moneda", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Moneda", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ProgramacionPago", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ProgramacionPago", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@PorPagar", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 20, (byte) 2, "PorPagar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaPago", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaPago", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Estatus", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@TipoCambio", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 20, (byte) 6, "TipoCambio", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuario", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaAlta", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuarioModificacion", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaModificacion", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Retencion", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 20, (byte) 2, "Retencion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@NombreArchivo", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NombreArchivo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ArchivoPDF", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ArchivoPDF", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand = new SqlCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[tblFacturasEmitidas] SET [IdFacturasEmitidas] = @IdFacturasEmitidas, [FolioFactura] = @FolioFactura, [FechaFactura] = @FechaFactura, [RfcReceptor] = @RfcReceptor, [NombreReceptor] = @NombreReceptor, [IdProyecto] = @IdProyecto, [NoCotizacion] = @NoCotizacion, [OrdenCompraRecibida] = @OrdenCompraRecibida, [SubTotal] = @SubTotal, [Iva] = @Iva, [Total] = @Total, [Moneda] = @Moneda, [ProgramacionPago] = @ProgramacionPago, [PorPagar] = @PorPagar, [FechaPago] = @FechaPago, [Estatus] = @Estatus, [TipoCambio] = @TipoCambio, [IdUsuario] = @IdUsuario, [FechaAlta] = @FechaAlta, [IdUsuarioModificacion] = @IdUsuarioModificacion, [FechaModificacion] = @FechaModificacion, [Retencion] = @Retencion, [NombreArchivo] = @NombreArchivo, [ArchivoPDF] = @ArchivoPDF WHERE (([IdFacturasEmitidas] = @Original_IdFacturasEmitidas))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdFacturasEmitidas", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdFacturasEmitidas", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FolioFactura", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FolioFactura", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaFactura", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaFactura", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@RfcReceptor", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RfcReceptor", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@NombreReceptor", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NombreReceptor", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdProyecto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@NoCotizacion", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoCotizacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@OrdenCompraRecibida", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OrdenCompraRecibida", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@SubTotal", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 20, (byte) 2, "SubTotal", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Iva", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 20, (byte) 2, "Iva", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Total", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 20, (byte) 2, "Total", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Moneda", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Moneda", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ProgramacionPago", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ProgramacionPago", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@PorPagar", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 20, (byte) 2, "PorPagar", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaPago", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaPago", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Estatus", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@TipoCambio", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 20, (byte) 6, "TipoCambio", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuario", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaAlta", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdUsuarioModificacion", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaModificacion", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Retencion", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 20, (byte) 2, "Retencion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@NombreArchivo", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NombreArchivo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ArchivoPDF", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ArchivoPDF", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_IdFacturasEmitidas", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdFacturasEmitidas", DataRowVersion.Original, false, (object) null, "", "", ""));
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
      this._commandCollection[0].CommandText = "SELECT IdFacturasEmitidas, FolioFactura, FechaFactura, RfcReceptor, NombreReceptor, IdProyecto, NoCotizacion, OrdenCompraRecibida, SubTotal, Iva, Total, Moneda, ProgramacionPago, PorPagar, FechaPago, Estatus, TipoCambio, IdUsuario, FechaAlta, IdUsuarioModificacion, FechaModificacion, Retencion, NombreArchivo, ArchivoPDF FROM dbo.tblFacturasEmitidas";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(
      SisaDevFacturas.tblFacturasEmitidasDataTable dataTable)
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
    public virtual SisaDevFacturas.tblFacturasEmitidasDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      SisaDevFacturas.tblFacturasEmitidasDataTable emitidasDataTable = new SisaDevFacturas.tblFacturasEmitidasDataTable();
      this.Adapter.Fill((DataTable) emitidasDataTable);
      return emitidasDataTable;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(
      SisaDevFacturas.tblFacturasEmitidasDataTable dataTable)
    {
      return this.Adapter.Update((DataTable) dataTable);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas dataSet) => this.Adapter.Update((DataSet) dataSet, "tblFacturasEmitidas");

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
    public virtual int Delete(Guid Original_IdFacturasEmitidas)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) Original_IdFacturasEmitidas;
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
      Guid IdFacturasEmitidas,
      string FolioFactura,
      DateTime FechaFactura,
      string RfcReceptor,
      string NombreReceptor,
      string IdProyecto,
      string NoCotizacion,
      string OrdenCompraRecibida,
      Decimal SubTotal,
      Decimal Iva,
      Decimal Total,
      string Moneda,
      DateTime? ProgramacionPago,
      Decimal? PorPagar,
      DateTime? FechaPago,
      int Estatus,
      Decimal? TipoCambio,
      Guid? IdUsuario,
      DateTime? FechaAlta,
      Guid? IdUsuarioModificacion,
      DateTime? FechaModificacion,
      Decimal? Retencion,
      string NombreArchivo,
      string ArchivoPDF)
    {
      this.Adapter.InsertCommand.Parameters[0].Value = (object) IdFacturasEmitidas;
      this.Adapter.InsertCommand.Parameters[1].Value = FolioFactura != null ? (object) FolioFactura : throw new ArgumentNullException(nameof (FolioFactura));
      this.Adapter.InsertCommand.Parameters[2].Value = (object) FechaFactura;
      this.Adapter.InsertCommand.Parameters[3].Value = RfcReceptor != null ? (object) RfcReceptor : throw new ArgumentNullException(nameof (RfcReceptor));
      this.Adapter.InsertCommand.Parameters[4].Value = NombreReceptor != null ? (object) NombreReceptor : throw new ArgumentNullException(nameof (NombreReceptor));
      if (IdProyecto == null)
        this.Adapter.InsertCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[5].Value = (object) IdProyecto;
      if (NoCotizacion == null)
        this.Adapter.InsertCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[6].Value = (object) NoCotizacion;
      if (OrdenCompraRecibida == null)
        this.Adapter.InsertCommand.Parameters[7].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[7].Value = (object) OrdenCompraRecibida;
      this.Adapter.InsertCommand.Parameters[8].Value = (object) SubTotal;
      this.Adapter.InsertCommand.Parameters[9].Value = (object) Iva;
      this.Adapter.InsertCommand.Parameters[10].Value = (object) Total;
      this.Adapter.InsertCommand.Parameters[11].Value = Moneda != null ? (object) Moneda : throw new ArgumentNullException(nameof (Moneda));
      if (ProgramacionPago.HasValue)
        this.Adapter.InsertCommand.Parameters[12].Value = (object) ProgramacionPago.Value;
      else
        this.Adapter.InsertCommand.Parameters[12].Value = (object) DBNull.Value;
      if (PorPagar.HasValue)
        this.Adapter.InsertCommand.Parameters[13].Value = (object) PorPagar.Value;
      else
        this.Adapter.InsertCommand.Parameters[13].Value = (object) DBNull.Value;
      if (FechaPago.HasValue)
        this.Adapter.InsertCommand.Parameters[14].Value = (object) FechaPago.Value;
      else
        this.Adapter.InsertCommand.Parameters[14].Value = (object) DBNull.Value;
      this.Adapter.InsertCommand.Parameters[15].Value = (object) Estatus;
      if (TipoCambio.HasValue)
        this.Adapter.InsertCommand.Parameters[16].Value = (object) TipoCambio.Value;
      else
        this.Adapter.InsertCommand.Parameters[16].Value = (object) DBNull.Value;
      if (IdUsuario.HasValue)
        this.Adapter.InsertCommand.Parameters[17].Value = (object) IdUsuario.Value;
      else
        this.Adapter.InsertCommand.Parameters[17].Value = (object) DBNull.Value;
      if (FechaAlta.HasValue)
        this.Adapter.InsertCommand.Parameters[18].Value = (object) FechaAlta.Value;
      else
        this.Adapter.InsertCommand.Parameters[18].Value = (object) DBNull.Value;
      if (IdUsuarioModificacion.HasValue)
        this.Adapter.InsertCommand.Parameters[19].Value = (object) IdUsuarioModificacion.Value;
      else
        this.Adapter.InsertCommand.Parameters[19].Value = (object) DBNull.Value;
      if (FechaModificacion.HasValue)
        this.Adapter.InsertCommand.Parameters[20].Value = (object) FechaModificacion.Value;
      else
        this.Adapter.InsertCommand.Parameters[20].Value = (object) DBNull.Value;
      if (Retencion.HasValue)
        this.Adapter.InsertCommand.Parameters[21].Value = (object) Retencion.Value;
      else
        this.Adapter.InsertCommand.Parameters[21].Value = (object) DBNull.Value;
      if (NombreArchivo == null)
        this.Adapter.InsertCommand.Parameters[22].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[22].Value = (object) NombreArchivo;
      if (ArchivoPDF == null)
        this.Adapter.InsertCommand.Parameters[23].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[23].Value = (object) ArchivoPDF;
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
      Guid IdFacturasEmitidas,
      string FolioFactura,
      DateTime FechaFactura,
      string RfcReceptor,
      string NombreReceptor,
      string IdProyecto,
      string NoCotizacion,
      string OrdenCompraRecibida,
      Decimal SubTotal,
      Decimal Iva,
      Decimal Total,
      string Moneda,
      DateTime? ProgramacionPago,
      Decimal? PorPagar,
      DateTime? FechaPago,
      int Estatus,
      Decimal? TipoCambio,
      Guid? IdUsuario,
      DateTime? FechaAlta,
      Guid? IdUsuarioModificacion,
      DateTime? FechaModificacion,
      Decimal? Retencion,
      string NombreArchivo,
      string ArchivoPDF,
      Guid Original_IdFacturasEmitidas)
    {
      this.Adapter.UpdateCommand.Parameters[0].Value = (object) IdFacturasEmitidas;
      this.Adapter.UpdateCommand.Parameters[1].Value = FolioFactura != null ? (object) FolioFactura : throw new ArgumentNullException(nameof (FolioFactura));
      this.Adapter.UpdateCommand.Parameters[2].Value = (object) FechaFactura;
      this.Adapter.UpdateCommand.Parameters[3].Value = RfcReceptor != null ? (object) RfcReceptor : throw new ArgumentNullException(nameof (RfcReceptor));
      this.Adapter.UpdateCommand.Parameters[4].Value = NombreReceptor != null ? (object) NombreReceptor : throw new ArgumentNullException(nameof (NombreReceptor));
      if (IdProyecto == null)
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) IdProyecto;
      if (NoCotizacion == null)
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) NoCotizacion;
      if (OrdenCompraRecibida == null)
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) OrdenCompraRecibida;
      this.Adapter.UpdateCommand.Parameters[8].Value = (object) SubTotal;
      this.Adapter.UpdateCommand.Parameters[9].Value = (object) Iva;
      this.Adapter.UpdateCommand.Parameters[10].Value = (object) Total;
      this.Adapter.UpdateCommand.Parameters[11].Value = Moneda != null ? (object) Moneda : throw new ArgumentNullException(nameof (Moneda));
      if (ProgramacionPago.HasValue)
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) ProgramacionPago.Value;
      else
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) DBNull.Value;
      if (PorPagar.HasValue)
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) PorPagar.Value;
      else
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) DBNull.Value;
      if (FechaPago.HasValue)
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) FechaPago.Value;
      else
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) DBNull.Value;
      this.Adapter.UpdateCommand.Parameters[15].Value = (object) Estatus;
      if (TipoCambio.HasValue)
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) TipoCambio.Value;
      else
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) DBNull.Value;
      if (IdUsuario.HasValue)
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) IdUsuario.Value;
      else
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) DBNull.Value;
      if (FechaAlta.HasValue)
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) FechaAlta.Value;
      else
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) DBNull.Value;
      if (IdUsuarioModificacion.HasValue)
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) IdUsuarioModificacion.Value;
      else
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) DBNull.Value;
      if (FechaModificacion.HasValue)
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) FechaModificacion.Value;
      else
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) DBNull.Value;
      if (Retencion.HasValue)
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) Retencion.Value;
      else
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) DBNull.Value;
      if (NombreArchivo == null)
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) NombreArchivo;
      if (ArchivoPDF == null)
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) ArchivoPDF;
      this.Adapter.UpdateCommand.Parameters[24].Value = (object) Original_IdFacturasEmitidas;
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
      string FolioFactura,
      DateTime FechaFactura,
      string RfcReceptor,
      string NombreReceptor,
      string IdProyecto,
      string NoCotizacion,
      string OrdenCompraRecibida,
      Decimal SubTotal,
      Decimal Iva,
      Decimal Total,
      string Moneda,
      DateTime? ProgramacionPago,
      Decimal? PorPagar,
      DateTime? FechaPago,
      int Estatus,
      Decimal? TipoCambio,
      Guid? IdUsuario,
      DateTime? FechaAlta,
      Guid? IdUsuarioModificacion,
      DateTime? FechaModificacion,
      Decimal? Retencion,
      string NombreArchivo,
      string ArchivoPDF,
      Guid Original_IdFacturasEmitidas)
    {
      return this.Update(Original_IdFacturasEmitidas, FolioFactura, FechaFactura, RfcReceptor, NombreReceptor, IdProyecto, NoCotizacion, OrdenCompraRecibida, SubTotal, Iva, Total, Moneda, ProgramacionPago, PorPagar, FechaPago, Estatus, TipoCambio, IdUsuario, FechaAlta, IdUsuarioModificacion, FechaModificacion, Retencion, NombreArchivo, ArchivoPDF, Original_IdFacturasEmitidas);
    }
  }
}
