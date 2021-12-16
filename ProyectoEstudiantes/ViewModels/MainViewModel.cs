using ProyectoEstudiantes.Commands;
using ProyectoEstudiantes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProyectoEstudiantes.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        
        public EstudianteModel Estudiante { set; get; }

        private ViewModelBase selectedViewModel;
        public ViewModelBase SelectedViewModel
        {
            get { return selectedViewModel; }
            set 
            {  
                selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ICommand UpdateViewCommand { set; get; }

        public MainViewModel()
        {
            Estudiante = new EstudianteModel();
            SelectedViewModel = new ViewModelBase();
            UpdateViewCommand = new UpdateViewCommand(this);
        }
    }
}
