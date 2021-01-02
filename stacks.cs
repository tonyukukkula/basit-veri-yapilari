using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tonyukukkula
{
    public partial class Form1 : Form
    {
        public stack kitaplik=new stack("");

        public class stacknode {
            public string kitap_ad;
            public stacknode sonraki;
            public stacknode(string kitap_ad) {
                this.kitap_ad = kitap_ad;
            }
        }
        public class stack {
            public stacknode bas;
            public stack(string kitap_ad) {
                this.bas = new stacknode(kitap_ad);
                this.bas.sonraki = bas;
            }
        }
        public int say(stack a) {
            int i=0;
            stacknode aktif =new stacknode("");
            aktif = a.bas;
            while (aktif.sonraki != aktif) {
                aktif = aktif.sonraki;
                i++;
            }
            return i;
        }
        public void ekle(stack a, string ka) {
            if (say(a) < numericUpDown1.Value)
            {
                stacknode yeni = new stacknode(ka);
                yeni.sonraki = kitaplik.bas;
                kitaplik.bas = yeni;
                label4.Text = "stack boyutu: " + Convert.ToSingle(say(kitaplik));
            }
            else{
                MessageBox.Show("limiti aşmayalım hocam");
            }
        }
        public void al(stack a){
            //if (say(a) != 0)
            //{
            //    a.bas = a.bas.sonraki;
            //    label4.Text = "stack boyutu: " + Convert.ToSingle(say(kitaplik));
            //}
            if (say(a) == 0)
            {
                MessageBox.Show("bişiy kalmamış, ayıp yauv");
            }else{
                a.bas = a.bas.sonraki;
                label4.Text = "stack boyutu: " + Convert.ToSingle(say(kitaplik));
            }
        }
        //public void en_fazlalama(int a) {
        //    en_fazla = a;
        //}
        public void yenile() {
            listBox1.Items.Clear();
            stacknode yenicik=new stacknode("");
            yenicik = kitaplik.bas;
            while (yenicik.sonraki != yenicik) {
                listBox1.Items.Add(yenicik.kitap_ad);
                yenicik = yenicik.sonraki;
            }
            textBox2.Text = kitaplik.bas.kitap_ad;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            al(kitaplik);
            yenile();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ekle(kitaplik, textBox1.Text);
            yenile();
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
