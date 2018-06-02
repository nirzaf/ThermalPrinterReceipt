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

       public static  decimal Tax {

            get { return 0.175m ; }
            set { }
        }

       public static decimal Discount
       {
            get { return 0.05m; }
            set { }
       }

 
        //Acts as an in memory db  
        public static List<Order> orders = new List<Order>();
    }
}
