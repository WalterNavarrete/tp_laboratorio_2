using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Gaseosa : Producto
    {
        #region Atributos

        protected float _litros;
        protected static bool DeConsumo;

        #endregion

        #region Propiedades

        /// <summary>
        /// Retorna costo de producción de la Gaseosa
        /// </summary>
        public override float CalcularCostoDeProduccion
        {
            get
            {
                return (this._precio * 0.42F);
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Inicialza DeConsumo en True
        /// </summary>
        static Gaseosa()
        {
            DeConsumo = false;
        }

        /// <summary>
        /// Inicialza la Harina con Producto recibido por parametro
        /// </summary>
        /// <param name="codigoBarra"></param>
        /// <param name="precio"></param>
        /// <param name="marca"></param>
        /// <param name="tipo"></param>
        public Gaseosa(Producto p, float litros)
            : this((int)p, p.Precio, p.Marca, litros) 
        {
        }

        /// <summary>
        /// Inicialza la Harina invocando al constructor Padre 'Producto'
        /// </summary>
        /// <param name="codigoBarra"></param>
        /// <param name="precio"></param>
        /// <param name="marca"></param>
        /// <param name="tipo"></param>
        public Gaseosa(int codigoBarra, float precio, EMarcaProducto marca, float litros)
            : base(codigoBarra, marca, precio)
        {
            this._litros = litros;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Retorno cadena "Bebible"
        /// </summary>
        /// <returns></returns>
        public override string Consumir()
        {
            return "Bebible";
        }

        /// <summary>
        /// Devuelve cadena con toda la información de la Gaseosa
        /// </summary>
        /// <returns></returns>
        private string MostrarGaseosa()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("MARCA: ");
            sb.AppendLine((base.Marca).ToString());
            sb.Append("CODIGO DE BARRAS: ");
            sb.AppendLine((base._codigoBarra).ToString());
            sb.Append("PRECIO: ");
            sb.AppendLine((base.Precio).ToString());
            sb.Append("LITROS: ");
            sb.AppendLine((this._litros).ToString());
            sb.AppendLine();
            return sb.ToString();
        }

        /// <summary>
        /// <summary>
        /// Sobrecarga Metodo Tostring para mostrar información de la Gaseosa
        /// </summary>
        /// <returns></returns>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarGaseosa();
        }

        #endregion
    }
}
