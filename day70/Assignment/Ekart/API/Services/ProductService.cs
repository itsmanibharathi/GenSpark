using API.Exceptions;
using API.Models;
using API.Models.Dtos;
using API.Repositorys;
using AutoMapper;

namespace API.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<int, Product> _productRepository;
        private readonly IMapper _mapper;
        private readonly AzureBlobStorageService _blobStorageService;

        public ProductService(IRepository<int,Product> productRepository, IMapper mapper, AzureBlobStorageService blobStorageService) {
            _productRepository = productRepository;
            _mapper = mapper;
            _blobStorageService = blobStorageService;

        }
        public async Task<Product> Add(ProductDto item)
        {
            try
            {
                
                var product = _mapper.Map<Product>(item);
                product.imageUrl = await _blobStorageService.UploadImageAsync(item.UploadImage);
                return await _productRepository.Add(product);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<IEnumerable<Product>> Get()
        {
            try
            {
                return _productRepository.Get();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
