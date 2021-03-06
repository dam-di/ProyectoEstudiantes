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
    class AddImageCommand : ICommand
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

                var bitmapImage = ImagesHandler.GetBitmapFromFile();
                if (bitmapImage != null)
                {
                    ImagenesDialog dialog = (ImagenesDialog)parameter;

                    ImageModel imageModel = new ImageModel();
                    imageModel._id = studentTableViewModel.CurrentStudent._id;
                    string _idI = bitmapImage.UriSource.Segments.Last().ToString().Replace(".", string.Empty);
                    imageModel.imagenes.Add(_idI, ImagesHandler.EncodeImage(bitmapImage));


                    RequestModel requestModel = new RequestModel();
                    requestModel.method = "POST";
                    requestModel.route = "/images";
                    requestModel.data = imageModel;

                    dialog.E01ProcesandoImagenes("Insertando imagen...");
                    ResponseModel responseModel = await APIHandler.ConsultAPI(requestModel);
                    
                    if (responseModel.resultOk)
                    {
                        
                        studentTableViewModel.LoadImagesCommand.Execute(dialog);
                        MessageBox.Show((string)responseModel.data);
                    }
                }
            }
            

        }

        public StudentTableViewModel studentTableViewModel { set; get; }
        public AddImageCommand(StudentTableViewModel studentTableViewModel)
        {
            this.studentTableViewModel = studentTableViewModel;
        }
    }
}
