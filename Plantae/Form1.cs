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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Itens iniciais
        int energia = 0;
        int frutos = 0;
        bool morto;
        bool pause = false;
        bool compensacao = false;
        double dinheiro = 5.00;
        int lost_energia = 10; //energia perdida a cada segundo
        Planta planta = new Planta(100);
        private void button1_Click(object sender, EventArgs e) //Gerar Energia
        {
            if (trackBar1.Value >= 1 && trackBar2.Value >= 1)
            {
                energia = energia + (trackBar1.Value + trackBar2.Value);
                energy.Text = Convert.ToString(energia);
                planta.setEnergia(energia);
                if (energia >= 100)
                {
                    energia = 100;
                    progressBar1.Value = 100;
                    energy.Text = Convert.ToString(100);
                }
                else
                {
                    progressBar1.Value = energia;
                }                
            }else
            {
                error.Text = "Recursos insulficientes para gerar energia...";
            }

            if (energia <= 100 && energia >= 51)
            {
                normal.Visible = true;
                medium.Visible = false;
                advanced.Visible = false;
                die.Visible = false;
            }
            else
            {
                if (energia <= 50 && energia >= 26)
                {
                    normal.Visible = false;
                    medium.Visible = true;
                    advanced.Visible = false;
                    die.Visible = false;
                }
                else
                {
                    if (energia <= 25 && energia >= 2)
                    {
                        advanced.Visible = true;
                        medium.Visible = false;
                        normal.Visible = false;
                        die.Visible = false;
                    }
                    else
                    {
                        if (energia <= 1)
                        {
                            morto = true;
                            die.Visible = true;
                            advanced.Visible = false;
                            medium.Visible = false;
                            normal.Visible = false;
                        }
                    }
                }
            }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBar2.Value == 5 && trackBar1.Value == 5)
            {
                lost_energia = 0;
                estado.Text = "Compensação";
                compensacao = true;
            }
            else
            {
                if (trackBar1.Value <= 4 && trackBar2.Value <= 4)
                {
                    estado.Text = "Consumo";
                    compensacao = false;
                }
                else
                {
                    if (trackBar1.Value >= 6 && trackBar2.Value >=6) {
                        estado.Text = "Armazenando";
                        compensacao = false;
                    }
                }
                lost_energia = 10;
            }
            water.Text = Convert.ToString(trackBar1.Value);
        }//Agua
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (trackBar2.Value == 5 && trackBar1.Value == 5)
            {
                lost_energia = 0;
                estado.Text = "Compensação";
                compensacao = true;
            }
            else
            {
                if (trackBar1.Value <= 4 && trackBar2.Value <= 4) {
                    estado.Text = "Consumo";
                    compensacao = false;
                }
                else
                {
                    if (trackBar1.Value >= 6 && trackBar2.Value >= 6)
                    {
                        estado.Text = "Armazenando";
                        compensacao = false;
                    }
                }
                    lost_energia = 10;
            }
            light.Text = Convert.ToString(trackBar2.Value);
        }//Luz
        private void timer1_Tick(object sender, EventArgs e)
        {
            energia = energia - lost_energia;

            if (trackBar2.Value == 5 && trackBar1.Value == 5)
            {
                lost_energia = 0;
            }             
            if (morto == true)
            {
                reiniciar.Visible = true;
                reiniciar.Enabled = true;
            }else
            {
                reiniciar.Visible = false;
                reiniciar.Enabled = false;
            }
            if (energia >= 100) //Progress Bar
            {
                progressBar1.Value = 100;
                energy.Text = Convert.ToString(100);
            }
            else
            {
                if (energia <= 1)
                {
                    energia = 0;
                    progressBar1.Value = 0;
                }else
                {
                    progressBar1.Value = energia;
                }                
            }
            energy.Text = Convert.ToString(energia);
            if (energia <= 100 && energia >= 51){//Imagens planta
                normal.Visible = true;
                medium.Visible = false;
                advanced.Visible = false;
                die.Visible = false;
            }
            else
            {
                if (energia <= 50 && energia >= 26)
                {
                    normal.Visible = false;
                    medium.Visible = true;
                    advanced.Visible = false;
                    die.Visible = false;
                    
                }else
                {
                    if (energia <= 25 && energia>= 2)
                    {
                        advanced.Visible = true;
                        medium.Visible = false;
                        normal.Visible = false;
                        die.Visible = false;
                    }else
                    {
                        if(energia <= 1)
                        {
                            die.Visible = true;
                            advanced.Visible = false;
                            medium.Visible = false;
                            normal.Visible = false;
                            if (energia == 0)
                            {

                                morto = true;
                                planta.setEnergia(0);
                                button1.Enabled = false;
                                trackBar1.Enabled = false;
                                trackBar2.Enabled = false;
                                lose.Text = "Você perdeu";
                            }
                        }
                    }
                }
            }        
        } //funções planta
        private void Form1_Load(object sender, EventArgs e)
        {
            energia = Convert.ToInt16(planta.getEnergia());
            energy.Text = Convert.ToString(energia);
            money.Text = Convert.ToString(string.Format("{0:N}", dinheiro));
        } //Atualiza informações quando carrega
        private void timer_frutos_Tick(object sender, EventArgs e)
        {
            if (energia >= 30 && energia <= 80) {
               if (pause == false && compensacao == false)
                {
                    frutos = frutos + 1;
                    fruits.Text = Convert.ToString(frutos);
                }
            }
        } //Acrescenta os frutos 2Segundos
        private void button2_Click(object sender, EventArgs e)
        {
            if (frutos >= 1)
            {
                frutos = frutos - 1;
                fruits.Text = Convert.ToString(frutos);
                dinheiro = dinheiro + 3.40;
                planta.setDinheiro(dinheiro);
                money.Text = Convert.ToString(string.Format("{0:N}", dinheiro));
                error.Text = " ";

            }else
            {
                error.Text = "Frutos insulficientes para vender";
            }
        }//Vender frutos
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                lost_energia = 0;
                button1.Enabled = false;
                button2.Enabled = false;
                pause = true;
                Manual manual = new Manual();
                manual.ShowDialog();
            }
            finally
            {
                if (morto == true)
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                    pause = true;
                }
                else
                {
                    button1.Enabled = true;
                    button2.Enabled = true;
                    pause = false;
                    lost_energia = 10;
                }
                
            }
            
            light.Text = Convert.ToString(1);                
        } //Informações Manual
        private void reiniciar_Click(object sender, EventArgs e)
        {
            morto = false;
            lost_energia = 10;
            energia = 100;
            frutos = 0;
            fruits.Text = Convert.ToString(frutos);
            planta.setDinheiro(5);
            dinheiro = 5;
            button1.Enabled = true;
            trackBar1.Enabled = true;
            trackBar2.Enabled = true;
            reiniciar.Enabled = false;
            reiniciar.Visible = false;
            trackBar1.Value = 0;
            trackBar2.Value = 0;
            lose.Text = " ";
        } //Restart Game
        private void button4_Click(object sender, EventArgs e)
        {
            if(dinheiro >= 100)
            {
                if (energia < 100)
                {
                    dinheiro = dinheiro - 100;
                    planta.setDinheiro(dinheiro);
                    energia = 100;
                    planta.setEnergia(energia);
                    energy.Text = Convert.ToString(energia);
                    progressBar1.Value = 100;
                    money.Text = Convert.ToString(string.Format("{0:N}", dinheiro));
                }
            }
            else
            {
                error.Text = "Dinheiro insulficiente para comprar";
            }
        } //Comprar 100 energia
        private void button6_Click(object sender, EventArgs e)
        {
           // lost_energia = 0;
           // dinheiro = 200;
            //money.Text = Convert.ToString(string.Format("{0:N}", dinheiro));

        } //Hack Test
        private void button7_Click(object sender, EventArgs e)
        {
           // lost_energia = 10;
           // money.Text = Convert.ToString(string.Format("{0:N}", dinheiro));
        } //Hack Test
        private void button5_Click(object sender, EventArgs e)
        {
            if (dinheiro >= 35)
            {
                dinheiro = dinheiro - 35;
                money.Text = Convert.ToString(string.Format("{0:N}", dinheiro));
                frutos = frutos + 10;
                fruits.Text = Convert.ToString(frutos);
            }else
            {
                error.Text = "Dinheiro insulficiente para comprar";
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        } //Comprar 10 frutas
    }
}
