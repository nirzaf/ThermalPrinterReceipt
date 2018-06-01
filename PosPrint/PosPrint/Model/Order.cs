using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosPrint
{
   public class Order
    {
        public Order()
        {
           RecieptNumber = Guid.NewGuid();
        }
    
      public Guid RecieptNumber { get; set; }
      public string ProductName { get; set; }
      public string ProductDescribtion { get; set; }
      public decimal Quantity { get; set; }
      public decimal Price { get; set; }
      public decimal Amount
        {
            get { return Quantity * Price; }
        }
    }
}
