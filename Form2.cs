using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arm_zapravka
{
    public partial class Form2 : Form
    {
        public static string ComboSelect;
        string query;
        DataGridView datagrid;
        int grid;
        public int index;



        public Form2(int grid, DataGridView datagrid)
        {
            InitializeComponent();
            this.grid = grid;
            this.datagrid = datagrid;
        }

        public void Form2_Load(object sender, EventArgs e)
        {
            switch (ComboSelect)
            {
                case "Наименование_организации":
                    query = @"SELECT Наименование_организации
                                  FROM Поставщики";
                    break;
                case "Наименование_организации++":
                    query = @"SELECT Наименование_организации
                                  FROM Поставщики";
                    break;
                case "Должность":
                    query = @"SELECT Должность
                                  FROM Должности";
                    break;
                case "Топливо":
                    query = @"SELECT Вид_топлива
                                  FROM Виды_топлива";
                    break;
                case "Топливо++":
                    query = @"SELECT Вид_топлива
                                  FROM Виды_топлива
                                  WHERE Виды_топлива.Код_поставщика = "+datagrid.CurrentRow.Cells[1].Value+";";
                    break;
                case "Фамилия_рабочего":
                    query = @"SELECT Фамилия_рабочего
                                  FROM Рабочие
                                  WHERE Код_должности = 1";
                    break;
                case "Клиент":
                    query = @"SELECT Фамилия_клиента
                                  FROM Клиенты";
                    break;
                default:
                    break;
            }

            using (var connection = new MySqlConnection(Form1.CONNECTION))
            {
                try
                {
                    var command = new MySqlCommand(query, connection);
                    connection.Open();
                    using (MySqlDataReader dataReader = command.ExecuteReader())
                    {
                        int i = 0;
                        while (dataReader.Read())
                        {
                            if (dataReader.HasRows)
                            {
                                comboBox1.Items.Add(dataReader.GetValue(i));
                            }

                        }
                    }
                    comboBox1.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                connection.Close();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Выберите значение");
            }
            else
            {
                index = comboBox1.SelectedIndex;
                switch (ComboSelect)
                {
                    case "Наименование_организации":
                        datagrid.CurrentRow.Cells[4].Value = index + 1;
                        break;
                    case "Наименование_организации++":
                        datagrid.CurrentRow.Cells[1].Value = index + 1;
                        break;
                    case "Должность":
                        datagrid.CurrentRow.Cells[6].Value = index + 1;
                        break;
                    case "Топливо":
                        datagrid.CurrentRow.Cells[1].Value = index + 1;
                        break;
                    case "Топливо++":
                        datagrid.CurrentRow.Cells[3].Value = index + 1;
                        break;
                    case "Клиент":
                        datagrid.CurrentRow.Cells[0].Value = index + 1;
                        break;
                    case "Фамилия_рабочего":
                        if (comboBox1.SelectedIndex == 0)
                            datagrid.CurrentRow.Cells[2].Value = 2;
                        if (comboBox1.SelectedIndex == 1)
                            datagrid.CurrentRow.Cells[2].Value = 7;
                        break;
                    default:
                        break;
                }
            }
            Hide();
        }


    }
}
