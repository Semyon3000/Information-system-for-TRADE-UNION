using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовая_работа
{
    public partial class login_window_1 : Form
    {
        public login_window_1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            login_window_sot login_Window_Sot = new login_window_sot();
            login_Window_Sot.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            login_window_stu login_Window_Stu = new login_window_stu();
            login_Window_Stu.Show();
        }
    }
}
