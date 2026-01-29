using MahApps.Metro.Controls;
using Proyecto_Intermodular_Gestion.Frontend.ControlUsuario;
using Proyecto_Intermodular_Gestion.Frontend.Dialogos;
using System.Windows;

namespace Proyecto_Intermodular_Gestion
{ 
    public partial class MainWindow : MetroWindow
    {
        private string Nom_Usuario; //Crear una cadena para poner el nombre del usuario
        public MainWindow(string usuario) //el string es el nombre de usuario que me he pasado desde login
        {
            InitializeComponent();
            Nom_Usuario = usuario.ToUpper(); //Ponerle valor a la cadena

           //Hacer que el método se pueda ejecutar, como en android studio 
            bienvenido_usuario();
        }

        //Botones de la barra horizontal azul de arriba
        private void bienvenido_usuario()
        {
            bienvenida_usuario.Text = "Bienvenido, " + Nom_Usuario;  //mensaje de bienvenida que sale en la parte de arriba
        }
        private void min_window_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized; //maximizar la ventana
        }

        private void max_window_Click(object sender, RoutedEventArgs e)
        {
            bool estamax = false;
            
            if (estamax == false){
                this.WindowState = WindowState.Maximized; //maximizar la ventana
                estamax = true;
            }
            else
            {
                this.WindowState = WindowState.Normal; //restaurar la ventana
                estamax = false;
            }

            this.WindowState = WindowState.Maximized; //maximizar la ventana
        }
        private void salir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); //cerrar la aplicación
        }




        //Botones que abren dialogos (Crear, Borrar, Modificar...)

        //Por ahora Localizar Click solo va a tener que salga en mainwindow, conforme tenga más eventualmente moveré todo a la misma ventana

        //Crear Funko
        private void Crear_Click(object sender, RoutedEventArgs e) //Ventana Dialogo Crear Funko
        {
            MetroWindow Añadir_Figura_Ventana = new Crear_Funko(); //poner value a la ventana que quiero mostrar
            Añadir_Figura_Ventana.Show(); //hacer que se vea dicha ventana
        }

        //Crear Borrar Funko
        private void Borrar_Click(object sender, RoutedEventArgs e)
        {
            MetroWindow Eliminar_Figura_Ventana = new Eliminar_Funko(); //poner value a la ventana que quiero mostrar
            Eliminar_Figura_Ventana.Show(); //hacer que se vea dicha ventana
        }

        private void Editar_Click(object sender, RoutedEventArgs e)
        {
            MetroWindow Editar_Figura_Ventana = new Editar_Funko(); //poner value a la ventana que quiero mostrar
            Editar_Figura_Ventana.Show(); //hacer que se vea dicha ventana
        }

        private void Localizar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}