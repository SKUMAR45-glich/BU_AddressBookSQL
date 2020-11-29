using NUnit.Framework;
using AddressBookSQL;
using System;
using System.Linq;

namespace AddressBookTestforSQL
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            AddressBookRepo.RetrieveAllContactstotest();

            var list = AddressBookRepo.contacts;

            Assert.That(list, Is.Not.Empty);
        }

        [Test]
        public void UpdateContact_WhenCalled_UpdateContactInDB()
        {
            AddressBookRepo.RetrieveAllContacts();

            var list = AddressBookRepo.contacts;
            var contact = list[1];
            var previousName = contact.FirstName;
            contact.FirstName = "Mahesh";
            AddressBookRepo.UpdateContact(contact);
            AddressBookRepo.contacts.Clear();
            AddressBookRepo.RetrieveAllContacts();
            var newName = AddressBookRepo.contacts.FirstOrDefault(c => c.Id == contact.Id).FirstName;


            Assert.That(previousName, Is.Not.EqualTo(newName));
        }
        [Test]
        public void RetrieveAllContactsInDateRange_WhenCalled_AddContactsToList()
        {
            var startDate = Convert.ToDateTime("01/01/2019");
            var endDate = Convert.ToDateTime("01/01/2020");
            AddressBookRepo.RetrieveDetailsInDateRange(startDate, endDate);

            var list = AddressBookRepo.contacts;

            Assert.That(list, Is.Not.Empty);
        }
    }
}