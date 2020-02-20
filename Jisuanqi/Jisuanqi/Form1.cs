using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jisuanqi
{
    public partial class Form1 : Form
    {
        private double num1;
        private double num2;
        private string opt;
        private bool yes1 = false;
        private bool yes2 = false;
        private bool yes3 = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            string inputnum1 = textBox1.Text;
            yes1 = Double.TryParse(inputnum1, out num1);
            if (!yes1)
            {
                textBox1.Clear();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            opt = comboBox.SelectedItem.ToString();
            if(opt!=" ")
            {
                yes3 = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string inputnum2 = textBox2.Text;
            yes2 = Double.TryParse(inputnum2, out num2);
            if (!yes2)
            {
                textBox2.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(yes1&&yes2&&yes3)
            {
               
                switch(opt)
                {
                    case "+":
                        label2.Text = (num1 + num2).ToString();
                        break;
                    case "-":
                        label2.Text = (num1 - num2).ToString();
                        break;
                    case "*":
                        label2.Text = (num1 * num2).ToString();
                        break;
                    case "/":
                        if(num2==0)
                        {
                            return;
                        }
                        label2.Text = (num1 / num2).ToString();
                        break;
                    default:
                        break;
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = " ";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
