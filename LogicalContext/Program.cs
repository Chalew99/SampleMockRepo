using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public static class Program
{
    private const String c_CCDataName = "CCData";

   private static void Main()
    {
        // Set an item in the thread’s call context
        CallContext.LogicalSetData(c_CCDataName, "Data = " + DateTime.Now);

        // Get the item in the thread’s call context
        GetCallContext();

        // Show that call context flows to another thread
        WaitCallback wc = na => GetCallContext();
        wc.EndInvoke(wc.BeginInvoke(null, null, null));

        // Show that call context flows to another AppDomain
        AppDomain ad = AppDomain.CreateDomain("Other AppDomain");
        ad.DoCallBack(GetCallContext);
        AppDomain.Unload(ad);

        // Remove the key to prevent (de)serialization of its value
        // from this point on improving performance
        CallContext.FreeNamedDataSlot(c_CCDataName);

        // Show no data due to the key being removed from the hashtable
        GetCallContext();
    }

    private static void GetCallContext()
    {
        // Get the item in the thread’s call context
        Console.WriteLine($"AppDomain = {AppDomain.CurrentDomain.FriendlyName}, Thread ID = {Thread.CurrentThread.ManagedThreadId}, {CallContext.LogicalGetData(c_CCDataName)}");
        //Console.WriteLine("AppDomain ={0}, Thread ID = {1}, {2}", AppDomain.CurrentDomain.FriendlyName,  Thread.CurrentThread.ManagedThreadId, CallContext.LogicalGetData(c_CCDataName));
    }
}
