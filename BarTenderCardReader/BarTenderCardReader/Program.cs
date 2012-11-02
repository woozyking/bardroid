using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Odbc;

namespace BarTenderCardReader
{
    class Program
    {
        private static string dbInfo = "DRIVER={MySQL ODBC 5.1 Driver};" +
                  "SERVER=localhost;" +
                  "DATABASE=bartender;" +
                  "UID=root;" +
                  "PASSWORD=;" +
                  "OPTION=3";

        private static OdbcConnection myConnection;
        private static OdbcCommand myQuery;

        static void Main(string[] args)
        {
            Connect();
            ConsoleKeyInfo kb;
            string input = string.Empty;
            while (true)
            {
                input = string.Empty;
                do
                {
                    kb = Console.ReadKey();

                    if (kb.Key == ConsoleKey.Oem2) //?                  
                        break;
                    input += kb.KeyChar;
                } while (true);
                InsertBarCode(ValidateAge(input));
            }
            Disconnect();
        }        

        public static void Connect()
        {
            myConnection = new OdbcConnection(dbInfo);
            myConnection.Open();
            myQuery = myConnection.CreateCommand();            
        }

        public static void Disconnect()
        {
            myConnection.Close();
        }

        public static void InsertBarCode(string value)
        {            
            try
            {
                string query = "Insert into barcode (barcode) Values ('" + value + "')";                

                myQuery.CommandText = query;
                OdbcDataReader myDataReader = myQuery.ExecuteReader();
                myDataReader.Close();
            }
            catch (OdbcException MyOdbcException) //Catch any ODBC exception ..
            {
                Console.WriteLine(MyOdbcException.Errors[0].Message);
            }
        }

        public static string ValidateAge(string barcode)
        {
            string[] parts = barcode.Split('=');
            if (parts.Length >= 1)
            {
                int birthday = int.Parse(parts[1].Substring(4, 8));
                string todayMonth = DateTime.Now.Month > 9 ? DateTime.Now.Month.ToString() : "0" + DateTime.Now.Month.ToString();
                string todayDay = DateTime.Now.Day > 9 ? DateTime.Now.Day.ToString() : "0" + DateTime.Now.Day.ToString();
                int today = int.Parse(DateTime.Now.Year.ToString() + todayMonth + todayDay);

                if (today - birthday > 190000)
                    return "pass";
                else
                    return "underage";
            }
            return "error";
        }
   }
}
