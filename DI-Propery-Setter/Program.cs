using System;

namespace DI_Propery_Setter
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
        private IService _service;
        public IService Service
        {
            set { this._service = value; }
        }
        public void ServeMethod() { this._service.Serve(); }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //creating object
            Service1 s1 = new Service1();

            Client client = new Client();
            client.Service = s1; //passing dependency
            client.ServeMethod();                   //TO DO:

            Service2 s2 = new Service2();
            client.Service = s2; //passing dependency
                                 //TO DO:
        }
    }
}
