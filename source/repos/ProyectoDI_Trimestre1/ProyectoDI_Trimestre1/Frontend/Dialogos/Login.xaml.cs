using MahApps.Metro.Controls;
using Microsoft.Extensions.Logging;
using ProyectoDI_Trimestre1.Backend.Modelos;
using ProyectoDI_Trimestre1.Backend.Repositorios;
using System.Linq;
using System.Windows;

namespace ProyectoDI_Trimestre1.Frontend.Dialogos
{

    public partial class Login : MetroWindow
    {
        public Login()
        {
            InitializeComponent();
        }


        private void btn_login_Click(object sender, RoutedEventArgs e) //Accion de dar al botón de login
        {
            if (string.IsNullOrWhiteSpace(txt_user.Text) || string.IsNullOrWhiteSpace(txt_password.Password))
            {
                MessageBox.Show("Por favor, rellene todos los campos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string usuario = txt_user.Text.Trim(); //vaciarme los campos
            string password = txt_password.Password.Trim();

            if (ValidarLogin(usuario, password)) //Situacion correcta, funciona
            {
                MessageBox.Show("Bienvenido, " + usuario, "LOGGEADO CON ÉXITO", MessageBoxButton.OK, MessageBoxImage.Information);
                Window mainWindow = new MainWindow(usuario);
                mainWindow.Show();
                this.Close();
            }
            else //Datos incorrectos
            {
                MessageBox.Show("Usuario o contraseña incorrectos,\ninserte su usuario e contraseña de nuevo", "ERROR DE LOGIN", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool ValidarLogin(string usuario, string password)
        {
            using (var db = new DiinventarioexamenContext())
            {
                // Buscar usuario en la BD
                var user = db.Usuarios.FirstOrDefault(u => u.Username == usuario); //poner campo username 

                if (user == null)
                {
                    return false; // no existe el usuario
                }

                return user.Password == password; // comparar contraseña
            }
        }

    }
}
