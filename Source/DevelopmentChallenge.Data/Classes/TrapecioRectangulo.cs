using DevelopmentChallenge.Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class TrapecioRectangulo : FormaGeometricaBase
    {
        private readonly decimal _baseMenor;
        private readonly decimal _baseMayor;
        private readonly decimal _altura;


        public override TipoForma Tipo => TipoForma.TrapecioRectangulo;

        public TrapecioRectangulo(decimal baseMayor, decimal baseMenor, decimal altura)
        {
            _baseMayor = baseMayor;
            _baseMenor = baseMenor;
            _altura = altura;
        }

        public override decimal Area()
        {
            return (_baseMenor + _baseMayor) * _altura / 2 ;
        }

        public override decimal Perimetro()
        {
            double ladoPerpendicular = Math.Sqrt( Math.Pow((double)(_baseMayor - _baseMenor), 2) + Math.Pow((double)_altura, 2) );

            return _altura + _baseMayor + _baseMenor + (decimal)ladoPerpendicular;
        }
    }
}
