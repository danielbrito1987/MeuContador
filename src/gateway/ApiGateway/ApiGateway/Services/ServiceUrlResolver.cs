using ApiGateway.Services.Interfaces;

namespace ApiGateway.Services
{
    public class ServiceUrlResolver : IServuceUrlResolver
    {
        private readonly IConfiguration _config;

        public ServiceUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string GetUrl(string serviceKey)
        {
            return _config[$"Services:{serviceKey}"]
                   ?? throw new Exception($"URL não configurada para {serviceKey}");
        }
    }
}
