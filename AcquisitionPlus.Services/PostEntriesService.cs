using AcquisitionPlus.Business.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;

namespace AcquisitionPlus.Services
{
    public class PostEntriesService : IPostEntriesService
    {
        public string UrlContabilidadService { get; private set; }

        public PostEntriesService(IConfiguration configuration)
        {
            UrlContabilidadService = configuration.GetSection("ModuloContabilidad:UrlContabilidad").Value;
        }

        public dynamic PostEntries(dynamic Data)
        {
            var Host = UrlContabilidadService.Split(new string[] { "//", "/" }, StringSplitOptions.None)[1];

            var client = new RestClient(UrlContabilidadService);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Connection", "keep-alive");
            request.AddHeader("Accept-Encoding", "gzip, deflate");
            request.AddHeader("Host", Host);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(Data);

            IRestResponse response = client.Execute(request);

            if (200 != (int)response.StatusCode)
                return null;

            return response.Content;
        }
    }
}
