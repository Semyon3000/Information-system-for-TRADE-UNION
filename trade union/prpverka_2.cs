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
    public partial class prpverka_2 : Form
    {
        OracleConnection ConnectionToOracle;
        string connectionString = @"DATA SOURCE=95.216.251.208:1521/ORCLPDB;TNS_ADMIN=C:\Users\semyo\Oracle\network\admin;PASSWORD=oe2020;PERSIST SECURITY INFO=True;USER ID=OE";

        public prpverka_2()
        {
            InitializeComponent();
            ConnectionToOracle = new OracleConnection(connectionString);
            ConnectionToOracle.Open();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            actions_sot actions_Sot = new actions_sot();
            actions_Sot.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = ConnectionToOracle.CreateCommand();
            string sql = "SELECT a.ФИО, a.дата_рождения, e.ном_курса, a.аббрев_института, e.наим_группы, a.пол, f.наим_категории, b.серия, b.номер, b.когда_выдан, b.кем_выдан, b.зарегистрирован, a.ном_инн, a.ном_тел, d.номер_билета, d.когда_выдан, c.ном_лиц_счёта, c.бик, c.наим_банка, c.годен_до, e.дата_под_заявления FROM ПОЛЬЗОВАТЕЛЬ a JOIN ПАСПОРТА b ON b.ID_ПАСПОРТА = a.ID_ПАСПОРТА JOIN РЕКВИЗИТЫ_БАНКА c ON c.id_реквиз_банка = a.id_реквиз_банка JOIN ПРОФ_БИЛЕТЫ d ON d.id_проф_билета = a.id_проф_билета JOIN МАТПОМОЩЬ e ON e.id_пользователя = a.id_пользователя JOIN КАТЕГОРИИ f ON f.id_категории = e.id_категории WHERE a.id_пользователя = " + Program.ID_proverka + " ";
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
            OracleCommand cmd = ConnectionToOracle.CreateCommand();
            string sql = "SELECT b.НАИМ_ПАПКИ FROM ДОКУМЕНТЫ a INNER JOIN АДРЕСА_ДОКУМЕНТОВ b ON a.ID_АДРЕСА = b.ID_АДРЕСА WHERE a.ID_ПОЛЬЗОВАТЕЛЯ = "+Program.ID_proverka+" AND a.НАИМ_ДОКУМЕНТА = '"+comboBox1.Text+"'";
            cmd.CommandText = sql;
            DataTable mytable = new DataTable();
            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
            adapter.Fill(mytable);
            object[] ID = mytable.Rows[0].ItemArray;
            label1.Text = "C:/матпомощь/" + Convert.ToString(ID[0])+" ";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = ConnectionToOracle.CreateCommand();
            string sql = "UPDATE МАТПОМОЩЬ SET СТАТУС = 'ИСПРАВИТЬ СЕРИЮ ПАСПОРТА' WHERE ID_ЗАЯВЛЕНИЯ = ( SELECT матпомощь.id_заявления FROM ПОЛЬЗОВАТЕЛЬ JOIN МАТПОМОЩЬ ON матпомощь.id_пользователя = пользователь.id_пользователя WHERE ПОЛЬЗОВАТЕЛЬ.ID_ПОЛЬЗОВАТЕЛЯ = "+Program.ID_proverka+" AND матпомощь.дата_под_заявления > '01.01.2022')";
            cmd.CommandText = sql;
        }
    }
}
