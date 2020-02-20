using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Model
{
    public abstract class Entity
    {
        public int ID { get; set; }
    }
}
