using DevelopmentChallenge.Data.Common;
using DevelopmentChallenge.Data.Interfaces;
using System;

namespace DevelopmentChallenge.Data.Classes
{
    public class TrianguloEquilatero : FormaGeometrica, IFormaGeometrica
    {
        private readonly decimal _lado;

        public TrianguloEquilatero(decimal lado) : base(FormaGeometricaTipo.TrianguloEquilatero)
        {
            _lado = lado;
        }

        public decimal CalcularArea() => ((_lado*_lado) * (decimal)Math.Sqrt(3)) / 4;

        public decimal CalcularPerimetro() => _lado * 3;

        public string TraducirForma(int cantidad, Idioma idioma)
        {
            switch (idioma)
            {
                case Idioma.Castellano: return cantidad == 1 ? "Triángulo" : "Triángulos";
                case Idioma.Ingles: return cantidad == 1 ? "Triangle" : "Triangles";
                case Idioma.Italiano: return cantidad == 1 ? "Triangolo" : "Triangoli";
                default: return string.Empty;
            }
        }
    }
}
