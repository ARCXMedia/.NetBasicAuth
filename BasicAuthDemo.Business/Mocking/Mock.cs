using BasicAuthDemoModels;

namespace BasicAuthDemo.Business.Mocking
{
    public static class Mock
    {
        public static Credentials MockCredentials()
        {
            return new Credentials()
            {
                ApiKey = "api-key",
                ApiPassword = "api-password",
            };
        }
    }
}
