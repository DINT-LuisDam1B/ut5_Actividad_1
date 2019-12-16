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
            string pregunta = "Vas a aprobarlas todas";
            QnASearchResultList response = await cliente.Runtime.GenerateAnswerAsync(Id, new QueryDTO { Question = pregunta });
            string respuesta = response.Answers[0].Answer;
            MessageBox.Show(respuesta,"chat",MessageBoxButton.OK);

        }

        private async void ProbarConexion_Button_ClickAsync(object sender, RoutedEventArgs e)
        {
           await conexionAsync();
        }
    }
}
