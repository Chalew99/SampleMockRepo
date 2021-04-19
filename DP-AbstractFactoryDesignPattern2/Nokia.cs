using DP_AbstractFactoryDesignPattern2.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_AbstractFactoryDesignPattern2
{

    /// <summary>  
    /// The 'ConcreteFactory1' class.  
    /// </summary>  
    class Nokia : IMobilePhone
    {
        public ISmartPhone GetSmartPhone()
        {
            return new NokiaPixel();
        }

        public INormalPhone GetNormalPhone()
        {
            return new Nokia1600();
        }
    }
}
