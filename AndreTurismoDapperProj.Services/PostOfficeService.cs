﻿using AndreTurismoDapperProj.Models;
using Newtonsoft.Json;

namespace AndreTurismoDapperProjAddressService.Service
{
    public class PostOfficeService
    {
        static readonly HttpClient endereco = new HttpClient();
        public  async Task<AddressDTO> GetAddress(string cep)
        {
            try
            {
                HttpResponseMessage response = await PostOfficeService.endereco.GetAsync("https://viacep.com.br/ws/" + cep + "/json/");
                response.EnsureSuccessStatusCode();
                string ender = await response.Content.ReadAsStringAsync();
                var end = JsonConvert.DeserializeObject<AddressDTO>(ender);
                return end;
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }
    }
}
