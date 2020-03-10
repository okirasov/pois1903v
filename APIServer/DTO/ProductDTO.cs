using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIServer.DTO
{
    public class ProductDTO : EntityDTO
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int CompanyID { get; set; }
    }
}
