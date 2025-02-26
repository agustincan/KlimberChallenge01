using DevelopmentChallenge.Data.Common;

namespace DevelopmentChallenge.Data.Interfaces
{
    public interface IFormaGeometrica
    {
        FormaGeometricaTipo Tipo { get; set; }
        decimal CalcularArea();
        decimal CalcularPerimetro();
        //string Imprimir(int idioma);
    }
}
