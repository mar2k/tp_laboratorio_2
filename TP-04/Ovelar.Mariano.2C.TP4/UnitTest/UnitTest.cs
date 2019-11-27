using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void ListaInstanciada()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);
        }

        [TestMethod]
        public void PaquetesConElMismoID()
        {
            Correo correo = new Correo();
            Paquete p1 = new Paquete("Test1", "11111");
            Paquete p2 = new Paquete("Test2", "11111");
            correo += p1;
            try
            {
                correo += p2;
            }
            catch (TrackingIDRepetidoException)
            {
                Assert.Fail("Trackig ID repetido");
            }
        }
    }
}
