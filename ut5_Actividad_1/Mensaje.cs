using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ut5_Actividad_1
{
    class Mensaje
    {
        private bool emisor; // sera true si el emisor es una persona y false si el emisor es el bot
        private string texto;

        public bool Emisor
        {
            get { return emisor; }

            set { emisor = value; }
        }

        public string Texto
        {
            get { return texto; }

            set { texto = value; }
        }
        public Mensaje() { }

        public Mensaje(bool emisor, string texto)
        {
            this.emisor = emisor;
            this.texto = texto;
        }
    }
}
