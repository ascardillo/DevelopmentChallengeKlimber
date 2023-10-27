using DevelopmentChallenge.Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class Circulo : FormaGeometricaBase
    {
        private readonly decimal _lado;

        public override TipoForma Tipo => TipoForma.Circulo;

        public Circulo(decimal diametro)
        {
            _lado = diametro;
        }

        public override decimal Area()
        {
            return (decimal)Math.PI * (_lado / 2) * (_lado / 2);
        }

        public override decimal Perimetro()
        {
            return (decimal)Math.PI * _lado;
        }
    }
}
