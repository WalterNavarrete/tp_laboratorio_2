using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_WalterNavarrete
{
    class Numero
    {
        private double numero;

        public Numero()
        {
            this.numero = 0;
        }
        public Numero(double numero)
        {
            this.numero = numero;
        }
        public Numero(string numero)
        {
            this.setNumero(numero);
        }

        private void setNumero(string numero)
        {
            if (this.validarNumero(numero) == 1)
            {
                this.numero = double.Parse(numero);
            }
        }

        public double getNumero()
        {
            return this.numero;
        }
        /// <summary>
        /// Valido que se trato de un Double Valido
        /// </summary>
        /// <param name="numeroString"></param>
        /// <returns>Si es valido retorno 1, si no es Valido Retorno 0</returns>
        /// 
        private double validarNumero(string numeroString) 
        {
            double resp = 1;
            if (double.TryParse(numeroString, out this.numero))
                return resp;
            else
                return this.numero;
  

        }
    }
}
