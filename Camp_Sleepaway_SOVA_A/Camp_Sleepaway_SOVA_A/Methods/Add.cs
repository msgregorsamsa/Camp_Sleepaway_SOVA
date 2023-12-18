using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camp_Sleepaway_SOVA.Methods
{
    public class Add : CampContext //Ärver från campcontext för att få åtkomst till connectionstringen?? 
    {
        public static void AddInformation(SqlConnection connection) //Lägg till metod för att lägga till med meny för val av vad man vill lägga till
        {
            Console.WriteLine("");
            string? Name = Console.ReadLine();

            Console.WriteLine("");
            string? Example1 = Console.ReadLine();

            Console.WriteLine("");
            string? Example2 = Console.ReadLine();

            Console.WriteLine("");
            string? Example3 = Console.ReadLine();

            Console.Clear();

            // SQL ska ersättas med LINQ i EF
            /* string? insertSQL = "INSERT INTO Customers () VALUES";
            insertSQL += $"('{Name}','{Example1}','{Example2}','{Example3}')";

            SqlCommand cmd = new SqlCommand(insertSQL, connection);
            cmd.ExecuteNonQuery(); */ 
        }
    }
}
