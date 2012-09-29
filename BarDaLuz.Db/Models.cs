using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BarDaLuz.Db
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsEntrance { get; set; }
        public virtual List<ProductTab> ProductTab { get; set; }
    }

    public class Tab
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public bool Paid { get; set; }
        public virtual List<ProductTab> ProductTab { get; set; }
    }

    public class ProductTab
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int TabId { get; set; }
        public virtual Tab Tab { get; set; }
    }
}
