using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string _archivo;
        private string _path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";
       
        public Texto(string archivo)
        {
            this._archivo = archivo;
        }

        public bool guardar(string datos)
        {
            try
            {
                StreamWriter sw = new StreamWriter(_path + this._archivo, false, Encoding.UTF8);
                sw.Write(datos);
                sw.Close();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool leer(out List<string> datos)
        {
            datos = new List<string>();
            try
            {
                StreamReader sr = new StreamReader(_path + this._archivo);
                datos.Add(sr.ReadLine());
                sr.Close();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }
    }
}
