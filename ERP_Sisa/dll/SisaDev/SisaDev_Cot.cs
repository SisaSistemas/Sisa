// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDev_Cot
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
  [XmlRoot("SisaDev_Cot")]
  [HelpKeyword("vs.data.DataSet")]
  [Serializable]
  public class SisaDev_Cot : DataSet
  {
    private SisaDev_Cot.sp_CargarCotizacionesDataTable tablesp_CargarCotizaciones;
    private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public SisaDev_Cot()
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
    protected SisaDev_Cot(SerializationInfo info, StreamingContext context)
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
          if (dataSet.Tables[nameof (sp_CargarCotizaciones)] != null)
            base.Tables.Add((DataTable) new SisaDev_Cot.sp_CargarCotizacionesDataTable(dataSet.Tables[nameof (sp_CargarCotizaciones)]));
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
    public SisaDev_Cot.sp_CargarCotizacionesDataTable sp_CargarCotizaciones => this.tablesp_CargarCotizaciones;

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
      SisaDev_Cot sisaDevCot = (SisaDev_Cot) base.Clone();
      sisaDevCot.InitVars();
      sisaDevCot.SchemaSerializationMode = this.SchemaSerializationMode;
      return (DataSet) sisaDevCot;
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
        if (dataSet.Tables["sp_CargarCotizaciones"] != null)
          base.Tables.Add((DataTable) new SisaDev_Cot.sp_CargarCotizacionesDataTable(dataSet.Tables["sp_CargarCotizaciones"]));
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
      this.tablesp_CargarCotizaciones = (SisaDev_Cot.sp_CargarCotizacionesDataTable) base.Tables["sp_CargarCotizaciones"];
      if (!initTable || this.tablesp_CargarCotizaciones == null)
        return;
      this.tablesp_CargarCotizaciones.InitVars();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private void InitClass()
    {
      this.DataSetName = nameof (SisaDev_Cot);
      this.Prefix = "";
      this.Namespace = "http://tempuri.org/SisaDev_Cot.xsd";
      this.EnforceConstraints = true;
      this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      this.tablesp_CargarCotizaciones = new SisaDev_Cot.sp_CargarCotizacionesDataTable();
      base.Tables.Add((DataTable) this.tablesp_CargarCotizaciones);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializesp_CargarCotizaciones() => false;

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
      SisaDev_Cot sisaDevCot = new SisaDev_Cot();
      XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
      XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
      xmlSchemaSequence.Items.Add((XmlSchemaObject) new XmlSchemaAny()
      {
        Namespace = sisaDevCot.Namespace
      });
      schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
      XmlSchema schemaSerializable = sisaDevCot.GetSchemaSerializable();
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
    public delegate void sp_CargarCotizacionesRowChangeEventHandler(
      object sender,
      SisaDev_Cot.sp_CargarCotizacionesRowChangeEvent e);

    [XmlSchemaProvider("GetTypedTableSchema")]
    [Serializable]
    public class sp_CargarCotizacionesDataTable : 
      TypedTableBase<SisaDev_Cot.sp_CargarCotizacionesRow>
    {
      private DataColumn columnIdCotizaciones;
      private DataColumn columnFechaCotizaciones;
      private DataColumn columnNoCotizaciones;
      private DataColumn columnNombreContacto;
      private DataColumn columnRazonSocial;
      private DataColumn columnConcepto;
      private DataColumn columnHechaPor;
      private DataColumn columnEnviadaPor;
      private DataColumn columnEstatus;
      private DataColumn columnCostoCotizaciones;
      private DataColumn columnNombreArchivoPdf;
      private DataColumn columnCorreo;
      private DataColumn columnRFQ;
      private DataColumn columnIdUsuarioCreo;
      private DataColumn columnIdUsuarioEnvia;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public sp_CargarCotizacionesDataTable()
      {
        this.TableName = "sp_CargarCotizaciones";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal sp_CargarCotizacionesDataTable(DataTable table)
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
      protected sp_CargarCotizacionesDataTable(SerializationInfo info, StreamingContext context)
        : base(info, context)
      {
        this.InitVars();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn IdCotizacionesColumn => this.columnIdCotizaciones;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FechaCotizacionesColumn => this.columnFechaCotizaciones;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn NoCotizacionesColumn => this.columnNoCotizaciones;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn NombreContactoColumn => this.columnNombreContacto;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn RazonSocialColumn => this.columnRazonSocial;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ConceptoColumn => this.columnConcepto;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn HechaPorColumn => this.columnHechaPor;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn EnviadaPorColumn => this.columnEnviadaPor;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn EstatusColumn => this.columnEstatus;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CostoCotizacionesColumn => this.columnCostoCotizaciones;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn NombreArchivoPdfColumn => this.columnNombreArchivoPdf;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CorreoColumn => this.columnCorreo;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn RFQColumn => this.columnRFQ;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn IdUsuarioCreoColumn => this.columnIdUsuarioCreo;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn IdUsuarioEnviaColumn => this.columnIdUsuarioEnvia;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_Cot.sp_CargarCotizacionesRow this[int index] => (SisaDev_Cot.sp_CargarCotizacionesRow) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_Cot.sp_CargarCotizacionesRowChangeEventHandler sp_CargarCotizacionesRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_Cot.sp_CargarCotizacionesRowChangeEventHandler sp_CargarCotizacionesRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_Cot.sp_CargarCotizacionesRowChangeEventHandler sp_CargarCotizacionesRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_Cot.sp_CargarCotizacionesRowChangeEventHandler sp_CargarCotizacionesRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void Addsp_CargarCotizacionesRow(SisaDev_Cot.sp_CargarCotizacionesRow row) => this.Rows.Add((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_Cot.sp_CargarCotizacionesRow Addsp_CargarCotizacionesRow(
        Guid IdCotizaciones,
        DateTime FechaCotizaciones,
        string NoCotizaciones,
        string NombreContacto,
        string RazonSocial,
        string Concepto,
        string HechaPor,
        string EnviadaPor,
        int Estatus,
        Decimal CostoCotizaciones,
        string NombreArchivoPdf,
        string Correo,
        string RFQ,
        Guid IdUsuarioCreo,
        Guid IdUsuarioEnvia)
      {
        SisaDev_Cot.sp_CargarCotizacionesRow cargarCotizacionesRow = (SisaDev_Cot.sp_CargarCotizacionesRow) this.NewRow();
        object[] objArray = new object[15]
        {
          (object) IdCotizaciones,
          (object) FechaCotizaciones,
          (object) NoCotizaciones,
          (object) NombreContacto,
          (object) RazonSocial,
          (object) Concepto,
          (object) HechaPor,
          (object) EnviadaPor,
          (object) Estatus,
          (object) CostoCotizaciones,
          (object) NombreArchivoPdf,
          (object) Correo,
          (object) RFQ,
          (object) IdUsuarioCreo,
          (object) IdUsuarioEnvia
        };
        cargarCotizacionesRow.ItemArray = objArray;
        this.Rows.Add((DataRow) cargarCotizacionesRow);
        return cargarCotizacionesRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_Cot.sp_CargarCotizacionesRow FindByIdCotizaciones(
        Guid IdCotizaciones)
      {
        return (SisaDev_Cot.sp_CargarCotizacionesRow) this.Rows.Find(new object[1]
        {
          (object) IdCotizaciones
        });
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        SisaDev_Cot.sp_CargarCotizacionesDataTable cotizacionesDataTable = (SisaDev_Cot.sp_CargarCotizacionesDataTable) base.Clone();
        cotizacionesDataTable.InitVars();
        return (DataTable) cotizacionesDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new SisaDev_Cot.sp_CargarCotizacionesDataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnIdCotizaciones = this.Columns["IdCotizaciones"];
        this.columnFechaCotizaciones = this.Columns["FechaCotizaciones"];
        this.columnNoCotizaciones = this.Columns["NoCotizaciones"];
        this.columnNombreContacto = this.Columns["NombreContacto"];
        this.columnRazonSocial = this.Columns["RazonSocial"];
        this.columnConcepto = this.Columns["Concepto"];
        this.columnHechaPor = this.Columns["HechaPor"];
        this.columnEnviadaPor = this.Columns["EnviadaPor"];
        this.columnEstatus = this.Columns["Estatus"];
        this.columnCostoCotizaciones = this.Columns["CostoCotizaciones"];
        this.columnNombreArchivoPdf = this.Columns["NombreArchivoPdf"];
        this.columnCorreo = this.Columns["Correo"];
        this.columnRFQ = this.Columns["RFQ"];
        this.columnIdUsuarioCreo = this.Columns["IdUsuarioCreo"];
        this.columnIdUsuarioEnvia = this.Columns["IdUsuarioEnvia"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnIdCotizaciones = new DataColumn("IdCotizaciones", typeof (Guid), (string) null, MappingType.Element);
        this.Columns.Add(this.columnIdCotizaciones);
        this.columnFechaCotizaciones = new DataColumn("FechaCotizaciones", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFechaCotizaciones);
        this.columnNoCotizaciones = new DataColumn("NoCotizaciones", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNoCotizaciones);
        this.columnNombreContacto = new DataColumn("NombreContacto", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNombreContacto);
        this.columnRazonSocial = new DataColumn("RazonSocial", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnRazonSocial);
        this.columnConcepto = new DataColumn("Concepto", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnConcepto);
        this.columnHechaPor = new DataColumn("HechaPor", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnHechaPor);
        this.columnEnviadaPor = new DataColumn("EnviadaPor", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEnviadaPor);
        this.columnEstatus = new DataColumn("Estatus", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEstatus);
        this.columnCostoCotizaciones = new DataColumn("CostoCotizaciones", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCostoCotizaciones);
        this.columnNombreArchivoPdf = new DataColumn("NombreArchivoPdf", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNombreArchivoPdf);
        this.columnCorreo = new DataColumn("Correo", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCorreo);
        this.columnRFQ = new DataColumn("RFQ", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnRFQ);
        this.columnIdUsuarioCreo = new DataColumn("IdUsuarioCreo", typeof (Guid), (string) null, MappingType.Element);
        this.Columns.Add(this.columnIdUsuarioCreo);
        this.columnIdUsuarioEnvia = new DataColumn("IdUsuarioEnvia", typeof (Guid), (string) null, MappingType.Element);
        this.Columns.Add(this.columnIdUsuarioEnvia);
        this.Constraints.Add((Constraint) new UniqueConstraint("Constraint1", new DataColumn[1]
        {
          this.columnIdCotizaciones
        }, true));
        this.columnIdCotizaciones.AllowDBNull = false;
        this.columnIdCotizaciones.Unique = true;
        this.columnFechaCotizaciones.AllowDBNull = false;
        this.columnNoCotizaciones.AllowDBNull = false;
        this.columnNoCotizaciones.MaxLength = 50;
        this.columnNombreContacto.AllowDBNull = false;
        this.columnNombreContacto.MaxLength = 150;
        this.columnRazonSocial.AllowDBNull = false;
        this.columnRazonSocial.MaxLength = (int) byte.MaxValue;
        this.columnConcepto.AllowDBNull = false;
        this.columnConcepto.MaxLength = 200;
        this.columnHechaPor.ReadOnly = true;
        this.columnHechaPor.MaxLength = 100;
        this.columnEnviadaPor.ReadOnly = true;
        this.columnEnviadaPor.MaxLength = 100;
        this.columnEstatus.AllowDBNull = false;
        this.columnNombreArchivoPdf.MaxLength = 150;
        this.columnCorreo.AllowDBNull = false;
        this.columnCorreo.MaxLength = 50;
        this.columnRFQ.ReadOnly = true;
        this.columnRFQ.MaxLength = 50;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_Cot.sp_CargarCotizacionesRow Newsp_CargarCotizacionesRow() => (SisaDev_Cot.sp_CargarCotizacionesRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new SisaDev_Cot.sp_CargarCotizacionesRow(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (SisaDev_Cot.sp_CargarCotizacionesRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.sp_CargarCotizacionesRowChanged == null)
          return;
        this.sp_CargarCotizacionesRowChanged((object) this, new SisaDev_Cot.sp_CargarCotizacionesRowChangeEvent((SisaDev_Cot.sp_CargarCotizacionesRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.sp_CargarCotizacionesRowChanging == null)
          return;
        this.sp_CargarCotizacionesRowChanging((object) this, new SisaDev_Cot.sp_CargarCotizacionesRowChangeEvent((SisaDev_Cot.sp_CargarCotizacionesRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.sp_CargarCotizacionesRowDeleted == null)
          return;
        this.sp_CargarCotizacionesRowDeleted((object) this, new SisaDev_Cot.sp_CargarCotizacionesRowChangeEvent((SisaDev_Cot.sp_CargarCotizacionesRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.sp_CargarCotizacionesRowDeleting == null)
          return;
        this.sp_CargarCotizacionesRowDeleting((object) this, new SisaDev_Cot.sp_CargarCotizacionesRowChangeEvent((SisaDev_Cot.sp_CargarCotizacionesRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void Removesp_CargarCotizacionesRow(SisaDev_Cot.sp_CargarCotizacionesRow row) => this.Rows.Remove((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        SisaDev_Cot sisaDevCot = new SisaDev_Cot();
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
          FixedValue = sisaDevCot.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (sp_CargarCotizacionesDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = sisaDevCot.GetSchemaSerializable();
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

    public class sp_CargarCotizacionesRow : DataRow
    {
      private SisaDev_Cot.sp_CargarCotizacionesDataTable tablesp_CargarCotizaciones;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal sp_CargarCotizacionesRow(DataRowBuilder rb)
        : base(rb)
      {
        this.tablesp_CargarCotizaciones = (SisaDev_Cot.sp_CargarCotizacionesDataTable) this.Table;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Guid IdCotizaciones
      {
        get => (Guid) this[this.tablesp_CargarCotizaciones.IdCotizacionesColumn];
        set => this[this.tablesp_CargarCotizaciones.IdCotizacionesColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DateTime FechaCotizaciones
      {
        get => (DateTime) this[this.tablesp_CargarCotizaciones.FechaCotizacionesColumn];
        set => this[this.tablesp_CargarCotizaciones.FechaCotizacionesColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string NoCotizaciones
      {
        get => (string) this[this.tablesp_CargarCotizaciones.NoCotizacionesColumn];
        set => this[this.tablesp_CargarCotizaciones.NoCotizacionesColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string NombreContacto
      {
        get => (string) this[this.tablesp_CargarCotizaciones.NombreContactoColumn];
        set => this[this.tablesp_CargarCotizaciones.NombreContactoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string RazonSocial
      {
        get => (string) this[this.tablesp_CargarCotizaciones.RazonSocialColumn];
        set => this[this.tablesp_CargarCotizaciones.RazonSocialColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Concepto
      {
        get => (string) this[this.tablesp_CargarCotizaciones.ConceptoColumn];
        set => this[this.tablesp_CargarCotizaciones.ConceptoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string HechaPor
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_CargarCotizaciones.HechaPorColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'HechaPor' de la tabla 'sp_CargarCotizaciones' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarCotizaciones.HechaPorColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string EnviadaPor
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_CargarCotizaciones.EnviadaPorColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'EnviadaPor' de la tabla 'sp_CargarCotizaciones' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarCotizaciones.EnviadaPorColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Estatus
      {
        get => (int) this[this.tablesp_CargarCotizaciones.EstatusColumn];
        set => this[this.tablesp_CargarCotizaciones.EstatusColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal CostoCotizaciones
      {
        get
        {
          try
          {
            return (Decimal) this[this.tablesp_CargarCotizaciones.CostoCotizacionesColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'CostoCotizaciones' de la tabla 'sp_CargarCotizaciones' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarCotizaciones.CostoCotizacionesColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string NombreArchivoPdf
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_CargarCotizaciones.NombreArchivoPdfColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'NombreArchivoPdf' de la tabla 'sp_CargarCotizaciones' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarCotizaciones.NombreArchivoPdfColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Correo
      {
        get => (string) this[this.tablesp_CargarCotizaciones.CorreoColumn];
        set => this[this.tablesp_CargarCotizaciones.CorreoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string RFQ
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_CargarCotizaciones.RFQColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'RFQ' de la tabla 'sp_CargarCotizaciones' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarCotizaciones.RFQColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Guid IdUsuarioCreo
      {
        get
        {
          try
          {
            return (Guid) this[this.tablesp_CargarCotizaciones.IdUsuarioCreoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'IdUsuarioCreo' de la tabla 'sp_CargarCotizaciones' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarCotizaciones.IdUsuarioCreoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Guid IdUsuarioEnvia
      {
        get
        {
          try
          {
            return (Guid) this[this.tablesp_CargarCotizaciones.IdUsuarioEnviaColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'IdUsuarioEnvia' de la tabla 'sp_CargarCotizaciones' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarCotizaciones.IdUsuarioEnviaColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsHechaPorNull() => this.IsNull(this.tablesp_CargarCotizaciones.HechaPorColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetHechaPorNull() => this[this.tablesp_CargarCotizaciones.HechaPorColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsEnviadaPorNull() => this.IsNull(this.tablesp_CargarCotizaciones.EnviadaPorColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetEnviadaPorNull() => this[this.tablesp_CargarCotizaciones.EnviadaPorColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCostoCotizacionesNull() => this.IsNull(this.tablesp_CargarCotizaciones.CostoCotizacionesColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCostoCotizacionesNull() => this[this.tablesp_CargarCotizaciones.CostoCotizacionesColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNombreArchivoPdfNull() => this.IsNull(this.tablesp_CargarCotizaciones.NombreArchivoPdfColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNombreArchivoPdfNull() => this[this.tablesp_CargarCotizaciones.NombreArchivoPdfColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsRFQNull() => this.IsNull(this.tablesp_CargarCotizaciones.RFQColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetRFQNull() => this[this.tablesp_CargarCotizaciones.RFQColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsIdUsuarioCreoNull() => this.IsNull(this.tablesp_CargarCotizaciones.IdUsuarioCreoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetIdUsuarioCreoNull() => this[this.tablesp_CargarCotizaciones.IdUsuarioCreoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsIdUsuarioEnviaNull() => this.IsNull(this.tablesp_CargarCotizaciones.IdUsuarioEnviaColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetIdUsuarioEnviaNull() => this[this.tablesp_CargarCotizaciones.IdUsuarioEnviaColumn] = Convert.DBNull;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class sp_CargarCotizacionesRowChangeEvent : EventArgs
    {
      private SisaDev_Cot.sp_CargarCotizacionesRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public sp_CargarCotizacionesRowChangeEvent(
        SisaDev_Cot.sp_CargarCotizacionesRow row,
        DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_Cot.sp_CargarCotizacionesRow Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }
  }
}
