﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda el dato en un archivo de texto.
        /// </summary>
        /// <param name="archivo">Path donde se guardará el archivo de texto.</param>
        /// <param name="datos">Datos que se guardarán en el archivo de texto.</param>
        /// <returns>true si guardó exitósamente.</returns>
        public bool guardar(string archivo, string datos)
        {
            try
            {
                StreamWriter sw = new StreamWriter(archivo, false);
                sw.Write(datos);
                sw.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Lee un archivo de texto y lo guarda en un string.
        /// </summary>
        /// <param name="archivo">Path donde se leerá el archivo de texto.</param>
        /// <param name="datos">Datos que se leerán del archivo de texto.</param>
        /// <returns>true si leeyó exitósamente.</returns>
        public bool leer(string archivo, out string datos)
        {
            try
            {
                StreamReader sr = new StreamReader(archivo);
                datos = sr.ReadToEnd();
                sr.Close();
                return true;
            }
            catch (Exception e)
            {
                datos = default(string);
                throw new ArchivosException(e);
            }
        }
    }
}
