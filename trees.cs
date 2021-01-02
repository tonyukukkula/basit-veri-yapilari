using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace veri_yapilari_7_Alperen_Kula_171180045
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add(rootNode.sayi);
            bstNodeC yeni = new bstNodeC(15, null, null);
            rootNode.leftNode = yeni;
            yeni= new bstNodeC(35, null, null);
            rootNode.rightNode = yeni;
            if (rootNode.leftNode != null) listBox1.Items.Add(rootNode.leftNode.sayi);
            if (rootNode.rightNode != null) listBox1.Items.Add(rootNode.rightNode.sayi);
        }
        public void siralayiver(bstNodeC aktif)
        {
            listBox1.Items.Add(aktif.sayi);
            if (aktif.leftNode != null) siralayiver(aktif.leftNode);
            if (aktif.rightNode != null) siralayiver(aktif.rightNode);
        }
        public class bstNodeC
        {
            public int sayi;
            public bstNodeC leftNode, rightNode;
            public bstNodeC(int sayi, bstNodeC leftNode, bstNodeC rightNode)
            {
                this.sayi = sayi;
                this.leftNode = leftNode;
                this.rightNode = rightNode;
            }
        }
        bstNodeC rootNode = new bstNodeC(25, null, null);

        public void min_bul(bstNodeC node)
        {
            if (node.sayi == 0) lavel1.Text = Convert.ToString(node.sayi);
            else if (node.leftNode != null) min_bul(node.leftNode);
            else lavel1.Text = Convert.ToString(node.sayi);
        }
        public void max_bul(bstNodeC node)
        {
            if (node.sayi == 0) lavel2.Text = Convert.ToString(node.sayi);
            else if (node.rightNode != null) max_bul(node.rightNode);
            else lavel2.Text = Convert.ToString(node.sayi);
        }
        private void ekleyiver(int sayi, bstNodeC node)
        {
            bstNodeC yeniNode = new bstNodeC(sayi, null, null);
            if (node.sayi == 0 || node==null) node.sayi = sayi;
            else
            {
                bstNodeC current = node;
                bstNodeC parent;
                while (true)
                {
                    parent = current;
                    if (sayi < current.sayi)
                    {
                        current = current.leftNode;
                        if (current == null)
                        {
                            parent.leftNode = yeniNode;
                            break;
                        }
                    }
                    else
                    {
                        current = current.rightNode;
                        if (current == null)
                        {
                            parent.rightNode = yeniNode;
                            return;
                        }
                    }
                }
            }
        }
/// /////////////////////////////////////////////////////////////////////////////////////////////////
        public void deleteKey()
        {
            System.Console.WriteLine("Silinecek Değeri giriniz:");
            int anektar=Convert.ToInt32(System.Console.ReadLine());
            rootNode= deleteRec(rootNode, anektar);
        }
        public bstNodeC deleteRec(bstNodeC root, int key)
        {
            /* Base Case: If the tree is empty */
            if (root == null) return root;

            /* Otherwise, recur down the tree */
            if (key < root.sayi)
                root.leftNode = deleteRec(root.leftNode, key);
            else if (key > root.sayi)
                root.rightNode = deleteRec(root.rightNode, key);

            // if key is same as root's key, then This is the node  
            // to be deleted  
            else
            {
                // node with only one child or no child  
                if (root.leftNode == null)
                    return root.rightNode;
                else if (root.rightNode == null)
                    return root.leftNode;

                // node with two children: Get the 
                // inorder successor (smallest  
                // in the right subtree)  
                root.sayi = minValue(root.rightNode);

                // Delete the inorder successor  
                root.rightNode = deleteRec(root.rightNode, root.sayi);
            }
            return root;
        }

        public int minValue(bstNodeC root)
        {
            int minv = root.sayi;
            while (root.leftNode != null)
            {
                minv = root.leftNode.sayi;
                root = root.leftNode;
            }
            return minv;
        }

        // This method mainly calls insertRec()  
        public void insert(int key)
        {
            rootNode = insertRec(rootNode, key);
        }

        /* A recursive function to insert a new key in BST */
        public bstNodeC insertRec(bstNodeC root, int key)
        {

            /* If the tree is empty, return a new node */
            if (root == null)
            {
                root = new bstNodeC(key, null, null);
                return root;
            }

            /* Otherwise, recur down the tree */
            if (key < root.sayi)
                root.leftNode = insertRec(root.leftNode, key);
            else if (key > root.sayi)
                root.rightNode= insertRec(root.rightNode, key);

            /* return the (unchanged) node pointer */
            return root;
        }


        /// //////////////////////////////////////////////////////////////////////////////////////////

        public void agacSil(int anektar)
        {
            deleteKey(anektar);
        }
       
        private void Button1_Click(object sender, EventArgs e)
        {
            min_bul(rootNode);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            max_bul(rootNode);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            ekleyiver(Convert.ToInt32(textBox1.Text), rootNode);
            siralayiver(rootNode);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            agacSil(Convert.ToInt32(textBox2.Text));
            listBox1.Items.Clear();
            siralayiver(rootNode);
        }
    }
}