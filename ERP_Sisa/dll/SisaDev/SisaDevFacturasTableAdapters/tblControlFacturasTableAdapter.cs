// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDevFacturasTableAdapters.tblControlFacturasTableAdapter
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
  public class tblControlFacturasTableAdapter : Component
  {
    private SqlDataAdapter _adapter;
    private SqlConnection _connection;
    private SqlTransaction _transaction;
    private SqlCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public tblControlFacturasTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblControlFacturas",
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
            "IdProyecto",
            "IdProyecto"
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
            "Viaticos",
            "Viaticos"
          },
          {
            "NombreArchivo",
            "NombreArchivo"
          },
          {
            "ArchivoFactura",
            "ArchivoFactura"
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
            "IdUsuarioModificacion",
            "IdUsuarioModificacion"
          },
          {
            "FechaModificacion",
            "FechaModificacion"
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
          }
        }
      });
      this._adapter.DeleteCommand = new SqlCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[tblControlFacturas] WHERE (([IdControlFacturas] = @Original_IdControlFacturas))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_IdControlFacturas", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdControlFacturas", DataRowVersion.Original, false, (object) null, "", "", ""));
      this._adapter.InsertCommand = new SqlCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[tblControlFacturas] ([IdControlFacturas], [FechaFactura], [IdProveedor], [NoFactura], [OrdenCompra], [IdProyecto], [Proyecto], [Moneda], [SubTotal], [Descuento], [IVA], [Total], [Estatus], [FormaPago], [Viaticos], [NombreArchivo], [ArchivoFactura], [IdUsuarioAlta], [FechaAlta], [IdUsuarioModificacion], [FechaModificacion], [Categoria], [Anticipo], [NotaCredito]) VALUES (@IdControlFacturas, @FechaFactura, @IdProveedor, @NoFactura, @OrdenCompra, @IdProyecto, @Proyecto, @Moneda, @SubTotal, @Descuento, @IVA, @Total, @Estatus, @FormaPago, @Viaticos, @NombreArchivo, @ArchivoFactura, @IdUsuarioAlta, @FechaAlta, @IdUsuarioModificacion, @FechaModificacion, @Categoria, @Anticipo, @NotaCredito)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdControlFacturas", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdControlFacturas", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaFactura", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaFactura", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdProveedor", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdProveedor", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@NoFactura", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoFactura", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@OrdenCompra", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OrdenCompra", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdProyecto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Proyecto", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Proyecto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Moneda", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Moneda", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@SubTotal", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "SubTotal", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Descuento", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Descuento", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IVA", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "IVA", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Total", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Total", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Estatus", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FormaPago", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FormaPago", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Viaticos", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Viaticos", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@NombreArchivo", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NombreArchivo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ArchivoFactura", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ArchivoFactura", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuarioAlta", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaAlta", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuarioModificacion", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaModificacion", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Categoria", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Categoria", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Anticipo", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Anticipo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@NotaCredito", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "NotaCredito", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand = new SqlCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[tblControlFacturas] SET [IdControlFacturas] = @IdControlFacturas, [FechaFactura] = @FechaFactura, [IdProveedor] = @IdProveedor, [NoFactura] = @NoFactura, [OrdenCompra] = @OrdenCompra, [IdProyecto] = @IdProyecto, [Proyecto] = @Proyecto, [Moneda] = @Moneda, [SubTotal] = @SubTotal, [Descuento] = @Descuento, [IVA] = @IVA, [Total] = @Total, [Estatus] = @Estatus, [FormaPago] = @FormaPago, [Viaticos] = @Viaticos, [NombreArchivo] = @NombreArchivo, [ArchivoFactura] = @ArchivoFactura, [IdUsuarioAlta] = @IdUsuarioAlta, [FechaAlta] = @FechaAlta, [IdUsuarioModificacion] = @IdUsuarioModificacion, [FechaModificacion] = @FechaModificacion, [Categoria] = @Categoria, [Anticipo] = @Anticipo, [NotaCredito] = @NotaCredito WHERE (([IdControlFacturas] = @Original_IdControlFacturas))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdControlFacturas", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdControlFacturas", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaFactura", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaFactura", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdProveedor", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdProveedor", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@NoFactura", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoFactura", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@OrdenCompra", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "OrdenCompra", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdProyecto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Proyecto", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Proyecto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Moneda", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Moneda", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@SubTotal", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "SubTotal", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Descuento", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Descuento", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IVA", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "IVA", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Total", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Total", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Estatus", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FormaPago", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FormaPago", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Viaticos", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Viaticos", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@NombreArchivo", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NombreArchivo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ArchivoFactura", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ArchivoFactura", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdUsuarioAlta", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaAlta", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdUsuarioModificacion", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaModificacion", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Categoria", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Categoria", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Anticipo", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "Anticipo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@NotaCredito", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "NotaCredito", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_IdControlFacturas", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdControlFacturas", DataRowVersion.Original, false, (object) null, "", "", ""));
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
      this._commandCollection[0].CommandText = "SELECT IdControlFacturas, FechaFactura, IdProveedor, NoFactura, OrdenCompra, IdProyecto, Proyecto, Moneda, SubTotal, Descuento, IVA, Total, Estatus, FormaPago, Viaticos, NombreArchivo, ArchivoFactura, IdUsuarioAlta, FechaAlta, IdUsuarioModificacion, FechaModificacion, Categoria, Anticipo, NotaCredito FROM dbo.tblControlFacturas";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(
      SisaDevFacturas.tblControlFacturasDataTable dataTable)
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
    public virtual SisaDevFacturas.tblControlFacturasDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      SisaDevFacturas.tblControlFacturasDataTable facturasDataTable = new SisaDevFacturas.tblControlFacturasDataTable();
      this.Adapter.Fill((DataTable) facturasDataTable);
      return facturasDataTable;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(
      SisaDevFacturas.tblControlFacturasDataTable dataTable)
    {
      return this.Adapter.Update((DataTable) dataTable);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas dataSet) => this.Adapter.Update((DataSet) dataSet, "tblControlFacturas");

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
    public virtual int Delete(Guid Original_IdControlFacturas)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) Original_IdControlFacturas;
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
      Guid IdControlFacturas,
      DateTime FechaFactura,
      Guid IdProveedor,
      string NoFactura,
      string OrdenCompra,
      string IdProyecto,
      string Proyecto,
      string Moneda,
      Decimal SubTotal,
      Decimal Descuento,
      Decimal IVA,
      Decimal Total,
      int Estatus,
      string FormaPago,
      int? Viaticos,
      string NombreArchivo,
      string ArchivoFactura,
      Guid? IdUsuarioAlta,
      DateTime? FechaAlta,
      Guid? IdUsuarioModificacion,
      DateTime? FechaModificacion,
      string Categoria,
      Decimal? Anticipo,
      Decimal? NotaCredito)
    {
      this.Adapter.InsertCommand.Parameters[0].Value = (object) IdControlFacturas;
      this.Adapter.InsertCommand.Parameters[1].Value = (object) FechaFactura;
      this.Adapter.InsertCommand.Parameters[2].Value = (object) IdProveedor;
      this.Adapter.InsertCommand.Parameters[3].Value = NoFactura != null ? (object) NoFactura : throw new ArgumentNullException(nameof (NoFactura));
      this.Adapter.InsertCommand.Parameters[4].Value = OrdenCompra != null ? (object) OrdenCompra : throw new ArgumentNullException(nameof (OrdenCompra));
      if (IdProyecto == null)
        this.Adapter.InsertCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[5].Value = (object) IdProyecto;
      this.Adapter.InsertCommand.Parameters[6].Value = Proyecto != null ? (object) Proyecto : throw new ArgumentNullException(nameof (Proyecto));
      this.Adapter.InsertCommand.Parameters[7].Value = Moneda != null ? (object) Moneda : throw new ArgumentNullException(nameof (Moneda));
      this.Adapter.InsertCommand.Parameters[8].Value = (object) SubTotal;
      this.Adapter.InsertCommand.Parameters[9].Value = (object) Descuento;
      this.Adapter.InsertCommand.Parameters[10].Value = (object) IVA;
      this.Adapter.InsertCommand.Parameters[11].Value = (object) Total;
      this.Adapter.InsertCommand.Parameters[12].Value = (object) Estatus;
      this.Adapter.InsertCommand.Parameters[13].Value = FormaPago != null ? (object) FormaPago : throw new ArgumentNullException(nameof (FormaPago));
      if (Viaticos.HasValue)
        this.Adapter.InsertCommand.Parameters[14].Value = (object) Viaticos.Value;
      else
        this.Adapter.InsertCommand.Parameters[14].Value = (object) DBNull.Value;
      if (NombreArchivo == null)
        this.Adapter.InsertCommand.Parameters[15].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[15].Value = (object) NombreArchivo;
      if (ArchivoFactura == null)
        this.Adapter.InsertCommand.Parameters[16].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[16].Value = (object) ArchivoFactura;
      if (IdUsuarioAlta.HasValue)
        this.Adapter.InsertCommand.Parameters[17].Value = (object) IdUsuarioAlta.Value;
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
      if (Categoria == null)
        this.Adapter.InsertCommand.Parameters[21].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[21].Value = (object) Categoria;
      if (Anticipo.HasValue)
        this.Adapter.InsertCommand.Parameters[22].Value = (object) Anticipo.Value;
      else
        this.Adapter.InsertCommand.Parameters[22].Value = (object) DBNull.Value;
      if (NotaCredito.HasValue)
        this.Adapter.InsertCommand.Parameters[23].Value = (object) NotaCredito.Value;
      else
        this.Adapter.InsertCommand.Parameters[23].Value = (object) DBNull.Value;
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
      Guid IdControlFacturas,
      DateTime FechaFactura,
      Guid IdProveedor,
      string NoFactura,
      string OrdenCompra,
      string IdProyecto,
      string Proyecto,
      string Moneda,
      Decimal SubTotal,
      Decimal Descuento,
      Decimal IVA,
      Decimal Total,
      int Estatus,
      string FormaPago,
      int? Viaticos,
      string NombreArchivo,
      string ArchivoFactura,
      Guid? IdUsuarioAlta,
      DateTime? FechaAlta,
      Guid? IdUsuarioModificacion,
      DateTime? FechaModificacion,
      string Categoria,
      Decimal? Anticipo,
      Decimal? NotaCredito,
      Guid Original_IdControlFacturas)
    {
      this.Adapter.UpdateCommand.Parameters[0].Value = (object) IdControlFacturas;
      this.Adapter.UpdateCommand.Parameters[1].Value = (object) FechaFactura;
      this.Adapter.UpdateCommand.Parameters[2].Value = (object) IdProveedor;
      this.Adapter.UpdateCommand.Parameters[3].Value = NoFactura != null ? (object) NoFactura : throw new ArgumentNullException(nameof (NoFactura));
      this.Adapter.UpdateCommand.Parameters[4].Value = OrdenCompra != null ? (object) OrdenCompra : throw new ArgumentNullException(nameof (OrdenCompra));
      if (IdProyecto == null)
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) IdProyecto;
      this.Adapter.UpdateCommand.Parameters[6].Value = Proyecto != null ? (object) Proyecto : throw new ArgumentNullException(nameof (Proyecto));
      this.Adapter.UpdateCommand.Parameters[7].Value = Moneda != null ? (object) Moneda : throw new ArgumentNullException(nameof (Moneda));
      this.Adapter.UpdateCommand.Parameters[8].Value = (object) SubTotal;
      this.Adapter.UpdateCommand.Parameters[9].Value = (object) Descuento;
      this.Adapter.UpdateCommand.Parameters[10].Value = (object) IVA;
      this.Adapter.UpdateCommand.Parameters[11].Value = (object) Total;
      this.Adapter.UpdateCommand.Parameters[12].Value = (object) Estatus;
      this.Adapter.UpdateCommand.Parameters[13].Value = FormaPago != null ? (object) FormaPago : throw new ArgumentNullException(nameof (FormaPago));
      if (Viaticos.HasValue)
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) Viaticos.Value;
      else
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) DBNull.Value;
      if (NombreArchivo == null)
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) NombreArchivo;
      if (ArchivoFactura == null)
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) ArchivoFactura;
      if (IdUsuarioAlta.HasValue)
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) IdUsuarioAlta.Value;
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
      if (Categoria == null)
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) Categoria;
      if (Anticipo.HasValue)
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) Anticipo.Value;
      else
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) DBNull.Value;
      if (NotaCredito.HasValue)
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) NotaCredito.Value;
      else
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) DBNull.Value;
      this.Adapter.UpdateCommand.Parameters[24].Value = (object) Original_IdControlFacturas;
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
      DateTime FechaFactura,
      Guid IdProveedor,
      string NoFactura,
      string OrdenCompra,
      string IdProyecto,
      string Proyecto,
      string Moneda,
      Decimal SubTotal,
      Decimal Descuento,
      Decimal IVA,
      Decimal Total,
      int Estatus,
      string FormaPago,
      int? Viaticos,
      string NombreArchivo,
      string ArchivoFactura,
      Guid? IdUsuarioAlta,
      DateTime? FechaAlta,
      Guid? IdUsuarioModificacion,
      DateTime? FechaModificacion,
      string Categoria,
      Decimal? Anticipo,
      Decimal? NotaCredito,
      Guid Original_IdControlFacturas)
    {
      return this.Update(Original_IdControlFacturas, FechaFactura, IdProveedor, NoFactura, OrdenCompra, IdProyecto, Proyecto, Moneda, SubTotal, Descuento, IVA, Total, Estatus, FormaPago, Viaticos, NombreArchivo, ArchivoFactura, IdUsuarioAlta, FechaAlta, IdUsuarioModificacion, FechaModificacion, Categoria, Anticipo, NotaCredito, Original_IdControlFacturas);
    }
  }
}
