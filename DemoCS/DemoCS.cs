using System;



namespace DemoCS

{

    /// <summary>

    /// DemoClass is a very simple class that demonstrates Marshal by Value and

    /// Marshal by Reference in .Net remoting.

    /// </summary>

    ///

    [Serializable] // for Marshaling by value

    public class InformationBucket

    {

        public int Value;

        public string Message;

    }



    // for Marshaling by reference

    public class DemoClass : MarshalByRefObject

    {

        private int Value = 0;

        private string Message = "";



        // method for setting a value

        public void SetValue(int InputValue)

        {

            Value = InputValue;

            Console.WriteLine("Demo class: Setting Value to {0}", InputValue);

        }



        // method for displaying a message

        public void SetMessage(string InputMessage)

        {

            Message = InputMessage;

            Console.WriteLine("Demo class: Setting Message to {0}", InputMessage);

        }



        public InformationBucket GetCurrentInformation()

        {

            InformationBucket Bucket = new InformationBucket();



            Bucket.Message = Message;

            Bucket.Value = Value;



            return Bucket;

        }

    }

}
