using System;

namespace ProductShowcase.Entities
{
    public class Product : IProduct
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Type { get; set; }
    }
}
