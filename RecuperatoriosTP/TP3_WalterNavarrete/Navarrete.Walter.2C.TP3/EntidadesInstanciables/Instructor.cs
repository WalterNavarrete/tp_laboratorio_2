using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    [Serializable]
    public sealed class Instructor : PersonaGimnasio
    {
        #region ATRIBUTOS

        private Queue<Gimnasio.EClases> _clasesDelDia;
        private static Random _random;

        #endregion

        #region CONSTRUCTORES

        /// <summary>
        /// Constructor por defecto para la serialización.
        /// </summary>
        public Instructor()
        {
        }

        /// <summary>
        /// Constructor de clase que inicializa el random.
        /// </summary>
        static Instructor()
        {
            Instructor._random = new Random();
        }

        /// <summary>
        /// Constructor para un nuevo instructor.
        /// </summary>
        /// <param name="id">ID.</param>
        /// <param name="nombre">Nombre.</param>
        /// <param name="apellido">Apellido.</param>
        /// <param name="dni">DNI.</param>
        /// <param name="nacionalidad">Nacionalidad.</param>
        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Gimnasio.EClases>();
            this._randomClases();
            this._randomClases();
        }

        #endregion

        #region METODOS

        /// <summary>
        /// Genera en forma Aleatoria las  clases que dicta el instructor.
        /// </summary>
        private void _randomClases()
        {
            int auxRandom = 0;
            //Genero un random y lo uso en el switch para agregar a la cola la clase que corresponda
            auxRandom = Instructor._random.Next(0, 3);

            switch (auxRandom)
            {
                case 0:
                    this._clasesDelDia.Enqueue(Gimnasio.EClases.Natacion);
                    break;
                case 1:
                    this._clasesDelDia.Enqueue(Gimnasio.EClases.CrossFit);
                    break;
                case 2:
                    this._clasesDelDia.Enqueue(Gimnasio.EClases.Pilates);
                    break;
                case 3:
                    this._clasesDelDia.Enqueue(Gimnasio.EClases.Yoga);
                    break;
            }
        }

        /// <summary>
        /// Devuelve una cadena con todos los datos del instructor.
        /// </summary>
        /// <returns>Datos del instructor.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// Devuelve las clases que dicta el instructor.
        /// </summary>
        /// <returns>Clases que dicta el instructor.</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA");
            foreach (Gimnasio.EClases item in this._clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Devuelve una cadena con todos los datos del instructor.
        /// </summary>
        /// <returns>Datos del instructor.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region SOBRECARAG DE OPERADORES

        /// <summary>
        /// Verifica si el instructor dicta la clase.
        /// </summary>
        /// <param name="i">Instructor a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns>true si el instructor dicta la clase.</returns>
        public static bool operator ==(Instructor i, Gimnasio.EClases c)
        {
            bool daClase = false;
            foreach (Gimnasio.EClases item in i._clasesDelDia)
            {
                if (item == c)
                {
                    daClase = true;
                    break;
                }
            }

            return daClase;
        }

        public static bool operator !=(Instructor i, Gimnasio.EClases c)
        {
            return !(i == c);
        }

        #endregion

    }
}
