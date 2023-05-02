using AndreTurismoDapperProj.Models;
using Microsoft.AspNetCore.ResponseCompression;
using Newtonsoft.Json;

namespace AndreTurismoDapperProj.Services
{
    public class HotelService
    {
        static readonly HttpClient hotelClient = new HttpClient();

        public async Task<List<Hotel>> GetAll()
        {
            try
            {
                HttpResponseMessage response = await HotelService.hotelClient.GetAsync("https://localhost:7007/api/Cities");
                response.EnsureSuccessStatusCode();
                string hotel = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Hotel>>(hotel);
            }catch(Exception) 
            {
                return null;
            }
        }

        public async Task<Hotel> Create(Hotel hotel)
        {
            HttpResponseMessage response = await HotelService.hotelClient.PostAsJsonAsync("https://localhost:7007/api/Cities", hotel);
            response.EnsureSuccessStatusCode();
            string hotelResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Hotel>(hotelResult);
        }
    }
}
