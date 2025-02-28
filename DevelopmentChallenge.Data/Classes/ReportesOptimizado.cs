using DevelopmentChallenge.Data.Common;
using DevelopmentChallenge.Data.Interfaces;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{
    public static class ReportesOptimizado
    {
        private static readonly ResourceManager ResourceManager = new ResourceManager("DevelopmentChallenge.Data.Resources.Strings", Assembly.GetExecutingAssembly());

        public static string Imprimir(List<IFormaGeometrica> formas, Idioma idioma)
        {
            var sb = new StringBuilder();
            var culture = ObtenerCultura(idioma);

            if (!formas.Any())
            {
                sb.Append(ResourceManager.GetString("ListaVacia", culture));
            }
            else
            {
                sb.Append(ResourceManager.GetString("ReporteDeFormas", culture));

                var resumenFormas = formas
                    .GroupBy(f => f.Tipo)
                    .Select(g => new
                    {
                        Tipo = g.Key,
                        Cantidad = g.Count(),
                        Area = g.Sum(f => f.CalcularArea()),
                        Perimetro = g.Sum(f => f.CalcularPerimetro())
                    });

                foreach (var resumen in resumenFormas)
                {
                    sb.Append(ObtenerLinea(resumen.Cantidad, resumen.Area, resumen.Perimetro, resumen.Tipo, idioma));
                }

                // FOOTER
                var totalFormas = resumenFormas.Sum(r => r.Cantidad);
                var totalPerimetro = resumenFormas.Sum(r => r.Perimetro);
                var totalArea = resumenFormas.Sum(r => r.Area);

                sb.Append(ResourceManager.GetString("Total", culture));
                sb.Append($"{totalFormas} {ResourceManager.GetString("Formas", culture)} ");
                sb.Append($"{ResourceManager.GetString("Perimetro", culture)} {totalPerimetro:#.##} ");
                sb.Append($"{ResourceManager.GetString("Area", culture)} {totalArea:#.##}");
            }

            return sb.ToString();
        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, FormaGeometricaTipo tipo, Idioma idioma)
        {
            var culture = ObtenerCultura(idioma);
            var keySingular = $"{tipo}Singular";
            var keyPlural = $"{tipo}Plural";
            var nombreForma = cantidad == 1 ? ResourceManager.GetString(keySingular, culture) : ResourceManager.GetString(keyPlural, culture);

            return $"{cantidad} {nombreForma} | {ResourceManager.GetString("Area", culture)} {area:#.##} | {ResourceManager.GetString("Perimetro", culture)} {perimetro:#.##} <br/>";
        }

        private static CultureInfo ObtenerCultura(Idioma idioma)
        {
            switch (idioma)
            {
                case Idioma.Castellano:
                    return new CultureInfo("es");
                case Idioma.Ingles:
                    return new CultureInfo("en");
                case Idioma.Italiano:
                    return new CultureInfo("it");
                default:
                    return CultureInfo.InvariantCulture;
            }
        }
    }
}
