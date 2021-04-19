using DP_AbstractFactoryDesignPattern2.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_AbstractFactoryDesignPattern2
{
    /// <summary>  
    /// The 'ConcreteFactory2' class.  
    /// </summary>  
    class Samsung : IMobilePhone
    {
        public ISmartPhone GetSmartPhone()
        {
            return new SamsungGalaxy();
        }

        public INormalPhone GetNormalPhone()
        {
            return new SamsungGuru();
        }
    }
}
