using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Clase_12_Library
{
    public class Moto : Vehiculo
    {
        #region CONSTRUCTORES

        /// <summary>
        /// Constructor por defecto para crear una Moto.
        /// </summary>
        /// <param name="marca">Marca de la moto.</param>
        /// <param name="patente">Patente de la moto.</param>
        /// <param name="color">Color de la moto.</param>
      public Moto(EMarca marca, string patente, ConsoleColor color)
            : base(marca, patente, color)
        {
        }

        #endregion

        #region PROPIEDADES
        /// <summary>
        /// Las motos tienen 2 ruedas
        /// </summary>
        protected override short CantidadRuedas
        {
            get
            {
                return 2;
            }
        }

        #endregion

        #region METODOS

        /// <summary>
        /// Devuelve todos los datos de la Moto.
        /// </summary>
        /// <returns>Datos de la Moto.</returns>
        protected override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MOTO");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("RUEDAS : " + this.CantidadRuedas);
            sb.AppendLine("--------------------");

            return sb.ToString();
        }

        #endregion
    }
}
