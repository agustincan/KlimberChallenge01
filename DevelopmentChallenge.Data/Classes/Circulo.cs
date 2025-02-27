using DevelopmentChallenge.Data.Common;
using DevelopmentChallenge.Data.Interfaces;
using System;

namespace DevelopmentChallenge.Data.Classes
{
    public class Circulo : FormaGeometrica, IFormaGeometrica
    {
        private readonly decimal _radio;

        public Circulo(decimal radio) : base(FormaGeometricaTipo.Circulo)
        {
            _radio = radio;
        }

        public decimal CalcularArea() => (decimal)Math.PI * (_radio * _radio);

        public decimal CalcularPerimetro() => (decimal)Math.PI * (_radio*2);

        public string TraducirForma(int cantidad, Idioma idioma)
        {
            switch (idioma)
            {
                case Idioma.Castellano: return cantidad == 1 ? "Círculo" : "Círculos";
                case Idioma.Ingles: return cantidad == 1 ? "Circle" : "Circles";
                case Idioma.Italiano: return cantidad == 1 ? "Cerchio" : "Cerchi";
                default: return string.Empty;
            }
        }
    }
}
