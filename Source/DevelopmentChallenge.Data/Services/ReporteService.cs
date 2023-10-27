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

        private void AgregarBody(ResultTotalesFormasGeometricas datosFormasGeometricas)
        {
            var totalesCuadrados = datosFormasGeometricas.TotalesCuadrados;
            var totalesCirculos = datosFormasGeometricas.TotalesCirculos;
            var totalesTriangulos = datosFormasGeometricas.TotalesTriangulos;
            var totalesTrapecios = datosFormasGeometricas.TotalesTrapeciosRectangulos;

            AgregarLinea(totalesCuadrados.Total, _culture.GetValue("Cuadrado", totalesCuadrados.Total), totalesCuadrados.TotalArea, totalesCuadrados.TotalPerimetro);
            AgregarLinea(totalesCirculos.Total, _culture.GetValue("Circulo", totalesCirculos.Total), totalesCirculos.TotalArea, totalesCirculos.TotalPerimetro);
            AgregarLinea(totalesTriangulos.Total, _culture.GetValue("Triangulo", totalesTriangulos.Total), totalesTriangulos.TotalArea, totalesTriangulos.TotalPerimetro);
            AgregarLinea(totalesTrapecios.Total, _culture.GetValue("TrapecioRectangulo", totalesTrapecios.Total), totalesTrapecios.TotalArea, totalesTrapecios.TotalPerimetro);
        }

        private void AgregarLinea(int cantidad, string descripcion, decimal area, decimal perimetro)
        {
            if (cantidad == 0)
            {
                return;
            }

            _sb.Append($"{cantidad} {descripcion} | {_culture.GetValue("Area")} {area:#.##} | {_culture.GetValue("Perimetro")} {perimetro:#.##} <br/>");
        }

        private void AgregarFooter(ResultTotalesFormasGeometricas totales)
        {
            _sb.Append(_culture.GetValue("Total").ToUpper() + ":<br/>");

            _sb.Append(
                (totales.TotalesCuadrados.Total
                + totales.TotalesCirculos.Total
                + totales.TotalesTriangulos.Total
                + totales.TotalesTrapeciosRectangulos.Total)
                + $" {_culture.GetValue("Formas").ToLower()} ");

            _sb.Append($"{_culture.GetValue("Perimetro")} " + 
                (totales.TotalesCuadrados.TotalPerimetro 
                + totales.TotalesTriangulos.TotalPerimetro 
                + totales.TotalesCirculos.TotalPerimetro
                + totales.TotalesTrapeciosRectangulos.TotalPerimetro
                ).ToString("#.##") + " ");

            _sb.Append($"{_culture.GetValue("Area")} " + 
                (totales.TotalesCuadrados.TotalArea 
                + totales.TotalesTriangulos.TotalArea 
                + totales.TotalesCirculos.TotalArea
                + totales.TotalesTrapeciosRectangulos.TotalArea
                ).ToString("#.##"));
        }
    }
}
