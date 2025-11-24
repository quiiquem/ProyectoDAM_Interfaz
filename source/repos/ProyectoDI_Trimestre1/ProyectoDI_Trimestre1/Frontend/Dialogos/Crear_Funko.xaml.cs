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
using MahApps.Metro.Controls;

namespace ProyectoDI_Trimestre1.Frontend.Dialogos
{
    /// <summary>
    /// Lógica de interacción para Crear_Funko.xaml
    /// </summary>
    public partial class Crear_Funko : MetroWindow
    {
        public Crear_Funko()
        {
            InitializeComponent();
        }


        private void Hay_Stock(object sender, RoutedEventArgs e)
        {
            if (Stock.IsChecked == true)
            {

                Stock.IsChecked = false;
            }
        }




        private void Cancelar_Boton(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show( //Mostrar el cuadro de diálogo de cancelar
     "No has guardado los datos, ¿Estás seguro?","Cancelar",MessageBoxButton.YesNo,MessageBoxImage.Warning
 );

            // Puedes comprobar qué botón pulsó el usuario
            if (result == MessageBoxResult.Yes)
            {
                this.Close(); //cerrar solo esa ventana en concreto
            }
        }

        private void Guardado(object sender, RoutedEventArgs e)
        {
          
        }

     
    }
}