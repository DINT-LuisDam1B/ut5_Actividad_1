using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ut5_Actividad_1
{
    /// <summary>
    /// Lógica de interacción para Configuracion.xaml
    /// </summary>
    public partial class Configuracion : Window
    {
        public Configuracion()
        {
            
            InitializeComponent();
            LoadSystemColors();
          
        }

        public void LoadSystemColors()
        {
            List<ItemColor> sysColorList = new List<ItemColor>();
            Type t = typeof(System.Windows.SystemColors);
            PropertyInfo[] propInfo = t.GetProperties();
            foreach (PropertyInfo p in propInfo)
            {
                if (p.PropertyType == typeof(Color))
                {
                    ItemColor list = new ItemColor();
                    list.Color = (Color)p.GetValue(new Color(),
                        BindingFlags.GetProperty, null, null, null);
                    list.Name = p.Name;

                    sysColorList.Add(list);
                }
                else if (p.PropertyType == typeof(SolidColorBrush))
                {
                    ItemColor list = new ItemColor();
                    list.Color = ((SolidColorBrush)p.GetValue(new SolidColorBrush(),
                        BindingFlags.GetProperty, null, null, null)).Color;
                    list.Name = p.Name;

                    sysColorList.Add(list);
                }
            }
            ColorList_ComboBox.ItemsSource = sysColorList;
        }

    }
}
