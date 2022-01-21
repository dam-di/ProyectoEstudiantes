using Newtonsoft.Json;
using ProyectoEstudiantes.Models;
using ProyectoEstudiantes.Services;
using ProyectoEstudiantes.ViewModels;
using ProyectoEstudiantes.Views.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProyectoEstudiantes.Commands.ImagesCommand
{
    class LoadImagesCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {

            if(parameter is ImagenesDialog)
            {
                ImagenesDialog dialog = (ImagenesDialog)parameter;
                dialog.E01ProcesandoImagenes("Espera un poco...");

                studentTableViewModel.ImagesListModel = new ImagesListModel();

                RequestModel requestModel = new RequestModel();
                requestModel.method = "GET";
                requestModel.route = "/images";
                requestModel.data = studentTableViewModel.CurrentStudent._id;

                ResponseModel responseModel = await APIHandler.ConsultAPI(requestModel);
                Console.WriteLine(responseModel.resultOk);

                if (responseModel.resultOk)
                {
                    studentTableViewModel.ImagesListModel = JsonConvert.DeserializeObject<ImagesListModel>((string)responseModel.data);
                    dialog.E00MostarImagenes();
                }
                else
                {
                    //MessageBox.Show((string)responseModel.data);
                    dialog.E01ProcesandoImagenes("No hay nada que mostrar");
                }


            }

            
            
        }

        public StudentTableViewModel studentTableViewModel { set; get; }
        public LoadImagesCommand(StudentTableViewModel studentTableViewModel)
        {
            this.studentTableViewModel = studentTableViewModel;
        }
    }
}
