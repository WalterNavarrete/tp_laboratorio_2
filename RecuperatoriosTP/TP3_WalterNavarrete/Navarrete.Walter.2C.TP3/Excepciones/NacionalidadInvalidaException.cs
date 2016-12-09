using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException: Exception
    {
        #region Atributos
        private const string msg = "La nacionalidad no se condice con el numero de DNI";
        #endregion

        #region Constructores
        public NacionalidadInvalidaException()
            : this(msg)
        { }

        public NacionalidadInvalidaException(string message)
            : base(message)
        { }
        #endregion
    }
}
