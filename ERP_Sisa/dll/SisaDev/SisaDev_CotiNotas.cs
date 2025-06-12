// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDev_CotiNotas
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
  [XmlRoot("SisaDev_CotiNotas")]
  [HelpKeyword("vs.data.DataSet")]
  [Serializable]
  public class SisaDev_CotiNotas : DataSet
  {
    private SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasDataTable tablesp_CargarCotizacionesReporteNotasAclaratorias;
    private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public SisaDev_CotiNotas()
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
    protected SisaDev_CotiNotas(SerializationInfo info, StreamingContext context)
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
          if (dataSet.Tables[nameof (sp_CargarCotizacionesReporteNotasAclaratorias)] != null)
            base.Tables.Add((DataTable) new SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasDataTable(dataSet.Tables[nameof (sp_CargarCotizacionesReporteNotasAclaratorias)]));
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
    public SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasDataTable sp_CargarCotizacionesReporteNotasAclaratorias => this.tablesp_CargarCotizacionesReporteNotasAclaratorias;

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
      SisaDev_CotiNotas sisaDevCotiNotas = (SisaDev_CotiNotas) base.Clone();
      sisaDevCotiNotas.InitVars();
      sisaDevCotiNotas.SchemaSerializationMode = this.SchemaSerializationMode;
      return (DataSet) sisaDevCotiNotas;
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
        if (dataSet.Tables["sp_CargarCotizacionesReporteNotasAclaratorias"] != null)
          base.Tables.Add((DataTable) new SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasDataTable(dataSet.Tables["sp_CargarCotizacionesReporteNotasAclaratorias"]));
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
      this.tablesp_CargarCotizacionesReporteNotasAclaratorias = (SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasDataTable) base.Tables["sp_CargarCotizacionesReporteNotasAclaratorias"];
      if (!initTable || this.tablesp_CargarCotizacionesReporteNotasAclaratorias == null)
        return;
      this.tablesp_CargarCotizacionesReporteNotasAclaratorias.InitVars();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private void InitClass()
    {
      this.DataSetName = nameof (SisaDev_CotiNotas);
      this.Prefix = "";
      this.Namespace = "http://tempuri.org/SisaDev_CotiNotas.xsd";
      this.EnforceConstraints = true;
      this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      this.tablesp_CargarCotizacionesReporteNotasAclaratorias = new SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasDataTable();
      base.Tables.Add((DataTable) this.tablesp_CargarCotizacionesReporteNotasAclaratorias);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializesp_CargarCotizacionesReporteNotasAclaratorias() => false;

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
      SisaDev_CotiNotas sisaDevCotiNotas = new SisaDev_CotiNotas();
      XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
      XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
      xmlSchemaSequence.Items.Add((XmlSchemaObject) new XmlSchemaAny()
      {
        Namespace = sisaDevCotiNotas.Namespace
      });
      schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
      XmlSchema schemaSerializable = sisaDevCotiNotas.GetSchemaSerializable();
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
    public delegate void sp_CargarCotizacionesReporteNotasAclaratoriasRowChangeEventHandler(
      object sender,
      SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasRowChangeEvent e);

    [XmlSchemaProvider("GetTypedTableSchema")]
    [Serializable]
    public class sp_CargarCotizacionesReporteNotasAclaratoriasDataTable : 
      TypedTableBase<SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasRow>
    {
      private DataColumn columnItem;
      private DataColumn columnNotaAclaratoria;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public sp_CargarCotizacionesReporteNotasAclaratoriasDataTable()
      {
        this.TableName = "sp_CargarCotizacionesReporteNotasAclaratorias";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal sp_CargarCotizacionesReporteNotasAclaratoriasDataTable(DataTable table)
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
      protected sp_CargarCotizacionesReporteNotasAclaratoriasDataTable(
        SerializationInfo info,
        StreamingContext context)
        : base(info, context)
      {
        this.InitVars();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ItemColumn => this.columnItem;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn NotaAclaratoriaColumn => this.columnNotaAclaratoria;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasRow this[
        int index]
      {
        return (SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasRow) this.Rows[index];
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasRowChangeEventHandler sp_CargarCotizacionesReporteNotasAclaratoriasRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasRowChangeEventHandler sp_CargarCotizacionesReporteNotasAclaratoriasRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasRowChangeEventHandler sp_CargarCotizacionesReporteNotasAclaratoriasRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasRowChangeEventHandler sp_CargarCotizacionesReporteNotasAclaratoriasRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void Addsp_CargarCotizacionesReporteNotasAclaratoriasRow(
        SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasRow row)
      {
        this.Rows.Add((DataRow) row);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasRow Addsp_CargarCotizacionesReporteNotasAclaratoriasRow(
        long Item,
        string NotaAclaratoria)
      {
        SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasRow notasAclaratoriasRow = (SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasRow) this.NewRow();
        object[] objArray = new object[2]
        {
          (object) Item,
          (object) NotaAclaratoria
        };
        notasAclaratoriasRow.ItemArray = objArray;
        this.Rows.Add((DataRow) notasAclaratoriasRow);
        return notasAclaratoriasRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasDataTable aclaratoriasDataTable = (SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasDataTable) base.Clone();
        aclaratoriasDataTable.InitVars();
        return (DataTable) aclaratoriasDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasDataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnItem = this.Columns["Item"];
        this.columnNotaAclaratoria = this.Columns["NotaAclaratoria"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnItem = new DataColumn("Item", typeof (long), (string) null, MappingType.Element);
        this.columnItem.ExtendedProperties.Add((object) "Generator_ColumnPropNameInRow", (object) "Item");
        this.columnItem.ExtendedProperties.Add((object) "Generator_ColumnPropNameInTable", (object) "ItemColumn");
        this.columnItem.ExtendedProperties.Add((object) "Generator_ColumnVarNameInTable", (object) "columnItem");
        this.columnItem.ExtendedProperties.Add((object) "Generator_UserColumnName", (object) "Item");
        this.Columns.Add(this.columnItem);
        this.columnNotaAclaratoria = new DataColumn("NotaAclaratoria", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNotaAclaratoria);
        this.columnItem.ReadOnly = true;
        this.columnNotaAclaratoria.AllowDBNull = false;
        this.columnNotaAclaratoria.MaxLength = int.MaxValue;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasRow Newsp_CargarCotizacionesReporteNotasAclaratoriasRow() => (SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasRow(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.sp_CargarCotizacionesReporteNotasAclaratoriasRowChanged == null)
          return;
        this.sp_CargarCotizacionesReporteNotasAclaratoriasRowChanged((object) this, new SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasRowChangeEvent((SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.sp_CargarCotizacionesReporteNotasAclaratoriasRowChanging == null)
          return;
        this.sp_CargarCotizacionesReporteNotasAclaratoriasRowChanging((object) this, new SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasRowChangeEvent((SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.sp_CargarCotizacionesReporteNotasAclaratoriasRowDeleted == null)
          return;
        this.sp_CargarCotizacionesReporteNotasAclaratoriasRowDeleted((object) this, new SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasRowChangeEvent((SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.sp_CargarCotizacionesReporteNotasAclaratoriasRowDeleting == null)
          return;
        this.sp_CargarCotizacionesReporteNotasAclaratoriasRowDeleting((object) this, new SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasRowChangeEvent((SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void Removesp_CargarCotizacionesReporteNotasAclaratoriasRow(
        SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasRow row)
      {
        this.Rows.Remove((DataRow) row);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        SisaDev_CotiNotas sisaDevCotiNotas = new SisaDev_CotiNotas();
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
          FixedValue = sisaDevCotiNotas.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (sp_CargarCotizacionesReporteNotasAclaratoriasDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = sisaDevCotiNotas.GetSchemaSerializable();
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

    public class sp_CargarCotizacionesReporteNotasAclaratoriasRow : DataRow
    {
      private SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasDataTable tablesp_CargarCotizacionesReporteNotasAclaratorias;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal sp_CargarCotizacionesReporteNotasAclaratoriasRow(DataRowBuilder rb)
        : base(rb)
      {
        this.tablesp_CargarCotizacionesReporteNotasAclaratorias = (SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasDataTable) this.Table;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public long Item
      {
        get
        {
          try
          {
            return (long) this[this.tablesp_CargarCotizacionesReporteNotasAclaratorias.ItemColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Item' de la tabla 'sp_CargarCotizacionesReporteNotasAclaratorias' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarCotizacionesReporteNotasAclaratorias.ItemColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string NotaAclaratoria
      {
        get => (string) this[this.tablesp_CargarCotizacionesReporteNotasAclaratorias.NotaAclaratoriaColumn];
        set => this[this.tablesp_CargarCotizacionesReporteNotasAclaratorias.NotaAclaratoriaColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsItemNull() => this.IsNull(this.tablesp_CargarCotizacionesReporteNotasAclaratorias.ItemColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetItemNull() => this[this.tablesp_CargarCotizacionesReporteNotasAclaratorias.ItemColumn] = Convert.DBNull;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class sp_CargarCotizacionesReporteNotasAclaratoriasRowChangeEvent : EventArgs
    {
      private SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public sp_CargarCotizacionesReporteNotasAclaratoriasRowChangeEvent(
        SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasRow row,
        DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_CotiNotas.sp_CargarCotizacionesReporteNotasAclaratoriasRow Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }
  }
}
