using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_MuazzamHamburger
{
    public static class Fonksiyon
    {
        public static void Temizle(Control.ControlCollection koleksiyon)
        {
            foreach (Control item in koleksiyon)
            {
                if(item is TextBox)
                {
                    TextBox txt = (TextBox)item;                   
                    txt.Clear();
                }
                else if(item is CheckBox)
                {
                    CheckBox chk = (CheckBox)item;
                    chk.Checked = false;
                }
                else if(item is RadioButton)
                {
                    RadioButton rd = (RadioButton)item;
                    rd.Checked = false;
                }
                else if(item is NumericUpDown)
                {
                    ((NumericUpDown)item).Value = 1;
                }
                else if(item is ComboBox)
                {
                    ((ComboBox)item).SelectedIndex = 0;
                }
                else if (item is FlowLayoutPanel)
                {
                    foreach (CheckBox chk in item.Controls)
                    {
                        chk.Checked = false;
                    }
                }
                //else if(item is ListBox)
                //{
                //    ((ListBox)item).Items.Clear();
                //}


            }
        }
    }
}
