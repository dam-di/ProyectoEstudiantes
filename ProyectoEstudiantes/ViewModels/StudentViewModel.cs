using ProyectoEstudiantes.Commands.StudentCommands;
using ProyectoEstudiantes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProyectoEstudiantes.ViewModels
{
    class StudentViewModel: ViewModelBase
    {
        public EstudianteModel CurrentStudent { get; set; }

        public ICommand NewStudentCommand { get; set; }
        public StudentViewModel()
        {
            CurrentStudent = new EstudianteModel();
            NewStudentCommand = new NewStudentCommand(this);
        }
    }
}
