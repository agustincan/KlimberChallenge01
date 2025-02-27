using DevelopmentChallenge.Data.Common;
using DevelopmentChallenge.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{
    public static class Reportes
    {
        
        public static string Imprimir(List<IFormaGeometrica> formas, Idioma idioma)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                if (idioma == Idioma.Castellano)
                    sb.Append("<h1>Lista vacía de formas!</h1>");
                else
                    sb.Append("<h1>Empty list of shapes!</h1>");
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                if (idioma == Idioma.Castellano)
                    sb.Append("<h1>Reporte de Formas</h1>");
                else
                    // default es inglés
                    sb.Append("<h1>Shapes report</h1>");

                var numeroCuadrados = 0;
                var numeroCirculos = 0;
                var numeroTriangulos = 0;

                var areaCuadrados = 0m;
                var areaCirculos = 0m;
                var areaTriangulos = 0m;

                var perimetroCuadrados = 0m;
                var perimetroCirculos = 0m;
                var perimetroTriangulos = 0m;

                foreach (var forma in formas)
                {
                    if (forma.Tipo == FormaGeometricaTipo.Cuadrado)
                    {
                        numeroCuadrados++;
                        areaCuadrados += forma.CalcularArea();
                        perimetroCuadrados += forma.CalcularPerimetro();
                    }
                    if (forma.Tipo == FormaGeometricaTipo.Circulo)
                    {
                        numeroCirculos++;
                        areaCirculos += forma.CalcularArea();
                        perimetroCirculos += forma.CalcularPerimetro();
                    }
                    if (forma.Tipo == FormaGeometricaTipo.TrianguloEquilatero)
                    {
                        numeroTriangulos++;
                        areaTriangulos += forma.CalcularArea();
                        perimetroTriangulos += forma.CalcularPerimetro();
                    }
                }

                sb.Append(ObtenerLinea(numeroCuadrados, areaCuadrados, perimetroCuadrados, FormaGeometricaTipo.Cuadrado, idioma));
                sb.Append(ObtenerLinea(numeroCirculos, areaCirculos, perimetroCirculos, FormaGeometricaTipo.Circulo, idioma));
                sb.Append(ObtenerLinea(numeroTriangulos, areaTriangulos, perimetroTriangulos, FormaGeometricaTipo.TrianguloEquilatero, idioma));

                // FOOTER
                sb.Append("TOTAL:<br/>");
                sb.Append(numeroCuadrados + numeroCirculos + numeroTriangulos + " " + (idioma == Idioma.Castellano ? "formas" : "shapes") + " ");
                sb.Append((idioma == Idioma.Castellano ? "Perimetro " : "Perimeter ") + (perimetroCuadrados + perimetroTriangulos + perimetroCirculos).ToString("#.##") + " ");
                sb.Append("Area " + (areaCuadrados + areaCirculos + areaTriangulos).ToString("#.##"));
            }

            return sb.ToString();
        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, FormaGeometricaTipo tipo, Idioma idioma)
        {
            if (cantidad > 0)
            {
                if (idioma == Idioma.Castellano)
                    return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimetro {perimetro:#.##} <br/>";

                return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimeter {perimetro:#.##} <br/>";
            }

            return string.Empty;
        }

        private static string TraducirForma(FormaGeometricaTipo tipo, int cantidad, Idioma idioma)
        {
            switch (tipo)
            {
                case FormaGeometricaTipo.Cuadrado:
                    if (idioma == Idioma.Castellano) return cantidad == 1 ? "Cuadrado" : "Cuadrados";
                    else return cantidad == 1 ? "Square" : "Squares";
                case FormaGeometricaTipo.Circulo:
                    if (idioma == Idioma.Castellano) return cantidad == 1 ? "Círculo" : "Círculos";
                    else return cantidad == 1 ? "Circle" : "Circles";
                case FormaGeometricaTipo.TrianguloEquilatero:
                    if (idioma == Idioma.Castellano) return cantidad == 1 ? "Triángulo" : "Triángulos";
                    else return cantidad == 1 ? "Triangle" : "Triangles";
            }

            return string.Empty;
        }
    }
}
