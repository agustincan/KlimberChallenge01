using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevelopmentChallenge.Data.Tests
{
    [TestClass]
    public sealed class DataTestTrapecio
    {
        [TestMethod]
        public void CalcularArea_ValoresValidos_RetornaAreaCorrecta()
        {
            // Arrange
            decimal baseMayor = 10;
            decimal baseMenor = 6;
            decimal altura = 5;
            Trapecio trapecio = new Trapecio(baseMayor, baseMenor, altura, 4, 4);

            // Act
            decimal area = trapecio.CalcularArea();

            // Assert
            Assert.AreEqual(40, area);
        }

        [TestMethod]
        public void CalcularPerimetro_ValoresValidos_RetornaPerimetroCorrecto()
        {
            // Arrange
            decimal baseMayor = 10;
            decimal baseMenor = 6;
            decimal lado1 = 4;
            decimal lado2 = 4;
            Trapecio trapecio = new Trapecio(baseMayor, baseMenor, 5, lado1, lado2);

            // Act
            decimal perimetro = trapecio.CalcularPerimetro();

            // Assert
            Assert.AreEqual(24, perimetro);
        }

        [TestMethod]
        public void TraducirForma_CantidadUno_IdiomaCastellano_RetornaNombreCorrecto()
        {
            // Arrange
            Trapecio trapecio = new Trapecio(10, 6, 5, 4, 4);

            // Act
            string nombre = trapecio.TraducirForma(1, Idioma.Castellano);

            // Assert
            Assert.AreEqual("Trapecio", nombre);
        }

        [TestMethod]
        public void TraducirForma_CantidadMultiples_IdiomaIngles_RetornaNombreCorrecto()
        {
            // Arrange
            Trapecio trapecio = new Trapecio(10, 6, 5, 4, 4);

            // Act
            string nombre = trapecio.TraducirForma(2, Idioma.Ingles);

            // Assert
            Assert.AreEqual("Trapezoids", nombre);
        }
    }
}
