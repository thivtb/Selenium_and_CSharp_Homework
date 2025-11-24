using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c__basic_SD5858_VoThiBeThi_section1.PageObjectModel
{
    public class ProductInfo
    {
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Total => Price * Quantity;
    }
}
