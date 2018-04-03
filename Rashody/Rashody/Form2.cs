using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace Rashody
{
    public partial class Reg : Form
    {
        public Reg()
        {
            InitializeComponent();

            //Form1 form;
        }

        private void SozdatAcc_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            Autorizacia naut = new Autorizacia();
            
            naut.cnn.Open();
            naut.comand = naut.cnn.CreateCommand();
            naut.comand.CommandText = "INSERT INTO Users (Login, Password)  VALUES(@Login, @Password)";
            naut.comand.Parameters.AddWithValue("@Login", Convert.ToString(textLogAcc.Text));
            naut.comand.Parameters.AddWithValue("@Password", Convert.ToString(textPassAcc.Text));
            naut.comand.ExecuteNonQuery();
            naut.cnn.Close();
            this.Hide();
        }
    }
}
