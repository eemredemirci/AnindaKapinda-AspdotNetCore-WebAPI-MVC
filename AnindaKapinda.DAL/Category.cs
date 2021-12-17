using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.DAL
{
    class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
