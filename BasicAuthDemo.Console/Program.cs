using BasicAuthDemo.Business.Components;
using BasicAuthDemo.Business.Interfaces;
using BasicAuthDemo.Business.Mocking;
using System.Net.Http;

namespace BasicAuthDemo.Console
{
    public class Program
    {

        static void Main(string[] args)
        {

            IAPIGateway apiGateway = new APIGateway(new HttpClient(),
                Mock.MockCredentials());

            var resp = apiGateway.GET("/api/test/order");

            System.Console.WriteLine(resp.Result.StatusCode);
            System.Console.ReadLine();
        }
    }
}
