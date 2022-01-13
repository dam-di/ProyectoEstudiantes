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
    class DeleteStudentCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            if(parameter is StudentTableView)
            {
                StudentTableView vista = (StudentTableView)parameter;

                MessageBoxResult result = MessageBox.Show("¿Deseas borrar este registro?", "Borrar", MessageBoxButton.YesNo, MessageBoxImage.Stop);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        RequestModel requestModel = new RequestModel();
                        requestModel.route = "/students";
                        requestModel.method = "DELETE";
                        requestModel.data = studentTableViewModel.CurrentStudent._id;
                        ResponseModel responseModel = await APIHandler.ConsultAPI(requestModel);

                        if (responseModel.resultOk)
                        {
                            studentTableViewModel.LoadStudentsCommand.Execute("");
                            vista.studentListView.SelectedIndex = 0;
                        }

                        MessageBox.Show((string)responseModel.data);

                        break;

                    case MessageBoxResult.No:
                        break;
                }
            }

            
        }

        public StudentTableViewModel studentTableViewModel { set; get; }
        public DeleteStudentCommand(StudentTableViewModel studentTableViewModel)
        {
            this.studentTableViewModel = studentTableViewModel;
        }
    }
}
