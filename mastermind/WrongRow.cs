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
    public partial class Onjuiste_integer : Form
    {
        public Onjuiste_integer()
        {
            InitializeComponent();          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tijd = Task.Delay(1000);
            tijd.Wait();
            BeginScreen beginscherm = new BeginScreen();
            beginscherm.Show();
            this.Hide();
        }
    }
}
