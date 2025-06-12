// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDevFacturasTableAdapters.tblProyectosTableAdapter
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
  public class tblProyectosTableAdapter : Component
  {
    private SqlDataAdapter _adapter;
    private SqlConnection _connection;
    private SqlTransaction _transaction;
    private SqlCommand[] _commandCollection;
    private bool _clearBeforeFill;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public tblProyectosTableAdapter() => this.ClearBeforeFill = true;

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
        DataSetTable = "tblProyectos",
        ColumnMappings = {
          {
            "IdProyecto",
            "IdProyecto"
          },
          {
            "FolioProyecto",
            "FolioProyecto"
          },
          {
            "NombreProyecto",
            "NombreProyecto"
          },
          {
            "Descripcion",
            "Descripcion"
          },
          {
            "IdLider",
            "IdLider"
          },
          {
            "IdCliente",
            "IdCliente"
          },
          {
            "Estatus",
            "Estatus"
          },
          {
            "FechaInicio",
            "FechaInicio"
          },
          {
            "FechaFin",
            "FechaFin"
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
            "UserProject1",
            "UserProject1"
          },
          {
            "UserProject2",
            "UserProject2"
          },
          {
            "UserProject3",
            "UserProject3"
          },
          {
            "UserProject4",
            "UserProject4"
          },
          {
            "IdCotizacion",
            "IdCotizacion"
          },
          {
            "CostoCotizacion",
            "CostoCotizacion"
          },
          {
            "FechaTermino",
            "FechaTermino"
          },
          {
            "EstatusDesc",
            "EstatusDesc"
          },
          {
            "NombreOC",
            "NombreOC"
          },
          {
            "ArchivoOC",
            "ArchivoOC"
          },
          {
            "NombreCL",
            "NombreCL"
          },
          {
            "ArchivoCL",
            "ArchivoCL"
          },
          {
            "NombreFC",
            "NombreFC"
          },
          {
            "ArchivoFC",
            "ArchivoFC"
          },
          {
            "CostoMOCotizado",
            "CostoMOCotizado"
          },
          {
            "CostoMaterialCotizado",
            "CostoMaterialCotizado"
          },
          {
            "CostoMECotizado",
            "CostoMECotizado"
          },
          {
            "CostoMOProyectado",
            "CostoMOProyectado"
          },
          {
            "CostoMaterialProyectado",
            "CostoMaterialProyectado"
          },
          {
            "CostoMEProyectado",
            "CostoMEProyectado"
          }
        }
      });
      this._adapter.DeleteCommand = new SqlCommand();
      this._adapter.DeleteCommand.Connection = this.Connection;
      this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[tblProyectos] WHERE (([IdProyecto] = @Original_IdProyecto))";
      this._adapter.DeleteCommand.CommandType = CommandType.Text;
      this._adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_IdProyecto", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdProyecto", DataRowVersion.Original, false, (object) null, "", "", ""));
      this._adapter.InsertCommand = new SqlCommand();
      this._adapter.InsertCommand.Connection = this.Connection;
      this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[tblProyectos] ([IdProyecto], [FolioProyecto], [NombreProyecto], [Descripcion], [IdLider], [IdCliente], [Estatus], [FechaInicio], [FechaFin], [IdUsuarioAlta], [FechaAlta], [IdUsuarioModificacion], [FechaModificacion], [Activo], [UserProject1], [UserProject2], [UserProject3], [UserProject4], [IdCotizacion], [CostoCotizacion], [FechaTermino], [EstatusDesc], [NombreOC], [ArchivoOC], [NombreCL], [ArchivoCL], [NombreFC], [ArchivoFC], [CostoMOCotizado], [CostoMaterialCotizado], [CostoMECotizado], [CostoMOProyectado], [CostoMaterialProyectado], [CostoMEProyectado]) VALUES (@IdProyecto, @FolioProyecto, @NombreProyecto, @Descripcion, @IdLider, @IdCliente, @Estatus, @FechaInicio, @FechaFin, @IdUsuarioAlta, @FechaAlta, @IdUsuarioModificacion, @FechaModificacion, @Activo, @UserProject1, @UserProject2, @UserProject3, @UserProject4, @IdCotizacion, @CostoCotizacion, @FechaTermino, @EstatusDesc, @NombreOC, @ArchivoOC, @NombreCL, @ArchivoCL, @NombreFC, @ArchivoFC, @CostoMOCotizado, @CostoMaterialCotizado, @CostoMECotizado, @CostoMOProyectado, @CostoMaterialProyectado, @CostoMEProyectado)";
      this._adapter.InsertCommand.CommandType = CommandType.Text;
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdProyecto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FolioProyecto", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FolioProyecto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@NombreProyecto", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NombreProyecto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Descripcion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdLider", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdLider", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdCliente", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdCliente", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Estatus", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Estatus", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaInicio", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaInicio", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaFin", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaFin", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuarioAlta", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaAlta", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdUsuarioModificacion", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaModificacion", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@Activo", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Activo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@UserProject1", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "UserProject1", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@UserProject2", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "UserProject2", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@UserProject3", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "UserProject3", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@UserProject4", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "UserProject4", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdCotizacion", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdCotizacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@CostoCotizacion", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 20, (byte) 2, "CostoCotizacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@FechaTermino", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaTermino", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@EstatusDesc", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EstatusDesc", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@NombreOC", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NombreOC", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ArchivoOC", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ArchivoOC", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@NombreCL", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NombreCL", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ArchivoCL", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ArchivoCL", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@NombreFC", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NombreFC", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@ArchivoFC", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ArchivoFC", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@CostoMOCotizado", SqlDbType.Float, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CostoMOCotizado", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@CostoMaterialCotizado", SqlDbType.Float, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CostoMaterialCotizado", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@CostoMECotizado", SqlDbType.Float, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CostoMECotizado", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@CostoMOProyectado", SqlDbType.Float, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CostoMOProyectado", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@CostoMaterialProyectado", SqlDbType.Float, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CostoMaterialProyectado", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.InsertCommand.Parameters.Add(new SqlParameter("@CostoMEProyectado", SqlDbType.Float, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CostoMEProyectado", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand = new SqlCommand();
      this._adapter.UpdateCommand.Connection = this.Connection;
      this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[tblProyectos] SET [IdProyecto] = @IdProyecto, [FolioProyecto] = @FolioProyecto, [NombreProyecto] = @NombreProyecto, [Descripcion] = @Descripcion, [IdLider] = @IdLider, [IdCliente] = @IdCliente, [Estatus] = @Estatus, [FechaInicio] = @FechaInicio, [FechaFin] = @FechaFin, [IdUsuarioAlta] = @IdUsuarioAlta, [FechaAlta] = @FechaAlta, [IdUsuarioModificacion] = @IdUsuarioModificacion, [FechaModificacion] = @FechaModificacion, [Activo] = @Activo, [UserProject1] = @UserProject1, [UserProject2] = @UserProject2, [UserProject3] = @UserProject3, [UserProject4] = @UserProject4, [IdCotizacion] = @IdCotizacion, [CostoCotizacion] = @CostoCotizacion, [FechaTermino] = @FechaTermino, [EstatusDesc] = @EstatusDesc, [NombreOC] = @NombreOC, [ArchivoOC] = @ArchivoOC, [NombreCL] = @NombreCL, [ArchivoCL] = @ArchivoCL, [NombreFC] = @NombreFC, [ArchivoFC] = @ArchivoFC, [CostoMOCotizado] = @CostoMOCotizado, [CostoMaterialCotizado] = @CostoMaterialCotizado, [CostoMECotizado] = @CostoMECotizado, [CostoMOProyectado] = @CostoMOProyectado, [CostoMaterialProyectado] = @CostoMaterialProyectado, [CostoMEProyectado] = @CostoMEProyectado WHERE (([IdProyecto] = @Original_IdProyecto))";
      this._adapter.UpdateCommand.CommandType = CommandType.Text;
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdProyecto", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdProyecto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FolioProyecto", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FolioProyecto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@NombreProyecto", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NombreProyecto", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Descripcion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdLider", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdLider", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdCliente", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdCliente", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Estatus", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Estatus", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaInicio", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaInicio", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaFin", SqlDbType.Date, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaFin", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdUsuarioAlta", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaAlta", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaAlta", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdUsuarioModificacion", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdUsuarioModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaModificacion", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaModificacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Activo", SqlDbType.Int, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "Activo", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@UserProject1", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "UserProject1", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@UserProject2", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "UserProject2", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@UserProject3", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "UserProject3", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@UserProject4", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "UserProject4", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdCotizacion", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdCotizacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CostoCotizacion", SqlDbType.Decimal, 0, ParameterDirection.Input, (byte) 20, (byte) 2, "CostoCotizacion", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@FechaTermino", SqlDbType.DateTime, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "FechaTermino", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@EstatusDesc", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "EstatusDesc", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@NombreOC", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NombreOC", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ArchivoOC", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ArchivoOC", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@NombreCL", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NombreCL", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ArchivoCL", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ArchivoCL", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@NombreFC", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "NombreFC", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ArchivoFC", SqlDbType.VarChar, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "ArchivoFC", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CostoMOCotizado", SqlDbType.Float, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CostoMOCotizado", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CostoMaterialCotizado", SqlDbType.Float, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CostoMaterialCotizado", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CostoMECotizado", SqlDbType.Float, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CostoMECotizado", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CostoMOProyectado", SqlDbType.Float, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CostoMOProyectado", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CostoMaterialProyectado", SqlDbType.Float, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CostoMaterialProyectado", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@CostoMEProyectado", SqlDbType.Float, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "CostoMEProyectado", DataRowVersion.Current, false, (object) null, "", "", ""));
      this._adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_IdProyecto", SqlDbType.UniqueIdentifier, 0, ParameterDirection.Input, (byte) 0, (byte) 0, "IdProyecto", DataRowVersion.Original, false, (object) null, "", "", ""));
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
      this._commandCollection[0].CommandText = "SELECT IdProyecto, FolioProyecto, NombreProyecto, Descripcion, IdLider, IdCliente, Estatus, FechaInicio, FechaFin, IdUsuarioAlta, FechaAlta, IdUsuarioModificacion, FechaModificacion, Activo, UserProject1, UserProject2, UserProject3, UserProject4, IdCotizacion, CostoCotizacion, FechaTermino, EstatusDesc, NombreOC, ArchivoOC, NombreCL, ArchivoCL, NombreFC, ArchivoFC, CostoMOCotizado, CostoMaterialCotizado, CostoMECotizado, CostoMOProyectado, CostoMaterialProyectado, CostoMEProyectado FROM dbo.tblProyectos";
      this._commandCollection[0].CommandType = CommandType.Text;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    [DataObjectMethod(DataObjectMethodType.Fill, true)]
    public virtual int Fill(SisaDevFacturas.tblProyectosDataTable dataTable)
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
    public virtual SisaDevFacturas.tblProyectosDataTable GetData()
    {
      this.Adapter.SelectCommand = this.CommandCollection[0];
      SisaDevFacturas.tblProyectosDataTable proyectosDataTable = new SisaDevFacturas.tblProyectosDataTable();
      this.Adapter.Fill((DataTable) proyectosDataTable);
      return proyectosDataTable;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas.tblProyectosDataTable dataTable) => this.Adapter.Update((DataTable) dataTable);

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [HelpKeyword("vs.data.TableAdapter")]
    public virtual int Update(SisaDevFacturas dataSet) => this.Adapter.Update((DataSet) dataSet, "tblProyectos");

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
    public virtual int Delete(Guid Original_IdProyecto)
    {
      this.Adapter.DeleteCommand.Parameters[0].Value = (object) Original_IdProyecto;
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
      Guid IdProyecto,
      string FolioProyecto,
      string NombreProyecto,
      string Descripcion,
      string IdLider,
      string IdCliente,
      string Estatus,
      DateTime? FechaInicio,
      DateTime? FechaFin,
      Guid? IdUsuarioAlta,
      DateTime? FechaAlta,
      Guid? IdUsuarioModificacion,
      DateTime? FechaModificacion,
      int? Activo,
      string UserProject1,
      string UserProject2,
      string UserProject3,
      string UserProject4,
      string IdCotizacion,
      Decimal? CostoCotizacion,
      DateTime? FechaTermino,
      string EstatusDesc,
      string NombreOC,
      string ArchivoOC,
      string NombreCL,
      string ArchivoCL,
      string NombreFC,
      string ArchivoFC,
      double? CostoMOCotizado,
      double? CostoMaterialCotizado,
      double? CostoMECotizado,
      double? CostoMOProyectado,
      double? CostoMaterialProyectado,
      double? CostoMEProyectado)
    {
      this.Adapter.InsertCommand.Parameters[0].Value = (object) IdProyecto;
      if (FolioProyecto == null)
        this.Adapter.InsertCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[1].Value = (object) FolioProyecto;
      if (NombreProyecto == null)
        this.Adapter.InsertCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[2].Value = (object) NombreProyecto;
      if (Descripcion == null)
        this.Adapter.InsertCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[3].Value = (object) Descripcion;
      if (IdLider == null)
        this.Adapter.InsertCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[4].Value = (object) IdLider;
      if (IdCliente == null)
        this.Adapter.InsertCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[5].Value = (object) IdCliente;
      if (Estatus == null)
        this.Adapter.InsertCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[6].Value = (object) Estatus;
      if (FechaInicio.HasValue)
        this.Adapter.InsertCommand.Parameters[7].Value = (object) FechaInicio.Value;
      else
        this.Adapter.InsertCommand.Parameters[7].Value = (object) DBNull.Value;
      if (FechaFin.HasValue)
        this.Adapter.InsertCommand.Parameters[8].Value = (object) FechaFin.Value;
      else
        this.Adapter.InsertCommand.Parameters[8].Value = (object) DBNull.Value;
      if (IdUsuarioAlta.HasValue)
        this.Adapter.InsertCommand.Parameters[9].Value = (object) IdUsuarioAlta.Value;
      else
        this.Adapter.InsertCommand.Parameters[9].Value = (object) DBNull.Value;
      if (FechaAlta.HasValue)
        this.Adapter.InsertCommand.Parameters[10].Value = (object) FechaAlta.Value;
      else
        this.Adapter.InsertCommand.Parameters[10].Value = (object) DBNull.Value;
      if (IdUsuarioModificacion.HasValue)
        this.Adapter.InsertCommand.Parameters[11].Value = (object) IdUsuarioModificacion.Value;
      else
        this.Adapter.InsertCommand.Parameters[11].Value = (object) DBNull.Value;
      if (FechaModificacion.HasValue)
        this.Adapter.InsertCommand.Parameters[12].Value = (object) FechaModificacion.Value;
      else
        this.Adapter.InsertCommand.Parameters[12].Value = (object) DBNull.Value;
      if (Activo.HasValue)
        this.Adapter.InsertCommand.Parameters[13].Value = (object) Activo.Value;
      else
        this.Adapter.InsertCommand.Parameters[13].Value = (object) DBNull.Value;
      if (UserProject1 == null)
        this.Adapter.InsertCommand.Parameters[14].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[14].Value = (object) UserProject1;
      if (UserProject2 == null)
        this.Adapter.InsertCommand.Parameters[15].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[15].Value = (object) UserProject2;
      if (UserProject3 == null)
        this.Adapter.InsertCommand.Parameters[16].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[16].Value = (object) UserProject3;
      if (UserProject4 == null)
        this.Adapter.InsertCommand.Parameters[17].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[17].Value = (object) UserProject4;
      if (IdCotizacion == null)
        this.Adapter.InsertCommand.Parameters[18].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[18].Value = (object) IdCotizacion;
      if (CostoCotizacion.HasValue)
        this.Adapter.InsertCommand.Parameters[19].Value = (object) CostoCotizacion.Value;
      else
        this.Adapter.InsertCommand.Parameters[19].Value = (object) DBNull.Value;
      if (FechaTermino.HasValue)
        this.Adapter.InsertCommand.Parameters[20].Value = (object) FechaTermino.Value;
      else
        this.Adapter.InsertCommand.Parameters[20].Value = (object) DBNull.Value;
      if (EstatusDesc == null)
        this.Adapter.InsertCommand.Parameters[21].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[21].Value = (object) EstatusDesc;
      if (NombreOC == null)
        this.Adapter.InsertCommand.Parameters[22].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[22].Value = (object) NombreOC;
      if (ArchivoOC == null)
        this.Adapter.InsertCommand.Parameters[23].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[23].Value = (object) ArchivoOC;
      if (NombreCL == null)
        this.Adapter.InsertCommand.Parameters[24].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[24].Value = (object) NombreCL;
      if (ArchivoCL == null)
        this.Adapter.InsertCommand.Parameters[25].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[25].Value = (object) ArchivoCL;
      if (NombreFC == null)
        this.Adapter.InsertCommand.Parameters[26].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[26].Value = (object) NombreFC;
      if (ArchivoFC == null)
        this.Adapter.InsertCommand.Parameters[27].Value = (object) DBNull.Value;
      else
        this.Adapter.InsertCommand.Parameters[27].Value = (object) ArchivoFC;
      if (CostoMOCotizado.HasValue)
        this.Adapter.InsertCommand.Parameters[28].Value = (object) CostoMOCotizado.Value;
      else
        this.Adapter.InsertCommand.Parameters[28].Value = (object) DBNull.Value;
      if (CostoMaterialCotizado.HasValue)
        this.Adapter.InsertCommand.Parameters[29].Value = (object) CostoMaterialCotizado.Value;
      else
        this.Adapter.InsertCommand.Parameters[29].Value = (object) DBNull.Value;
      if (CostoMECotizado.HasValue)
        this.Adapter.InsertCommand.Parameters[30].Value = (object) CostoMECotizado.Value;
      else
        this.Adapter.InsertCommand.Parameters[30].Value = (object) DBNull.Value;
      if (CostoMOProyectado.HasValue)
        this.Adapter.InsertCommand.Parameters[31].Value = (object) CostoMOProyectado.Value;
      else
        this.Adapter.InsertCommand.Parameters[31].Value = (object) DBNull.Value;
      if (CostoMaterialProyectado.HasValue)
        this.Adapter.InsertCommand.Parameters[32].Value = (object) CostoMaterialProyectado.Value;
      else
        this.Adapter.InsertCommand.Parameters[32].Value = (object) DBNull.Value;
      if (CostoMEProyectado.HasValue)
        this.Adapter.InsertCommand.Parameters[33].Value = (object) CostoMEProyectado.Value;
      else
        this.Adapter.InsertCommand.Parameters[33].Value = (object) DBNull.Value;
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
      Guid IdProyecto,
      string FolioProyecto,
      string NombreProyecto,
      string Descripcion,
      string IdLider,
      string IdCliente,
      string Estatus,
      DateTime? FechaInicio,
      DateTime? FechaFin,
      Guid? IdUsuarioAlta,
      DateTime? FechaAlta,
      Guid? IdUsuarioModificacion,
      DateTime? FechaModificacion,
      int? Activo,
      string UserProject1,
      string UserProject2,
      string UserProject3,
      string UserProject4,
      string IdCotizacion,
      Decimal? CostoCotizacion,
      DateTime? FechaTermino,
      string EstatusDesc,
      string NombreOC,
      string ArchivoOC,
      string NombreCL,
      string ArchivoCL,
      string NombreFC,
      string ArchivoFC,
      double? CostoMOCotizado,
      double? CostoMaterialCotizado,
      double? CostoMECotizado,
      double? CostoMOProyectado,
      double? CostoMaterialProyectado,
      double? CostoMEProyectado,
      Guid Original_IdProyecto)
    {
      this.Adapter.UpdateCommand.Parameters[0].Value = (object) IdProyecto;
      if (FolioProyecto == null)
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[1].Value = (object) FolioProyecto;
      if (NombreProyecto == null)
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[2].Value = (object) NombreProyecto;
      if (Descripcion == null)
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[3].Value = (object) Descripcion;
      if (IdLider == null)
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[4].Value = (object) IdLider;
      if (IdCliente == null)
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[5].Value = (object) IdCliente;
      if (Estatus == null)
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[6].Value = (object) Estatus;
      if (FechaInicio.HasValue)
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) FechaInicio.Value;
      else
        this.Adapter.UpdateCommand.Parameters[7].Value = (object) DBNull.Value;
      if (FechaFin.HasValue)
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) FechaFin.Value;
      else
        this.Adapter.UpdateCommand.Parameters[8].Value = (object) DBNull.Value;
      if (IdUsuarioAlta.HasValue)
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) IdUsuarioAlta.Value;
      else
        this.Adapter.UpdateCommand.Parameters[9].Value = (object) DBNull.Value;
      if (FechaAlta.HasValue)
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) FechaAlta.Value;
      else
        this.Adapter.UpdateCommand.Parameters[10].Value = (object) DBNull.Value;
      if (IdUsuarioModificacion.HasValue)
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) IdUsuarioModificacion.Value;
      else
        this.Adapter.UpdateCommand.Parameters[11].Value = (object) DBNull.Value;
      if (FechaModificacion.HasValue)
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) FechaModificacion.Value;
      else
        this.Adapter.UpdateCommand.Parameters[12].Value = (object) DBNull.Value;
      if (Activo.HasValue)
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) Activo.Value;
      else
        this.Adapter.UpdateCommand.Parameters[13].Value = (object) DBNull.Value;
      if (UserProject1 == null)
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[14].Value = (object) UserProject1;
      if (UserProject2 == null)
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[15].Value = (object) UserProject2;
      if (UserProject3 == null)
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[16].Value = (object) UserProject3;
      if (UserProject4 == null)
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[17].Value = (object) UserProject4;
      if (IdCotizacion == null)
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[18].Value = (object) IdCotizacion;
      if (CostoCotizacion.HasValue)
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) CostoCotizacion.Value;
      else
        this.Adapter.UpdateCommand.Parameters[19].Value = (object) DBNull.Value;
      if (FechaTermino.HasValue)
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) FechaTermino.Value;
      else
        this.Adapter.UpdateCommand.Parameters[20].Value = (object) DBNull.Value;
      if (EstatusDesc == null)
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[21].Value = (object) EstatusDesc;
      if (NombreOC == null)
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[22].Value = (object) NombreOC;
      if (ArchivoOC == null)
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[23].Value = (object) ArchivoOC;
      if (NombreCL == null)
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[24].Value = (object) NombreCL;
      if (ArchivoCL == null)
        this.Adapter.UpdateCommand.Parameters[25].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[25].Value = (object) ArchivoCL;
      if (NombreFC == null)
        this.Adapter.UpdateCommand.Parameters[26].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[26].Value = (object) NombreFC;
      if (ArchivoFC == null)
        this.Adapter.UpdateCommand.Parameters[27].Value = (object) DBNull.Value;
      else
        this.Adapter.UpdateCommand.Parameters[27].Value = (object) ArchivoFC;
      if (CostoMOCotizado.HasValue)
        this.Adapter.UpdateCommand.Parameters[28].Value = (object) CostoMOCotizado.Value;
      else
        this.Adapter.UpdateCommand.Parameters[28].Value = (object) DBNull.Value;
      if (CostoMaterialCotizado.HasValue)
        this.Adapter.UpdateCommand.Parameters[29].Value = (object) CostoMaterialCotizado.Value;
      else
        this.Adapter.UpdateCommand.Parameters[29].Value = (object) DBNull.Value;
      if (CostoMECotizado.HasValue)
        this.Adapter.UpdateCommand.Parameters[30].Value = (object) CostoMECotizado.Value;
      else
        this.Adapter.UpdateCommand.Parameters[30].Value = (object) DBNull.Value;
      if (CostoMOProyectado.HasValue)
        this.Adapter.UpdateCommand.Parameters[31].Value = (object) CostoMOProyectado.Value;
      else
        this.Adapter.UpdateCommand.Parameters[31].Value = (object) DBNull.Value;
      if (CostoMaterialProyectado.HasValue)
        this.Adapter.UpdateCommand.Parameters[32].Value = (object) CostoMaterialProyectado.Value;
      else
        this.Adapter.UpdateCommand.Parameters[32].Value = (object) DBNull.Value;
      if (CostoMEProyectado.HasValue)
        this.Adapter.UpdateCommand.Parameters[33].Value = (object) CostoMEProyectado.Value;
      else
        this.Adapter.UpdateCommand.Parameters[33].Value = (object) DBNull.Value;
      this.Adapter.UpdateCommand.Parameters[34].Value = (object) Original_IdProyecto;
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
      string FolioProyecto,
      string NombreProyecto,
      string Descripcion,
      string IdLider,
      string IdCliente,
      string Estatus,
      DateTime? FechaInicio,
      DateTime? FechaFin,
      Guid? IdUsuarioAlta,
      DateTime? FechaAlta,
      Guid? IdUsuarioModificacion,
      DateTime? FechaModificacion,
      int? Activo,
      string UserProject1,
      string UserProject2,
      string UserProject3,
      string UserProject4,
      string IdCotizacion,
      Decimal? CostoCotizacion,
      DateTime? FechaTermino,
      string EstatusDesc,
      string NombreOC,
      string ArchivoOC,
      string NombreCL,
      string ArchivoCL,
      string NombreFC,
      string ArchivoFC,
      double? CostoMOCotizado,
      double? CostoMaterialCotizado,
      double? CostoMECotizado,
      double? CostoMOProyectado,
      double? CostoMaterialProyectado,
      double? CostoMEProyectado,
      Guid Original_IdProyecto)
    {
      return this.Update(Original_IdProyecto, FolioProyecto, NombreProyecto, Descripcion, IdLider, IdCliente, Estatus, FechaInicio, FechaFin, IdUsuarioAlta, FechaAlta, IdUsuarioModificacion, FechaModificacion, Activo, UserProject1, UserProject2, UserProject3, UserProject4, IdCotizacion, CostoCotizacion, FechaTermino, EstatusDesc, NombreOC, ArchivoOC, NombreCL, ArchivoCL, NombreFC, ArchivoFC, CostoMOCotizado, CostoMaterialCotizado, CostoMECotizado, CostoMOProyectado, CostoMaterialProyectado, CostoMEProyectado, Original_IdProyecto);
    }
  }
}
