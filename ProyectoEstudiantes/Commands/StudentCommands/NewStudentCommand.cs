using ProyectoEstudiantes.Models;
using ProyectoEstudiantes.Services;
using ProyectoEstudiantes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProyectoEstudiantes.Commands.StudentCommands
{
    class NewStudentCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            //bool okinsertar = await StudentDBHandler.NuevoEstudiante(studentViewModel.CurrentStudent);
            RequestModel requestModel = new RequestModel();
            requestModel.route = "/students";
            requestModel.method = "POST";
            requestModel.data = studentViewModel.CurrentStudent;
            ResponseModel responseModel =  await APIHandler.ConsultAPI(requestModel);

            if (responseModel.resultOk)
            {
                MessageBox.Show("Se ha creado el estudiante");
            }
            else
            {
                MessageBox.Show("Error al crear");
            }
        }

        private StudentViewModel studentViewModel;
        public NewStudentCommand(StudentViewModel studentViewModel)
        {
            this.studentViewModel = studentViewModel;
        }
    }
}
