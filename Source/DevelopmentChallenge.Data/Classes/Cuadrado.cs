using DevelopmentChallenge.Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class Cuadrado : FormaGeometricaBase
    {
        private readonly decimal _lado;

        public override TipoForma Tipo => TipoForma.Cuadrado;

        public Cuadrado(decimal lado)
        {
            _lado = lado;
        }

        public override decimal Area()
        {
            return _lado * _lado;
        }

        public override decimal Perimetro()
        {
            return _lado * 4;
        }
    }
}
