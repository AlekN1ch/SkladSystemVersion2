using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkladSystemVersion2
{
    public partial class Sklad : Form
    {
        public Sklad()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                Form2 form2 = new Form2();
                form2.ShowDialog();
            }
            if (comboBox1.SelectedIndex == 0)
            {
                Zayavki zayavka = new Zayavki();
                zayavka.ShowDialog();
            }
            this.Close();
        }

        private void Sklad_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "skladDataSet.skladTable". При необходимости она может быть перемещена или удалена.
            this.skladTableTableAdapter.Fill(this.skladDataSet.skladTable);

        }
    }
}
