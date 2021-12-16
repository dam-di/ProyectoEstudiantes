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
    class SaveStudentCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            StudentTableView vista = (StudentTableView)parameter;

            Console.WriteLine("FECHA: "+vista.datePickerFecha.Text);
            Console.WriteLine("NOMBRE: "+studentTableViewModel.CurrentStudent.Nombre);
            //Console.WriteLine(studentTableViewModel.CurrentStudent.Fecha);

            if (vista.datePickerFecha.Text.Equals(""))
            {
                vista.txWarning.Text = "Debes poner un fecha";
            }else if (studentTableViewModel.CurrentStudent.Nombre.Equals("") || studentTableViewModel.CurrentStudent.Nombre is null)
            {
                vista.txWarning.Text = "Debes poner un nombre";
            }
            else
            {
                vista.txWarning.Text = "";
                MessageBoxResult result = MessageBox.Show("¿Deseas realizar los cambios?", "Modificar", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        bool okguardar = StudentDBHandler.GuardarEstudiante(studentTableViewModel.CurrentStudent);
                        if (okguardar)
                        {
                            MessageBox.Show("Estudiante modificado con éxito", "Modificar");
                            vista.E01MostrarEstudiante();
                        }
                        else
                        {
                            MessageBox.Show("Error al modificar", "Modificar");

                        }
                        break;
                    
                    case MessageBoxResult.No:
                        break;

                }
            }

            
        }

        public StudentTableViewModel studentTableViewModel { get; set; }
        public SaveStudentCommand(StudentTableViewModel studentTableViewModel)
        {
            this.studentTableViewModel = studentTableViewModel;
        }
    }
}
