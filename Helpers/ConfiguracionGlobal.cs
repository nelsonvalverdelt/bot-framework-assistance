using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BumblebeeRobot.Helpers
{
    public class ConfiguracionGlobal: IConfiguracionGlobal
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
      
        public ConfiguracionGlobal(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

        }
        public Uri GetAbsoluteUri()
        {
            var request = _httpContextAccessor.HttpContext.Request;

            UriBuilder uriBuilder = new UriBuilder();
            uriBuilder.Scheme = request.Scheme;
            uriBuilder.Host = request.Host.Host;
            uriBuilder.Path = request.Path.ToString();
            uriBuilder.Port = request.Host.Port.Value;
            uriBuilder.Query = request.QueryString.ToString();
            return uriBuilder.Uri;
        }
    }
}
