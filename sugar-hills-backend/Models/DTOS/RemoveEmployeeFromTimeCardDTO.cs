using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sugar_hills_backend.Models.DTOS
{
    public class RemoveEmployeeFromTimeCardDTO
    {
        public int ID { get; set; }
        public DateTime TimeIn { get; set; }
    }
}
