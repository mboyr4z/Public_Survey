using AutoMapper;
using Entities;
using Entities.Dtos;
using Entities.RequestParameters;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _manager;

        private readonly IMapper _mapper;

        public ProductManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateOneProduct(ProductDtoForInsertion productDto)
        {
            /*Product product = new Product(){
                ProductName = productDto.ProductName,
                Price = productDto.Price,
                CategoryId = productDto.CategoryId
            };*/

            Product product = _mapper.Map<Product>(productDto);


            _manager.Product.Create(product);
            _manager.Save();
        }

        public void DeleteOneProduct(Product product)
        {
            if (product is not null)
            {
                _manager.Product.Delete(product);
                _manager.Save();
            }
        }

        public IEnumerable<Product> GetAllProducts(bool trackChanges)
        {
            return _manager.Product.GetAllProducts(trackChanges);
        }

        public IEnumerable<Product> GetLastestProducts(int n, bool trackChanges)
        {
            return _manager
            .Product
            .FindAll(trackChanges)
            .OrderByDescending(prd => prd.ProductId)
            .Take(n);
        }

        public IEnumerable<Product> GelShowCaseProducts(bool trackChanges)
        {
            return _manager.Product.GetShowCaseProducts(trackChanges);
        }

        public IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters p)
        {
            return _manager.Product.GetAllProductsWithDetails(p);
        }

        public Product? GetOneProduct(int id, bool trackChanges)
        {
            var product = _manager.Product.GetOneProduct(id, trackChanges);

            if (product is null)
            {
                throw new Exception("Not Found");
            }
            return product;
        }

        public ProductDtoForUpdate GetOneProductDtoForUpdate(int id, bool v)
        {
            Product product = GetOneProduct(id, v);
            ProductDtoForUpdate productDtoForUpdate = _mapper.Map<ProductDtoForUpdate>(product);
            return productDtoForUpdate;
        }

        public void UpdateOneProduct(ProductDtoForUpdate productDto)
        {
            // var entity = _manager.Product.GetOneProduct(productDto.ProductId, true);
            // entity.ProductName = productDto.ProductName;
            // entity.Price = productDto.Price;
            // entity.CategoryId = productDto.CategoryId;

            var entity = _mapper.Map<Product>(productDto);
            _manager.Product.UpdateOneProduct(entity);

            _manager.Save();
        }
    }
}