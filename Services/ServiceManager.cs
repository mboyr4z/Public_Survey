using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IProductService _productService;

        private readonly IAuthService _authService;



        public ServiceManager(IProductService productService, IAuthService authService)
        {
            _productService = productService;
            _authService = authService;
        }

        public IProductService ProductService => _productService;
        public IAuthService AuthService => _authService;
    }
}