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
    public partial class Status_statement : Form
    {
        OracleConnection ConnectionToOracle;
        string connectionString = @"DATA SOURCE=95.216.251.208:1521/ORCLPDB;TNS_ADMIN=C:\Users\semyo\Oracle\network\admin;PASSWORD=oe2020;PERSIST SECURITY INFO=True;USER ID=OE";

        public Status_statement()
        {
            InitializeComponent();
            ConnectionToOracle = new OracleConnection(connectionString);
            ConnectionToOracle.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            actions_stu actions_Stu = new actions_stu();
            actions_Stu.Show();
        }

        private void Status_statement_Load(object sender, EventArgs e)
        {
            OracleCommand cmd = ConnectionToOracle.CreateCommand();
            string sql = "SELECT a.СТАТУС FROM МАТПОМОЩЬ a JOIN ПОЛЬЗОВАТЕЛЬ b ON b.id_пользователя = a.ID_ПОЛЬЗОВАТЕЛЯ WHERE b.id_пользователя = "+Program.ID_polzovatel+" AND a.ДАТА_ПОД_ЗАЯВЛЕНИЯ > '01.01.2022'";
            cmd.CommandText = sql;
            DataTable mytable = new DataTable();
            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            adapter.Fill(mytable);
            object[] ID = mytable.Rows[0].ItemArray;
            textBox1.Text = Convert.ToString(ID[0]);
            ConnectionToOracle.Close();
        }
    }
}
