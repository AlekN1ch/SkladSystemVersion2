using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkladSystemVersion2
{
    public partial class Form2 : Form
    {
        public static string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=sklad.accdb";
        public OleDbConnection myConnection;
        public Label[] labels;
        public static bool b = true;
        public static int a = 0;
        public static bool now = false;
        public Form2()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connection);
            myConnection.Open();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                Sklad sklad = new Sklad();
                sklad.ShowDialog(); 
              
            }
            if (comboBox1.SelectedIndex == 1)
            {
                Zayavki zayavka = new Zayavki();
                zayavka.ShowDialog();
                
            }
            if (comboBox1.SelectedIndex == 2)
            {
                WorkerApp workerApp = new WorkerApp(); 
                workerApp.ShowDialog();
                this.Enabled = true;
            }
            
        }
   


        public void StadyCheck(int stady)
        {

            labels[a].BackColor = SystemColors.Info;
            foreach (Label label in labels)
            {
                if (label == labels[a]) break;
                else label.BackColor = DefaultBackColor;
            }

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "skladDataSet.skladTable". При необходимости она может быть перемещена или удалена.
            this.skladTableTableAdapter.Fill(this.skladDataSet.skladTable);
            FillListBoxes();
            Label[] labels1 = { label7, label8, label9, label10, label11, label12, label13 };
            labels = labels1;
            StadyCheck(a);

            NextStep();
            timer1.Start();

        }
        public void FillListBoxes()
        {
            string query = "SELECT Tname FROM skladTable ORDER BY Код";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            listBox1.Items.Clear();
            while (reader.Read())
            {
                listBox1.Items.Add(reader[0].ToString());
            }
            reader.Close();
            string query2 = "SELECT ID,number FROM skladTable ORDER BY Код";
            OleDbCommand command2 = new OleDbCommand(query2, myConnection);
            OleDbDataReader reader2 = command2.ExecuteReader();
            listBox2.Items.Clear();
            while (reader2.Read())
            {
                listBox2.Items.Add(reader2[0].ToString() + " #" + reader2[1].ToString());
            }
            reader2.Close();
            string query3 = "SELECT category FROM skladTable ORDER BY Код";
            OleDbCommand command3 = new OleDbCommand(query3, myConnection);
            OleDbDataReader reader3 = command3.ExecuteReader();
            listBox3.Items.Clear();
            while (reader3.Read())
            {
                listBox3.Items.Add(reader3[0].ToString());
            }
            reader3.Close();
            string query4 = "SELECT place FROM skladTable ORDER BY Код";
            OleDbCommand command4 = new OleDbCommand(query4, myConnection);
            OleDbDataReader reader4 = command4.ExecuteReader();
            listBox4.Items.Clear();
            while (reader4.Read())
            {
                listBox4.Items.Add(reader4[0].ToString());
            }
            reader4.Close();


        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            b = WorkerApp.acces;
            NextStep();
            WorkerApp.answer = true;
            WorkerApp.acces = true;
            button1.Enabled = false;
            button2.Enabled = false;
            WorkerApp workerApp = new WorkerApp();
            workerApp.Show();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (now)
            {
                NextStep();
                now = false;
            }
            
        }
        public static void MessageOfMoreTime()
        { MessageBox.Show("Процесс ещё в процессе выполнения"); }
        private void button3_Click(object sender, EventArgs e)
        {
            
        }
        public void NextStep()
        {
            switch (a)
            {
                case 0:
                case 2:
                case 4:
                    button1.Enabled = true;
                    button2.Enabled = false;
                    break;
                case 1:
                case 3:
                case 5:
                    if (b)
                    {
                        button1.Enabled = false;
                        button2.Enabled = true;
                    }
                    else
                    {
                        button2.Enabled = false;
                        button1.Enabled = true;
                    }
                    break;
                case 6:
                    button1.Enabled = false;
                    button2.Enabled = false;
                    MessageBox.Show("Все этапы работы завершены");
                    break;

            }
            switch (a)
            { 
                case 0:
                    string query = "UPDATE skladTable SET [place] ="+"' Зона предварительного хранения'"+" WHERE [Код] >"+" -1";
                    OleDbCommand command = new OleDbCommand(query, myConnection);
                    command.ExecuteNonQuery();
                    break;
                case 1:
                    string query1 = "UPDATE skladTable SET place = " + "' Зона контроля качества'" + " WHERE [Код] >" + " -1";
                    OleDbCommand command1 = new OleDbCommand(query1, myConnection);
                    command1.ExecuteNonQuery();
                    break;
                case 2:
                    string query2 = "UPDATE skladTable SET place =" + "' Зона сортировки'" + " WHERE [Код] >" + " -1";
                    OleDbCommand command2 = new OleDbCommand(query2, myConnection);
                    command2.ExecuteNonQuery();
                    break;
                case 3:
                    string query3 = "UPDATE skladTable SET place = " + "' Зона сборки заказа'" + " WHERE [Код] >" + " -1";
                    OleDbCommand command3 = new OleDbCommand(query3, myConnection);
                    command3.ExecuteNonQuery();
                    break;
                case 4:
                    string query4 = "UPDATE skladTable SET place =" + "' Зона консолидации'" + " WHERE [Код] >" + " -1";
                    OleDbCommand command4 = new OleDbCommand(query4, myConnection);
                    command4.ExecuteNonQuery();
                    break;
                case 5:
                    string query5 = "UPDATE skladTable SET place =" + "' Зона упаковки'" + " WHERE [Код] >" + " -1";
                    OleDbCommand command5 = new OleDbCommand(query5, myConnection);
                    command5.ExecuteNonQuery();
                    break;
                case 6:
                    string query6 = "UPDATE skladTable SET place = " + "' Зона передачи в доставку'" + " WHERE [Код] >" + " -1";
                    OleDbCommand command6 = new OleDbCommand(query6, myConnection);
                    command6.ExecuteNonQuery();
                    break;
            }
            FillListBoxes();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (a < 6)
            {
                a++;
                StadyCheck(a);
                NextStep();
            }
            else a = a;
            b = true;
        }
    }
}
