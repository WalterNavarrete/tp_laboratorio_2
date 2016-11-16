using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_12_Library
{
    public abstract class Vehiculo
    {
        #region ATRIBUTOS

        EMarca _marca;
        string _patente;
        ConsoleColor _color;

        #endregion

        #region PROPIEDADES
        /// <summary>
        /// Retornará la cantidad de ruedas del vehículo
        /// </summary>
        protected abstract short CantidadRuedas { get;}

        #endregion

        #region CONSTRUCTORES

        /// <summary>
        /// Constructor por defecto para crear un Vehículo.
        /// </summary>
        /// <param name="patente">Patente del vehículo.</param>
        /// <param name="marca">Marca del vehículo.</param>
        /// <param name="color">Color del vehículo.</param>
        public Vehiculo(EMarca marca, string patente, ConsoleColor color)
        {
            this._marca = marca;
            this._patente = patente;
            this._color = color;
        }

        #endregion

        #region METODOS

        /// <summary>
        /// Genera un string con los datos del Vehiculo
        /// </summary>
        /// <returns></returns>
        protected virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("PATENTE: {0}\r\n", this._patente);
            sb.AppendFormat("MARCA  : {0}\r\n", this._marca.ToString());
            sb.AppendFormat("COLOR  : {0}\r\n", this._color.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Sobrecargo metodo para ejecutar Metodo Mostrar()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Mostrar();
        }

        #endregion

        #region SOBRECARGA DE OPERADORES

        /// <summary>
        /// Dos vehículos son iguales si comparten la misma patente
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1._patente == v2._patente);
        }

        /// <summary>
        /// Dos vehículos son distintos si su patente es distinta
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }

        #endregion

        #region ENUMERADOS

        public enum EMarca
        {
            Yamaha, Chevrolet, Ford, Iveco, Scania, BMW
        }

        #endregion
    }
}
