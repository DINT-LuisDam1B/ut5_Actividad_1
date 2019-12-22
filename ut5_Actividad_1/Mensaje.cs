using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ut5_Actividad_1
{
    class Mensaje : INotifyPropertyChanged

    {
        public bool emisor; // sera true si el emisor es una persona y false si el emisor es el bot
        private string actor; // campo con valor "Usuario" o "Robot", mas eficiente podria ser una enumeración con estos dos campos.
        private string texto;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool Emisor
        {
            get { return emisor; }

            set {
                emisor = value;
                this.NotifyPropertyChanged("Emisor");
            }
        }

        public string Actor
        {
            get { return actor; }

            set { actor = value; }
        }

        public string Texto
        {
            get { return texto; }

            set { texto = value; }
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Mensaje() { }

        public Mensaje(bool emisor,string actor, string texto)
        {
            this.emisor = emisor;
            this.actor = actor;
            this.texto = texto;
        }
    }
}
