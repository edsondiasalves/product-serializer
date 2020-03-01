namespace ProductShowcase.ServiceModels
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public SmartphoneDto SmartphoneDetails { get; set; }
        public BookDto BookDetails { get; set; }
    }
}
