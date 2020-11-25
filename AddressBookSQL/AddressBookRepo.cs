using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookSQL
{
    public class AddressBookRepo
    {
        public static string connectionString;
        public static SqlConnection sqlConnection;

        public static List<AddressModel> contacts;
        public static void SetConnection()
        {
            connectionString = @"Data Source=DESKTOP-SC0MR56\SQLEXPRESS;Initial Catalog=AddressBookServiceDataBase;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
        }
        /// <summary>
        /// Method to retrieve and display all contacts from addressBook
        /// hence there are 4 interdependent tables, used joins
        /// </summary>
        public static void RetrieveAllContacts()
        {
            contacts = new List<AddressModel>();
            try
            {
                SetConnection();
                using (sqlConnection)
                {
                    var query = @"select * from AddressBookService";
                    var sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlConnection.Open();
                    var dr = sqlCommand.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            AddressModel addressModel = new AddressModel();
                            addressModel.Id = Convert.ToInt32(dr["Id"]);
                            addressModel.FirstName = dr["FirstName"].ToString();
                            addressModel.LastName = dr["LastName"].ToString();
                            addressModel.Relation_Type = dr["Relation_Type"].ToString();
                            addressModel.Address = dr["Address"].ToString();
                            addressModel.City = dr["City"].ToString();
                            addressModel.State = dr["State"].ToString();
                            addressModel.Zipcode = dr["ZipCode"].ToString();
                            addressModel.PhoneNumber = dr["PhoneNumber"].ToString();
                            addressModel.Email = dr["Email"].ToString();
                            contacts.Add(addressModel);
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
