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
    public partial class actions_sot : Form
    {
        public actions_sot()
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

            string sql1 = "UPDATE ПАСПОРТА SET СЕРИЯ = NULL, НОМЕР = NULL, КЕМ_ВЫДАН = NULL, КОГДА_ВЫДАН = NULL, ЗАРЕГИСТРИРОВАН = NULL WHERE КОГДА_ВЫДАН > '01.01.2017' AND КОГДА_ВЫДАН < '01.03.2017'";
            string sql2 = "UPDATE РЕКВИЗИТЫ_БАНКА SET НАИМ_БАНКА = NULL, НОМ_ЛИЦ_СЧЁТА = NULL, БИК = NULL, ГОДЕН_ДО = NULL WHERE ГОДЕН_ДО < '01.03.2023'";
            cmd.CommandText = sql1;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            proverka_1 Proverka_1 = new proverka_1();
            Proverka_1.Show();
        }        

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Itog_spisok itog_Spisok = new Itog_spisok();
            itog_Spisok.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Otchot_kategory otchot_Kategory = new Otchot_kategory();
            otchot_Kategory.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Otchot otchot = new Otchot();
            otchot.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            login_window_1 login_Window_1 = new login_window_1();
            login_Window_1.Show();
        }
    }
}
