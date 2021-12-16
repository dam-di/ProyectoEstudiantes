using ProyectoEstudiantes.Services;
using ProyectoEstudiantes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProyectoEstudiantes.Commands.StudentCommands
{
    class LoadStudentsCommand: ICommand
    {


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            StudentDBHandler.CargarListaFicticia();
            studentTableViewModel.ListaEstudiantes = StudentDBHandler.ObtenerListaEstudiantes();
        }

        public StudentTableViewModel studentTableViewModel;
        public LoadStudentsCommand(StudentTableViewModel studentTableViewModel)
        {
            this.studentTableViewModel = studentTableViewModel;
        }
    }
}
