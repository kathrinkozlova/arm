using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Drawing;


namespace Arm_zapravka
{
    public partial class Form1 : Form
    {
        static readonly string CONNECTION = "Server = 127.0.0.1; User = root;" + "password = 123; Database = fuel;";

        public Form1()
        {
            InitializeComponent();
        }

       
        private void InsertDataFuel()
        {
            using (MySqlConnection con = new MySqlConnection(CONNECTION))
            {
                try
                {
                    string sql = @"SET FOREIGN_KEY_CHECKS=0; INSERT INTO Виды_топлива (Вид_топлива, Цена, Запасы_топлива, Код_поставщика) 
                    VALUES (@Вид_топлива, @Цена, @Запасы_топлива, @Код_поставщика);";

                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    if (dataGridView2.CurrentRow != null)
                    {
                        cmd.Parameters.AddWithValue("@Вид_топлива", dataGridView2.CurrentRow.Cells[1].Value);
                        cmd.Parameters.AddWithValue("@Цена", dataGridView2.CurrentRow.Cells[2].Value);
                        cmd.Parameters.AddWithValue("@Запасы_топлива", dataGridView2.CurrentRow.Cells[3].Value);
                        cmd.Parameters.AddWithValue("@Код_поставщика", dataGridView2.CurrentRow.Cells[4].Value);
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
            using (MySqlConnection con = new MySqlConnection(CONNECTION))
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
            using (MySqlConnection con = new MySqlConnection(CONNECTION))
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
            using (MySqlConnection con = new MySqlConnection(CONNECTION))
            {
                try
                {
                    string sql = @"SET FOREIGN_KEY_CHECKS=0; INSERT INTO Должности (Должность) 
                    VALUES (@Должность);";

                    con.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    if (dataGridView3.CurrentRow != null)
                        cmd.Parameters.AddWithValue("@Должность", dataGridView3.CurrentRow.Cells[1].Value);
                        cmd.Parameters.AddWithValue("@Оклад", dataGridView3.CurrentRow.Cells[1].Value);
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
            using (MySqlConnection con = new MySqlConnection(CONNECTION))
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
            using (MySqlConnection con = new MySqlConnection(CONNECTION))
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
                        cmd.Parameters.AddWithValue("@Оклад", dataGridView3.CurrentRow.Cells[2].Value);
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
            using (MySqlConnection con = new MySqlConnection(CONNECTION))
            {
                try
                {
                    string sql = @"SET FOREIGN_KEY_CHECKS=0; INSERT INTO Рабочие (Фамилия, Имя, Отчество, Пол, Возраст, Код_должности, Телефон, Оклад) 
                    VALUES (@Фамилия,@Имя, @Отчество,@Пол, @Возраст, @Код_должности, @Телефон);";

                    con.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    if (dataGridView4.CurrentRow != null)
                    {
                        cmd.Parameters.AddWithValue("@Фамилия", dataGridView4.CurrentRow.Cells[1].Value);
                        cmd.Parameters.AddWithValue("@Имя", dataGridView4.CurrentRow.Cells[2].Value);
                        cmd.Parameters.AddWithValue("@Отчество", dataGridView4.CurrentRow.Cells[3].Value);
                        cmd.Parameters.AddWithValue("@Пол", dataGridView4.CurrentRow.Cells[4].Value);
                        cmd.Parameters.AddWithValue("@Возраст", dataGridView4.CurrentRow.Cells[5].Value);
                        cmd.Parameters.AddWithValue("@Код_должности", dataGridView4.CurrentRow.Cells[6].Value);
                        cmd.Parameters.AddWithValue("@Телефон", dataGridView4.CurrentRow.Cells[7].Value);
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
            using (MySqlConnection con = new MySqlConnection(CONNECTION))
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
            using (MySqlConnection con = new MySqlConnection(CONNECTION))
            {
                try
                {
                    string sql = @"UPDATE Рабочие
                                   SET Фамилия = @Фамилия, Имя = @Имя, Отчество = @Отчество, Пол = @Пол, Возраст = @Возраст, Код_должности = @Код_должности, Телефон = @Телефон
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
            using (MySqlConnection con = new MySqlConnection(CONNECTION))
            {
                try
                {
                    string sql = @"SET FOREIGN_KEY_CHECKS=0; INSERT INTO Клиенты (Фамилия, Имя, Отчество) 
                    VALUES (@Фамилия,@Имя, @Отчество);";

                    con.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    if (dataGridView1.CurrentRow != null)
                    {
                        cmd.Parameters.AddWithValue("@Фамилия", dataGridView1.CurrentRow.Cells[1].Value);
                        cmd.Parameters.AddWithValue("@Имя", dataGridView1.CurrentRow.Cells[2].Value);
                        cmd.Parameters.AddWithValue("@Отчество", dataGridView1.CurrentRow.Cells[3].Value);
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
            using (MySqlConnection con = new MySqlConnection(CONNECTION))
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
            using (MySqlConnection con = new MySqlConnection(CONNECTION))
            {
                try
                {
                    string sql = @"UPDATE Клиенты
                                   SET Фамилия = @Фамилия, Имя = @Имя, Отчество = @Отчество
                                   WHERE Код_клиента = @Код_клиента";
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    if (dataGridView1.CurrentRow != null)
                    {
                        cmd.Parameters.AddWithValue("@Код_клиента", dataGridView1.CurrentRow.Cells[0].Value);
                        cmd.Parameters.AddWithValue("@Фамилия", dataGridView1.CurrentRow.Cells[1].Value);
                        cmd.Parameters.AddWithValue("@Имя", dataGridView1.CurrentRow.Cells[2].Value);
                        cmd.Parameters.AddWithValue("@Отчество", dataGridView1.CurrentRow.Cells[3].Value);                       
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
            using (MySqlConnection con = new MySqlConnection(CONNECTION))
            {
                try
                {
                    string sql = @"SET FOREIGN_KEY_CHECKS=0; INSERT INTO Продажа (Код_топлива, Код_рабочего, Количество_топлива, Дата) 
                    VALUES (@Код_топлива, @Код_рабочего, @Количество_топлива, @Дата);";

                    con.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    //создаем параметры и добавляем их в коллекцию
                    if (dataGridView5.CurrentRow != null)
                    {
                        
                        cmd.Parameters.AddWithValue("@Код_топлива", dataGridView5.CurrentRow.Cells[1].Value);
                        cmd.Parameters.AddWithValue("@Код_рабочего", dataGridView5.CurrentRow.Cells[2].Value);
                        cmd.Parameters.AddWithValue("@Количество_топлива", dataGridView5.CurrentRow.Cells[3].Value);
                        cmd.Parameters.AddWithValue("@Дата", dataGridView5.CurrentRow.Cells[4].Value);
                        
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
            using (MySqlConnection con = new MySqlConnection(CONNECTION))
            {
                try
                {
                    string sql = @"SET FOREIGN_KEY_CHECKS=0;
                                  DELETE FROM Продажа " +
                                  "WHERE Код_клиента = @Код_клиента";

                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Код_клиента", dataGridView5.CurrentRow.Cells[0].Value);
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
            using (MySqlConnection con = new MySqlConnection(CONNECTION))
            {
                try
                {
                    string sql = @"SET FOREIGN_KEY_CHECKS=0; 
                                   UPDATE Продажа 
                                   SET  Код_топлива = @Код_топлива, Код_рабочего = @Код_рабочего, Количество_топлива = @Количество_топлива, Дата = @Дата
                                   WHERE Код_клиента = @Код_клиента
                                  ";
                    con.Open();
                    
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    if (dataGridView5.CurrentRow != null)
                    {
                        cmd.Parameters.AddWithValue("@Код_клиента", dataGridView5.CurrentRow.Cells[0].Value);
                        cmd.Parameters.AddWithValue("@Код_рабочего", dataGridView5.CurrentRow.Cells[1].Value);
                        cmd.Parameters.AddWithValue("@Код_топлива", dataGridView5.CurrentRow.Cells[2].Value);
                        cmd.Parameters.AddWithValue("@Количество_топлива", dataGridView5.CurrentRow.Cells[3].Value);
                        cmd.Parameters.AddWithValue("@Дата", dataGridView5.CurrentRow.Cells[4].Value);
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
            using (MySqlConnection con = new MySqlConnection(CONNECTION))
            {
                try
                {
                    string sql = @"SET FOREIGN_KEY_CHECKS=0; INSERT INTO Поставщики (Наименование_организации, Телефон_организации) 
                    VALUES (@Наименование_организации, @Телефон_организации);";

                    con.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, con);

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
            using (MySqlConnection con = new MySqlConnection(CONNECTION))
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
            using (MySqlConnection con = new MySqlConnection(CONNECTION))
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
            using (MySqlConnection con = new MySqlConnection(CONNECTION))
            {
                try
                {
                    string sql = @"SET FOREIGN_KEY_CHECKS=0; INSERT INTO Поставка_топлива (Код_поставщика, Количество_поставки, Код_топлива) 
                    VALUES (@Код_поставщика, @Количество_поставки, @Код_топлива);";

                    con.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, con);

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
            using (MySqlConnection con = new MySqlConnection(CONNECTION))
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
            using (MySqlConnection con = new MySqlConnection(CONNECTION))
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
                        dataGridView2.DataSource = BD.GetFuel();
                        break;
                    }
                case 1:
                    {
                        InsertDataDol();
                        dataGridView3.DataSource = BD.GetDol();
                        break;
                    }
                case 2:
                    {
                        InsertDataRab();
                        dataGridView4.DataSource = BD.GetRab();
                        break;
                    }
                case 3:
                    {
                        InsertDataClient();
                        dataGridView1.DataSource = BD.GetClient();
                        break;
                    }
                case 4:
                    {
                        InsertDataSale();
                        dataGridView5.DataSource = BD.GetSale();
                        break;
                    }
                case 5:
                    {
                        InsertDataPostavshiki();
                        dataGridView6.DataSource = BD.GetPostavshiki();
                        break;
                    }
                case 6:
                    {
                        InsertDataPostavka();
                        dataGridView7.DataSource = BD.GetPostavka();
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
                        dataGridView2.DataSource = BD.GetFuel();
                        break;
                    }
                case 1:
                    {
                        DeleteDol();
                        dataGridView3.DataSource = BD.GetDol();
                        break;
                    }
                case 2:
                    {
                        DeleteRab();
                        dataGridView4.DataSource = BD.GetRab();
                        break;
                    }
                case 3:
                    {
                        DeleteClient();
                        dataGridView1.DataSource = BD.GetClient();
                        break;
                    }
                case 4:
                    {
                        DeleteSale();
                        dataGridView5.DataSource = BD.GetSale();
                        break;
                    }
                case 5:
                    {
                        DeletePostavshiki();
                        dataGridView6.DataSource = BD.GetPostavshiki();
                        break;
                    }
                case 6:
                    {
                        DeletePostavka();
                        dataGridView7.DataSource = BD.GetPostavka();
                        break;
                    }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView2.DataSource = BD.GetFuel();
            dataGridView1.DataSource = BD.GetClient();
            dataGridView3.DataSource = BD.GetDol();
            dataGridView4.DataSource = BD.GetRab();
            dataGridView5.DataSource = BD.GetSale();
            dataGridView6.DataSource = BD.GetPostavshiki();
            dataGridView7.DataSource = BD.GetPostavka();
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
            //var form2 = new Form2();
            //form2.Show();            
        }

        private void Search(DataGridView grid)
        {
            int lastFindRow = 0;
            int lastFindCell = 0;
            bool newFind = false;

            try
            {
                if (!newFind)
                    grid.Rows[lastFindRow].Cells[lastFindCell].Style.BackColor = Color.White;

                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    bool finded = false;
                    int n = lastFindRow;
                    lastFindCell++;
                    for (int i = lastFindRow; i < grid.RowCount; i++)
                    {
                        if (grid.Rows[i].Visible)
                        {
                            if (i != lastFindRow)
                                lastFindCell = 0;
                            finded = false;
                            for (int k = lastFindCell; k < grid.Rows[i].Cells.Count; k++)
                            {
                                if (grid.Rows[i].Cells[k].Value != null && grid.Rows[i].Cells[k].Visible)
                                {
                                    if (grid.Rows[i].Cells[k].Value.ToString().IndexOf(textBox1.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                                    {
                                        lastFindCell = k;
                                        finded = true;
                                        break;
                                    }
                                }
                            }
                            if (finded)
                            {
                                grid.Rows[i].Cells[lastFindCell].Style.SelectionBackColor = Color.FromArgb(53, 153, 255);
                                grid.Rows[i].Cells[lastFindCell].Style.SelectionForeColor = Color.Black;

                                grid.CurrentCell = grid.Rows[i].Cells[lastFindCell];
                                newFind = false;
                                lastFindRow = i;
                                break;
                            }
                            n = i;
                        }
                    }
                    if (!finded)
                    {
                        newFind = true;
                        lastFindRow = 0;
                        lastFindCell = 0;
                        if (n + 1 >= dataGridView2.RowCount)
                        {
                            if (MessageBox.Show("Поиск достиг конца таблицы. Начать поиск заново?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                button1.PerformClick();
                        }
                        else
                            MessageBox.Show("Искомый текст не найден. ", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {       
             switch (tabControl1.SelectedIndex)
            {
                case 0:
                    {
                       try { 
                           Search(dataGridView2);
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
                            Search(dataGridView3);
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
                            Search(dataGridView4);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    }
                      case 3:
                    {
                        try
                        {
                            Search(dataGridView1);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    }
                      case 4:
                    {
                        try
                        {
                            Search(dataGridView5);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    }
                      case 5:
                    {
                        try
                        {
                            Search(dataGridView6);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    }
                      case 6:
                    {
                        try
                        {
                            Search(dataGridView7);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
        }

        public static void CheckDigit(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        public static void CheckLetter(KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void dataGridView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            var row = dataGridView2.CurrentRow.Cells;

            if (dataGridView2.CurrentRow != null && (row[2].IsInEditMode || row[3].IsInEditMode || row[4].IsInEditMode))
               CheckDigit(e);
        }

        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView2.CurrentRow != null) dataGridView2.CurrentRow.Cells[0].ReadOnly = true;
            var value = ((DataGridView)sender).CurrentCell.OwningColumn.Name;
            switch (value)
            {
                case "Вид_топлива":
                case "Цена":
                case "Запасы_топлива":
                case "Код_поставщика":
                    e.Control.KeyPress -= dataGridView2_KeyPress;
                    e.Control.KeyPress += dataGridView2_KeyPress;
                    break;
            }
        }

        private void dataGridView3_KeyPress(object sender, KeyPressEventArgs e)
        {
            var row = dataGridView3.CurrentRow.Cells;

            if (dataGridView3.CurrentRow != null && row[2].IsInEditMode)
                CheckDigit(e);
            if (dataGridView3.CurrentRow != null && row[1].IsInEditMode)
                CheckLetter(e);
        }

        private void dataGridView3_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView3.CurrentRow != null) dataGridView3.CurrentRow.Cells[0].ReadOnly = true;
            var value = ((DataGridView)sender).CurrentCell.OwningColumn.Name;
            switch (value)
            {
                case "Должность":
                case "Оклад":
                    e.Control.KeyPress -= dataGridView3_KeyPress;
                    e.Control.KeyPress += dataGridView3_KeyPress;
                    break;
            }
        }

        public static void CheckGender(KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && e.KeyChar != 'М' && e.KeyChar != 'Ж')
                e.Handled = true;
        }

        private void dataGridView4_KeyPress(object sender, KeyPressEventArgs e)
        {
            var row = dataGridView4.CurrentRow.Cells;

            if (dataGridView4.CurrentRow != null && (row[5].IsInEditMode || row[6].IsInEditMode || row[7].IsInEditMode))
                CheckDigit(e);
            if (dataGridView4.CurrentRow != null && (row[1].IsInEditMode || row[2].IsInEditMode || row[3].IsInEditMode))
                CheckLetter(e);
            if (dataGridView4.CurrentRow != null && row[4].IsInEditMode)
                CheckGender(e);

        }

        private void dataGridView4_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView4.CurrentRow != null) dataGridView4.CurrentRow.Cells[0].ReadOnly = true;
            var value = ((DataGridView)sender).CurrentCell.OwningColumn.Name;
            switch (value)
            {
                case "Фамилия":
                case "Имя":
                case "Отчество":
                case "Пол":
                case "Возраст":
                case "Код_должности":
                case "Телефон":
                    e.Control.KeyPress -= dataGridView4_KeyPress;
                    e.Control.KeyPress += dataGridView4_KeyPress;
                    break;
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentRow != null) dataGridView1.CurrentRow.Cells[0].ReadOnly = true;
            var value = ((DataGridView)sender).CurrentCell.OwningColumn.Name;
            switch (value)
            {
                case "Фамилия":
                case "Имя":
                case "Отчество":
                    e.Control.KeyPress -= dataGridView1_KeyPress;
                    e.Control.KeyPress += dataGridView1_KeyPress;
                    break;
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            var row = dataGridView1.CurrentRow.Cells;

            if (dataGridView1.CurrentRow != null && (row[1].IsInEditMode || row[2].IsInEditMode || row[3].IsInEditMode))
                CheckLetter(e);
        }

        private void dataGridView5_KeyPress(object sender, KeyPressEventArgs e)
        {
            var row = dataGridView5.CurrentRow.Cells;

            if (dataGridView5.CurrentRow != null && (row[0].IsInEditMode || row[1].IsInEditMode || row[2].IsInEditMode || row[3].IsInEditMode))
                CheckDigit(e);
        }

        private void dataGridView5_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var value = ((DataGridView)sender).CurrentCell.OwningColumn.Name;
            switch (value)
            {
                case "Код_клиента":
                case "Код_топлива":
                case "Код_рабочего":
                case "Количество_топлива":
                    e.Control.KeyPress -= dataGridView5_KeyPress;
                    e.Control.KeyPress += dataGridView5_KeyPress;
                    break;
            }
        }

        private void dataGridView6_KeyPress(object sender, KeyPressEventArgs e)
        {
            var row = dataGridView6.CurrentRow.Cells;

            if (dataGridView6.CurrentRow != null && row[2].IsInEditMode)
                CheckDigit(e);
            if (dataGridView6.CurrentRow != null && row[1].IsInEditMode)
                CheckLetter(e);
        }

        private void dataGridView6_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView6.CurrentRow != null) dataGridView6.CurrentRow.Cells[0].ReadOnly = true;
            var value = ((DataGridView)sender).CurrentCell.OwningColumn.Name;
            switch (value)
            {
                case "Наименование_организации":
                case "Телефон_организации":
                    e.Control.KeyPress -= dataGridView6_KeyPress;
                    e.Control.KeyPress += dataGridView6_KeyPress;
                    break;
            }
        }

        private void dataGridView7_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView7.CurrentRow != null) dataGridView7.CurrentRow.Cells[0].ReadOnly = true;
            var value = ((DataGridView)sender).CurrentCell.OwningColumn.Name;
            switch (value)
            {
                case "Код_поставщика":
                case "Количество_поставки":
                case "Код_топлива":
                    e.Control.KeyPress -= dataGridView7_KeyPress;
                    e.Control.KeyPress += dataGridView7_KeyPress;
                    break;
            }
        }

        private void dataGridView7_KeyPress(object sender, KeyPressEventArgs e)
        {
            var row = dataGridView7.CurrentRow.Cells;

            if (dataGridView7.CurrentRow != null && (row[1].IsInEditMode || row[2].IsInEditMode || row[3].IsInEditMode))
                CheckDigit(e);
        }
    }
}
