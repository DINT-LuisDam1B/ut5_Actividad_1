using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker;
using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ut5_Actividad_1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private QnAMakerRuntimeClient cliente;
        public MainWindow()
        {
            InitializeComponent();
     
        }

        private void Configuracion_Button_Click(object sender, RoutedEventArgs e)
        {
            Configuracion config_Windows = new Configuracion();
            config_Windows.Owner = this;
            config_Windows.ShowDialog();
        }

        private async Task conexionAsync()
        {
            //Creamos el cliente de QnA
            string EndPoint = Properties.Settings.Default.EndPoint;
            string Key = Properties.Settings.Default.Key;
            string Id = Properties.Settings.Default.Id;
            cliente = new QnAMakerRuntimeClient(new EndpointKeyServiceClientCredentials(Key)) { RuntimeEndpoint = EndPoint };

            //Realizamos la pregunta a la API
            try
            {
                string pregunta = "Vas a aprobarlas todas";
                QnASearchResultList response = await cliente.Runtime.GenerateAnswerAsync(Id, new QueryDTO { Question = pregunta });
                
                MessageBox.Show("Se ha realizado la conexión satisfactoriamente!!.","Conexión",MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }catch (Exception e)
            {
                MessageBox.Show("Fallo de conexión, Comprueba la conexión" + e.Message ,"Fallo Conexión",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            

        }

        private async void ProbarConexion_Button_ClickAsync(object sender, RoutedEventArgs e)
        {
           await conexionAsync();
        }

        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (mensaje_TextBox.Text.Length == 0)
            {
                e.CanExecute = true;

            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
    }
}
