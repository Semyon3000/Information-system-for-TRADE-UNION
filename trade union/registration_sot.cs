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
    public partial class registration_sot : Form
    {
        public registration_sot()
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
            string sql = "INSERT INTO ПОЛЬЗОВАТЕЛЬ ( ID_ПОЛЬЗОВАТЕЛЯ, ФИО, ПОЛ, ПАРОЛЬ, ЛОГИН, НОМ_ИНН, АББРЕВ_ИНСТИТУТА, НОМ_ТЕЛ, ДАТА_РОЖДЕНИЯ, ID_ТИПА_ПОЛЬЗ, ID_ПАСПОРТА, ID_РЕКВИЗ_БАНКА, ID_ПРОФ_БИЛЕТА) VALUES ( ПОЛЬЗ.nextval, '" + textBox3.Text + "', '" + textBox12.Text + "', '" + textBox19.Text + "', '" +textBox20.Text+ "',  NULL,  NULL,  NULL, DATE'" + textBox5.Text+ "', 2,  NULL,  NULL, NULL)";
            cmd.CommandText = sql;

            ConnectionToOracle.Close();
            this.Hide();
            login_window_sot login_Window_Sot = new login_window_sot(); 
            login_Window_Sot.Show();
        }
    }
}
