using Entities;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Repositories.Contracts;
using Repositories.Extensions;

namespace Repositories
{
    public sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateProduct(Product product) => Create(product);

       
        public void Delete(Product product) => Remove(product);
        

        
        public IQueryable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges);

        public IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters pr)
        {
            return GetAllProducts(false)
            .FilteredByCategoryId(pr.CategoryId)
            .FilteredBySearchTerm(pr.SearchTerm)
            .FilteredByPrice(pr.MinPrice, pr.MaxPrice, pr.IsValidPrice)
            .ToPaginate(pr.PageNumber, pr.PageSize);
        }

        public Product GetOneProduct(int id, bool trackChanges){
            return FindByCondition(p => p.ProductId.Equals(id), trackChanges);
        }

        public IQueryable<Product> GetShowCaseProducts(bool trackChanges)
        {
            return FindAll(trackChanges)
            .Where(p => p.Showcase.Equals(true));
        }

        public void UpdateOneProduct(Product entity) => Update(entity);
        
    }
}