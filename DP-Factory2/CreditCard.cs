using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethodDesignPatternInCSharp
{
    /// <summary>  
    /// The 'Product' Abstract Class  
    /// </summary>  
    abstract class CreditCard
    {
        public abstract string CardType { get; }
        public abstract int CreditLimit { get; set; }
        public abstract int AnnualCharge { get; set; }
    }
}
