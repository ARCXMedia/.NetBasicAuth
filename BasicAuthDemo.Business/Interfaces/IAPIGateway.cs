using System.Net.Http;
using System.Threading.Tasks;

namespace BasicAuthDemo.Business.Interfaces
{
    public interface IAPIGateway
    {
        Task<HttpResponseMessage> GET(string endpoint);
    }
}
