using System;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using System.Windows.Input;
using Proyecto_Intermodular_Gestion.Backend;
using Proyecto_Intermodular_Gestion.Backend.Modelo;
using Proyecto_Intermodular_Gestion.Frontend.Mensajes;

namespace Proyecto_Intermodular_Gestion.Frontend.Dialogos
{
    /// <summary>
    /// Lógica de interacción para Crear_Funko.xaml
    /// </summary>
    public partial class Crear_Funko : MetroWindow
    {
        public Crear_Funko()
        {
            InitializeComponent();
            CargarCategorias();
            CargarUbicaciones();
        }

        //Permitir solo números en algunos textboxs
        private void SoloNumeros(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out _);
        }

        //Permitir solo DECIMALES en algunos textboxs
        private void SoloDecimales(object sender, TextCompositionEventArgs e)
        {
            TextBox tb = sender as TextBox;

            // Permitir solo dígitos y un único separador decimal
            if (char.IsDigit(e.Text, 0))
            {
                e.Handled = false;
            }
            else if ((e.Text == "." || e.Text == ",") && !tb.Text.Contains('.') && !tb.Text.Contains(','))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        //Cargar categorías al iniciar la ventana
        private void CargarCategorias() {
            using (var db = new ProyectoIntermodularContext()) { 
                var categorias = db.Categorias.OrderBy(c => c.Idcategorias).ToList(); 
                categoria_funko.ItemsSource = categorias; } 
        }

        //Cargar ubicaciones al iniciar la ventana
        private void CargarUbicaciones()
        {
            using (var db = new ProyectoIntermodularContext())
            {
                var ubicaciones = db.Ubicacions.OrderBy(u => u.IdUbicacion).ToList();
                ubicacion_funko.ItemsSource = ubicaciones;
            }
        }

        // Evento para marcar/desmarcar stock
        private void Hay_Stock(object sender, RoutedEventArgs e)
        {
            if (Stock.IsChecked == true)
            {
                Stock.IsChecked = false;
            }
        }

        private void Cancelar_Boton(object sender, RoutedEventArgs e)
        {
            var msg = MensajeOpciones.Crear("¿Seguro?", "¿Quieres cancelar la operación?");
            var ventana = new VentanaMensaje(msg);
            ventana.ShowDialog();

            if (ventana.Resultado)
            {
                // Usuario pulsó ACEPTAR
                this.Close();
            }
            else
            {
                // Usuario pulsó CANCELAR
            }

        }

        private void Guardado(object sender, RoutedEventArgs e)
        {
            //Pasar los valores finales para guardar en la BD
            String nombre = nombre_funko.Text;
            decimal.TryParse(precio_funko.Text, out decimal precio); //pasar a decimal el precio, para que concuerde con la BD
            String categoria = categoria_funko.Text;
            int.TryParse(cantidad_stock.Text, out int cantidad); //pasar a int la cantidad, para que concuerde con la BD
            String ubicacion = ubicacion_funko.Text;
            int idubicacion = (int)ubicacion_funko.SelectedValue; //pillar la idUbicacion seleccionada, ya que es PK de FK
            DateTime? fecha = fecha_funko.SelectedDate;

            if(string.IsNullOrWhiteSpace(nombre) || precio <= 0 || string.IsNullOrWhiteSpace(categoria))
            {
                MensajeAdvertencia.Mostrar("Por favor, rellene todos los campos obligatorios.", "Warning");
                return;
            } else
            {
                var producto = new Producto {  //Crear objeto producto
                    Nombre = nombre, 
                    Precio = precio, 
                    CantidadStock = cantidad, 
                    FechaIngreso = fecha, 
                    Categoria = categoria,
                    UbicacionAlmacen = ubicacion,
                    UbicacionIdUbicacion = idubicacion
                };

                //GUARDAR EN LA BD EL PRODUCTO CREADO
                using (var db = new ProyectoIntermodularContext()) { 
                    db.Productos.Add(producto); 
                    db.SaveChanges(); }

                MensajeInformacion.Mostrar("Funko guardado correctamente.", "¡Realizado con éxito!");
                this.Close();

            }

        }

        // Mostrar u ocultar panel de cantidad según el estado del checkbox
        private void Stock_Checked(object sender, RoutedEventArgs e)
        { 
            CantidadStock_Panel.Visibility = Visibility.Visible;
        }

        private void Stock_Unchecked(object sender, RoutedEventArgs e)
        {
            CantidadStock_Panel.Visibility = Visibility.Collapsed;
        }
    }
}
