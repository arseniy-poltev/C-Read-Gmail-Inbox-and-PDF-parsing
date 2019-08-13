using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Resource
{
    class Order
    {
        public string reference;
        public string shipping_date;
        public bool direct;
        public string model;
        public string visual;
        public string unit;
        public string model_color;
        public List<string> printing_color;
    }
}
