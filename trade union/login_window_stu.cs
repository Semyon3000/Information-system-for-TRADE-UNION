using Oracle.ManagedDataAccess.Client;
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
    public partial class login_window_stu : Form
    {
        public login_window_stu()
        {
            InitializeComponent();
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            OracleConnection ConnectionToOracle;
            string connectionString = @"DATA SOURCE=95.216.251.208:1521/ORCLPDB;TNS_ADMIN=C:\Users\semyo\Oracle\network\admin;PASSWORD=oe2020;PERSIST SECURITY INFO=True;USER ID=OE";
            ConnectionToOracle = new OracleConnection(connectionString);
            ConnectionToOracle.Open();

            OracleCommand cmd = ConnectionToOracle.CreateCommand();
            string sql = "SELECT ID_ПОЛЬЗОВАТЕЛЯ FROM ПОЛЬЗОВАТЕЛЬ WHERE ЛОГИН = '" + textBox1.Text + "' AND ПАРОЛЬ = '" + textBox2.Text + "'";
            cmd.CommandText = sql;
            DataTable mytable = new DataTable();
            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            adapter.Fill(mytable);
            object[] ID = mytable.Rows[0].ItemArray;
            Program.ID_polzovatel = Convert.ToInt32(ID[0]);
            ConnectionToOracle.Close();
            this.Hide();
            actions_stu actions_Stu = new actions_stu();
            actions_Stu.Show();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            registration_stu registration_Stu = new registration_stu();
            registration_Stu.Show();

        }
    }
}
