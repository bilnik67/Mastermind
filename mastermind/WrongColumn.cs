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
    public partial class Onjuist_kolom : Form
    {
        public Onjuist_kolom()
        {
            InitializeComponent();


        }

        private void Onjuist_kolom_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Tijd = Task.Delay(1000);
            Tijd.Wait();
            BeginScreen beginscherm = new BeginScreen();
            beginscherm.Show();
            this.Hide();
        }
    }
}
