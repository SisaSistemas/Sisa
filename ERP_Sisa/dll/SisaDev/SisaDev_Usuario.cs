// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDev_Usuario
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
  [XmlRoot("SisaDev_Usuario")]
  [HelpKeyword("vs.data.DataSet")]
  [Serializable]
  public class SisaDev_Usuario : DataSet
  {
    private SisaDev_Usuario.tblSucursalesDataTable tabletblSucursales;
    private SisaDev_Usuario.tblUsuariosDataTable tabletblUsuarios;
    private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public SisaDev_Usuario()
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
    protected SisaDev_Usuario(SerializationInfo info, StreamingContext context)
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
          if (dataSet.Tables[nameof (tblSucursales)] != null)
            base.Tables.Add((DataTable) new SisaDev_Usuario.tblSucursalesDataTable(dataSet.Tables[nameof (tblSucursales)]));
          if (dataSet.Tables[nameof (tblUsuarios)] != null)
            base.Tables.Add((DataTable) new SisaDev_Usuario.tblUsuariosDataTable(dataSet.Tables[nameof (tblUsuarios)]));
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
    public SisaDev_Usuario.tblSucursalesDataTable tblSucursales => this.tabletblSucursales;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public SisaDev_Usuario.tblUsuariosDataTable tblUsuarios => this.tabletblUsuarios;

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
      SisaDev_Usuario sisaDevUsuario = (SisaDev_Usuario) base.Clone();
      sisaDevUsuario.InitVars();
      sisaDevUsuario.SchemaSerializationMode = this.SchemaSerializationMode;
      return (DataSet) sisaDevUsuario;
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
        if (dataSet.Tables["tblSucursales"] != null)
          base.Tables.Add((DataTable) new SisaDev_Usuario.tblSucursalesDataTable(dataSet.Tables["tblSucursales"]));
        if (dataSet.Tables["tblUsuarios"] != null)
          base.Tables.Add((DataTable) new SisaDev_Usuario.tblUsuariosDataTable(dataSet.Tables["tblUsuarios"]));
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
      this.tabletblSucursales = (SisaDev_Usuario.tblSucursalesDataTable) base.Tables["tblSucursales"];
      if (initTable && this.tabletblSucursales != null)
        this.tabletblSucursales.InitVars();
      this.tabletblUsuarios = (SisaDev_Usuario.tblUsuariosDataTable) base.Tables["tblUsuarios"];
      if (!initTable || this.tabletblUsuarios == null)
        return;
      this.tabletblUsuarios.InitVars();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private void InitClass()
    {
      this.DataSetName = nameof (SisaDev_Usuario);
      this.Prefix = "";
      this.Namespace = "http://tempuri.org/SisaDev_Usuario.xsd";
      this.EnforceConstraints = true;
      this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      this.tabletblSucursales = new SisaDev_Usuario.tblSucursalesDataTable();
      base.Tables.Add((DataTable) this.tabletblSucursales);
      this.tabletblUsuarios = new SisaDev_Usuario.tblUsuariosDataTable();
      base.Tables.Add((DataTable) this.tabletblUsuarios);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializetblSucursales() => false;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializetblUsuarios() => false;

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
      SisaDev_Usuario sisaDevUsuario = new SisaDev_Usuario();
      XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
      XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
      xmlSchemaSequence.Items.Add((XmlSchemaObject) new XmlSchemaAny()
      {
        Namespace = sisaDevUsuario.Namespace
      });
      schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
      XmlSchema schemaSerializable = sisaDevUsuario.GetSchemaSerializable();
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
    public delegate void tblSucursalesRowChangeEventHandler(
      object sender,
      SisaDev_Usuario.tblSucursalesRowChangeEvent e);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public delegate void tblUsuariosRowChangeEventHandler(
      object sender,
      SisaDev_Usuario.tblUsuariosRowChangeEvent e);

    [XmlSchemaProvider("GetTypedTableSchema")]
    [Serializable]
    public class tblSucursalesDataTable : TypedTableBase<SisaDev_Usuario.tblSucursalesRow>
    {
      private DataColumn columnidSucursa;
      private DataColumn columnCiudadSucursal;
      private DataColumn columnDireccionSucursal;
      private DataColumn columnTelefonoSucursal;
      private DataColumn columnTIMESTAMP;
      private DataColumn columnEstatus;
      private DataColumn columnGerente;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public tblSucursalesDataTable()
      {
        this.TableName = "tblSucursales";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal tblSucursalesDataTable(DataTable table)
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
      protected tblSucursalesDataTable(SerializationInfo info, StreamingContext context)
        : base(info, context)
      {
        this.InitVars();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn idSucursaColumn => this.columnidSucursa;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CiudadSucursalColumn => this.columnCiudadSucursal;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn DireccionSucursalColumn => this.columnDireccionSucursal;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn TelefonoSucursalColumn => this.columnTelefonoSucursal;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn TIMESTAMPColumn => this.columnTIMESTAMP;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn EstatusColumn => this.columnEstatus;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn GerenteColumn => this.columnGerente;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_Usuario.tblSucursalesRow this[int index] => (SisaDev_Usuario.tblSucursalesRow) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_Usuario.tblSucursalesRowChangeEventHandler tblSucursalesRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_Usuario.tblSucursalesRowChangeEventHandler tblSucursalesRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_Usuario.tblSucursalesRowChangeEventHandler tblSucursalesRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_Usuario.tblSucursalesRowChangeEventHandler tblSucursalesRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void AddtblSucursalesRow(SisaDev_Usuario.tblSucursalesRow row) => this.Rows.Add((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_Usuario.tblSucursalesRow AddtblSucursalesRow(
        Guid idSucursa,
        string CiudadSucursal,
        string DireccionSucursal,
        string TelefonoSucursal,
        DateTime TIMESTAMP,
        bool Estatus,
        string Gerente)
      {
        SisaDev_Usuario.tblSucursalesRow tblSucursalesRow = (SisaDev_Usuario.tblSucursalesRow) this.NewRow();
        object[] objArray = new object[7]
        {
          (object) idSucursa,
          (object) CiudadSucursal,
          (object) DireccionSucursal,
          (object) TelefonoSucursal,
          (object) TIMESTAMP,
          (object) Estatus,
          (object) Gerente
        };
        tblSucursalesRow.ItemArray = objArray;
        this.Rows.Add((DataRow) tblSucursalesRow);
        return tblSucursalesRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_Usuario.tblSucursalesRow FindByidSucursa(Guid idSucursa) => (SisaDev_Usuario.tblSucursalesRow) this.Rows.Find(new object[1]
      {
        (object) idSucursa
      });

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        SisaDev_Usuario.tblSucursalesDataTable sucursalesDataTable = (SisaDev_Usuario.tblSucursalesDataTable) base.Clone();
        sucursalesDataTable.InitVars();
        return (DataTable) sucursalesDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new SisaDev_Usuario.tblSucursalesDataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnidSucursa = this.Columns["idSucursa"];
        this.columnCiudadSucursal = this.Columns["CiudadSucursal"];
        this.columnDireccionSucursal = this.Columns["DireccionSucursal"];
        this.columnTelefonoSucursal = this.Columns["TelefonoSucursal"];
        this.columnTIMESTAMP = this.Columns["TIMESTAMP"];
        this.columnEstatus = this.Columns["Estatus"];
        this.columnGerente = this.Columns["Gerente"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnidSucursa = new DataColumn("idSucursa", typeof (Guid), (string) null, MappingType.Element);
        this.Columns.Add(this.columnidSucursa);
        this.columnCiudadSucursal = new DataColumn("CiudadSucursal", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCiudadSucursal);
        this.columnDireccionSucursal = new DataColumn("DireccionSucursal", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDireccionSucursal);
        this.columnTelefonoSucursal = new DataColumn("TelefonoSucursal", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTelefonoSucursal);
        this.columnTIMESTAMP = new DataColumn("TIMESTAMP", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTIMESTAMP);
        this.columnEstatus = new DataColumn("Estatus", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEstatus);
        this.columnGerente = new DataColumn("Gerente", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnGerente);
        this.Constraints.Add((Constraint) new UniqueConstraint("Constraint1", new DataColumn[1]
        {
          this.columnidSucursa
        }, true));
        this.columnidSucursa.AllowDBNull = false;
        this.columnidSucursa.Unique = true;
        this.columnCiudadSucursal.AllowDBNull = false;
        this.columnCiudadSucursal.MaxLength = 50;
        this.columnDireccionSucursal.AllowDBNull = false;
        this.columnDireccionSucursal.MaxLength = 250;
        this.columnTelefonoSucursal.AllowDBNull = false;
        this.columnTelefonoSucursal.MaxLength = 50;
        this.columnGerente.MaxLength = 150;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_Usuario.tblSucursalesRow NewtblSucursalesRow() => (SisaDev_Usuario.tblSucursalesRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new SisaDev_Usuario.tblSucursalesRow(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (SisaDev_Usuario.tblSucursalesRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.tblSucursalesRowChanged == null)
          return;
        this.tblSucursalesRowChanged((object) this, new SisaDev_Usuario.tblSucursalesRowChangeEvent((SisaDev_Usuario.tblSucursalesRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.tblSucursalesRowChanging == null)
          return;
        this.tblSucursalesRowChanging((object) this, new SisaDev_Usuario.tblSucursalesRowChangeEvent((SisaDev_Usuario.tblSucursalesRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.tblSucursalesRowDeleted == null)
          return;
        this.tblSucursalesRowDeleted((object) this, new SisaDev_Usuario.tblSucursalesRowChangeEvent((SisaDev_Usuario.tblSucursalesRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.tblSucursalesRowDeleting == null)
          return;
        this.tblSucursalesRowDeleting((object) this, new SisaDev_Usuario.tblSucursalesRowChangeEvent((SisaDev_Usuario.tblSucursalesRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void RemovetblSucursalesRow(SisaDev_Usuario.tblSucursalesRow row) => this.Rows.Remove((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        SisaDev_Usuario sisaDevUsuario = new SisaDev_Usuario();
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
          FixedValue = sisaDevUsuario.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (tblSucursalesDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = sisaDevUsuario.GetSchemaSerializable();
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

    [XmlSchemaProvider("GetTypedTableSchema")]
    [Serializable]
    public class tblUsuariosDataTable : TypedTableBase<SisaDev_Usuario.tblUsuariosRow>
    {
      private DataColumn columnIdUsuario;
      private DataColumn columnNombreCompleto;
      private DataColumn columnUsuario;
      private DataColumn columnContrasena;
      private DataColumn columnFoto;
      private DataColumn columnPermisos;
      private DataColumn columnPuesto;
      private DataColumn columnTelefono;
      private DataColumn columnCorreo;
      private DataColumn columnFechaAlta;
      private DataColumn columnIdUsuarioModificacion;
      private DataColumn columnFechaModificacion;
      private DataColumn columnActivo;
      private DataColumn columnEsLiderProyecto;
      private DataColumn columnPerfil;
      private DataColumn columnSueldoDiario;
      private DataColumn columnidSucursal;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public tblUsuariosDataTable()
      {
        this.TableName = "tblUsuarios";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal tblUsuariosDataTable(DataTable table)
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
      protected tblUsuariosDataTable(SerializationInfo info, StreamingContext context)
        : base(info, context)
      {
        this.InitVars();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn IdUsuarioColumn => this.columnIdUsuario;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn NombreCompletoColumn => this.columnNombreCompleto;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn UsuarioColumn => this.columnUsuario;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ContrasenaColumn => this.columnContrasena;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FotoColumn => this.columnFoto;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn PermisosColumn => this.columnPermisos;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn PuestoColumn => this.columnPuesto;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn TelefonoColumn => this.columnTelefono;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CorreoColumn => this.columnCorreo;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FechaAltaColumn => this.columnFechaAlta;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn IdUsuarioModificacionColumn => this.columnIdUsuarioModificacion;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FechaModificacionColumn => this.columnFechaModificacion;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ActivoColumn => this.columnActivo;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn EsLiderProyectoColumn => this.columnEsLiderProyecto;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn PerfilColumn => this.columnPerfil;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn SueldoDiarioColumn => this.columnSueldoDiario;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn idSucursalColumn => this.columnidSucursal;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_Usuario.tblUsuariosRow this[int index] => (SisaDev_Usuario.tblUsuariosRow) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_Usuario.tblUsuariosRowChangeEventHandler tblUsuariosRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_Usuario.tblUsuariosRowChangeEventHandler tblUsuariosRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_Usuario.tblUsuariosRowChangeEventHandler tblUsuariosRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_Usuario.tblUsuariosRowChangeEventHandler tblUsuariosRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void AddtblUsuariosRow(SisaDev_Usuario.tblUsuariosRow row) => this.Rows.Add((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_Usuario.tblUsuariosRow AddtblUsuariosRow(
        Guid IdUsuario,
        string NombreCompleto,
        string Usuario,
        string Contrasena,
        string Foto,
        int Permisos,
        string Puesto,
        string Telefono,
        string Correo,
        DateTime FechaAlta,
        Guid IdUsuarioModificacion,
        DateTime FechaModificacion,
        int Activo,
        int EsLiderProyecto,
        string Perfil,
        Decimal SueldoDiario,
        Guid idSucursal)
      {
        SisaDev_Usuario.tblUsuariosRow tblUsuariosRow = (SisaDev_Usuario.tblUsuariosRow) this.NewRow();
        object[] objArray = new object[17]
        {
          (object) IdUsuario,
          (object) NombreCompleto,
          (object) Usuario,
          (object) Contrasena,
          (object) Foto,
          (object) Permisos,
          (object) Puesto,
          (object) Telefono,
          (object) Correo,
          (object) FechaAlta,
          (object) IdUsuarioModificacion,
          (object) FechaModificacion,
          (object) Activo,
          (object) EsLiderProyecto,
          (object) Perfil,
          (object) SueldoDiario,
          (object) idSucursal
        };
        tblUsuariosRow.ItemArray = objArray;
        this.Rows.Add((DataRow) tblUsuariosRow);
        return tblUsuariosRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_Usuario.tblUsuariosRow FindByIdUsuario(Guid IdUsuario) => (SisaDev_Usuario.tblUsuariosRow) this.Rows.Find(new object[1]
      {
        (object) IdUsuario
      });

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        SisaDev_Usuario.tblUsuariosDataTable usuariosDataTable = (SisaDev_Usuario.tblUsuariosDataTable) base.Clone();
        usuariosDataTable.InitVars();
        return (DataTable) usuariosDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new SisaDev_Usuario.tblUsuariosDataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnIdUsuario = this.Columns["IdUsuario"];
        this.columnNombreCompleto = this.Columns["NombreCompleto"];
        this.columnUsuario = this.Columns["Usuario"];
        this.columnContrasena = this.Columns["Contrasena"];
        this.columnFoto = this.Columns["Foto"];
        this.columnPermisos = this.Columns["Permisos"];
        this.columnPuesto = this.Columns["Puesto"];
        this.columnTelefono = this.Columns["Telefono"];
        this.columnCorreo = this.Columns["Correo"];
        this.columnFechaAlta = this.Columns["FechaAlta"];
        this.columnIdUsuarioModificacion = this.Columns["IdUsuarioModificacion"];
        this.columnFechaModificacion = this.Columns["FechaModificacion"];
        this.columnActivo = this.Columns["Activo"];
        this.columnEsLiderProyecto = this.Columns["EsLiderProyecto"];
        this.columnPerfil = this.Columns["Perfil"];
        this.columnSueldoDiario = this.Columns["SueldoDiario"];
        this.columnidSucursal = this.Columns["idSucursal"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnIdUsuario = new DataColumn("IdUsuario", typeof (Guid), (string) null, MappingType.Element);
        this.Columns.Add(this.columnIdUsuario);
        this.columnNombreCompleto = new DataColumn("NombreCompleto", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNombreCompleto);
        this.columnUsuario = new DataColumn("Usuario", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnUsuario);
        this.columnContrasena = new DataColumn("Contrasena", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnContrasena);
        this.columnFoto = new DataColumn("Foto", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFoto);
        this.columnPermisos = new DataColumn("Permisos", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPermisos);
        this.columnPuesto = new DataColumn("Puesto", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPuesto);
        this.columnTelefono = new DataColumn("Telefono", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTelefono);
        this.columnCorreo = new DataColumn("Correo", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCorreo);
        this.columnFechaAlta = new DataColumn("FechaAlta", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFechaAlta);
        this.columnIdUsuarioModificacion = new DataColumn("IdUsuarioModificacion", typeof (Guid), (string) null, MappingType.Element);
        this.Columns.Add(this.columnIdUsuarioModificacion);
        this.columnFechaModificacion = new DataColumn("FechaModificacion", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFechaModificacion);
        this.columnActivo = new DataColumn("Activo", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnActivo);
        this.columnEsLiderProyecto = new DataColumn("EsLiderProyecto", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEsLiderProyecto);
        this.columnPerfil = new DataColumn("Perfil", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPerfil);
        this.columnSueldoDiario = new DataColumn("SueldoDiario", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSueldoDiario);
        this.columnidSucursal = new DataColumn("idSucursal", typeof (Guid), (string) null, MappingType.Element);
        this.Columns.Add(this.columnidSucursal);
        this.Constraints.Add((Constraint) new UniqueConstraint("Constraint1", new DataColumn[1]
        {
          this.columnIdUsuario
        }, true));
        this.columnIdUsuario.AllowDBNull = false;
        this.columnIdUsuario.Unique = true;
        this.columnNombreCompleto.MaxLength = 100;
        this.columnUsuario.MaxLength = 100;
        this.columnContrasena.MaxLength = 50;
        this.columnFoto.MaxLength = int.MaxValue;
        this.columnPuesto.MaxLength = 100;
        this.columnTelefono.MaxLength = 50;
        this.columnCorreo.MaxLength = 100;
        this.columnPerfil.MaxLength = int.MaxValue;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_Usuario.tblUsuariosRow NewtblUsuariosRow() => (SisaDev_Usuario.tblUsuariosRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new SisaDev_Usuario.tblUsuariosRow(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (SisaDev_Usuario.tblUsuariosRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.tblUsuariosRowChanged == null)
          return;
        this.tblUsuariosRowChanged((object) this, new SisaDev_Usuario.tblUsuariosRowChangeEvent((SisaDev_Usuario.tblUsuariosRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.tblUsuariosRowChanging == null)
          return;
        this.tblUsuariosRowChanging((object) this, new SisaDev_Usuario.tblUsuariosRowChangeEvent((SisaDev_Usuario.tblUsuariosRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.tblUsuariosRowDeleted == null)
          return;
        this.tblUsuariosRowDeleted((object) this, new SisaDev_Usuario.tblUsuariosRowChangeEvent((SisaDev_Usuario.tblUsuariosRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.tblUsuariosRowDeleting == null)
          return;
        this.tblUsuariosRowDeleting((object) this, new SisaDev_Usuario.tblUsuariosRowChangeEvent((SisaDev_Usuario.tblUsuariosRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void RemovetblUsuariosRow(SisaDev_Usuario.tblUsuariosRow row) => this.Rows.Remove((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        SisaDev_Usuario sisaDevUsuario = new SisaDev_Usuario();
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
          FixedValue = sisaDevUsuario.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (tblUsuariosDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = sisaDevUsuario.GetSchemaSerializable();
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

    public class tblSucursalesRow : DataRow
    {
      private SisaDev_Usuario.tblSucursalesDataTable tabletblSucursales;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal tblSucursalesRow(DataRowBuilder rb)
        : base(rb)
      {
        this.tabletblSucursales = (SisaDev_Usuario.tblSucursalesDataTable) this.Table;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Guid idSucursa
      {
        get => (Guid) this[this.tabletblSucursales.idSucursaColumn];
        set => this[this.tabletblSucursales.idSucursaColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string CiudadSucursal
      {
        get => (string) this[this.tabletblSucursales.CiudadSucursalColumn];
        set => this[this.tabletblSucursales.CiudadSucursalColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string DireccionSucursal
      {
        get => (string) this[this.tabletblSucursales.DireccionSucursalColumn];
        set => this[this.tabletblSucursales.DireccionSucursalColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string TelefonoSucursal
      {
        get => (string) this[this.tabletblSucursales.TelefonoSucursalColumn];
        set => this[this.tabletblSucursales.TelefonoSucursalColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DateTime TIMESTAMP
      {
        get
        {
          try
          {
            return (DateTime) this[this.tabletblSucursales.TIMESTAMPColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'TIMESTAMP' de la tabla 'tblSucursales' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tabletblSucursales.TIMESTAMPColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool Estatus
      {
        get
        {
          try
          {
            return (bool) this[this.tabletblSucursales.EstatusColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Estatus' de la tabla 'tblSucursales' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tabletblSucursales.EstatusColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Gerente
      {
        get
        {
          try
          {
            return (string) this[this.tabletblSucursales.GerenteColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Gerente' de la tabla 'tblSucursales' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tabletblSucursales.GerenteColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsTIMESTAMPNull() => this.IsNull(this.tabletblSucursales.TIMESTAMPColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetTIMESTAMPNull() => this[this.tabletblSucursales.TIMESTAMPColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsEstatusNull() => this.IsNull(this.tabletblSucursales.EstatusColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetEstatusNull() => this[this.tabletblSucursales.EstatusColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsGerenteNull() => this.IsNull(this.tabletblSucursales.GerenteColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetGerenteNull() => this[this.tabletblSucursales.GerenteColumn] = Convert.DBNull;
    }

    public class tblUsuariosRow : DataRow
    {
      private SisaDev_Usuario.tblUsuariosDataTable tabletblUsuarios;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal tblUsuariosRow(DataRowBuilder rb)
        : base(rb)
      {
        this.tabletblUsuarios = (SisaDev_Usuario.tblUsuariosDataTable) this.Table;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Guid IdUsuario
      {
        get => (Guid) this[this.tabletblUsuarios.IdUsuarioColumn];
        set => this[this.tabletblUsuarios.IdUsuarioColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string NombreCompleto
      {
        get
        {
          try
          {
            return (string) this[this.tabletblUsuarios.NombreCompletoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'NombreCompleto' de la tabla 'tblUsuarios' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tabletblUsuarios.NombreCompletoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Usuario
      {
        get
        {
          try
          {
            return (string) this[this.tabletblUsuarios.UsuarioColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Usuario' de la tabla 'tblUsuarios' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tabletblUsuarios.UsuarioColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Contrasena
      {
        get
        {
          try
          {
            return (string) this[this.tabletblUsuarios.ContrasenaColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Contrasena' de la tabla 'tblUsuarios' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tabletblUsuarios.ContrasenaColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Foto
      {
        get
        {
          try
          {
            return (string) this[this.tabletblUsuarios.FotoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Foto' de la tabla 'tblUsuarios' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tabletblUsuarios.FotoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Permisos
      {
        get
        {
          try
          {
            return (int) this[this.tabletblUsuarios.PermisosColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Permisos' de la tabla 'tblUsuarios' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tabletblUsuarios.PermisosColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Puesto
      {
        get
        {
          try
          {
            return (string) this[this.tabletblUsuarios.PuestoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Puesto' de la tabla 'tblUsuarios' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tabletblUsuarios.PuestoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Telefono
      {
        get
        {
          try
          {
            return (string) this[this.tabletblUsuarios.TelefonoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Telefono' de la tabla 'tblUsuarios' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tabletblUsuarios.TelefonoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Correo
      {
        get
        {
          try
          {
            return (string) this[this.tabletblUsuarios.CorreoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Correo' de la tabla 'tblUsuarios' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tabletblUsuarios.CorreoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DateTime FechaAlta
      {
        get
        {
          try
          {
            return (DateTime) this[this.tabletblUsuarios.FechaAltaColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'FechaAlta' de la tabla 'tblUsuarios' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tabletblUsuarios.FechaAltaColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Guid IdUsuarioModificacion
      {
        get
        {
          try
          {
            return (Guid) this[this.tabletblUsuarios.IdUsuarioModificacionColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'IdUsuarioModificacion' de la tabla 'tblUsuarios' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tabletblUsuarios.IdUsuarioModificacionColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DateTime FechaModificacion
      {
        get
        {
          try
          {
            return (DateTime) this[this.tabletblUsuarios.FechaModificacionColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'FechaModificacion' de la tabla 'tblUsuarios' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tabletblUsuarios.FechaModificacionColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Activo
      {
        get
        {
          try
          {
            return (int) this[this.tabletblUsuarios.ActivoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Activo' de la tabla 'tblUsuarios' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tabletblUsuarios.ActivoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int EsLiderProyecto
      {
        get
        {
          try
          {
            return (int) this[this.tabletblUsuarios.EsLiderProyectoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'EsLiderProyecto' de la tabla 'tblUsuarios' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tabletblUsuarios.EsLiderProyectoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Perfil
      {
        get
        {
          try
          {
            return (string) this[this.tabletblUsuarios.PerfilColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Perfil' de la tabla 'tblUsuarios' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tabletblUsuarios.PerfilColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal SueldoDiario
      {
        get
        {
          try
          {
            return (Decimal) this[this.tabletblUsuarios.SueldoDiarioColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'SueldoDiario' de la tabla 'tblUsuarios' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tabletblUsuarios.SueldoDiarioColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Guid idSucursal
      {
        get
        {
          try
          {
            return (Guid) this[this.tabletblUsuarios.idSucursalColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'idSucursal' de la tabla 'tblUsuarios' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tabletblUsuarios.idSucursalColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNombreCompletoNull() => this.IsNull(this.tabletblUsuarios.NombreCompletoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNombreCompletoNull() => this[this.tabletblUsuarios.NombreCompletoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsUsuarioNull() => this.IsNull(this.tabletblUsuarios.UsuarioColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetUsuarioNull() => this[this.tabletblUsuarios.UsuarioColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsContrasenaNull() => this.IsNull(this.tabletblUsuarios.ContrasenaColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetContrasenaNull() => this[this.tabletblUsuarios.ContrasenaColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFotoNull() => this.IsNull(this.tabletblUsuarios.FotoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFotoNull() => this[this.tabletblUsuarios.FotoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPermisosNull() => this.IsNull(this.tabletblUsuarios.PermisosColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPermisosNull() => this[this.tabletblUsuarios.PermisosColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPuestoNull() => this.IsNull(this.tabletblUsuarios.PuestoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPuestoNull() => this[this.tabletblUsuarios.PuestoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsTelefonoNull() => this.IsNull(this.tabletblUsuarios.TelefonoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetTelefonoNull() => this[this.tabletblUsuarios.TelefonoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCorreoNull() => this.IsNull(this.tabletblUsuarios.CorreoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCorreoNull() => this[this.tabletblUsuarios.CorreoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFechaAltaNull() => this.IsNull(this.tabletblUsuarios.FechaAltaColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFechaAltaNull() => this[this.tabletblUsuarios.FechaAltaColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsIdUsuarioModificacionNull() => this.IsNull(this.tabletblUsuarios.IdUsuarioModificacionColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetIdUsuarioModificacionNull() => this[this.tabletblUsuarios.IdUsuarioModificacionColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFechaModificacionNull() => this.IsNull(this.tabletblUsuarios.FechaModificacionColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFechaModificacionNull() => this[this.tabletblUsuarios.FechaModificacionColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsActivoNull() => this.IsNull(this.tabletblUsuarios.ActivoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetActivoNull() => this[this.tabletblUsuarios.ActivoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsEsLiderProyectoNull() => this.IsNull(this.tabletblUsuarios.EsLiderProyectoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetEsLiderProyectoNull() => this[this.tabletblUsuarios.EsLiderProyectoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPerfilNull() => this.IsNull(this.tabletblUsuarios.PerfilColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPerfilNull() => this[this.tabletblUsuarios.PerfilColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsSueldoDiarioNull() => this.IsNull(this.tabletblUsuarios.SueldoDiarioColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetSueldoDiarioNull() => this[this.tabletblUsuarios.SueldoDiarioColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsidSucursalNull() => this.IsNull(this.tabletblUsuarios.idSucursalColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetidSucursalNull() => this[this.tabletblUsuarios.idSucursalColumn] = Convert.DBNull;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class tblSucursalesRowChangeEvent : EventArgs
    {
      private SisaDev_Usuario.tblSucursalesRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public tblSucursalesRowChangeEvent(SisaDev_Usuario.tblSucursalesRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_Usuario.tblSucursalesRow Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class tblUsuariosRowChangeEvent : EventArgs
    {
      private SisaDev_Usuario.tblUsuariosRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public tblUsuariosRowChangeEvent(SisaDev_Usuario.tblUsuariosRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_Usuario.tblUsuariosRow Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }
  }
}
