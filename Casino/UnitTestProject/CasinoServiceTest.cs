using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Casino;

namespace UnitTestProject
{
    [TestClass]
    public class CasinoServiceTest
    {
        ICasinoService service = new CasinoService(new CasinoRepository(new WstrzykiwanieStalych()));

        [TestMethod]
        public void ClientsToStringTest()
        {
            string result = null;
            result = service.ClientsToString();
            Assert.AreNotEqual(null, result);
            Console.WriteLine(result);
        }

        [TestMethod]
        public void GamesToStringTest()
        {
            string result = null;
            result = service.GamesToString();
            Assert.AreNotEqual(null, result);
            Console.WriteLine(result);
        }

        [TestMethod]
        public void PlayGamesToStringTest()
        {
            string result = null;
            result = service.PlayGamesToString();
            Assert.AreNotEqual(null, result);
            Console.WriteLine(result);
        }

        [TestMethod]
        public void ParticipationsToStringTest()
        {
            string result = null;
            result = service.ParticipationsToString();
            Assert.AreNotEqual(null, result);
            Console.WriteLine(result);
        }

        [TestMethod]
        public void RepositoryToStringTest()
        {
            string result = null;
            result = service.RepositoryToString();
            Assert.AreNotEqual(null, result);
            Console.WriteLine(result);
        }


    }
}
