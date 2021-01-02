using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace veri_yapilari_4_Alperen_Kula_171180045
{
    public partial class Form1 : Form
    {
        public int islem_toplam_sure = 0;
        public class nod {
            public string isim;
            public int islem_sure;
            public nod ileri;
            public int anlik_islem_toplam_sure;
            public nod(string isim, int islem_sure) {
                this.isim = isim;
                this.islem_sure = islem_sure;
            }
        }
        public class llinked_list
        {
            public int size;
            public nod bas = new nod("bas", 0);
            public nod orta = new nod("orta", 0);
            public nod son = new nod("son", 0);
            public nod bitis = new nod("son", 0);
            public llinked_list()
            {
                bas.ileri = orta;
                orta.ileri = son;
                son.ileri = bitis;
                size = 0;
            }
        }
        public void ekle_havale(nod yeni) {
            nod aktif = liste.bas;
            while (aktif.ileri != liste.orta) {
                aktif = aktif.ileri;
            }
            aktif.ileri = yeni;
            yeni.ileri = liste.orta;
            liste.size++;
            islem_toplam_sure += yeni.islem_sure;
            yeni.anlik_islem_toplam_sure = islem_toplam_sure;
            yenile();
        }
        public void ekle_para_yatirma(nod yeni)
        {
            nod aktif = liste.orta;
            while (aktif.ileri != liste.son)
            {
                aktif = aktif.ileri;
            }
            aktif.ileri = yeni;
            yeni.ileri = liste.son;
            liste.size++;
            islem_toplam_sure += yeni.islem_sure;
            yeni.anlik_islem_toplam_sure = islem_toplam_sure;
            yenile();
        }
        public void ekle_para_cekme(nod yeni)
        {
            nod aktif=liste.son;
            while (aktif.ileri != liste.bitis) {
                aktif = aktif.ileri;
            }
            yeni.ileri = aktif.ileri;
            aktif.ileri = yeni;
            liste.size++;
            islem_toplam_sure += yeni.islem_sure;
            yeni.anlik_islem_toplam_sure = islem_toplam_sure;
            yenile();

        }
        public llinked_list liste = new llinked_list();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void yenile() {
            listBox1.Items.Clear();
            nod yenicik;
            yenicik = liste.bas;
            while (yenicik != liste.orta)
            {
                if (yenicik.isim != "bas")
                {
                    listBox1.Items.Add(yenicik.isim +"  "+ Convert.ToString(yenicik.anlik_islem_toplam_sure)+"dk");
                    yenicik = yenicik.ileri;
                }
                else
                {
                    yenicik = yenicik.ileri;
                }
            }
            listBox2.Items.Clear();
            yenicik = liste.orta;
            while (yenicik != liste.son)
            {
                if (yenicik.isim != "orta")
                {
                    listBox2.Items.Add(yenicik.isim + "  " + Convert.ToString(yenicik.anlik_islem_toplam_sure) + "dk");
                    yenicik = yenicik.ileri;
                }
                else
                {
                    yenicik = yenicik.ileri;
                }
            }
            listBox3.Items.Clear();
            yenicik = liste.son;
            while (yenicik != liste.bitis)
            {
                if (yenicik.isim != "son")
                {
                    listBox3.Items.Add(yenicik.isim + "  " + Convert.ToString(yenicik.anlik_islem_toplam_sure) + "dk");
                    yenicik = yenicik.ileri;
                }
                else
                {
                    yenicik = yenicik.ileri;
                }
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            nod yeni = new nod(textBox1.Text, 3);
            ekle_havale(yeni);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            nod yeni = new nod(textBox2.Text, 2);
            ekle_para_yatirma(yeni);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            nod yeni = new nod(textBox3.Text, 1);
            ekle_para_cekme(yeni);
        }
        //public void azalt(int a)
        //{
        //    nod ilk = liste.bas;
        //    while (ilk != liste.bitis) {
        //        ilk.anlik_islem_toplam_sure -= a;
        //        ilk = ilk.ileri;
        //    }
        //    islem_toplam_sure -= a;
        //}
        private void Button4_Click(object sender, EventArgs e)
        {
            if (liste.bas.ileri != liste.orta)
            {
                //nod yenicik = liste.bas;
                //while (yenicik.ileri != liste.bitis) {
                //    if (yenicik == liste.bas)
                //    {
                //        yenicik = yenicik.ileri;
                //    }else{
                //        yenicik.anlik_islem_toplam_sure -= 3;
                //        yenicik = yenicik.ileri;
                //    }
                //}
                ////azalt(3);
                nod aktif = liste.bas;
                aktif.ileri = aktif.ileri.ileri;
            }
            else if (liste.orta.ileri != liste.son)
            {
                //nod yenicik = liste.orta;
                //while (yenicik.ileri != liste.bitis)
                //{
                //    if (yenicik == liste.orta)
                //    {
                //        yenicik = yenicik.ileri;
                //    }
                //    else
                //    {
                //        yenicik.anlik_islem_toplam_sure -= 2;
                //        yenicik = yenicik.ileri;
                //    }
                //}
                ////azalt(2);
                nod aktif = liste.orta;
                aktif.ileri = aktif.ileri.ileri;
            }
            else if (liste.son.ileri != liste.bitis)
            {
                //nod yenicik = liste.son;
                //while (yenicik.ileri != liste.bitis)
                //{
                //    if (yenicik == liste.son)
                //    {
                //        yenicik = yenicik.ileri;
                //    }
                //    else
                //    {
                //        yenicik.anlik_islem_toplam_sure -= 1;
                //        yenicik = yenicik.ileri;
                //    }
                //}
                ////azalt(1);
                nod aktif = liste.son;
                aktif.ileri = aktif.ileri.ileri;
            }
            //nod aktif = liste.bas.ileri;
            //if (aktif != liste.orta || aktif != liste.son) {
            //    aktif.ileri = aktif.ileri.ileri;
            //} else {
            //    if (aktif == liste.orta) {aktif = liste.orta.ileri; }
            //    else if (aktif == liste.son) { aktif = liste.son.ileri; }
            //}
            yenile();
        }
    }
}
