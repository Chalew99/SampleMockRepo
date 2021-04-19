using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HMACClient
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
            
           Console.ReadLine();
        }
        static async Task RunAsync()
        {
            Console.WriteLine("Calling the back-end API");
            //Need to change the port number
            //provide the port number where your api is running
            string apiBaseAddress = "https://localhost:44311/";
            HMACDelegatingHandler customDelegatingHandler = new HMACDelegatingHandler();
            HttpClient client = HttpClientFactory.Create(customDelegatingHandler);
            var order = new Order
            {
                OrderID = 10248,
                CustomerName = "Pranaya Rout",
                CustomerAddress = "Mumbai|Mahatashtra|IN",
                ContactNumber = "1234567890",
                IsShipped = true
            };
            HttpResponseMessage response = await client.PostAsJsonAsync(apiBaseAddress + "api/orders", order);
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseString);
                Console.WriteLine("HTTP Status: {0}, Reason {1}. Press ENTER to exit", response.StatusCode, response.ReasonPhrase);
            }
            else
            {
                Console.WriteLine("Failed to call the API. HTTP Status: {0}, Reason {1}", response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
