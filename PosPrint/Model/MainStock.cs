using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosPrint.Model
{
    class MainStock
    {
        
        public Guid ProductID { get; set; }
       
        public int QuantityInStock { get; set; }
        public virtual Product Product { get; set; }
    }
}
