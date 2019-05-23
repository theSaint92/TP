using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Casino;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class WstrzykiwanieIloscioweTest
    {
        
 

        [TestMethod]
        public void WstrzykiwanieIloscioweTestPoprawnosc()
        {
            ICasinoRepository repository = new CasinoRepository(new WstrzykiwanieIlosciowe(10,5,5));

            Assert.AreEqual(10, repository.GetAllClients().Count());
            Assert.AreEqual(5, repository.GetAllGames().Count());
            Assert.AreEqual(25, repository.GetAllPlayGames().Count());
            Assert.AreEqual(12, repository.GetAllParticipations().Count());

        }

       
    }
}
