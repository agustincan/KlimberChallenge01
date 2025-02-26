using DevelopmentChallenge.Data.Common;
using DevelopmentChallenge.Data.Interfaces;

namespace DevelopmentChallenge.Data.Classes
{
    public class Cuadrado : FormaGeometrica, IFormaGeometrica
    {
        private readonly decimal _lado;

        public Cuadrado(decimal lado):base(FormaGeometricaTipo.Cuadrado, lado)
        {
            _lado = lado;
        }

        public decimal CalcularArea() => _lado * _lado;

        public decimal CalcularPerimetro() => _lado * 4;

        public string TraducirForma(int cantidad, int idioma)
        {
            switch (idioma)
            {
                case FormaGeometrica.Castellano: return cantidad == 1 ? "Cuadrado" : "Cuadrados";
                case FormaGeometrica.Ingles: return cantidad == 1 ? "Square" : "Squares";
                case FormaGeometrica.Italiano: return cantidad == 1 ? "Quadrato" : "Quadrati";
                default: return string.Empty;
            }
        }
    }
}
