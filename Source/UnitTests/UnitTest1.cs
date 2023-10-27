using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Services;
using DevelopmentChallenge.Data.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestResumenListaVacia()
        {
            var reporte = new ReporteService();

            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                reporte.Imprimir(new List<FormaGeometricaBase>(), TipoIdioma.Castellano));
        }

        [TestMethod]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            var reporte = new ReporteService();

            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                reporte.Imprimir(new List<FormaGeometricaBase>(), TipoIdioma.Ingles));
        }

        [TestMethod]
        public void TestResumenListaVaciaFormasEnItaliano()
        {
            var reporte = new ReporteService();

            Assert.AreEqual("<h1>Elenco vuoto di forme!</h1>",
                reporte.Imprimir(new List<FormaGeometricaBase>(), TipoIdioma.Italiano));
        }

        [TestMethod]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<FormaGeometricaBase> { new Cuadrado(5) };
            var resumen = new ReporteService().Imprimir(cuadrados, TipoIdioma.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestMethod]
        public void TestResumenListaConUnTrapecioRectangulo()
        {
            var trapeciosRectangulos = new List<FormaGeometricaBase> { new TrapecioRectangulo(5,3,4) };
            var resumen = new ReporteService().Imprimir(trapeciosRectangulos, TipoIdioma.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Trapecio rectangulo | Area 16 | Perimetro 16,47 <br/>TOTAL:<br/>1 formas Perimetro 16,47 Area 16", resumen);
        }

        [TestMethod]
        public void TestResumenListaConMasTrapeciosRectangulos()
        {
            var trapeciosRectangulos = new List<FormaGeometricaBase> { new TrapecioRectangulo(5, 3, 4), new TrapecioRectangulo(10, 5, 5) };
            var resumen = new ReporteService().Imprimir(trapeciosRectangulos, TipoIdioma.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>2 Trapecios rectangulos | Area 53,5 | Perimetro 43,54 <br/>TOTAL:<br/>2 formas Perimetro 43,54 Area 53,5", resumen);
        }

        [TestMethod]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<FormaGeometricaBase> {
                new Cuadrado(5),
                new Cuadrado(1),
                new Cuadrado(3),
            };

            var resumen = new ReporteService().Imprimir(cuadrados, TipoIdioma.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestMethod]
        public void TestResumenListaConMasTiposEnIngles()
        {
            var formas = new List<FormaGeometricaBase> {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m),
            };

            var resumen = new ReporteService().Imprimir(formas, TipoIdioma.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestMethod]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<FormaGeometricaBase> {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m),
            };

            var resumen = new ReporteService().Imprimir(formas, TipoIdioma.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Circulos | Area 13,01 | Perimetro 18,06 <br/>3 Triangulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }
    }
}
