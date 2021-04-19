using System;
using IoCTestSetup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace UNIT

{

    [TestClass]

        public class UnitTest1

        {

        [DataTestMethod]
        //[DataRow("SMS send", expected)]
        
        public void TestMethod1(String input, ISendr expected)

            {

            var mock = new Mock<ISendr>();
            //mock.Setup(x => x.send()).Returns(expected);
            var objsender = new sender().send(mock.Object);

            Assert.AreEqual(input, objsender); 
            //new sender().send(new smsSender()));
            //Assert.AreEqual("SMS send", objsender);

            //Assert.AreEqual("Email send", new sender().send(new emailSender()));

            //Assert.AreEqual("VOICE Send", new sender().send(new voiceSend()));

        }

    }

 }




