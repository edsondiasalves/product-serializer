namespace ProductShowcase.Entities
{
    public interface IProduct
    {
        int Id { get; set; }
        string Name { get; set; }
        string Type { get; set; }
    }
}