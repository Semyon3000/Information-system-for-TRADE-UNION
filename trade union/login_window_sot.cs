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
    public partial class login_window_sot : Form
    {
        public login_window_sot()
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
            string sql = "SELECT ID_ПОЛЬЗОВАТЕЛЯ FROM ПОЛЬЗОВАТЕЛЬ a JOIN ТИПЫ_ПОЛЬЗОВАТЕЛЕЙ b ON a.id_типа_польз = b.id_типа_польз WHERE a.ЛОГИН = '" + textBox1.Text + "' AND a.ПАРОЛЬ = '" + textBox2.Text + "' AND b.КОД_ДОСТУПА = '" + textBox3.Text + "'";
            cmd.CommandText = sql;
            DataTable mytable = new DataTable();
            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            adapter.Fill(mytable);
            object[] ID = mytable.Rows[0].ItemArray;
            Program.ID_polzovatel = Convert.ToInt32(ID[0]);
            ConnectionToOracle.Close();

            this.Hide();
            actions_sot actions_Sot = new actions_sot();
            actions_Sot.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            registration_sot registration_Sot = new registration_sot();
            registration_Sot.Show();
        }
    }
}
