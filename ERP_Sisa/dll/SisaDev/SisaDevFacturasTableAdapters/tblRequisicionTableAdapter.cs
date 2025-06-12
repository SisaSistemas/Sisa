// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDevFacturasTableAdapters.tblRequisicionTableAdapter
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
  public class tblRequisicionTableAdapter : Component
  {
    private SqlDataAdapter _adapter;
    private SqlConnection _connection;
    private SqlTransaction _transaction;
    private SqlCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public tblRequisicionTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblRequisicion",
        ColumnMappings = {
          {
            "IdRequisicion",
            "IdRequisicion"
          },
          {
            "NoRequisicion",
            "NoRequisicion"
          },
          {
            "IdEmpresa",
            "IdEmpresa"
          },
          {
            "idContacto",
            "idContacto"
          },
          {
            "Concepto",
            "Concepto"
          },
          {
            "FechaRequisicion",
            "FechaRequisicion"
          },
          {
            "TIMESTAMP",
            "TIMESTAMP"
          },
          {
            "Estatus",
            "Estatus"
          },
          {
            "NombreArchivoPdf",
            "NombreArchivoPdf"
          },
          {
            "DocumentoPdf",
            "DocumentoPdf"
          },
          {
            "NombreArchivoXls",
            "NombreArchivoXls"
          },
          {
            "DocumentoXls",
            "DocumentoXls"
          },
          {
            "CostoRequisicion",
            "CostoRequisicion"
          },
          {
            "IdUsuarioCancela",
            "IdUsuarioCancela"
          },
          {
            "ComentarioCancela",
            "ComentarioCancela"
          },
          {
            "FechaCancela",
            "FechaCancela"
          },
          {
            "FechaEnviada",
            "FechaEnviada"
          },
          {
            "IdUsuarioEnvia",
            "IdUsuarioEnvia"
          },
          {
            "IdUsuarioCreo",
            "IdUsuarioCreo"
          }
        }
      });
      this._adapter.DeleteCommand = new SqlCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[tblRequisicion] WHERE (([IdRequisicion] = @Original_IdRequisicion))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_IdRequisicion", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdRequisicion", DataRowVersion.Original, false, (object) null, "", "", ""));
      this._adapter.InsertCommand = new SqlCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[tblRequisicion] ([IdRequisicion], [NoRequisicion], [IdEmpresa], [idContacto], [Concepto], [FechaRequisicion], [TIMESTAMP], [Estatus], [NombreArchivoPdf], [DocumentoPdf], [NombreArchivoXls], [DocumentoXls], [CostoRequisicion], [IdUsuarioCancela], [ComentarioCancela], [FechaCancela], [FechaEnviada], [IdUsuarioEnvia], [IdUsuarioCreo]) VALUES (@IdRequisicion, @NoRequisicion, @IdEmpresa, @idContacto, @Concepto, @FechaRequisicion, @TIMESTAMP, @Estatus, @NombreArchivoPdf, @DocumentoPdf, @NombreArchivoXls, @DocumentoXls, @CostoRequisicion, @IdUsuarioCancela, @ComentarioCancela, @FechaCancela, @FechaEnviada, @IdUsuarioEnvia, @IdUsuarioCreo)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdRequisicion", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdRequisicion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@NoRequisicion", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoRequisicion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdEmpresa", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdEmpresa", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@idContacto", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "idContacto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Concepto", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Concepto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaRequisicion", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaRequisicion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@TIMESTAMP", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TIMESTAMP", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Estatus", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@NombreArchivoPdf", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NombreArchivoPdf", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@DocumentoPdf", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DocumentoPdf", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@NombreArchivoXls", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NombreArchivoXls", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@DocumentoXls", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DocumentoXls", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@CostoRequisicion", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "CostoRequisicion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuarioCancela", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioCancela", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ComentarioCancela", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ComentarioCancela", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaCancela", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaCancela", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaEnviada", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaEnviada", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuarioEnvia", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioEnvia", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuarioCreo", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioCreo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand = new SqlCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[tblRequisicion] SET [IdRequisicion] = @IdRequisicion, [NoRequisicion] = @NoRequisicion, [IdEmpresa] = @IdEmpresa, [idContacto] = @idContacto, [Concepto] = @Concepto, [FechaRequisicion] = @FechaRequisicion, [TIMESTAMP] = @TIMESTAMP, [Estatus] = @Estatus, [NombreArchivoPdf] = @NombreArchivoPdf, [DocumentoPdf] = @DocumentoPdf, [NombreArchivoXls] = @NombreArchivoXls, [DocumentoXls] = @DocumentoXls, [CostoRequisicion] = @CostoRequisicion, [IdUsuarioCancela] = @IdUsuarioCancela, [ComentarioCancela] = @ComentarioCancela, [FechaCancela] = @FechaCancela, [FechaEnviada] = @FechaEnviada, [IdUsuarioEnvia] = @IdUsuarioEnvia, [IdUsuarioCreo] = @IdUsuarioCreo WHERE (([IdRequisicion] = @Original_IdRequisicion))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdRequisicion", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdRequisicion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@NoRequisicion", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NoRequisicion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdEmpresa", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdEmpresa", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@idContacto", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "idContacto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Concepto", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Concepto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaRequisicion", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaRequisicion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@TIMESTAMP", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "TIMESTAMP", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Estatus", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@NombreArchivoPdf", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NombreArchivoPdf", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@DocumentoPdf", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DocumentoPdf", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@NombreArchivoXls", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NombreArchivoXls", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@DocumentoXls", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "DocumentoXls", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CostoRequisicion", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 18, (byte) 2, "CostoRequisicion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdUsuarioCancela", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioCancela", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ComentarioCancela", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ComentarioCancela", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaCancela", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaCancela", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaEnviada", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaEnviada", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdUsuarioEnvia", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioEnvia", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdUsuarioCreo", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioCreo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_IdRequisicion", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdRequisicion", DataRowVersion.Original, false, (object) null, "", "", ""));
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
      this._commandCollection[0].CommandText = "SELECT IdRequisicion, NoRequisicion, IdEmpresa, idContacto, Concepto, FechaRequisicion, TIMESTAMP, Estatus, NombreArchivoPdf, DocumentoPdf, NombreArchivoXls, DocumentoXls, CostoRequisicion, IdUsuarioCancela, ComentarioCancela, FechaCancela, FechaEnviada, IdUsuarioEnvia, IdUsuarioCreo FROM dbo.tblRequisicion";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(SisaDevFacturas.tblRequisicionDataTable dataTable)
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
    public virtual SisaDevFacturas.tblRequisicionDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      SisaDevFacturas.tblRequisicionDataTable requisicionDataTable = new SisaDevFacturas.tblRequisicionDataTable();
      this.Adapter.Fill((DataTable) requisicionDataTable);
      return requisicionDataTable;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas.tblRequisicionDataTable dataTable) => this.Adapter.Update((DataTable) dataTable);

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas dataSet) => this.Adapter.Update((DataSet) dataSet, "tblRequisicion");

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
    public virtual int Delete(Guid Original_IdRequisicion)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) Original_IdRequisicion;
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
      Guid IdRequisicion,
      string NoRequisicion,
      Guid IdEmpresa,
      Guid idContacto,
      string Concepto,
      DateTime FechaRequisicion,
      DateTime TIMESTAMP,
      int Estatus,
      string NombreArchivoPdf,
      string DocumentoPdf,
      string NombreArchivoXls,
      string DocumentoXls,
      Decimal? CostoRequisicion,
      Guid? IdUsuarioCancela,
      string ComentarioCancela,
      DateTime? FechaCancela,
      DateTime? FechaEnviada,
      Guid? IdUsuarioEnvia,
      Guid? IdUsuarioCreo)
    {
      this.Adapter.InsertCommand.Parameters[0].Value = (object) IdRequisicion;
      this.Adapter.InsertCommand.Parameters[1].Value = NoRequisicion != null ? (object) NoRequisicion : throw new ArgumentNullException(nameof (NoRequisicion));
      this.Adapter.InsertCommand.Parameters[2].Value = (object) IdEmpresa;
      this.Adapter.InsertCommand.Parameters[3].Value = (object) idContacto;
      this.Adapter.InsertCommand.Parameters[4].Value = Concepto != null ? (object) Concepto : throw new ArgumentNullException(nameof (Concepto));
      this.Adapter.InsertCommand.Parameters[5].Value = (object) FechaRequisicion;
      this.Adapter.InsertCommand.Parameters[6].Value = (object) TIMESTAMP;
      this.Adapter.InsertCommand.Parameters[7].Value = (object) Estatus;
      if (NombreArchivoPdf == null)
        this.Adapter.InsertCommand.Parameters[8].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[8].Value = (object) NombreArchivoPdf;
      if (DocumentoPdf == null)
        this.Adapter.InsertCommand.Parameters[9].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[9].Value = (object) DocumentoPdf;
      if (NombreArchivoXls == null)
        this.Adapter.InsertCommand.Parameters[10].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[10].Value = (object) NombreArchivoXls;
      if (DocumentoXls == null)
        this.Adapter.InsertCommand.Parameters[11].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[11].Value = (object) DocumentoXls;
      if (CostoRequisicion.HasValue)
        this.Adapter.InsertCommand.Parameters[12].Value = (object) CostoRequisicion.Value;
      else
        this.Adapter.InsertCommand.Parameters[12].Value = (object) DBNull.Value;
      if (IdUsuarioCancela.HasValue)
        this.Adapter.InsertCommand.Parameters[13].Value = (object) IdUsuarioCancela.Value;
      else
        this.Adapter.InsertCommand.Parameters[13].Value = (object) DBNull.Value;
      if (ComentarioCancela == null)
        this.Adapter.InsertCommand.Parameters[14].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[14].Value = (object) ComentarioCancela;
      if (FechaCancela.HasValue)
        this.Adapter.InsertCommand.Parameters[15].Value = (object) FechaCancela.Value;
      else
        this.Adapter.InsertCommand.Parameters[15].Value = (object) DBNull.Value;
      if (FechaEnviada.HasValue)
        this.Adapter.InsertCommand.Parameters[16].Value = (object) FechaEnviada.Value;
      else
        this.Adapter.InsertCommand.Parameters[16].Value = (object) DBNull.Value;
      if (IdUsuarioEnvia.HasValue)
        this.Adapter.InsertCommand.Parameters[17].Value = (object) IdUsuarioEnvia.Value;
      else
        this.Adapter.InsertCommand.Parameters[17].Value = (object) DBNull.Value;
      if (IdUsuarioCreo.HasValue)
        this.Adapter.InsertCommand.Parameters[18].Value = (object) IdUsuarioCreo.Value;
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
      Guid IdRequisicion,
      string NoRequisicion,
      Guid IdEmpresa,
      Guid idContacto,
      string Concepto,
      DateTime FechaRequisicion,
      DateTime TIMESTAMP,
      int Estatus,
      string NombreArchivoPdf,
      string DocumentoPdf,
      string NombreArchivoXls,
      string DocumentoXls,
      Decimal? CostoRequisicion,
      Guid? IdUsuarioCancela,
      string ComentarioCancela,
      DateTime? FechaCancela,
      DateTime? FechaEnviada,
      Guid? IdUsuarioEnvia,
      Guid? IdUsuarioCreo,
      Guid Original_IdRequisicion)
    {
      this.Adapter.UpdateCommand.Parameters[0].Value = (object) IdRequisicion;
      this.Adapter.UpdateCommand.Parameters[1].Value = NoRequisicion != null ? (object) NoRequisicion : throw new ArgumentNullException(nameof (NoRequisicion));
      this.Adapter.UpdateCommand.Parameters[2].Value = (object) IdEmpresa;
      this.Adapter.UpdateCommand.Parameters[3].Value = (object) idContacto;
      this.Adapter.UpdateCommand.Parameters[4].Value = Concepto != null ? (object) Concepto : throw new ArgumentNullException(nameof (Concepto));
      this.Adapter.UpdateCommand.Parameters[5].Value = (object) FechaRequisicion;
      this.Adapter.UpdateCommand.Parameters[6].Value = (object) TIMESTAMP;
      this.Adapter.UpdateCommand.Parameters[7].Value = (object) Estatus;
      if (NombreArchivoPdf == null)
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) NombreArchivoPdf;
      if (DocumentoPdf == null)
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) DocumentoPdf;
      if (NombreArchivoXls == null)
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) NombreArchivoXls;
      if (DocumentoXls == null)
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) DocumentoXls;
      if (CostoRequisicion.HasValue)
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) CostoRequisicion.Value;
      else
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) DBNull.Value;
      if (IdUsuarioCancela.HasValue)
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) IdUsuarioCancela.Value;
      else
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) DBNull.Value;
      if (ComentarioCancela == null)
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) ComentarioCancela;
      if (FechaCancela.HasValue)
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) FechaCancela.Value;
      else
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) DBNull.Value;
      if (FechaEnviada.HasValue)
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) FechaEnviada.Value;
      else
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) DBNull.Value;
      if (IdUsuarioEnvia.HasValue)
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) IdUsuarioEnvia.Value;
      else
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) DBNull.Value;
      if (IdUsuarioCreo.HasValue)
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) IdUsuarioCreo.Value;
      else
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) DBNull.Value;
      this.Adapter.UpdateCommand.Parameters[19].Value = (object) Original_IdRequisicion;
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
      string NoRequisicion,
      Guid IdEmpresa,
      Guid idContacto,
      string Concepto,
      DateTime FechaRequisicion,
      DateTime TIMESTAMP,
      int Estatus,
      string NombreArchivoPdf,
      string DocumentoPdf,
      string NombreArchivoXls,
      string DocumentoXls,
      Decimal? CostoRequisicion,
      Guid? IdUsuarioCancela,
      string ComentarioCancela,
      DateTime? FechaCancela,
      DateTime? FechaEnviada,
      Guid? IdUsuarioEnvia,
      Guid? IdUsuarioCreo,
      Guid Original_IdRequisicion)
    {
      return this.Update(Original_IdRequisicion, NoRequisicion, IdEmpresa, idContacto, Concepto, FechaRequisicion, TIMESTAMP, Estatus, NombreArchivoPdf, DocumentoPdf, NombreArchivoXls, DocumentoXls, CostoRequisicion, IdUsuarioCancela, ComentarioCancela, FechaCancela, FechaEnviada, IdUsuarioEnvia, IdUsuarioCreo, Original_IdRequisicion);
    }
  }
}
