﻿using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker;
using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
        private string EndPoint = Properties.Settings.Default.EndPoint;
        private string Key = Properties.Settings.Default.Key;
        private string Id = Properties.Settings.Default.Id;

        private ObservableCollection<Mensaje> listaMensajes = null;

        public MainWindow()
        {
            InitializeComponent();
            listaMensajes = new ObservableCollection<Mensaje>();
            listaMensajes_ListBox.DataContext = listaMensajes;

        }
        private async Task conexionAsync()
        {
            //Creamos el cliente de QnA
            
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

        private async Task respuestaAsync(Mensaje mensajeUsuario, Mensaje mensajeRespuesta)
        {
           
            try
            {
                string pregunta = mensajeUsuario.Texto;
                QnASearchResultList response = await cliente.Runtime.GenerateAnswerAsync(Id, new QueryDTO { Question = pregunta });

                string respuesta = response.Answers[0].Answer;

                mensajeRespuesta.Texto = respuesta;
                mensajeRespuesta.Emisor = false;
                mensajeRespuesta.Actor = "Robot";
                

            }
            catch (Exception e)
            {
                MessageBox.Show("Fallo de conexión, Comprueba la conexión" + e.Message, "Fallo Conexión", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private async void ProbarConexion_Button_ClickAsync(object sender, RoutedEventArgs e)
        {
           await conexionAsync();
        }

        //COMANDOS DEFINIDOS PARA LA APLICACIÓN

        private void EnviarCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (mensaje_TextBox != null && (mensaje_TextBox.Text.Length != 0))
            {
                e.CanExecute = true;

            }
            else
            {
                e.CanExecute = false;
            }
            
        }

        private void EnviarCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            CrearMensaje();

            mensaje_TextBox.Clear();

        }

       private async void CrearMensaje()
       {
            Mensaje mensajeRespuesta = new Mensaje();
            Mensaje mensajeUsuario = new Mensaje(true,"Usuario", mensaje_TextBox.Text.ToString());//Creamos el mensaje introducido con el usuario y lo añadimos a la lista.
            listaMensajes.Add(mensajeUsuario);
            await respuestaAsync(mensajeUsuario, mensajeRespuesta);//Obtenemos las respuesta y creamos el mensaje con esa respuesta y la añadimos a la lista
            listaMensajes.Add(mensajeRespuesta);

       }

        private void SalirCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            listaMensajes.Clear();

        }

        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (listaMensajes != null && listaMensajes.Count > 0) e.CanExecute = true;
            else e.CanExecute = false;
        }

        private void GuardarCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            GuardarConversacion();

        }

        private void GuardarCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (listaMensajes != null && listaMensajes.Count != 0) e.CanExecute = true;
            else e.CanExecute = false;
        }

        private void PropiedadesCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Configuracion config_Windows = new Configuracion();
            config_Windows.Owner = this;
            config_Windows.ShowDialog();

        }

        private async void ConectarCommand_ExecutedAsync(object sender, ExecutedRoutedEventArgs e)
        {
            await conexionAsync();

        }

        //Metodo para guardar la conversación.
        private void GuardarConversacion()
        {
            // El archivo txt generado se guarda en la ubicación por defecto
            // /bin/Debug/Conversacion.txt
            using (StreamWriter sw = new StreamWriter("Conversacion.txt",false,Encoding.UTF8))
            {
                foreach (Mensaje mensaje in listaMensajes)
                {
                    sw.WriteLine("Actor: " + mensaje.Actor + 
                                " - Mensaje:  " + mensaje.Texto);

                }

                MessageBox.Show("Conversación Guardada con exito","Guardar Conversación",MessageBoxButton.OK,MessageBoxImage.Information);
            }

        }
    }
}
