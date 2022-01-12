using Newtonsoft.Json;
using ProyectoEstudiantes.Models;
using ProyectoEstudiantes.Services;
using ProyectoEstudiantes.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        public async void Execute(object parameter)
        {
            StudentDBHandler.CargarListaFicticia();

            RequestModel requestModel = new RequestModel();
            requestModel.route = "/students";
            requestModel.method = "GET";
            requestModel.data = "all";

            ResponseModel responseModel = await APIHandler.ConsultAPI(requestModel);

            if (responseModel.resultOk)
            {
                studentTableViewModel.ListaEstudiantes = JsonConvert.DeserializeObject<ObservableCollection<EstudianteModel>>((string)responseModel.data);
            }
            else
            {
                MessageBox.Show((string)responseModel.data);
            }

            
            //studentTableViewModel.ListaEstudiantes = StudentDBHandler.ObtenerListaEstudiantes();
        }

        public StudentTableViewModel studentTableViewModel;
        public LoadStudentsCommand(StudentTableViewModel studentTableViewModel)
        {
            this.studentTableViewModel = studentTableViewModel;
        }
    }
}
