using System;

using System.Runtime.Remoting;



namespace ServerCS

{

    /// <summary>

    /// ConfigFileRemotingServer

    /// </summary>

    class ConfigFileRemotingServer

    {

        /// <summary>

        /// Demonstrates how to develop a server to sponsor a remote object

        /// </summary>

        [STAThread]

        static void Main(string[] args)

        {

            Console.WriteLine("Server: Reading the config file...");

            RemotingConfiguration.Configure(@"..\..\servercs.config", false);



            Console.WriteLine("Server: I'm ready, press return to exit the server");

            Console.ReadLine();

        }

    }

}
