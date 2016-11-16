using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        #region ATRIBUTOS

        private const string msg = "El DNI es invalido";

        #endregion

        #region CONSTRUCTORES

         public DniInvalidoException()
            : this(msg)
        { }

        public DniInvalidoException(Exception e)
             : this(msg, e)
        { }

        public DniInvalidoException(string message)
            : this(message, null)
        { }

        public DniInvalidoException(string message, Exception e)
            : base(message, e)
        { }


        #endregion
    }
}
