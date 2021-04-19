using System;

namespace DI_Constructor
{
    public interface IService
    {
        void Serve();
    }
    public class Service1 : IService
    {
        public void Serve()
        {
            Console.WriteLine("Service1 Called");
            Console.ReadLine();
        }
    }
    public class Service2 : IService
    {
        public void Serve() 
        { 
            Console.WriteLine("Service2 Called");
            Console.ReadLine();
        }
    }
    public class Client
    {
        private IService _service;
        public Client(IService service)
        {
            this._service = service;
        }
        public void ServeMethod() 
        { 
            this._service.Serve();
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            //creating object
            Service1 s1 = new Service1();
            //passing dependency
            Client c1 = new Client(s1);
            //TO DO:
            c1.ServeMethod();

            Service2 s2 = new Service2();
            //passing dependency
            c1 = new Client(s2);
            //TO DO:
        }
    }
}
