using AutoMapper;
using ProductShowcase.Entities;
using ProductShowcase.ServiceModels;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Threading.Tasks;

namespace ProductShowcase.Service
{
    public class ProductsService : IProductsService
    {
        private IMapper _mapper;
        private string CurrentPath = Directory.GetCurrentDirectory();

        public ProductsService(IMapper mapper) {
            this._mapper = mapper;
        }

        public IEnumerable<IProduct> GetAllProducts(CastingScheme scheme = CastingScheme.Sequencially)
        {
            string jsonFile = @"/Data/Products.json";
            string textProducts = File.ReadAllText($"{this.CurrentPath}{jsonFile}");

            List<ProductDto> productsDto = JsonSerializer.Deserialize<List<ProductDto>>(textProducts);
            
            if (scheme == CastingScheme.Sequencially)
                return GetAllProductsCastingSequencialy(productsDto);   
            else
                return GetAllProductsCastingByChunks(productsDto);
        }

        private IEnumerable<IProduct> GetAllProductsCastingSequencialy(List<ProductDto> productsDto)
        {
            List<IProduct> products = new List<IProduct>();

            Parallel.ForEach(productsDto, (p) => {
                switch (p.Type)
                {
                    case "Smartphone":
                        Smartphone smartphone = _mapper.Map<Smartphone>(p);
                        products.Add(smartphone);
                        break;
                    case "Book":
                        Book book = _mapper.Map<Book>(p);
                        products.Add(book);
                        break;
                    default:
                        break;
                }
            });

            return products;
        }

        private IEnumerable<IProduct> GetAllProductsCastingByChunks(List<ProductDto> productsDto)
        {
            List<IProduct> products = new List<IProduct>();
            
            var books = productsDto.Where(w => w.Type.Equals("Book")).ToList();
            var smartphones = productsDto.Where(w => w.Type.Equals("Smartphone")).ToList();
            
            products.AddRange(_mapper.Map<List<Book>>(books));
            products.AddRange(_mapper.Map<List<Smartphone>>(smartphones));

            return products;
        }
    }
}
