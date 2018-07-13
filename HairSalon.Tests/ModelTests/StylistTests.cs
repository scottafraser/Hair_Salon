using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistTests : IDisposable
    {
        public StylistTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=scott_fraser_test;";
        }

        [TestMethod]
        public void GetAll_CategoriesEmptyAtFirst_0()
        {

            int result = Stylist.GetAll().Count;


            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Equals_ReturnsTrueForSameName_Stylist()
        {

            Stylist firstStylist = new Stylist("Jessica");
            Stylist secondStylist = new Stylist("Jessica");

            Assert.AreEqual(firstStylist, secondStylist);
        }

        [TestMethod]
        public void Save_SavesStylistToDatabase_StylistList()
        {

            Stylist testStylist = new Stylist("Jessica");
            testStylist.Save();
            List<Stylist> result = Stylist.GetAll();
            List<Stylist> testList = new List<Stylist> { testStylist };


            CollectionAssert.AreEqual(testList, result);
        }

        [TestMethod]
        public void Save_DatabaseAssignsIdToStylist_Id()
        {

            Stylist testStylist = new Stylist("Jessica");
            testStylist.Save();
            Stylist savedStylist = Stylist.GetAll()[0];

            int result = savedStylist.GetId();
            int testId = testStylist.GetId();


            Assert.AreEqual(testId, result);
        }

        [TestMethod]
        public void Find_FindsStylistInDatabase_Stylist()
        {

            Stylist testStylist = new Stylist("Jessica");
            testStylist.Save();

             Stylist foundStylist = Stylist.Find(testStylist.GetId());

            Assert.AreEqual(testStylist, foundStylist);
        }

        [TestMethod]
        public void GetClients_RetrievesAllClientsWithStylist_ClientList()
        {
            Stylist testStylist = new Stylist("Jessica");
            testStylist.Save();

            Client firstClient = new Client("Steve", testStylist.GetId());
            firstClient.Save();
            Client secondClient = new Client("Jerry", testStylist.GetId());
            secondClient.Save();


            List<Client> testClientList = new List<Client> { firstClient, secondClient };
            List<Client> resultClientList = testStylist.GetClients();

            CollectionAssert.AreEqual(testClientList, resultClientList);
        }

        public void Dispose()
        {
            Client.DeleteAll();
            Stylist.DeleteAll();
        }
    }
}