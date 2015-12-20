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
            string zapros = @"Select * 
                               FROM Виды_топлива";
            return Connection(zapros);
        }

        public static DataTable GetFuelAll()
        {
            string zapros = @"Select Виды_топлива.* , Поставщики. Наименование_организации
                                FROM Виды_топлива, Поставщики
                                WHERE Виды_топлива.Код_поставщика = Поставщики.Код_поставщика";
            return Connection(zapros);
        }

        public static DataTable GetRabAll()
        {
            string zapros = @"Select Рабочие.*, Должности.Должность
                                FROM Рабочие, Должности
                                WHERE Рабочие.Код_должности = Должности.Код_должности";
            return Connection(zapros);
        }

        public static DataTable GetRab()
        {
            string zapros = @"Select *
                                FROM Рабочие";
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
            string zapros = @"Select *
                              FROM Продажа";
            return Connection(zapros);
        }

        public static DataTable GetSaleAll()
        {
            string zapros = @"Select Продажа.*, Клиенты.Фамилия_клиента, Виды_топлива.Вид_топлива, Рабочие.Фамилия_рабочего
                              FROM Продажа, Клиенты, Виды_топлива, Рабочие
                               WHERE Продажа.Код_клиента = Клиенты.Код_клиента AND Продажа.Код_топлива = Виды_топлива.Код_топлива AND Продажа.Код_рабочего = Рабочие.Код_рабочего";
            return Connection(zapros);
        }

        public static DataTable GetPostavka()
        {
            string zapros = @"Select *
                            FROM Поставка_топлива";
            return Connection(zapros);
        }

        public static DataTable GetPostavkaAll()
        {
            string zapros = @"Select Поставка_топлива.*, Поставщики.Наименование_организации, Виды_топлива.Вид_топлива
                            FROM Поставка_топлива, Поставщики, Виды_топлива
                            WHERE Поставка_топлива.Код_поставщика = Поставщики.Код_поставщика AND Поставка_топлива.Код_топлива = Виды_топлива.Код_топлива";
            return Connection(zapros);
        }

        public static DataTable GetPostavshiki()
        {
            string zapros = @"Select * from Поставщики";
            return Connection(zapros);
        }


        public static void GetSoldFuel()
        {
            string zapros = @"SELECT Запасы_топлива
                              FROM Виды_топлива
                              WHERE Код_топлива = " + Form1.codeFuel + ";";
            using (MySqlConnection con = new MySqlConnection(CONNECTION))
            {
                con.Open();
                MySqlCommand com = new MySqlCommand(zapros, con);
                using (MySqlDataReader dataReader = com.ExecuteReader())
                {

                    while (dataReader.Read())
                    {
                        string _allFuel = dataReader.GetValue(0).ToString();
                        Form1.allFuel = Int32.Parse(_allFuel);
                    }
                }
            }
        }
    }
}
