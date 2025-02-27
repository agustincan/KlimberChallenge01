using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevelopmentChallenge.Data.Tests
{
    [TestClass]
    public class DataTestRectangulo
    {
        [TestMethod]
        public void CalcularArea_RectanguloConAnchoYAlto_RetornaAreaCorrecta()
        {
            // Arrange
            var rectangulo = new Rectangulo(5, 10);

            // Act
            var area = rectangulo.CalcularArea();

            // Assert
            Assert.AreEqual(50, area);
        }

        [TestMethod]
        public void CalcularPerimetro_RectanguloConAnchoYAlto_RetornaPerimetroCorrecto()
        {
            // Arrange
            var rectangulo = new Rectangulo(5, 10);

            // Act
            var perimetro = rectangulo.CalcularPerimetro();

            // Assert
            Assert.AreEqual(30, perimetro);
        }

        [TestMethod]
        [DataRow(1, Idioma.Castellano, "Rectángulo")]
        [DataRow(2, Idioma.Castellano, "Rectángulos")]
        [DataRow(1, Idioma.Ingles, "Rectangle")]
        [DataRow(2, Idioma.Ingles, "Rectangles")]
        [DataRow(1, Idioma.Italiano, "Rettangolo")]
        [DataRow(2, Idioma.Italiano, "Rettangoli")]
        public void TraducirForma_CantidadEIdioma_RetornaTraduccionCorrecta(int cantidad, Idioma idioma, string traduccionEsperada)
        {
            // Arrange
            var rectangulo = new Rectangulo(5, 10);

            // Act
            var traduccion = rectangulo.TraducirForma(cantidad, idioma);

            // Assert
            Assert.AreEqual(traduccionEsperada, traduccion);
        }
    }
}
