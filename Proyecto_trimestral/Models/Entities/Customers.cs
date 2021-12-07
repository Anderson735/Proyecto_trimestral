using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_trimestral.Models.Entities
{
    public class Customers
    {
        public string document { get; set; }
        public string document_type { get; set; }
        public string name1 { get; set; }
        public string name2 { get; set; }
        public string last_name1 { get; set; }
        public string last_name2 { get; set; }
        public List<Business> Businesses { get; set; }
    }
}
