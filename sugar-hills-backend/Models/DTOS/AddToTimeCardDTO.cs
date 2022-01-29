using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sugar_hills_backend.Models.DTOS
{
    public class AddToTimeCardDTO
    {
        public int EmployeeID { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
    }
}
