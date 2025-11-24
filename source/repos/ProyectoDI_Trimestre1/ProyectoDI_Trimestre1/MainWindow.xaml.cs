using MahApps.Metro.Controls;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProyectoDI_Trimestre1.Frontend.Dialogos;
using System.Runtime.CompilerServices;
using ProyectoDI_Trimestre1.Backend.Modelos;

namespace ProyectoDI_Trimestre1
{
    public partial class MainWindow : MetroWindow
    {
        private string Nom_Usuario; //Crear una cadena para poner el nombre del usuario
        public MainWindow(string usuario) //el string es el nombre de usuario que me he pasado desde login
        {
            InitializeComponent();
            Nom_Usuario = usuario; //Ponerle valor a la cadena

           //Hacer que el método se pueda ejecutar, como en android studio 
            bienvenido_usuario();
        }

        private void bienvenido_usuario()
        {
            bienvenida_usuario.Text = "Bienvenido " + Nom_Usuario;  //mensaje de bienvenida que sale en la parte de arriba
        }

        private void salir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); //cerrar la aplicación
        }

        private void Crear_Click(object sender, RoutedEventArgs e) //Ventana Dialogo Crear Funko
        {
            MetroWindow Añadir_Figura_Ventana = new Crear_Funko(); //poner value a la ventana que quiero mostrar
            Añadir_Figura_Ventana.Show(); //hacer que se vea dicha ventana
        }

        private void Borrar_Click(object sender, RoutedEventArgs e)
        {
            MetroWindow Eliminar_Figura_Ventana = new Eliminar_Funko(); //poner value a la ventana que quiero mostrar
            Eliminar_Figura_Ventana.Show(); //hacer que se vea dicha ventana
        }
    }
}