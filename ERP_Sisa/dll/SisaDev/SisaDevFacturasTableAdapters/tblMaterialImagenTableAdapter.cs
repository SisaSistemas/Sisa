// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDevFacturasTableAdapters.tblMaterialImagenTableAdapter
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
  public class tblMaterialImagenTableAdapter : Component
  {
    private SqlDataAdapter _adapter;
    private SqlConnection _connection;
    private SqlTransaction _transaction;
    private SqlCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public tblMaterialImagenTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblMaterialImagen",
        ColumnMappings = {
          {
            "IdMaterialImagen",
            "IdMaterialImagen"
          },
          {
            "IdMaterial",
            "IdMaterial"
          },
          {
            "Imagen",
            "Imagen"
          },
          {
            "FileName",
            "FileName"
          },
          {
            "FileExtension",
            "FileExtension"
          },
          {
            "FileSize",
            "FileSize"
          },
          {
            "FileContentType",
            "FileContentType"
          },
          {
            "Fecha",
            "Fecha"
          },
          {
            "IdUsuario",
            "IdUsuario"
          }
        }
      });
      this._adapter.DeleteCommand = new SqlCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[tblMaterialImagen] WHERE (([IdMaterialImagen] = @Original_IdMaterialImagen))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_IdMaterialImagen", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdMaterialImagen", DataRowVersion.Original, false, (object) null, "", "", ""));
      this._adapter.InsertCommand = new SqlCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[tblMaterialImagen] ([IdMaterialImagen], [IdMaterial], [Imagen], [FileName], [FileExtension], [FileSize], [FileContentType], [Fecha], [IdUsuario]) VALUES (@IdMaterialImagen, @IdMaterial, @Imagen, @FileName, @FileExtension, @FileSize, @FileContentType, @Fecha, @IdUsuario)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdMaterialImagen", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdMaterialImagen", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdMaterial", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdMaterial", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Imagen", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Imagen", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FileName", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FileName", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FileExtension", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FileExtension", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FileSize", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FileSize", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FileContentType", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FileContentType", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Fecha", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Fecha", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuario", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand = new SqlCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[tblMaterialImagen] SET [IdMaterialImagen] = @IdMaterialImagen, [IdMaterial] = @IdMaterial, [Imagen] = @Imagen, [FileName] = @FileName, [FileExtension] = @FileExtension, [FileSize] = @FileSize, [FileContentType] = @FileContentType, [Fecha] = @Fecha, [IdUsuario] = @IdUsuario WHERE (([IdMaterialImagen] = @Original_IdMaterialImagen))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdMaterialImagen", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdMaterialImagen", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdMaterial", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdMaterial", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Imagen", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Imagen", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FileName", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FileName", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FileExtension", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FileExtension", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FileSize", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FileSize", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FileContentType", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FileContentType", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Fecha", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Fecha", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuario", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_IdMaterialImagen", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdMaterialImagen", DataRowVersion.Original, false, (object) null, "", "", ""));
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
      this._commandCollection[0].CommandText = "SELECT IdMaterialImagen, IdMaterial, Imagen, FileName, FileExtension, FileSize, FileContentType, Fecha, IdUsuario FROM dbo.tblMaterialImagen";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(
      SisaDevFacturas.tblMaterialImagenDataTable dataTable)
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
    public virtual SisaDevFacturas.tblMaterialImagenDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      SisaDevFacturas.tblMaterialImagenDataTable materialImagenDataTable = new SisaDevFacturas.tblMaterialImagenDataTable();
      this.Adapter.Fill((DataTable) materialImagenDataTable);
      return materialImagenDataTable;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(
      SisaDevFacturas.tblMaterialImagenDataTable dataTable)
    {
      return this.Adapter.Update((DataTable) dataTable);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas dataSet) => this.Adapter.Update((DataSet) dataSet, "tblMaterialImagen");

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
    public virtual int Delete(Guid Original_IdMaterialImagen)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) Original_IdMaterialImagen;
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
      Guid IdMaterialImagen,
      Guid IdMaterial,
      string Imagen,
      string FileName,
      string FileExtension,
      string FileSize,
      string FileContentType,
      DateTime Fecha,
      Guid IdUsuario)
    {
      this.Adapter.InsertCommand.Parameters[0].Value = (object) IdMaterialImagen;
      this.Adapter.InsertCommand.Parameters[1].Value = (object) IdMaterial;
      this.Adapter.InsertCommand.Parameters[2].Value = Imagen != null ? (object) Imagen : throw new ArgumentNullException(nameof (Imagen));
      this.Adapter.InsertCommand.Parameters[3].Value = FileName != null ? (object) FileName : throw new ArgumentNullException(nameof (FileName));
      this.Adapter.InsertCommand.Parameters[4].Value = FileExtension != null ? (object) FileExtension : throw new ArgumentNullException(nameof (FileExtension));
      this.Adapter.InsertCommand.Parameters[5].Value = FileSize != null ? (object) FileSize : throw new ArgumentNullException(nameof (FileSize));
      this.Adapter.InsertCommand.Parameters[6].Value = FileContentType != null ? (object) FileContentType : throw new ArgumentNullException(nameof (FileContentType));
      this.Adapter.InsertCommand.Parameters[7].Value = (object) Fecha;
      this.Adapter.InsertCommand.Parameters[8].Value = (object) IdUsuario;
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
      Guid IdMaterialImagen,
      Guid IdMaterial,
      string Imagen,
      string FileName,
      string FileExtension,
      string FileSize,
      string FileContentType,
      DateTime Fecha,
      Guid IdUsuario,
      Guid Original_IdMaterialImagen)
    {
      this.Adapter.UpdateCommand.Parameters[0].Value = (object) IdMaterialImagen;
      this.Adapter.UpdateCommand.Parameters[1].Value = (object) IdMaterial;
      this.Adapter.UpdateCommand.Parameters[2].Value = Imagen != null ? (object) Imagen : throw new ArgumentNullException(nameof (Imagen));
      this.Adapter.UpdateCommand.Parameters[3].Value = FileName != null ? (object) FileName : throw new ArgumentNullException(nameof (FileName));
      this.Adapter.UpdateCommand.Parameters[4].Value = FileExtension != null ? (object) FileExtension : throw new ArgumentNullException(nameof (FileExtension));
      this.Adapter.UpdateCommand.Parameters[5].Value = FileSize != null ? (object) FileSize : throw new ArgumentNullException(nameof (FileSize));
      this.Adapter.UpdateCommand.Parameters[6].Value = FileContentType != null ? (object) FileContentType : throw new ArgumentNullException(nameof (FileContentType));
      this.Adapter.UpdateCommand.Parameters[7].Value = (object) Fecha;
      this.Adapter.UpdateCommand.Parameters[8].Value = (object) IdUsuario;
      this.Adapter.UpdateCommand.Parameters[9].Value = (object) Original_IdMaterialImagen;
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
      Guid IdMaterial,
      string Imagen,
      string FileName,
      string FileExtension,
      string FileSize,
      string FileContentType,
      DateTime Fecha,
      Guid IdUsuario,
      Guid Original_IdMaterialImagen)
    {
      return this.Update(Original_IdMaterialImagen, IdMaterial, Imagen, FileName, FileExtension, FileSize, FileContentType, Fecha, IdUsuario, Original_IdMaterialImagen);
    }
  }
}
