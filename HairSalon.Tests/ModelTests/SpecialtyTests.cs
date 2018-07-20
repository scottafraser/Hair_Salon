﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{

    [TestClass]
    public class SpecialtyTests : IDisposable
    {
        public SpecialtyTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=scott_fraser_test;";
        }

        [TestMethod]
        public void GetAll_CategoriesEmptyAtFirst_0()
        {

            int result = Specialty.GetAll().Count;


            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Equals_ReturnsTrueForSameName_Specialty()
        {

            Specialty firstSpecialty = new Specialty("Beard Trimming");
            Specialty secondSpecialty = new Specialty("Beard Trimming");

            Assert.AreEqual(firstSpecialty, secondSpecialty);
        }

        [TestMethod]
        public void Save_SavesSpecialtyToDatabase_SpecialtyList()
        {

            Specialty testSpecialty = new Specialty("Beard Trimming");
            testSpecialty.Save();
            List<Specialty> result = Specialty.GetAll();
            List<Specialty> testList = new List<Specialty> { testSpecialty };


            CollectionAssert.AreEqual(testList, result);
        }

        [TestMethod]
        public void Save_DatabaseAssignsIdToSpecialty_Id()
        {

            Specialty testSpecialty = new Specialty("Beard Trimming");
            testSpecialty.Save();
            Specialty savedSpecialty = Specialty.GetAll()[0];

            int result = savedSpecialty.GetId();
            int testId = testSpecialty.GetId();


            Assert.AreEqual(testId, result);
        }

        [TestMethod]
        public void Find_FindsSpecialtyInDatabase_Specialty()
        {

            Specialty testSpecialty = new Specialty("Beard Trimming");
            testSpecialty.Save();

            Specialty foundSpecialty = Specialty.Find(testSpecialty.GetId());

            Assert.AreEqual(testSpecialty, foundSpecialty);
        }

        [TestMethod]
        public void GetClients_RetrievesAllStylistWithSpecialty_StylistList()
        {
            Specialty testSpecialty = new Specialty("Beard Trimming");
            testSpecialty.Save();

            Client firstStylist = new Stylist("Steve", testSpecialty.GetId());
            firstStylist.Save();
            Stylist secondStylist = new Stylist("Jerry", testSpecialty.GetId());
            secondClient.Save();


            List<Client> testStylistList = new List<Stylist> { firstStylist, secondStylist };
            List<Stylist> resultStylistList = testSpecialty.GetStylists();

            CollectionAssert.AreEqual(testClientList, resultClientList);
        }

        public void Dispose()
        {
            Client.DeleteAll();
            Specialty.DeleteAll();
        }
    }
