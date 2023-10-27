using DevelopmentChallenge.Data.Classes;
using System.Collections.Generic;
using System.Linq;

namespace DevelopmentChallenge.Data.Utils
{
    public static class Totales
    {
        public static ResultTotalesFormasGeometricas ObtenerTotalesFormasGeometricas(List<FormaGeometricaBase> formas)
        {
            return new ResultTotalesFormasGeometricas()
            {
                TotalesCuadrados = ObtenerTotales(formas, TipoForma.Cuadrado),
                TotalesCirculos = ObtenerTotales(formas, TipoForma.Circulo),
                TotalesTriangulos = ObtenerTotales(formas, TipoForma.TrianguloEquilatero),
                TotalesTrapeciosRectangulos = ObtenerTotales(formas, TipoForma.TrapecioRectangulo)
            };
        }

        private static ResultTotales ObtenerTotales(List<FormaGeometricaBase> formas, TipoForma tipoForma)
        {
            var formasGeometricas = formas.Where(x => x.Tipo == tipoForma);

            var result = new ResultTotales
            {
                Total = formasGeometricas.Count(),
                TotalArea = formasGeometricas.Sum(x => x.Area()),
                TotalPerimetro = formasGeometricas.Sum(x => x.Perimetro()),
            };

            return result;
        }
    }
}
