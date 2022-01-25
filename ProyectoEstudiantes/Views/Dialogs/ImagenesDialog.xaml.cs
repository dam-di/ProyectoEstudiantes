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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoEstudiantes.Views.Dialogs
{
    /// <summary>
    /// Lógica de interacción para ImagenesDialog.xaml
    /// </summary>
    public partial class ImagenesDialog : UserControl
    {
        public ImagenesDialog()
        {
            InitializeComponent();
        }

        public void E00MostarImagenes()
        {
            stackImages.Visibility = Visibility.Visible;
            stackProcessImages.Visibility = Visibility.Collapsed;
            stackZoom.Visibility = Visibility.Collapsed;
        }

        public void E01ProcesandoImagenes(string mensaje)
        {
            stackImages.Visibility = Visibility.Collapsed;
            stackProcessImages.Visibility = Visibility.Visible;
            barraProgreso.Visibility = Visibility.Visible;
            imgNoDisponible.Visibility = Visibility.Collapsed;
            txtProcess.Text = mensaje;
            stackZoom.Visibility = Visibility.Collapsed;
        }

        public void E02ImagenNoDisponible()
        {
            stackImages.Visibility = Visibility.Collapsed;
            stackProcessImages.Visibility = Visibility.Visible;
            barraProgreso.Visibility = Visibility.Collapsed;
            imgNoDisponible.Visibility = Visibility.Visible;
            txtProcess.Text = "Imagenes no encontradas";
            stackZoom.Visibility = Visibility.Collapsed;
        }

        public void E03ZoomImagen()
        {
            stackImages.Visibility = Visibility.Collapsed;
            stackProcessImages.Visibility = Visibility.Collapsed;
            stackZoom.Visibility = Visibility.Visible;
        }

        private void imgZoom_MouseDown(object sender, MouseButtonEventArgs e)
        {
            E00MostarImagenes();
        }
    }
}
