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
    public partial class proverka_1 : Form
    {
        public proverka_1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OracleConnection ConnectionToOracle;
            string connectionString = @"DATA SOURCE=95.216.251.208:1521/ORCLPDB;TNS_ADMIN=C:\Users\semyo\Oracle\network\admin;PASSWORD=oe2020;PERSIST SECURITY INFO=True;USER ID=OE";
            ConnectionToOracle = new OracleConnection(connectionString);
            ConnectionToOracle.Open();

            OracleCommand cmd = ConnectionToOracle.CreateCommand();
            string sql = "SELECT пользователь.ID_ПОЛЬЗОВАТЕЛЯ, пользователь.фио, пользователь.АББРЕВ_ИНСТИТУТА FROM ПОЛЬЗОВАТЕЛЬ JOIN МАТПОМОЩЬ ON МАТПОМОЩЬ.ID_ПОЛЬЗОВАТЕЛЯ = ПОЛЬЗОВАТЕЛЬ.ID_ПОЛЬЗОВАТЕЛЯ WHERE матпомощь.дата_под_заявления > '01.01.2022' AND матпомощь.статус NOT IN ('всё верно')";
            cmd.CommandText = sql;
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            ConnectionToOracle.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            actions_sot actions_Sot = new actions_sot();    
            actions_Sot.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.ID_proverka = Convert.ToInt32(textBox1.Text);
            this.Hide();
            prpverka_2 Proverka_2 = new prpverka_2();
            Proverka_2.Show();
        }
    }
}
