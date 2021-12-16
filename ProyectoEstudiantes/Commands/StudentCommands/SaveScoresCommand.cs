using ProyectoEstudiantes.Services;
using ProyectoEstudiantes.ViewModels;
using ProyectoEstudiantes.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProyectoEstudiantes.Commands.StudentCommands
{
    internal class SaveScoresCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            StudentTableView vista = (StudentTableView)parameter;
            MessageBoxResult result = MessageBox.Show("¿Deseas realizar los cambios?", "Guardar Notas", MessageBoxButton.YesNo);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    bool okguardar = StudentDBHandler.GuardarNotasEstudiante(studentTableViewModel.CurrentStudent);
                    if (okguardar)
                    {
                        MessageBox.Show("Notas guardadas con éxito", "Guardar Notas");
                        vista.E03MostrarNotas();
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar", "Guardar Notas");
                    }
                    break;

                case MessageBoxResult.No:
                    break;

            } 
        }

        public StudentTableViewModel studentTableViewModel { get; set; }
        public SaveScoresCommand(StudentTableViewModel studentTableViewModel)
        {
            this.studentTableViewModel = studentTableViewModel;
        }
    }
}
