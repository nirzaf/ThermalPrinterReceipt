using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosPrint.Model
{
    public class Business
    {
        public int BusinessId { get; set; }
        public string BusinessName { get; set; }
        public string Phone { get; set; }
        public string Branch { get; set; }
        public string Location { get; set; }

        //In memory store for business 
        public static List<Business> Businesses = new List<Business>();
    }
}
