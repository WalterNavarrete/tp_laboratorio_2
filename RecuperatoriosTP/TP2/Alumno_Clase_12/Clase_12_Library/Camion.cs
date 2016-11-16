using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_12_Library
{
    public class Camion : Vehiculo
    {
        #region CONSTRUCTORES

        /// <summary>
        /// Constructor por defecto para crear un Camión.
        /// </summary>
        /// <param name="marca">Marca del camión</param>
        /// <param name="patente">Patente del camión.</param>
        /// <param name="color">Color del camión.</param>
        public Camion(EMarca marca, string patente, ConsoleColor color)
            : base(marca, patente, color) { }

        #endregion

        #region PROPIEDADES

        /// <summary>
        /// Los camiones tienen 8 ruedas
        /// </summary>
        protected override short CantidadRuedas
        {
            get
            {
                return 8;
            }
        }

        #endregion

        #region METODOS

        /// <summary>
        /// Devuelve todos los datos del Camión.
        /// </summary>
        /// <returns>Datos del Camión.</returns>
        protected override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CAMION");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("RUEDAS : " + this.CantidadRuedas);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        #endregion
    }
}
