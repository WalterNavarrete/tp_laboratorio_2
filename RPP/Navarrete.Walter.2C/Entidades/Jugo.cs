using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Jugo : Producto
    {
        #region Enumerados

        public enum ESaborJugo{Asqueroso, Pasable, Rico}

        #endregion

        #region Atributos

        ESaborJugo _sabor;
        static bool DeConsumo;

        #endregion

        #region Propiedades
        
        /// <summary>
        /// Retorna costo de producción del jugo
        /// </summary>
        public override float CalcularCostoDeProduccion
        {
            get 
            {               
                return (this._precio * 0.4F);
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Inicialza DeConsumo en True
        /// </summary>
        static Jugo()
        {
            DeConsumo = false;
        }
        /// <summary>
        /// Inicialza el Jugo invocando al constructor Padre 'Producto'
        /// </summary>
        /// <param name="codigoBarra"></param>
        /// <param name="precio"></param>
        /// <param name="marca"></param>
        /// <param name="sabor"></param>
        public Jugo(int codigoBarra, float precio, EMarcaProducto marca, ESaborJugo sabor):base(codigoBarra,marca,precio)
        {
            this._sabor = sabor;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Devuelve cadena con toda la información de Jugo
        /// </summary>
        /// <returns></returns>
        private string MostrarJugo() 
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("MARCA: ");
            sb.AppendLine((base.Marca).ToString());
            sb.Append("CODIGO DE BARRAS: ");
            sb.AppendLine((base._codigoBarra).ToString());
            sb.Append("PRECIO: ");
            sb.AppendLine((base.Precio).ToString());
            sb.Append("SABOR: ");
            sb.AppendLine(this._sabor.ToString());
            sb.AppendLine();
            return sb.ToString();
        }
        /// <summary>
        /// Sobrecarga Metodo Tostring para mostrar información del Jugo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarJugo();
        }
        /// <summary>
        /// Retorna cadena "Bebible"
        /// </summary>
        /// <returns></returns>
        public override string Consumir()
        {
            return "Bebible";
        }

        #endregion
    }
}
