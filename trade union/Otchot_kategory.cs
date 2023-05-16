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
    public partial class Otchot_kategory : Form
    {
        public Otchot_kategory()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            actions_sot actions_Sot = new actions_sot();
            actions_Sot.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleConnection ConnectionToOracle;
            string connectionString = @"DATA SOURCE=95.216.251.208:1521/ORCLPDB;TNS_ADMIN=C:\Users\semyo\Oracle\network\admin;PASSWORD=oe2020;PERSIST SECURITY INFO=True;USER ID=OE";
            ConnectionToOracle = new OracleConnection(connectionString);
            ConnectionToOracle.Open();

            OracleCommand cmd = ConnectionToOracle.CreateCommand();
            string sql = "SELECT b.НАИМ_КАТЕГОРИИ, c.аббрев_института, COUNT (c.аббрев_института) FROM МАТПОМОЩЬ a JOIN КАТЕГОРИИ b ON b.ID_КАТЕГОРИИ = a.ID_КАТЕГОРИИ  JOIN ПОЛЬЗОВАТЕЛЬ c ON c.ID_ПОЛЬЗОВАТЕЛЯ = a.ID_ПОЛЬЗОВАТЕЛЯ WHERE a.СТАТУС = 'всё верно' AND a.ДАТА_ПОД_ЗАЯВЛЕНИЯ > '"+comboBox1.Text+"' AND c.аббрев_института IS NOT NULL GROUP BY ROLLUP (b.НАИМ_КАТЕГОРИИ, c.аббрев_института)";
            cmd.CommandText = sql;
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            ConnectionToOracle.Close();
        }
    }
}
