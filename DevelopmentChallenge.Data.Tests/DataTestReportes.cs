using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Common;
using DevelopmentChallenge.Data.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DevelopmentChallenge.Data.Tests
{
    [TestClass]
    public class DataTestReportes
    {
        [TestMethod]
        public void Imprimir_ListaVaciaEnCastellano_DevuelveMensajeListaVacia()
        {
            // Arrange
            var formas = new List<IFormaGeometrica>();
            var idioma = Idioma.Castellano;

            // Act
            var resultado = Reportes.Imprimir(formas, idioma);

            // Assert
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>", resultado);
        }

        [TestMethod]
        public void Imprimir_ListaVaciaEnIngles_DevuelveMensajeListaVacia()
        {
            // Arrange
            var formas = new List<IFormaGeometrica>();
            var idioma = Idioma.Ingles;

            // Act
            var resultado = Reportes.Imprimir(formas, idioma);

            // Assert
            Assert.AreEqual("<h1>Empty list of shapes!</h1>", resultado);
        }

        [TestMethod]
        public void Imprimir_ListaConFormasEnCastellano_DevuelveReporte()
        {
            // Arrange
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4)
            };
            var idioma = Idioma.Castellano;

            // Act
            var resultado = Reportes.Imprimir(formas, idioma);

            // Assert
            var esperado = "<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>1 Círculo | Area 28,27 | Perimetro 18,85 <br/>1 Triángulo | Area 6,93 | Perimetro 12 <br/>TOTAL:<br/>3 formas Perimetro 50,85 Area 60,2";
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void Imprimir_ListaConFormasEnIngles_DevuelveReporte()
        {
            // Arrange
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4)
            };
            var idioma = Idioma.Ingles;

            // Act
            var resultado = Reportes.Imprimir(formas, idioma);

            // Assert
            var esperado = "<h1>Shapes report</h1>1 Square | Area 25 | Perimeter 20 <br/>1 Circle | Area 28,27 | Perimeter 18,85 <br/>1 Triangle | Area 6,93 | Perimeter 12 <br/>TOTAL:<br/>3 shapes Perimeter 50,85 Area 60,2";
            Assert.AreEqual(esperado, resultado);
        }
    }
}

