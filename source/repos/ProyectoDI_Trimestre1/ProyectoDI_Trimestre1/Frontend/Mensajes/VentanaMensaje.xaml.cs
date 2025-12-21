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
using System.Windows.Shapes;

namespace ProyectoDI_Trimestre1.Frontend.Mensajes
{
    /// <summary>
    /// Interaction logic for VentanaMensaje.xaml
    /// </summary>
    public partial class VentanaMensaje : Window
    {
        MensajeVentana _mensajeVentana;
        public bool Resultado { get; private set; }

        public VentanaMensaje(MensajeVentana mensajeVentana)
        {
            InitializeComponent();
            _mensajeVentana = mensajeVentana;
        }

        private void ventanaDialogoMensaje_Loaded(object sender, RoutedEventArgs e)
        {
            imgMensaje.Source = _mensajeVentana.Imagen;
            tbMensaje.Text = _mensajeVentana.Cuerpo;
            tbTitulo.Text = _mensajeVentana.Titulo;
            Aceptar.Background = _mensajeVentana.ColorDistintivo;

            //Mostrar o ocultar el segundo boton segun el tipo de mensaje que es
            Otra_Opcion.Visibility = _mensajeVentana.MostrarOpciones ? Visibility.Visible : Visibility.Collapsed; 
        }

        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            Resultado = true;
            this.Close();
        }

        private void Opcion_Extra_Click(object sender, RoutedEventArgs e)
        {
            Resultado = false;
            this.Close();
        }


    }
}
