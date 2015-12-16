using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arm_zapravka
{
    static class BD 
    {
        static readonly string CONNECTION = "Server = 127.0.0.1; User = root;" + "password = 123; Database = fuel;";


        public static DataTable Connection(string zapros)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection con = new MySqlConnection(CONNECTION))
            {
                con.Open();
                MySqlCommand com = new MySqlCommand(zapros, con);
                using (MySqlDataReader dr = com.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        dt.Load(dr);
                    }
                }
                return dt;
            }
        }

        public static DataTable GetFuel()
        {
            string zapros = @"Select * from Виды_топлива";
            return Connection(zapros);
        }

        public static DataTable GetRab()
        {
            string zapros = @"Select * from Рабочие";
            return Connection(zapros);
        }

        public static DataTable GetDol()
        {
            string zapros = @"Select * from Должности";
            return Connection(zapros);
        }

        public static DataTable GetClient()
        {
            string zapros = @"Select * from Клиенты";
            return Connection(zapros);
        }

        public static DataTable GetSale()
        {
            string zapros = @"Select * from Продажа";
            return Connection(zapros);
        }

        public static DataTable GetPostavka()
        {
            string zapros = @"Select * from Поставка_топлива";
            return Connection(zapros);
        }

        public static DataTable GetPostavshiki()
        {
            string zapros = @"Select * from Поставщики";
            return Connection(zapros);
        }
    }
}
