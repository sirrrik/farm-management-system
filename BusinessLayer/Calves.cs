using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
     public class Calves
    {
        public int ID { get; set; }
         public int CalfID { get; set; }
          public int CowID { get; set; }
        public string Gender { get; set; }
        public string Breed { get; set; }
        public string Health{ get; set; }
          public DateTime BirthDate{ get; set; }
    }
}
	