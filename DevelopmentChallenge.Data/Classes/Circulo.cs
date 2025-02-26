using DevelopmentChallenge.Data.Common;
using DevelopmentChallenge.Data.Interfaces;
using System;

namespace DevelopmentChallenge.Data.Classes
{
    public class Circulo : FormaGeometrica, IFormaGeometrica
    {
        private readonly decimal _radio;

        public Circulo(decimal radio) : base(FormaGeometricaTipo.Circulo, radio)
        {
            _radio = radio;
        }

        public decimal CalcularArea() => (decimal)Math.PI * (_radio / 2) * (_radio / 2);

        public decimal CalcularPerimetro() => (decimal)Math.PI * _radio;

        public string TraducirForma(int cantidad, int idioma)
        {
            switch (idioma)
            {
                case FormaGeometrica.Castellano: return cantidad == 1 ? "Círculo" : "Círculos";
                case FormaGeometrica.Ingles: return cantidad == 1 ? "Circle" : "Circles";
                case FormaGeometrica.Italiano: return cantidad == 1 ? "Cerchio" : "Cerchi";
                default: return string.Empty;
            }
        }
    }
}
