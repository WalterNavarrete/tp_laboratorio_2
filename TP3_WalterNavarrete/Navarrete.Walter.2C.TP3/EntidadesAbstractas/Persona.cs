using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region ATRIBUTOS

        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;

        #endregion

        #region PROPIEDADES

        public string Apellido
        {
            get { return this._apellido; }
            set { this._apellido = this.ValidarNombreApellido(value); }
        }

        public int DNI
        {
            get { return this._dni; }
            set { _dni = ValidarDni(this.Nacionalidad, value); }
        }

        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set { this._nacionalidad = value; }
        }

        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = this.ValidarNombreApellido(value); }
        }

        [XmlIgnore]
        public string StringToDNI
        {
            set
            {
                try
                {
                    this._dni = ValidarDni(this.Nacionalidad, value);
                }
                catch (Exception)
                {
                    throw new NacionalidadInvalidaException();
                }
            }
        }

        #endregion

        #region CONSTRUCTORES

        /// <summary>
        /// Constructor por defecto para la serialización.
        /// </summary>
        public Persona()
        { }

        /// <summary>
        /// Constructor para una nueva Persona sin DNI.
        /// </summary>
        /// <param name="nombre">Nombre.</param>
        /// <param name="apellido">Apellido.</param>
        /// <param name="nacionalidad">Nacionalidad</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor que crea una nueva Persona con DNI int.
        /// </summary>
        /// <param name="nombre">Nombre.</param>
        /// <param name="apellido">Apellido.</param>
        /// <param name="dni">DNI (int).</param>
        /// <param name="nacionalidad">Nacionalidad.</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this._dni = dni;
        }

        /// <summary>
        /// Constructor que crea una nueva Persona con DNI string.
        /// </summary>
        /// <param name="nombre">Nombre.</param>
        /// <param name="apellido">Apellido.</param>
        /// <param name="dni">DNI (int).</param>
        /// <param name="nacionalidad">Nacionalidad.</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region METODOS

        /// <summary>
        /// Valida que el dni sea correcto con la nacionalidad
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            bool dniInvalido = false;
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato < 1 || dato > 89999999)
                        dniInvalido = true;
                    break;
                case ENacionalidad.Extranjero:
                    if (dato < 90000000 || dato > 99999999)
                        dniInvalido = true;
                    break;
                default:
                    throw new NacionalidadInvalidaException("Nacionalidad inexistente");
            }

            if (dniInvalido)
                throw new DniInvalidoException("El dni es invalido");
            else
                return dato;
        }

        /// <summary>
        /// Valida que el dni sea correcto con la nacionalidad, reutiliza ValidarDni
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            try
            {
                return ValidarDni(nacionalidad, int.Parse(dato));
            }
            catch (DniInvalidoException)
            {
                throw;
            }
            catch (NacionalidadInvalidaException)
            {
                throw;
            }
            catch (FormatException)
            {
                throw new DniInvalidoException();
            }
        }

        /// <summary>
        /// Valida Nombre y Apellido
        /// </summary>
        /// <param name="dato">Recibe un string a validar</param>
        /// <returns>Retorna un string</returns>
        private string ValidarNombreApellido(string dato)
        {
            Regex rgx = new Regex(@"[a-zA-Z]*");

            if (rgx.IsMatch(dato))
                return dato;
            else
                return "";
        }

        /// <summary>
        /// Retorna una cadena con todos los datos de la Persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("NOMBRE COMPLETO: " + this._apellido + ", " + this._nombre);
            sb.AppendLine("NACIONALIDAD: " + this._nacionalidad.ToString());
            return sb.ToString();
        }

        #endregion

        #region ENUMERADOS

        public enum ENacionalidad
        {
            Argentino, Extranjero
        }

        #endregion

    }
}
