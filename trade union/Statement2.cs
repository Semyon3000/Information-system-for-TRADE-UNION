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
    public partial class Statement2 : Form
    {
        OracleConnection ConnectionToOracle;
        string connectionString = @"DATA SOURCE=95.216.251.208:1521/ORCLPDB;TNS_ADMIN=C:\Users\semyo\Oracle\network\admin;PASSWORD=oe2020;PERSIST SECURITY INFO=True;USER ID=OE";

        public Statement2()
        {
            InitializeComponent();
            ConnectionToOracle = new OracleConnection(connectionString);
            ConnectionToOracle.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string category1 = comboBox1.Text;
            string category2 = Convert.ToString(category1[0]);
            category2 += Convert.ToString(category1[1]);
            DateTime thisDay = DateTime.Today;

            OracleCommand cmd = ConnectionToOracle.CreateCommand();
            string sql = "INSERT INTO МАТПОМОЩЬ ( ID_ЗАЯВЛЕНИЯ, НОМ_КУРСА, НАИМ_ГРУППЫ, ДАТА_ПОД_ЗАЯВЛЕНИЯ, СТАТУС, ID_ПОЛЬЗОВАТЕЛЯ, ID_КАТЕГОРИИ ) VALUES ( МАТП.nextval , "+textBox15.Text + ", '"+textBox13.Text + "', DATE'"+thisDay.ToString("yyyy-MM-dd") +"', 'ещё не проверено!', " + Program.ID_polzovatel + ", "+category2+")";
            string sql1 = "UPDATE ПАСПОРТА SET СЕРИЯ = "+textBox19.Text + ", НОМЕР = "+textBox11.Text + ", КЕМ_ВЫДАН = "+textBox9.Text + ", КОГДА_ВЫДАН = DATE'" + textBox10.Text + "', ЗАРЕГИСТРИРОВАН = "+textBox2.Text + " WHERE ID_ПАСПОРТА = (SELECT ПАСПОРТА.ID_ПАСПОРТА FROM ПОЛЬЗОВАТЕЛЬ JOIN ПАСПОРТА ON ПАСПОРТА.ID_ПАСПОРТА = ПОЛЬЗОВАТЕЛЬ.ID_ПАСПОРТА WHERE ПОЛЬЗОВАТЕЛЬ.ID_ПОЛЬЗОВАТЕЛЯ = "+Program.ID_polzovatel+")";
            string sql2 = "UPDATE РЕКВИЗИТЫ_БАНКА SET НАИМ_БАНКА = "+textBox20.Text+", НОМ_ЛИЦ_СЧЁТА = "+textBox18.Text+", БИК = "+textBox17.Text+", ГОДЕН_ДО = DATE'" + textBox16.Text + "' WHERE ID_РЕКВИЗ_БАНКА = (SELECT реквизиты_банка.id_реквиз_банка FROM ПОЛЬЗОВАТЕЛЬ JOIN РЕКВИЗИТЫ_БАНКА ON реквизиты_банка.id_реквиз_банка = пользователь.id_реквиз_банка WHERE ПОЛЬЗОВАТЕЛЬ.ID_ПОЛЬЗОВАТЕЛЯ = " + Program.ID_polzovatel + ")";
            string sql3 = "UPDATE ПРОФ_БИЛЕТЫ SET НОМЕР_БИЛЕТА = "+textBox6.Text+ ", КОГДА_ВЫДАН = DATE'" + textBox21.Text + "' WHERE ID_ПРОФ_БИЛЕТА = ( SELECT проф_билеты.id_проф_билета FROM ПОЛЬЗОВАТЕЛЬ JOIN ПРОФ_БИЛЕТЫ ON проф_билеты.id_проф_билета = пользователь.id_проф_билета WHERE ПОЛЬЗОВАТЕЛЬ.ID_ПОЛЬЗОВАТЕЛЯ = " + Program.ID_polzovatel + ")";
            cmd.CommandText = sql;


            ConnectionToOracle.Close();
            this.Hide();
            actions_stu actions_Stu = new actions_stu();
            actions_Stu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = ConnectionToOracle.CreateCommand();
            string sql = "";
            string sql1 = "UPDATE ПАСПОРТА SET СЕРИЯ = " + textBox19.Text + ", НОМЕР = " + textBox11.Text + ", КЕМ_ВЫДАН = " + textBox9.Text + ", КОГДА_ВЫДАН = DATE'" + textBox10.Text + "', ЗАРЕГИСТРИРОВАН = " + textBox2.Text + " WHERE ID_ПАСПОРТА = (SELECT ПАСПОРТА.ID_ПАСПОРТА FROM ПОЛЬЗОВАТЕЛЬ JOIN ПАСПОРТА ON ПАСПОРТА.ID_ПАСПОРТА = ПОЛЬЗОВАТЕЛЬ.ID_ПАСПОРТА WHERE ПОЛЬЗОВАТЕЛЬ.ID_ПОЛЬЗОВАТЕЛЯ = " + Program.ID_polzovatel + ")";
            string sql2 = "UPDATE РЕКВИЗИТЫ_БАНКА SET НАИМ_БАНКА = " + textBox20.Text + ", НОМ_ЛИЦ_СЧЁТА = " + textBox18.Text + ", БИК = " + textBox17.Text + ", ГОДЕН_ДО = DATE'" + textBox16.Text + "' WHERE ID_РЕКВИЗ_БАНКА = (SELECT реквизиты_банка.id_реквиз_банка FROM ПОЛЬЗОВАТЕЛЬ JOIN РЕКВИЗИТЫ_БАНКА ON реквизиты_банка.id_реквиз_банка = пользователь.id_реквиз_банка WHERE ПОЛЬЗОВАТЕЛЬ.ID_ПОЛЬЗОВАТЕЛЯ = " + Program.ID_polzovatel + ")";
            string sql3 = "UPDATE ПРОФ_БИЛЕТЫ SET НОМЕР_БИЛЕТА = " + textBox6.Text + ", КОГДА_ВЫДАН = DATE'" + textBox21.Text + "' WHERE ID_ПРОФ_БИЛЕТА = ( SELECT проф_билеты.id_проф_билета FROM ПОЛЬЗОВАТЕЛЬ JOIN ПРОФ_БИЛЕТЫ ON проф_билеты.id_проф_билета = пользователь.id_проф_билета WHERE ПОЛЬЗОВАТЕЛЬ.ID_ПОЛЬЗОВАТЕЛЯ = " + Program.ID_polzovatel + ")";
            cmd.CommandText = sql;


            ConnectionToOracle.Close();
            this.Hide();
            actions_stu actions_Stu = new actions_stu();
            actions_Stu.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = ConnectionToOracle.CreateCommand();
            string sql = "SELECT a.ФИО, a.дата_рождения, e.ном_курса, a.аббрев_института, e.наим_группы, a.пол, f.наим_категории, b.серия, b.номер, b.когда_выдан, b.кем_выдан, b.зарегистрирован, a.ном_инн, a.ном_тел, d.номер_билета, d.когда_выдан, c.ном_лиц_счёта, c.бик, c.наим_банка, c.годен_до, e.дата_под_заявления FROM ПОЛЬЗОВАТЕЛЬ a JOIN ПАСПОРТА b ON b.ID_ПАСПОРТА = a.ID_ПАСПОРТА JOIN РЕКВИЗИТЫ_БАНКА c ON c.id_реквиз_банка = a.id_реквиз_банка JOIN ПРОФ_БИЛЕТЫ d ON d.id_проф_билета = a.id_проф_билета JOIN МАТПОМОЩЬ e ON e.id_пользователя = a.id_пользователя JOIN КАТЕГОРИИ f ON f.id_категории = e.id_категории WHERE a.id_пользователя = " + Program.ID_polzovatel + " ";
            cmd.CommandText = sql;
            DataTable mytable = new DataTable();
            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            adapter.Fill(mytable);
            object[] ID = mytable.Rows[0].ItemArray;
            textBox1.Text = Convert.ToString(ID[0]);
            textBox5.Text = Convert.ToString(ID[1]);
            textBox15.Text = Convert.ToString(ID[2]);
            textBox14.Text = Convert.ToString(ID[3]);
            textBox13.Text = Convert.ToString(ID[4]);
            textBox12.Text = Convert.ToString(ID[5]);
            comboBox1.Text = Convert.ToString(ID[6]);
            textBox19.Text = Convert.ToString(ID[7]);
            textBox11.Text = Convert.ToString(ID[8]);
            textBox10.Text = Convert.ToString(ID[9]);
            textBox9.Text = Convert.ToString(ID[10]);
            textBox2.Text = Convert.ToString(ID[11]);
            textBox8.Text = Convert.ToString(ID[12]);
            textBox7.Text = Convert.ToString(ID[13]);
            textBox6.Text = Convert.ToString(ID[14]);
            textBox21.Text = Convert.ToString(ID[15]);
            textBox18.Text = Convert.ToString(ID[16]);
            textBox17.Text = Convert.ToString(ID[17]);
            textBox20.Text = Convert.ToString(ID[18]);
            textBox16.Text = Convert.ToString(ID[19]);
            ConnectionToOracle.Close();
        }
    }
}
