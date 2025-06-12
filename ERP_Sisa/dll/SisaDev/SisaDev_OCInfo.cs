// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDev_OCInfo
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
  [XmlRoot("SisaDev_OCInfo")]
  [HelpKeyword("vs.data.DataSet")]
  [Serializable]
  public class SisaDev_OCInfo : DataSet
  {
    private SisaDev_OCInfo.sp_GeneraReporteOCInfoDataTable tablesp_GeneraReporteOCInfo;
    private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public SisaDev_OCInfo()
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
    protected SisaDev_OCInfo(SerializationInfo info, StreamingContext context)
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
          if (dataSet.Tables[nameof (sp_GeneraReporteOCInfo)] != null)
            base.Tables.Add((DataTable) new SisaDev_OCInfo.sp_GeneraReporteOCInfoDataTable(dataSet.Tables[nameof (sp_GeneraReporteOCInfo)]));
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
    public SisaDev_OCInfo.sp_GeneraReporteOCInfoDataTable sp_GeneraReporteOCInfo => this.tablesp_GeneraReporteOCInfo;

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
      SisaDev_OCInfo sisaDevOcInfo = (SisaDev_OCInfo) base.Clone();
      sisaDevOcInfo.InitVars();
      sisaDevOcInfo.SchemaSerializationMode = this.SchemaSerializationMode;
      return (DataSet) sisaDevOcInfo;
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
        if (dataSet.Tables["sp_GeneraReporteOCInfo"] != null)
          base.Tables.Add((DataTable) new SisaDev_OCInfo.sp_GeneraReporteOCInfoDataTable(dataSet.Tables["sp_GeneraReporteOCInfo"]));
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
      this.tablesp_GeneraReporteOCInfo = (SisaDev_OCInfo.sp_GeneraReporteOCInfoDataTable) base.Tables["sp_GeneraReporteOCInfo"];
      if (!initTable || this.tablesp_GeneraReporteOCInfo == null)
        return;
      this.tablesp_GeneraReporteOCInfo.InitVars();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private void InitClass()
    {
      this.DataSetName = nameof (SisaDev_OCInfo);
      this.Prefix = "";
      this.Namespace = "http://tempuri.org/SisaDev_OCInfo.xsd";
      this.EnforceConstraints = true;
      this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      this.tablesp_GeneraReporteOCInfo = new SisaDev_OCInfo.sp_GeneraReporteOCInfoDataTable();
      base.Tables.Add((DataTable) this.tablesp_GeneraReporteOCInfo);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializesp_GeneraReporteOCInfo() => false;

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
      SisaDev_OCInfo sisaDevOcInfo = new SisaDev_OCInfo();
      XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
      XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
      xmlSchemaSequence.Items.Add((XmlSchemaObject) new XmlSchemaAny()
      {
        Namespace = sisaDevOcInfo.Namespace
      });
      schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
      XmlSchema schemaSerializable = sisaDevOcInfo.GetSchemaSerializable();
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
    public delegate void sp_GeneraReporteOCInfoRowChangeEventHandler(
      object sender,
      SisaDev_OCInfo.sp_GeneraReporteOCInfoRowChangeEvent e);

    [XmlSchemaProvider("GetTypedTableSchema")]
    [Serializable]
    public class sp_GeneraReporteOCInfoDataTable : 
      TypedTableBase<SisaDev_OCInfo.sp_GeneraReporteOCInfoRow>
    {
      private DataColumn columnidSucursa;
      private DataColumn columnDireccionSucursal;
      private DataColumn columnTelefono;
      private DataColumn columnNombreCompleto;
      private DataColumn columnCiudadSucursal;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public sp_GeneraReporteOCInfoDataTable()
      {
        this.TableName = "sp_GeneraReporteOCInfo";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal sp_GeneraReporteOCInfoDataTable(DataTable table)
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
      protected sp_GeneraReporteOCInfoDataTable(SerializationInfo info, StreamingContext context)
        : base(info, context)
      {
        this.InitVars();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn idSucursaColumn => this.columnidSucursa;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn DireccionSucursalColumn => this.columnDireccionSucursal;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn TelefonoColumn => this.columnTelefono;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn NombreCompletoColumn => this.columnNombreCompleto;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CiudadSucursalColumn => this.columnCiudadSucursal;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_OCInfo.sp_GeneraReporteOCInfoRow this[int index] => (SisaDev_OCInfo.sp_GeneraReporteOCInfoRow) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_OCInfo.sp_GeneraReporteOCInfoRowChangeEventHandler sp_GeneraReporteOCInfoRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_OCInfo.sp_GeneraReporteOCInfoRowChangeEventHandler sp_GeneraReporteOCInfoRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_OCInfo.sp_GeneraReporteOCInfoRowChangeEventHandler sp_GeneraReporteOCInfoRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_OCInfo.sp_GeneraReporteOCInfoRowChangeEventHandler sp_GeneraReporteOCInfoRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void Addsp_GeneraReporteOCInfoRow(SisaDev_OCInfo.sp_GeneraReporteOCInfoRow row) => this.Rows.Add((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_OCInfo.sp_GeneraReporteOCInfoRow Addsp_GeneraReporteOCInfoRow(
        Guid idSucursa,
        string DireccionSucursal,
        string Telefono,
        string NombreCompleto,
        string CiudadSucursal)
      {
        SisaDev_OCInfo.sp_GeneraReporteOCInfoRow reporteOcInfoRow = (SisaDev_OCInfo.sp_GeneraReporteOCInfoRow) this.NewRow();
        object[] objArray = new object[5]
        {
          (object) idSucursa,
          (object) DireccionSucursal,
          (object) Telefono,
          (object) NombreCompleto,
          (object) CiudadSucursal
        };
        reporteOcInfoRow.ItemArray = objArray;
        this.Rows.Add((DataRow) reporteOcInfoRow);
        return reporteOcInfoRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_OCInfo.sp_GeneraReporteOCInfoRow FindByidSucursa(Guid idSucursa) => (SisaDev_OCInfo.sp_GeneraReporteOCInfoRow) this.Rows.Find(new object[1]
      {
        (object) idSucursa
      });

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        SisaDev_OCInfo.sp_GeneraReporteOCInfoDataTable reporteOcInfoDataTable = (SisaDev_OCInfo.sp_GeneraReporteOCInfoDataTable) base.Clone();
        reporteOcInfoDataTable.InitVars();
        return (DataTable) reporteOcInfoDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new SisaDev_OCInfo.sp_GeneraReporteOCInfoDataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnidSucursa = this.Columns["idSucursa"];
        this.columnDireccionSucursal = this.Columns["DireccionSucursal"];
        this.columnTelefono = this.Columns["Telefono"];
        this.columnNombreCompleto = this.Columns["NombreCompleto"];
        this.columnCiudadSucursal = this.Columns["CiudadSucursal"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnidSucursa = new DataColumn("idSucursa", typeof (Guid), (string) null, MappingType.Element);
        this.Columns.Add(this.columnidSucursa);
        this.columnDireccionSucursal = new DataColumn("DireccionSucursal", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDireccionSucursal);
        this.columnTelefono = new DataColumn("Telefono", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTelefono);
        this.columnNombreCompleto = new DataColumn("NombreCompleto", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNombreCompleto);
        this.columnCiudadSucursal = new DataColumn("CiudadSucursal", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCiudadSucursal);
        this.Constraints.Add((Constraint) new UniqueConstraint("Constraint1", new DataColumn[1]
        {
          this.columnidSucursa
        }, true));
        this.columnidSucursa.AllowDBNull = false;
        this.columnidSucursa.Unique = true;
        this.columnDireccionSucursal.AllowDBNull = false;
        this.columnDireccionSucursal.MaxLength = 250;
        this.columnTelefono.MaxLength = 50;
        this.columnNombreCompleto.MaxLength = 100;
        this.columnCiudadSucursal.AllowDBNull = false;
        this.columnCiudadSucursal.MaxLength = 50;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_OCInfo.sp_GeneraReporteOCInfoRow Newsp_GeneraReporteOCInfoRow() => (SisaDev_OCInfo.sp_GeneraReporteOCInfoRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new SisaDev_OCInfo.sp_GeneraReporteOCInfoRow(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (SisaDev_OCInfo.sp_GeneraReporteOCInfoRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.sp_GeneraReporteOCInfoRowChanged == null)
          return;
        this.sp_GeneraReporteOCInfoRowChanged((object) this, new SisaDev_OCInfo.sp_GeneraReporteOCInfoRowChangeEvent((SisaDev_OCInfo.sp_GeneraReporteOCInfoRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.sp_GeneraReporteOCInfoRowChanging == null)
          return;
        this.sp_GeneraReporteOCInfoRowChanging((object) this, new SisaDev_OCInfo.sp_GeneraReporteOCInfoRowChangeEvent((SisaDev_OCInfo.sp_GeneraReporteOCInfoRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.sp_GeneraReporteOCInfoRowDeleted == null)
          return;
        this.sp_GeneraReporteOCInfoRowDeleted((object) this, new SisaDev_OCInfo.sp_GeneraReporteOCInfoRowChangeEvent((SisaDev_OCInfo.sp_GeneraReporteOCInfoRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.sp_GeneraReporteOCInfoRowDeleting == null)
          return;
        this.sp_GeneraReporteOCInfoRowDeleting((object) this, new SisaDev_OCInfo.sp_GeneraReporteOCInfoRowChangeEvent((SisaDev_OCInfo.sp_GeneraReporteOCInfoRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void Removesp_GeneraReporteOCInfoRow(SisaDev_OCInfo.sp_GeneraReporteOCInfoRow row) => this.Rows.Remove((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        SisaDev_OCInfo sisaDevOcInfo = new SisaDev_OCInfo();
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
          FixedValue = sisaDevOcInfo.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (sp_GeneraReporteOCInfoDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = sisaDevOcInfo.GetSchemaSerializable();
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

    public class sp_GeneraReporteOCInfoRow : DataRow
    {
      private SisaDev_OCInfo.sp_GeneraReporteOCInfoDataTable tablesp_GeneraReporteOCInfo;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal sp_GeneraReporteOCInfoRow(DataRowBuilder rb)
        : base(rb)
      {
        this.tablesp_GeneraReporteOCInfo = (SisaDev_OCInfo.sp_GeneraReporteOCInfoDataTable) this.Table;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Guid idSucursa
      {
        get => (Guid) this[this.tablesp_GeneraReporteOCInfo.idSucursaColumn];
        set => this[this.tablesp_GeneraReporteOCInfo.idSucursaColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string DireccionSucursal
      {
        get => (string) this[this.tablesp_GeneraReporteOCInfo.DireccionSucursalColumn];
        set => this[this.tablesp_GeneraReporteOCInfo.DireccionSucursalColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Telefono
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_GeneraReporteOCInfo.TelefonoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Telefono' de la tabla 'sp_GeneraReporteOCInfo' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_GeneraReporteOCInfo.TelefonoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string NombreCompleto
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_GeneraReporteOCInfo.NombreCompletoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'NombreCompleto' de la tabla 'sp_GeneraReporteOCInfo' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_GeneraReporteOCInfo.NombreCompletoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string CiudadSucursal
      {
        get => (string) this[this.tablesp_GeneraReporteOCInfo.CiudadSucursalColumn];
        set => this[this.tablesp_GeneraReporteOCInfo.CiudadSucursalColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsTelefonoNull() => this.IsNull(this.tablesp_GeneraReporteOCInfo.TelefonoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetTelefonoNull() => this[this.tablesp_GeneraReporteOCInfo.TelefonoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNombreCompletoNull() => this.IsNull(this.tablesp_GeneraReporteOCInfo.NombreCompletoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNombreCompletoNull() => this[this.tablesp_GeneraReporteOCInfo.NombreCompletoColumn] = Convert.DBNull;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class sp_GeneraReporteOCInfoRowChangeEvent : EventArgs
    {
      private SisaDev_OCInfo.sp_GeneraReporteOCInfoRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public sp_GeneraReporteOCInfoRowChangeEvent(
        SisaDev_OCInfo.sp_GeneraReporteOCInfoRow row,
        DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_OCInfo.sp_GeneraReporteOCInfoRow Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }
  }
}
