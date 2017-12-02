using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plantae
{
    class Planta
    {
        private double energia;
        private double luz;
        private double agua;
        private double dinheiro; //Dinheiro do usuario
        public Planta(int n)

        {
            setEnergia(n);
        }//Construtor

        public double getEnergia()
        {
            return energia;
        }
        public double getAgua()
        {
            return agua;
        }
        public double getLuz()
        {
            return luz;
        }
        public void setEnergia(double energia)
        {
            this.energia = energia;
        }
        public void setAgua(double agua)
        {
            this.agua = agua;
        }
        public void setLuz(double luz)
        {
            this.luz = luz;
        }
        public void setDinheiro(double dinheiro)
        {
            this.dinheiro = dinheiro;
        }
        public double getDinheiro()
        {
            return dinheiro;
        }
    }
}
