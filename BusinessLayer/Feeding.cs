using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
     public class Feeding
    {
        public int ID { get; set; }
        public int Feeding_id { get; set; }
        public int Housing_id { get; set; }
        public int CowID { get; set; }
        public int food_id { get; set; }
        public string quantity { get; set; }
        
    }
}
