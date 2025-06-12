// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDevFacturasTableAdapters.tblClientesTableAdapter
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
  public class tblClientesTableAdapter : Component
  {
    private SqlDataAdapter _adapter;
    private SqlConnection _connection;
    private SqlTransaction _transaction;
    private SqlCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public tblClientesTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblClientes",
        ColumnMappings = {
          {
            "IdCliente",
            "IdCliente"
          },
          {
            "RazonSocial",
            "RazonSocial"
          },
          {
            "Contacto",
            "Contacto"
          },
          {
            "Email",
            "Email"
          },
          {
            "Departamento",
            "Departamento"
          },
          {
            "TelefonoEmpresa",
            "TelefonoEmpresa"
          },
          {
            "Celular",
            "Celular"
          },
          {
            "UsuarioCliente",
            "UsuarioCliente"
          },
          {
            "ContrasenaCliente",
            "ContrasenaCliente"
          },
          {
            "MapaCoordenadas",
            "MapaCoordenadas"
          },
          {
            "Logotipo",
            "Logotipo"
          },
          {
            "Direccion",
            "Direccion"
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
            "Activo",
            "Activo"
          },
          {
            "idEmpresa",
            "idEmpresa"
          }
        }
      });
      this._adapter.DeleteCommand = new SqlCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[tblClientes] WHERE (([IdCliente] = @Original_IdCliente))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_IdCliente", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdCliente", DataRowVersion.Original, false, (object) null, "", "", ""));
      this._adapter.InsertCommand = new SqlCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[tblClientes] ([IdCliente], [RazonSocial], [Contacto], [Email], [Departamento], [TelefonoEmpresa], [Celular], [UsuarioCliente], [ContrasenaCliente], [MapaCoordenadas], [Logotipo], [Direccion], [IdUsuarioAlta], [FechaAlta], [IdUsuarioModificacion], [FechaModificacion], [Activo], [idEmpresa]) VALUES (@IdCliente, @RazonSocial, @Contacto, @Email, @Departamento, @TelefonoEmpresa, @Celular, @UsuarioCliente, @ContrasenaCliente, @MapaCoordenadas, @Logotipo, @Direccion, @IdUsuarioAlta, @FechaAlta, @IdUsuarioModificacion, @FechaModificacion, @Activo, @idEmpresa)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdCliente", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdCliente", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@RazonSocial", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RazonSocial", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Contacto", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Contacto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Email", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Departamento", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Departamento", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@TelefonoEmpresa", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TelefonoEmpresa", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Celular", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Celular", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@UsuarioCliente", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "UsuarioCliente", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ContrasenaCliente", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ContrasenaCliente", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@MapaCoordenadas", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MapaCoordenadas", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Logotipo", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Logotipo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Direccion", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Direccion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuarioAlta", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaAlta", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuarioModificacion", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaModificacion", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Activo", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Activo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@idEmpresa", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "idEmpresa", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand = new SqlCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[tblClientes] SET [IdCliente] = @IdCliente, [RazonSocial] = @RazonSocial, [Contacto] = @Contacto, [Email] = @Email, [Departamento] = @Departamento, [TelefonoEmpresa] = @TelefonoEmpresa, [Celular] = @Celular, [UsuarioCliente] = @UsuarioCliente, [ContrasenaCliente] = @ContrasenaCliente, [MapaCoordenadas] = @MapaCoordenadas, [Logotipo] = @Logotipo, [Direccion] = @Direccion, [IdUsuarioAlta] = @IdUsuarioAlta, [FechaAlta] = @FechaAlta, [IdUsuarioModificacion] = @IdUsuarioModificacion, [FechaModificacion] = @FechaModificacion, [Activo] = @Activo, [idEmpresa] = @idEmpresa WHERE (([IdCliente] = @Original_IdCliente))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdCliente", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdCliente", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@RazonSocial", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "RazonSocial", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Contacto", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Contacto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Email", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Departamento", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Departamento", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@TelefonoEmpresa", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TelefonoEmpresa", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Celular", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Celular", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@UsuarioCliente", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "UsuarioCliente", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ContrasenaCliente", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ContrasenaCliente", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@MapaCoordenadas", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "MapaCoordenadas", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Logotipo", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Logotipo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Direccion", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Direccion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdUsuarioAlta", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaAlta", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdUsuarioModificacion", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaModificacion", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Activo", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Activo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@idEmpresa", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "idEmpresa", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_IdCliente", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdCliente", DataRowVersion.Original, false, (object) null, "", "", ""));
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
      this._commandCollection[0].CommandText = "SELECT IdCliente, RazonSocial, Contacto, Email, Departamento, TelefonoEmpresa, Celular, UsuarioCliente, ContrasenaCliente, MapaCoordenadas, Logotipo, Direccion, IdUsuarioAlta, FechaAlta, IdUsuarioModificacion, FechaModificacion, Activo, idEmpresa FROM dbo.tblClientes";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(SisaDevFacturas.tblClientesDataTable dataTable)
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
    public virtual SisaDevFacturas.tblClientesDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      SisaDevFacturas.tblClientesDataTable clientesDataTable = new SisaDevFacturas.tblClientesDataTable();
      this.Adapter.Fill((DataTable) clientesDataTable);
      return clientesDataTable;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas.tblClientesDataTable dataTable) => this.Adapter.Update((DataTable) dataTable);

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas dataSet) => this.Adapter.Update((DataSet) dataSet, "tblClientes");

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
    public virtual int Delete(Guid Original_IdCliente)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) Original_IdCliente;
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
      Guid IdCliente,
      string RazonSocial,
      string Contacto,
      string Email,
      string Departamento,
      string TelefonoEmpresa,
      string Celular,
      string UsuarioCliente,
      string ContrasenaCliente,
      string MapaCoordenadas,
      string Logotipo,
      string Direccion,
      Guid IdUsuarioAlta,
      DateTime FechaAlta,
      Guid IdUsuarioModificacion,
      DateTime FechaModificacion,
      int Activo,
      Guid idEmpresa)
    {
      this.Adapter.InsertCommand.Parameters[0].Value = (object) IdCliente;
      this.Adapter.InsertCommand.Parameters[1].Value = RazonSocial != null ? (object) RazonSocial : throw new ArgumentNullException(nameof (RazonSocial));
      this.Adapter.InsertCommand.Parameters[2].Value = Contacto != null ? (object) Contacto : throw new ArgumentNullException(nameof (Contacto));
      this.Adapter.InsertCommand.Parameters[3].Value = Email != null ? (object) Email : throw new ArgumentNullException(nameof (Email));
      if (Departamento == null)
        this.Adapter.InsertCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[4].Value = (object) Departamento;
      this.Adapter.InsertCommand.Parameters[5].Value = TelefonoEmpresa != null ? (object) TelefonoEmpresa : throw new ArgumentNullException(nameof (TelefonoEmpresa));
      this.Adapter.InsertCommand.Parameters[6].Value = Celular != null ? (object) Celular : throw new ArgumentNullException(nameof (Celular));
      this.Adapter.InsertCommand.Parameters[7].Value = UsuarioCliente != null ? (object) UsuarioCliente : throw new ArgumentNullException(nameof (UsuarioCliente));
      this.Adapter.InsertCommand.Parameters[8].Value = ContrasenaCliente != null ? (object) ContrasenaCliente : throw new ArgumentNullException(nameof (ContrasenaCliente));
      if (MapaCoordenadas == null)
        this.Adapter.InsertCommand.Parameters[9].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[9].Value = (object) MapaCoordenadas;
      if (Logotipo == null)
        this.Adapter.InsertCommand.Parameters[10].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[10].Value = (object) Logotipo;
      this.Adapter.InsertCommand.Parameters[11].Value = Direccion != null ? (object) Direccion : throw new ArgumentNullException(nameof (Direccion));
      this.Adapter.InsertCommand.Parameters[12].Value = (object) IdUsuarioAlta;
      this.Adapter.InsertCommand.Parameters[13].Value = (object) FechaAlta;
      this.Adapter.InsertCommand.Parameters[14].Value = (object) IdUsuarioModificacion;
      this.Adapter.InsertCommand.Parameters[15].Value = (object) FechaModificacion;
      this.Adapter.InsertCommand.Parameters[16].Value = (object) Activo;
      this.Adapter.InsertCommand.Parameters[17].Value = (object) idEmpresa;
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
      Guid IdCliente,
      string RazonSocial,
      string Contacto,
      string Email,
      string Departamento,
      string TelefonoEmpresa,
      string Celular,
      string UsuarioCliente,
      string ContrasenaCliente,
      string MapaCoordenadas,
      string Logotipo,
      string Direccion,
      Guid IdUsuarioAlta,
      DateTime FechaAlta,
      Guid IdUsuarioModificacion,
      DateTime FechaModificacion,
      int Activo,
      Guid idEmpresa,
      Guid Original_IdCliente)
    {
      this.Adapter.UpdateCommand.Parameters[0].Value = (object) IdCliente;
      this.Adapter.UpdateCommand.Parameters[1].Value = RazonSocial != null ? (object) RazonSocial : throw new ArgumentNullException(nameof (RazonSocial));
      this.Adapter.UpdateCommand.Parameters[2].Value = Contacto != null ? (object) Contacto : throw new ArgumentNullException(nameof (Contacto));
      this.Adapter.UpdateCommand.Parameters[3].Value = Email != null ? (object) Email : throw new ArgumentNullException(nameof (Email));
      if (Departamento == null)
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) Departamento;
      this.Adapter.UpdateCommand.Parameters[5].Value = TelefonoEmpresa != null ? (object) TelefonoEmpresa : throw new ArgumentNullException(nameof (TelefonoEmpresa));
      this.Adapter.UpdateCommand.Parameters[6].Value = Celular != null ? (object) Celular : throw new ArgumentNullException(nameof (Celular));
      this.Adapter.UpdateCommand.Parameters[7].Value = UsuarioCliente != null ? (object) UsuarioCliente : throw new ArgumentNullException(nameof (UsuarioCliente));
      this.Adapter.UpdateCommand.Parameters[8].Value = ContrasenaCliente != null ? (object) ContrasenaCliente : throw new ArgumentNullException(nameof (ContrasenaCliente));
      if (MapaCoordenadas == null)
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) MapaCoordenadas;
      if (Logotipo == null)
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) Logotipo;
      this.Adapter.UpdateCommand.Parameters[11].Value = Direccion != null ? (object) Direccion : throw new ArgumentNullException(nameof (Direccion));
      this.Adapter.UpdateCommand.Parameters[12].Value = (object) IdUsuarioAlta;
      this.Adapter.UpdateCommand.Parameters[13].Value = (object) FechaAlta;
      this.Adapter.UpdateCommand.Parameters[14].Value = (object) IdUsuarioModificacion;
      this.Adapter.UpdateCommand.Parameters[15].Value = (object) FechaModificacion;
      this.Adapter.UpdateCommand.Parameters[16].Value = (object) Activo;
      this.Adapter.UpdateCommand.Parameters[17].Value = (object) idEmpresa;
      this.Adapter.UpdateCommand.Parameters[18].Value = (object) Original_IdCliente;
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
      string RazonSocial,
      string Contacto,
      string Email,
      string Departamento,
      string TelefonoEmpresa,
      string Celular,
      string UsuarioCliente,
      string ContrasenaCliente,
      string MapaCoordenadas,
      string Logotipo,
      string Direccion,
      Guid IdUsuarioAlta,
      DateTime FechaAlta,
      Guid IdUsuarioModificacion,
      DateTime FechaModificacion,
      int Activo,
      Guid idEmpresa,
      Guid Original_IdCliente)
    {
      return this.Update(Original_IdCliente, RazonSocial, Contacto, Email, Departamento, TelefonoEmpresa, Celular, UsuarioCliente, ContrasenaCliente, MapaCoordenadas, Logotipo, Direccion, IdUsuarioAlta, FechaAlta, IdUsuarioModificacion, FechaModificacion, Activo, idEmpresa, Original_IdCliente);
    }
  }
}
