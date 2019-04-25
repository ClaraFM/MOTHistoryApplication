using MOTHistory.Contracts.Repository;
using MOTHistory.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace MOTHistory.Repository
{
    public class MOTRepository: IMOTRepository
    {
        private readonly HttpClient _client;

        public MOTRepository(HttpClient httpClient)
        {
            _client = httpClient;
        }

        public VehicleDto Find(string regNumber)
        {
            var trimReg = Regex.Replace(regNumber, " ", "");
            HttpResponseMessage response =  _client.GetAsync($"trade/vehicles/mot-tests?registration={trimReg}").Result;
            if (response.IsSuccessStatusCode)
            {
                using (HttpContent content = response.Content)
                {
                    var data = content.ReadAsStringAsync();
                    var vehicles = JsonConvert.DeserializeObject<List<VehicleDto>>(data.Result);
                    return vehicles.FirstOrDefault();
                }
            }
            else
            {
                //Error
                return null;
            }
        }
    }
}
