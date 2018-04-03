using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Rashody
{
    class Vibor
    {
        Form1 form;
        public void ViborPopolnenie(Form1 form)
        {
           
            Autorizacia at = new Autorizacia();
            at.comand.Connection.Open();
            at.cnn.Open();
            at.comand = at.cnn.CreateCommand();
            at.comand.CommandText = "SELECT * FROM Dohod Where Users_ID = '" + at.id_users  + "' ";

             using (SqlDataReader reader = at.comand.ExecuteReader())
            {
                if (reader.Read())
                {
                      MessageBox.Show("успешно " , "OK");
                    
                }
                else
                {
                    MessageBox.Show("Error", "OK");
                }
            }
            at.cnn.Close();

        }

    }
}
