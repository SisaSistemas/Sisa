// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDev_Proyecto
// Assembly: SisaDev, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E70D772F-2E61-4F6B-8371-8519ED629E68
// Assembly location: \\Mac\Home\Documents\SisaDev.dll

using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace SisaDev
{
  [DesignerCategory("code")]
  [ToolboxItem(true)]
  [XmlSchemaProvider("GetTypedDataSetSchema")]
  [XmlRoot("SisaDev_Proyecto")]
  [HelpKeyword("vs.data.DataSet")]
  [Serializable]
  public class SisaDev_Proyecto : DataSet
  {
    private SisaDev_Proyecto.sp_AdministracionDataTable tablesp_Administracion;
    private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public SisaDev_Proyecto()
    {
      this.BeginInit();
      this.InitClass();
      CollectionChangeEventHandler changeEventHandler = new CollectionChangeEventHandler(this.SchemaChanged);
      base.Tables.CollectionChanged += changeEventHandler;
      base.Relations.CollectionChanged += changeEventHandler;
      this.EndInit();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    protected SisaDev_Proyecto(SerializationInfo info, StreamingContext context)
      : base(info, context, false)
    {
      if (this.IsBinarySerialized(info, context))
      {
        this.InitVars(false);
        CollectionChangeEventHandler changeEventHandler = new CollectionChangeEventHandler(this.SchemaChanged);
        this.Tables.CollectionChanged += changeEventHandler;
        this.Relations.CollectionChanged += changeEventHandler;
      }
      else
      {
        string s = (string) info.GetValue("XmlSchema", typeof (string));
        if (this.DetermineSchemaSerializationMode(info, context) == SchemaSerializationMode.IncludeSchema)
        {
          DataSet dataSet = new DataSet();
          dataSet.ReadXmlSchema((XmlReader) new XmlTextReader((TextReader) new StringReader(s)));
          if (dataSet.Tables[nameof (sp_Administracion)] != null)
            base.Tables.Add((DataTable) new SisaDev_Proyecto.sp_AdministracionDataTable(dataSet.Tables[nameof (sp_Administracion)]));
          this.DataSetName = dataSet.DataSetName;
          this.Prefix = dataSet.Prefix;
          this.Namespace = dataSet.Namespace;
          this.Locale = dataSet.Locale;
          this.CaseSensitive = dataSet.CaseSensitive;
          this.EnforceConstraints = dataSet.EnforceConstraints;
          this.Merge(dataSet, false, MissingSchemaAction.Add);
          this.InitVars();
        }
        else
          this.ReadXmlSchema((XmlReader) new XmlTextReader((TextReader) new StringReader(s)));
        this.GetSerializationData(info, context);
        CollectionChangeEventHandler changeEventHandler = new CollectionChangeEventHandler(this.SchemaChanged);
        base.Tables.CollectionChanged += changeEventHandler;
        this.Relations.CollectionChanged += changeEventHandler;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public SisaDev_Proyecto.sp_AdministracionDataTable sp_Administracion => this.tablesp_Administracion;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public override SchemaSerializationMode SchemaSerializationMode
    {
      get => this._schemaSerializationMode;
      set => this._schemaSerializationMode = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new DataTableCollection Tables => base.Tables;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new DataRelationCollection Relations => base.Relations;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    protected override void InitializeDerivedDataSet()
    {
      this.BeginInit();
      this.InitClass();
      this.EndInit();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public override DataSet Clone()
    {
      SisaDev_Proyecto sisaDevProyecto = (SisaDev_Proyecto) base.Clone();
      sisaDevProyecto.InitVars();
      sisaDevProyecto.SchemaSerializationMode = this.SchemaSerializationMode;
      return (DataSet) sisaDevProyecto;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    protected override bool ShouldSerializeTables() => false;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    protected override bool ShouldSerializeRelations() => false;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    protected override void ReadXmlSerializable(XmlReader reader)
    {
      if (this.DetermineSchemaSerializationMode(reader) == SchemaSerializationMode.IncludeSchema)
      {
        this.Reset();
        DataSet dataSet = new DataSet();
        int num = (int) dataSet.ReadXml(reader);
        if (dataSet.Tables["sp_Administracion"] != null)
          base.Tables.Add((DataTable) new SisaDev_Proyecto.sp_AdministracionDataTable(dataSet.Tables["sp_Administracion"]));
        this.DataSetName = dataSet.DataSetName;
        this.Prefix = dataSet.Prefix;
        this.Namespace = dataSet.Namespace;
        this.Locale = dataSet.Locale;
        this.CaseSensitive = dataSet.CaseSensitive;
        this.EnforceConstraints = dataSet.EnforceConstraints;
        this.Merge(dataSet, false, MissingSchemaAction.Add);
        this.InitVars();
      }
      else
      {
        int num = (int) this.ReadXml(reader);
        this.InitVars();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    protected override XmlSchema GetSchemaSerializable()
    {
      MemoryStream memoryStream = new MemoryStream();
      this.WriteXmlSchema((XmlWriter) new XmlTextWriter((Stream) memoryStream, (Encoding) null));
      memoryStream.Position = 0L;
      return XmlSchema.Read((XmlReader) new XmlTextReader((Stream) memoryStream), (ValidationEventHandler) null);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    internal void InitVars() => this.InitVars(true);

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    internal void InitVars(bool initTable)
    {
      this.tablesp_Administracion = (SisaDev_Proyecto.sp_AdministracionDataTable) base.Tables["sp_Administracion"];
      if (!initTable || this.tablesp_Administracion == null)
        return;
      this.tablesp_Administracion.InitVars();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private void InitClass()
    {
      this.DataSetName = nameof (SisaDev_Proyecto);
      this.Prefix = "";
      this.Namespace = "http://tempuri.org/SisaDev_Proyecto.xsd";
      this.EnforceConstraints = true;
      this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      this.tablesp_Administracion = new SisaDev_Proyecto.sp_AdministracionDataTable();
      base.Tables.Add((DataTable) this.tablesp_Administracion);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializesp_Administracion() => false;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private void SchemaChanged(object sender, CollectionChangeEventArgs e)
    {
      if (e.Action != CollectionChangeAction.Remove)
        return;
      this.InitVars();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public static XmlSchemaComplexType GetTypedDataSetSchema(XmlSchemaSet xs)
    {
      SisaDev_Proyecto sisaDevProyecto = new SisaDev_Proyecto();
      XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
      XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
      xmlSchemaSequence.Items.Add((XmlSchemaObject) new XmlSchemaAny()
      {
        Namespace = sisaDevProyecto.Namespace
      });
      schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
      XmlSchema schemaSerializable = sisaDevProyecto.GetSchemaSerializable();
      if (xs.Contains(schemaSerializable.TargetNamespace))
      {
        MemoryStream memoryStream1 = new MemoryStream();
        MemoryStream memoryStream2 = new MemoryStream();
        try
        {
          schemaSerializable.Write((Stream) memoryStream1);
          IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
          while (enumerator.MoveNext())
          {
            XmlSchema current = (XmlSchema) enumerator.Current;
            memoryStream2.SetLength(0L);
            current.Write((Stream) memoryStream2);
            if (memoryStream1.Length == memoryStream2.Length)
            {
              memoryStream1.Position = 0L;
              memoryStream2.Position = 0L;
              do
                ;
              while (memoryStream1.Position != memoryStream1.Length && memoryStream1.ReadByte() == memoryStream2.ReadByte());
              if (memoryStream1.Position == memoryStream1.Length)
                return schemaComplexType;
            }
          }
        }
        finally
        {
          memoryStream1?.Close();
          memoryStream2?.Close();
        }
      }
      xs.Add(schemaSerializable);
      return schemaComplexType;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public delegate void sp_AdministracionRowChangeEventHandler(
      object sender,
      SisaDev_Proyecto.sp_AdministracionRowChangeEvent e);

    [XmlSchemaProvider("GetTypedTableSchema")]
    [Serializable]
    public class sp_AdministracionDataTable : TypedTableBase<SisaDev_Proyecto.sp_AdministracionRow>
    {
      private DataColumn columnID;
      private DataColumn columnFolioProyecto;
      private DataColumn columnNombreProyecto;
      private DataColumn columnContactoCliente;
      private DataColumn columnCliente;
      private DataColumn columnLiderProyecto;
      private DataColumn columnFechaInicio;
      private DataColumn columnFechaFin;
      private DataColumn columnOC;
      private DataColumn columnCL;
      private DataColumn columnFC;
      private DataColumn columnIdProyecto;
      private DataColumn columnEstatus;
      private DataColumn columnFacturado;
      private DataColumn columnPorcentaje;
      private DataColumn columnPagado;
      private DataColumn columnPorcentajePagado;
      private DataColumn columnEstatusDesc;
      private DataColumn columnIdUsuario;
      private DataColumn columnIdUsuarioAlta;
      private DataColumn columnCostoMaterialProyectado;
      private DataColumn columnCostoMOProyectado;
      private DataColumn columnCostoMEProyectado;
      private DataColumn columnFechaAlta;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public sp_AdministracionDataTable()
      {
        this.TableName = "sp_Administracion";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal sp_AdministracionDataTable(DataTable table)
      {
        this.TableName = table.TableName;
        if (table.CaseSensitive != table.DataSet.CaseSensitive)
          this.CaseSensitive = table.CaseSensitive;
        if (table.Locale.ToString() != table.DataSet.Locale.ToString())
          this.Locale = table.Locale;
        if (table.Namespace != table.DataSet.Namespace)
          this.Namespace = table.Namespace;
        this.Prefix = table.Prefix;
        this.MinimumCapacity = table.MinimumCapacity;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected sp_AdministracionDataTable(SerializationInfo info, StreamingContext context)
        : base(info, context)
      {
        this.InitVars();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn IDColumn => this.columnID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FolioProyectoColumn => this.columnFolioProyecto;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn NombreProyectoColumn => this.columnNombreProyecto;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ContactoClienteColumn => this.columnContactoCliente;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ClienteColumn => this.columnCliente;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn LiderProyectoColumn => this.columnLiderProyecto;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FechaInicioColumn => this.columnFechaInicio;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FechaFinColumn => this.columnFechaFin;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn OCColumn => this.columnOC;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CLColumn => this.columnCL;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FCColumn => this.columnFC;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn IdProyectoColumn => this.columnIdProyecto;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn EstatusColumn => this.columnEstatus;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FacturadoColumn => this.columnFacturado;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn PorcentajeColumn => this.columnPorcentaje;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn PagadoColumn => this.columnPagado;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn PorcentajePagadoColumn => this.columnPorcentajePagado;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn EstatusDescColumn => this.columnEstatusDesc;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn IdUsuarioColumn => this.columnIdUsuario;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn IdUsuarioAltaColumn => this.columnIdUsuarioAlta;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CostoMaterialProyectadoColumn => this.columnCostoMaterialProyectado;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CostoMOProyectadoColumn => this.columnCostoMOProyectado;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CostoMEProyectadoColumn => this.columnCostoMEProyectado;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FechaAltaColumn => this.columnFechaAlta;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_Proyecto.sp_AdministracionRow this[int index] => (SisaDev_Proyecto.sp_AdministracionRow) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_Proyecto.sp_AdministracionRowChangeEventHandler sp_AdministracionRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_Proyecto.sp_AdministracionRowChangeEventHandler sp_AdministracionRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_Proyecto.sp_AdministracionRowChangeEventHandler sp_AdministracionRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_Proyecto.sp_AdministracionRowChangeEventHandler sp_AdministracionRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void Addsp_AdministracionRow(SisaDev_Proyecto.sp_AdministracionRow row) => this.Rows.Add((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_Proyecto.sp_AdministracionRow Addsp_AdministracionRow(
        long ID,
        string FolioProyecto,
        string NombreProyecto,
        string ContactoCliente,
        string Cliente,
        string LiderProyecto,
        DateTime FechaInicio,
        DateTime FechaFin,
        string OC,
        string CL,
        string FC,
        Guid IdProyecto,
        string Estatus,
        Decimal Facturado,
        Decimal Porcentaje,
        Decimal Pagado,
        Decimal PorcentajePagado,
        string EstatusDesc,
        Guid IdUsuario,
        Guid IdUsuarioAlta,
        double CostoMaterialProyectado,
        double CostoMOProyectado,
        double CostoMEProyectado,
        DateTime FechaAlta)
      {
        SisaDev_Proyecto.sp_AdministracionRow administracionRow = (SisaDev_Proyecto.sp_AdministracionRow) this.NewRow();
        object[] objArray = new object[24]
        {
          (object) ID,
          (object) FolioProyecto,
          (object) NombreProyecto,
          (object) ContactoCliente,
          (object) Cliente,
          (object) LiderProyecto,
          (object) FechaInicio,
          (object) FechaFin,
          (object) OC,
          (object) CL,
          (object) FC,
          (object) IdProyecto,
          (object) Estatus,
          (object) Facturado,
          (object) Porcentaje,
          (object) Pagado,
          (object) PorcentajePagado,
          (object) EstatusDesc,
          (object) IdUsuario,
          (object) IdUsuarioAlta,
          (object) CostoMaterialProyectado,
          (object) CostoMOProyectado,
          (object) CostoMEProyectado,
          (object) FechaAlta
        };
        administracionRow.ItemArray = objArray;
        this.Rows.Add((DataRow) administracionRow);
        return administracionRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        SisaDev_Proyecto.sp_AdministracionDataTable administracionDataTable = (SisaDev_Proyecto.sp_AdministracionDataTable) base.Clone();
        administracionDataTable.InitVars();
        return (DataTable) administracionDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new SisaDev_Proyecto.sp_AdministracionDataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnID = this.Columns["ID"];
        this.columnFolioProyecto = this.Columns["FolioProyecto"];
        this.columnNombreProyecto = this.Columns["NombreProyecto"];
        this.columnContactoCliente = this.Columns["ContactoCliente"];
        this.columnCliente = this.Columns["Cliente"];
        this.columnLiderProyecto = this.Columns["LiderProyecto"];
        this.columnFechaInicio = this.Columns["FechaInicio"];
        this.columnFechaFin = this.Columns["FechaFin"];
        this.columnOC = this.Columns["OC"];
        this.columnCL = this.Columns["CL"];
        this.columnFC = this.Columns["FC"];
        this.columnIdProyecto = this.Columns["IdProyecto"];
        this.columnEstatus = this.Columns["Estatus"];
        this.columnFacturado = this.Columns["Facturado"];
        this.columnPorcentaje = this.Columns["Porcentaje"];
        this.columnPagado = this.Columns["Pagado"];
        this.columnPorcentajePagado = this.Columns["PorcentajePagado"];
        this.columnEstatusDesc = this.Columns["EstatusDesc"];
        this.columnIdUsuario = this.Columns["IdUsuario"];
        this.columnIdUsuarioAlta = this.Columns["IdUsuarioAlta"];
        this.columnCostoMaterialProyectado = this.Columns["CostoMaterialProyectado"];
        this.columnCostoMOProyectado = this.Columns["CostoMOProyectado"];
        this.columnCostoMEProyectado = this.Columns["CostoMEProyectado"];
        this.columnFechaAlta = this.Columns["FechaAlta"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnID = new DataColumn("ID", typeof (long), (string) null, MappingType.Element);
        this.Columns.Add(this.columnID);
        this.columnFolioProyecto = new DataColumn("FolioProyecto", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFolioProyecto);
        this.columnNombreProyecto = new DataColumn("NombreProyecto", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNombreProyecto);
        this.columnContactoCliente = new DataColumn("ContactoCliente", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnContactoCliente);
        this.columnCliente = new DataColumn("Cliente", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCliente);
        this.columnLiderProyecto = new DataColumn("LiderProyecto", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnLiderProyecto);
        this.columnFechaInicio = new DataColumn("FechaInicio", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFechaInicio);
        this.columnFechaFin = new DataColumn("FechaFin", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFechaFin);
        this.columnOC = new DataColumn("OC", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnOC);
        this.columnCL = new DataColumn("CL", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCL);
        this.columnFC = new DataColumn("FC", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFC);
        this.columnIdProyecto = new DataColumn("IdProyecto", typeof (Guid), (string) null, MappingType.Element);
        this.Columns.Add(this.columnIdProyecto);
        this.columnEstatus = new DataColumn("Estatus", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEstatus);
        this.columnFacturado = new DataColumn("Facturado", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFacturado);
        this.columnPorcentaje = new DataColumn("Porcentaje", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPorcentaje);
        this.columnPagado = new DataColumn("Pagado", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPagado);
        this.columnPorcentajePagado = new DataColumn("PorcentajePagado", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPorcentajePagado);
        this.columnEstatusDesc = new DataColumn("EstatusDesc", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEstatusDesc);
        this.columnIdUsuario = new DataColumn("IdUsuario", typeof (Guid), (string) null, MappingType.Element);
        this.Columns.Add(this.columnIdUsuario);
        this.columnIdUsuarioAlta = new DataColumn("IdUsuarioAlta", typeof (Guid), (string) null, MappingType.Element);
        this.Columns.Add(this.columnIdUsuarioAlta);
        this.columnCostoMaterialProyectado = new DataColumn("CostoMaterialProyectado", typeof (double), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCostoMaterialProyectado);
        this.columnCostoMOProyectado = new DataColumn("CostoMOProyectado", typeof (double), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCostoMOProyectado);
        this.columnCostoMEProyectado = new DataColumn("CostoMEProyectado", typeof (double), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCostoMEProyectado);
        this.columnFechaAlta = new DataColumn("FechaAlta", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFechaAlta);
        this.columnID.ReadOnly = true;
        this.columnFolioProyecto.MaxLength = 50;
        this.columnNombreProyecto.MaxLength = 100;
        this.columnContactoCliente.MaxLength = 150;
        this.columnCliente.MaxLength = (int) byte.MaxValue;
        this.columnLiderProyecto.ReadOnly = true;
        this.columnLiderProyecto.MaxLength = 100;
        this.columnOC.ReadOnly = true;
        this.columnOC.MaxLength = 150;
        this.columnCL.ReadOnly = true;
        this.columnCL.MaxLength = 150;
        this.columnFC.ReadOnly = true;
        this.columnFC.MaxLength = 150;
        this.columnIdProyecto.AllowDBNull = false;
        this.columnEstatus.MaxLength = 50;
        this.columnFacturado.ReadOnly = true;
        this.columnPorcentaje.ReadOnly = true;
        this.columnPagado.ReadOnly = true;
        this.columnPorcentajePagado.ReadOnly = true;
        this.columnEstatusDesc.ReadOnly = true;
        this.columnEstatusDesc.MaxLength = 100;
        this.columnIdUsuario.AllowDBNull = false;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_Proyecto.sp_AdministracionRow Newsp_AdministracionRow() => (SisaDev_Proyecto.sp_AdministracionRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new SisaDev_Proyecto.sp_AdministracionRow(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (SisaDev_Proyecto.sp_AdministracionRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.sp_AdministracionRowChanged == null)
          return;
        this.sp_AdministracionRowChanged((object) this, new SisaDev_Proyecto.sp_AdministracionRowChangeEvent((SisaDev_Proyecto.sp_AdministracionRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.sp_AdministracionRowChanging == null)
          return;
        this.sp_AdministracionRowChanging((object) this, new SisaDev_Proyecto.sp_AdministracionRowChangeEvent((SisaDev_Proyecto.sp_AdministracionRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.sp_AdministracionRowDeleted == null)
          return;
        this.sp_AdministracionRowDeleted((object) this, new SisaDev_Proyecto.sp_AdministracionRowChangeEvent((SisaDev_Proyecto.sp_AdministracionRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.sp_AdministracionRowDeleting == null)
          return;
        this.sp_AdministracionRowDeleting((object) this, new SisaDev_Proyecto.sp_AdministracionRowChangeEvent((SisaDev_Proyecto.sp_AdministracionRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void Removesp_AdministracionRow(SisaDev_Proyecto.sp_AdministracionRow row) => this.Rows.Remove((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        SisaDev_Proyecto sisaDevProyecto = new SisaDev_Proyecto();
        XmlSchemaAny xmlSchemaAny1 = new XmlSchemaAny();
        xmlSchemaAny1.Namespace = "http://www.w3.org/2001/XMLSchema";
        xmlSchemaAny1.MinOccurs = 0M;
        xmlSchemaAny1.MaxOccurs = Decimal.MaxValue;
        xmlSchemaAny1.ProcessContents = XmlSchemaContentProcessing.Lax;
        xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny1);
        XmlSchemaAny xmlSchemaAny2 = new XmlSchemaAny();
        xmlSchemaAny2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
        xmlSchemaAny2.MinOccurs = 1M;
        xmlSchemaAny2.ProcessContents = XmlSchemaContentProcessing.Lax;
        xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny2);
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "namespace",
          FixedValue = sisaDevProyecto.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (sp_AdministracionDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = sisaDevProyecto.GetSchemaSerializable();
        if (xs.Contains(schemaSerializable.TargetNamespace))
        {
          MemoryStream memoryStream1 = new MemoryStream();
          MemoryStream memoryStream2 = new MemoryStream();
          try
          {
            schemaSerializable.Write((Stream) memoryStream1);
            IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
            while (enumerator.MoveNext())
            {
              XmlSchema current = (XmlSchema) enumerator.Current;
              memoryStream2.SetLength(0L);
              current.Write((Stream) memoryStream2);
              if (memoryStream1.Length == memoryStream2.Length)
              {
                memoryStream1.Position = 0L;
                memoryStream2.Position = 0L;
                do
                  ;
                while (memoryStream1.Position != memoryStream1.Length && memoryStream1.ReadByte() == memoryStream2.ReadByte());
                if (memoryStream1.Position == memoryStream1.Length)
                  return schemaComplexType;
              }
            }
          }
          finally
          {
            memoryStream1?.Close();
            memoryStream2?.Close();
          }
        }
        xs.Add(schemaSerializable);
        return schemaComplexType;
      }
    }

    public class sp_AdministracionRow : DataRow
    {
      private SisaDev_Proyecto.sp_AdministracionDataTable tablesp_Administracion;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal sp_AdministracionRow(DataRowBuilder rb)
        : base(rb)
      {
        this.tablesp_Administracion = (SisaDev_Proyecto.sp_AdministracionDataTable) this.Table;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public long ID
      {
        get
        {
          try
          {
            return (long) this[this.tablesp_Administracion.IDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'ID' de la tabla 'sp_Administracion' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_Administracion.IDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string FolioProyecto
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_Administracion.FolioProyectoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'FolioProyecto' de la tabla 'sp_Administracion' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_Administracion.FolioProyectoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string NombreProyecto
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_Administracion.NombreProyectoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'NombreProyecto' de la tabla 'sp_Administracion' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_Administracion.NombreProyectoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string ContactoCliente
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_Administracion.ContactoClienteColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'ContactoCliente' de la tabla 'sp_Administracion' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_Administracion.ContactoClienteColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Cliente
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_Administracion.ClienteColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Cliente' de la tabla 'sp_Administracion' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_Administracion.ClienteColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string LiderProyecto
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_Administracion.LiderProyectoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'LiderProyecto' de la tabla 'sp_Administracion' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_Administracion.LiderProyectoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DateTime FechaInicio
      {
        get
        {
          try
          {
            return (DateTime) this[this.tablesp_Administracion.FechaInicioColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'FechaInicio' de la tabla 'sp_Administracion' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_Administracion.FechaInicioColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DateTime FechaFin
      {
        get
        {
          try
          {
            return (DateTime) this[this.tablesp_Administracion.FechaFinColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'FechaFin' de la tabla 'sp_Administracion' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_Administracion.FechaFinColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string OC
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_Administracion.OCColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'OC' de la tabla 'sp_Administracion' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_Administracion.OCColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string CL
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_Administracion.CLColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'CL' de la tabla 'sp_Administracion' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_Administracion.CLColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string FC
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_Administracion.FCColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'FC' de la tabla 'sp_Administracion' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_Administracion.FCColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Guid IdProyecto
      {
        get => (Guid) this[this.tablesp_Administracion.IdProyectoColumn];
        set => this[this.tablesp_Administracion.IdProyectoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Estatus
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_Administracion.EstatusColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Estatus' de la tabla 'sp_Administracion' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_Administracion.EstatusColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal Facturado
      {
        get
        {
          try
          {
            return (Decimal) this[this.tablesp_Administracion.FacturadoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Facturado' de la tabla 'sp_Administracion' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_Administracion.FacturadoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal Porcentaje
      {
        get
        {
          try
          {
            return (Decimal) this[this.tablesp_Administracion.PorcentajeColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Porcentaje' de la tabla 'sp_Administracion' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_Administracion.PorcentajeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal Pagado
      {
        get
        {
          try
          {
            return (Decimal) this[this.tablesp_Administracion.PagadoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Pagado' de la tabla 'sp_Administracion' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_Administracion.PagadoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal PorcentajePagado
      {
        get
        {
          try
          {
            return (Decimal) this[this.tablesp_Administracion.PorcentajePagadoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'PorcentajePagado' de la tabla 'sp_Administracion' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_Administracion.PorcentajePagadoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string EstatusDesc
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_Administracion.EstatusDescColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'EstatusDesc' de la tabla 'sp_Administracion' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_Administracion.EstatusDescColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Guid IdUsuario
      {
        get => (Guid) this[this.tablesp_Administracion.IdUsuarioColumn];
        set => this[this.tablesp_Administracion.IdUsuarioColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Guid IdUsuarioAlta
      {
        get
        {
          try
          {
            return (Guid) this[this.tablesp_Administracion.IdUsuarioAltaColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'IdUsuarioAlta' de la tabla 'sp_Administracion' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_Administracion.IdUsuarioAltaColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public double CostoMaterialProyectado
      {
        get
        {
          try
          {
            return (double) this[this.tablesp_Administracion.CostoMaterialProyectadoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'CostoMaterialProyectado' de la tabla 'sp_Administracion' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_Administracion.CostoMaterialProyectadoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public double CostoMOProyectado
      {
        get
        {
          try
          {
            return (double) this[this.tablesp_Administracion.CostoMOProyectadoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'CostoMOProyectado' de la tabla 'sp_Administracion' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_Administracion.CostoMOProyectadoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public double CostoMEProyectado
      {
        get
        {
          try
          {
            return (double) this[this.tablesp_Administracion.CostoMEProyectadoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'CostoMEProyectado' de la tabla 'sp_Administracion' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_Administracion.CostoMEProyectadoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DateTime FechaAlta
      {
        get
        {
          try
          {
            return (DateTime) this[this.tablesp_Administracion.FechaAltaColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'FechaAlta' de la tabla 'sp_Administracion' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_Administracion.FechaAltaColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsIDNull() => this.IsNull(this.tablesp_Administracion.IDColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetIDNull() => this[this.tablesp_Administracion.IDColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFolioProyectoNull() => this.IsNull(this.tablesp_Administracion.FolioProyectoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFolioProyectoNull() => this[this.tablesp_Administracion.FolioProyectoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNombreProyectoNull() => this.IsNull(this.tablesp_Administracion.NombreProyectoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNombreProyectoNull() => this[this.tablesp_Administracion.NombreProyectoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsContactoClienteNull() => this.IsNull(this.tablesp_Administracion.ContactoClienteColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetContactoClienteNull() => this[this.tablesp_Administracion.ContactoClienteColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsClienteNull() => this.IsNull(this.tablesp_Administracion.ClienteColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetClienteNull() => this[this.tablesp_Administracion.ClienteColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsLiderProyectoNull() => this.IsNull(this.tablesp_Administracion.LiderProyectoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetLiderProyectoNull() => this[this.tablesp_Administracion.LiderProyectoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFechaInicioNull() => this.IsNull(this.tablesp_Administracion.FechaInicioColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFechaInicioNull() => this[this.tablesp_Administracion.FechaInicioColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFechaFinNull() => this.IsNull(this.tablesp_Administracion.FechaFinColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFechaFinNull() => this[this.tablesp_Administracion.FechaFinColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsOCNull() => this.IsNull(this.tablesp_Administracion.OCColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetOCNull() => this[this.tablesp_Administracion.OCColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCLNull() => this.IsNull(this.tablesp_Administracion.CLColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCLNull() => this[this.tablesp_Administracion.CLColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFCNull() => this.IsNull(this.tablesp_Administracion.FCColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFCNull() => this[this.tablesp_Administracion.FCColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsEstatusNull() => this.IsNull(this.tablesp_Administracion.EstatusColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetEstatusNull() => this[this.tablesp_Administracion.EstatusColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFacturadoNull() => this.IsNull(this.tablesp_Administracion.FacturadoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFacturadoNull() => this[this.tablesp_Administracion.FacturadoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPorcentajeNull() => this.IsNull(this.tablesp_Administracion.PorcentajeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPorcentajeNull() => this[this.tablesp_Administracion.PorcentajeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPagadoNull() => this.IsNull(this.tablesp_Administracion.PagadoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPagadoNull() => this[this.tablesp_Administracion.PagadoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPorcentajePagadoNull() => this.IsNull(this.tablesp_Administracion.PorcentajePagadoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPorcentajePagadoNull() => this[this.tablesp_Administracion.PorcentajePagadoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsEstatusDescNull() => this.IsNull(this.tablesp_Administracion.EstatusDescColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetEstatusDescNull() => this[this.tablesp_Administracion.EstatusDescColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsIdUsuarioAltaNull() => this.IsNull(this.tablesp_Administracion.IdUsuarioAltaColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetIdUsuarioAltaNull() => this[this.tablesp_Administracion.IdUsuarioAltaColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCostoMaterialProyectadoNull() => this.IsNull(this.tablesp_Administracion.CostoMaterialProyectadoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCostoMaterialProyectadoNull() => this[this.tablesp_Administracion.CostoMaterialProyectadoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCostoMOProyectadoNull() => this.IsNull(this.tablesp_Administracion.CostoMOProyectadoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCostoMOProyectadoNull() => this[this.tablesp_Administracion.CostoMOProyectadoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCostoMEProyectadoNull() => this.IsNull(this.tablesp_Administracion.CostoMEProyectadoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCostoMEProyectadoNull() => this[this.tablesp_Administracion.CostoMEProyectadoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFechaAltaNull() => this.IsNull(this.tablesp_Administracion.FechaAltaColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFechaAltaNull() => this[this.tablesp_Administracion.FechaAltaColumn] = Convert.DBNull;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class sp_AdministracionRowChangeEvent : EventArgs
    {
      private SisaDev_Proyecto.sp_AdministracionRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public sp_AdministracionRowChangeEvent(
        SisaDev_Proyecto.sp_AdministracionRow row,
        DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_Proyecto.sp_AdministracionRow Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }
  }
}
