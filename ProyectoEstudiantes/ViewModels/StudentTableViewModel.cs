using ProyectoEstudiantes.Commands.ImagesCommand;
using ProyectoEstudiantes.Commands.StudentCommands;
using ProyectoEstudiantes.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProyectoEstudiantes.ViewModels
{
    class StudentTableViewModel: ViewModelBase
    {

        private ObservableCollection<EstudianteModel> listaEstudiantes { get; set; }
        public ObservableCollection<EstudianteModel> ListaEstudiantes { get { return listaEstudiantes;} 
            set { listaEstudiantes = value; OnPropertyChanged(nameof(ListaEstudiantes)); } }


        public ObservableCollection<string> ListaNotas { get; set; }

        public ICommand LoadStudentsCommand { get; set; }
        public ICommand LoadStudentCommand { get; set; }
        public ICommand CancelarEditarEstudianteCommand { get; set; }
        public ICommand SaveStudentCommand { get; set; }
        public ICommand SaveScoresCommand { get; set; }
        public ICommand DeleteStudentCommand { set; get; }
        public ICommand FindStudentCommand { set; get; }
        public ICommand AddImageCommand { set; get; }
        public ICommand LoadImagesCommand { set; get; }
        public ICommand ZoomImageCommand { set; get; }
        private EstudianteModel currentStudent { get; set; }
        public EstudianteModel CurrentStudent { get { return currentStudent; } 
            set { currentStudent = value; OnPropertyChanged(nameof(CurrentStudent)); } }


        private EstudianteModel selectedStudent;
        public EstudianteModel SelectedStudent { get { return selectedStudent; } set { selectedStudent=value; OnPropertyChanged(nameof(SelectedStudent)); } }

        private ImagesListModel imagesListModel;
        public ImagesListModel ImagesListModel
        {
            get { return imagesListModel; }
            set { imagesListModel = value; OnPropertyChanged(nameof(ImagesListModel)); }
        }

        private byte[] zoomImagen;
        public byte[] ZoomImagen
        {
            set { zoomImagen = value; OnPropertyChanged(nameof(ZoomImagen)); }
            get { return zoomImagen; }
        }

        public StudentTableViewModel()
        {
            ListaEstudiantes = new ObservableCollection<EstudianteModel>();
            LoadStudentsCommand = new LoadStudentsCommand(this);
            LoadStudentCommand = new LoadStudentCommand(this); 
            CancelarEditarEstudianteCommand = new CancelarEditarEstudianteCommand(this);
            SaveStudentCommand = new SaveStudentCommand(this);
            SaveScoresCommand = new SaveScoresCommand(this);
            DeleteStudentCommand = new DeleteStudentCommand(this);
            FindStudentCommand = new FindStudentCommand(this);
            AddImageCommand = new AddImageCommand(this);
            LoadImagesCommand = new LoadImagesCommand(this);
            ZoomImageCommand = new ZoomImageCommand(this);
            CurrentStudent = new EstudianteModel();
            ListaNotas = new ObservableCollection<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "NA" };
        }
    }
}
