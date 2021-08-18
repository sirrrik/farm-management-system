using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
     public class CPemp
    {
        public int ID { get; set; }
        public int CowId { get; set; }
        public string Age { get; set; }
        public string Breed { get; set; }
        public string Health { get; set; }
       
        public DateTime DateOfBirth { get; set; }
    }
}
