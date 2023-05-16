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
    public partial class actions_stu : Form
    {
        public actions_stu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Status_statement status_Statement = new Status_statement();
            status_Statement.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Statement2 statement2 = new Statement2();
            statement2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            login_window_1 login_Window_1 = new login_window_1();
            login_Window_1.Show();
        }
    }
}
