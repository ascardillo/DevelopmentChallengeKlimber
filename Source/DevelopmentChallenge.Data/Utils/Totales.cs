using DevelopmentChallenge.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevelopmentChallenge.Data.Utils
{
    public static class Totales
    {
        public static List<ResultTotales> ObtenerTotalesFormasGeometricas(List<FormaGeometricaBase> formas)
        {
            var result = new List<ResultTotales>();

            foreach (TipoForma forma in Enum.GetValues(typeof(TipoForma)))
            {
                var formasPorTipo = formas.Where(x => x.Tipo == forma);

                if (!formasPorTipo.Any())
                {
                    continue;
                }

                var totales = new ResultTotales
                {
                    Total = formasPorTipo.Count(),
                    TotalArea = formasPorTipo.Sum(x => x.Area()),
                    TotalPerimetro = formasPorTipo.Sum(x => x.Perimetro()),
                    Descripcion = formasPorTipo.First().Descripcion()
                };
                result.Add(totales);
            }

            return result;
        }
    }
}
