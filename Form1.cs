using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkladSystemVersion2
{
    public partial class Form1 : Form
    {
        public static string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Autorization.accdb";
        public OleDbConnection myConnection;
        public static string connection1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AdminAutorization.accdb";
        public OleDbConnection myConnection1;
        public Form1()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connection);
            myConnection.Open();
            myConnection1 = new OleDbConnection(connection1);
            myConnection1.Open();
            ListBoxUserFiller();
            ListBoxAdminFiller();
        }
        public void ListBoxUserFiller()
        {
            string query = "SELECT login FROM autorizationTable ORDER BY Код";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            listBox1.Items.Clear();
            while (reader.Read())
            {
                listBox1.Items.Add(reader[0].ToString());
            }
            reader.Close();
            string query1 = "SELECT password FROM autorizationTable ORDER BY Код";
            OleDbCommand command1 = new OleDbCommand(query1, myConnection);
            OleDbDataReader reade1r = command1.ExecuteReader();
            listBox2.Items.Clear();
            while (reade1r.Read())
            {
                listBox2.Items.Add(reade1r[0].ToString());
            }
            reade1r.Close();

        }
        public void ListBoxAdminFiller()
        {
            string query = "SELECT login FROM adminsTable ORDER BY Код";
            OleDbCommand command = new OleDbCommand(query, myConnection1);
            OleDbDataReader reader = command.ExecuteReader();
            listBox3.Items.Clear();
            while (reader.Read())
            {
                listBox3.Items.Add(reader[0].ToString());
            }
            reader.Close();
            string query1 = "SELECT password FROM adminsTable ORDER BY Код";
            OleDbCommand command1 = new OleDbCommand(query1, myConnection1);
            OleDbDataReader reade1r = command1.ExecuteReader();
            listBox4.Items.Clear();
            while (reade1r.Read())
            {
                listBox4.Items.Add(reade1r[0].ToString());
            }
            reade1r.Close();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "adminAutorizationDataSet.adminsTable". При необходимости она может быть перемещена или удалена.
            this.adminsTableTableAdapter.Fill(this.adminAutorizationDataSet.adminsTable);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "autorizationDataSet.autorizationTable". При необходимости она может быть перемещена или удалена.
            this.autorizationTableTableAdapter.Fill(this.autorizationDataSet.autorizationTable);
            label6.BackColor = SystemColors.Info;
            label5.BackColor = SystemColors.ActiveCaption;
            vhodA = false;
        }
        public bool accesPas=false;
        public bool acces,vhodA ;

        private void button1_Click(object sender, EventArgs e)
        {
            if (vhodA == false)
            {
                acces = false;

                foreach (var item in listBox1.Items)
                {
                    if (textBox1.Text == item.ToString())
                    {
                        acces = true;



                    }

                }
                if (acces)
                {
                    button1.Visible = false;
                    button2.Visible = true;
                    label3.Visible = false;
                    label4.Visible = true;
                    textBox1.Visible = false;
                    textBox2.Visible = true;
                }
                else
                { MessageBox.Show("Неверный логин"); }
            }
            else
            {
                acces = false;

                foreach (var item in listBox3.Items)
                {
                    if (textBox1.Text == item.ToString())
                    {
                        acces = true;



                    }

                }
                if (acces)
                {
                    button1.Visible = false;
                    button2.Visible = true;
                    label3.Visible = false;
                    label4.Visible = true;
                    textBox1.Visible = false;
                    textBox2.Visible = true;
                }
                else
                { MessageBox.Show("Неверный логин"); }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           accesPas = false;
            if (vhodA == false)
            {
                foreach (var item1 in listBox2.Items)
                {
                    if (textBox2.Text == item1.ToString())
                    {
                        accesPas = true;
                    }

                }
                if (acces && accesPas)
                {
                    MessageBox.Show("Вы успешно вошли в систему");
                    WorkerApp workerApp = new WorkerApp();
                    workerApp.Show();
                    
                }
                else
                {
                    MessageBox.Show("Неверный пароль");
                }
            }
            else {
                foreach (var item1 in listBox4.Items)
                {
                    if (textBox2.Text == item1.ToString())
                    {
                        accesPas = true;
                    }

                }
                if (acces && accesPas)
                {
                    MessageBox.Show("Вы успешно вошли в систему");
                    Form2 form2 = new Form2();
                    form2.ShowDialog();
                    
                }
                else
                {
                    MessageBox.Show("Неверный пароль");
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            label5.BackColor = SystemColors.Info;
            label6.BackColor = SystemColors.ActiveCaption;
            vhodA = true;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            label6.BackColor = SystemColors.Info;
            label5.BackColor = SystemColors.ActiveCaption;
            vhodA = false;
        }
    }
}
