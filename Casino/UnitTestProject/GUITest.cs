using System;
using System.Windows.Input;
using GUI.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class GUITest
    {
        [TestMethod]
        public void AddClientCommmandTest()
        {
            ViewModel vm = new ViewModel();
            ICommand com = vm.AddClientCommandButton;

            int count = vm.ClientsCollection.Count;
            vm.ClientToAdd = new DatabaseCasinoModel.Clients
            {
                Id = 5,
                Name = "Rufus",
                Surname = "Rudy",
                DateOfBirth = new DateTime(1999,5,12)
            };
            com.Execute(null);
            Assert.AreEqual(count, vm.ClientsCollection.Count - 1);

        }
    }
}
