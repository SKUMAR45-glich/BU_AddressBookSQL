using System;

namespace AddressBookSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to AddressBook");
            AddressBookRepo.RetrieveAllContacts();
            AddressBookRepo.DisplayContacts();
        }
    }
}
