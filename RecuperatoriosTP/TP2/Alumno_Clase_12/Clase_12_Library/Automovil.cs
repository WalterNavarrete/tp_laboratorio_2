using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_12_Library
{
    public class Automovil : Vehiculo
    {
        #region CONSTRUCTORES

        /// <summary>
        /// Constructor por defecto para crear un Automóvil.
        /// </summary>
        /// <param name="marca">Marca del automóvil.</param>
        /// <param name="patente">Patente del automóvil.</param>
        /// <param name="color">Color del automóvil.</param>
        public Automovil(EMarca marca, string patente, ConsoleColor color)
            : base(marca, patente, color){}

        #endregion


        #region PROPIEDADES

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

        #region METODOS

        /// <summary>
        /// Devuelve todos los datos del Automóvil.
        /// </summary>
        /// <returns> Datos del Automóvil.</returns>
        protected override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("RUEDAS :"  + this.CantidadRuedas);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion
    }
}
