using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_WalterNavarrete
{
    class Calculadora
    {
        /// <summary>
        /// Realizo las operaciones
        /// </summary>
        /// <param name="numero1">numero 1 a operar</param>
        /// <param name="numero2">numero 2 a operar</param>
        /// <param name="operador">Operacion a realizar</param>
        /// <returns>Retorno resultado de la operación</returns>
        public static double operar(Numero numero1, Numero numero2, string operador)
        {
            double resultado = 0;

            switch (operador)
            {
                case "+":
                    resultado = numero1.getNumero() + numero2.getNumero();
                    break;
                case "-":
                    resultado = numero1.getNumero() - numero2.getNumero();
                    break;
                case "*":
                    resultado = numero1.getNumero() * numero2.getNumero();
                    break;
                case "/":
                    if (numero1.getNumero() == 0 || numero2.getNumero() == 0)
                    {
                        resultado = 0;
                    }
                    else
                    {
                        resultado = numero1.getNumero() / numero2.getNumero();
                    }
                    break;
            }
            return resultado;
        }

        /// <summary>
        /// Valido que sea un operador Valido
        /// </summary>
        /// <param name="operador">String Operador</param>
        /// <returns>En caso que no sea alguno valido retorno +</returns>
        public static string validarOperador(string operador)
        {
            if (operador != "-" && operador != "*" && operador != "/")
                return "+";
            else
                return operador;
        }


    }
}
