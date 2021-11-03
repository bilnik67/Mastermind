using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mastermind
{
    public partial class Beginscherm : Form
    {
       
       
        public Beginscherm()
        {
            InitializeComponent();
        }
         
        private void Form1_Load(object sender, EventArgs e)
        {
            
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
              
              
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        public static int totaalrijen;
        public static string aantalrijen;
        public static string aantalkolommen;
        public static int totaalkolommen;
        private void button1_Click(object sender, EventArgs e)
        {
            string aantalrijen = textBox1.Text;
            string aantalkolommen = textBox2.Text;

            var tijd = Task.Delay(1000);
            tijd.Wait();
            if (int.TryParse(aantalkolommen, out totaalkolommen))
            {
                if (totaalkolommen < 7 && totaalkolommen > 3)
                {
                    Mastermind mastermind = new Mastermind();
                    mastermind.Show();

                }
                else
                {
                    Onjuist_kolom onjuist_Kolom = new Onjuist_kolom();
                    onjuist_Kolom.Show();
                    this.Hide();
                }
            }
            if (int.TryParse(aantalrijen, out totaalrijen))
            {
                if (totaalrijen < 12 && totaalrijen > 5)
                {
                    Mastermind mastermind = new Mastermind();
                    mastermind.Show();
                }
                else
                {
                    Onjuiste_integer onjuiste_Integer = new Onjuiste_integer();
                    onjuiste_Integer.Show();
                }
            }
            else
            {
                Onjuiste_integer onjuiste_Integer = new Onjuiste_integer();
                onjuiste_Integer.Show();
            }
            this.Hide();   
        }
    }
}
