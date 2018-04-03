using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;





namespace Rashody
{
    class Podskazki
    {
        Form1 form;
        public void Soobshenie(Form1 form)
        {

            ToolTip b = new ToolTip();
            b.SetToolTip(form.cartTitLBt, "Выберите для пополнения или списания");
            b.SetToolTip(form.koshTitLBt, "Выберите для пополнения или списания");
            b.SetToolTip(form.bankTitLBt, "Выберите для пополнения или списания");

            b.SetToolTip(form.uslugButt, "Услуги");
            b.SetToolTip(form.razvButton, "Развлечения");
            b.SetToolTip(form.pokypButt, "Покупки");
            b.SetToolTip(form.productButt, "Продукты");
            b.SetToolTip(form.odezdaButt, "Одежда/Обувь");
            b.SetToolTip(form.transButt, "Транспорт");
            b.SetToolTip(form.hozButt, "Хозяйство");

        }

    }
}
