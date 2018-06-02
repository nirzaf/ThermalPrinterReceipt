using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosPrint.Model
{
    class StockHistory
    {
        public Guid HistoryID { get; set; }

        public float Quantity { get; set; }
        
        public DateTime DateReceived { get; set; }
        public Guid ProductID { get; set; }
        public Product Product { get; set; }

    }
}
