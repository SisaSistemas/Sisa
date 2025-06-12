// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDevFacturasTableAdapters.tblUsuariosTableAdapter
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
  public class tblUsuariosTableAdapter : Component
  {
    private SqlDataAdapter _adapter;
    private SqlConnection _connection;
    private SqlTransaction _transaction;
    private SqlCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public tblUsuariosTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblUsuarios",
        ColumnMappings = {
          {
            "IdUsuario",
            "IdUsuario"
          },
          {
            "NombreCompleto",
            "NombreCompleto"
          },
          {
            "Usuario",
            "Usuario"
          },
          {
            "Contrasena",
            "Contrasena"
          },
          {
            "Foto",
            "Foto"
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
            "Telefono",
            "Telefono"
          },
          {
            "Correo",
            "Correo"
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
      this._adapter.DeleteCommand = new SqlCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[tblUsuarios] WHERE (([IdUsuario] = @Original_IdUsuario))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_IdUsuario", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuario", DataRowVersion.Original, false, (object) null, "", "", ""));
      this._adapter.InsertCommand = new SqlCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[tblUsuarios] ([IdUsuario], [NombreCompleto], [Usuario], [Contrasena], [Foto], [Permisos], [Puesto], [Telefono], [Correo], [FechaAlta], [IdUsuarioModificacion], [FechaModificacion], [Activo], [EsLiderProyecto], [Perfil], [SueldoDiario], [idSucursal]) VALUES (@IdUsuario, @NombreCompleto, @Usuario, @Contrasena, @Foto, @Permisos, @Puesto, @Telefono, @Correo, @FechaAlta, @IdUsuarioModificacion, @FechaModificacion, @Activo, @EsLiderProyecto, @Perfil, @SueldoDiario, @idSucursal)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuario", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@NombreCompleto", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NombreCompleto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Usuario", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Contrasena", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Contrasena", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Foto", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Foto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Permisos", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Permisos", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Puesto", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Puesto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Telefono", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Telefono", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Correo", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Correo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaAlta", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuarioModificacion", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaModificacion", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Activo", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Activo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@EsLiderProyecto", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EsLiderProyecto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Perfil", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Perfil", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@SueldoDiario", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "SueldoDiario", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@idSucursal", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "idSucursal", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand = new SqlCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[tblUsuarios] SET [IdUsuario] = @IdUsuario, [NombreCompleto] = @NombreCompleto, [Usuario] = @Usuario, [Contrasena] = @Contrasena, [Foto] = @Foto, [Permisos] = @Permisos, [Puesto] = @Puesto, [Telefono] = @Telefono, [Correo] = @Correo, [FechaAlta] = @FechaAlta, [IdUsuarioModificacion] = @IdUsuarioModificacion, [FechaModificacion] = @FechaModificacion, [Activo] = @Activo, [EsLiderProyecto] = @EsLiderProyecto, [Perfil] = @Perfil, [SueldoDiario] = @SueldoDiario, [idSucursal] = @idSucursal WHERE (([IdUsuario] = @Original_IdUsuario))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuario", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@NombreCompleto", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NombreCompleto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Usuario", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Contrasena", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Contrasena", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Foto", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Foto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Permisos", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Permisos", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Puesto", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Puesto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Telefono", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Telefono", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Correo", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Correo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaAlta", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdUsuarioModificacion", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaModificacion", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Activo", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Activo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@EsLiderProyecto", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EsLiderProyecto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Perfil", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Perfil", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@SueldoDiario", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "SueldoDiario", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@idSucursal", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "idSucursal", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_IdUsuario", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuario", DataRowVersion.Original, false, (object) null, "", "", ""));
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
      this._commandCollection[0].CommandText = "SELECT IdUsuario, NombreCompleto, Usuario, Contrasena, Foto, Permisos, Puesto, Telefono, Correo, FechaAlta, IdUsuarioModificacion, FechaModificacion, Activo, EsLiderProyecto, Perfil, SueldoDiario, idSucursal FROM dbo.tblUsuarios";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(SisaDevFacturas.tblUsuariosDataTable dataTable)
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
    public virtual SisaDevFacturas.tblUsuariosDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      SisaDevFacturas.tblUsuariosDataTable usuariosDataTable = new SisaDevFacturas.tblUsuariosDataTable();
      this.Adapter.Fill((DataTable) usuariosDataTable);
      return usuariosDataTable;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas.tblUsuariosDataTable dataTable) => this.Adapter.Update((DataTable) dataTable);

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas dataSet) => this.Adapter.Update((DataSet) dataSet, "tblUsuarios");

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
    public virtual int Delete(Guid Original_IdUsuario)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) Original_IdUsuario;
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
      Guid IdUsuario,
      string NombreCompleto,
      string Usuario,
      string Contrasena,
      string Foto,
      int? Permisos,
      string Puesto,
      string Telefono,
      string Correo,
      DateTime? FechaAlta,
      Guid? IdUsuarioModificacion,
      DateTime? FechaModificacion,
      int? Activo,
      int? EsLiderProyecto,
      string Perfil,
      Decimal? SueldoDiario,
      Guid? idSucursal)
    {
      this.Adapter.InsertCommand.Parameters[0].Value = (object) IdUsuario;
      if (NombreCompleto == null)
        this.Adapter.InsertCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[1].Value = (object) NombreCompleto;
      if (Usuario == null)
        this.Adapter.InsertCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[2].Value = (object) Usuario;
      if (Contrasena == null)
        this.Adapter.InsertCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[3].Value = (object) Contrasena;
      if (Foto == null)
        this.Adapter.InsertCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[4].Value = (object) Foto;
      if (Permisos.HasValue)
        this.Adapter.InsertCommand.Parameters[5].Value = (object) Permisos.Value;
      else
        this.Adapter.InsertCommand.Parameters[5].Value = (object) DBNull.Value;
      if (Puesto == null)
        this.Adapter.InsertCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[6].Value = (object) Puesto;
      if (Telefono == null)
        this.Adapter.InsertCommand.Parameters[7].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[7].Value = (object) Telefono;
      if (Correo == null)
        this.Adapter.InsertCommand.Parameters[8].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[8].Value = (object) Correo;
      if (FechaAlta.HasValue)
        this.Adapter.InsertCommand.Parameters[9].Value = (object) FechaAlta.Value;
      else
        this.Adapter.InsertCommand.Parameters[9].Value = (object) DBNull.Value;
      if (IdUsuarioModificacion.HasValue)
        this.Adapter.InsertCommand.Parameters[10].Value = (object) IdUsuarioModificacion.Value;
      else
        this.Adapter.InsertCommand.Parameters[10].Value = (object) DBNull.Value;
      if (FechaModificacion.HasValue)
        this.Adapter.InsertCommand.Parameters[11].Value = (object) FechaModificacion.Value;
      else
        this.Adapter.InsertCommand.Parameters[11].Value = (object) DBNull.Value;
      if (Activo.HasValue)
        this.Adapter.InsertCommand.Parameters[12].Value = (object) Activo.Value;
      else
        this.Adapter.InsertCommand.Parameters[12].Value = (object) DBNull.Value;
      if (EsLiderProyecto.HasValue)
        this.Adapter.InsertCommand.Parameters[13].Value = (object) EsLiderProyecto.Value;
      else
        this.Adapter.InsertCommand.Parameters[13].Value = (object) DBNull.Value;
      if (Perfil == null)
        this.Adapter.InsertCommand.Parameters[14].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[14].Value = (object) Perfil;
      if (SueldoDiario.HasValue)
        this.Adapter.InsertCommand.Parameters[15].Value = (object) SueldoDiario.Value;
      else
        this.Adapter.InsertCommand.Parameters[15].Value = (object) DBNull.Value;
      if (idSucursal.HasValue)
        this.Adapter.InsertCommand.Parameters[16].Value = (object) idSucursal.Value;
      else
        this.Adapter.InsertCommand.Parameters[16].Value = (object) DBNull.Value;
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
      Guid IdUsuario,
      string NombreCompleto,
      string Usuario,
      string Contrasena,
      string Foto,
      int? Permisos,
      string Puesto,
      string Telefono,
      string Correo,
      DateTime? FechaAlta,
      Guid? IdUsuarioModificacion,
      DateTime? FechaModificacion,
      int? Activo,
      int? EsLiderProyecto,
      string Perfil,
      Decimal? SueldoDiario,
      Guid? idSucursal,
      Guid Original_IdUsuario)
    {
      this.Adapter.UpdateCommand.Parameters[0].Value = (object) IdUsuario;
      if (NombreCompleto == null)
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) NombreCompleto;
      if (Usuario == null)
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) Usuario;
      if (Contrasena == null)
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) Contrasena;
      if (Foto == null)
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) Foto;
      if (Permisos.HasValue)
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) Permisos.Value;
      else
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) DBNull.Value;
      if (Puesto == null)
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) Puesto;
      if (Telefono == null)
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) Telefono;
      if (Correo == null)
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) Correo;
      if (FechaAlta.HasValue)
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) FechaAlta.Value;
      else
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) DBNull.Value;
      if (IdUsuarioModificacion.HasValue)
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) IdUsuarioModificacion.Value;
      else
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) DBNull.Value;
      if (FechaModificacion.HasValue)
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) FechaModificacion.Value;
      else
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) DBNull.Value;
      if (Activo.HasValue)
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) Activo.Value;
      else
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) DBNull.Value;
      if (EsLiderProyecto.HasValue)
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) EsLiderProyecto.Value;
      else
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) DBNull.Value;
      if (Perfil == null)
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) Perfil;
      if (SueldoDiario.HasValue)
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) SueldoDiario.Value;
      else
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) DBNull.Value;
      if (idSucursal.HasValue)
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) idSucursal.Value;
      else
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) DBNull.Value;
      this.Adapter.UpdateCommand.Parameters[17].Value = (object) Original_IdUsuario;
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
      string NombreCompleto,
      string Usuario,
      string Contrasena,
      string Foto,
      int? Permisos,
      string Puesto,
      string Telefono,
      string Correo,
      DateTime? FechaAlta,
      Guid? IdUsuarioModificacion,
      DateTime? FechaModificacion,
      int? Activo,
      int? EsLiderProyecto,
      string Perfil,
      Decimal? SueldoDiario,
      Guid? idSucursal,
      Guid Original_IdUsuario)
    {
      return this.Update(Original_IdUsuario, NombreCompleto, Usuario, Contrasena, Foto, Permisos, Puesto, Telefono, Correo, FechaAlta, IdUsuarioModificacion, FechaModificacion, Activo, EsLiderProyecto, Perfil, SueldoDiario, idSucursal, Original_IdUsuario);
    }
  }
}
