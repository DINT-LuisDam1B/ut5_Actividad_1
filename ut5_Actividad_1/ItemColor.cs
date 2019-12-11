using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ut5_Actividad_1
{
    class ItemColor
    {
        public string Name { get; set; }

        private Color _color;
        public Color Color
        {
            get {
                return (SolidColorBrush)_color;
                }
            set;
        }

    }
}
