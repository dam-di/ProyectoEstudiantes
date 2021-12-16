using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ProyectoEstudiantes.Views
{
    /// <summary>
    /// Lógica de interacción para StudentTableView.xaml
    /// </summary>
    public partial class StudentTableView : UserControl, INotifyPropertyChanged
    {
        public StudentTableView()
        {
            InitializeComponent();
            E00EstadoInicial();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private bool editarActivado;
        public bool EditarActivado { get { return editarActivado; } set { editarActivado = value; OnPropertyChanged(nameof(EditarActivado)); } }

        private bool editarNotasActivado;
        public bool EditarNotasActivado { get { return editarNotasActivado; } set { editarNotasActivado = value; OnPropertyChanged(nameof(EditarNotasActivado));} }

        public string Modo = "estudiante";
        public void E00EstadoInicial()
        {
            stackEstudiante.Visibility = Visibility.Collapsed;
            stackNotas.Visibility = Visibility.Collapsed;

            EditarActivado = false;
            EditarNotasActivado=false;

            txWarning.Text = "";
        }

        public void E01MostrarEstudiante()
        {
            Modo = "estudiante";

            stackEstudiante.Visibility = Visibility.Visible;
            stackNotas.Visibility = Visibility.Collapsed;

            btnCancelar.Visibility = Visibility.Collapsed;
            btnEditarEstudiante.Visibility = Visibility.Visible;
            btnGuardarEstudiante.Visibility = Visibility.Collapsed;

            studentListView.IsEnabled = true;

            EditarActivado = false;

            btnMostrarNotas.IsEnabled = true;

            txWarning.Text = "";

        }

        public void E02ModificarEstudiante()
        {
            btnCancelar.Visibility = Visibility.Visible;
            btnEditarEstudiante.Visibility = Visibility.Collapsed;
            btnGuardarEstudiante.Visibility = Visibility.Visible;

            studentListView.IsEnabled = false;

            EditarActivado = true;

            btnMostrarNotas.IsEnabled = false;
        }

        public void E03MostrarNotas()
        {
            Modo = "notas";

            stackEstudiante.Visibility = Visibility.Collapsed;
            stackNotas.Visibility = Visibility.Visible;

            EditarNotasActivado = false;

            btnEditarNotasEstudiante.Visibility = Visibility.Visible;
            btnGuardarNotasEstudiante.Visibility= Visibility.Collapsed;
            btnNotasCancelar.Visibility = Visibility.Collapsed;

            EditarNotasActivado = false;

            studentListView.IsEnabled = true;

            btnMostrarEstudiante.IsEnabled = true;
        }

        public void E04EditarNotas()
        {
            btnMostrarEstudiante.IsEnabled = false;
            studentListView.IsEnabled=false;

            btnEditarNotasEstudiante.Visibility = Visibility.Collapsed;
            btnGuardarNotasEstudiante.Visibility = Visibility.Visible;
            btnNotasCancelar.Visibility = Visibility.Visible;

            EditarNotasActivado = true;
        }

        private void studentListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Modo.Equals("estudiante"))
            {
                E01MostrarEstudiante();

            }
            else
            {
                E03MostrarNotas();
            }
        }

        private void btnEditarEstudiante_Click(object sender, RoutedEventArgs e)
        {
            E02ModificarEstudiante();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            E01MostrarEstudiante();
        }

        private void btnMostrarNotas_Click(object sender, RoutedEventArgs e)
        {
            E03MostrarNotas();
        }

        private void btnEditarNotasEstudiante_Click(object sender, RoutedEventArgs e)
        {
            E04EditarNotas();
        }

        private void btnNotasCancelar_Click(object sender, RoutedEventArgs e)
        {
            E03MostrarNotas();
        }

        private void btnMostrarEstudiante_Click(object sender, RoutedEventArgs e)
        {
            E01MostrarEstudiante();
        }
    }
}
