using DevelopmentChallenge.Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class TrianguloEquilatero : FormaGeometricaBase
    {
        private readonly decimal _lado;

        public override TipoForma Tipo => TipoForma.TrianguloEquilatero;

        public TrianguloEquilatero(decimal lado)
        {
            _lado = lado;
        }

        public override decimal Area()
        {
            return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
        }

        public override decimal Perimetro()
        {
            return _lado * 3;
        }
    }
}
