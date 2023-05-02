using AndreTurismoDapperProj.Models;
using Microsoft.AspNetCore.ResponseCompression;
using Newtonsoft.Json;

namespace AndreTurismoDapperProj.Services
{
    public class CustomerService
    {
        static readonly HttpClient customerClient = new HttpClient();

        public async Task<List<Customer>> GetAll()
        {
            try
            {
                HttpResponseMessage response = await CustomerService.customerClient.GetAsync("https://localhost:7007/api/Cities"); 
                response.EnsureSuccessStatusCode();
                string customer = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Customer>>(customer);

            }catch (Exception)
            {
                return null;
            }
        }

        public async Task<Customer> Create(Customer customer)
        {
            try
            {
                HttpResponseMessage response = await CustomerService.customerClient.PostAsJsonAsync("https://localhost:7007/api/Cities", customer);
                response.EnsureSuccessStatusCode();
                string customerResult = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Customer>(customerResult);
            }catch(Exception)
            {
                return null;
            }
        }
    }
}
