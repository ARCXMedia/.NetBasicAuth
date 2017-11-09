using BasicAuthDemo.Business.Interfaces;
using BasicAuthDemoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BasicAuthDemo.Business.Components
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class APIGateway
        : IAPIGateway
    {
        /// <summary>
        /// 
        /// </summary>
        private HttpClient _httpClient;

        private Credentials _user;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpClient"></param>
        public APIGateway(HttpClient httpClient,
            Credentials user)
        {
            _httpClient = httpClient;
            _user = user;   
        }
        public async Task<HttpResponseMessage> GET(string endpoint)
        {
           return await Connect().GetAsync(endpoint);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private HttpClient Connect()
        {
            try
            {
                _httpClient.Timeout = TimeSpan.FromMinutes(30);
                _httpClient.BaseAddress = new Uri("url");
                _httpClient.DefaultRequestHeaders.Accept.Add(
                            new MediaTypeWithQualityHeaderValue("application/json"));

                var byteArray = Encoding.ASCII.GetBytes(_user.ApiKey + ":" + _user.ApiPassword);
                var header = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
                _httpClient.DefaultRequestHeaders.Authorization = header;

                return _httpClient;
            }
            catch (HttpRequestException ex)
            {
                //Log here

                throw new HttpRequestException(ex.Message);
            }

        }
    }
}
