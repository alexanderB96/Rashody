using Bunifu.Framework.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rashody
{
    public partial class Form1 : Form
    {
        public string tekst;
        public string ltekst;
        public string tkst;
        public string znach;
        public int id;
        public string znachLabel;

        public Form1()
        {
            InitializeComponent();

            // -home- подключение к серверу и авторизация
            Autorizacia at = new Autorizacia(this);
            at.Aut();
            //-end-

            //-home -вызов метода где происходят подсказки для кнопок
            Podskazki pd = new Podskazki();
            pd.Soobshenie(this);
            // -end-

            tabPage4.Parent = null;
            History.Parent = null;
            Grafik.Parent = null;

            HistoryLabel.Enabled = false;
            Home.Enabled = false;
            labelGrafik.Enabled = false;
        }

        private void Autoriz_Click(object sender, EventArgs e)
        {
            tabPage3.Parent = TabControl;
            tabPage4.Parent = null;
            History.Parent = null;
            Grafik.Parent = null;
            TabControl.SelectTab(tabPage3);
        }
       
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Autorizacia ai = new Autorizacia(this);
            ai.Ident();
            // отображение средств 
            Autorizacia vb = new Autorizacia();
            vb.Dannye(this);
            //



        }

        private void logOff_Click(object sender, EventArgs e)
        {
            // выход из учётной записи
            Application.Restart();
           
        }

        private void exitProg_Click(object sender, EventArgs e)
        {
            Application.Exit();  // закрытие программы        
        }

        private void cardButt_Click(object sender, EventArgs e)
        {
          
             
        }

         private void koshButt_Click(object sender, EventArgs e)
         {
           
         }

         private void bankButt_Click(object sender, EventArgs e)
         {
            // обработка события какая кнопка нажата, присвоение значения в переменную текст для использования в БД
            var bt = sender as BunifuTileButton;
            tekst =  bt.Tag.ToString();
                        

            if (tekst == "1")
            {
                viborSpis.Text = viborPopol.Text = "Карта";
                if (Convert.ToUInt32(cartTitLBt.LabelText) <= 0)
                          znachLabel = "0";
                

            }
            else if (tekst == "2")
            {
                viborSpis.Text = viborPopol.Text = "Кошелёк";
                if (Convert.ToUInt32(koshTitLBt.LabelText) <= 0)
                    znachLabel = "0";

            }

            else if (tekst == "3")
            {
                viborSpis.Text = viborPopol.Text = "Банковский счёт";
                if (Convert.ToUInt32(bankTitLBt.LabelText) <= 0)
                    znachLabel = "0";

            }

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Autorizacia vn = new Autorizacia();
            vn.Vnesenie(this);
            vn.Dannye(this);
            textPopolnenie.Text = "";
           
        }

        private void textPopolnenie_TextChanged(object sender, EventArgs e)
        {
          /*  if (textPopolnenie.Text.Length>0)
            {
                bunifuImageButton1.Enabled = false;
            }
            else
                bunifuImageButton1.Enabled = true;*/
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Autorizacia vn = new Autorizacia();
            vn.Spisanie(this);
            vn.Dannye(this);
            textSpisanie.Text = "";
        }

        private void bunifuCustomLabel8_Click(object sender, EventArgs e)
        {
            Autorizacia aut = new Autorizacia();
            History.Parent = TabControl;
            tabPage3.Parent = null;
            tabPage4.Parent = null;
            Grafik.Parent = null;
            TabControl.SelectTab(History);

            aut.History(this);
            
        }

        private void Home_Click(object sender, EventArgs e)
        {
            tabPage4.Parent = TabControl;
            tabPage3.Parent = null;
            History.Parent = null;
            Grafik.Parent = null;
            TabControl.SelectTab(tabPage4);
        }

        private void razvButton_Click(object sender, EventArgs e)
        {
            // обработка события какая кнопка нажата, присвоение значения в переменную текст для использования в БД
            var but = sender as BunifuImageButton;
            tkst = but.Tag.ToString();

            if (tkst == "Развлечения")
            {
                viborUslugi.Text = "Развлечения";

            }
            else if (tkst == "Услуги")
            {
                viborUslugi.Text = "Услуги";

            }

            else if (tkst == "Покупки")
            {
                viborUslugi.Text = "Покупки";

            }
            else if (tkst == "Продукты")
            {
                viborUslugi.Text = "Продукты";

            }
            else if (tkst == "Одежда")
            {
                viborUslugi.Text = "Одежда";

            }
            else if (tkst == "Транспорт")
            {
                viborUslugi.Text = "Транспорт";

            }
            else if (tkst == "Хозяйство")
            {
                viborUslugi.Text = "Хозяйство";

            }
        }

        private void labelGrafik_Click(object sender, EventArgs e)
        {
            tabPage3.Parent = null;
            tabPage4.Parent = null;
            History.Parent = null;
            Grafik.Parent = TabControl;
            TabControl.SelectTab(Grafik);
        }

        private void ZaReg_Click(object sender, EventArgs e)
        {
            Reg okn = new Reg();
            okn.ShowDialog();
            // хей
        }
    }
}
