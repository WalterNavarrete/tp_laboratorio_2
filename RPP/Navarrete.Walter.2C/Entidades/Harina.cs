using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Harina :Producto
    {
        #region Enumerados

        public enum ETipoHarina { CuatroCeros, Integral}

        #endregion

        #region Atributos

        protected ETipoHarina _tipo;
        protected static bool DeConsumo;

        #endregion

        #region Propiedades
        /// <summary>
        /// Retorna costo de producción de la Harina
        /// </summary>
        public override float CalcularCostoDeProduccion
        {
            get 
            {
                return (this._precio * 0.6F);
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Inicialza DeConsumo en True
        /// </summary>
        static Harina()
        {
            DeConsumo = false;
        }

        /// <summary>
        /// Inicialza la Harina invocando al constructor Padre 'Producto'
        /// </summary>
        /// <param name="codigoBarra"></param>
        /// <param name="precio"></param>
        /// <param name="marca"></param>
        /// <param name="tipo"></param>
        public Harina(int codigoBarra, float precio, EMarcaProducto marca, ETipoHarina tipo)
            : base(codigoBarra, marca, precio) 
        {
            this._tipo = tipo;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Devuelve cadena con toda la información de la Harina
        /// </summary>
        /// <returns></returns>
        private string MostrarHarina() 
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("MARCA: ");
            sb.AppendLine((base.Marca).ToString());
            sb.Append("CODIGO DE BARRAS: ");
            sb.AppendLine((base._codigoBarra).ToString());
            sb.Append("PRECIO: ");
            sb.AppendLine((base.Precio).ToString());
            sb.Append("TIPO: ");
            sb.AppendLine((this._tipo).ToString());
            sb.AppendLine();
            return sb.ToString();
        }
        /// <summary>
        /// Sobrecarga Metodo Tostring para mostrar información de la Harina
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarHarina();
        }

        #endregion
    }
}
