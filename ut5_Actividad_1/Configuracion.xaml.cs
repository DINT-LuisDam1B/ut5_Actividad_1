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
            colorFondo_ComboBox.ItemsSource = typeof(Colors).GetProperties();
            colorUsuario_ComboBox.ItemsSource = typeof(Colors).GetProperties();
            colorRobot_ComboBox.ItemsSource = typeof(Colors).GetProperties();

        }

        private void Aceptar_Button_Click(object sender, RoutedEventArgs e)
        {
            // El item del combobox tiene dos valores donde es nombre del color tipo string es el segundo campo
            // aplicamos String.Split y nos quedamos con el color.
            string[] colorFondo = colorFondo_ComboBox.SelectedValue.ToString().Split(' ');
            string[] colorUsuario = colorUsuario_ComboBox.SelectedValue.ToString().Split(' ');
            string[] colorRobot = colorRobot_ComboBox.SelectedValue.ToString().Split(' ');

            // añadimos el color a las propiedades de configuración definidas previamente
            // como valor por defecto las he puesto todas con valor = "White".
            Properties.Settings.Default.ColorFondo = colorFondo[1];
            Properties.Settings.Default.ColorUsuario = colorUsuario[1];
            Properties.Settings.Default.ColorRobot = colorRobot[1];

            this.Close();
        }

        private void Cancelar_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
