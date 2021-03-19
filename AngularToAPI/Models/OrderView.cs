using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularToAPI.Models
{
    public class OrderView
    {
        public long OrderID { get; set; }
        public string OrderNo { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public string PMethod { get; set; }
        public Nullable<decimal> GTotal { get; set; }
    }
}
