using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_AbstractFactoryDesignPattern2
{
    /// <summary>  
    /// The 'ProductA1' class  
    /// </summary>  
    class NokiaPixel : ISmartPhone
    {
        public string GetModelDetails()
        {
            return "Model: Nokia Pixel\nRAM: 3GB\nCamera: 8MP\n";
        }
    }
}
