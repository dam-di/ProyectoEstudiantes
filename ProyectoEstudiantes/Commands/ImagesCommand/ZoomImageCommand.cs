using ProyectoEstudiantes.ViewModels;
using ProyectoEstudiantes.Views.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProyectoEstudiantes.Commands.ImagesCommand
{
    class ZoomImageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter is ImagenesDialog)
            {
                ImagenesDialog dialog = (ImagenesDialog)parameter;
                Dictionary<string, byte[]> imagenDict = (Dictionary<string, byte[]>)dialog.listBoxImages.SelectedValue;
                studentTableViewModel.ZoomImagen = imagenDict.ElementAt(0).Value;
                dialog.E03ZoomImagen();
                

            }
        }

        public StudentTableViewModel studentTableViewModel { set; get; }
        public ZoomImageCommand(StudentTableViewModel studentTableViewModel)
        {
            this.studentTableViewModel = studentTableViewModel;
        }
    }
}
