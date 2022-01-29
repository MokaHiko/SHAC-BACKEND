using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sugar_hills_backend.Models.DTOS
{
    public class CreateEmployeeDTO
    {
        public string Name { get; set;  }
        public string Gender { get; set; }
        public string Position { get; set; }
        public float Mobile { get; set; }
    }
}
