using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Galletita: Producto
    {
        #region Atributos

        protected float _peso;
        protected bool DeConsumo;

        #endregion

        #region Propiedades

         public override float CalcularCostoDeProduccion
        {
            get 
            {
                return (this._precio * 0.33F);
            }
        }

        #endregion

        #region Constructores
        /// <summary>
         /// Inicialza la Galletita invocando al constructor Padre 'Producto'
        /// </summary>
        /// <param name="codigoBarra"></param>
        /// <param name="precio"></param>
        /// <param name="marca"></param>
        /// <param name="peso"></param>
         public Galletita(int codigoBarra, float precio, EMarcaProducto marca, float peso)
            : base(codigoBarra, marca, precio)  
        {
            this._peso = peso;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Retorno cadena "Comestible"
        /// </summary>
        /// <returns></returns>
        public override string Consumir()
        {
            return "Comestible";
        }

        /// <summary>
        /// Devuelve cadena con toda la información de la Galletita
        /// </summary>
        /// <returns></returns>
        string MostrarGalletita(Galletita g) 
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("MARCA: ");
            sb.AppendLine((g.Marca).ToString());
            sb.Append("CODIGO DE BARRAS: ");
            sb.AppendLine((g._codigoBarra).ToString());
            sb.Append("PRECIO: ");
            sb.AppendLine((g.Precio).ToString());
            sb.Append("PESO: ");
            sb.AppendLine(this._peso.ToString());
            sb.AppendLine();
            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga Metodo Tostring para mostrar información de la Galletita
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarGalletita(this);
        }

        #endregion
    }
}
