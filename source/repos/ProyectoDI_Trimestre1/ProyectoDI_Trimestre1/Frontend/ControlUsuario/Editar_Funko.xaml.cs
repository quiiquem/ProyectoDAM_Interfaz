using MahApps.Metro.Controls;
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

namespace Proyecto_Intermodular_Gestion.Frontend.ControlUsuario
{
    /// <summary>
    /// Lógica de interacción para Editar_Funko.xaml
    /// </summary>
    public partial class Editar_Funko : MetroWindow
    {
        public Editar_Funko()
        {
            InitializeComponent();
            CargarProductos();
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

        //Cargar Productos
        private void CargarProductos()
        {
            using (var db = new ProyectoIntermodularContext())
            {
                var productos = db.Productos.OrderBy(p => p.Nombre).ToList();
                funko_elegido_editar.ItemsSource = productos;
            }
        }


        //Cargar Categorias al iniciar la ventana
        private void CargarCategorias()
        {
            using (var db = new ProyectoIntermodularContext())
            {
                var categorias = db.Categorias.OrderBy(c => c.Idcategorias).ToList();
                categoria_funko_editar.ItemsSource = categorias;
            }
        }


        //Cargar Ubicaciones al iniciar la ventana
        private void CargarUbicaciones()
        {
            using (var db = new ProyectoIntermodularContext())
            {
                var ubicaciones = db.Ubicacions.OrderBy(u => u.IdUbicacion).ToList();
                funko_ubicacion_editar.ItemsSource = ubicaciones;
            }
        }

        private void Mostrar_Datos(object sender, SelectionChangedEventArgs e)
        {
            //Cambiar propiedades del boton en interfaz
            Boton_Guardar.Foreground = Brushes.White;
            Boton_Guardar.Background = Brushes.DarkBlue;
            Boton_Guardar.BorderBrush = Brushes.DarkBlue;

            //Poner los datos del producto para editar
            if (funko_elegido_editar.SelectedItem is Producto p)
            {
                // Mostrar panel
                Mostrar_Opciones.Visibility = Visibility.Visible;
                this.Height = 450;

                // Rellenar campos
                txt_nombre_funko_editar.Text = p.Nombre;
                txt_precio_funko_editar.Text = p.Precio.ToString();
                categoria_funko_editar.Text = p.Categoria;
                stock_funko_editar.Text = p.CantidadStock.ToString();
                fecha_funko_editar.SelectedDate = p.FechaIngreso;

                // Categoria (SelectedValuePath = IdCategoria)
                categoria_funko_editar.SelectedValue = p.Categoria;

                // Ubicación (SelectedValuePath = IdUbicacion)
                funko_ubicacion_editar.SelectedValue = p.UbicacionIdUbicacion;
            }
            else
            {
                Mostrar_Opciones.Visibility = Visibility.Collapsed;
                this.Height = 250;
            }
        }


        //Boton cancelar
        private void Cancelar_Click(object sender, RoutedEventArgs e)
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

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            if (funko_elegido_editar.SelectedItem == null)
            {
                MensajeError.Mostrar("Error", "Debes seleccionar un Funko para editar.");
                return;
            }

            var msg = MensajeOpciones.Crear("¿Seguro?", "¿Quieres guardar los cambios?");
            var ventana = new VentanaMensaje(msg);
            ventana.ShowDialog();

            if (ventana.Resultado)
            {
                
                // Obtener datos del formulario
                string nombre = txt_nombre_funko_editar.Text;
                decimal.TryParse(txt_precio_funko_editar.Text, out decimal precio);
                string categoria = categoria_funko_editar.Text;

                int.TryParse(stock_funko_editar.Text, out int cantidad);
                int idubicacion = (int)funko_ubicacion_editar.SelectedValue;
                DateTime? fecha = fecha_funko_editar.SelectedDate;

                if(nombre.Length== 0 || precio <= 0 || categoria.Length==0)
                {
                    MensajeError.Mostrar("Error", "Por favor, rellena todos los campos correctamente.");
                    return;
                }

                // Obtener el producto original
                var producto = funko_elegido_editar.SelectedItem as Producto;

                // Asignar los nuevos valores
                producto.Nombre = nombre;
                producto.Precio = precio;
                producto.CantidadStock = cantidad;
                producto.FechaIngreso = fecha;
                producto.Categoria = categoria;
                
                producto.UbicacionIdUbicacion = idubicacion;

                // Guardar cambios en la BD
                using (var db = new ProyectoIntermodularContext())
                {
                    db.Productos.Update(producto);
                    db.SaveChanges();
                }

                MensajeInformacion.Mostrar("Funko guardado correctamente.", "¡Realizado con éxito!");
                this.Close();
            } else { 
            MensajeAdvertencia.Mostrar("Operación cancelada.", "Advertencia");
            }
        }
    }
}
