using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookADo
{
    class CRUDOperation
    {
        public SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-NGODVI2\SQLEXPRESS;Initial Catalog=AddressBookDB;Integrated Security=True");

        public void InsertDataToAddressBook(Contact c)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spAddRecordInAddressBook", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@firstname", c.Firstname);
                    command.Parameters.AddWithValue("@lastname", c.Lastname);
                    command.Parameters.AddWithValue("@address", c.Address);
                    command.Parameters.AddWithValue("@city", c.City);
                    command.Parameters.AddWithValue("@state", c.State);
                    command.Parameters.AddWithValue("@email", c.Email);
                    command.Parameters.AddWithValue("@zipNo", c.Zipno);
                    command.Parameters.AddWithValue("@PhoneNumber", c.PhoneNo);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        Console.WriteLine("Insert successfully");
                    }

                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public void UpdatePhoneNumber()
        {
            try
            {
                using(this.connection)
                {
                    SqlCommand command = new SqlCommand("spEditPersonPhoneNumber", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@firstname", "Kalpesh");
                    command.Parameters.AddWithValue("@PhoneNumber", 9920036999);
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if(result != 0)
                    {
                        Console.WriteLine("updated record");
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}
