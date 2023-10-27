using DevelopmentChallenge.Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Classes
{
    public abstract class FormaGeometricaBase
    {
        public virtual TipoForma Tipo { get; }

        public abstract decimal Area();
        public abstract decimal Perimetro();
    }
}
