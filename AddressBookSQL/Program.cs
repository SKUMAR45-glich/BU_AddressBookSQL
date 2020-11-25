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


            //To Update the AddressBook

            var contact = AddressBookRepo.contacts[1];                                      //Select the contact to be changed                                            
            contact.City = "Chennai";                                                       //Enter the city to be changed
            contact.State = "Tamil Nadu";                                                   //Relocated State
            AddressBookRepo.UpdateContact(contact);                                         //Update Function the contact
        }
    }
}
