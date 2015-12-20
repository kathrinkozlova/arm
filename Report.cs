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
using Excel = Microsoft.Office.Interop.Excel;

namespace Arm_zapravka
{
    public partial class Report : Form
    {
        bool sumReport;
        public DataTable dt;

        public Report()
        {
            InitializeComponent();
        }


        

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null)
                MessageBox.Show("Введите запрос", "Ошибка");
            sumReport = false;
            Print();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sumReport = true;
            Print();
        }

        private void Print()
        {
            

            Excel.Application xlApp;
            Excel.Worksheet xlSheet;
            Excel.Range xlSheetRange;

            xlApp = new Excel.Application();
            try
            {
                //добавляем книгу
                xlApp.Workbooks.Add(Type.Missing);

                //делаем временно неактивным документ
                xlApp.Interactive = false;
                xlApp.EnableEvents = false;

                //выбираем лист на котором будем работать (Лист 1)
                xlSheet = (Excel.Worksheet)xlApp.Sheets[1];
                //Название листа
                xlSheet.Name = "Данные";
                int collInd = 0;
                int rowInd = 0;
                string data = "";
                //Выгрузка данных
               // DataTable dt = Get("SELECT * FROM " + comboBox1.SelectedItem + " WHERE " + comboBox2.SelectedItem + " = " + "'" + textBox1.Text + "'");
                if (sumReport)
                {
                    dt = Get(@"SELECT SUM(Виды_топлива.Цена*Продажа.Количество_топлива) AS Заработок_за_день
                                        FROM  Виды_топлива, Продажа
                                        WHERE Виды_топлива.Код_топлива = Продажа.Код_топлива AND Продажа.Дата = CURDATE();");
                }
                else 
                {
                    dt = Get(textBox1.Text);
                }

                

                //называем колонки
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    data = dt.Columns[i].ColumnName;
                    xlSheet.Cells[1, i + 1] = data;

                    //выделяем первую строку
                    xlSheetRange = xlSheet.get_Range("A1:Z1", Type.Missing);

                    //делаем полужирный текст и перенос слов
                    xlSheetRange.WrapText = true;
                    xlSheetRange.Font.Bold = true;
                }

                //заполняем строки
                for (rowInd = 0; rowInd < dt.Rows.Count; rowInd++)
                {
                    for (collInd = 0; collInd < dt.Columns.Count; collInd++)
                    {
                        data = dt.Rows[rowInd].ItemArray[collInd].ToString();
                        xlSheet.Cells[rowInd + 2, collInd + 1] = data;
                    }
                }

                //выбираем всю область данных
                xlSheetRange = xlSheet.UsedRange;

                //выравниваем строки и колонки по их содержимому
                xlSheetRange.Columns.AutoFit();
                xlSheetRange.Rows.AutoFit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                //Показываем ексель
                xlApp.Visible = true;
                xlApp.Interactive = true;
                xlApp.ScreenUpdating = true;
                xlApp.UserControl = true;

                //
            }
        }


        private DataTable Get(string query)
        {
            DataTable dt = new DataTable();
            MySqlConnection con = new MySqlConnection(Form1.CONNECTION);
            try
            {
                MySqlCommand comm = new MySqlCommand(query, con);
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(comm);
                DataSet ds = new DataSet();
                da.Fill(ds);
                comm.ExecuteNonQuery();
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return dt;
        }
    }
}
