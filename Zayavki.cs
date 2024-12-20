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
    public partial class Zayavki : Form
    {
        public static string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=sklad.accdb";
        public OleDbConnection myConnection;
        public Zayavki()
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
                Form2 form2 = new Form2();
                form2.ShowDialog();
            }
            this.Close();
        }

        private void Zayavki_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "skladDataSet.skladTable". При необходимости она может быть перемещена или удалена.
            this.skladTableTableAdapter.Fill(this.skladDataSet.skladTable);
            string query2 = "SELECT number FROM skladTable ORDER BY Код";
            OleDbCommand command2 = new OleDbCommand(query2, myConnection);
            OleDbDataReader reader2 = command2.ExecuteReader();
            listBox1.Items.Clear();
            while (reader2.Read())
            {
                listBox1.Items.Add(" #" + reader2[0].ToString());
            }
            reader2.Close();
        }

        private void Zayavki_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateZayvka createZayvka = new CreateZayvka();
            createZayvka.ShowDialog();
            this.Close();
        }
    }
}
