using ProyectoEstudiantes.Models;
using ProyectoEstudiantes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProyectoEstudiantes.Commands.StudentCommands
{
    class LoadStudentCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if( parameter != null)
            {
                EstudianteModel estudiante = (EstudianteModel)parameter;

                studentTableViewModel.CurrentStudent = (EstudianteModel)estudiante.Clone();
                studentTableViewModel.CurrentStudent.Notas = (NotasModel)estudiante.Notas.Clone();

                studentTableViewModel.SelectedStudent = (EstudianteModel)estudiante.Clone();
                studentTableViewModel.SelectedStudent.Notas = (NotasModel)estudiante.Notas.Clone();
            }
            

        }

        public StudentTableViewModel studentTableViewModel { get; set; }
        public LoadStudentCommand(StudentTableViewModel studentTableViewModel)
        {
            this.studentTableViewModel = studentTableViewModel;
        }
    }
}
