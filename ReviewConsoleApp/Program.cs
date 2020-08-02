using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Model;

namespace ReviewConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string parameterDate = ConfigurationManager.AppSettings["DisableDate"];

            ClientInformation clientInformation = new ClientInformation();


           // clientInformation.DisableAccounts(DateTime.Parse(parameterDate));
            // void date time - xxx;

            //List<Movements> mov = new List<Movements>();
            //mov.get
            var movements = clientInformation.GetMovements();
            foreach (var movement in movements) 
            {
                Console.WriteLine("Test "+ Convert.ToString(movement.Id)+ " "+ movement.TipeMovements);
            }

            Console.ReadKey();

        }
    }
}
