using DevelopmentChallenge.Data.Common;
using DevelopmentChallenge.Data.Interfaces;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace DevelopmentChallenge.Data.Classes
{
    public class Trapecio : FormaGeometrica, IFormaGeometrica
    {
        private readonly decimal _baseMayor;
        private readonly decimal _baseMenor;
        private readonly decimal _altura;
        private readonly decimal _lado1;
        private readonly decimal _lado2;
        private readonly ResourceManager _resourceManager;

        public Trapecio(decimal baseMayor, decimal baseMenor, decimal altura, decimal lado1, decimal lado2)
            : base(FormaGeometricaTipo.Trapecio)
        {
            _baseMayor = baseMayor;
            _baseMenor = baseMenor;
            _altura = altura;
            _lado1 = lado1;
            _lado2 = lado2;
            _resourceManager = new ResourceManager("DevelopmentChallenge.Data.Resources.Strings", Assembly.GetExecutingAssembly());
        }

        public decimal CalcularArea() => ((_baseMayor + _baseMenor) / 2) * _altura;

        public decimal CalcularPerimetro() => _baseMayor + _baseMenor + _lado1 + _lado2;

        public string TraducirForma(int cantidad, Idioma idioma)
        {
            CultureInfo culture;
            switch (idioma)
            {
                case Idioma.Castellano:
                    culture = new CultureInfo("es-ES");
                    break;
                case Idioma.Ingles:
                    culture = new CultureInfo("en-US");
                    break;
                case Idioma.Italiano:
                    culture = new CultureInfo("it-IT");
                    break;
                default:
                    culture = CultureInfo.InvariantCulture;
                    break;
            }

            var key = cantidad == 1 ? "Trapecio" : "Trapecios";
            return _resourceManager.GetString(key, culture) ?? string.Empty;
        }
    }
}
