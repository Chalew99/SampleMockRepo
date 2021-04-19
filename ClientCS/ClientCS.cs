
using System;

using System.Runtime.Remoting;



namespace ClientCS

{

    /// <summary>

    /// ClientCS

    /// </summary>

    class ClientCS

    {

        /// <summary>

        /// ClientCS is a simple .Net remoting application that demonstrates

        /// how to configure .Net remoting via configuration files and also shows

        /// how to perform both marshal by reference and marshal by value.

        /// </summary>

        [STAThread]

        static void Main(string[] args)

        {

            // Test if input arguments were supplied:

            if (args.Length == 0)

            {

                System.Console.WriteLine("Please enter a numeric value followed by a message!");

                System.Console.WriteLine("Example: <program_name> 111 \"Remoting: Some string from client sent to Demo class \n then displayed on Server\"");

                Console.ReadLine();
                return;

            }



            Console.WriteLine("Client: Reading the config file...");

            RemotingConfiguration.Configure(@"..\..\clientcs.config", false);



            System.Console.WriteLine("Client: Instantiating the DemoClass object...");

            DemoCS.DemoClass MyDemo = new DemoCS.DemoClass();

            // The following call demonstrates marshal by reference

            // because we set a numeric value on the server from the client.

            System.Console.WriteLine("Client: DemoClass object - Setting the value...");

            MyDemo.SetValue(int.Parse(args[0]));

            // The following call also demonstrates marshal by reference

            // because we set a string value on the server from the client.

            System.Console.WriteLine("Client: DemoClass object - Setting the message...");

            MyDemo.SetMessage(args[1]);

            // The following call also demonstrates marshal by value because

            // we retrieve a serializable object named InformationBucket

            // from the server and get a copy to access on the client.

            System.Console.WriteLine("Client: DemoClass object - getting the current info...");

            DemoCS.InformationBucket IB = MyDemo.GetCurrentInformation();



            Console.WriteLine();

            Console.WriteLine("Client: The message is: " + IB.Message);

            Console.WriteLine("Client: The value is: " + IB.Value.ToString());

        }

    }

}