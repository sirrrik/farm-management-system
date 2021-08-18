using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public  class Treatment
    {
        public int ID { get; set; }
        public int treatment_id { get; set; }
        public string treatment_name { get; set; }
        public string treatment_med { get; set; }
        public string treatment_type { get; set; }
        public int cost { get; set; }

    }
}
