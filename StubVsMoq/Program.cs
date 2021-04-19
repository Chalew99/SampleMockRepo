using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StubVsMoq
{

    public interface IExtensionManager
    {
        Boolean CheckExtension(string FileName);
    }
    class Program
    {
        static void Main(string[] args)
        {
            String fileextension;
            Console.WriteLine("Please Enter file extension");
            fileextension = Console.ReadLine();
            FileChecker xxx = new FileChecker();

            if (xxx.CheckFile(fileextension))
            {
                Console.WriteLine($"File extension entered is {fileextension}");
                Console.ReadLine();
            }
            Console.ReadLine();
        }
    }

    public class FileChecker
    {
        IExtensionManager objmanager = null;
        //Default constructor  
        public FileChecker()
        {
            objmanager = new ExtensionManager();
        }
        //parameterized constructor  
        public FileChecker(IExtensionManager tmpManager)
        {
            objmanager = tmpManager;
        }

        public Boolean CheckFile(String FileName)
        {
            return objmanager.CheckExtension(FileName);
        }
    }
    public class ExtensionManager : IExtensionManager
    {
            public Boolean CheckExtension(string filename)
            {
                //some complex business logic might goes here. may be db operation or file system handling  
                return true;
            }
        }
    }
