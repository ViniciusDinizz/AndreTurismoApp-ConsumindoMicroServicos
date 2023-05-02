using AndreTurismoDapperProj.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AndreTurismoDapperProj.Services
{
    public class CityService
    {
        static readonly HttpClient cityClient = new HttpClient();
        public async Task<List<City>> GetAll()
        {
            try
            {
                HttpResponseMessage response = await CityService.cityClient.GetAsync("https://localhost:7007/api/Cities");
                response.EnsureSuccessStatusCode();
                string city = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<City>>(city);
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }
        public async Task<City> GetId(int idCity)
        {
            try
            {
                HttpResponseMessage response = await CityService.cityClient.GetAsync("https://localhost:7007/api/Cities/" + idCity);
                response.EnsureSuccessStatusCode();
                string city = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<City>(city);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<City> Create(City city)
        {
            try
            {
                HttpResponseMessage response = await CityService.cityClient.PostAsJsonAsync("https://localhost:7007/api/Cities", city);
                response.EnsureSuccessStatusCode();
                string cityReturn = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<City>(cityReturn);
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }
        public async Task<ActionResult<City>> Update (int id, City city)
        {
            try
            {
                HttpResponseMessage response = await CityService.cityClient.PutAsJsonAsync("https://localhost:7007/api/Cities/" + id, city);
                response.EnsureSuccessStatusCode() ;
                string resultUpdate = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ActionResult<City>>(resultUpdate);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<ActionResult<City>> Delete(int id)
        {
            try
            {
                HttpResponseMessage response = await CityService.cityClient.DeleteAsync("https://localhost:7007/api/Cities/" + id);
                response.EnsureSuccessStatusCode();
                string deleteSucess = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ActionResult<City>>(deleteSucess);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
