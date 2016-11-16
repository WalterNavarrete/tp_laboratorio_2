using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Archivos;
using System.Xml.Serialization;

namespace EntidadesInstanciables
{
    [Serializable]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Instructor))]
    public class Jornada
    {
        #region ATRIBUTOS

        public List<Alumno> _alumnos;
        public Gimnasio.EClases _clases;
        public Instructor _instructor;

        #endregion

        #region CONSTRUCTORES

        /// <summary>
        /// Constructor por defecto que inicializa la lista de alumnos.
        /// </summary>
        public Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor que inicializa la clase y al instructor que recibe como parámetros.
        /// </summary>
        /// <param name="clase">Clase que se da en la jornada.</param>
        /// <param name="instructor">Instructor que da la clase.</param>
        public Jornada(Gimnasio.EClases clases, Instructor instructor)
            :this()
        {
            this._clases = clases;
            this._instructor = instructor;
        }

        #endregion

        #region SOBRECARGAS DE OPERADORES

        /// <summary>
        /// La igualdad se da cuando un alumno ya esta cargado en la jornada
        /// </summary>
        /// <param name="jornada"></param>
        /// <param name="alumno"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool participa = false;

            foreach (Alumno item in j._alumnos)
            {
                if (a == item)
                {
                    participa = true;
                    break;
                }
            }
            return participa;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un alumno a la jornada.
        /// </summary>
        /// <param name="j">Jornada a la que se va a agregar el alumno.</param>
        /// <param name="a">Alumno a agregar a la jornada.</param>
        /// <returns>Devuelve la Jornada.</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j._alumnos.Add(a);

            return j;
        }

        #endregion

        #region METODOS

        /// <summary>
        /// Guarda la jornada en un archivo de texto.
        /// </summary>
        /// <param name="jornada">Jornada a guardar.</param>
        /// <returns>true si guardó exitosamente.</returns>
        public static bool Guardar(Jornada jornada)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\jornada.txt";

            Texto text = new Texto();

            text.guardar(path, jornada.ToString());

            return true;       
        }

        /// <summary>
        /// Lee la jornada que se guardó en un archivo de texto y la devuelve como string.
        /// </summary>
        /// <returns>Jornada leída en formato string.</returns>
        public static string Leer()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\jornada.txt";
            string aux;
            Texto text = new Texto();
            text.leer(path, out aux);
            return aux;
        }

        /// <summary>
        /// Devuelve cadena con los datos de la jornada.
        /// </summary>
        /// <returns>Datos completos de la jornada.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASE DE " + this._clases + " POR " + this._instructor);
            sb.AppendLine("ALUMNOS:");
            foreach (Alumno item in this._alumnos)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("<------------------------------------------->");
            return sb.ToString();
        }

        #endregion

    }
}
