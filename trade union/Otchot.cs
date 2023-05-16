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
    public partial class Otchot : Form
    {
        public Otchot()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            actions_sot actions_Sot = new actions_sot();
            actions_Sot.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OracleConnection ConnectionToOracle;
            string connectionString = @"DATA SOURCE=95.216.251.208:1521/ORCLPDB;TNS_ADMIN=C:\Users\semyo\Oracle\network\admin;PASSWORD=oe2020;PERSIST SECURITY INFO=True;USER ID=OE";
            ConnectionToOracle = new OracleConnection(connectionString);
            ConnectionToOracle.Open();

            OracleCommand cmd1 = ConnectionToOracle.CreateCommand();
            OracleCommand cmd2 = ConnectionToOracle.CreateCommand();
            string sql1 = "SELECT COUNT (*) AS ПОЛУЧИЛИ, SUM(ВЫПЛАТИЛИ) AS СУММА_ДЕНЕГ FROM МАТПОМОЩЬ WHERE СТАТУС='всё верно' AND ДАТА_ПОД_ЗАЯВЛЕНИЯ > '"+comboBox1.Text+"'";
            string sql2 = "SELECT COUNT(*) FROM МАТПОМОЩЬ WHERE СТАТУС NOT IN ('всё верно') AND ДАТА_ПОД_ЗАЯВЛЕНИЯ > '"+comboBox1.Text+"'";
            cmd1.CommandText = sql1;
            cmd2.CommandText = sql2;
            DataTable mytable1= new DataTable();
            DataTable mytable2 = new DataTable();
            OracleDataAdapter adapter1 = new OracleDataAdapter(cmd1);
            OracleDataAdapter adapter2 = new OracleDataAdapter(cmd2);
            adapter1.Fill(mytable1);
            adapter2.Fill(mytable2);
            object[] infa1 = mytable1.Rows[0].ItemArray;
            object[] infa2 = mytable2.Rows[0].ItemArray;
            textBox1.Text = "Всего выплатили" + Convert.ToString(infa1[1]) + " руб.          Получило матпомощь "+ Convert.ToString(infa1[0]) + " .           Не получило матпомощь :"+ Convert.ToString(infa2[0]) + ". ";
            ConnectionToOracle.Close();

        }
    }
}
