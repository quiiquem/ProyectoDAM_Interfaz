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
    /// Interaction logic for Eliminar_Funko.xaml
    /// </summary>
    public partial class Eliminar_Funko : MetroWindow
    {
        public Eliminar_Funko()
        {
            InitializeComponent();
        }

        private void Borrar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result_borrar = MessageBox.Show( //Mostrar el cuadro de diálogo de cancelar
  "¿Estás seguro?", "Eliminar Figura", MessageBoxButton.YesNo, MessageBoxImage.Question);
         
            // Si el usuario hace click en si lo cierra
            if (result_borrar == MessageBoxResult.Yes)
            {
                MessageBox.Show("Figura eliminada con éxito", "Eliminado", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close(); //cerrar solo esa ventana en concreto
            }
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result_cancelar = MessageBox.Show( 
                "¿Deseas cancelar la eliminación?", "Cancelar", MessageBoxButton.YesNo, MessageBoxImage.Question);
           
            if (result_cancelar == MessageBoxResult.Yes)
            {
                this.Close(); //cerrar solo esa ventana en concreto
            }
        }
    }
}
