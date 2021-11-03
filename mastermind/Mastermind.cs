using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

    /*
    * Mastermind The Game:
    * 
    * Gemaakt door Tijn van Horik
    * Student Fontys Eindhoven
    */

namespace mastermind
{
    
    public partial class Mastermind : Form
    {
        private int colorIndex = 0;
        public int MaximaalActiveRows = Beginscherm.totaalrijen - 1;
        public bool CanSubmit = false;

        public Mastermind()
        {
            InitializeComponent();
            GenerateComputerColors();          
            
            label1.Text = "Aantal rijen: " + Beginscherm.totaalrijen;
            int aantalknopen = Beginscherm.totaalrijen * 4;
            
            int endposition = 10;
            int endpositioncheck = 1;
            int eindpositiepanel = 70 * Beginscherm.totaalrijen + 3;
            int nieuwetopmargin = 2;
            int aantalbuttons = 0;
            int aantalloopsmargin = 0;
            

            flowLayoutPanel1.Height = eindpositiepanel;
            flowLayoutPanel2.Height = eindpositiepanel - 20;
            button1.Location = new Point(357, eindpositiepanel);
            RaadBtn.Location = new Point(357, eindpositiepanel - 50);
            for (int i = aantalknopen - 1; i > -1; i--)
            {
                Button nieuweknop = AddColorButton(i, 100, endposition);
                flowLayoutPanel1.Controls.Add(nieuweknop);
                nieuweknop.Click += new System.EventHandler(this.Buttonclicked);
                endposition += 70;            
            }
            
            for (int i = aantalknopen - 1; i > -1; i--)
            {
                Button nieuwecheckknop = AddCheckButton(i, 100, endpositioncheck, nieuwetopmargin);
    
                flowLayoutPanel2.Controls.Add(nieuwecheckknop);
                if (aantalloopsmargin == 2)
                {
                    aantalloopsmargin = 0;
                    nieuwetopmargin = 2;
                }

                nieuwecheckknop.Location = new Point(100, endpositioncheck);
                aantalbuttons++;
                if (aantalbuttons % 4 == 0)
                {
                    nieuwetopmargin = 20;
                }
                if (nieuwetopmargin == 20)
                {
                    aantalloopsmargin += 1;
                }

            }
            ActivRow = 0;
            mastermindgeladen = true;         
        }
        void Buttonclicked(object sender, EventArgs e)
        {
            Button currentbutton = (Button)sender;
            var colors = new List<Color> { Color.Red, Color.Green, Color.Orange, Color.Yellow, Color.White, Color.Black };
            currentbutton.BackColor = colors[colorIndex];

            colorIndex++;
            if (colorIndex == 6)
            {
                colorIndex = 0;
            }

        }
        public Button[] ButtonsInRow(int row)
        {
            Button[] buttons = new Button[4];
            
            for (int i = 0; i < 4; i++)
            {
                int buttonindex = 4 * row + i;
                buttons[i] = (Button)flowLayoutPanel1.Controls["butn" + buttonindex];
                
            }
            return buttons;
        }
        private int _ActivRow = 0;
        public int ActivRow 
        {
            get => _ActivRow;
            set
            {
                
                DisableRow(_ActivRow);
                _ActivRow = value;
                EnableRow(_ActivRow);
            }
        }
        public void EnableRow(int row)
        {
            Button[] ButtonsInTheRow = ButtonsInRow(row);
            foreach (Button button in ButtonsInTheRow)
            {
                if (ActivRow < Beginscherm.totaalrijen)
                {
                    button.Enabled = true;
                }
                
            }   
        }
        public void DisableRow(int row)
        {
            Button[] ButtonsInTheRow = ButtonsInRow(row);
            foreach (Button button in ButtonsInTheRow)
            {
                if (ActivRow < Beginscherm.totaalrijen)
                {
                    button.Enabled = false;
                }
                
            }
        }
        public void CheckSubmit(int row)
        {
            Button[] ButtonsInTheRow = ButtonsInRow(row);
            foreach (Button button in ButtonsInTheRow)
            {
                
                if (button.BackColor == Color.Gray)
                {                  
                    CanSubmit = false;                  
                }
                else
                {
                    CanSubmit = true;
                }


            }
        }
        public void CheckColorsInRow(int row)
        {
            Button[] ButtonsInTheRow = ButtonsInRow(row);
            foreach (Button button in ButtonsInTheRow)
            {


            }
        }


        private static void GenerateComputerColors()
        {
            var colors = new List<Color> { Color.Red, Color.Green, Color.Orange, Color.Yellow, Color.White, Color.Black };
            Color[] chosenColorsComputer = new Color[4];
            Random rnd = new Random();

            for (int i = 0; i < 4; i++)
            {
                int randomNumber = rnd.Next(0, colors.Count);
                chosenColorsComputer[i] = colors[randomNumber];

                Console.WriteLine(chosenColorsComputer[i]);
            }
        }
        private void RaadBtn_Click(object sender, EventArgs e)
        {

            CheckSubmit(_ActivRow);
            if (CanSubmit == true)
            {
                ActivRow++;
                CanSubmit = false;
            }
            if (ActivRow > MaximaalActiveRows)
            {
                ActivRow = 0;
                MessageBox.Show("Verlorenn!");
                var tijd = Task.Delay(1000);
                tijd.Wait();
                Beginscherm beginscherm = new Beginscherm();
                beginscherm.Show();
                this.Hide();
            }
        }

        private void Mastermind_Load(object sender, EventArgs e)
        {
            
        }
        private Button AddColorButton(int i, int start, int end)
        {
            Button newbutton = new Button();
            newbutton.Name = "butn" + i.ToString();
            newbutton.Text = i.ToString();
            newbutton.ForeColor = Color.Aqua;
            newbutton.BackColor = Color.Gray;
            newbutton.Width = 60;
            newbutton.Height = 60;
            newbutton.Location = new Point(start, end);
            newbutton.TextAlign = ContentAlignment.MiddleCenter;
            newbutton.Margin = new Padding(5);
            newbutton.Enabled = false;
            return newbutton;
        }
        private Button AddCheckButton(int i, int startcheck, int endcheck, int newtopmargin)
        {
            Button newcheckbutton = new Button();
            newcheckbutton.Name = "checkbutn" + i.ToString();
            newcheckbutton.Text = i.ToString();
            newcheckbutton.ForeColor = Color.Aqua;
            newcheckbutton.BackColor = Color.Gray;
            newcheckbutton.Width = 22;
            newcheckbutton.Height = 22;
            newcheckbutton.Location = new Point(startcheck, endcheck);
            newcheckbutton.TextAlign = ContentAlignment.MiddleCenter;
            newcheckbutton.Margin = new Padding(2, newtopmargin, 2, 2);
            newcheckbutton.Enabled = false;
            return newcheckbutton;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var tijd = Task.Delay(1000);
            tijd.Wait();
            Beginscherm beginscherm = new Beginscherm();
            beginscherm.Show();

            this.Hide();
        }


        
    }
}
