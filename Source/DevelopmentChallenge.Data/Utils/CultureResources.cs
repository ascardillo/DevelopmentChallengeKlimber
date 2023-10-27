using DevelopmentChallenge.Data.Utils;
using DevelopmentChallenge.Data.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Utils
{
    public class CultureResources:ICultureResources { 

        private readonly ResourceManager _resourceManager;

        public CultureResources(string idioma) 
        {
            _resourceManager = new ResourceManager(@"DevelopmentChallenge.Data.Resources.Res", Assembly.GetExecutingAssembly());
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(idioma);
        }

        public string GetValue(string texto, int cantidad = 1)
        {
            if(cantidad > 1)
            {
                texto = texto + "N";
            }
            
            var descripcion = _resourceManager.GetString(texto);
            return descripcion;
        }
        
    }
}
