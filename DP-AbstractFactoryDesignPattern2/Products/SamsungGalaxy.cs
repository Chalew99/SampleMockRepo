using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_AbstractFactoryDesignPattern2.Products
{
    /// <summary>  
    /// The 'ProductA2' class  
    /// </summary>  
    class SamsungGalaxy : ISmartPhone
    {
        public string GetModelDetails()
        {
            return "Model: Samsung Galaxy\nRAM: 2GB\nCamera: 13MP\n";
        }
    }
}
