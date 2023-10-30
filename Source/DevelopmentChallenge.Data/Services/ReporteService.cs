using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Resources;
using DevelopmentChallenge.Data.Utils;
using DevelopmentChallenge.Data.Utils.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Services
{
    public class ReporteService : IReporteServices
    {
        ICultureResources _culture;
        StringBuilder _sb;

        public ReporteService() { }

        public string Imprimir(List<FormaGeometricaBase> formas, string idioma)
        {
            _sb = new StringBuilder();
            _culture = new CultureResources(idioma);

            if (!formas.Any())
            {
                _sb.Append($"<h1>{_culture.GetValue("ListaVaciaDeFormas")}!</h1>");
                return _sb.ToString();
            }

            var datosFormasGeometricas = Totales.ObtenerTotalesFormasGeometricas(formas);

            AgregarHeader();
            AgregarBody(datosFormasGeometricas);
            AgregarFooter(datosFormasGeometricas);

            return _sb.ToString();
        }

        private void AgregarHeader()
        {
            _sb.Append($"<h1>{_culture.GetValue("ReporteDeFormas")}</h1>");
        }

        private void AgregarBody(List<ResultTotales> resultTotales)
        {
            foreach (var totales in resultTotales)
            {
                AgregarLinea(totales.Total,
                    _culture.GetValue(totales.Descripcion, totales.Total),
                    totales.TotalArea, 
                    totales.TotalPerimetro);
            }
        }

        private void AgregarLinea(int cantidad, string descripcion, decimal area, decimal perimetro)
        {
            if (cantidad == 0)
            {
                return;
            }

            _sb.Append($"{cantidad} {descripcion} | {_culture.GetValue("Area")} {area:#.##} | {_culture.GetValue("Perimetro")} {perimetro:#.##} <br/>");
        }

        private void AgregarFooter(List<ResultTotales> totales)
        {
            _sb.Append(_culture.GetValue("Total").ToUpper() + ":<br/>");

            _sb.Append(
                (totales.Sum(x => x.Total))
                + $" {_culture.GetValue("Formas").ToLower()} ");

            _sb.Append($"{_culture.GetValue("Perimetro")} " + 
                (totales.Sum(s => s.TotalPerimetro)
                ).ToString("#.##") + " ");

            _sb.Append($"{_culture.GetValue("Area")} " + 
                (totales.Sum(s => s.TotalArea)
                ).ToString("#.##"));
        }
    }
}
