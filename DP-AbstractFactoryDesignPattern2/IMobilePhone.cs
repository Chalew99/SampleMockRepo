using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_AbstractFactoryDesignPattern2
{
    /// <summary>  
    /// The 'AbstractFactory' interface.  
    /// </summary>  
    interface IMobilePhone
    {
        ISmartPhone GetSmartPhone();
        INormalPhone GetNormalPhone();
    }


    /// <summary>  
    /// The 'AbstractProductA' interface  
    /// </summary> 
    interface ISmartPhone
    {
        string GetModelDetails();
    }

    /// <summary>  
    /// The 'AbstractProductB' interface  
    /// </summary> 
    interface INormalPhone
    {
        string GetModelDetails();
    }
}
