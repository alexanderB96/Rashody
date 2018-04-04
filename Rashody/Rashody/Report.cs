using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using System.Data;

namespace Rashody
{
    class Report
    {
        Form1 form;
        Autorizacia dst = new Autorizacia();

        public void prosM(Form1 form) // прошлый месяц
        {
            dst.cnn.Open();
            dst.comand = dst.cnn.CreateCommand();
            dst.comand.CommandText = " SELECT SUM(Dohod.KolichestvoSredstv) AS SUMM FROM dbo.Dohod WHERE Dohod.Date2 >= DATEADD(MONTH, DATEDIFF(MONTH, 0, CURRENT_TIMESTAMP) - 1, 0) AND Dohod.Date2 < DATEADD(MONTH, DATEDIFF(MONTH, 0, CURRENT_TIMESTAMP), 0) AND Dohod.UsersID = '" + form.id + "' AND Dohod.Deistv LIKE '%Списание%' ";
            using (SqlDataReader reader = dst.comand.ExecuteReader())
            {
                if (reader.Read())
                {

                    form.otcRashod.Text = reader["SUMM"].ToString();
                }
                else
                {
                    // MessageBox.Show("Error", "OK");
                }
            }
            dst.cnn.Close();

            dst.cnn.Open();
            dst.comand = dst.cnn.CreateCommand();
            dst.comand.CommandText = " SELECT SUM(Dohod.KolichestvoSredstv) AS SUMM FROM dbo.Dohod WHERE Dohod.Date2 >= DATEADD(MONTH, DATEDIFF(MONTH, 0, CURRENT_TIMESTAMP) - 1, 0) AND Dohod.Date2 < DATEADD(MONTH, DATEDIFF(MONTH, 0, CURRENT_TIMESTAMP), 0) AND Dohod.UsersID = '" + form.id + "' AND Dohod.Deistv LIKE '%Пополнение%' ";
            using (SqlDataReader reader = dst.comand.ExecuteReader())
            {
                if (reader.Read())
                {
                    form.otcDohod.Text = reader["SUMM"].ToString();
                }
                else
                {
                    // MessageBox.Show("Error", "OK");
                }
            }
            dst.cnn.Close();
            dst.cnn.Open();
            dst.comand = dst.cnn.CreateCommand();
            dst.comand.CommandText = " SELECT SUM(Dohod.KolichestvoSredstv) AS SUMM FROM dbo.Dohod WHERE Dohod.Date2 >= DATEADD(MONTH, DATEDIFF(MONTH, 0, CURRENT_TIMESTAMP) - 1, 0) AND Dohod.Date2 < DATEADD(MONTH, DATEDIFF(MONTH, 0, CURRENT_TIMESTAMP), 0) AND Dohod.UsersID = '" + form.id + "' ";
            using (SqlDataReader reader = dst.comand.ExecuteReader())
            {
                if (reader.Read())
                {
                    form.otcPribl.Text = reader["SUMM"].ToString();
                }
                else
                {
                    // MessageBox.Show("Error", "OK");
                }
            }
            dst.cnn.Close();
        }

        public void tekM(Form1 form) // текущей месяц
        {
            dst.cnn.Open();
            dst.comand = dst.cnn.CreateCommand();
            dst.comand.CommandText = " SELECT SUM(Dohod.KolichestvoSredstv) AS SUMM FROM dbo.Dohod WHERE Dohod.Date2 >= DATEADD(MONTH, DATEDIFF(MONTH, 0, CURRENT_TIMESTAMP) , 0) AND Dohod.Date2 < DATEADD(MONTH, DATEDIFF(MONTH, 0, CURRENT_TIMESTAMP) +1, 0) AND Dohod.UsersID = '" + form.id + "' AND Dohod.Deistv LIKE '%Списание%' ";
            using (SqlDataReader reader = dst.comand.ExecuteReader())
            {
                if (reader.Read())
                {

                    form.otcRashod.Text = reader["SUMM"].ToString();
                }
                else
                {
                    // MessageBox.Show("Error", "OK");
                }
            }
            dst.cnn.Close();

            dst.cnn.Open();
            dst.comand = dst.cnn.CreateCommand();
            dst.comand.CommandText = " SELECT SUM(Dohod.KolichestvoSredstv) AS SUMM FROM dbo.Dohod WHERE Dohod.Date2 >= DATEADD(MONTH, DATEDIFF(MONTH, 0, CURRENT_TIMESTAMP) , 0) AND Dohod.Date2 < DATEADD(MONTH, DATEDIFF(MONTH, 0, CURRENT_TIMESTAMP) +1, 0) AND Dohod.UsersID = '" + form.id + "' AND Dohod.Deistv LIKE '%Пополнение%' ";
            using (SqlDataReader reader = dst.comand.ExecuteReader())
            {
                if (reader.Read())
                {
                    form.otcDohod.Text = reader["SUMM"].ToString();
                }
                else
                {
                    // MessageBox.Show("Error", "OK");
                }
            }
            dst.cnn.Close();
            dst.cnn.Open();
            dst.comand = dst.cnn.CreateCommand();
            dst.comand.CommandText = " SELECT SUM(Dohod.KolichestvoSredstv) AS SUMM FROM dbo.Dohod WHERE Dohod.Date2 >= DATEADD(MONTH, DATEDIFF(MONTH, 0, CURRENT_TIMESTAMP) , 0) AND Dohod.Date2 < DATEADD(MONTH, DATEDIFF(MONTH, 0, CURRENT_TIMESTAMP) +1, 0) AND Dohod.UsersID = '" + form.id + "' ";
            using (SqlDataReader reader = dst.comand.ExecuteReader())
            {
                if (reader.Read())
                {
                    form.otcPribl.Text = reader["SUMM"].ToString();
                }
                else
                {
                    // MessageBox.Show("Error", "OK");
                }
            }
            dst.cnn.Close();
        }
    }

}