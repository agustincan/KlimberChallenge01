using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Common;
using DevelopmentChallenge.Data.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    //[TestFixture]
    [TestClass]
    public class DataTests
    {
        List<IFormaGeometrica> formas;
        public DataTests()
        {
            SetUp();
        }

        private void SetUp()
        {
            formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m)
            };
        }

        [TestMethod]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                Reportes.Imprimir(new List<IFormaGeometrica>(), Idioma.Castellano));
        }

        [TestMethod]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                Reportes.Imprimir(new List<IFormaGeometrica>(), Idioma.Ingles));
        }

        [TestMethod]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<IFormaGeometrica> {new Cuadrado(5)};

            var resumen = Reportes.Imprimir(cuadrados, Idioma.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestMethod]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Cuadrado(1),
                new Cuadrado(3)
            };

            var resumen = Reportes.Imprimir(cuadrados, Idioma.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestMethod]
        public void TestResumenListaConMasTipos()
        {
            var resumen = Reportes.Imprimir(formas, Idioma.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 52,03 | Perimeter 36,13 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 115,73 Area 130,67",
                resumen);
        }

        [TestMethod]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var resumen = Reportes.Imprimir(formas, Idioma.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 52,03 | Perimetro 36,13 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 115,73 Area 130,67",
                resumen);
        }
    }
}
