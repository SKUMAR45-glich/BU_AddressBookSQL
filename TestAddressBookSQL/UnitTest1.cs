using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBookSQL;
using System.Collections.Generic;
using System;
using RestSharp;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TestAddressBookSQL
{
    [TestClass]
    public class UnitTest1
    {
        //Test for Thread
        [TestMethod]
        public void TestMethod1()
        {
            List<AddressModel> addressModel = new List<AddressModel>();                            //List for Multiple List            //
            AddressBookRepo addressBookRepo = new AddressBookRepo();

            //Addition of Multiple Address
            addressModel.Add(new AddressModel("Virat", "Kohli", "Captain", "Delhi", "NewDelhi", "India", "147852", "9999999", "vk@gmail.com", new DateTime(2020, 11, 5)));
            addressModel.Add(new AddressModel("Mahi", "Dhoni", "Legend", "Ranchi", "Chennai", "India", "148852", "9989999", "msd@gmail.com", new DateTime(2020, 8, 15)));


            //Time taken to Add Contact without Thread

            DateTime startDateTime = DateTime.Now;                                       //Initialization
            addressBookRepo.AddMultipleAddress(addressModel);
            DateTime endDateTime = DateTime.Now;                                         //Completion
            Console.WriteLine("Without Thread : " + (endDateTime - startDateTime));


            //Time taken to Add Contact with Thread

            DateTime startDateTimeThread = DateTime.Now;                                       //Initialization
            addressBookRepo.AddMultipleAddressWithThread(addressModel);
            DateTime endDateTimeThread = DateTime.Now;                                         //Completion
            Console.WriteLine("With Thread : " + (endDateTimeThread - startDateTimeThread));
        }

        RestClient client;

        [TestInitialize]

        //Link to add Link
        public void SetUp()
        {
            client = new RestClient("http://localhost:4000/address");
        }



        private IRestResponse getAddressList()
        {
            //arrange
            RestRequest request = new RestRequest("/list", Method.GET);              //Retrieving AddressList 

            //act
            IRestResponse response = client.Execute(request);
            return response;
        }


        [TestMethod]
        public void countingContactInAddressList()
        {
            IRestResponse response = getAddressList();

            //Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);                                 //Checking the Status
            List<AddressBook> dataResponse = JsonConvert.DeserializeObject<List<AddressBook>>(response.Content);          //Desrializing Object
            Assert.AreEqual(9, dataResponse.Count);                                                          //Counting the responses that matches


            //Retrieving the data from the DataResponse 
            foreach (var item in dataResponse)
            {
                Console.WriteLine("ID " + item.id + " Name: " + item.name + " Salary " + item.salary);                        //Display the result
            }
        }


    }
}
