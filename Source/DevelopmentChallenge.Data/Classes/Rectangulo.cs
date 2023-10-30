using DevelopmentChallenge.Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public class Rectangulo : FormaGeometricaBase
    {
        private readonly decimal _ladoMenor;
        private readonly decimal _ladoMayor;

        public override TipoForma Tipo => TipoForma.Rectangulo;

        public Rectangulo(decimal ladoMenor, decimal ladoMayor)
        {
            _ladoMenor = ladoMenor;
            _ladoMayor = ladoMayor;
        }

        public override decimal Area()
        {
            return _ladoMenor * _ladoMayor;
        }

        public override string Descripcion()
        {
            return "Rectangulo";
        }

        public override decimal Perimetro()
        {
            return (_ladoMenor * 2 + _ladoMayor * 2);
        } 
    }
}
