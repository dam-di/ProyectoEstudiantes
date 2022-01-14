using Newtonsoft.Json;
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

                if (responseModel.resultOk)
                {
                    vista.E01MostrarEstudiante();
                    studentTableViewModel.CurrentStudent = JsonConvert.DeserializeObject<EstudianteModel>((string)responseModel.data);
                }
                else
                {
                    MessageBox.Show((string)responseModel.data);
                }

            }
            

        }

        public StudentTableViewModel studentTableViewModel { get; set; }
        public FindStudentCommand(StudentTableViewModel studentTableViewModel)
        {
            this.studentTableViewModel = studentTableViewModel;
        }
    }
}
