namespace Proyecto1V1.Services
{
    public class PatientsService
    {
        private static string _baseUrl;

        public PatientsService()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        }

    }
}
