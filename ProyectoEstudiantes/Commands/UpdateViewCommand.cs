using ProyectoEstudiantes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProyectoEstudiantes.Commands
{
    class UpdateViewCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Console.WriteLine(parameter.ToString());
            if(parameter is string)
            {
                string vista = parameter.ToString();
                if (vista.Equals("home"))
                {
                    viewModel.SelectedViewModel = new HomeViewModel();
                }else if (vista.Equals("student"))
                {
                    viewModel.SelectedViewModel = new StudentViewModel();

                }else if (vista.Equals("tabla"))
                {
                    viewModel.SelectedViewModel = new StudentTableViewModel();
                }
            }
        }

        public MainViewModel viewModel;
        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
            this.viewModel.SelectedViewModel = new HomeViewModel();
        }

    }
}
