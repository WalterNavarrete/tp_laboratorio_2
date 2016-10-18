using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Producto
    {

        #region Enumerados

        public enum EMarcaProducto
        {
            Manaos, Pitusas, Naranjú, Diversión, Swift, Favorita
        }
        public enum ETipoProducto
        {
            Galletita, Gaseosa, Jugo, Todos
        }

        #endregion

        #region Atributos

        protected int _codigoBarra;
        protected EMarcaProducto _marca;
        protected float _precio;

        #endregion

        #region Propiedades
        /// <summary>
        /// Retorna valor de _marca
        /// </summary>
        public EMarcaProducto Marca {

            get { return this._marca; }
        }

        public abstract float CalcularCostoDeProduccion { get; }

        /// <summary>
        /// Retorna valor de _precio
        /// </summary>
        public float Precio 
        {
            get {return this._precio;}
        }

        #endregion

        #region Constructores
        /// <summary>
        /// Inicialza el Producto
        /// </summary>
        /// <param name="codigobarra"></param>
        /// <param name="marca"></param>
        /// <param name="precio"></param>
        public Producto(int codigobarra, EMarcaProducto marca, float precio)
        {
            this._codigoBarra = codigobarra;
            this._marca = marca;
            this._precio = precio;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Retorna cadena 'Parte de una mezcla'
        /// </summary>
        /// <returns></returns>
        public virtual string Consumir() 
        {
            return "Parte de una mezcla";
        }

        /// <summary>
        /// Muestra una cadena de todos los productos
        /// </summary>
        /// <returns></returns>
       private static string MostrarProducto(Producto p) 
       {
            StringBuilder sb = new StringBuilder();
            sb.Append("MARCA: ");
            sb.AppendLine((p.Marca).ToString());
            sb.Append("CODIGO DE BARRAS: ");
            sb.AppendLine((p._codigoBarra).ToString());
            sb.Append("PRECIO: ");
            sb.AppendLine((p.Precio).ToString());

           return sb.ToString();
       }
 
       #endregion

        #region Sobrecargas Operadores
     
        /// <summary>
        /// Compara dos Productos
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
       public static  bool operator ==(Producto p1, Producto p2)
       {
           return (p1._precio == p2._precio && p1._codigoBarra == p2._codigoBarra && p1._marca == p2._marca);
       }
        /// <summary>
        /// Valido igualdad de marca del producto con la marca recibida por param
        /// </summary>
        /// <param name="prod"></param>
        /// <param name="marca"></param>
        /// <returns></returns>
       public static bool operator ==(Producto prod, EMarcaProducto marca)
       {
           return (prod.Marca.Equals(marca));
       }

       public static bool operator !=(Producto p1, Producto p2)
       {
           return !(p1._precio == p2._precio && p1._codigoBarra == p2._codigoBarra && p1._marca == p2._marca);
       }

       public static bool operator !=(Producto prod, EMarcaProducto marca) 
       {
           return !(prod.Marca.Equals(marca));
       }
  
       /// <summary>
       /// Retorna el Codigo del Producto
       /// </summary>
       /// <param name="p"></param>
       /// <returns></returns>
       public static explicit operator int(Producto p)
       {
           return p._codigoBarra;
       }
       /// <summary>
       /// Muestra cadena de Producto
       /// </summary>
       /// <param name="p"></param>
       /// <returns></returns>
       public static implicit operator string(Producto p)
       {
           return Producto.MostrarProducto(p);
       }

       public override bool Equals(object obj) { return ReferenceEquals(this, obj); }

        #endregion
    }
}
