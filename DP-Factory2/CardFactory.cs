using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethodDesignPatternInCSharp
{
    /// <summary>  
    /// The 'Creator' Abstract Class  
    /// </summary>  
    abstract class CardFactory
    {
        public abstract CreditCard GetCreditCard();
    }
}
