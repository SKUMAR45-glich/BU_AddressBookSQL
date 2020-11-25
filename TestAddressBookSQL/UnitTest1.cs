using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBookSQL;
using System.Collections.Generic;
using System;

namespace TestAddressBookSQL
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<AddressModel> addressModel = new List<AddressModel>();
            AddressBookRepo addressBookRepo = new AddressBookRepo();

            addressModel.Add(new AddressModel("Virat", "Kohli","Captain","Delhi","NewDelhi", "India", "147852","9999999","vk@gmail.com", new DateTime(2020,11,5)));
            addressModel.Add(new AddressModel("Mahi", "Dhoni", "Legend", "Ranchi", "Chennai", "India", "148852", "9989999", "msd@gmail.com", new DateTime(2020, 8, 15)));

            DateTime startDateTime = DateTime.Now;
            addressBookRepo.AddMultipleAddress(addressModel);
            DateTime endDateTime = DateTime.Now;
            Console.WriteLine("Without Thread : " + (endDateTime - startDateTime));

            DateTime startDateTimeThread = DateTime.Now;
            addressBookRepo.AddMultipleAddressWithThread(addressModel);
            DateTime endDateTimeThread = DateTime.Now;
            Console.WriteLine("With Thread : " + (endDateTimeThread - startDateTimeThread));
        }
    }
}
