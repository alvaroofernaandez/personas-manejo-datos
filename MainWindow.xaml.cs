using System.Text;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace Ficheros2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Persona> personas = new List<Persona>();
        String rutaArchivo = "personas.txt";
        int contadorPersonas = 0;

        public MainWindow()
        {
            InitializeComponent();
            string[] lineas = File.ReadAllLines(rutaArchivo);
            int num = (lineas.Length / 3) - (lineas.Length % 3);
            int contador = 0;

            for (int i = 0; i < num; i++)
            {
                personas.Add(new Persona(lineas[contador], lineas[contador + 1], Convert.ToInt32(lineas[contador + 2])));
                contador += 3;
            }
        }

        private void btnPrimero_click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (rutaArchivo.Length > 0)
                {
                    if (File.Exists(rutaArchivo) == true)
                    {
                        txbNombre.Text = personas.First().nombre;
                        txbApellidos.Text = personas.First().apellidos;
                        lblNota.Content = "Nota: " + personas.First().nota;
                        contadorPersonas = 0;
                    }
                    else
                    {
                        MessageBox.Show("Ese archivo no existe o no es encontrado.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Ese archivo está vacío.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAnterior_click(object sender, RoutedEventArgs e)
        {
            if (contadorPersonas > 0) 
            {
                contadorPersonas--;
                txbNombre.Text = personas[contadorPersonas].nombre;
                txbApellidos.Text = personas[contadorPersonas].apellidos;
                lblNota.Content = "Nota: " + personas[contadorPersonas].nota;
            }
            else
            {
                MessageBox.Show("Ya estás en la primera persona.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnSiguiente_click(object sender, RoutedEventArgs e)
        {
            if (contadorPersonas < personas.Count - 1)
            {
                contadorPersonas++;
                txbNombre.Text = personas[contadorPersonas].nombre;
                txbApellidos.Text = personas[contadorPersonas].apellidos;
                lblNota.Content = "Nota: " + personas[contadorPersonas].nota;
            }
            else
            {
                MessageBox.Show("Ya estás en la última persona.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnUltimo_click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (rutaArchivo.Length > 0)
                {
                    if (File.Exists(rutaArchivo) == true)
                    {
                        contadorPersonas = personas.Count - 1;
                        txbNombre.Text = personas.Last().nombre;
                        txbApellidos.Text = personas.Last().apellidos;
                        lblNota.Content = "Nota: " + personas.Last().nota;
                    }
                    else
                    {
                        MessageBox.Show("Ese archivo no existe o no es encontrado.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Ese archivo está vacío.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Ha ocurrido un error.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}