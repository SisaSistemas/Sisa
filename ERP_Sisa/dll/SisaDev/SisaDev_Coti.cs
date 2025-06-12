// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDev_Coti
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
  [XmlRoot("SisaDev_Coti")]
  [HelpKeyword("vs.data.DataSet")]
  [Serializable]
  public class SisaDev_Coti : DataSet
  {
    private SisaDev_Coti.sp_CargarCotizacionesReporteDataTable tablesp_CargarCotizacionesReporte;
    private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public SisaDev_Coti()
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
    protected SisaDev_Coti(SerializationInfo info, StreamingContext context)
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
          if (dataSet.Tables[nameof (sp_CargarCotizacionesReporte)] != null)
            base.Tables.Add((DataTable) new SisaDev_Coti.sp_CargarCotizacionesReporteDataTable(dataSet.Tables[nameof (sp_CargarCotizacionesReporte)]));
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
    public SisaDev_Coti.sp_CargarCotizacionesReporteDataTable sp_CargarCotizacionesReporte => this.tablesp_CargarCotizacionesReporte;

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
      SisaDev_Coti sisaDevCoti = (SisaDev_Coti) base.Clone();
      sisaDevCoti.InitVars();
      sisaDevCoti.SchemaSerializationMode = this.SchemaSerializationMode;
      return (DataSet) sisaDevCoti;
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
        if (dataSet.Tables["sp_CargarCotizacionesReporte"] != null)
          base.Tables.Add((DataTable) new SisaDev_Coti.sp_CargarCotizacionesReporteDataTable(dataSet.Tables["sp_CargarCotizacionesReporte"]));
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
      this.tablesp_CargarCotizacionesReporte = (SisaDev_Coti.sp_CargarCotizacionesReporteDataTable) base.Tables["sp_CargarCotizacionesReporte"];
      if (!initTable || this.tablesp_CargarCotizacionesReporte == null)
        return;
      this.tablesp_CargarCotizacionesReporte.InitVars();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private void InitClass()
    {
      this.DataSetName = nameof (SisaDev_Coti);
      this.Prefix = "";
      this.Namespace = "http://tempuri.org/SisaDev_Coti.xsd";
      this.EnforceConstraints = true;
      this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      this.tablesp_CargarCotizacionesReporte = new SisaDev_Coti.sp_CargarCotizacionesReporteDataTable();
      base.Tables.Add((DataTable) this.tablesp_CargarCotizacionesReporte);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializesp_CargarCotizacionesReporte() => false;

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
      SisaDev_Coti sisaDevCoti = new SisaDev_Coti();
      XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
      XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
      xmlSchemaSequence.Items.Add((XmlSchemaObject) new XmlSchemaAny()
      {
        Namespace = sisaDevCoti.Namespace
      });
      schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
      XmlSchema schemaSerializable = sisaDevCoti.GetSchemaSerializable();
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
    public delegate void sp_CargarCotizacionesReporteRowChangeEventHandler(
      object sender,
      SisaDev_Coti.sp_CargarCotizacionesReporteRowChangeEvent e);

    [XmlSchemaProvider("GetTypedTableSchema")]
    [Serializable]
    public class sp_CargarCotizacionesReporteDataTable : 
      TypedTableBase<SisaDev_Coti.sp_CargarCotizacionesReporteRow>
    {
      private DataColumn columnIdCotizaciones;
      private DataColumn columnFechaCotizaciones;
      private DataColumn columnNoCotizaciones;
      private DataColumn columnConcepto;
      private DataColumn columnNoCotizaciones1;
      private DataColumn columnCiudad;
      private DataColumn columnCostoCotizaciones;
      private DataColumn columnCorreo;
      private DataColumn columnCreo;
      private DataColumn columnNombreContacto;
      private DataColumn columnRazonSocial;
      private DataColumn columnDireccionFiscal;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public sp_CargarCotizacionesReporteDataTable()
      {
        this.TableName = "sp_CargarCotizacionesReporte";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal sp_CargarCotizacionesReporteDataTable(DataTable table)
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
      protected sp_CargarCotizacionesReporteDataTable(
        SerializationInfo info,
        StreamingContext context)
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
      public DataColumn ConceptoColumn => this.columnConcepto;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn NoCotizaciones1Column => this.columnNoCotizaciones1;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CiudadColumn => this.columnCiudad;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CostoCotizacionesColumn => this.columnCostoCotizaciones;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CorreoColumn => this.columnCorreo;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CreoColumn => this.columnCreo;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn NombreContactoColumn => this.columnNombreContacto;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn RazonSocialColumn => this.columnRazonSocial;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn DireccionFiscalColumn => this.columnDireccionFiscal;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_Coti.sp_CargarCotizacionesReporteRow this[int index] => (SisaDev_Coti.sp_CargarCotizacionesReporteRow) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_Coti.sp_CargarCotizacionesReporteRowChangeEventHandler sp_CargarCotizacionesReporteRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_Coti.sp_CargarCotizacionesReporteRowChangeEventHandler sp_CargarCotizacionesReporteRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_Coti.sp_CargarCotizacionesReporteRowChangeEventHandler sp_CargarCotizacionesReporteRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDev_Coti.sp_CargarCotizacionesReporteRowChangeEventHandler sp_CargarCotizacionesReporteRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void Addsp_CargarCotizacionesReporteRow(
        SisaDev_Coti.sp_CargarCotizacionesReporteRow row)
      {
        this.Rows.Add((DataRow) row);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_Coti.sp_CargarCotizacionesReporteRow Addsp_CargarCotizacionesReporteRow(
        Guid IdCotizaciones,
        DateTime FechaCotizaciones,
        string NoCotizaciones,
        string Concepto,
        string NoCotizaciones1,
        string Ciudad,
        Decimal CostoCotizaciones,
        string Correo,
        string Creo,
        string NombreContacto,
        string RazonSocial,
        string DireccionFiscal)
      {
        SisaDev_Coti.sp_CargarCotizacionesReporteRow cotizacionesReporteRow = (SisaDev_Coti.sp_CargarCotizacionesReporteRow) this.NewRow();
        object[] objArray = new object[12]
        {
          (object) IdCotizaciones,
          (object) FechaCotizaciones,
          (object) NoCotizaciones,
          (object) Concepto,
          (object) NoCotizaciones1,
          (object) Ciudad,
          (object) CostoCotizaciones,
          (object) Correo,
          (object) Creo,
          (object) NombreContacto,
          (object) RazonSocial,
          (object) DireccionFiscal
        };
        cotizacionesReporteRow.ItemArray = objArray;
        this.Rows.Add((DataRow) cotizacionesReporteRow);
        return cotizacionesReporteRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_Coti.sp_CargarCotizacionesReporteRow FindByIdCotizaciones(
        Guid IdCotizaciones)
      {
        return (SisaDev_Coti.sp_CargarCotizacionesReporteRow) this.Rows.Find(new object[1]
        {
          (object) IdCotizaciones
        });
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        SisaDev_Coti.sp_CargarCotizacionesReporteDataTable reporteDataTable = (SisaDev_Coti.sp_CargarCotizacionesReporteDataTable) base.Clone();
        reporteDataTable.InitVars();
        return (DataTable) reporteDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new SisaDev_Coti.sp_CargarCotizacionesReporteDataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnIdCotizaciones = this.Columns["IdCotizaciones"];
        this.columnFechaCotizaciones = this.Columns["FechaCotizaciones"];
        this.columnNoCotizaciones = this.Columns["NoCotizaciones"];
        this.columnConcepto = this.Columns["Concepto"];
        this.columnNoCotizaciones1 = this.Columns["NoCotizaciones1"];
        this.columnCiudad = this.Columns["Ciudad"];
        this.columnCostoCotizaciones = this.Columns["CostoCotizaciones"];
        this.columnCorreo = this.Columns["Correo"];
        this.columnCreo = this.Columns["Creo"];
        this.columnNombreContacto = this.Columns["NombreContacto"];
        this.columnRazonSocial = this.Columns["RazonSocial"];
        this.columnDireccionFiscal = this.Columns["DireccionFiscal"];
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
        this.columnConcepto = new DataColumn("Concepto", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnConcepto);
        this.columnNoCotizaciones1 = new DataColumn("NoCotizaciones1", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNoCotizaciones1);
        this.columnCiudad = new DataColumn("Ciudad", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCiudad);
        this.columnCostoCotizaciones = new DataColumn("CostoCotizaciones", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCostoCotizaciones);
        this.columnCorreo = new DataColumn("Correo", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCorreo);
        this.columnCreo = new DataColumn("Creo", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCreo);
        this.columnNombreContacto = new DataColumn("NombreContacto", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNombreContacto);
        this.columnRazonSocial = new DataColumn("RazonSocial", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnRazonSocial);
        this.columnDireccionFiscal = new DataColumn("DireccionFiscal", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDireccionFiscal);
        this.Constraints.Add((Constraint) new UniqueConstraint("Constraint1", new DataColumn[1]
        {
          this.columnIdCotizaciones
        }, true));
        this.columnIdCotizaciones.AllowDBNull = false;
        this.columnIdCotizaciones.Unique = true;
        this.columnFechaCotizaciones.AllowDBNull = false;
        this.columnNoCotizaciones.AllowDBNull = false;
        this.columnNoCotizaciones.MaxLength = 50;
        this.columnConcepto.AllowDBNull = false;
        this.columnConcepto.MaxLength = 200;
        this.columnNoCotizaciones1.AllowDBNull = false;
        this.columnNoCotizaciones1.MaxLength = 50;
        this.columnCiudad.AllowDBNull = false;
        this.columnCiudad.MaxLength = 100;
        this.columnCorreo.AllowDBNull = false;
        this.columnCorreo.MaxLength = 50;
        this.columnCreo.ReadOnly = true;
        this.columnCreo.MaxLength = 100;
        this.columnNombreContacto.AllowDBNull = false;
        this.columnNombreContacto.MaxLength = 150;
        this.columnRazonSocial.AllowDBNull = false;
        this.columnRazonSocial.MaxLength = (int) byte.MaxValue;
        this.columnDireccionFiscal.AllowDBNull = false;
        this.columnDireccionFiscal.MaxLength = (int) byte.MaxValue;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_Coti.sp_CargarCotizacionesReporteRow Newsp_CargarCotizacionesReporteRow() => (SisaDev_Coti.sp_CargarCotizacionesReporteRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new SisaDev_Coti.sp_CargarCotizacionesReporteRow(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (SisaDev_Coti.sp_CargarCotizacionesReporteRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.sp_CargarCotizacionesReporteRowChanged == null)
          return;
        this.sp_CargarCotizacionesReporteRowChanged((object) this, new SisaDev_Coti.sp_CargarCotizacionesReporteRowChangeEvent((SisaDev_Coti.sp_CargarCotizacionesReporteRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.sp_CargarCotizacionesReporteRowChanging == null)
          return;
        this.sp_CargarCotizacionesReporteRowChanging((object) this, new SisaDev_Coti.sp_CargarCotizacionesReporteRowChangeEvent((SisaDev_Coti.sp_CargarCotizacionesReporteRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.sp_CargarCotizacionesReporteRowDeleted == null)
          return;
        this.sp_CargarCotizacionesReporteRowDeleted((object) this, new SisaDev_Coti.sp_CargarCotizacionesReporteRowChangeEvent((SisaDev_Coti.sp_CargarCotizacionesReporteRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.sp_CargarCotizacionesReporteRowDeleting == null)
          return;
        this.sp_CargarCotizacionesReporteRowDeleting((object) this, new SisaDev_Coti.sp_CargarCotizacionesReporteRowChangeEvent((SisaDev_Coti.sp_CargarCotizacionesReporteRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void Removesp_CargarCotizacionesReporteRow(
        SisaDev_Coti.sp_CargarCotizacionesReporteRow row)
      {
        this.Rows.Remove((DataRow) row);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        SisaDev_Coti sisaDevCoti = new SisaDev_Coti();
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
          FixedValue = sisaDevCoti.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (sp_CargarCotizacionesReporteDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = sisaDevCoti.GetSchemaSerializable();
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

    public class sp_CargarCotizacionesReporteRow : DataRow
    {
      private SisaDev_Coti.sp_CargarCotizacionesReporteDataTable tablesp_CargarCotizacionesReporte;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal sp_CargarCotizacionesReporteRow(DataRowBuilder rb)
        : base(rb)
      {
        this.tablesp_CargarCotizacionesReporte = (SisaDev_Coti.sp_CargarCotizacionesReporteDataTable) this.Table;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Guid IdCotizaciones
      {
        get => (Guid) this[this.tablesp_CargarCotizacionesReporte.IdCotizacionesColumn];
        set => this[this.tablesp_CargarCotizacionesReporte.IdCotizacionesColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DateTime FechaCotizaciones
      {
        get => (DateTime) this[this.tablesp_CargarCotizacionesReporte.FechaCotizacionesColumn];
        set => this[this.tablesp_CargarCotizacionesReporte.FechaCotizacionesColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string NoCotizaciones
      {
        get => (string) this[this.tablesp_CargarCotizacionesReporte.NoCotizacionesColumn];
        set => this[this.tablesp_CargarCotizacionesReporte.NoCotizacionesColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Concepto
      {
        get => (string) this[this.tablesp_CargarCotizacionesReporte.ConceptoColumn];
        set => this[this.tablesp_CargarCotizacionesReporte.ConceptoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string NoCotizaciones1
      {
        get => (string) this[this.tablesp_CargarCotizacionesReporte.NoCotizaciones1Column];
        set => this[this.tablesp_CargarCotizacionesReporte.NoCotizaciones1Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Ciudad
      {
        get => (string) this[this.tablesp_CargarCotizacionesReporte.CiudadColumn];
        set => this[this.tablesp_CargarCotizacionesReporte.CiudadColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal CostoCotizaciones
      {
        get
        {
          try
          {
            return (Decimal) this[this.tablesp_CargarCotizacionesReporte.CostoCotizacionesColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'CostoCotizaciones' de la tabla 'sp_CargarCotizacionesReporte' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarCotizacionesReporte.CostoCotizacionesColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Correo
      {
        get => (string) this[this.tablesp_CargarCotizacionesReporte.CorreoColumn];
        set => this[this.tablesp_CargarCotizacionesReporte.CorreoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Creo
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_CargarCotizacionesReporte.CreoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Creo' de la tabla 'sp_CargarCotizacionesReporte' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_CargarCotizacionesReporte.CreoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string NombreContacto
      {
        get => (string) this[this.tablesp_CargarCotizacionesReporte.NombreContactoColumn];
        set => this[this.tablesp_CargarCotizacionesReporte.NombreContactoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string RazonSocial
      {
        get => (string) this[this.tablesp_CargarCotizacionesReporte.RazonSocialColumn];
        set => this[this.tablesp_CargarCotizacionesReporte.RazonSocialColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string DireccionFiscal
      {
        get => (string) this[this.tablesp_CargarCotizacionesReporte.DireccionFiscalColumn];
        set => this[this.tablesp_CargarCotizacionesReporte.DireccionFiscalColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCostoCotizacionesNull() => this.IsNull(this.tablesp_CargarCotizacionesReporte.CostoCotizacionesColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCostoCotizacionesNull() => this[this.tablesp_CargarCotizacionesReporte.CostoCotizacionesColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCreoNull() => this.IsNull(this.tablesp_CargarCotizacionesReporte.CreoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCreoNull() => this[this.tablesp_CargarCotizacionesReporte.CreoColumn] = Convert.DBNull;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class sp_CargarCotizacionesReporteRowChangeEvent : EventArgs
    {
      private SisaDev_Coti.sp_CargarCotizacionesReporteRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public sp_CargarCotizacionesReporteRowChangeEvent(
        SisaDev_Coti.sp_CargarCotizacionesReporteRow row,
        DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDev_Coti.sp_CargarCotizacionesReporteRow Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }
  }
}
