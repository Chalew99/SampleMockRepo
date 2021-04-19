//using System;
//using System.Threading;

//class ThreadStaticTest
//{
//    [ThreadStatic]
//    static string greeting;

//    static void xMain()
//    {
//        greeting = "Goodbye from the main thread";
//        Thread t = new Thread(ThreadMethod);
//        t.Start();
//        t.Join();
//        Console.WriteLine(greeting); // prints the main thread's copy
//        Console.ReadKey();
//    }

//    static void ThreadMethod()
//    {
//        greeting = "Hello from the second thread"; // only affects the second thread's copy
//        Console.WriteLine(greeting);
//    }
//}


//class ThreadStaticTest2
//{
//    [ThreadStatic]
//    static string greeting = "Greetings from the current thread";

//    static void Main()
//    {
//        Console.WriteLine(greeting); // prints initial value
//        greeting = "Goodbye from the main thread";
//        Thread t = new Thread(ThreadMethod);
//        t.Start();
//        t.Join();
//        Console.WriteLine(greeting); // prints the main thread's copy
//        Console.ReadKey();
//    }

//    static void ThreadMethod()
//    {
//        Console.WriteLine(greeting); // prints nothing as greeting initialized on main thread
//        greeting = "Hello from the second thread"; // only affects the second thread's copy
//        Console.WriteLine(greeting);
//    }
//}


using System;
using System.Threading;

class ThreadLocalTest
{
    static ThreadLocal<string> greeting;
    ThreadLocal<int> numThreads = new ThreadLocal<int>(() => 1); // instance field

    static ThreadLocalTest()
    {
        greeting = new ThreadLocal<string>(() => "Greetings from the current thread");
    }

    static void Main()
    {
        Console.WriteLine(greeting.Value.Replace("current", "main"));
        greeting.Value = "Goodbye from the main thread";
        Thread t = new Thread(ThreadMethod);
        t.Start();
        t.Join();
        ThreadLocalTest tl = new ThreadLocalTest();
        Thread t2 = new Thread(tl.InstanceThreadMethod);
        t2.Start();
        t2.Join();
        Console.WriteLine("The number of current threads is now " + tl.numThreads);
        Console.WriteLine(greeting.Value); // prints the main thread's copy which is still 1
        Console.ReadKey();
    }

    static void ThreadMethod()
    {
        Console.WriteLine(greeting.Value.Replace("current", "second"));
        greeting.Value = "Hello from the second thread"; // only affects the second thread's copy
        Console.WriteLine(greeting.Value);
    }

    void InstanceThreadMethod()
    {
        numThreads.Value++; // increment this thread's copy to 2
        Console.WriteLine("The number of current threads is " + this.numThreads);
    }
}