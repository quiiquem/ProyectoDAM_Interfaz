using MahApps.Metro.Controls;
using Proyecto_Intermodular_Gestion.Backend.Modelo;
using Proyecto_Intermodular_Gestion.Frontend.Mensajes;
using System.Windows;
using System.Windows.Input;

namespace Proyecto_Intermodular_Gestion.Frontend.Dialogos
{

    public partial class Login : MetroWindow
    {
        public Login()
        {
            InitializeComponent();

        }

        //Hacer que la tecla enter sea como pulsar el boton de login
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btn_login_Click(sender, e);
            }
        }

        private void btn_login_Click(object sender, RoutedEventArgs e) //Accion de dar al botón de login
        {


            if (string.IsNullOrWhiteSpace(txt_user.Text) || string.IsNullOrWhiteSpace(txt_password.Password))
            {
                MensajeAdvertencia.Mostrar("Por favor, rellene todos los campos.", "Warning");

                return;
            }

            string usuario = txt_user.Text.Trim(); //vaciarme los campos
            string password = txt_password.Password.Trim();

                 if (ValidarLogin(usuario, password)) //Situacion correcta, funciona
                     {
                         MensajeInformacion.Mostrar("Login correcto,\nbienvenido " + usuario, "LOGIN EXITOSO");
                         Window mainWindow = new MainWindow(usuario);
                         mainWindow.Show();
                         this.Close();
                     }
                     else //Datos incorrectos
                     {
                         MensajeError.Mostrar("Usuario o contraseña incorrectos,\ninserte su usuario e contraseña de nuevo", "ERROR DE LOGIN");
                     }
                 }

                 private bool ValidarLogin(string usuario, string password)
                 {
                     using (var db = new ProyectoIntermodularContext())
                     {
                         // Buscar usuario en la BD
                         var user = db.Usuarios.FirstOrDefault(u => u.NomUsuario == usuario); //poner campo username 

                         if (user == null)
                         {
                             return false; // no existe el usuario
                         }

                         return user.Contrasenya_Usuario == password; // comparar contraseña
                     }
                 }

        }
    }
    