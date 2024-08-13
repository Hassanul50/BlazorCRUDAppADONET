//using System.Transactions;

//namespace Blazor.Shared
//{
//    public class Class1
//    {
//        using Oracle.ManagedDataAccess.Client;
//using System;

//namespace OracleExample
//    {
//        class Program
//        {
//            static void Main(string[] args)
//            {
//                // Define the connection string
//                string connectionString = "User Id=myUsername;Password=myPassword;Data Source=myOracleDB;";

//                // Create a connection
//                using (OracleConnection connection = new OracleConnection(connectionString))
//                {
//                    try
//                    {
//                        // Open the connection
//                        connection.Open();
//                        Console.WriteLine("Connection opened successfully.");

//                        // Define a query
//                        string query = "SELECT * FROM myTable";

//                        // Create a command
//                        using (OracleCommand command = new OracleCommand(query, connection))
//                        {
//                            // Execute the command and get a reader
//                            using (OracleDataReader reader = command.ExecuteReader())
//                            {
//                                // Read data
//                                while (reader.Read())
//                                {
//                                    Console.WriteLine(reader["myColumn"].ToString());
//                                }
//                            }
//                        }
//                    }
//                    catch (OracleException ex)
//                    {
//                        Console.WriteLine("Oracle error: " + ex.Message);
//                    }
//                    catch (Exception ex)
//                    {
//                        Console.WriteLine("General error: " + ex.Message);
//                    }
//                }
//            }
//        }
//    }


//    using (OracleTransaction transaction = connection.BeginTransaction())
//{
//    try
//    {
//        // Execute your commands
//        // ...

//        // Commit the transaction
//        transaction.Commit();
//    }
//    catch
//    {
//    // Rollback the transaction in case of error
//    transaction.Rollback();
//}
//}


//}
//}
