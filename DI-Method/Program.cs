using System;

namespace DI_Method
{
    public interface IService
    {
        void Serve();
    }
    public class Service1 : IService
    {
        public void Serve() { Console.WriteLine("Service1 Called"); }
    }
    public class Service2 : IService
    {
        public void Serve() { Console.WriteLine("Service2 Called"); }
    }
    public class Client
    {
        //private IService _service;
        public void Start(IService service)
        {
            service.Serve();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //creating object
            Service1 s1 = new Service1();

            Client client = new Client();
            client.Start(s1); //passing dependency
                              //TO DO:

            Service2 s2 = new Service2();
            client.Start(s2); //passing dependency
        }
    }
}
