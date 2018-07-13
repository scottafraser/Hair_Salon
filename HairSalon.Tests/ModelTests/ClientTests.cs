using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class ClientTests : IDisposable
    {
        public ClientTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=scott_fraser_test;";
        }
        public void Dispose()
        {
            Client.DeleteAll();
            Stylist.DeleteAll();
        }

        [TestMethod]
        public void Equals_OverrideTrueForSameDescription_Client()
        {
            Client firstClient = new Client("Steve", 1);
            Client secondClient = new Client("Steve", 1);

            Assert.AreEqual(firstClient, secondClient);
        }

        [TestMethod]
        public void Save_SavesClientToDatabase_ClientList()
        {
            Client testClient = new Client("Steve", 1);
            testClient.Save();
            List<Client> result = Client.GetAll();
            List<Client> testList = new List<Client> { testClient };
            CollectionAssert.AreEqual(testList, result);
        }

        [TestMethod]
        public void Save_DatabaseAssignsIdToObject_Id()
        {
            Client testClient = new Client("Steve", 1);
            testClient.Save();
            Client savedClient = Client.GetAll()[0];
            int result = savedClient.GetId();
            int testId = testClient.GetId();
            Assert.AreEqual(testId, result);
        }

        [TestMethod]
        public void Find_FindsClientInDatabase_Client()
        {
            Client testClient = new Client("Steve", 1);
            testClient.Save();
            Client foundClient = Client.Find(testClient.GetId());
            Assert.AreEqual(testClient, foundClient);
        }
    }
}