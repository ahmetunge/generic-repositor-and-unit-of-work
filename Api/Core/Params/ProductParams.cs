namespace Api.Core.Params
{
    public class ProductParams
    {
        private const int MaxPageSize = 50;
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }

        public string Sort { get; set; }

        private int _pageSize = 6;
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }

        public int PageIndex { get; set; } = 1;
    }
}