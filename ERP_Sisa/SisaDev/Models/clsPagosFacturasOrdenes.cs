using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SisaDev.Models
{
    public class clsPagosFacturasOrdenes : sp_SelectPagosFacturasOrdenes_Result
    {
        public bool esRoot { get; set; }
    }
}