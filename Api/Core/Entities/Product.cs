namespace Api.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public int ProductTypeId { get; set; }

        public ProductType ProductType { get; set; }

        public int ProductBrandId { get; set; }

        public ProductBrand ProductBrand { get; set; }
    }
}