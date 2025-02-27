using DevelopmentChallenge.Data.Common;
using DevelopmentChallenge.Data.Interfaces;

namespace DevelopmentChallenge.Data.Classes
{
    public class Cuadrado : FormaGeometrica, IFormaGeometrica
    {
        private readonly decimal _lado;

        public Cuadrado(decimal lado):base(FormaGeometricaTipo.Cuadrado)
        {
            _lado = lado;
        }

        public decimal CalcularArea() => _lado * _lado;

        public decimal CalcularPerimetro() => _lado * 4;

        public string TraducirForma(int cantidad, Idioma idioma)
        {
            switch (idioma)
            {
                case Idioma.Castellano: return cantidad == 1 ? "Cuadrado" : "Cuadrados";
                case Idioma.Ingles: return cantidad == 1 ? "Square" : "Squares";
                case Idioma.Italiano: return cantidad == 1 ? "Quadrato" : "Quadrati";
                default: return string.Empty;
            }
        }
    }
}
