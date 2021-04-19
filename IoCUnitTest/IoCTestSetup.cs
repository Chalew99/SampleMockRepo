using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace IoCTestSetup

{

    public interface ISendr

    {

        string send();

    }



    public class smsSender : ISendr

    {

        public string send()

        {

            return "SMS send";

        }

    }



    public class emailSender : ISendr

    {

        public String send()

        {

            return "Email send";

        }

    }



    public class voiceSend : ISendr

    {

        public string send()

        {

            return "VOICE Send";

        }

    }

    public class sender

    {

        public string send(ISendr obj)

        {

            return obj.send();

        }

    }

}