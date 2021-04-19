using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;

namespace BasicAuthenticationConsoleClient
{
    class Program
    {
        //    static void Main(string[] args)
        //    {

        //        HttpClientHandler handler = new HttpClientHandler();
        //        HttpClient client = new HttpClient(handler);

        //        //HttpClientHandler handler = new HttpClientHandler { Proxy = WebRequest.GetSystemWebProxy() };
        //        //HttpClient client = new HttpClient(handler);

        //        //HttpClient client = new HttpClient();



        //        //System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

        //        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization",
        //                    Convert.ToBase64String(Encoding.Default.GetBytes("AdminUser:123456")));
        //        //Need to change the PORT number where your WEB API service is running
        //        //var path = new Uri("http://localhost:44333/api/Employees");
        //        // HttpResponseMessage response = await client.GetAsync(path);
        //        //if (response.IsSuccessStatusCode)

        //        client.BaseAddress = new Uri("http://localhost:44333/");
        //        var result = client.GetAsync("api/Employees").Result;

        //        //var result = client.GetAsync(new Uri("http://localhost:44333/api/Employees")).Result;

        //        if (result.IsSuccessStatusCode)
        //        {
        //            Console.WriteLine("Done" + result.StatusCode);
        //            var JsonContent = result.Content.ReadAsStringAsync().Result;
        //            List<Employee> empList = JsonConvert.DeserializeObject<List<Employee>>(JsonContent);
        //            foreach (var emp in empList)
        //            {
        //                Console.WriteLine("Name = " + emp.Name + " Gender = " + emp.Gender + " Dept = " + emp.Dept + " Salary = " + emp.Salary);
        //            }
        //        }
        //        else
        //            Console.WriteLine("Error" + result.StatusCode);
        //        Console.ReadLine();

        //}

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //APITest.GetDataWithoutAuthentication1();

            //MainAsync(args).GetAwaiter().GetResult();
            GetDataWithAuthentication().GetAwaiter().GetResult();
            Console.ReadLine();
        }

        //static async Task MainAsync(string[] args)
        //{
        //    Console.WriteLine("Do Stuff");
        //    //await APITest.GetDataWithAuthentication();
        //    await APITest.PostData();
        //    Console.WriteLine("All Done");
        //}

        private static string APIUrl = "http://localhost:44333/api/Employees";
        public static async Task GetDataWithAuthentication()
        {
            var authCredential = Encoding.UTF8.GetBytes("AdminUser:123456");
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authCredential));
                client.BaseAddress = new Uri(APIUrl);
                HttpResponseMessage response = await client.GetAsync(APIUrl);

                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var rawResponse = readTask.GetAwaiter().GetResult();
                    Console.WriteLine(rawResponse);

                    //Console.WriteLine("Done" + result.StatusCode);
                    //var JsonContent = result.Content.ReadAsStringAsync().Result;
                    //var JsonContent = response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    //            List<Employee> empList = JsonConvert.DeserializeObject<List<Employee>>(JsonContent);
                    //            foreach (var emp in empList)
                    //            {
                    //                Console.WriteLine("Name = " + emp.Name + " Gender = " + emp.Gender + " Dept = " + emp.Dept + " Salary = " + emp.Salary);
                    //            }
                }
                Console.WriteLine("Complete");
            }
        }
        public class Employee
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Gender { get; set; }
            public string Dept { get; set; }
            public int Salary { get; set; }
        }

    }
}
