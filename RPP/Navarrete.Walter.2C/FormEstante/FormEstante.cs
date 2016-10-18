using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using System.IO;
using System.Xml;

namespace FormEstante
{
    public partial class FormEstante : Form
    {
        public FormEstante()
        {
            InitializeComponent();
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            rtxtSalida.Text = "";
            Estante est1;
            Estante est2;
            this.CargarEstante(out est1, out est2);
            rtxtSalida.Text += String.Format("Valor total Estante1: {0}", est1.ValorEstanteTotal);
            rtxtSalida.Text += String.Format("Valor Estante1 sólo de Galletitas: {0}",
           est1.GetValorEstante(Producto.ETipoProducto.Galletita));
            rtxtSalida.Text += String.Format("Contenido Estante1:\n{0}",
           Estante.MostrarEstante(est1));
            rtxtSalida.Text += "Estante ordenado por Marca....\n";
            est1.GetProductos().Sort(FormEstante.OrdenarProductos);
            rtxtSalida.Text += Estante.MostrarEstante(est1);
            est1 = est1 - Producto.ETipoProducto.Galletita;
            rtxtSalida.Text += String.Format("Estante1 sin Galletitas: {0}",
           Estante.MostrarEstante(est1));
            rtxtSalida.Text += String.Format("Contenido Estante2:\n{0}",
           Estante.MostrarEstante(est2));
            est2 -= Producto.ETipoProducto.Todos;
            rtxtSalida.Text += String.Format("Contenido Estante2:\n{0}",
           Estante.MostrarEstante(est2));
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            rtxtSalida.Text = "";
            Estante est1;
            Estante est2;
            this.CargarEstante(out est1, out est2);
            rtxtSalida.Text += "Estante 1 ordenado por Marca....\n";
            est1.GetProductos().Sort(FormEstante.OrdenarProductos);
            rtxtSalida.Text += Estante.MostrarEstante(est1);
            rtxtSalida.Text += "Estante 2 ordenado por Marca....\n";
            est2.GetProductos().Sort(FormEstante.OrdenarProductos);
            rtxtSalida.Text += Estante.MostrarEstante(est2);
        }

        private void CargarEstante(out Estante est1, out Estante est2)
        {
            
            est1 = new Estante(4);
            est2 = new Estante(3);
            Harina h1 = new Harina(102, 37.5f, Producto.EMarcaProducto.Favorita,
            Harina.ETipoHarina.CuatroCeros);
            Harina h2 = new Harina(103, 40.25f, Producto.EMarcaProducto.Favorita,
            Harina.ETipoHarina.Integral);
            Galletita g1 = new Galletita(113, 33.65f, Producto.EMarcaProducto.Pitusas, 250f);
            Galletita g2 = new Galletita(111, 56f, Producto.EMarcaProducto.Diversión, 500f);
            Jugo j1 = new Jugo(112, 25f, Producto.EMarcaProducto.Naranjú, Jugo.ESaborJugo.Pasable);
            Jugo j2 = new Jugo(333, 33f, Producto.EMarcaProducto.Swift, Jugo.ESaborJugo.Asqueroso);
            Gaseosa g = new Gaseosa(j2, 2250f);
            if (!(est1 + h1))
            {
                Console.WriteLine("No se pudo agregar el producto al estante!!!");
            }
            if (!(est1 + g1))
            {
                Console.WriteLine("No se pudo agregar el producto al estante!!!");
            }
            if (!(est1 + g2))
            {
                Console.WriteLine("No se pudo agregar el producto al estante!!!");
            }
            if (!(est1 + g1))
            {
                Console.WriteLine("No se pudo agregar el producto al estante!!!");
            }
            if (!(est1 + j1))
            {
                Console.WriteLine("No se pudo agregar el producto al estante!!!");
            }
            if (!(est2 + h2))
            {
                Console.WriteLine("No se pudo agregar el producto al estante!!!");
            }
            if (!(est2 + j2))
            {
                Console.WriteLine("No se pudo agregar el producto al estante!!!");
            }
            if (!(est2 + g))
            {
                Console.WriteLine("No se pudo agregar el producto al estante!!!");
            }
            if (!(est2 + g1))
            {
                Console.WriteLine("No se pudo agregar el producto al estante!!!");
            }


            File.Delete("../../../Estante.txt");
            File.Delete("../../../Estante.xml");
            GuardarEstante(est1);
            GuardarEstante(est2);
            SerializarEstante(est1);
            SerializarEstante(est2);

            DeserializarEstante();

        }

        /// <summary>
        /// Ordena los productos del estante por marca
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private static int OrdenarProductos(Producto p1, Producto p2)
        {
            return string.Compare((p1.Marca).ToString(), (p2.Marca).ToString());
        }

        /// <summary>
        /// Guarda en un archivo de texto toda la informacion del Estante y sus Productos
        /// </summary>
        /// <param name="e"></param>
        public static void GuardarEstante(Estante e)
        {
            string lines = Estante.MostrarEstante(e);

            System.IO.StreamWriter file = new System.IO.StreamWriter("../../../Estante.txt");
            file.WriteLine(lines);

            file.Close();

        }

        /// <summary>
        /// Guarda en un archivo xml toda la informacion del Estante y sus Productos
        /// </summary>
        /// <param name="e"></param>
        private static void SerializarEstante(Estante e)
        {

            XmlDocument doc = new XmlDocument();
            XmlElement raiz = doc.CreateElement("estante");
            doc.AppendChild(raiz);

            foreach (Producto p in e.GetProductos())
            {
                XmlElement producto = doc.CreateElement("PRODUCTO");
                raiz.AppendChild(producto);
                XmlElement marca = doc.CreateElement("MARCA");
                marca.AppendChild(doc.CreateTextNode(p.Marca.ToString()));
                producto.AppendChild(marca);
                XmlElement codigo = doc.CreateElement("CODIGO_BARRA");
                codigo.AppendChild(doc.CreateTextNode(((int)p).ToString()));
                producto.AppendChild(codigo);
                XmlElement precio = doc.CreateElement("PRECIO");
                precio.AppendChild(doc.CreateTextNode(p.Precio.ToString()));
                producto.AppendChild(precio);             
            }

            doc.Save("../../../Estante.xml");

        }

        public static void DeserializarEstante()
        {
            XmlTextReader reader = new XmlTextReader("../../../Estante.xml");
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        Console.Write("<" + reader.Name);
                        Console.WriteLine(">");
                        break;
                    case XmlNodeType.Text:
                        Console.WriteLine(reader.Value);
                        break;
                    case XmlNodeType.EndElement:
                        Console.Write("</" + reader.Name);
                        Console.WriteLine(">");
                        break;
                }
            }
            Console.ReadLine();
        }

    }
}
