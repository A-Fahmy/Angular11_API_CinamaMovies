using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularToAPI.Models
{
    public class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.OrderItems = new HashSet<OrderItem>();
        }

        public long OrderID { get; set; }
        public string OrderNo { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public string PMethod { get; set; }
        public Nullable<decimal> GTotal { get; set; }

        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        
    }
}
