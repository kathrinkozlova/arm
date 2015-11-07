using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Arm_zapravka
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        DataTable GetFuel()
        {
            comboBox1.BringToFront();            
            new MySqlConnectionStringBuilder();
            const string connection = "Server = 127.0.0.1; User = root;" + "password = 123; Database = fuel;";

            var zaprosF = @"Select * from Виды_топлива";

            DataTable dt = new DataTable();

            using (MySqlConnection con = new MySqlConnection(connection))
            {
                con.Open();
                MySqlCommand com = new MySqlCommand(zaprosF, con);
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

        DataTable GetRab()
        {  
            new MySqlConnectionStringBuilder();
            string connection = "Server = 127.0.0.1; User = root;" + "password = 123; Database = fuel;";

            string zaprosR = @"Select * from Рабочие";

            DataTable dt = new DataTable();

            using (MySqlConnection con = new MySqlConnection(connection))
            {
                con.Open();
                MySqlCommand com = new MySqlCommand(zaprosR, con);
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

        DataTable GetDol()
        {

            new MySqlConnectionStringBuilder();
            string connection = "Server = 127.0.0.1; User = root;" + "password = 123; Database = fuel;";

            string zaprosD = @"Select * from Должности";

            DataTable dt = new DataTable();

            using (MySqlConnection con = new MySqlConnection(connection))
            {
                con.Open();
                MySqlCommand com = new MySqlCommand(zaprosD, con);
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

        DataTable GetClient()
        {

            new MySqlConnectionStringBuilder();
            var connection = "Server = 127.0.0.1; User = root;" + "password = 123; Database = fuel;";

            string zaprosP = @"Select * from Клиенты";

            DataTable dt = new DataTable();

            using (MySqlConnection con = new MySqlConnection(connection))
            {
                con.Open();
                MySqlCommand com = new MySqlCommand(zaprosP, con);
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

        DataTable GetSale()
        {
            new MySqlConnectionStringBuilder();
            string connection = "Server = 127.0.0.1; User = root;" + "password = 123; Database = fuel;";

            string zaprosP = @"Select * from Скидки";

            DataTable dt = new DataTable();

            using (MySqlConnection con = new MySqlConnection(connection))
            {
                con.Open();
                MySqlCommand com = new MySqlCommand(zaprosP, con);
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

        DataTable GetPostavka()
        {

            new MySqlConnectionStringBuilder();
            string connection = "Server = 127.0.0.1; User = root;" + "password = 123; Database = fuel;";

            string zaprosP = @"Select * from Поставка_топлива";

            DataTable dt = new DataTable();

            using (MySqlConnection con = new MySqlConnection(connection))
            {
                con.Open();
                MySqlCommand com = new MySqlCommand(zaprosP, con);
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

        DataTable GetPostavshiki()
        {

            new MySqlConnectionStringBuilder();
            string connection = "Server = 127.0.0.1; User = root;" + "password = 123; Database = fuel;";

            string zaprosP = @"Select * from Поставщики";

            DataTable dt = new DataTable();

            using (MySqlConnection con = new MySqlConnection(connection))
            {
                con.Open();
                MySqlCommand com = new MySqlCommand(zaprosP, con);
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

        private void InsertDataFuel()
        {
            string connection = @"server=127.0.0.1; user=root;Database=fuel; password=123;";

            using (MySqlConnection con = new MySqlConnection(connection))
            {
                try
                {
                    string sql = @"SET FOREIGN_KEY_CHECKS=0; INSERT INTO Виды_топлива (Вид_топлива, Цена, Запасы_топлива, Код_поставки) 
                    VALUES (@Вид_топлива, @Цена, @Запасы_топлива, @Код_поставки);";

                    con.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    //создаем параметры и добавляем их в коллекцию
                    if (dataGridView2.CurrentRow != null)
                    {
                        cmd.Parameters.AddWithValue("@Вид_топлива", dataGridView2.CurrentRow.Cells[1].Value);
                        cmd.Parameters.AddWithValue("@Цена", dataGridView2.CurrentRow.Cells[2].Value);
                        cmd.Parameters.AddWithValue("@Запасы_топлива", dataGridView2.CurrentRow.Cells[3].Value);
                        cmd.Parameters.AddWithValue("@Код_поставки", dataGridView2.CurrentRow.Cells[4].Value);
                    }

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DeleteFuel()
        {
            string connection = @"server=127.0.0.1;user=root;Database=fuel;password=123;";

            using (MySqlConnection con = new MySqlConnection(connection))
            {
                try
                {
                    string sql = "DELETE FROM Виды_топлива " +
                                 "WHERE Код_топлива = @Код_топлива";

                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Код_топлива", dataGridView2.CurrentRow.Cells[0].Value);
                    cmd.ExecuteNonQuery();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void UpdateFuel()
        {
            string connection = @"server=127.0.0.1;user=root;Database=fuel;password=123;";

            using (MySqlConnection con = new MySqlConnection(connection))
            {
                try
                {
                    string sql = @"UPDATE Виды_топлива
                                   SET Вид_топлива = @Вид_топлива, Цена = @Цена, Запасы_топлива = @Запасы_топлива, Код_поставки = @Код_поставки
                                   WHERE Код_топлива = @Код_топлива";
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    if (dataGridView2.CurrentRow != null)
                    {
                        cmd.Parameters.AddWithValue("@Код_топлива", dataGridView2.CurrentRow.Cells[0].Value);
                        cmd.Parameters.AddWithValue("@Вид_топлива", dataGridView2.CurrentRow.Cells[1].Value);
                        cmd.Parameters.AddWithValue("@Цена", dataGridView2.CurrentRow.Cells[2].Value);
                        cmd.Parameters.AddWithValue("@Запасы_топлива", dataGridView2.CurrentRow.Cells[3].Value);
                        cmd.Parameters.AddWithValue("@Код_поставки", dataGridView2.CurrentRow.Cells[4].Value);
                    }
                    cmd.ExecuteNonQuery();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void InsertDataDol()
        {
            string connection = @"server=127.0.0.1; user=root;Database=fuel; password=123;";

            using (MySqlConnection con = new MySqlConnection(connection))
            {
                try
                {
                    string sql = @"SET FOREIGN_KEY_CHECKS=0; INSERT INTO Должности (Должность) 
                    VALUES (@Должность);";

                    con.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    //создаем параметры и добавляем их в коллекцию
                    if (dataGridView3.CurrentRow != null)
                        cmd.Parameters.AddWithValue("@Должность", dataGridView3.CurrentRow.Cells[1].Value);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DeleteDol()
        {
            string connection = @"server=127.0.0.1;user=root;Database=fuel;password=123;";

            using (MySqlConnection con = new MySqlConnection(connection))
            {
                try
                {
                    string sql = "DELETE FROM Должности " +
                                 "WHERE Код_должности = @Код_должности";

                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Код_должности", dataGridView3.CurrentRow.Cells[0].Value);
                    cmd.ExecuteNonQuery();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void UpdateDol()
        {
            string connection = @"server=127.0.0.1;user=root;Database=fuel;password=123;";

            using (MySqlConnection con = new MySqlConnection(connection))
            {
                try
                {
                    string sql = @"UPDATE Должности
                                   SET Должность = @Должность
                                   WHERE Код_должности = @Код_должности";
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    if (dataGridView3.CurrentRow != null)
                    {
                        cmd.Parameters.AddWithValue("@Код_должности", dataGridView3.CurrentRow.Cells[0].Value);
                        cmd.Parameters.AddWithValue("@Должность", dataGridView3.CurrentRow.Cells[1].Value);
                    }
                    cmd.ExecuteNonQuery();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void InsertDataRab()
        {
            string connection = @"server=127.0.0.1; user=root;Database=fuel; password=123;";

            using (MySqlConnection con = new MySqlConnection(connection))
            {
                try
                {
                    string sql = @"SET FOREIGN_KEY_CHECKS=0; INSERT INTO Рабочие (Фамилия, Имя, Отчество, Пол, Возраст, Код_должности, Телефон, Оклад) 
                    VALUES (@Фамилия,@Имя, @Отчество,@Пол, @Возраст, @Код_должности, @Телефон, @Оклад);";

                    con.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    //создаем параметры и добавляем их в коллекцию
                    if (dataGridView4.CurrentRow != null)
                    {
                        cmd.Parameters.AddWithValue("@Фамилия", dataGridView4.CurrentRow.Cells[1].Value);
                        cmd.Parameters.AddWithValue("@Имя", dataGridView4.CurrentRow.Cells[2].Value);
                        cmd.Parameters.AddWithValue("@Отчество", dataGridView4.CurrentRow.Cells[3].Value);
                        cmd.Parameters.AddWithValue("@Пол", dataGridView4.CurrentRow.Cells[4].Value);
                        cmd.Parameters.AddWithValue("@Возраст", dataGridView4.CurrentRow.Cells[5].Value);
                        cmd.Parameters.AddWithValue("@Код_должности", dataGridView4.CurrentRow.Cells[6].Value);
                        cmd.Parameters.AddWithValue("@Телефон", dataGridView4.CurrentRow.Cells[7].Value);
                        cmd.Parameters.AddWithValue("@Оклад", dataGridView4.CurrentRow.Cells[8].Value);
                    }
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DeleteRab()
        {
            string connection = @"server=127.0.0.1;user=root;Database=fuel;password=123;";

            using (MySqlConnection con = new MySqlConnection(connection))
            {
                try
                {
                    string sql = "DELETE FROM Рабочие " +
                                 "WHERE Код_рабочего = @Код_рабочего";

                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Код_рабочего", dataGridView4.CurrentRow.Cells[0].Value);
                    cmd.ExecuteNonQuery();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void UpdateRab()
        {
            string connection = @"server=127.0.0.1;user=root;Database=fuel;password=123;";

            using (MySqlConnection con = new MySqlConnection(connection))
            {
                try
                {
                    string sql = @"UPDATE Рабочие
                                   SET Фамилия = @Фамилия, Имя = @Имя, Отчество = @Отчество, Пол = @Пол, Возраст = @Возраст, Код_должности = @Код_должности, Телефон = @Телефон, Оклад = @Оклад
                                   WHERE Код_рабочего = @Код_рабочего";
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    if (dataGridView4.CurrentRow != null)
                    {
                        cmd.Parameters.AddWithValue("@Код_рабочего", dataGridView4.CurrentRow.Cells[0].Value);
                        cmd.Parameters.AddWithValue("@Фамилия", dataGridView4.CurrentRow.Cells[1].Value);
                        cmd.Parameters.AddWithValue("@Имя", dataGridView4.CurrentRow.Cells[2].Value);
                        cmd.Parameters.AddWithValue("@Отчество", dataGridView4.CurrentRow.Cells[3].Value);
                        cmd.Parameters.AddWithValue("@Пол", dataGridView4.CurrentRow.Cells[4].Value);
                        cmd.Parameters.AddWithValue("@Возраст", dataGridView4.CurrentRow.Cells[5].Value);
                        cmd.Parameters.AddWithValue("@Код_должности", dataGridView4.CurrentRow.Cells[6].Value);
                        cmd.Parameters.AddWithValue("@Телефон", dataGridView4.CurrentRow.Cells[7].Value);
                        cmd.Parameters.AddWithValue("@Оклад", dataGridView4.CurrentRow.Cells[8].Value);
                    }
                    cmd.ExecuteNonQuery();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void InsertDataClient()
        {
            string connection = @"server=127.0.0.1; user=root;Database=fuel; password=123;";

            using (MySqlConnection con = new MySqlConnection(connection))
            {
                try
                {
                    string sql = @"SET FOREIGN_KEY_CHECKS=0; INSERT INTO Клиенты (Фамилия, Имя, Отчество, Телефон, Код_накопительной_карты) 
                    VALUES (@Фамилия,@Имя, @Отчество, @Телефон, @Код_накопительной_карты);";

                    con.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    //создаем параметры и добавляем их в коллекцию
                    if (dataGridView1.CurrentRow != null)
                    {
                        cmd.Parameters.AddWithValue("@Фамилия", dataGridView1.CurrentRow.Cells[1].Value);
                        cmd.Parameters.AddWithValue("@Имя", dataGridView1.CurrentRow.Cells[2].Value);
                        cmd.Parameters.AddWithValue("@Отчество", dataGridView1.CurrentRow.Cells[3].Value);
                        cmd.Parameters.AddWithValue("@Телефон", dataGridView1.CurrentRow.Cells[4].Value);
                        cmd.Parameters.AddWithValue("@Код_накопительной_карты", dataGridView1.CurrentRow.Cells[5].Value);
                    }
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DeleteClient()
        {
            string connection = @"server=127.0.0.1;user=root;Database=fuel;password=123;";

            using (MySqlConnection con = new MySqlConnection(connection))
            {
                try
                {
                    string sql = "DELETE FROM Клиенты " +
                                 "WHERE Код_клиента = @Код_клиента";

                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    if (dataGridView1.CurrentRow != null)
                        cmd.Parameters.AddWithValue("@Код_клиента", value: dataGridView1.CurrentRow.Cells[0].Value);
                    cmd.ExecuteNonQuery();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void UpdateClient()
        {
            string connection = @"server=127.0.0.1;user=root;Database=fuel;password=123;";

            using (MySqlConnection con = new MySqlConnection(connection))
            {
                try
                {
                    string sql = @"UPDATE Клиенты
                                   SET Фамилия = @Фамилия, Имя = @Имя, Отчество = @Отчество, Телефон = @Телефон, Код_карты = @Код_карты
                                   WHERE Код_клиента = @Код_клиента";
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    if (dataGridView1.CurrentRow != null)
                    {
                        cmd.Parameters.AddWithValue("@Код_клиента", dataGridView1.CurrentRow.Cells[0].Value);
                        cmd.Parameters.AddWithValue("@Фамилия", dataGridView1.CurrentRow.Cells[1].Value);
                        cmd.Parameters.AddWithValue("@Имя", dataGridView1.CurrentRow.Cells[2].Value);
                        cmd.Parameters.AddWithValue("@Отчество", dataGridView1.CurrentRow.Cells[3].Value);
                        cmd.Parameters.AddWithValue("@Телефон", dataGridView1.CurrentRow.Cells[4].Value);
                        cmd.Parameters.AddWithValue("@Код_карты", dataGridView1.CurrentRow.Cells[5].Value);
                    }
                    cmd.ExecuteNonQuery();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void InsertDataSale()
        {
            string connection = @"server=127.0.0.1; user=root;Database=fuel; password=123;";

            using (MySqlConnection con = new MySqlConnection(connection))
            {
                try
                {
                    string sql = @"SET FOREIGN_KEY_CHECKS=0; INSERT INTO Скидки (Количество_заправок, Код_клиента, Скидка ) 
                    VALUES (@Количество_заправок, @Код_клиента, @Скидка );";

                    con.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    //создаем параметры и добавляем их в коллекцию
                    if (dataGridView5.CurrentRow != null)
                    {
                        cmd.Parameters.AddWithValue("@Количество_заправок", dataGridView5.CurrentRow.Cells[1].Value);
                        cmd.Parameters.AddWithValue("@Код_клиента", dataGridView5.CurrentRow.Cells[2].Value);
                        cmd.Parameters.AddWithValue("@Скидка", dataGridView5.CurrentRow.Cells[3].Value);
                    }
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DeleteSale()
        {
            string connection = @"server=127.0.0.1;user=root;Database=fuel;password=123;";

            using (MySqlConnection con = new MySqlConnection(connection))
            {
                try
                {
                    string sql = "DELETE FROM Скидки " +
                                  "WHERE Код_карты = @Код_карты";

                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Код_карты", dataGridView5.CurrentRow.Cells[0].Value);
                    cmd.ExecuteNonQuery();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void UpdateSale()
        {
            string connection = @"server=127.0.0.1;user=root;Database=fuel;password=123;";

            using (MySqlConnection con = new MySqlConnection(connection))
            {
                try
                {
                    string sql = @"UPDATE Скидки
                                   SET Количество_заправок = @Количество_заправок, Код_клиента = @Код_клиента, Скидка = @Скидка
                                   WHERE Код_карты = @Код_карты";
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    if (dataGridView5.CurrentRow != null)
                    {
                        cmd.Parameters.AddWithValue("@Код_карты", dataGridView5.CurrentRow.Cells[0].Value);
                        cmd.Parameters.AddWithValue("@Количество_заправок", dataGridView5.CurrentRow.Cells[1].Value);
                        cmd.Parameters.AddWithValue("@Код_клиента", dataGridView5.CurrentRow.Cells[2].Value);
                        cmd.Parameters.AddWithValue("@Скидка", dataGridView5.CurrentRow.Cells[3].Value);
                    }
                    cmd.ExecuteNonQuery();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void InsertDataPostavshiki()
        {
            string connection = @"server=127.0.0.1; user=root;Database=fuel; password=123;";

            using (MySqlConnection con = new MySqlConnection(connection))
            {
                try
                {
                    string sql = @"SET FOREIGN_KEY_CHECKS=0; INSERT INTO Поставщики (Наименование_организации, Телефон_организации) 
                    VALUES (@Наименование_организации, @Телефон_организации);";

                    con.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    //создаем параметры и добавляем их в коллекцию
                    if (dataGridView6.CurrentRow != null)
                    {
                        cmd.Parameters.AddWithValue("@Наименование_организации", dataGridView6.CurrentRow.Cells[1].Value);
                        cmd.Parameters.AddWithValue("@Телефон_организации", dataGridView6.CurrentRow.Cells[2].Value);
                    }
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DeletePostavshiki()
        {
            string connection = @"server=127.0.0.1;user=root;Database=fuel;password=123;";

            using (MySqlConnection con = new MySqlConnection(connection))
            {
                try
                {
                    string sql = "DELETE FROM Поставщики " +
                                  "WHERE Код_поставщика = @Код_поставщика";

                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Код_поставщика", dataGridView6.CurrentRow.Cells[0].Value);
                    cmd.ExecuteNonQuery();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void UpdatePostavshiki()
        {
            string connection = @"server=127.0.0.1;user=root;Database=fuel;password=123;";

            using (MySqlConnection con = new MySqlConnection(connection))
            {
                try
                {
                    string sql = @"UPDATE Поставщики
                                   SET Наименование_организации = @Наименование_организации, Телефон_организации = @Телефон_организации
                                   WHERE Код_поставщика = @Код_поставщика";
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    if (dataGridView6.CurrentRow != null)
                    {
                        cmd.Parameters.AddWithValue("@Код_поставщика", dataGridView6.CurrentRow.Cells[0].Value);
                        cmd.Parameters.AddWithValue("@Наименование_организации", dataGridView6.CurrentRow.Cells[1].Value);
                        cmd.Parameters.AddWithValue("@Телефон_организации", dataGridView6.CurrentRow.Cells[2].Value);
                    }
                    cmd.ExecuteNonQuery();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void InsertDataPostavka()
        {
            string connection = @"server=127.0.0.1; user=root;Database=fuel; password=123;";

            using (MySqlConnection con = new MySqlConnection(connection))
            {
                try
                {
                    string sql = @"SET FOREIGN_KEY_CHECKS=0; INSERT INTO Поставка_топлива (Код_поставщика, Количество_поставки, Код_топлива) 
                    VALUES (@Код_поставщика, @Количество_поставки, @Код_топлива);";

                    con.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    //создаем параметры и добавляем их в коллекцию
                    if (dataGridView7.CurrentRow != null)
                    {
                        cmd.Parameters.AddWithValue("@Код_поставщика", dataGridView7.CurrentRow.Cells[1].Value);
                        cmd.Parameters.AddWithValue("@Количество_поставки", dataGridView7.CurrentRow.Cells[2].Value);
                        cmd.Parameters.AddWithValue("@Код_топлива", dataGridView7.CurrentRow.Cells[3].Value);
                    }
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DeletePostavka()
        {
            string connection = @"server=127.0.0.1;user=root;Database=fuel;password=123;";

            using (MySqlConnection con = new MySqlConnection(connection))
            {
                try
                {
                    string sql = "DELETE FROM Поставка_топлива " +
                                  "WHERE Код_поставки = @Код_поставки";

                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Код_поставки", dataGridView7.CurrentRow.Cells[0].Value);
                    cmd.ExecuteNonQuery();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void UpdatePostavka()
        {
            string connection = @"server=127.0.0.1;user=root;Database=fuel;password=123;";

            using (MySqlConnection con = new MySqlConnection(connection))
            {
                try
                {
                    string sql = @"UPDATE Поставка_топлива
                                   SET Код_поставщика = @Код_поставщика, Количество_поставки = @Количество_поставки, Код_топлива = @Код_топлива
                                   WHERE Код_поставки = @Код_поставки";
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    if (dataGridView7.CurrentRow != null)
                    {
                        cmd.Parameters.AddWithValue("@Код_поставки", dataGridView7.CurrentRow.Cells[0].Value);
                        cmd.Parameters.AddWithValue("@Код_поставщика", dataGridView7.CurrentRow.Cells[1].Value);
                        cmd.Parameters.AddWithValue("@Количество_поставки", dataGridView7.CurrentRow.Cells[2].Value);
                        cmd.Parameters.AddWithValue("@Код_топлива", dataGridView7.CurrentRow.Cells[3].Value);
                    }
                    cmd.ExecuteNonQuery();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    {
                        InsertDataFuel();
                        dataGridView2.DataSource = GetFuel();
                        break;
                    }
                case 1:
                    {
                        InsertDataDol();
                        dataGridView3.DataSource = GetDol();
                        break;
                    }
                case 2:
                    {
                        InsertDataRab();
                        dataGridView4.DataSource = GetRab();
                        break;
                    }
                case 3:
                    {
                        InsertDataClient();
                        dataGridView1.DataSource = GetClient();
                        break;
                    }
                case 4:
                    {
                        InsertDataSale();
                        dataGridView5.DataSource = GetSale();
                        break;
                    }
                case 5:
                    {
                        InsertDataPostavshiki();
                        dataGridView6.DataSource = GetPostavshiki();
                        break;
                    }
                case 6:
                    {
                        InsertDataPostavka();
                        dataGridView7.DataSource = GetPostavka();
                        break;
                    }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    {
                        DeleteFuel();
                        dataGridView2.DataSource = GetFuel();
                        break;
                    }
                case 1:
                    {
                        DeleteDol();
                        dataGridView3.DataSource = GetDol();
                        break;
                    }
                case 2:
                    {
                        DeleteRab();
                        dataGridView4.DataSource = GetRab();
                        break;
                    }
                case 3:
                    {
                        DeleteClient();
                        dataGridView1.DataSource = GetClient();
                        break;
                    }
                case 4:
                    {
                        DeleteSale();
                        dataGridView5.DataSource = GetSale();
                        break;
                    }
                case 5:
                    {
                        DeletePostavshiki();
                        dataGridView6.DataSource = GetPostavshiki();
                        break;
                    }
                case 6:
                    {
                        DeletePostavka();
                        dataGridView7.DataSource = GetPostavka();
                        break;
                    }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
               switch (tabControl1.SelectedIndex)
              { 
                  case 0:
                      comboBox1.Items.Clear();
                      object[] searchFuel = { "Поиск по коду топлива", "Поиск по названию топлива", "Поиск по запасам топлива", "Поиск по коду поставки" };
                      comboBox1.Items.AddRange(searchFuel);
                      comboBox1.SelectedIndex = 0;
                      break;
                  case 1:
                      comboBox1.Items.Clear();
                      object[] searchDol = { "Поиск по коду должности", "Поиск по названю должности"};
                      comboBox1.Items.AddRange(searchDol);
                      comboBox1.SelectedIndex = 0;
                      break;
                  case 2:
                      comboBox1.Items.Clear();
                      object[] searchRab = { "Поиск по коду рабочего", "Поиск по ФИО", "Поиск по полу", "Поиск по возрасту", "Поиск по коду должности", "Поиск по окладу"};
                      comboBox1.Items.AddRange(searchRab);
                      comboBox1.SelectedIndex = 0;
                      break;
                  case 3:
                      comboBox1.Items.Clear();
                     // comboBox1.SelectedIndex = 0;
                      break;
                  case 4:
                      comboBox1.Items.Clear();
                      //comboBox1.SelectedIndex = 0;
                      break;
                  case 5:
                      comboBox1.Items.Clear();
                     // comboBox1.SelectedIndex = 0;
                      break;
                  case 6:
                      comboBox1.Items.Clear();
                      //comboBox1.SelectedIndex = 0;
                      break;
              } 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            object[] searchFuel = { "Поиск по коду топлива", "Поиск по названию топлива", "Поиск по запасам топлива", "Поиск по коду поставки" };
            comboBox1.Items.AddRange(searchFuel);
            comboBox1.SelectedIndex = 0;
            dataGridView2.DataSource = GetFuel();
            dataGridView1.DataSource = GetClient();
            dataGridView3.DataSource = GetDol();
            dataGridView4.DataSource = GetRab();
            dataGridView5.DataSource = GetSale();
            dataGridView6.DataSource = GetPostavshiki();
            dataGridView7.DataSource = GetPostavka();
        }

        public void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateFuel();
        }

        private void dataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateDol();
        }

        private void dataGridView4_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateRab();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateClient();
        }

        private void dataGridView5_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateSale();
        }

        private void dataGridView6_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdatePostavshiki();
        }

        private void dataGridView7_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdatePostavka();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            form2.Show();            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {       
             switch (tabControl1.SelectedIndex)
            {
                case 0:
                    {
                       try {   
                           if (comboBox1.SelectedIndex == 0){                           
                                string sql = "Код_топлива = " + textBox1.Text + "";
                                DataRowCollection allRows = ((DataTable)dataGridView2.DataSource).Rows;
                                DataRow[] searchRow = ((DataTable)dataGridView2.DataSource).Select(sql);
                                int rowIndex = allRows.IndexOf(searchRow[0]);
                                dataGridView2.CurrentCell = dataGridView2[0,rowIndex];
                                textBox1.Text = "";
                              }
                            if (comboBox1.SelectedIndex == 1){                           
                                string sql = "Вид_топлива LIKE '%" + textBox1.Text + "%'";
                                DataRowCollection allRows = ((DataTable)dataGridView2.DataSource).Rows;
                                DataRow[] searchRow = ((DataTable)dataGridView2.DataSource).Select(sql);
                                int rowIndex = allRows.IndexOf(searchRow[0]);
                                dataGridView2.CurrentCell = dataGridView2[0,rowIndex];
                                textBox1.Text = "";
                                }
                            if (comboBox1.SelectedIndex == 2){
                                if (radioButton1.Checked){
                                    string sql = "Запасы_топлива >" + textBox1.Text + "";
                                    DataRowCollection allRows = ((DataTable)dataGridView2.DataSource).Rows;
                                    DataRow[] searchRow = ((DataTable)dataGridView2.DataSource).Select(sql);
                                    int rowIndex = allRows.IndexOf(searchRow[0]);
                                    dataGridView2.CurrentCell = dataGridView2[0, rowIndex];
                                    textBox1.Text = "";
                                }
                                if (radioButton2.Checked){
                                    string sql = "Запасы_топлива =" + textBox1.Text + "";
                                    DataRowCollection allRows = ((DataTable)dataGridView2.DataSource).Rows;
                                    DataRow[] searchRow = ((DataTable)dataGridView2.DataSource).Select(sql);
                                    int rowIndex = allRows.IndexOf(searchRow[0]);
                                    dataGridView2.CurrentCell = dataGridView2[0, rowIndex];
                                    textBox1.Text = "";
                                }
                                if (radioButton3.Checked){
                                    string sql = "Запасы_топлива <" + textBox1.Text + "";
                                    DataRowCollection allRows = ((DataTable)dataGridView2.DataSource).Rows;
                                    DataRow[] searchRow = ((DataTable)dataGridView2.DataSource).Select(sql);
                                    int rowIndex = allRows.IndexOf(searchRow[0]);
                                    dataGridView2.CurrentCell = dataGridView2[0, rowIndex];
                                    textBox1.Text = "";
                                }
                                }
                            if (comboBox1.SelectedIndex == 3)
                            {
                                string sql = "Код_поставки ='" + textBox1.Text + "'";
                                DataRowCollection allRows = ((DataTable)dataGridView2.DataSource).Rows;
                                DataRow[] searchRow = ((DataTable)dataGridView2.DataSource).Select(sql);
                                int rowIndex = allRows.IndexOf(searchRow[0]);
                                dataGridView2.CurrentCell = dataGridView2[0, rowIndex];
                                textBox1.Text = "";
                            }
                           
                           }
                       catch (Exception ex){
                            MessageBox.Show(ex.Message);
                           }
                            break;                        
                    }
                case 1:
                    {
                        try
                        {
                            if (comboBox1.SelectedIndex == 0){
                                string sql = "Код_должности =" + textBox1.Text + "";
                                DataRowCollection allRows = ((DataTable)dataGridView3.DataSource).Rows;
                                DataRow[] searchRow = ((DataTable)dataGridView3.DataSource).Select(sql);
                                int rowIndex = allRows.IndexOf(searchRow[0]);
                                dataGridView3.CurrentCell = dataGridView3[0, rowIndex];
                                textBox1.Text = "";
                            }
                            if (comboBox1.SelectedIndex == 1)
                            {
                                string sql = "Должность LIKE '%" + textBox1.Text + "%'";
                                DataRowCollection allRows = ((DataTable)dataGridView3.DataSource).Rows;
                                DataRow[] searchRow = ((DataTable)dataGridView3.DataSource).Select(sql);
                                int rowIndex = allRows.IndexOf(searchRow[0]);
                                dataGridView3.CurrentCell = dataGridView3[0, rowIndex];
                                textBox1.Text = "";
                            }
                        }
                        catch (Exception ex){
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    }
                      case 2:
                    {
                        try
                        {
                            if (comboBox1.SelectedIndex == 0)
                            {
                                string sql = "Код_рабочего =" + textBox1.Text + "";
                                DataRowCollection allRows = ((DataTable)dataGridView4.DataSource).Rows;
                                DataRow[] searchRow = ((DataTable)dataGridView4.DataSource).Select(sql);
                                int rowIndex = allRows.IndexOf(searchRow[0]);
                                dataGridView4.CurrentCell = dataGridView4[0, rowIndex];
                                textBox1.Text = ""; 
                            }
                            if (comboBox1.SelectedIndex == 1)
                            {
                                //string sql = "Фамилия AND Имя AND Отчество LIKE '%" + textBox1.Text + "%'";
                                //DataRowCollection allRows = ((DataTable)dataGridView4.DataSource).Rows;
                                //DataRow[] searchRow = ((DataTable)dataGridView4.DataSource).Select(sql);
                                //int rowIndex = allRows.IndexOf(searchRow[0]);
                                //dataGridView4.CurrentCell = dataGridView4[0, rowIndex];
                                //textBox1.Text = "";
                            }
                            if (comboBox1.SelectedIndex == 2)
                            {

                            }
                            if (comboBox1.SelectedIndex == 3)
                            {

                            }
                            if (comboBox1.SelectedIndex == 4)
                            {

                            }
                            if (comboBox1.SelectedIndex == 5)
                            {

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    {
                        if (comboBox1.SelectedIndex == 2)
                        {
                            radioButton1.Visible = true;
                            radioButton2.Visible = true;
                            radioButton3.Visible = true;
                        }
                        if (comboBox1.SelectedIndex != 2)
                        {
                            radioButton1.Visible = false;
                            radioButton2.Visible = false;
                            radioButton3.Visible = false;
                        }
                        break;

                    }
            }
        }

      

    }
}
