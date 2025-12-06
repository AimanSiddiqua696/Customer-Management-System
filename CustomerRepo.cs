using practiceproject.Product;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database.Customer
{
    internal class CustomerRepo
    {
        private readonly string file = @"C:\Users\User\Desktop\AimanSiddiqua\customers.txt";
        public CustomerRepo()
        {

        }
        public void SaveInFile(CustomerModel customer) //save the data for a single object in a file
        {
            using (StreamWriter stream = new StreamWriter(file, true))
            {
                stream.WriteLine(customer.ToString());

            }

        }
        public void SaveAllDataIntoFile(List<CustomerModel> customers)
        {
            //this code of lines also delete all the data from the file
            //means empty the file first and then foreach loop will run
            //using (StreamWriter stream = new StreamWriter(file, false))
            //{
            //    stream.Write(file, "");
            //        }
            //or instead of writing above code to empty the file we can only write a single line of code which is more good
            File.WriteAllText(file, ""); //this line delete all the data from the file
            foreach (CustomerModel customer in customers)
            {
                SaveInFile(customer);
            }
        }

        public List<CustomerModel> GetCustomersFromFile() //read the all data from the file and load into the list and return the list
                                                          //when we need all the data from the file , we call the function it will
                                                          //create a list load  all the data from the file into a list and return you a list 
        {
            List<CustomerModel> customersLists = new List<CustomerModel>();
            using (StreamReader stream = new StreamReader(file))
            {
                string line = "";
                while ((line = stream.ReadLine()) != null)
                {
                    if (line.Length > 5)
                    {
                        string[] parts = line.Split(',');
                        string customerName = parts[0];
                        string phonenumber = parts[1];
                        int age = int.Parse(parts[2]);
                        string address = parts[3];


                        //now we will create an object and then you will add this object to this list 
                        CustomerModel customerModel = new CustomerModel(customerName, phonenumber, age, address);
                        customersLists.Add(customerModel);
                    }


                }
            }
            return customersLists;
        }
        public readonly string DbConnection = "Server=LocalHost;Database=PointOfSale;Trusted_Connection=True";
        public bool Create(CustomerModel Customer)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection))
            {
                string query = "INSERT INTO CUSTOMER1 (cname, phonenumber, age, address)" +
                    "VALUES (@cname, @phonenumber, @age, @address)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cname", Customer.cname);
                cmd.Parameters.AddWithValue("@phonenumber", Customer.phonenumber);
                cmd.Parameters.AddWithValue("@age", Customer.age);
                cmd.Parameters.AddWithValue("@address", Customer.address);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool Update(CustomerModel customer)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection))
            {
                string query = "UPDATE CUSTOMER1 SET cname= @cname, phonenumber=@phonenumber, age=@age, address=@address WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", customer.id);
                cmd.Parameters.AddWithValue("@cname", customer.cname);
                cmd.Parameters.AddWithValue("@phonenumber", customer.phonenumber);
                cmd.Parameters.AddWithValue("@age", customer.age);
                cmd.Parameters.AddWithValue("@address", customer.address);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(DbConnection))
            {
                string query = "DELETE FROM CUSTOMER1 WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public List<CustomerModel> GetAll()
        {
            List<CustomerModel> customers = new List<CustomerModel>();
            using (SqlConnection conn = new SqlConnection(DbConnection))
            {
                string query = "SELECT id, cname, phonenumber, age, address FROM CUSTOMER1";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    string cname = reader["cname"].ToString();
                    string phonenumber = reader["phonenumber"].ToString();
                    int age = Convert.ToInt32(reader["age"]);
                    string address = reader["address"].ToString();
                  
                    CustomerModel product = new CustomerModel(id, cname, phonenumber, age, address);
                    customers.Add(product);
                }
                reader.Close();
            }
            return customers;

        }
    }
}

        

    