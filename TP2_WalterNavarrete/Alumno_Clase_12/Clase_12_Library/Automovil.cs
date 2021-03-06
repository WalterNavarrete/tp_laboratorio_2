﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_12_Library
{
    public class Automovil : Vehiculo
    {
        #region "Costructores"

        public Automovil(EMarca marca, string patente, ConsoleColor color)
            : base(marca, patente, color){}

        #endregion

        #region "Propiedades"
        /// <summary>
        /// Los automoviles tienen 4 ruedas
        /// </summary>
        protected override short CantidadRuedas
        {
            get
            {
                return 4;
            }
        }

        #endregion

        #region "Sobrecarga Metodos"

        protected override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("RUEDAS :"  + this.CantidadRuedas);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.Mostrar();
        }

        #endregion
    }
}
