using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    [Serializable]
    public sealed class Alumno : PersonaGimnasio
    {
        #region ATRIBUTOS

        private Gimnasio.EClases _clasesQueToma;
        private EEstadoCuenta _estadoCuenta;
        
        #endregion

        #region CONSTRUCTORES

        /// <summary>
        /// Constructor por defecto para la serialización.
        /// </summary>
        public Alumno()
        {
        }

        /// <summary>
        /// Constructor para un nuevo alumno.
        /// </summary>
        /// <param name="id">ID.</param>
        /// <param name="nombre">Nombre.</param>
        /// <param name="apellido">Apellido.</param>
        /// <param name="dni">DNI.</param>
        /// <param name="nacionalidad">Nacionalidad.</param>
        /// <param name="claseQueToma">Clase que toma.</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases clasesQueToma) 
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesQueToma = clasesQueToma;
        }
        /// <summary>
        /// Constructor para un nuevo alumno con el estado de la cuenta.
        /// </summary>
        /// <param name="id">ID.</param>
        /// <param name="nombre">Nombre.</param>
        /// <param name="apellido">Apellido.</param>
        /// <param name="dni">DNI.</param>
        /// <param name="nacionalidad">Nacionalidad.</param>
        /// <param name="claseQueToma">Clase que toma.</param>
        /// <param name="estadoCuenta">Estado de la cuenta.</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases clasesQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, clasesQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }
        /// <summary>
       
        #endregion

        #region METODOS

        /// <summary>
        /// Devuelve una cadena con todos los datos del alumno.
        /// </summary>
        /// <returns>Datos del alumno.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos() + "ESTADO DE CUENTA: " + this._estadoCuenta + "\n" + this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Devuelve la clase que toma el alumno.
        /// </summary>
        /// <returns>Clase que toma el alumno.</returns>
        protected override string ParticiparEnClase()
        {
            return ("TOMA CLASES DE " + this._clasesQueToma);
        }

        /// <summary>
        /// Devuelve todos los datos del alumno.
        /// </summary>
        /// <returns>Datos del alumno.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region SOBRECARGAS DE OPERADORES

        /// <summary>
        /// Compara si el alumno no toma la clase.
        /// </summary>
        /// <param name="a">Alumno a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns>true si el alumno no toma la clase.</returns>
        public static bool operator ==(Alumno a, Gimnasio.EClases c)
        {
            return (a._clasesQueToma == c) && (a._estadoCuenta != EEstadoCuenta.Deudor);
        }

        /// <summary>
        /// Compara si el alumno toma la clase y su estado de cuenta no es Deudor.
        /// </summary>
        /// <param name="a">Alumno a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns>true si el alumno toma la clase y su estado de cuenta no es Deudor.</returns>
        public static bool operator !=(Alumno a, Gimnasio.EClases c)
        {
            return(a._clasesQueToma != c);
        }

        #endregion
       
        #region ENUMERADOS

        public enum EEstadoCuenta
        {
            AlDia, Deudor, MesPrueba
        }

        #endregion
    }

}
