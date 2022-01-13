using ProyectoEstudiantes.Models;
using ProyectoEstudiantes.Services;
using ProyectoEstudiantes.ViewModels;
using ProyectoEstudiantes.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProyectoEstudiantes.Commands.StudentCommands
{
    class FindStudentCommand : ICommand
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
                RequestModel requestModel = new RequestModel()
                {
                    route = "/students",
                    method = "GET",
                    data = vista.txtDNI.Text
                };

                ResponseModel responseModel = await APIHandler.ConsultAPI(requestModel);

            }
            

        }

        public StudentTableViewModel studentTableViewModel { get; set; }
        public FindStudentCommand(StudentTableViewModel studentTableViewModel)
        {
            this.studentTableViewModel = studentTableViewModel;
        }
    }
}
