using MahApps.Metro.Controls;
using Microsoft.EntityFrameworkCore;
using Mysqlx.Cursor;
using Proyecto_Intermodular_Gestion.Backend.Modelo;
using Proyecto_Intermodular_Gestion.Frontend.Mensajes;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Proyecto_Intermodular_Gestion.Frontend.Dialogos
{
    /// <summary>
    /// Interaction logic for Eliminar_Funko.xaml
    /// </summary>
    public partial class Eliminar_Funko : MetroWindow
    {
        public Eliminar_Funko()
        {
            InitializeComponent();
            CargarProductos();
        }


        //Cargar nombres al iniciar la ventana
        private void CargarProductos()
        {
            using (var db = new ProyectoIntermodularContext())
            {
                var productos = db.Productos.OrderBy(p => p.Nombre).ToList();
                nombre_funko_eliminar.ItemsSource = productos;
            }
        }

        //Borrar funko de la BD
        private void Borrar_Click(object sender, RoutedEventArgs e)
        {
            var msg = MensajeOpciones.Crear("¿Seguro?", "¿Quieres borrar la figura?");
            var ventana = new VentanaMensaje(msg);
            ventana.ShowDialog();

            if (!ventana.Resultado)
                return;

            string nombre = nombre_funko_eliminar.Text;

            using (var db = new ProyectoIntermodularContext())
            {
                var producto = db.Productos.FirstOrDefault(p => p.Nombre == nombre);

                if (producto != null)
                {
                    db.Productos.Remove(producto);
                    db.SaveChanges();

                    MensajeInformacion.Mostrar("Funko eliminado correctamente.", "¡Realizado con éxito!");
                    this.Close();
                }
                else
                {
                    MensajeError.Mostrar("No se encontró el Funko.", "Error");
                }
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
