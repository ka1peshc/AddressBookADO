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

        public void DeleteRecordUsingFirstName()
        {
            try {
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spDeleteRowUsingFirstname", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@fname", "Kalpesh");
                    this.connection.Open();
                    var result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if(result != 0)
                    {
                        Console.WriteLine("Delete record successfully");
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

        public void RetrivePeopleBasedOnCity()
        {
            try
            {
                Contact c = new Contact();
                using (this.connection)
                {
                    SqlCommand command = new SqlCommand("spRetrivePersonBasedOnCityOrState", this.connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@City", "Mumbai");
                    this.connection.Open();
                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            c.Firstname = sqlDataReader[1].ToString();
                            c.Lastname = sqlDataReader[2].ToString();
                            c.Address = sqlDataReader[3].ToString();
                            c.City = sqlDataReader[4].ToString();
                            c.State = sqlDataReader[5].ToString();
                            c.Email = sqlDataReader[6].ToString();
                            c.Zipno = Convert.ToInt32(sqlDataReader[7]);
                            c.PhoneNo = Convert.ToInt64(sqlDataReader[8]);
                            Console.WriteLine(c.Firstname + "\t" + c.Lastname + "\t" + c.Address + "\t" + c.City +
                                "\t" + c.State + "\t" + c.Email + "\t" + c.Zipno + "\t" + c.PhoneNo);
                        }
                    }
                    this.connection.Close();
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

        public void SizeofAddressBookBasedOnCity()
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("spSizeofAddressBookBasedOnCity", this.connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@city", "Mumbai");
                    this.connection.Open();
                    int count = (int)cmd.ExecuteScalar();
                    this.connection.Close();
                    Console.WriteLine("Mumbai count is {0}", count);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public void SortedRecord()
        {
            try
            {
                Contact c = new Contact();
                string SortedQuery = @"SELECT * FROM AddressBook ORDER BY firstname";
                SqlCommand cmd = new SqlCommand(SortedQuery, this.connection);
                this.connection.Open();
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        c.Firstname = sqlDataReader[1].ToString();
                        c.Lastname = sqlDataReader[2].ToString();
                        c.Address = sqlDataReader[3].ToString();
                        c.City = sqlDataReader[4].ToString();
                        c.State = sqlDataReader[5].ToString();
                        c.Email = sqlDataReader[6].ToString();
                        c.Zipno = Convert.ToInt32(sqlDataReader[7]);
                        c.PhoneNo = Convert.ToInt64(sqlDataReader[8]);
                        Console.WriteLine(c.Firstname + "\t" + c.Lastname + "\t" + c.Address + "\t" + c.City +
                            "\t" + c.State + "\t" + c.Email + "\t" + c.Zipno + "\t" + c.PhoneNo);
                    }
                }
                this.connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public void SizeofAddressBookBasedOnType()
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand("spSizeofAddressBookBasedOnType", this.connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@type", "Friend");
                    this.connection.Open();
                    int count = (int)cmd.ExecuteScalar();
                    this.connection.Close();
                    Console.WriteLine("Friend count is {0}", count);
                }
            }
            catch (Exception e)
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
