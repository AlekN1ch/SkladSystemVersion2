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
    public partial class WorkerApp : Form
    {
        public WorkerApp()
        {
            InitializeComponent();
        }

        private void WorkerApp_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        public void CheckStudy(int stady)
        {
            switch (stady)
            {
                case 0:
                case 2:
                case 4:
                case 6:
                    button1.Enabled=false;
                    button2.Enabled = false;
                    break;
                default:
                    button1.Enabled=true;   
                    button2.Enabled=true;
                    break;
            }
            switch (stady)
            { 
                case 0:
                    label3.Text = "Отгрузка";
                    break;
                case 1:
                    label3.Text = "Контроль качества";
                    break;
                case 2  :
                    label3.Text = "Сортировка";
                    break;
                case 3:
                    label3.Text = "Сбор заказа";
                    break;
                case 4:
                    label3.Text = "Консолидация";
                    break;
                case 5:
                    label3.Text = "Упаковка";
                    break;
                case 6:
                    label3.Text = "Передача в доставку";
                    break;
            }
        }
        public static int stady;
        public static bool answer=false,ready=false;
        private void timer1_Tick(object sender, EventArgs e)
        {
           
            stady = Form2.a;
            if (ready)
            {
                button2.Visible = true;
                button1.Visible = true;
            }
            else {
                button2.Visible = false;
                button1.Visible = false;
            }
            if (answer)
            {
                label5.Visible = true;
                pictureBox2.Visible = true;
                pictureBox3.Visible = true;
            }
            else {
                label5.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
            }
          
            CheckStudy(stady);

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            CheckStudy(stady);
            Form2.MessageOfMoreTime();
        }
        public static bool acces=true;
        private void button2_Click(object sender, EventArgs e)
        {
            acces = false;
            CheckStudy(stady);
            Form2.b = false;
            Form2.now = true;
            ready = false;
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            answer = false;
            ready = true;
        }
    }
    
}
