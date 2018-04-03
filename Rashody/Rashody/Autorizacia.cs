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
    #region
    public class Autorizacia  // подключение к серверу
    {
        Form1 form;
        public string str = null;
        public SqlConnection cnn = new SqlConnection(@"Data Source=АЛЕКСАНДР-ПК; Initial Catalog = Costs; Integrated Security=SSPI;");
        public SqlCommand comand;
        public SqlConnection bldr;
        public string id_users;


        public Autorizacia(Form1 form)
        {
            this.form = form;

        }

        public Autorizacia()
        {
        }

        public void Aut()
        {

            try
            {
                cnn.Open();
                str = "Удачно!";
                form.connectINF.Text = str;
                cnn.Close();
            }
            catch (Exception ex)
            {
                str = "Не Удачно!";
                form.connectINF.Text = str;
            }


        }

        public void Ident()
        {
            string login = form.textLog.Text.ToString();
            string password = form.textPass.Text.ToString();
            cnn.Open();
            comand = cnn.CreateCommand();
            comand.CommandText = "SELECT * FROM Users Where Login = '" + login + "' and Password = '" + password + "' ";
            using (SqlDataReader reader = comand.ExecuteReader())
            {
                if (reader.Read())
                {
                    string id_us = reader["ID"].ToString();
                    Int32.TryParse(id_us, out int id_users);
                    form.id = id_users;
                    MessageBox.Show("Вы успешно авторизовались!" + "Ваш ID" + id_users, "OK");
                    form.tabPage3.Parent = null;
                    form.tabPage4.Parent = form.TabControl;
                    form.HistoryLabel.Enabled = true;
                    form.Home.Enabled = true;
                    form.labelGrafik.Enabled = true;
                    form.Autoriz.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Не верные логин или пароль", "Проверьте введеные данные", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    form.textLog.Text = "";
                    form.textPass.Text = "";
                }
            }
            cnn.Close();

            #region
            /*  bool proverka;
              try
              {

                  while (reader.Read())
                  {
                      if (form.textLog.Text.ToString() == reader["Login"].ToString() & form.textPass.Text == reader["Password"].ToString())
                      {
                          proverka = true;
                          MessageBox.Show("Успешно!", "OK");
                          form.tabPage3.Parent = null;
                          form.tabPage4.Parent = form.TabControl;
                      }
                      else
                      {
                          proverka = false;
                          MessageBox.Show("Проверьте правильность введеных данных");
                      }
                  }
              }
              catch (SqlException ex)
              {
                  MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK);
              }*/
            #endregion

        }

        public void Dannye(Form1 form)
        {

            cnn.Open();
            comand = cnn.CreateCommand();
            comand.CommandText = " SELECT  Dohod.UsersID, SUM(Dohod.KolichestvoSredstv) AS SUMMA FROM dbo.Dohod Where UsersID = '" + form.id + "' AND Dohod.Var_Scheta = ' 1 '   GROUP BY Dohod.UsersID ";
            // comand.CommandText = "SELECT * FROM Dohod Where UsersID = '" + form.id + "' and Var_Scheta = ' 1 ' ";
            using (SqlDataReader reader = comand.ExecuteReader())
            {
                if (reader.Read())
                {
                    /*form.cartaMoney.Text = null;
                    form.cartaMoney.Text = reader["SUMMA"].ToString();*/
                    form.cartTitLBt.LabelText = reader["SUMMA"].ToString();
                }
                else
                {
                    // MessageBox.Show("Error", "OK");
                }
            }
            cnn.Close();

            cnn.Open();
            comand = cnn.CreateCommand();
            comand.CommandText = " SELECT  Dohod.UsersID, SUM(Dohod.KolichestvoSredstv) AS SUMMA FROM dbo.Dohod Where UsersID = '" + form.id + "' AND Dohod.Var_Scheta = ' 2 '   GROUP BY Dohod.UsersID ";
            using (SqlDataReader reader = comand.ExecuteReader())
            {
                if (reader.Read())
                {
                   /* form.koshMoney.Text = null;
                    form.koshMoney.Text = reader["SUMMA"].ToString();*/
                    form.koshTitLBt.LabelText = reader["SUMMA"].ToString();
                }
                else
                {
                    // MessageBox.Show("Error", "OK");
                }
            }
            cnn.Close();

            cnn.Open();
            comand = cnn.CreateCommand();
            comand.CommandText = " SELECT  Dohod.UsersID, SUM(Dohod.KolichestvoSredstv) AS SUMMA FROM dbo.Dohod Where UsersID = '" + form.id + "' AND Dohod.Var_Scheta = ' 3 '   GROUP BY Dohod.UsersID ";
            using (SqlDataReader reader = comand.ExecuteReader())
            {
                if (reader.Read())
                {
                    /*form.bankMoney.Text = null;
                    form.bankMoney.Text = reader["SUMMA"].ToString();*/
                    form.bankTitLBt.LabelText = reader["SUMMA"].ToString();
                }
                else
                {
                    // MessageBox.Show("Error", "OK");
                }
            }
            cnn.Close();
            cnn.Open();
            comand = cnn.CreateCommand();
            comand.CommandText = " SELECT  Dohod.UsersID ,SUM(Dohod.KolichestvoSredstv) AS Summa FROM dbo.Dohod WHERE  Dohod.UsersID = '" + form.id + "'  GROUP BY Dohod.UsersID ";
            using (SqlDataReader reader = comand.ExecuteReader())
            {
                if (reader.Read())
                {
                    form.obshSum.Text = null;
                    form.obshSum.Text = reader["Summa"].ToString();
                }
                else
                {
                    // MessageBox.Show("Error", "OK");
                }
            }
            cnn.Close();

            cnn.Open();
            comand = cnn.CreateCommand();
            comand.CommandText = " SELECT  Dohod.KolichestvoSredstv,  Dohod.Var_Scheta ,MAX(Dohod.Time) AS Time ,MAX(Dohod.Data) AS Data FROM dbo.Dohod WHERE (Dohod.Var_Scheta = 1  OR Dohod.Var_Scheta = 2 OR Dohod.Var_Scheta = 3) and Dohod.Date2 = (SELECT   MAX(Dohod.Date2) AS expr1  FROM dbo.Dohod  WHERE Dohod.UsersID = '" + form.id + "') GROUP BY Dohod.Var_Scheta,  Dohod.KolichestvoSredstv";
            using (SqlDataReader reader = comand.ExecuteReader())
            {
                if (reader.Read())
                {
                    form.labelSumm.Text = null;
                    form.labelSumm.Text = reader["KolichestvoSredstv"].ToString();
                }
                else
                {
                    // MessageBox.Show("Error", "OK");
                }
            }
            cnn.Close();

            cnn.Open();
            comand = cnn.CreateCommand();
            comand.CommandText = " SELECT  Dohod.KolichestvoSredstv,  Dohod.Var_Scheta ,Dohod.Deistv ,MAX(Dohod.Time) AS Time ,MAX(Dohod.Data) AS Data FROM dbo.Dohod WHERE (Dohod.Var_Scheta = 1  OR Dohod.Var_Scheta = 2 OR Dohod.Var_Scheta = 3) and Dohod.Date2 = (SELECT   MAX(Dohod.Date2) AS expr1  FROM dbo.Dohod  WHERE Dohod.UsersID = '" + form.id + "') GROUP BY Dohod.Var_Scheta,  Dohod.KolichestvoSredstv, Dohod.Deistv";
            using (SqlDataReader reader = comand.ExecuteReader())
            {
                if (reader.Read())
                {
                    form.labelDeistv.Text = null;
                    form.labelDeistv.Text = reader["Deistv"].ToString();
                }
                else
                {
                    // MessageBox.Show("Error", "OK");
                }
            }
            cnn.Close();

            cnn.Open();
            comand = cnn.CreateCommand();
            comand.CommandText = " SELECT  Dohod.KolichestvoSredstv,  Dohod.Var_Scheta ,Dohod.Deistv ,MAX(Dohod.Time) AS Time ,MAX(Dohod.Data) AS Data, Dohod.Usluga FROM dbo.Dohod WHERE (Dohod.Var_Scheta = 1  OR Dohod.Var_Scheta = 2 OR Dohod.Var_Scheta = 3) and Dohod.Date2 = (SELECT   MAX(Dohod.Date2) AS expr1  FROM dbo.Dohod  WHERE Dohod.UsersID = '" + form.id + "') GROUP BY Dohod.Var_Scheta,  Dohod.KolichestvoSredstv, Dohod.Deistv, Dohod.Usluga";
            using (SqlDataReader reader = comand.ExecuteReader())
            {
                if (reader.Read())
                {
                    form.poslabDeistv.Text = null;
                    form.poslabDeistv.Text = reader["Usluga"].ToString();
                }
                else
                {
                    // MessageBox.Show("Error", "OK");
                }
            }
            cnn.Close();

        }

        public void Vnesenie(Form1 form)
        {

            cnn.Open();
            comand = cnn.CreateCommand();
            comand.CommandText = "INSERT INTO Dohod (NameSchet, KolichestvoSredstv, Var_Scheta, UsersID, Data, Date2, Deistv, Usluga) VALUES  (@NameSchet, @KolichestvoSredstv, @Var_Scheta, @UsersID, @Data, @Date2, @Deistv, @Usluga)";
            comand.Parameters.AddWithValue("@NameSchet", Convert.ToString(form.tekst));
            comand.Parameters.AddWithValue("@KolichestvoSredstv", Convert.ToDouble(form.textPopolnenie.Text));
            comand.Parameters.AddWithValue("@Var_Scheta", Convert.ToInt32(form.tekst));
            comand.Parameters.AddWithValue("@UsersID", Convert.ToInt32(form.id));
            comand.Parameters.AddWithValue("@Data", DateTime.Now.ToShortDateString());
            comand.Parameters.AddWithValue("@Date2", DateTime.Now.ToLocalTime());
            comand.Parameters.AddWithValue("@Deistv", Convert.ToString("Пополнение"));
            comand.Parameters.AddWithValue("@Usluga", Convert.ToString(form.viborPopol.Text));

            comand.ExecuteNonQuery();
            cnn.Close();
            form.viborSpis.Text = form.viborPopol.Text = form.viborUslugi.Text = "";
            form.labelDeistv.Text = "";
            form.labelDeistv.Text = "Пополнение";
            //form.poslabDeistv.Text = form.tekst;


        }
        public void Spisanie(Form1 form)
        {
            if (form.znachLabel == "0") // проверка условия, если сумма в счёте меньше нуля. то списать средства со счёта нельзя
            {
                MessageBox.Show("Сумма списания не должна быть больше суммы остатка", "Ошибка списания", MessageBoxButtons.OK, MessageBoxIcon.Error);
                form.znachLabel = "";
            }
            else
            {
                cnn.Open();
                comand = cnn.CreateCommand();
                comand.CommandText = "INSERT INTO Dohod (NameSchet, KolichestvoSredstv, Var_Scheta, UsersID, Data, Date2, Deistv, Usluga) VALUES  (@NameSchet, @KolichestvoSredstv, @Var_Scheta, @UsersID, @Data, @Date2, @Deistv, @Usluga)";
                comand.Parameters.AddWithValue("@NameSchet", Convert.ToString(form.tekst));
                comand.Parameters.AddWithValue("@KolichestvoSredstv", Convert.ToDouble("-" + form.textSpisanie.Text));
                comand.Parameters.AddWithValue("@Var_Scheta", Convert.ToInt32(form.tekst));
                comand.Parameters.AddWithValue("@UsersID", Convert.ToInt32(form.id));
                comand.Parameters.AddWithValue("@Data", DateTime.Now.ToShortDateString());
                comand.Parameters.AddWithValue("@Date2", DateTime.Now.ToLocalTime());
                comand.Parameters.AddWithValue("@Deistv", Convert.ToString("Списание"));
                comand.Parameters.AddWithValue("@Usluga", Convert.ToString(form.viborUslugi.Text));

                comand.ExecuteNonQuery();
                cnn.Close();
                form.viborSpis.Text = form.viborPopol.Text = form.viborUslugi.Text = "";
                form.labelDeistv.Text = "";
                form.labelDeistv.Text = "Списание";
            }


            // form.poslabDeistv.Text = form.tkst;


        }

        public void History(Form1 form)
        {
            form.listHistory.Items.Clear();
            cnn.Open();
            System.Text.StringBuilder results = new System.Text.StringBuilder();
            SqlCommand SC = new SqlCommand();
            SC.Connection = cnn;
            SC.CommandType = CommandType.Text;
            SC.CommandText = "SELECT TOP 10  Dohod.KolichestvoSredstv FROM dbo.Dohod WHERE Dohod.UsersID = '" + form.id + "' ORDER BY Dohod.Date2 DESC";
            SqlDataReader SDR = SC.ExecuteReader();
            bool MoreResults = false;
            do
            {
                while (SDR.Read())
                {
                    for (int i = 0; i < SDR.FieldCount; i = i + 1)
                        form.listHistory.Items.Add(SDR[i]);
                }
                MoreResults = SDR.NextResult();
            } while (MoreResults);
            SDR.Close();
            cnn.Close();

            form.listHistory1.Items.Clear();
            cnn.Open();
            System.Text.StringBuilder results1 = new System.Text.StringBuilder();
            SqlCommand SC1 = new SqlCommand();
            SC.Connection = cnn;
            SC.CommandType = CommandType.Text;
            SC.CommandText = "SELECT TOP 10  Dohod.Date2 FROM dbo.Dohod WHERE Dohod.UsersID = '" + form.id + "' ORDER BY Dohod.Date2 DESC";
            SqlDataReader SDR1 = SC.ExecuteReader();
            bool MoreResults1 = false;
            do
            {
                while (SDR1.Read())
                {
                    for (int i = 0; i < SDR1.FieldCount; i = i + 1)
                        form.listHistory1.Items.Add(SDR1[i]);
                }
                MoreResults1 = SDR1.NextResult();
            } while (MoreResults1);
            SDR1.Close();
            cnn.Close();

            form.listHistory2.Items.Clear();
            cnn.Open();
            System.Text.StringBuilder results2 = new System.Text.StringBuilder();
            SqlCommand SC2 = new SqlCommand();
            SC.Connection = cnn;
            SC.CommandType = CommandType.Text;
            SC.CommandText = "SELECT TOP 10  Dohod.Deistv FROM dbo.Dohod WHERE Dohod.UsersID = '" + form.id + "' ORDER BY Dohod.Date2 DESC";
            SqlDataReader SDR2 = SC.ExecuteReader();
            bool MoreResults2 = false;
            do
            {
                while (SDR2.Read())
                {
                    for (int i = 0; i < SDR2.FieldCount; i = i + 1)
                        form.listHistory2.Items.Add(SDR2[i]);
                }
                MoreResults2 = SDR2.NextResult();
            } while (MoreResults2);
            SDR2.Close();
            cnn.Close();

            form.listHistory3.Items.Clear();
            cnn.Open();
            System.Text.StringBuilder results3 = new System.Text.StringBuilder();
            SqlCommand SC3 = new SqlCommand();
            SC.Connection = cnn;
            SC.CommandType = CommandType.Text;
            SC.CommandText = "SELECT TOP 10  Dohod.Usluga FROM dbo.Dohod WHERE Dohod.UsersID = '" + form.id + "' ORDER BY Dohod.Date2 DESC";
            SqlDataReader SDR3 = SC.ExecuteReader();
            bool MoreResults3 = false;
            do
            {
                while (SDR3.Read())
                {
                    for (int i = 0; i < SDR3.FieldCount; i = i + 1)
                        form.listHistory3.Items.Add(SDR3[i]);
                }
                MoreResults3 = SDR3.NextResult();
            } while (MoreResults3);
            SDR3.Close();
            cnn.Close();
        }

        public void Report (Form1 form)
        {
            cnn.Open();
            comand = cnn.CreateCommand();
            comand.CommandText = " SELECT SUM(Dohod.KolichestvoSredstv) AS SUMM FROM dbo.Dohod WHERE Dohod.Date2 >= DATEADD(MONTH, DATEDIFF(MONTH, 0, CURRENT_TIMESTAMP) - 1, 0) AND Dohod.Date2 < DATEADD(MONTH, DATEDIFF(MONTH, 0, CURRENT_TIMESTAMP), 0) AND Dohod.UsersID = '" + form.id + "' AND Dohod.Deistv LIKE '%Списание%' ";
            // comand.CommandText = "SELECT * FROM Dohod Where UsersID = '" + form.id + "' and Var_Scheta = ' 1 ' ";
            using (SqlDataReader reader = comand.ExecuteReader())
            {
                if (reader.Read())
                {
                    /*form.cartaMoney.Text = null;
                    form.cartaMoney.Text = reader["SUMMA"].ToString();*/
                    form.otcRashod.Text = reader["SUMM"].ToString();
                }
                else
                {
                    // MessageBox.Show("Error", "OK");
                }
            }
            cnn.Close();

            cnn.Open();
            comand = cnn.CreateCommand();
            comand.CommandText = " SELECT SUM(Dohod.KolichestvoSredstv) AS SUMM FROM dbo.Dohod WHERE Dohod.Date2 >= DATEADD(MONTH, DATEDIFF(MONTH, 0, CURRENT_TIMESTAMP) - 1, 0) AND Dohod.Date2 < DATEADD(MONTH, DATEDIFF(MONTH, 0, CURRENT_TIMESTAMP), 0) AND Dohod.UsersID = '" + form.id + "' AND Dohod.Deistv LIKE '%Пополнение%' ";
            // comand.CommandText = "SELECT * FROM Dohod Where UsersID = '" + form.id + "' and Var_Scheta = ' 1 ' ";
            using (SqlDataReader reader = comand.ExecuteReader())
            {
                if (reader.Read())
                {
                    /*form.cartaMoney.Text = null;
                    form.cartaMoney.Text = reader["SUMMA"].ToString();*/
                    form.otcDohod.Text = reader["SUMM"].ToString();
                }
                else
                {
                    // MessageBox.Show("Error", "OK");
                }
            }
            cnn.Close();
            cnn.Open();
            comand = cnn.CreateCommand();
            comand.CommandText = " SELECT SUM(Dohod.KolichestvoSredstv) AS SUMM FROM dbo.Dohod WHERE Dohod.Date2 >= DATEADD(MONTH, DATEDIFF(MONTH, 0, CURRENT_TIMESTAMP) - 1, 0) AND Dohod.Date2 < DATEADD(MONTH, DATEDIFF(MONTH, 0, CURRENT_TIMESTAMP), 0) AND Dohod.UsersID = '" + form.id + "' ";
            // comand.CommandText = "SELECT * FROM Dohod Where UsersID = '" + form.id + "' and Var_Scheta = ' 1 ' ";
            using (SqlDataReader reader = comand.ExecuteReader())
            {
                if (reader.Read())
                {
                    /*form.cartaMoney.Text = null;
                    form.cartaMoney.Text = reader["SUMMA"].ToString();*/
                    form.otcPribl.Text = reader["SUMM"].ToString();
                }
                else
                {
                    // MessageBox.Show("Error", "OK");
                }
            }
            cnn.Close();
        }

         


    }
#endregion
}
