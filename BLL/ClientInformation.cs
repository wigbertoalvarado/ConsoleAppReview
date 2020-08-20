using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Model;
using System.Data;
using System.Data.SqlClient;
using BLL.Data;
using System.Data.Entity;

namespace BLL
{
    public class ClientInformation
    {
        private static string connectionString = $"Server={ConfigurationManager.AppSettings["Server"]};"
               + $"Database={ConfigurationManager.AppSettings["Database"]};"
               + $"Trusted_Connection={ConfigurationManager.AppSettings["Trusted_Connection"]}";
        
        public class GetClient : ClassAbstractClient 
        {
            
            public override List<Model.Client> GetClients()
            {
                string query = "Select top 10 *  from Client";
                List<Model.Client> clients = new List<Model.Client>();

                SqlConnection con = new SqlConnection(connectionString);

                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand(query, con);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        //DateTime bday;
                        //DateTime.TryParse((string)reader[5], out bday); validacion de datos sucios

                        var client = new Model.Client()
                        {
                            ClientId = (int)reader[0],
                            FirstName = (string)reader[1],
                            LastName = (string)reader[2],
                            Dni = (string)reader[3],
                            Dir = (string)reader[4],
                            Birthday = (DateTime)reader[5]
                        };
                        clients.Add(client);
                    }
                    reader.Close();
                    con.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error in the method GetClients " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
                return clients;
            }
        }
        public List<Model.Account> GetAccounts() 
        {
            string query = "select top 10 * from Account";
            List<Model.Account> accounts = new List<Model.Account>();

            SqlConnection con = new SqlConnection(connectionString);

            try 
            {
                con.Open();
                SqlCommand command = new SqlCommand(query, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Model.Account account = new Model.Account() 
                    {
                        AccountId = (int)reader[0],
                        AccountNumber = (string)reader[1],
                        AccountDescription = (string)reader[2],
                        CreationDate = (DateTime)reader[3],
                        AccountState = (bool)reader[4]
                    };
                    accounts.Add(account);
                }

                reader.Close();
                con.Close();
            } 
            catch (SqlException ex) 
            {
                Console.WriteLine("Error in the method GetAccounts " + ex.Message);
            } 
            finally 
            {
                con.Close();
            }

            return accounts;
        }

        public List<ClientAccountDto> GetClientAccounts() 
        {
            string query = "Select c.First_Name [FirstName], c.Last_Name LastName, c.DNI, a.Account_Number AccountNumber, a.Account_Description [Description], a.Creation_Date CreationDate " +
                            "From Client c " +
                            "inner join Client_Account ca on c.Client_Id = ca.Client_Id " +
                            "inner join Account a on ca.Account_Id = a.Account_Id and ca.Account_Number = a.Account_Number";
            List<ClientAccountDto> clientAccountDto = new List<ClientAccountDto>();

            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                con.Open();

                SqlCommand command = new SqlCommand(query, con);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ClientAccountDto clientAccount = new ClientAccountDto()
                    {
                        FirstName = (string)reader[0],
                        LastName = (string)reader[1],
                        DNI = (string)reader[2],
                        AccountNumber = (string)reader[3],
                        Description = (string)reader[4],
                        CreationDate = (DateTime)reader[5]
                    };
                    clientAccountDto.Add(clientAccount);
                }
                reader.Close();
                con.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error in the method GetClientAccounts " + ex.Message);
            }
            finally 
            {
                con.Close();
            }

            return clientAccountDto;
        }

        public void DisableAccounts(DateTime expirationDate) 
        { 
          
            try
            {
                using (var context = new Account_ClientEntities()) 
                {
                    var accountsToUpdate = context.Accounts.Where(a => a.Creation_Date < expirationDate).ToList();

                    foreach (var account in accountsToUpdate) 
                    {
                        account.Account_State = false;
                    }

                    context.Entry(accountsToUpdate).State = EntityState.Modified;
                    context.SaveChanges();
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error in the method DisableAccounts " + ex.Message);
            }

        }

        public List<Movements> GetMovements() {

            string query = "select top 10 * from Movements";

            List<Movements> movements = new List<Movements>();

            SqlConnection con = new SqlConnection(connectionString);

            try 
            {
                con.Open();

                SqlCommand command = new SqlCommand(query,con);

                SqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    Movements mov = new Movements()
                    {
                        Id =(int)reader[0],
                        TipeMovements = (string)reader[1],
                        Description = (string)reader[2],
                        DateActual = (DateTime)reader[3]
                    };
                    movements.Add(mov);
                }
                reader.Close();
                con.Close();

            } 
            catch (SqlException ex)
            {
                Console.WriteLine("This error in the method GetMovements"+ ex.Message);
            } 
            finally
            {
                con.Close();
            }


            return movements;
        }

    }
}
