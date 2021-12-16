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
    internal class CancelarEditarEstudianteCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            studentTableViewModel.CurrentStudent = (EstudianteModel)studentTableViewModel.SelectedStudent.Clone();
            studentTableViewModel.CurrentStudent.Notas = (NotasModel)studentTableViewModel.SelectedStudent.Notas.Clone();
        }


        public StudentTableViewModel studentTableViewModel;
        public CancelarEditarEstudianteCommand(StudentTableViewModel studentTableViewModel)
        {
            this.studentTableViewModel = studentTableViewModel;
        }
    }
}
