using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Plantae
{
    public partial class questions : Form
    {
        public questions()
        {
            InitializeComponent();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
            {
                resposta2.Text = "Correto";
                button4.Visible = false;
                button3.Visible = true;
            }
            else
            {
                resposta2.Text = "Incorreto";
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                resposta.Text = "Correto";
                button2.Visible = true;
                button1.Visible = false;
            }
            else
            {
                resposta.Text = "Incorreto";
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel5.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            panel6.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (radioButton14.Checked == true)
            {
                resposta3.Text = "Correto";
                button5.Visible = true;
                button6.Visible = false;
            }
            else {
                resposta3.Text = "Incorreto";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
            panel8.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (radioButton18.Checked)
            {
                resposta4.Text = "Correto";
                button7.Visible = true;
                button8.Visible = false;
            }
            else
            {
                resposta4.Text = "Incorreto";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (radioButton22.Checked)
            {
                resposta5.Text = "Correto";
                button9.Visible = true;
                button10.Visible = false;
            }
            else
            {
                resposta5.Text = "Incorreto";
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            panel8.Visible = false;
            panel10.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel12.Visible = true;
            panel10.Visible = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
