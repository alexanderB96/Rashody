using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Rashody
{
    class ChartReport
    {
        Autorizacia dostup = new Autorizacia();

        public void graficETOTM(Form1 form)
        {
            form.chart1.Series["Pervii"].Points.Clear();
            dostup.cnn.Open();
            dostup.comand = dostup.cnn.CreateCommand();
             dostup.comand.CommandText = "  SELECT SUM(Dohod.KolichestvoSredstv) AS SUMM, Dohod.Usluga FROM dbo.Dohod WHERE Dohod.Date2 >= DATEADD(MONTH, DATEDIFF(MONTH, 0, CURRENT_TIMESTAMP) , 0) AND Dohod.Date2 < DATEADD(MONTH, DATEDIFF(MONTH, 0, CURRENT_TIMESTAMP) +1, 0) AND Dohod.UsersID = '"+form.id+"' GROUP BY Dohod.Usluga";
             using (SqlDataReader reader = dostup.comand.ExecuteReader())
            {
                while (reader.Read())
                {
                    object SUMM = reader["SUMM"];
                    object Usluga = reader["Usluga"];
                    form.chart1.Series["Pervii"].Points.AddXY(" " + SUMM + " " + Usluga + "" , SUMM);
                   
                }
              
            }
            dostup.cnn.Close();

            form.chart2.Series["Pervii"].Points.Clear();
            dostup.cnn.Open();
            dostup.comand = dostup.cnn.CreateCommand();
            dostup.comand.CommandText = " SELECT SUM(Dohod.KolichestvoSredstv) AS SUMM,Dohod.Usluga FROM dbo.Dohod WHERE Dohod.Date2>=DATEADD(MONTH, DATEDIFF(MONTH,0,CURRENT_TIMESTAMP) ,0) AND Dohod.Date2 < DATEADD(MONTH, DATEDIFF(MONTH, 0, CURRENT_TIMESTAMP) +1, 0) AND Dohod.UsersID = '"+form.id+"' AND Dohod.Deistv LIKE '%Пополнение%' GROUP BY Dohod.Usluga ";
            using (SqlDataReader reader = dostup.comand.ExecuteReader())
            {
                while (reader.Read())
                {
                    object SUMM = reader["SUMM"];
                    object Usluga = reader["Usluga"];
                    form.chart2.Series["Pervii"].Points.AddXY(" " + SUMM + " " + Usluga + "", SUMM);

                }

            }
            dostup.cnn.Close();

            form.chart3.Series["Pervii"].Points.Clear();
            dostup.cnn.Open();
            dostup.comand = dostup.cnn.CreateCommand();
            dostup.comand.CommandText = " SELECT SUM(Dohod.KolichestvoSredstv) AS SUMM,Dohod.Usluga FROM dbo.Dohod WHERE Dohod.Date2>=DATEADD(MONTH, DATEDIFF(MONTH,0,CURRENT_TIMESTAMP) ,0) AND Dohod.Date2 < DATEADD(MONTH, DATEDIFF(MONTH, 0, CURRENT_TIMESTAMP) +1, 0) AND Dohod.UsersID = '" + form.id + "' AND Dohod.Deistv LIKE '%Списание%' GROUP BY Dohod.Usluga ";
            using (SqlDataReader reader = dostup.comand.ExecuteReader())
            {
                while (reader.Read())
                {
                    object SUMM = reader["SUMM"];
                    object Usluga = reader["Usluga"];
                    form.chart3.Series["Pervii"].Points.AddXY(" " + SUMM + " " + Usluga + "", SUMM);

                }

            }
            dostup.cnn.Close();

        }

        public void graficPROSHM(Form1 form)
        {
            form.chart1.Series["Pervii"].Points.Clear();
            dostup.cnn.Open();
            dostup.comand = dostup.cnn.CreateCommand();
            dostup.comand.CommandText = "  SELECT SUM(Dohod.KolichestvoSredstv) AS SUMM, Dohod.Usluga FROM dbo.Dohod WHERE Dohod.Date2 >= DATEADD(MONTH, DATEDIFF(MONTH, 0, CURRENT_TIMESTAMP) -1 , 0) AND Dohod.Date2 < DATEADD(MONTH, DATEDIFF(MONTH, 0, CURRENT_TIMESTAMP) , 0) AND Dohod.UsersID = '" + form.id + "' GROUP BY Dohod.Usluga";
            using (SqlDataReader reader = dostup.comand.ExecuteReader())
            {
                while (reader.Read())
                {
                    object SUMM = reader["SUMM"];
                    object Usluga = reader["Usluga"];
                    form.chart1.Series["Pervii"].Points.AddXY(" " + SUMM + " " + Usluga + "", SUMM);

                }

            }
            dostup.cnn.Close();

            form.chart2.Series["Pervii"].Points.Clear();
            dostup.cnn.Open();
            dostup.comand = dostup.cnn.CreateCommand();
            dostup.comand.CommandText = " SELECT SUM(Dohod.KolichestvoSredstv) AS SUMM,Dohod.Usluga FROM dbo.Dohod WHERE Dohod.Date2>=DATEADD(MONTH, DATEDIFF(MONTH,0,CURRENT_TIMESTAMP) -1 ,0) AND Dohod.Date2 < DATEADD(MONTH, DATEDIFF(MONTH, 0, CURRENT_TIMESTAMP) , 0) AND Dohod.UsersID = '" + form.id + "' AND Dohod.Deistv LIKE '%Пополнение%' GROUP BY Dohod.Usluga ";
            using (SqlDataReader reader = dostup.comand.ExecuteReader())
            {
                while (reader.Read())
                {
                    object SUMM = reader["SUMM"];
                    object Usluga = reader["Usluga"];
                    form.chart2.Series["Pervii"].Points.AddXY(" " + SUMM + " " + Usluga + "", SUMM);

                }

            }
            dostup.cnn.Close();

            form.chart3.Series["Pervii"].Points.Clear();
            dostup.cnn.Open();
            dostup.comand = dostup.cnn.CreateCommand();
            dostup.comand.CommandText = " SELECT SUM(Dohod.KolichestvoSredstv) AS SUMM,Dohod.Usluga FROM dbo.Dohod WHERE Dohod.Date2>=DATEADD(MONTH, DATEDIFF(MONTH,0,CURRENT_TIMESTAMP) -1,0) AND Dohod.Date2 < DATEADD(MONTH, DATEDIFF(MONTH, 0, CURRENT_TIMESTAMP) , 0) AND Dohod.UsersID = '" + form.id + "' AND Dohod.Deistv LIKE '%Списание%' GROUP BY Dohod.Usluga ";
            using (SqlDataReader reader = dostup.comand.ExecuteReader())
            {
                while (reader.Read())
                {
                    object SUMM = reader["SUMM"];
                    object Usluga = reader["Usluga"];
                    form.chart3.Series["Pervii"].Points.AddXY(" " + SUMM + " " + Usluga + "", SUMM);

                }

            }
            dostup.cnn.Close();

        }

        public void graficPROSHNED(Form1 form)
        {
            form.chart1.Series["Pervii"].Points.Clear();
            dostup.cnn.Open();
            dostup.comand = dostup.cnn.CreateCommand();
            dostup.comand.CommandText = "  SELECT SUM(Dohod.KolichestvoSredstv) AS SUMM, Dohod.Usluga FROM dbo.Dohod WHERE Dohod.Date2 >= DATEADD(DAY, -7, CAST( CURRENT_TIMESTAMP AS DATE))  AND Dohod.Date2 < CAST(CURRENT_TIMESTAMP AS DATE) AND Dohod.UsersID = '" + form.id + "' GROUP BY Dohod.Usluga";
            using (SqlDataReader reader = dostup.comand.ExecuteReader())
            {
                while (reader.Read())
                {
                    object SUMM = reader["SUMM"];
                    object Usluga = reader["Usluga"];
                    form.chart1.Series["Pervii"].Points.AddXY(" " + SUMM + " " + Usluga + "", SUMM);

                }

            }
            dostup.cnn.Close();

            form.chart2.Series["Pervii"].Points.Clear();
            dostup.cnn.Open();
            dostup.comand = dostup.cnn.CreateCommand();
            dostup.comand.CommandText = " SELECT SUM(Dohod.KolichestvoSredstv) AS SUMM,Dohod.Usluga FROM dbo.Dohod  WHERE Dohod.Date2 >= DATEADD(DAY, -7, CAST( CURRENT_TIMESTAMP AS DATE))  AND Dohod.Date2 < CAST(CURRENT_TIMESTAMP AS DATE) AND Dohod.UsersID = '" + form.id + "' AND Dohod.Deistv LIKE '%Пополнение%' GROUP BY Dohod.Usluga ";
            using (SqlDataReader reader = dostup.comand.ExecuteReader())
            {
                while (reader.Read())
                {
                    object SUMM = reader["SUMM"];
                    object Usluga = reader["Usluga"];
                    form.chart2.Series["Pervii"].Points.AddXY(" " + SUMM + " " + Usluga + "", SUMM);

                }

            }
            dostup.cnn.Close();

            form.chart3.Series["Pervii"].Points.Clear();
            dostup.cnn.Open();
            dostup.comand = dostup.cnn.CreateCommand();
            dostup.comand.CommandText = " SELECT SUM(Dohod.KolichestvoSredstv) AS SUMM,Dohod.Usluga FROM dbo.Dohod  WHERE Dohod.Date2 >= DATEADD(DAY, -7, CAST( CURRENT_TIMESTAMP AS DATE))  AND Dohod.Date2 < CAST(CURRENT_TIMESTAMP AS DATE) AND Dohod.UsersID = '" + form.id + "' AND Dohod.Deistv LIKE '%Списание%' GROUP BY Dohod.Usluga ";
            using (SqlDataReader reader = dostup.comand.ExecuteReader())
            {
                while (reader.Read())
                {
                    object SUMM = reader["SUMM"];
                    object Usluga = reader["Usluga"];
                    form.chart3.Series["Pervii"].Points.AddXY(" " + SUMM + " " + Usluga + "", SUMM);

                }

            }
            dostup.cnn.Close();

        }
    }
}
