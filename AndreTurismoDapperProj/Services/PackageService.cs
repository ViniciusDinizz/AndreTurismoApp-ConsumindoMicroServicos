using AndreTurismoDapperProj.Models;
using Newtonsoft.Json;

namespace AndreTurismoDapperProj.Services
{
    public class PackageService
    {
        static readonly HttpClient packageClient = new HttpClient();

        public async Task<List<Package>> GetAll()
        {
            try
            {
                HttpResponseMessage response = await PackageService.packageClient.GetAsync("https://localhost:7007/api/Cities");
                response.EnsureSuccessStatusCode();
                string package = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Package>>(package);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Package> Create(Package package)
        {
            try
            {
                HttpResponseMessage response = await PackageService.packageClient.PostAsJsonAsync("https://localhost:7007/api/Cities", package);
                response.EnsureSuccessStatusCode();
                string packageResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Package>(packageResult);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
