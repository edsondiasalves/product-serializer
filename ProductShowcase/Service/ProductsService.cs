using AutoMapper;
using ProductShowcase.Entities;
using ProductShowcase.ServiceModels;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ProductShowcase.Service
{
    public class ProductsService : IProductsService
    {
        private IMapper _mapper;
        private string CurrentPath = Directory.GetCurrentDirectory();

        public ProductsService(IMapper mapper) {
            this._mapper = mapper;
        }

        public IEnumerable<IProduct> GetAllProducts()
        {
            string jsonFile = @"/Data/Products.json";
            string textProducts = File.ReadAllText($"{this.CurrentPath}{jsonFile}");

            List<ProductDto> productsDto = JsonSerializer.Deserialize<List<ProductDto>>(textProducts);
            List<IProduct> products = new List<IProduct>();

            foreach (ProductDto genericProduct in productsDto)
            {
                switch (genericProduct.Type) {
                    case "Smartphone":
                        Smartphone smartphone = _mapper.Map<Smartphone>(genericProduct);
                        products.Add(smartphone);
                        break;
                    case "Book":
                        Book book = _mapper.Map<Book>(genericProduct);
                        products.Add(book);
                        break;
                    default:
                        break;
                }
            }
            
            return products;
        }
    }
}
