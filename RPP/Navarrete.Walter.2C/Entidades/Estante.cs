using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Estante
    {
        #region Atributos

        protected sbyte _capacidad;
        protected List<Producto> _productos;

        #endregion

        #region Propiedades

        public float ValorEstanteTotal
        {
            get
            {
                return this.GetValorEstante();
            }
        }

        #endregion

        #region Constructores

        private Estante()
        {
            this._productos = new List<Producto>();
        }

        public Estante(sbyte capacidad)
            : this()
        {
            this._capacidad = capacidad;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Retorna Lista de Productos
        /// </summary>
        /// <returns></returns>
        public List<Producto> GetProductos()
        {
            return this._productos;
        }

        /// <summary>
        /// Devuelvo el valor del Estante segun el tipo de Producto
        /// </summary>
        /// <param name="tipoProducto"></param>
        /// <returns></returns>
        public float GetValorEstante(Producto.ETipoProducto tipoProducto)
        {
            float valor = 0;
            foreach (Producto item in this.GetProductos())
            {
                switch (tipoProducto)
                {
                    case Producto.ETipoProducto.Galletita:
                        if (item is Galletita)
                        valor += item.Precio;
                        break;
                    case Producto.ETipoProducto.Gaseosa:
                        if (item is Gaseosa)
                        valor += item.Precio;
                        break;
                    case Producto.ETipoProducto.Jugo:
                        if (item is Jugo)
                        valor += item.Precio;
                        break;
                    case Producto.ETipoProducto.Todos:
                        valor += item.Precio;
                        break;
                    default:
                        return 0;
                }

            }
            return valor;

        }

        /// <summary>
        /// Devuelve valor total de todos los productos
        /// </summary>
        /// <returns></returns>
        private float GetValorEstante()
        {
            return GetValorEstante(Producto.ETipoProducto.Todos);
        }

        /// <summary>
        /// Muestra cadena de la informacion del estante recibido por parametro
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string MostrarEstante(Estante e)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CAPACIDAD " + e._capacidad);
            foreach (Producto p in e._productos)
            {
                sb.AppendLine(p.ToString());
            }

            return sb.ToString();
        }

        #endregion

        #region Sobrecarga Operadores

        /// <summary>
        /// Verifico si el Producto existe en el Estante
        /// </summary>
        /// <param name="e"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool operator ==(Estante e, Producto p)
        {
            foreach (Producto prod in e._productos)
            {
                if (prod == p)
                {
                    return true;                  
                }
            }
            return false;
        }

        public static bool operator !=(Estante e, Producto p)
        {
            return !(e == p);
        }

        // <summary>
        /// Retorno un Estante con todos loa productos menos con el que coincida tipo de producto pasado por param
        /// </summary>
        /// <param name="e"></param>
        /// <param name="tipo"></param>
        /// <returns></returns>
        public static Estante operator -(Estante e, Producto.ETipoProducto tipo)
        {
            for (int i = 0; i < e.GetProductos().Count; i++)
            {
                switch (tipo)
                {
                    case Producto.ETipoProducto.Galletita:
                        if (e.GetProductos()[i] is Galletita)
                        {
                            e -= e.GetProductos()[i];
                            i--;
                        }
                        break;
                    case Producto.ETipoProducto.Gaseosa:
                        if (e.GetProductos()[i] is Gaseosa)
                        {
                            e -= e.GetProductos()[i];
                            i--;
                        }
                        break;
                    case Producto.ETipoProducto.Jugo:
                        if (e.GetProductos()[i] is Jugo)
                        {
                            e -= e.GetProductos()[i];
                            i--;
                        }
                        break;
                    case Producto.ETipoProducto.Todos:
                        e.GetProductos().Clear();
                        break;
                    default:
                        break;
                }
            }
            return e;
        }

        /// <summary>
        /// Si el Producto esta en el estante lo remueve
        /// </summary>
        /// <param name="e"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Estante operator -(Estante e, Producto p)
        {
            if (e == p)
                e._productos.Remove(p);
            else
                Console.WriteLine("No se pudo remover el producto del Estante.");

            return e;
        }

        /// <summary>
        /// Si el Producto no existe en el Estante lo agrego
        /// </summary>
        /// <param name="estante"></param>
        /// <param name="producto"></param>
        /// <returns></returns>
        public static bool operator +(Estante estante, Producto producto)
        {
            if (estante._productos.Count >= estante._capacidad)
                return false;

            foreach (Producto itemp in estante._productos)
            {
                if (itemp == producto)
                    return false;
            }

            estante._productos.Add(producto);
            return true;

        }

        #endregion


    }
}
