using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
     public class Milk
    {
        public int ID { get; set; }
        public int CowId { get; set; }
        public DateTime Date { get; set; }
        public int Morning { get; set; }
        public int Evening { get; set; }
        public int Total  { get; set; }
        public int Average { get; set; }
    }
}
