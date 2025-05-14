using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBanHang.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }

        //Khai báo thuộc tính - lập mối kết hợp
        public virtual Categogy Categogy { set; get; }
        public int Discount { set; get; }
    }
}
