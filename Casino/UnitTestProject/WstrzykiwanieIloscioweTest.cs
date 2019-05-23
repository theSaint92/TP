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
            ICasinoRepository repository = new CasinoRepository(new WstrzykiwanieIlosciowe(10, 5, 5, 5));

            Assert.AreEqual(10, repository.GetAllClients().Count());
            Assert.AreEqual(5, repository.GetAllGames().Count());
            Assert.AreEqual(5, repository.GetAllPlayGames().Count());
            Assert.AreEqual(5, repository.GetAllParticipations().Count());

        }

        [TestMethod]
        public void WstrzykiwanieIloscioweTestSmall()
        {
            ICasinoRepository repository = new CasinoRepository(new WstrzykiwanieIlosciowe(100, 50, 50, 50));
            ICasinoService service = new CasinoService(repository);

            Assert.AreEqual(100, repository.GetAllClients().Count());
            Assert.AreEqual(50, repository.GetAllGames().Count());
            Assert.AreEqual(50, repository.GetAllPlayGames().Count());
            Assert.AreEqual(50, repository.GetAllParticipations().Count());

        }


        [TestMethod]
        public void WstrzykiwanieIloscioweTestMedium()
        {
            ICasinoRepository repository = new CasinoRepository(new WstrzykiwanieIlosciowe(1000, 500, 500, 500));
            ICasinoService service = new CasinoService(repository);

            Assert.AreEqual(1000, repository.GetAllClients().Count());
            Assert.AreEqual(500, repository.GetAllGames().Count());
            Assert.AreEqual(500, repository.GetAllPlayGames().Count());
            Assert.AreEqual(500, repository.GetAllParticipations().Count());

        }

        [TestMethod]
        public void WstrzykiwanieIloscioweTestBig()
        {
            ICasinoRepository repository = new CasinoRepository(new WstrzykiwanieIlosciowe(10000, 5000, 5000, 5000));
            ICasinoService service = new CasinoService(repository);

            Assert.AreEqual(10000, repository.GetAllClients().Count());
            Assert.AreEqual(5000, repository.GetAllGames().Count());
            Assert.AreEqual(5000, repository.GetAllPlayGames().Count());
            Assert.AreEqual(5000, repository.GetAllParticipations().Count());

        }

        [TestMethod]
        public void WstrzykiwanieIloscioweTestHuge()
        {
            ICasinoRepository repository = new CasinoRepository(new WstrzykiwanieIlosciowe(100000, 50000, 50000, 50000));
            ICasinoService service = new CasinoService(repository);

            Assert.AreEqual(100000, repository.GetAllClients().Count());
            Assert.AreEqual(50000, repository.GetAllGames().Count());
            Assert.AreEqual(50000, repository.GetAllPlayGames().Count());
            Assert.AreEqual(50000, repository.GetAllParticipations().Count());


        }



    }
}
