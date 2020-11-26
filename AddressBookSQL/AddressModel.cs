using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSQL
{
    public class AddressModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Relation_Type { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateofJoining { get; set; }


        public AddressModel(string firstName, string lastName, string relation_type, string address, string city, string state, string zipcode, string phonenumber, string email, DateTime dateofJoining)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Relation_Type =relation_type;
            this.Address = address;
            this.City = city;
            this.State = state;
            this.Zipcode = zipcode;
            this.PhoneNumber = phonenumber;
            this.Email = email;
            this.DateofJoining = dateofJoining;
        }

        public AddressModel()
        {
        }

        public void Display()
        {
            Console.Write(Id + " " + FirstName + " " + LastName + " " + Relation_Type + " " + Address
                + " " + City + " " + State + " " + Zipcode + " " + PhoneNumber + " " + Email + " "+DateofJoining+"\n");
        }
    }
}
