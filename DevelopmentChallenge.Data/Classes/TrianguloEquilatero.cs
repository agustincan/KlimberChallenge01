using DevelopmentChallenge.Data.Common;
using DevelopmentChallenge.Data.Interfaces;
using System;

namespace DevelopmentChallenge.Data.Classes
{
    public class TrianguloEquilatero : FormaGeometrica, IFormaGeometrica
    {
        private readonly decimal _lado;

        public TrianguloEquilatero(decimal lado) : base(FormaGeometricaTipo.TrianguloEquilatero, lado)
        {
            _lado = lado;
        }

        public decimal CalcularArea() => ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;

        public decimal CalcularPerimetro() => _lado * 3;

        public string TraducirForma(int cantidad, int idioma)
        {
            switch (idioma)
            {
                case FormaGeometrica.Castellano: return cantidad == 1 ? "Triángulo" : "Triángulos";
                case FormaGeometrica.Ingles: return cantidad == 1 ? "Triangle" : "Triangles";
                case FormaGeometrica.Italiano: return cantidad == 1 ? "Triangolo" : "Triangoli";
                default: return string.Empty;
            }
        }
    }
}
