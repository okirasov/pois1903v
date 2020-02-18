using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Model
{
    public class Product : Entity
    {
        public string Name;

        public decimal Price;

        public int CompanyID;
    }
}
