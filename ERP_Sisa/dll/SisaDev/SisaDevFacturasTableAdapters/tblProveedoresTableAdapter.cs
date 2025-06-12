// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDevFacturasTableAdapters.tblProveedoresTableAdapter
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
  public class tblProveedoresTableAdapter : Component
  {
    private SqlDataAdapter _adapter;
    private SqlConnection _connection;
    private SqlTransaction _transaction;
    private SqlCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public tblProveedoresTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblProveedores",
        ColumnMappings = {
          {
            "IdProveedor",
            "IdProveedor"
          },
          {
            "Proveedor",
            "Proveedor"
          },
          {
            "Contacto",
            "Contacto"
          },
          {
            "Domicilio",
            "Domicilio"
          },
          {
            "Coordenadas",
            "Coordenadas"
          },
          {
            "Email",
            "Email"
          },
          {
            "Telefono1",
            "Telefono1"
          },
          {
            "Telefono2",
            "Telefono2"
          },
          {
            "Giro",
            "Giro"
          },
          {
            "Comentarios",
            "Comentarios"
          },
          {
            "Imagen",
            "Imagen"
          },
          {
            "FechaAlta",
            "FechaAlta"
          },
          {
            "IdUsuarioAlta",
            "IdUsuarioAlta"
          },
          {
            "FechaModificacion",
            "FechaModificacion"
          },
          {
            "IdUsuarioModifica",
            "IdUsuarioModifica"
          },
          {
            "Activo",
            "Activo"
          },
          {
            "NombreComercial",
            "NombreComercial"
          },
          {
            "DiasCredito",
            "DiasCredito"
          },
          {
            "idSucursal",
            "idSucursal"
          }
        }
      });
      this._adapter.DeleteCommand = new SqlCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[tblProveedores] WHERE (([IdProveedor] = @Original_IdProveedor))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_IdProveedor", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdProveedor", DataRowVersion.Original, false, (object) null, "", "", ""));
      this._adapter.InsertCommand = new SqlCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[tblProveedores] ([IdProveedor], [Proveedor], [Contacto], [Domicilio], [Coordenadas], [Email], [Telefono1], [Telefono2], [Giro], [Comentarios], [Imagen], [FechaAlta], [IdUsuarioAlta], [FechaModificacion], [IdUsuarioModifica], [Activo], [NombreComercial], [DiasCredito], [idSucursal]) VALUES (@IdProveedor, @Proveedor, @Contacto, @Domicilio, @Coordenadas, @Email, @Telefono1, @Telefono2, @Giro, @Comentarios, @Imagen, @FechaAlta, @IdUsuarioAlta, @FechaModificacion, @IdUsuarioModifica, @Activo, @NombreComercial, @DiasCredito, @idSucursal)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdProveedor", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdProveedor", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Proveedor", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Proveedor", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Contacto", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Contacto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Domicilio", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Domicilio", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Coordenadas", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Coordenadas", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Email", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Telefono1", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Telefono1", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Telefono2", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Telefono2", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Giro", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Giro", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Comentarios", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Comentarios", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Imagen", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Imagen", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaAlta", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuarioAlta", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaModificacion", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuarioModifica", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioModifica", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Activo", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Activo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@NombreComercial", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NombreComercial", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@DiasCredito", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DiasCredito", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@idSucursal", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "idSucursal", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand = new SqlCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[tblProveedores] SET [IdProveedor] = @IdProveedor, [Proveedor] = @Proveedor, [Contacto] = @Contacto, [Domicilio] = @Domicilio, [Coordenadas] = @Coordenadas, [Email] = @Email, [Telefono1] = @Telefono1, [Telefono2] = @Telefono2, [Giro] = @Giro, [Comentarios] = @Comentarios, [Imagen] = @Imagen, [FechaAlta] = @FechaAlta, [IdUsuarioAlta] = @IdUsuarioAlta, [FechaModificacion] = @FechaModificacion, [IdUsuarioModifica] = @IdUsuarioModifica, [Activo] = @Activo, [NombreComercial] = @NombreComercial, [DiasCredito] = @DiasCredito, [idSucursal] = @idSucursal WHERE (([IdProveedor] = @Original_IdProveedor))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdProveedor", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdProveedor", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Proveedor", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Proveedor", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Contacto", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Contacto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Domicilio", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Domicilio", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Coordenadas", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Coordenadas", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Email", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Telefono1", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Telefono1", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Telefono2", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Telefono2", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Giro", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Giro", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Comentarios", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Comentarios", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Imagen", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Imagen", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaAlta", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdUsuarioAlta", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaModificacion", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdUsuarioModifica", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioModifica", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Activo", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Activo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@NombreComercial", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NombreComercial", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@DiasCredito", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DiasCredito", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@idSucursal", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "idSucursal", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_IdProveedor", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdProveedor", DataRowVersion.Original, false, (object) null, "", "", ""));
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
      this._commandCollection[0].CommandText = "SELECT IdProveedor, Proveedor, Contacto, Domicilio, Coordenadas, Email, Telefono1, Telefono2, Giro, Comentarios, Imagen, FechaAlta, IdUsuarioAlta, FechaModificacion, IdUsuarioModifica, Activo, NombreComercial, DiasCredito, idSucursal FROM dbo.tblProveedores";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(SisaDevFacturas.tblProveedoresDataTable dataTable)
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
    public virtual SisaDevFacturas.tblProveedoresDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      SisaDevFacturas.tblProveedoresDataTable proveedoresDataTable = new SisaDevFacturas.tblProveedoresDataTable();
      this.Adapter.Fill((DataTable) proveedoresDataTable);
      return proveedoresDataTable;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas.tblProveedoresDataTable dataTable) => this.Adapter.Update((DataTable) dataTable);

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas dataSet) => this.Adapter.Update((DataSet) dataSet, "tblProveedores");

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
    public virtual int Delete(Guid Original_IdProveedor)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) Original_IdProveedor;
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
      Guid IdProveedor,
      string Proveedor,
      string Contacto,
      string Domicilio,
      string Coordenadas,
      string Email,
      string Telefono1,
      string Telefono2,
      string Giro,
      string Comentarios,
      string Imagen,
      DateTime FechaAlta,
      Guid IdUsuarioAlta,
      DateTime FechaModificacion,
      Guid IdUsuarioModifica,
      int Activo,
      string NombreComercial,
      int? DiasCredito,
      Guid? idSucursal)
    {
      this.Adapter.InsertCommand.Parameters[0].Value = (object) IdProveedor;
      this.Adapter.InsertCommand.Parameters[1].Value = Proveedor != null ? (object) Proveedor : throw new ArgumentNullException(nameof (Proveedor));
      this.Adapter.InsertCommand.Parameters[2].Value = Contacto != null ? (object) Contacto : throw new ArgumentNullException(nameof (Contacto));
      if (Domicilio == null)
        this.Adapter.InsertCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[3].Value = (object) Domicilio;
      if (Coordenadas == null)
        this.Adapter.InsertCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[4].Value = (object) Coordenadas;
      this.Adapter.InsertCommand.Parameters[5].Value = Email != null ? (object) Email : throw new ArgumentNullException(nameof (Email));
      if (Telefono1 == null)
        this.Adapter.InsertCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[6].Value = (object) Telefono1;
      if (Telefono2 == null)
        this.Adapter.InsertCommand.Parameters[7].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[7].Value = (object) Telefono2;
      if (Giro == null)
        this.Adapter.InsertCommand.Parameters[8].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[8].Value = (object) Giro;
      if (Comentarios == null)
        this.Adapter.InsertCommand.Parameters[9].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[9].Value = (object) Comentarios;
      if (Imagen == null)
        this.Adapter.InsertCommand.Parameters[10].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[10].Value = (object) Imagen;
      this.Adapter.InsertCommand.Parameters[11].Value = (object) FechaAlta;
      this.Adapter.InsertCommand.Parameters[12].Value = (object) IdUsuarioAlta;
      this.Adapter.InsertCommand.Parameters[13].Value = (object) FechaModificacion;
      this.Adapter.InsertCommand.Parameters[14].Value = (object) IdUsuarioModifica;
      this.Adapter.InsertCommand.Parameters[15].Value = (object) Activo;
      if (NombreComercial == null)
        this.Adapter.InsertCommand.Parameters[16].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[16].Value = (object) NombreComercial;
      if (DiasCredito.HasValue)
        this.Adapter.InsertCommand.Parameters[17].Value = (object) DiasCredito.Value;
      else
        this.Adapter.InsertCommand.Parameters[17].Value = (object) DBNull.Value;
      if (idSucursal.HasValue)
        this.Adapter.InsertCommand.Parameters[18].Value = (object) idSucursal.Value;
      else
        this.Adapter.InsertCommand.Parameters[18].Value = (object) DBNull.Value;
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
      Guid IdProveedor,
      string Proveedor,
      string Contacto,
      string Domicilio,
      string Coordenadas,
      string Email,
      string Telefono1,
      string Telefono2,
      string Giro,
      string Comentarios,
      string Imagen,
      DateTime FechaAlta,
      Guid IdUsuarioAlta,
      DateTime FechaModificacion,
      Guid IdUsuarioModifica,
      int Activo,
      string NombreComercial,
      int? DiasCredito,
      Guid? idSucursal,
      Guid Original_IdProveedor)
    {
      this.Adapter.UpdateCommand.Parameters[0].Value = (object) IdProveedor;
      this.Adapter.UpdateCommand.Parameters[1].Value = Proveedor != null ? (object) Proveedor : throw new ArgumentNullException(nameof (Proveedor));
      this.Adapter.UpdateCommand.Parameters[2].Value = Contacto != null ? (object) Contacto : throw new ArgumentNullException(nameof (Contacto));
      if (Domicilio == null)
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) Domicilio;
      if (Coordenadas == null)
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) Coordenadas;
      this.Adapter.UpdateCommand.Parameters[5].Value = Email != null ? (object) Email : throw new ArgumentNullException(nameof (Email));
      if (Telefono1 == null)
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) Telefono1;
      if (Telefono2 == null)
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) Telefono2;
      if (Giro == null)
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) Giro;
      if (Comentarios == null)
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) Comentarios;
      if (Imagen == null)
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) Imagen;
      this.Adapter.UpdateCommand.Parameters[11].Value = (object) FechaAlta;
      this.Adapter.UpdateCommand.Parameters[12].Value = (object) IdUsuarioAlta;
      this.Adapter.UpdateCommand.Parameters[13].Value = (object) FechaModificacion;
      this.Adapter.UpdateCommand.Parameters[14].Value = (object) IdUsuarioModifica;
      this.Adapter.UpdateCommand.Parameters[15].Value = (object) Activo;
      if (NombreComercial == null)
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) NombreComercial;
      if (DiasCredito.HasValue)
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) DiasCredito.Value;
      else
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) DBNull.Value;
      if (idSucursal.HasValue)
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) idSucursal.Value;
      else
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) DBNull.Value;
      this.Adapter.UpdateCommand.Parameters[19].Value = (object) Original_IdProveedor;
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
      string Proveedor,
      string Contacto,
      string Domicilio,
      string Coordenadas,
      string Email,
      string Telefono1,
      string Telefono2,
      string Giro,
      string Comentarios,
      string Imagen,
      DateTime FechaAlta,
      Guid IdUsuarioAlta,
      DateTime FechaModificacion,
      Guid IdUsuarioModifica,
      int Activo,
      string NombreComercial,
      int? DiasCredito,
      Guid? idSucursal,
      Guid Original_IdProveedor)
    {
      return this.Update(Original_IdProveedor, Proveedor, Contacto, Domicilio, Coordenadas, Email, Telefono1, Telefono2, Giro, Comentarios, Imagen, FechaAlta, IdUsuarioAlta, FechaModificacion, IdUsuarioModifica, Activo, NombreComercial, DiasCredito, idSucursal, Original_IdProveedor);
    }
  }
}
