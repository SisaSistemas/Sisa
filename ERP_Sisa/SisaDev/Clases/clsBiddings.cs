using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SisaDev.Clases
{
    public class clsBiddings
    {
        public Guid IdCotizaciones { get; set; }
        public Guid IdEmpresa { get; set; }
        public string RazonSocial { get; set; }
        public string RFC { get; set; }
        public string Cliente { get; set; }
        public string NoCotizaciones { get; set; }
        public string Concepto { get; set; }
        public int Estatus { get; set; }
        public decimal CostoCotizaciones { get; set; }
        public DateTime FechaCotizaciones { get; set; }
        public string Estilo { get; set; }
    }
}