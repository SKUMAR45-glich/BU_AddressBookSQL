﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AddressBookSQL
{
    public class AddressBookRepo
    {
        public static string connectionString;                                                          
        public static SqlConnection sqlConnection;

        public static List<AddressModel> contacts = new List<AddressModel>();                                           //List to AddressModel                           
        public static void SetConnection()
        {
            connectionString = @"Data Source=DESKTOP-SC0MR56\SQLEXPRESS;Initial Catalog=AddressBookServiceDataBase;Integrated Security=True";           //Path for connection
            sqlConnection = new SqlConnection(connectionString);                                                                                        //Connection Link for Database
        }


        //Retrieve All ContactDetails
        public static void RetrieveAllContacts()                                                         
        {
                                                               
            try
            {
                SetConnection();                                                                                           //Set the connection
                using (sqlConnection)
                {
                    var query = @"select * from AddressBookService";                                                    //Query to select 
                    var sqlCommand = new SqlCommand(query, sqlConnection);                                              //Command to add query to connection
                    sqlConnection.Open();
                    var dr = sqlCommand.ExecuteReader();                                                                //Read the Query
                    if (dr.HasRows)                                                                                     //Number of rows is >0
                    {
                        while (dr.Read())                                                                             
                        {
                            AddressModel addressModel = new AddressModel();                                            //object for AddressModel
                           
                            addressModel.Id = Convert.ToInt32(dr["Id"]);
                            addressModel.FirstName = dr["FirstName"].ToString();
                            addressModel.LastName = dr["LastName"].ToString();
                            addressModel.Address = dr["Address"].ToString();
                            addressModel.City = dr["City"].ToString();
                            addressModel.State = dr["State"].ToString();
                            addressModel.Zipcode = dr["ZipCode"].ToString();
                            addressModel.PhoneNumber = dr["PhoneNumber"].ToString();
                            addressModel.Email = dr["Email"].ToString();
                            addressModel.Relation_Type = dr["Relation_Type"].ToString();

                            contacts.Add(addressModel);                                               //Add the values to the List
                        }
                    }

                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                sqlConnection.Close();                                                                     //Close the Connection
            }
        }

        public static void UpdateContact(AddressModel updateAddressModel)
        {
            try
            {
                SetConnection();                                                                      //Turn on the connection
                
                var sqlCommand = new SqlCommand("SpUpdateCityRelation", sqlConnection);                                 //Stored Procedure     
                sqlCommand.CommandType = CommandType.StoredProcedure;                                                   //command for Stored Procedure
                

                sqlCommand.Parameters.AddWithValue("@Id", updateAddressModel.Id);
                sqlCommand.Parameters.AddWithValue("@FirstName", updateAddressModel.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", updateAddressModel.LastName);
                sqlCommand.Parameters.AddWithValue("@RelationType", updateAddressModel.Relation_Type);
                sqlCommand.Parameters.AddWithValue("@Address", updateAddressModel.Address);
                sqlCommand.Parameters.AddWithValue("@City", updateAddressModel.City);
                sqlCommand.Parameters.AddWithValue("@State", updateAddressModel.State);
                sqlCommand.Parameters.AddWithValue("@Zipcode", updateAddressModel.Zipcode);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", updateAddressModel.PhoneNumber);
                sqlCommand.Parameters.AddWithValue("@Email", updateAddressModel.Email);
                
                sqlConnection.Open();         
                
                var dr = sqlCommand.ExecuteReader();                                                       //Read the Query
                
                if (dr.Read())
                {
                    
                    var contactModel = new AddressModel();
                    contactModel.Id = Convert.ToInt32(dr["Id"]);
                    contactModel.FirstName = dr["FirstName"].ToString();
                    contactModel.LastName = dr["LastName"].ToString();
                    contactModel.Relation_Type = dr["Relation_Type"].ToString();
                    contactModel.Address = dr["Address"].ToString();
                    contactModel.City = dr["City"].ToString();
                    contactModel.State = dr["State"].ToString();
                    contactModel.Zipcode = dr["ZipCode"].ToString();
                    contactModel.PhoneNumber = dr["PhoneNumber"].ToString();
                    contactModel.Email = dr["Email"].ToString();

                    var existingDetails = contacts.FirstOrDefault(c => c.Id == updateAddressModel.Id);          //FInd the ID of contact to update
                    
                    if (existingDetails != null)
                    {
                        contacts.Remove(existingDetails);                                              //Delete Entire existing
                        contacts.Add(contactModel);                                                   //Add Completely New
                    }
                    else
                        contacts.Add(contactModel);                                    //No Updation
                    contactModel.Display();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }


        public static void DisplayContacts()
        {
            foreach (var contact in contacts)
            {
                contact.Display();
            }
        }
    }
}
