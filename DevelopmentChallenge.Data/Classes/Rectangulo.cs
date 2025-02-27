using DevelopmentChallenge.Data.Common;
using DevelopmentChallenge.Data.Interfaces;

namespace DevelopmentChallenge.Data.Classes
{
    public class Rectangulo : FormaGeometrica, IFormaGeometrica
    {
        private readonly decimal _ancho;
        private readonly decimal _alto;

        public Rectangulo(decimal ancho, decimal alto) : base(FormaGeometricaTipo.Rectangulo)
        {
            _ancho = ancho;
            _alto = alto;
        }

        public decimal CalcularArea() => _ancho * _alto;

        public decimal CalcularPerimetro() => 2 * (_ancho + _alto);

        public string TraducirForma(int cantidad, Idioma idioma)
        {
            switch (idioma)
            {
                case Idioma.Castellano: return cantidad == 1 ? "Rectángulo" : "Rectángulos";
                case Idioma.Ingles: return cantidad == 1 ? "Rectangle" : "Rectangles";
                case Idioma.Italiano: return cantidad == 1 ? "Rettangolo" : "Rettangoli";
                default: return string.Empty;
            }
        }
    }
}
