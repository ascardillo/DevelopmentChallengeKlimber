using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Services
{
    public interface IReporteServices
    {
        string Imprimir(List<FormaGeometricaBase> formas, string idioma);
    }
}
