// using System;
// using System.Collections.Generic;
//using System.Linq;
// using System.Text;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Runtime.Remoting;

// namespace ExecutionContextStudy
// {
//     class ThreadDataSlotTest
//     {
//       public static void Main()
//         {
//             for (var i = 0; i< 10; i++)
//             {
//                 Thread.Sleep(10);

//                 Task.Run(() =>
//                 {
//                     var slot = Thread.GetNamedDataSlot("test");
//                     if (slot == null)
//                     {
//                         Thread.AllocateNamedDataSlot("test");
//                     }

//                     if (Thread.GetData(slot) == null)
//                         {
//                             Thread.SetData(slot, DateTime.Now.Millisecond);
//                         }
//                     Console.WriteLine(Thread.CurrentThread.ManagedThreadId + ":" + Thread.GetData(slot));
//                 });
//             }

//             Console.ReadLine();
//         }
//     }
// }

// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Runtime.Remoting.Messaging;

// namespace ExecutionContextStudy
// {
//     class CallContextTest
//     {
//         public static void Main()
//         {
//             Console.WriteLine("Test: CallContext.SetData");
//             for (var i = 0; i< 10; i++)
//             {
//                 Thread.Sleep(10);

//                 Task.Run(() =>
//                 {
//                     if (CallContext.GetData("test") == null)
//                     {
//                         CallContext.SetData("test", DateTime.Now.Millisecond);
//                     }

//                     Console.WriteLine(Thread.CurrentThread.ManagedThreadId + ":" + CallContext.GetData("test"));
//                 });
//             }

//             Console.ReadLine();
//        }
//     }
//}

 using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Text;
 using System.Threading;
 using System.Threading.Tasks;
 using System.Runtime.Remoting.Messaging;

 namespace ExecutionContextStudy
 {
     class ExecutionContextTest
     {
         public static void Main()
         {
             Console.WriteLine("Test: CallContext.SetData");
             Task.Run(() =>
            {
                CallContext.SetData("test", "Duan Guangwei");
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + ":" + CallContext.GetData("test"));

                Task.Run(() =>
                {
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId + ":" + CallContext.GetData("test"));
                });
            });

            Thread.Sleep(100);
            Console.WriteLine("Test: CallContext.LogicalSetData");
             Task.Run(() =>
            {
                 CallContext.LogicalSetData("test", "Duan Guangwei");
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + ":" + CallContext.LogicalGetData("test"));

                 Task.Run(() =>
                 {
                     Console.WriteLine(Thread.CurrentThread.ManagedThreadId + ":" + CallContext.LogicalGetData("test"));
                 });

                ExecutionContext.SuppressFlow();
                 Task.Run(() =>
                 {
                     Console.WriteLine("After SuppressFlow:" + CallContext.LogicalGetData("test"));
                 });
                ExecutionContext.RestoreFlow();
                 Task.Run(() =>
                 {
                     Console.WriteLine("After RestoreFlow:" + CallContext.LogicalGetData("test"));
                 });
             });

             Console.ReadLine();
        }
     }
}