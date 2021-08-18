using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
     public class Sales
    {
        public int ID { get; set; }
        public int CowId { get; set; }
        public DateTime Date { get; set; }
        public string Amount { get; set; }

    }
}
