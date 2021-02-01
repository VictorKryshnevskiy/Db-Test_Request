using System;
using System.Data.SqlClient;
using System.Data.SqlServerCe;

namespace Db_Test_Request
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlCeConnection cn = new SqlCeConnection(@"Data Source = C:\Users\Виктор\Documents\Db-Test.db");
            string sqlExpression = "SELECT * FROM Account WHERE CreateON > 2015";
            cn.Open();
            SqlCeCommand command = new SqlCeCommand(sqlExpression, cn);
            SqlCeDataReader reader = command.ExecuteReader();
            // выводим названия столбцов
            Console.WriteLine("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));

            while (reader.Read()) // построчно считываем данные
            {
                object name = reader.GetValue(0);
                object create = reader.GetValue(1);
                object id = reader.GetValue(2);

                Console.WriteLine("{0} \t{1} \t{2}", name, create, id);
            }
            reader.Close();
            Console.Read();
        }
    }
}
