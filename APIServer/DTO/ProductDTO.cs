using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIServer.Model;

namespace APIServer.DTO
{
    public class ProductDTO : EntityDTO
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int? CompanyID { get; set; }

        public ProductDTO(Product p)
        {
            if (p != null)
            {
                ID = p.ID;
                Name = p.Name;
                Price = p.Price;
                CompanyID = p.Company?.ID;
            }
        }
    }
}
