using System;

namespace AddressBookSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to AddressBook");                                     //Welcome Message

            AddressBookRepo.RetrieveAllContacts();                                           //Retrieve All Contact which is the database
            AddressBookRepo.DisplayContacts();                                               //Display function to show the Contacts

            Console.WriteLine();
            
            
            //To Update the AddressBook

            var contact = AddressBookRepo.contacts[1];                                      //Select the contact to be changed                                            
            contact.City = "Chennai";                                                       //Enter the city to be changed
            contact.State = "Tamil Nadu";                                                   //Relocated State
            AddressBookRepo.UpdateContact(contact);                                         //Update Function the contact

            Console.WriteLine();

            
            var startDate = Convert.ToDateTime("15/09/2020");
            var endDate = Convert.ToDateTime("30/09/2020");
            AddressBookRepo.RetrieveDetailsInDateRange(startDate, endDate);

            Console.WriteLine();

            //Addition

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

            AddressBookRepo.AddContact(addressModel);                                   //To Add Values

        }
    }
}
