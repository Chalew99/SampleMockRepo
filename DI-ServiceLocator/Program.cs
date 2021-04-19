using System;
using System.Collections.Generic;

namespace DI_ServiceLocator_StrongType
{
    public interface IService
    {
        void ExecuteService();
    }
    public class LoggingService : IService
    {
        public void ExecuteService()
        {
            Console.WriteLine("Executing Log Service");
        }
    }

    public static class ServiceLocator
    {
        public static IService ObjService = null;

        //Service locator function returning strong type   
        public static IService SetLocation(IService tmpser)
        {
            if (ObjService == null) return new LoggingService();
            return ObjService;
        }

        //Execute service  
        public static void ExecuteService()
        {
            ObjService.ExecuteService();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IService svr = ServiceLocator.SetLocation(new LoggingService());
            svr.ExecuteService();
            Console.ReadLine();
        }
    }
}
