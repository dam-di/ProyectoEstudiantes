using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstudiantes.Models
{
    public class EstudianteModel : INotifyPropertyChanged, ICloneable
    {
        

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        private NotasModel notas;
        public NotasModel Notas { get { return notas; } set { notas = value; OnPropertyChanged(nameof(Notas)); } }


        //DNI ESTUDIANTE
        private string id;
        public string _id
        {
            get { return id; }
            set 
            { 
                id = value; 
                OnPropertyChanged(nameof(_id));
            }
        }


        private string nombre;
        public string Nombre 
        { 
            get
            {
                return nombre;
            } 
            set 
            { 
                nombre = value;
                OnPropertyChanged(nameof(Nombre));
            }
        }

        private DateTime fecha;
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; OnPropertyChanged(nameof(Fecha)); }
        }

        private string curso;
        public string Curso {  get { return curso; }
            set { curso = value; OnPropertyChanged(nameof(Curso)); } }

        public EstudianteModel()
        {
            fecha = DateTime.Today;
            Notas = new NotasModel();
        }

    }
}
