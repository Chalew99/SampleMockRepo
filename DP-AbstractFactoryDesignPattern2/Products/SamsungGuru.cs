using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_AbstractFactoryDesignPattern2.Products
{
    /// <summary>  
    /// The 'ProductB2' class  
    /// </summary>  
    class SamsungGuru : INormalPhone
    {
        public string GetModelDetails()
        {
            return "Model: Samsung Guru\nRAM: NA\nCamera: NA\n";
        }
    }
}
