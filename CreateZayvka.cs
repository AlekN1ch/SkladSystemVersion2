using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SkladSystemVersion2
{
    public partial class CreateZayvka : Form
    {
        public static string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=sklad.accdb";
        public OleDbConnection myConnection;
        public CreateZayvka()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connection);
            myConnection.Open();
        }
        public int number,id;
        public Random random = new Random();
        private void CreateZayvka_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "skladDataSet.skladTable". При необходимости она может быть перемещена или удалена.
            this.skladTableTableAdapter.Fill(this.skladDataSet.skladTable);
            FillList();
            
            number = random.Next(1000,9999);
            label2.Text = number.ToString();
           
        }
        public string name;
        public void FillList()
            {
            string query = "SELECT weight,category,ID,number FROM skladTable ORDER BY Код";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            listBox2.Items.Clear();
            while (reader.Read())
            {
                
                listBox2.Items.Add(reader[0].ToString()+" "+ reader[1].ToString()+" "+ reader[2].ToString() + " " + reader[3].ToString());
            }
            reader.Close();
            string query1 = "SELECT Tname FROM skladTable ORDER BY Код";
            OleDbCommand command1 = new OleDbCommand(query1, myConnection);
            OleDbDataReader reader1 = command1.ExecuteReader();
            listBox1.Items.Clear();
            while (reader1.Read())
            {
                listBox1.Items.Add(reader1[0].ToString());
              
            }
            reader1.Close();
        }
        public void AddInList()
        {
            id = random.Next(10000, 99999);
            string query = "INSERT INTO skladTable ([Tname],[number],[ID],[weight],[category]) VALUES " + "('" + textBox1.Text + "','" + number + "','" + id + "','" + textBox2.Text + "','" + comboBox1.SelectedItem.ToString() + "')";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
          
            FillList();
        

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           if( comboBox1.SelectedIndex==-1||comboBox1.SelectedItem.ToString()==string.Empty) MessageBox.Show("Нужно выбрать категорию товара");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddInList();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            
           

        }
        public int index;
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listBox1.SelectedIndex=index;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Zayavki zayavki = new Zayavki();
            zayavki.Show();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CreateZayvka_FormClosing(object sender, FormClosingEventArgs e)
        {
          myConnection.Close();
        }
    }
}
