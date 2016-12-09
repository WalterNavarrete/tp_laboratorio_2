using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesAbstractas;
using EntidadesInstanciables;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Valido que el DNI no pueda tener ni puntos ni letras.
        /// </summary>
        [TestMethod]
        public void DNI_Invalido_Texto()
        {
            // DNI con punto
            string dniComa = "45.852.454";
            try
            {
                Alumno a = new Alumno(99, "Walter", "Navarrete", dniComa, Persona.ENacionalidad.Argentino, Gimnasio.EClases.Natacion, Alumno.EEstadoCuenta.AlDia);
                Assert.Fail("Sin excepción para DNI inválido: {0}.", dniComa);
            }
            catch (Exception e)
            {
                // DNIInvalidoException lanza NacionalidadInvalidaException siempre.
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }

            // DNI con texto
            string dniTexto = "treintaycuatro456987";
            try
            {
                Alumno a = new Alumno(99, "Walter", "Navarrete", dniTexto, Persona.ENacionalidad.Argentino, Gimnasio.EClases.Natacion, Alumno.EEstadoCuenta.AlDia);
                Assert.Fail("Sin excepción para DNI inválido: {0}.", dniTexto);
            }
            catch (Exception e)
            {
                // DNIInvalidoException lanza NacionalidadInvalidaException siempre.
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }

        /// <summary>
        /// Comprobar que el DNI no pueda ser mayor a 99.999.999
        /// </summary>
        [TestMethod]
        public void DNI_Invalido_Alto()
        {
            //DNI mayor a 99.999.999
            string dniUltimo = "100000000";
            try
            {
                // DNI Invalido?
                Alumno a = new Alumno(99, "Walter", "Navarrete", dniUltimo, Persona.ENacionalidad.Argentino, Gimnasio.EClases.Natacion, Alumno.EEstadoCuenta.AlDia);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
                return;
            }
            Assert.Fail("Sin excepción para DNI inválido: {0}.", dniUltimo);
        }

        [TestMethod]
        public void Gimnasio_InstanciaAtributos_Test()
        {
            Gimnasio gym = new Gimnasio();

            //La lista de alumnos fue instanciada
            Assert.IsNotNull(gym._alumnos);

            //La lista de instructores fue instanciada
            Assert.IsNotNull(gym._instructores);

            //La lista de jornadas fue instanciada
            Assert.IsNotNull(gym._jornadas);
        }

    }
}
