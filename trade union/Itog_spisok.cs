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
    public partial class Itog_spisok : Form
    {
        public Itog_spisok()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            actions_sot actions_Sot = new actions_sot();
            actions_Sot.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OracleConnection ConnectionToOracle;
            string connectionString = @"DATA SOURCE=95.216.251.208:1521/ORCLPDB;TNS_ADMIN=C:\Users\semyo\Oracle\network\admin;PASSWORD=oe2020;PERSIST SECURITY INFO=True;USER ID=OE";
            ConnectionToOracle = new OracleConnection(connectionString);
            ConnectionToOracle.Open();

            OracleCommand cmd = ConnectionToOracle.CreateCommand();
            string sql = "SELECT a.фио, c.НАИМ_КАТЕГОРИИ, c.ПРИОРИТЕТНОСТЬ, i.когда_выдан, d.НАИМ_БАНКА, d.НОМ_ЛИЦ_СЧЁТА, d.БИК, d.ГОДЕН_ДО FROM ПОЛЬЗОВАТЕЛЬ a JOIN МАТПОМОЩЬ b ON b.id_пользователя=a.id_пользователя JOIN КАТЕГОРИИ c ON c.ID_КАТЕГОРИИ = b.ID_КАТЕГОРИИ JOIN РЕКВИЗИТЫ_БАНКА d ON d.ID_РЕКВИЗ_БАНКА = a.ID_РЕКВИЗ_БАНКА  JOIN ПРОФ_БИЛЕТЫ i ON i.id_проф_билета = a.id_проф_билета WHERE b.статус = 'всё верно' and b.дата_под_заявления > '01.01.2022' ORDER BY c.ПРИОРИТЕТНОСТЬ, i.когда_выдан desc fetch first "+textBox1.Text+" rows only";
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
