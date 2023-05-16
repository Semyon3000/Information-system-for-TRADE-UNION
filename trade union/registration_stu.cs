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
    public partial class registration_stu : Form
    {
        public registration_stu()
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
            string sql = "INSERT INTO ПОЛЬЗОВАТЕЛЬ ( ID_ПОЛЬЗОВАТЕЛЯ, ФИО, ПОЛ, ПАРОЛЬ, ЛОГИН, НОМ_ИНН, АББРЕВ_ИНСТИТУТА, НОМ_ТЕЛ, ДАТА_РОЖДЕНИЯ, ID_ТИПА_ПОЛЬЗ, ID_ПАСПОРТА, ID_РЕКВИЗ_БАНКА, ID_ПРОФ_БИЛЕТА) VALUES ( ПОЛЬЗ.nextval, '" + textBox1.Text+"', '"+textBox12.Text+"', '"+textBox19.Text+"', '"+textBox20.Text+"', "+textBox8.Text+", '"+textBox14.Text+ "', " + textBox7.Text + ", DATE'"+textBox5.Text+ "', 1, ДОКУМ.nextval, ДОКУМ.nextval, ДОКУМ.nextval)";
            string sql1 = "INSERT INTO РЕКВИЗИТЫ_БАНКА (ID_РЕКВИЗ_БАНКА, НАИМ_БАНКА, НОМ_ЛИЦ_СЧЁТА, БИК, ГОДЕН_ДО) VALUES (РЕКВ.nextval,'"+textBox16.Text+"', "+textBox18.Text+", "+textBox17.Text+", DATE'"+textBox3.Text+"' )";
            string sql2 = "INSERT INTO ПАСПОРТА (ID_ПАСПОРТА, СЕРИЯ, НОМЕР, КЕМ_ВЫДАН, КОГДА_ВЫДАН, ЗАРЕГИСТРИРОВАН ) VALUES (ПАСП.nextval , "+textBox11.Text+", "+textBox4.Text+", '"+textBox9.Text+"', DATE'"+textBox10.Text+"', '"+textBox2+"' )";
            string sql3 = "INSERT INTO ПРОФ_БИЛЕТЫ ( ID_ПРОФ_БИЛЕТА, НОМЕР_БИЛЕТА, КОГДА_ВЫДАН ) VALUES ( ПРОФ.nextval, "+textBox6+", DATE'"+textBox21+"')";

            cmd.CommandText = sql;
            


            ConnectionToOracle.Close();
           

            this.Hide();
            login_window_stu login_Window_Stu = new login_window_stu();
            login_Window_Stu.Show();
            
        }

        
    }
}
