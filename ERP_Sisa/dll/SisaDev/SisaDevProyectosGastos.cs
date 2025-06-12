// Decompiled with JetBrains decompiler
// Type: SisaDev.SisaDevProyectosGastos
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
  [XmlRoot("SisaDevProyectosGastos")]
  [HelpKeyword("vs.data.DataSet")]
  [Serializable]
  public class SisaDevProyectosGastos : DataSet
  {
    private SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasDataTable tablesp_ReporteProyectosGastosVistas;
    private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public SisaDevProyectosGastos()
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
    protected SisaDevProyectosGastos(SerializationInfo info, StreamingContext context)
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
          if (dataSet.Tables[nameof (sp_ReporteProyectosGastosVistas)] != null)
            base.Tables.Add((DataTable) new SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasDataTable(dataSet.Tables[nameof (sp_ReporteProyectosGastosVistas)]));
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
    public SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasDataTable sp_ReporteProyectosGastosVistas => this.tablesp_ReporteProyectosGastosVistas;

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
      SisaDevProyectosGastos devProyectosGastos = (SisaDevProyectosGastos) base.Clone();
      devProyectosGastos.InitVars();
      devProyectosGastos.SchemaSerializationMode = this.SchemaSerializationMode;
      return (DataSet) devProyectosGastos;
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
        if (dataSet.Tables["sp_ReporteProyectosGastosVistas"] != null)
          base.Tables.Add((DataTable) new SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasDataTable(dataSet.Tables["sp_ReporteProyectosGastosVistas"]));
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
      this.tablesp_ReporteProyectosGastosVistas = (SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasDataTable) base.Tables["sp_ReporteProyectosGastosVistas"];
      if (!initTable || this.tablesp_ReporteProyectosGastosVistas == null)
        return;
      this.tablesp_ReporteProyectosGastosVistas.InitVars();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private void InitClass()
    {
      this.DataSetName = nameof (SisaDevProyectosGastos);
      this.Prefix = "";
      this.Namespace = "http://tempuri.org/SisaDevProyectosGastos.xsd";
      this.EnforceConstraints = true;
      this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      this.tablesp_ReporteProyectosGastosVistas = new SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasDataTable();
      base.Tables.Add((DataTable) this.tablesp_ReporteProyectosGastosVistas);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializesp_ReporteProyectosGastosVistas() => false;

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
      SisaDevProyectosGastos devProyectosGastos = new SisaDevProyectosGastos();
      XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
      XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
      xmlSchemaSequence.Items.Add((XmlSchemaObject) new XmlSchemaAny()
      {
        Namespace = devProyectosGastos.Namespace
      });
      schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
      XmlSchema schemaSerializable = devProyectosGastos.GetSchemaSerializable();
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
    public delegate void sp_ReporteProyectosGastosVistasRowChangeEventHandler(
      object sender,
      SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasRowChangeEvent e);

    [XmlSchemaProvider("GetTypedTableSchema")]
    [Serializable]
    public class sp_ReporteProyectosGastosVistasDataTable : 
      TypedTableBase<SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasRow>
    {
      private DataColumn columnid;
      private DataColumn columnFechaCreacion;
      private DataColumn columnFolio;
      private DataColumn columnFechaInicio;
      private DataColumn columnFechaFin;
      private DataColumn columnLider;
      private DataColumn columnNombreProyecto;
      private DataColumn columnEstatus;
      private DataColumn columnCostoCotizacion;
      private DataColumn columnRazonSocial;
      private DataColumn columnNombreContacto;
      private DataColumn columnOC;
      private DataColumn columnCL;
      private DataColumn columnFacturado;
      private DataColumn columnPorcentaje;
      private DataColumn columnPagado;
      private DataColumn columnPorcentajePagado;
      private DataColumn columnGastos;
      private DataColumn columnOCNumero;
      private DataColumn columnOCPend;
      private DataColumn columnFacturas;
      private DataColumn columnManoObra;
      private DataColumn columnViaticos;
      private DataColumn columnCajaChica;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public sp_ReporteProyectosGastosVistasDataTable()
      {
        this.TableName = "sp_ReporteProyectosGastosVistas";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal sp_ReporteProyectosGastosVistasDataTable(DataTable table)
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
      protected sp_ReporteProyectosGastosVistasDataTable(
        SerializationInfo info,
        StreamingContext context)
        : base(info, context)
      {
        this.InitVars();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn idColumn => this.columnid;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FechaCreacionColumn => this.columnFechaCreacion;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FolioColumn => this.columnFolio;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FechaInicioColumn => this.columnFechaInicio;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FechaFinColumn => this.columnFechaFin;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn LiderColumn => this.columnLider;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn NombreProyectoColumn => this.columnNombreProyecto;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn EstatusColumn => this.columnEstatus;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CostoCotizacionColumn => this.columnCostoCotizacion;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn RazonSocialColumn => this.columnRazonSocial;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn NombreContactoColumn => this.columnNombreContacto;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn OCColumn => this.columnOC;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CLColumn => this.columnCL;

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
      public DataColumn GastosColumn => this.columnGastos;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn OCNumeroColumn => this.columnOCNumero;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn OCPendColumn => this.columnOCPend;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FacturasColumn => this.columnFacturas;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ManoObraColumn => this.columnManoObra;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ViaticosColumn => this.columnViaticos;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CajaChicaColumn => this.columnCajaChica;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasRow this[
        int index]
      {
        return (SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasRow) this.Rows[index];
      }

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasRowChangeEventHandler sp_ReporteProyectosGastosVistasRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasRowChangeEventHandler sp_ReporteProyectosGastosVistasRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasRowChangeEventHandler sp_ReporteProyectosGastosVistasRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasRowChangeEventHandler sp_ReporteProyectosGastosVistasRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void Addsp_ReporteProyectosGastosVistasRow(
        SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasRow row)
      {
        this.Rows.Add((DataRow) row);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasRow Addsp_ReporteProyectosGastosVistasRow(
        DateTime FechaCreacion,
        string Folio,
        string FechaInicio,
        string FechaFin,
        string Lider,
        string NombreProyecto,
        string Estatus,
        Decimal CostoCotizacion,
        string RazonSocial,
        string NombreContacto,
        string OC,
        string CL,
        Decimal Facturado,
        Decimal Porcentaje,
        Decimal Pagado,
        Decimal PorcentajePagado,
        Decimal Gastos,
        Decimal OCNumero,
        Decimal OCPend,
        Decimal Facturas,
        Decimal ManoObra,
        Decimal Viaticos,
        Decimal CajaChica)
      {
        SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasRow proyectosGastosVistasRow = (SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasRow) this.NewRow();
        object[] objArray = new object[24]
        {
          null,
          (object) FechaCreacion,
          (object) Folio,
          (object) FechaInicio,
          (object) FechaFin,
          (object) Lider,
          (object) NombreProyecto,
          (object) Estatus,
          (object) CostoCotizacion,
          (object) RazonSocial,
          (object) NombreContacto,
          (object) OC,
          (object) CL,
          (object) Facturado,
          (object) Porcentaje,
          (object) Pagado,
          (object) PorcentajePagado,
          (object) Gastos,
          (object) OCNumero,
          (object) OCPend,
          (object) Facturas,
          (object) ManoObra,
          (object) Viaticos,
          (object) CajaChica
        };
        proyectosGastosVistasRow.ItemArray = objArray;
        this.Rows.Add((DataRow) proyectosGastosVistasRow);
        return proyectosGastosVistasRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasRow FindByid(
        int id)
      {
        return (SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasRow) this.Rows.Find(new object[1]
        {
          (object) id
        });
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasDataTable gastosVistasDataTable = (SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasDataTable) base.Clone();
        gastosVistasDataTable.InitVars();
        return (DataTable) gastosVistasDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasDataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnid = this.Columns["id"];
        this.columnFechaCreacion = this.Columns["FechaCreacion"];
        this.columnFolio = this.Columns["Folio"];
        this.columnFechaInicio = this.Columns["FechaInicio"];
        this.columnFechaFin = this.Columns["FechaFin"];
        this.columnLider = this.Columns["Lider"];
        this.columnNombreProyecto = this.Columns["NombreProyecto"];
        this.columnEstatus = this.Columns["Estatus"];
        this.columnCostoCotizacion = this.Columns["CostoCotizacion"];
        this.columnRazonSocial = this.Columns["RazonSocial"];
        this.columnNombreContacto = this.Columns["NombreContacto"];
        this.columnOC = this.Columns["OC"];
        this.columnCL = this.Columns["CL"];
        this.columnFacturado = this.Columns["Facturado"];
        this.columnPorcentaje = this.Columns["Porcentaje"];
        this.columnPagado = this.Columns["Pagado"];
        this.columnPorcentajePagado = this.Columns["PorcentajePagado"];
        this.columnGastos = this.Columns["Gastos"];
        this.columnOCNumero = this.Columns["OCNumero"];
        this.columnOCPend = this.Columns["OCPend"];
        this.columnFacturas = this.Columns["Facturas"];
        this.columnManoObra = this.Columns["ManoObra"];
        this.columnViaticos = this.Columns["Viaticos"];
        this.columnCajaChica = this.Columns["CajaChica"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnid = new DataColumn("id", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnid);
        this.columnFechaCreacion = new DataColumn("FechaCreacion", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFechaCreacion);
        this.columnFolio = new DataColumn("Folio", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFolio);
        this.columnFechaInicio = new DataColumn("FechaInicio", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFechaInicio);
        this.columnFechaFin = new DataColumn("FechaFin", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFechaFin);
        this.columnLider = new DataColumn("Lider", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnLider);
        this.columnNombreProyecto = new DataColumn("NombreProyecto", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNombreProyecto);
        this.columnEstatus = new DataColumn("Estatus", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEstatus);
        this.columnCostoCotizacion = new DataColumn("CostoCotizacion", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCostoCotizacion);
        this.columnRazonSocial = new DataColumn("RazonSocial", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnRazonSocial);
        this.columnNombreContacto = new DataColumn("NombreContacto", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNombreContacto);
        this.columnOC = new DataColumn("OC", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnOC);
        this.columnCL = new DataColumn("CL", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCL);
        this.columnFacturado = new DataColumn("Facturado", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFacturado);
        this.columnPorcentaje = new DataColumn("Porcentaje", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPorcentaje);
        this.columnPagado = new DataColumn("Pagado", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPagado);
        this.columnPorcentajePagado = new DataColumn("PorcentajePagado", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPorcentajePagado);
        this.columnGastos = new DataColumn("Gastos", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnGastos);
        this.columnOCNumero = new DataColumn("OCNumero", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnOCNumero);
        this.columnOCPend = new DataColumn("OCPend", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnOCPend);
        this.columnFacturas = new DataColumn("Facturas", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFacturas);
        this.columnManoObra = new DataColumn("ManoObra", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnManoObra);
        this.columnViaticos = new DataColumn("Viaticos", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnViaticos);
        this.columnCajaChica = new DataColumn("CajaChica", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCajaChica);
        this.Constraints.Add((Constraint) new UniqueConstraint("Constraint1", new DataColumn[1]
        {
          this.columnid
        }, true));
        this.columnid.AutoIncrement = true;
        this.columnid.AllowDBNull = false;
        this.columnid.ReadOnly = true;
        this.columnid.Unique = true;
        this.columnFolio.MaxLength = 150;
        this.columnFechaInicio.MaxLength = 50;
        this.columnFechaFin.MaxLength = 50;
        this.columnLider.MaxLength = 150;
        this.columnNombreProyecto.MaxLength = int.MaxValue;
        this.columnEstatus.MaxLength = 50;
        this.columnRazonSocial.MaxLength = 500;
        this.columnNombreContacto.MaxLength = 500;
        this.columnOC.MaxLength = 50;
        this.columnCL.MaxLength = 50;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasRow Newsp_ReporteProyectosGastosVistasRow() => (SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasRow(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.sp_ReporteProyectosGastosVistasRowChanged == null)
          return;
        this.sp_ReporteProyectosGastosVistasRowChanged((object) this, new SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasRowChangeEvent((SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.sp_ReporteProyectosGastosVistasRowChanging == null)
          return;
        this.sp_ReporteProyectosGastosVistasRowChanging((object) this, new SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasRowChangeEvent((SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.sp_ReporteProyectosGastosVistasRowDeleted == null)
          return;
        this.sp_ReporteProyectosGastosVistasRowDeleted((object) this, new SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasRowChangeEvent((SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.sp_ReporteProyectosGastosVistasRowDeleting == null)
          return;
        this.sp_ReporteProyectosGastosVistasRowDeleting((object) this, new SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasRowChangeEvent((SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void Removesp_ReporteProyectosGastosVistasRow(
        SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasRow row)
      {
        this.Rows.Remove((DataRow) row);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        SisaDevProyectosGastos devProyectosGastos = new SisaDevProyectosGastos();
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
          FixedValue = devProyectosGastos.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (sp_ReporteProyectosGastosVistasDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = devProyectosGastos.GetSchemaSerializable();
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

    public class sp_ReporteProyectosGastosVistasRow : DataRow
    {
      private SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasDataTable tablesp_ReporteProyectosGastosVistas;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal sp_ReporteProyectosGastosVistasRow(DataRowBuilder rb)
        : base(rb)
      {
        this.tablesp_ReporteProyectosGastosVistas = (SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasDataTable) this.Table;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int id
      {
        get => (int) this[this.tablesp_ReporteProyectosGastosVistas.idColumn];
        set => this[this.tablesp_ReporteProyectosGastosVistas.idColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DateTime FechaCreacion
      {
        get
        {
          try
          {
            return (DateTime) this[this.tablesp_ReporteProyectosGastosVistas.FechaCreacionColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'FechaCreacion' de la tabla 'sp_ReporteProyectosGastosVistas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_ReporteProyectosGastosVistas.FechaCreacionColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Folio
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_ReporteProyectosGastosVistas.FolioColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Folio' de la tabla 'sp_ReporteProyectosGastosVistas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_ReporteProyectosGastosVistas.FolioColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string FechaInicio
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_ReporteProyectosGastosVistas.FechaInicioColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'FechaInicio' de la tabla 'sp_ReporteProyectosGastosVistas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_ReporteProyectosGastosVistas.FechaInicioColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string FechaFin
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_ReporteProyectosGastosVistas.FechaFinColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'FechaFin' de la tabla 'sp_ReporteProyectosGastosVistas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_ReporteProyectosGastosVistas.FechaFinColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Lider
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_ReporteProyectosGastosVistas.LiderColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Lider' de la tabla 'sp_ReporteProyectosGastosVistas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_ReporteProyectosGastosVistas.LiderColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string NombreProyecto
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_ReporteProyectosGastosVistas.NombreProyectoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'NombreProyecto' de la tabla 'sp_ReporteProyectosGastosVistas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_ReporteProyectosGastosVistas.NombreProyectoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Estatus
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_ReporteProyectosGastosVistas.EstatusColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Estatus' de la tabla 'sp_ReporteProyectosGastosVistas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_ReporteProyectosGastosVistas.EstatusColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal CostoCotizacion
      {
        get
        {
          try
          {
            return (Decimal) this[this.tablesp_ReporteProyectosGastosVistas.CostoCotizacionColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'CostoCotizacion' de la tabla 'sp_ReporteProyectosGastosVistas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_ReporteProyectosGastosVistas.CostoCotizacionColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string RazonSocial
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_ReporteProyectosGastosVistas.RazonSocialColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'RazonSocial' de la tabla 'sp_ReporteProyectosGastosVistas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_ReporteProyectosGastosVistas.RazonSocialColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string NombreContacto
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_ReporteProyectosGastosVistas.NombreContactoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'NombreContacto' de la tabla 'sp_ReporteProyectosGastosVistas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_ReporteProyectosGastosVistas.NombreContactoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string OC
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_ReporteProyectosGastosVistas.OCColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'OC' de la tabla 'sp_ReporteProyectosGastosVistas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_ReporteProyectosGastosVistas.OCColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string CL
      {
        get
        {
          try
          {
            return (string) this[this.tablesp_ReporteProyectosGastosVistas.CLColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'CL' de la tabla 'sp_ReporteProyectosGastosVistas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_ReporteProyectosGastosVistas.CLColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal Facturado
      {
        get
        {
          try
          {
            return (Decimal) this[this.tablesp_ReporteProyectosGastosVistas.FacturadoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Facturado' de la tabla 'sp_ReporteProyectosGastosVistas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_ReporteProyectosGastosVistas.FacturadoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal Porcentaje
      {
        get
        {
          try
          {
            return (Decimal) this[this.tablesp_ReporteProyectosGastosVistas.PorcentajeColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Porcentaje' de la tabla 'sp_ReporteProyectosGastosVistas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_ReporteProyectosGastosVistas.PorcentajeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal Pagado
      {
        get
        {
          try
          {
            return (Decimal) this[this.tablesp_ReporteProyectosGastosVistas.PagadoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Pagado' de la tabla 'sp_ReporteProyectosGastosVistas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_ReporteProyectosGastosVistas.PagadoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal PorcentajePagado
      {
        get
        {
          try
          {
            return (Decimal) this[this.tablesp_ReporteProyectosGastosVistas.PorcentajePagadoColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'PorcentajePagado' de la tabla 'sp_ReporteProyectosGastosVistas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_ReporteProyectosGastosVistas.PorcentajePagadoColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal Gastos
      {
        get
        {
          try
          {
            return (Decimal) this[this.tablesp_ReporteProyectosGastosVistas.GastosColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Gastos' de la tabla 'sp_ReporteProyectosGastosVistas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_ReporteProyectosGastosVistas.GastosColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal OCNumero
      {
        get
        {
          try
          {
            return (Decimal) this[this.tablesp_ReporteProyectosGastosVistas.OCNumeroColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'OCNumero' de la tabla 'sp_ReporteProyectosGastosVistas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_ReporteProyectosGastosVistas.OCNumeroColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal OCPend
      {
        get
        {
          try
          {
            return (Decimal) this[this.tablesp_ReporteProyectosGastosVistas.OCPendColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'OCPend' de la tabla 'sp_ReporteProyectosGastosVistas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_ReporteProyectosGastosVistas.OCPendColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal Facturas
      {
        get
        {
          try
          {
            return (Decimal) this[this.tablesp_ReporteProyectosGastosVistas.FacturasColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Facturas' de la tabla 'sp_ReporteProyectosGastosVistas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_ReporteProyectosGastosVistas.FacturasColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal ManoObra
      {
        get
        {
          try
          {
            return (Decimal) this[this.tablesp_ReporteProyectosGastosVistas.ManoObraColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'ManoObra' de la tabla 'sp_ReporteProyectosGastosVistas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_ReporteProyectosGastosVistas.ManoObraColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal Viaticos
      {
        get
        {
          try
          {
            return (Decimal) this[this.tablesp_ReporteProyectosGastosVistas.ViaticosColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'Viaticos' de la tabla 'sp_ReporteProyectosGastosVistas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_ReporteProyectosGastosVistas.ViaticosColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal CajaChica
      {
        get
        {
          try
          {
            return (Decimal) this[this.tablesp_ReporteProyectosGastosVistas.CajaChicaColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("El valor de la columna 'CajaChica' de la tabla 'sp_ReporteProyectosGastosVistas' es DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablesp_ReporteProyectosGastosVistas.CajaChicaColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFechaCreacionNull() => this.IsNull(this.tablesp_ReporteProyectosGastosVistas.FechaCreacionColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFechaCreacionNull() => this[this.tablesp_ReporteProyectosGastosVistas.FechaCreacionColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFolioNull() => this.IsNull(this.tablesp_ReporteProyectosGastosVistas.FolioColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFolioNull() => this[this.tablesp_ReporteProyectosGastosVistas.FolioColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFechaInicioNull() => this.IsNull(this.tablesp_ReporteProyectosGastosVistas.FechaInicioColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFechaInicioNull() => this[this.tablesp_ReporteProyectosGastosVistas.FechaInicioColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFechaFinNull() => this.IsNull(this.tablesp_ReporteProyectosGastosVistas.FechaFinColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFechaFinNull() => this[this.tablesp_ReporteProyectosGastosVistas.FechaFinColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsLiderNull() => this.IsNull(this.tablesp_ReporteProyectosGastosVistas.LiderColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetLiderNull() => this[this.tablesp_ReporteProyectosGastosVistas.LiderColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNombreProyectoNull() => this.IsNull(this.tablesp_ReporteProyectosGastosVistas.NombreProyectoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNombreProyectoNull() => this[this.tablesp_ReporteProyectosGastosVistas.NombreProyectoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsEstatusNull() => this.IsNull(this.tablesp_ReporteProyectosGastosVistas.EstatusColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetEstatusNull() => this[this.tablesp_ReporteProyectosGastosVistas.EstatusColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCostoCotizacionNull() => this.IsNull(this.tablesp_ReporteProyectosGastosVistas.CostoCotizacionColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCostoCotizacionNull() => this[this.tablesp_ReporteProyectosGastosVistas.CostoCotizacionColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsRazonSocialNull() => this.IsNull(this.tablesp_ReporteProyectosGastosVistas.RazonSocialColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetRazonSocialNull() => this[this.tablesp_ReporteProyectosGastosVistas.RazonSocialColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNombreContactoNull() => this.IsNull(this.tablesp_ReporteProyectosGastosVistas.NombreContactoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNombreContactoNull() => this[this.tablesp_ReporteProyectosGastosVistas.NombreContactoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsOCNull() => this.IsNull(this.tablesp_ReporteProyectosGastosVistas.OCColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetOCNull() => this[this.tablesp_ReporteProyectosGastosVistas.OCColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCLNull() => this.IsNull(this.tablesp_ReporteProyectosGastosVistas.CLColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCLNull() => this[this.tablesp_ReporteProyectosGastosVistas.CLColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFacturadoNull() => this.IsNull(this.tablesp_ReporteProyectosGastosVistas.FacturadoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFacturadoNull() => this[this.tablesp_ReporteProyectosGastosVistas.FacturadoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPorcentajeNull() => this.IsNull(this.tablesp_ReporteProyectosGastosVistas.PorcentajeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPorcentajeNull() => this[this.tablesp_ReporteProyectosGastosVistas.PorcentajeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPagadoNull() => this.IsNull(this.tablesp_ReporteProyectosGastosVistas.PagadoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPagadoNull() => this[this.tablesp_ReporteProyectosGastosVistas.PagadoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPorcentajePagadoNull() => this.IsNull(this.tablesp_ReporteProyectosGastosVistas.PorcentajePagadoColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPorcentajePagadoNull() => this[this.tablesp_ReporteProyectosGastosVistas.PorcentajePagadoColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsGastosNull() => this.IsNull(this.tablesp_ReporteProyectosGastosVistas.GastosColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetGastosNull() => this[this.tablesp_ReporteProyectosGastosVistas.GastosColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsOCNumeroNull() => this.IsNull(this.tablesp_ReporteProyectosGastosVistas.OCNumeroColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetOCNumeroNull() => this[this.tablesp_ReporteProyectosGastosVistas.OCNumeroColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsOCPendNull() => this.IsNull(this.tablesp_ReporteProyectosGastosVistas.OCPendColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetOCPendNull() => this[this.tablesp_ReporteProyectosGastosVistas.OCPendColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFacturasNull() => this.IsNull(this.tablesp_ReporteProyectosGastosVistas.FacturasColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFacturasNull() => this[this.tablesp_ReporteProyectosGastosVistas.FacturasColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsManoObraNull() => this.IsNull(this.tablesp_ReporteProyectosGastosVistas.ManoObraColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetManoObraNull() => this[this.tablesp_ReporteProyectosGastosVistas.ManoObraColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsViaticosNull() => this.IsNull(this.tablesp_ReporteProyectosGastosVistas.ViaticosColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetViaticosNull() => this[this.tablesp_ReporteProyectosGastosVistas.ViaticosColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCajaChicaNull() => this.IsNull(this.tablesp_ReporteProyectosGastosVistas.CajaChicaColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCajaChicaNull() => this[this.tablesp_ReporteProyectosGastosVistas.CajaChicaColumn] = Convert.DBNull;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class sp_ReporteProyectosGastosVistasRowChangeEvent : EventArgs
    {
      private SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public sp_ReporteProyectosGastosVistasRowChangeEvent(
        SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasRow row,
        DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SisaDevProyectosGastos.sp_ReporteProyectosGastosVistasRow Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }
  }
}
