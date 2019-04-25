using Microsoft.Extensions.DependencyInjection;
using MOTHistory.Contracts.Repository;
using MOTHistory.Contracts.Services;
using MOTHistory.Repository;
using MOTHistory.Services;
using System;
using System.Net.Http.Headers;

namespace MOTHistoryApp
{  
   class MOTHistoryProgram
    {
        private const string API_URL = "https://beta.check-mot.service.gov.uk/";
        private const string API_KEY_TYPE = "x-api-key";
        private const string API_KEY = "fZi8YcjrZN1cGkQeZP7Uaa4rTxua8HovaswPuIno";
        //Reg num to test: XX10ABC, AJ17CNZ, VE04 JYR

        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddScoped<IMOTRepository, MOTRepository>();
            services.AddScoped<IMOTService, MOTService>();

            services.AddHttpClient<IMOTRepository, MOTRepository>(client =>
            {
                client.BaseAddress = new Uri(API_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add(API_KEY_TYPE, API_KEY);
                client.DefaultRequestHeaders.Add("description", "");
            });

            var provider = services.BuildServiceProvider();

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("---------VEHICLE MOT CHECKER-------------");
            Console.WriteLine("-----------------------------------------");

            while (true)
            {
                Console.WriteLine("Enter a registration number: ");

                var regnum = Console.ReadLine();

                var motService = provider.GetService<IMOTService>();

                var vehicle = motService.Find(regnum);

                Console.WriteLine(vehicle?.ToString() ?? $"The vehicle with the registration: {regnum} was not found.");
                Console.WriteLine();
            }
        }
       
    }
}
