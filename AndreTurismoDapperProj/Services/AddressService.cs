using System.Security.Cryptography.X509Certificates;
using AndreTurismoDapperProj.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AndreTurismoDapperProj.Services
{
    public class AddressService
    {
        static readonly HttpClient addressClient = new HttpClient();
        public async Task<List<Address>> GetAll()
        {
            try
            {
                HttpResponseMessage response = await AddressService.addressClient.GetAsync("https://localhost:7253/api/Addresses");
                response.EnsureSuccessStatusCode();
                string address = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Address>>(address);
            }
            catch (HttpRequestException)
            {
                return null; 
            }
        }
        public async Task<Address> GetId(int Id)
        {
            try
            {
                HttpResponseMessage response = await AddressService.addressClient.GetAsync("https://localhost:7253/api/Addresses/" + Id);
                response.EnsureSuccessStatusCode();
                string address = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Address>(address);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<ActionResult<AddressDTO>> GetCep(string cep)
        {
            try
            {
                HttpResponseMessage response = await AddressService.addressClient.GetAsync("https://localhost:7253/api/Addresses/" + cep);
                response.EnsureSuccessStatusCode();
                string addresDTO = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AddressDTO>(addresDTO);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<Address> Create(Address address)
        {
            try
            {
                HttpResponseMessage response = await AddressService.addressClient.PostAsJsonAsync("https://localhost:7253/api/Addresses", address);
                response.EnsureSuccessStatusCode();
                string addressReturn = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Address>(addressReturn);
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }
        public async Task<ActionResult<Address>> Update(int Id, Address address)
        {
            try
            {
                HttpResponseMessage response = await AddressService.addressClient.PutAsJsonAsync("https://localhost:7253/api/Addresses/" + Id, address);
                response.EnsureSuccessStatusCode();
                string addressUpdate = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ActionResult<Address>>(addressUpdate);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<ActionResult<Address>> Delete(int idAddress)
        {
            try
            {
                HttpResponseMessage response = await AddressService.addressClient.DeleteAsync("https://localhost:7253/api/Addresses/" + idAddress);
                response.EnsureSuccessStatusCode();
                string resultDelete = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ActionResult<Address>>(resultDelete);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
