using Api.Core.Entities;
using Api.Core.Params;

namespace Api.Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(ProductParams productParams) : base(x =>
            (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
            (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
        )
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
            AddOrderByAsc(p => p.Name);

            switch (productParams.Sort)
            {
                case "idAsc":
                    AddOrderByAsc(p => p.Id);
                    break;
                case "idDesc":
                    AddOrderByDesc(p => p.Id);
                    break;
                default:
                    AddOrderByAsc(p => p.Name);
                    break;
            }
        }
        public ProductsWithTypesAndBrandsSpecification(int id) : base(p => p.Id == id)
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
        }
        public ProductsWithTypesAndBrandsSpecification()
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
        }
    }
}