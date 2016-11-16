using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Xml.Serialization;
using Archivos;

namespace EntidadesInstanciables
{
    [Serializable]
    [XmlInclude(typeof(Alumno))]
    [XmlInclude(typeof(Instructor))]
    [XmlInclude(typeof(Jornada))]
    public class Gimnasio
    {
        #region ATRIBUTOS

        public List<Alumno> _alumnos;
        public List<Instructor> _instructores;
        public List<Jornada> _jornadas;

        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Inicializa los atributos del Gimnasio
        /// </summary>
        public Gimnasio()
        {
            this._alumnos = new List<Alumno>();
            this._instructores = new List<Instructor>();
            this._jornadas = new List<Jornada>();
        }

        #endregion

        #region PROPIEDADES

        /// <summary>
        /// Indexador de una Lista de Jornada
        /// </summary>
        /// <param name="i"></param>
        /// <returns>Retorna una Jornada con el Indice especifico</returns>
        [XmlIgnore]
        public Jornada this[int index]
        {
            get
            {
                return this._jornadas[index];
            }
        }

        #endregion

        #region SOBRECARGAS DE OPERADORES

        /// <summary>
        /// Compara si el alumno está inscripto en el gimnasio.
        /// </summary>
        /// <param name="g">Gimnasio a comparar.</param>
        /// <param name="a">Alumno a comparar.</param>
        /// <returns>true si el alumno está inscripto en el gimnasio.</returns>
        public static bool operator ==(Gimnasio g, Alumno a)
        {
            return (g._alumnos.Contains(a));
        }

        public static bool operator !=(Gimnasio g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Se agrega un alumno al gimnasio, validando que no esté previamente cargado.
        /// </summary>
        /// <param name="g">Gimnasio donde se agrega alumno.</param>
        /// <param name="a">Alumno a agregar.</param>
        /// <returns>Gimnasio con el alumno agregado.</returns>
        public static Gimnasio operator +(Gimnasio g, Alumno a)
        {
            if (g == a)
                throw new AlumnoRepetidoException();

            g._alumnos.Add(a);

            return g;
        }

        /// <summary>
        /// Compara si el instructor está dando clases en el gimnasio.
        /// </summary>
        /// <param name="g">Gimnasio a comparar.</param>
        /// <param name="i">Instructor a comparar.</param>
        /// <returns>true si el instructor está dando clases en el gimnasio.</returns>
        public static bool operator ==(Gimnasio g, Instructor i)
        {
            bool daClase = false;
            foreach (Instructor item in g._instructores)
            {
                if (item == i)
                {
                    daClase = true;
                    break;
                }
            }

            return daClase;
        }

        public static bool operator !=(Gimnasio g, Instructor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Se agrega un instructor al gimnasio, validando que no esté previamente cargado.
        /// </summary>
        /// <param name="g">Gimnasio donde se agrega alumno.</param>
        /// <param name="i">Instructor a agregar.</param>
        /// <returns>Gimnasio con el instructor agregado.</returns>
        public static Gimnasio operator +(Gimnasio g, Instructor i)
        {
            if (g != i)
                g._instructores.Add(i);

            return g;
        }

        /// <summary>
        /// Un gimnasio es igual a una clase si hay un instructor que de la clase
        /// </summary>
        /// <param name="g">Objeto de Gimnasio</param>
        /// <param name="clase">Enumerado de EClases</param>
        /// <returns>Retorna un Instructor que esté dando clase</returns>
        public static Instructor operator ==(Gimnasio g, Gimnasio.EClases clase)
        {
            Instructor instAux = null;
            foreach (Instructor item in g._instructores)
            {
                if (item == clase)
                {
                    instAux = item;
                    break;
                }
            }

            //Verifico que la variable tipo Instructor este inicializada, sino, lanzo una excepcion
            if (!Object.Equals(instAux, null))
                return instAux;
            else
                throw new SinInstructorException();


        }

        public static Instructor operator !=(Gimnasio g, Gimnasio.EClases clase)
        {
            int index = -1;
            for (int i = 0; i < g._instructores.Count; i++)
            {
                if (g._instructores[i] != clase)
                {
                    index = i;
                    break;
                }

            }

            return g._instructores[index];
        }

        /// <summary>
        /// Genera una nueva jornada en el gimnasio con la clase dada.
        /// </summary>
        /// <param name="g">Gimnasio donde se genera la jornada.</param>
        /// <param name="clase">Clase que se va a dictar en la jornada.</param>
        /// <returns>Gimnasio con la jornada generada.</returns>
        public static Gimnasio operator +(Gimnasio g, Gimnasio.EClases clase)
        {
            Jornada j = new Jornada(clase, (g == clase));

            foreach (Alumno alumno in g._alumnos)
            {
                if (alumno == clase)
                    j += alumno;
            }

            g._jornadas.Add(j);

            return g;
        }

        #endregion

        #region METODOS

        /// <summary>
        /// Devuelve una cadena con todos los datos del gimnasio.
        /// </summary>
        /// <param name="gim">Gimnasio a mostrar.</param>
        /// <returns>Datos del gimnasio.</returns>
        private static string MostrarDatos(Gimnasio gim)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            for (int i = 0; i < gim._jornadas.Count; i++)
            {
                sb.AppendLine(gim._jornadas[i].ToString());
            }

           

            return sb.ToString();
        }

        /// <summary>
        /// Guarda el gimnasio en un archivo XML.
        /// </summary>
        /// <param name="g">Gimnasio a mostrar</param>
        /// <returns>true si guardó exitosamente</returns>
        public static bool Guardar(Gimnasio g)
        {
            string pathXml = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\gimnasio.xml";
            Xml<Gimnasio> xmlFile = new Xml<Gimnasio>();
            xmlFile.guardar(pathXml, g);
            return true;
        }

        /// <summary>
        /// Lee el gimnasio que se guardó en un archivo XML y la devuelve como Gimnasio.
        /// </summary>
        /// <returns>Gimnasio leído en formato Gimnasio.</returns>
        public static Gimnasio Leer()
        {
            string pathXml = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\gimnasio.xml";
            Gimnasio auxGimnasio;
            Xml<Gimnasio> xmlFile = new Xml<Gimnasio>();
            xmlFile.leer(pathXml, out auxGimnasio);
            return auxGimnasio;
        }

        /// <summary>
        /// Devuelve todos los datos del gimnasio.
        /// </summary>
        /// <returns>Cadena de datos del gimnasio.</returns>
        public override string ToString()
        {
            return Gimnasio.MostrarDatos(this);
        }

        #endregion

        #region ENUMERADOS

        public enum EClases
        {
            Natacion, CrossFit, Pilates, Yoga
        }

        #endregion
    }

}
