using ProyectoEstudiantes.Models;
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

        public async void Execute(object parameter)
        {
            StudentTableView vista = (StudentTableView)parameter;
            MessageBoxResult result = MessageBox.Show("¿Deseas realizar los cambios?", "Modificar", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    RequestModel requestModel = new RequestModel();
                    requestModel.route = "/students";
                    requestModel.method = "PUT";
                    requestModel.data = studentTableViewModel.CurrentStudent;
                    ResponseModel responseModel = await APIHandler.ConsultAPI(requestModel);

                    if (responseModel.resultOk)
                    {
                        vista.E03MostrarNotas();
                        studentTableViewModel.LoadStudentsCommand.Execute("");
                    }

                    MessageBox.Show((string)responseModel.data, "Modificar", MessageBoxButton.OK, MessageBoxImage.Information);
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
