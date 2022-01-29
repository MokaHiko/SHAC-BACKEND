using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sugar_hills_backend.Models.DTOS
{
    public class ShacTimeCardDTO
    {
        public int ID { get; set; }
        public string Name { get; set;  }
        public string Gender { get; set; }
        public string Position { get; set; }
        public float Mobile { get; set; }
        public DateTime TimeIn{ get; set; }
        public DateTime TimeOut{ get; set; }
    }
}
