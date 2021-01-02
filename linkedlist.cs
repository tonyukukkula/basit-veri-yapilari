using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace veri_yapilari_2_Alperen_Kula_171180045
{
    public partial class Form1 : Form
    {
        public int def_ogr, def_ders;
        //public List_node head;
        public class List_node{
            public int ogrenci_no;
            public int ders_kod; // 456, 404, 502
            public int ders_not;
            public List_node ileri;
            //public List_node(int a, int b)
            //{
            //    ogrenci_no = a;
            //    ders_kod = b;
            //    //   ders_not = c;
            //}
            public List_node(int a, int b, int c){
                    ogrenci_no = a;
                    ders_kod = b;
                    ders_not = c;
            }
        }
        public class LinkedList{
            public List_node bas;
            public List_node son;
            public LinkedList(){
                bas = new List_node(0, 0, 0);
                son = new List_node(0, 0, 0);
                bas.ileri = son;
                son.ileri = son;
            }
        }

        public LinkedList ll=new LinkedList();
        public List_node a = new List_node(0001, 404, 80);
        public List_node b = new List_node(0002, 404, 80);
        public List_node c = new List_node(0003, 404, 80);
        public List_node d = new List_node(0004, 404, 80);
        public List_node e = new List_node(0005, 404, 80);
        public List_node f = new List_node(0003, 502, 80);
        public List_node g = new List_node(0001, 456, 80);

        //public void ders_ekle(int a, int b, int c){
        //    List_node aktif= ll.bas;
        //    List_node yeni_node = new List_node(a, b, c);
        //    yeni_node.ileri = aktif.ileri;
        //    aktif.ileri = yeni_node;
        //}
        //public void derse_ekle(int a, int b)
        //{
        //    List_node aktif = ll.bas;
        //    List_node yeni_node = new List_node(a, def_ders, b);
        //    yeni_node.ileri = aktif.ileri;
        //    aktif.ileri = yeni_node;
        //}

        public void ders_ekle(int a, int b, int c)
        {
            List_node yeni_node = new List_node(a, b, c);
            List_node aktif = ll.bas;
            while ((aktif.ileri != ll.son) && (string.Compare(Convert.ToString(aktif.ileri.ogrenci_no),Convert.ToString(yeni_node.ogrenci_no)) < 0))
                aktif = aktif.ileri;
            yeni_node.ileri = aktif.ileri;
            aktif.ileri =yeni_node;
        }
        public void derse_ekle(int a, int b)
        {
            List_node aktif = ll.bas;
            List_node yeni_node = new List_node(a, def_ders, b);
            while ((aktif.ileri != ll.son) && (string.Compare(Convert.ToString(aktif.ileri.ogrenci_no), Convert.ToString(yeni_node.ogrenci_no)) < 0))
                aktif = aktif.ileri;
            yeni_node.ileri = aktif.ileri;
            aktif.ileri = yeni_node;
        }

        public void sirala(){

        }
            public void silme(){
                List_node aktif = ll.bas;
                while (aktif.ileri != ll.son && (aktif.ileri.ogrenci_no != Convert.ToInt32(textBox7.Text)) && aktif.ileri.ders_kod != Convert.ToInt32(textBox6.Text))
                {
                    aktif= aktif.ileri;
                }
                aktif.ileri = aktif.ileri.ileri;
                yenile(Öğrenciler);
            }
         
        //static List_node deleteNode(List_node start, int k)
        //{
        //    if (k < 1)
        //        return start;
        //    if (start == null)
        //        return null;
        //    if (k == 1)
        //    {
        //        List_node res = start.ileri;
        //        return res;
        //    }

        //    start.ileri = deleteNode(start.ileri, k - 1);
        //    return start;
        //}
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //başlangıç için verdim bir kaç tane :)
            ll.bas.ileri  = a;
            a.ileri = b;
            b.ileri = c;
            c.ileri = d;
            d.ileri = f;
            f.ileri = g;
            g.ileri = ll.son;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int c = Convert.ToInt32(textBox1.Text);
            int a = Convert.ToInt32(textBox5.Text);
            int b = Convert.ToInt32(textBox4.Text);
            ders_ekle(a,b,c);
            yenile(Öğrenciler);

        }

        private void Öğrenciler_SelectedIndexChanged(object sender, EventArgs e)
        {
            def_ogr = Convert.ToInt32(Öğrenciler.SelectedItem.ToString());
        }
        public void yenile(ListBox lb){
            Öğrenciler.Items.Clear();
            string curItem = dersler.SelectedItem.ToString();
            List_node aktif = ll.bas;
            if (curItem == "Veri Yapıları // 456")
            {
                def_ders = 456;
                while ((aktif != ll.son))
                {
                    if (aktif.ders_kod == 456)
                    {
                        Öğrenciler.Items.Add(aktif.ogrenci_no.ToString());
                        aktif = aktif.ileri;
                    }
                    else
                    {
                        aktif = aktif.ileri;
                    }
                }
            }
            else if (curItem == "OOP // 404")
            {
                def_ders = 404;
                while ((aktif != ll.son))
                {
                    if (aktif.ders_kod == 404)
                    {
                        Öğrenciler.Items.Add(aktif.ogrenci_no.ToString());
                        aktif = aktif.ileri;
                    }
                    else
                    {
                        aktif = aktif.ileri;
                    }
                }
            }
            else if (curItem == "Türk Dili // 502")
            {
                def_ders = 502;
                while ((aktif != ll.son))
                {
                    if (aktif.ders_kod == 502)
                    {
                        Öğrenciler.Items.Add(aktif.ogrenci_no.ToString());
                        aktif = aktif.ileri;
                    }
                    else
                    {
                        aktif = aktif.ileri;
                    }
                }
            }
            int x = lb.Items.Count;
            string[] arr = new string[x];
            //lb.Items.CopyTo(arr, 0);
            arr = lb.Items.OfType<string>().ToArray();
            var arr2 = arr.Distinct();
            lb.Items.Clear();
            foreach (string s in arr2)
            {
                lb.Items.Add(s);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(textBox2.Text);
            int b = Convert.ToInt32(textBox3.Text);
            derse_ekle(a, b);
            yenile(Öğrenciler);
        }

        private void Dersler_MouseClick(object sender, MouseEventArgs e)
        {
            Öğrenciler.Items.Clear();
            string curItem = dersler.SelectedItem.ToString();
            List_node aktif = ll.bas;
            if (curItem == "Veri Yapıları // 456")
            {
                def_ders = 456;
                while ((aktif != ll.son))
                {
                    if (aktif.ders_kod == 456)
                    {
                        Öğrenciler.Items.Add(aktif.ogrenci_no.ToString());
                        aktif = aktif.ileri;
                    }
                    else
                    {
                        aktif = aktif.ileri;
                    }
                }
            }
            else if (curItem == "OOP // 404")
            {
                def_ders = 404;
                while ((aktif != ll.son))
                {
                    if (aktif.ders_kod == 404)
                    {
                        Öğrenciler.Items.Add(aktif.ogrenci_no.ToString());
                        aktif = aktif.ileri;
                    }
                    else
                    {
                        aktif = aktif.ileri;
                    }
                }
            }
            else if (curItem == "Türk Dili // 502")
            {
                def_ders = 502;
                while ((aktif != ll.son))
                {
                    if (aktif.ders_kod == 502)
                    {
                        Öğrenciler.Items.Add(aktif.ogrenci_no.ToString());
                        aktif = aktif.ileri;
                    }
                    else
                    {
                        aktif = aktif.ileri;
                    }
                }
            }
            yenile(Öğrenciler);
        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //silme();
            List_node aktif = ll.bas;
            while (aktif.ileri != ll.son)
            {
                if (aktif.ileri.ogrenci_no == Convert.ToInt32(textBox9.Text) && aktif.ileri.ders_kod == Convert.ToInt32(textBox8.Text))
                { aktif.ileri = aktif.ileri.ileri; }
                else { aktif = aktif.ileri; }
            }
            yenile(Öğrenciler);
           //yenile(Öğrenciler);

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            //silme();
            List_node aktif = ll.bas;
            while (aktif.ileri != ll.son)
            {
                if (aktif.ileri.ogrenci_no == Convert.ToInt32(textBox9.Text) && aktif.ileri.ders_kod == Convert.ToInt32(textBox8.Text))
                { aktif.ileri = aktif.ileri.ileri; }
                else { aktif = aktif.ileri; }
            }
            yenile(Öğrenciler);
            //yenile(Öğrenciler);
        }

        private void Button5_Click(object sender, EventArgs e)
        {

        }

        private void Dersler_SelectedIndexChanged(object sender, EventArgs e)
        {         
        }
    }
}
