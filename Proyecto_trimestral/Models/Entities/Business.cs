using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_trimestral.Models.Entities
{
    public class Business
    {
        public int id { get; set; }
        public List<Customers> customers  { get; set; }
        public int categories { get; set; }
        public List<Products> products { get; set; }
        public List<Services> services { get; set; }
        public string name { get; set; }

    }
}
