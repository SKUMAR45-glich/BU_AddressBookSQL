
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBookSQL;
using System;

namespace TestingAddressBookSQLl
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void Given_FirstAndLastName_Should_ReturnTrue()
        {
            AddressBookRepo.RetrieveAllContacts();
            var contact = AddressBookRepo.contacts[1];
            //var contact = list[1];
            //var previousName = contact.FirstName;
            contact.City = "Rajeev";
            contact.State = "TN";
            bool result = AddressBookRepo.UpdateContact(contact);

            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void DataforDateRetrieval()
        {
            AddressBookRepo.RetrieveAllContacts();
            var startDate = Convert.ToDateTime("15/09/2020");
            var endDate = Convert.ToDateTime("30/09/2020");
            bool result = AddressBookRepo.RetrieveDetailsInDateRange(startDate, endDate);

            Assert.AreEqual(result, true);
        }


        [TestMethod]
        public void Given_ContactInfo_WhenAddedToDatabase_Should_Return_True()
        {
            AddressBookRepo addressBookRepo = new AddressBookRepo();

            AddressModel addressModel = new AddressModel
            {
                FirstName = "Virat",
                LastName = "Kohli",
                DateofJoining = DateTime.Now,
                Address = "Delhi",
                State = "Australia",
                City = "Adelaide",
                Zipcode = "147852",
                PhoneNumber = "9038880216",
                Email = "vk@gmail.com",
                Relation_Type = "Captain",
            };

            bool result = AddressBookRepo.AddContact(addressModel);

            Assert.AreEqual(result, true);
        }

    }
}

