namespace Entities.RequestParameters
{
    public class ProductRequestParameters : RequestParameters
    {
        public int? CategoryId { get; set; }
        public int MinPrice { get; set; } = 0;
        public int MaxPrice{get;set;} = int.MaxValue;
        public bool IsValidPrice => MaxPrice > MinPrice;
        
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public ProductRequestParameters(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public ProductRequestParameters() : this(1,6)   // boş nesne çalıştırmaya çalışan olursa diğer rcoonsta böyle yönlendir, alternatif olarak ta parametreye = ile default değer ver
        {
            
        }
    }
}